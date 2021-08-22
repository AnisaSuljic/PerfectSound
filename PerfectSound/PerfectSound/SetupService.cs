using Microsoft.EntityFrameworkCore;
using PerfectSound.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound
{
    public class SetupService
    {
        public static void Init(PerfectSoundContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
