using System;
using System.Collections.Generic;

#nullable disable

namespace ABLLSP.Models
{
    public partial class Event
    {
        public long EventId { get; set; }
        public string EventName { get; set; }
        public DateTime? EventDate { get; set; }
        public byte? EventType { get; set; }
        public byte Status { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
