﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGF.CA.Domain.Primitives;

namespace Events.Domain.Entities
{
    public class Activity : Entity<Guid>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }

    }
}
