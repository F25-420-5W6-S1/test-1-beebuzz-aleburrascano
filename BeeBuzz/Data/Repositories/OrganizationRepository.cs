using BeeBuzz.Data.Entities;
using BeeBuzz.Data.Interfaces;

namespace BeeBuzz.Data.Repositories
{
    public class OrganizationRepository : BeeBuzzGenericGenericRepository<Organization>, IOrganizationRepository
    {
        private readonly ILogger<OrganizationRepository> _specificLogger;

        public OrganizationRepository(
            ApplicationDbContext db,
            ILogger<BeeBuzzGenericGenericRepository<Organization>> genericLogger,
            ILogger<OrganizationRepository> specificLogger) : base(db, genericLogger)
        {
            _specificLogger = specificLogger;
        }

        public ICollection<ApplicationUser> GetUsersByOrganizationId(Guid organizationId)
        {
            try
            {
                _specificLogger.LogInformation("Getting all users for Organization ID: {OrganizationId}", organizationId);

                var users = _context.Users
                    .Where(u => u.OrganizationId == organizationId)
                    .ToList();

                _specificLogger.LogInformation("Found {Count} users for Organization ID: {OrganizationId}",
                    users.Count, organizationId);

                return users;
            }
            catch (Exception ex)
            {
                _specificLogger.LogError(ex, "Failed to get users for Organization ID: {OrganizationId}", organizationId);
                throw;
            }
        }

        public ICollection<Beehive> GetBeehivesByOrganizationId(Guid organizationId)
        {
            try
            {
                _specificLogger.LogInformation("Getting all beehives for Organization ID: {OrganizationId}", organizationId);

                var users = this.GetUsersByOrganizationId(organizationId);

                var beehives = _context.Beehives
                    .Where(b => users.Any(u => u.Id == b.UserId))
                    .ToList();

                _specificLogger.LogInformation("Found {Count} beehives for Organization ID: {OrganizationId}",
                    beehives.Count, organizationId);

                return beehives;
            }
            catch (Exception ex)
            {
                _specificLogger.LogError(ex, "Failed to get beehives for Organization ID: {OrganizationId}", organizationId);
                throw;
            }
        }
    }
}
