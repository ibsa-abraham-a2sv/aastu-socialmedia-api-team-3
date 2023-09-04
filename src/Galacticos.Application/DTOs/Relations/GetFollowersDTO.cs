namespace Galacticos.Application.DTOs.Relations{
    public class GetFollowersDTO{
        public Guid FollowerId { get; set; }
        public string FollowerName { get; set; }
        public string FollowerSurname { get; set; }
        public string FollowerUsername { get; set; }
        public string Picture { get; set; }
    }
}