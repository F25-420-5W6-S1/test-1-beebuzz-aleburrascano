using BeeBuzz.Data.Entities;

namespace BeeBuzz.Data.Interfaces
{
    public interface IOrganizationRepository
    {
        ICollection<Beehive> GetBeehivesByOrganizationId(Guid organizationId);
        ICollection<ApplicationUser> GetUsersByOrganizationId(Guid organizationId);
    }
}