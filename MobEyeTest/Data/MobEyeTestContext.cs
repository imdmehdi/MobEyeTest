using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MobEyeTest.Models;

namespace MobEyeTest.Data
{
    public class MobEyeTestContext : DbContext
    {
        private static bool _created = false;
        public MobEyeTestContext (DbContextOptions<MobEyeTestContext> options)
            : base(options)
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }

        public DbSet<MobEyeTest.Models.FormJson> FormJson { get; set; }
        public DbSet<MobEyeTest.Models.FormDetails> FormDetails { get; set; }

    }
}
