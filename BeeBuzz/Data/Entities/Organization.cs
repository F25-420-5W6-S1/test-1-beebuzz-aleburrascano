using System.ComponentModel.DataAnnotations;

namespace BeeBuzz.Data.Entities
{
    public class Organization
    {
        public Guid Id { get; set; }
        public ICollection<ApplicationUser>? Users { get; set; }
    }
}
