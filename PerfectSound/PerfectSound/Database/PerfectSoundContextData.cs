using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound.Database
{
    public partial class PerfectSoundContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserType>().HasData(new UserType()
            {
                UserTypeId = 1,
                Type = "Admin"
            });

            modelBuilder.Entity<UserType>().HasData(new UserType()
            {
                UserTypeId = 2,
                Type = "Guest"
            });
        }
    }
}
