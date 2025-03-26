using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FileLab.Data
{
    public class AuthDbContext : IdentityDbContext<IdentityUser>
    {
        public AuthDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AuthDbContext()
        {
        }
    }
}
