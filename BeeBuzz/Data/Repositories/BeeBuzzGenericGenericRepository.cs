using BeeBuzz.Data.Interfaces;
using BeeBuzz.Data;
using Microsoft.EntityFrameworkCore;

namespace BeeBuzz.Data.Repositories
{
    public class BeeBuzzGenericGenericRepository<T> : IBeeBuzzGenericRepository<T> where T : class
    {
        internal readonly ILogger<BeeBuzzGenericGenericRepository<T>> _logger;
        internal readonly ApplicationDbContext _context;
        internal readonly DbSet<T> _dbSet;

        public BeeBuzzGenericGenericRepository(ApplicationDbContext db, ILogger<BeeBuzzGenericGenericRepository<T>> logger) 
        {
            _logger = logger;
            _context = db;
            _dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            try
            {
                _logger.LogInformation("Adding new {EntityType} to database", typeof(T).Name);
                _dbSet.Add(entity);
                _logger.LogInformation("Successfully added {EntityType} (not yet saved)", typeof(T).Name);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to add {EntityType}", typeof(T).Name);
                throw;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                _logger.LogInformation("Deleting {EntityType} from database", typeof(T).Name);
                _dbSet.Remove(entity);
                _logger.LogInformation("Successfully deleted {EntityType} (not yet saved)", typeof(T).Name);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to delete {EntityType}", typeof(T).Name);
                throw;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                _logger.LogInformation("Getting all {EntityType} from database", typeof(T).Name);
                var result = _dbSet.ToList();
                _logger.LogInformation("Successfully retrieved {Count} {EntityType} records", result.Count, typeof(T).Name);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get all {EntityType}", typeof(T).Name);
                return null;
            }
        }

        public T GetById(object id)
        {
            try
            {
                _logger.LogInformation("Getting {EntityType} with ID: {Id}", typeof(T).Name, id);
                var result = _dbSet.Find(id);

                if (result == null)
                {
                    _logger.LogWarning("{EntityType} with ID {Id} not found", typeof(T).Name, id);
                }
                else
                {
                    _logger.LogInformation("Successfully retrieved {EntityType} with ID: {Id}", typeof(T).Name, id);
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get {EntityType} by ID: {Id}", typeof(T).Name, id);
                throw;
            }
        }

        public void SaveAll()
        {
            try
            {
                _logger.LogInformation("Saving changes to database");
                var entriesAffected = _context.SaveChanges();
                _logger.LogInformation("Successfully saved {Count} changes to database", entriesAffected);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to save changes to database");
                throw;
            }
        }

        public void Update(T entity)
        {
            try
            {
                _logger.LogInformation("Updating {EntityType} in database", typeof(T).Name);
                _dbSet.Update(entity);
                _logger.LogInformation("Successfully updated {EntityType} (not yet saved)", typeof(T).Name);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update {EntityType}", typeof(T).Name);
                throw;
            }
        }
    }
}
