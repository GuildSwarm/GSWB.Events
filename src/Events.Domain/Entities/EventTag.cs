﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.Entities
{
    public class EventTag
    {
        public required string Name { get; set; }
        public string? Description { get; set; }


        public virtual ICollection<EventTemplate> EventTemplates { get; set; } = [];
        public virtual ICollection<Event> Events { get; set; } = [];

    }
}
