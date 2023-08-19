using Galacticos.Application.Persistence.Contracts;
using Galacticos.Infrastructure.Data;
using Galacticos.Domain.Entities;

namespace Galacticos.Infrastructure.Persistence.Repositories
{
    public class NewsFeedRepository : INewsFeedRepository
    {
        private readonly SocialMediaDbContext _dbContext;
        private readonly IRelationRepository _relationRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        public NewsFeedRepository(SocialMediaDbContext dbContext, IRelationRepository relationRepository, IPostRepository postRepository, IUserRepository userRepository)
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
            var aggregatedPosts = new List<Post>();

            foreach (var followedUserId in followedUserIds)
            {
                var postsFromFollowedUser = await _postRepository.GetPostsByUserId(followedUserId);
                aggregatedPosts.AddRange(postsFromFollowedUser);
            }

            var paginatedPosts = aggregatedPosts
                .OrderByDescending(post => post.CreatedAt)
                .Skip(itemsToSkip)
                .Take(pageSize);

            var newsFeedData = new List<object>();

            foreach (var post in paginatedPosts)
            {
                var author = await _userRepository.GetById(post.UserId);

                var newsFeedItem = new
                {
                    PostId = post.Id,
                    Image = post.Image,
                    AuthorName = author.UserName,
                    DateCreated = post.UpdatedAt
                };

                newsFeedData.Add(newsFeedItem);
            }

            return newsFeedData;
        }
    }
}