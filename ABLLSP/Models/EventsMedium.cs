using System;
using System.Collections.Generic;

#nullable disable

namespace ABLLSP.Models
{
    public partial class EventsMedium
    {
        public long MediaId { get; set; }
        public long EventId { get; set; }
        public string MediaUrl { get; set; }
        public byte MediaType { get; set; }
        public byte Status { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
