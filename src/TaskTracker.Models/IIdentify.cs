﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Models
{
    public interface IIdentify
    {
        public Guid Id { get; set; }
    }
}
