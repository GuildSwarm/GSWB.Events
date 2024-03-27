﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Domain.Entities
{
    public class EventParticipation
    {
        public required Guid MemberId { get; set; }
        public int Duration { get; set; }
        public string? ParticipantNotes { get; set; }
        public string? ManagerNotes { get; set; }
        public required EventRole EventRole { get; set; }
        public DiscordEventChannel? Channel { get; set; }
    }
}