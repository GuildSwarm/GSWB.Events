using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TGF.CA.Domain.Primitives;

namespace Events.Domain.Entities
{
    public class DiscordEventChannelTemplate : Entity<Guid>
    {
        /// <summary>
        /// Channel without parent will be considered asnt he category channel
        /// </summary>
        public DiscordEventChannelTemplate? Parent { get; set; }
        public ulong DiscordChannelId { get; set; }
        public string? Name { get; set; }
        public ChannelType Type { get; set; }

    }
}
