using Galacticos.Application.Persistence.Contracts;

namespace Galacticos.Infrastructure.Persistence.Repositories
{
    public class NewsFeedRepository : INewsFeedRepository
    {
        private readonly DbContext _dbContext;
        private readonly IRelationRepository _relationRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        public NewsFeedRepository(DbContext dbContext, IRelationRepository relationRepository, IPostRepository postRepository, IUserRepository userRepository)
        {
            _dbContext = dbContext;
            _relationRepository = relationRepository;
            _postRepository = postRepository;
            _userRepository = userRepository;
        }

        public async Task<List<object>> GetNewsFeedForUser(int userId, int pageNumber, int pageSize)
        {
            int itemsToSkip = (pageNumber - 1) * pageSize;

            var followedUserIds = await _relationRepository.GetFollowedUserIdsByUserId(userId);
            var aggregatedPosts = new List<object>();

            foreach (var followedUserId in followedUserIds)
            {
                var postsFromFollowedUser = await _postRepository.GetPostsByUserId(followedUserId);
                aggregatedPosts.AddRange(postsFromFollowedUser);
            }

            var paginatedPosts = aggregatedPosts
                .OrderByDescending(post => post.DateCreated)
                .Skip(itemsToSkip)
                .Take(pageSize);

            var newsFeedData = new List<object>();

            foreach (var post in postsFromFollowedUser)
            {
                var author = await _userRepository.GetUserById(post.AuthorId);

                var newsFeedItem = new
                {
                    PostId = post.Id,
                    Content = post.Content,
                    AuthorName = author.Username,
                    DateCreated = post.DateCreated
                };

                newsFeedData.Add(newsFeedItem);
            }

            return newsFeedData;
        }
    }
}