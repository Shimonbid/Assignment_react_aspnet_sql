using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class UserQueriesContext : DbContext
    {
        public UserQueriesContext(DbContextOptions<UserQueriesContext> options)
        : base(options)
        {
        }

        public DbSet<UserQueries> UserQueries { get; set; }
        public DbSet<Results> Results { get; set; }
    }
}
