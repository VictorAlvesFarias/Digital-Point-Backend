using Microsoft.AspNetCore.Identity;

namespace DigitalPoint.Domain.Entities
{
    public class ApplicationUser:IdentityUser {
        public ICollection<WorkPoint> WorkPoint { get; } = new List<WorkPoint>();

        public string Name { get; set; }
    }
}
