using BeeBuzz.Data.Entities;

namespace BeeBuzz.Data.Repositories
{
    public class BeehiveRepository : BeeBuzzGenericGenericRepository<Beehive>
    {
        private readonly ILogger<BeehiveRepository> _specificLogger;

        public BeehiveRepository(
            ApplicationDbContext db,
            ILogger<BeeBuzzGenericGenericRepository<Beehive>> genericLogger,
            ILogger<BeehiveRepository> specificLogger) : base(db, genericLogger)
        {
            _specificLogger = specificLogger;
        }
    }
}
