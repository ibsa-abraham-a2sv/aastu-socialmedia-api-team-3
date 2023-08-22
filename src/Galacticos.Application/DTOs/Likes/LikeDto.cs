using Galacticos.Application.DTOs.Common;

namespace Galacticos.Application.DTOs.Likes
{
    public class LikeDto : BaseEntityDto
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
    }
}