﻿using PerfectSound.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerfectSound.Interfaces
{
    public interface INewsService
    {
        List<News> GetLast3();
    }
}
