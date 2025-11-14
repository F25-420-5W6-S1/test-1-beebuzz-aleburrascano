using Microsoft.AspNetCore.Identity;
using BeeBuzz.Data.Entities;

namespace BeeBuzz.Data
{
    public class Seeder
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hosting;
        private readonly RoleManager<IdentityRole<int>> _roleManager;


        public Seeder(ApplicationDbContext context,
            IWebHostEnvironment hosting,
            RoleManager<IdentityRole<int>> roleManager)
        {
            _db = context;
            _hosting = hosting;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            _db.Database.EnsureCreated();

            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole<int>("Admin"));
                await _roleManager.CreateAsync(new IdentityRole<int>("Default"));
            }

            Guid guid;
            Guid.TryParseExact("0000-0000-0000-0000", "XXXX-XXXX-XXXX-XXXX", out guid);

            if (!_db.Organizations.Any())
            {
                var organization = new Organization()
                {
                    Id = guid,
                    Users = null
                };

                var user = new ApplicationUser()
                {
                    UserName = "user",
                    OrganizationId = guid,
                    Organization = organization,
                    Beehives = null
                };

                _db.Organizations.Add(organization);
                _db.Users.Add(user);

                _db.SaveChanges();
            }
        }
    }
}
