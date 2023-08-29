using Galacticos.Domain.Entities.Common;

namespace Galacticos.Domain.Entities
{
    public class UserConnection : BaseEntity
    {
        public Guid userId { get; set; }
        public string? connectionId { get; set; }
        public User? user { get; set; }
    }
}