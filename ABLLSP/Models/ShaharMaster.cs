using System;
using System.Collections.Generic;

#nullable disable

namespace ABLLSP.Models
{
    public partial class ShaharMaster
    {
        public int ShaharId { get; set; }
        public byte PrantId { get; set; }
        public string ShaharName { get; set; }
        public string ShaharInfo { get; set; }
        public byte Status { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }

        public ICollection<ShaharMemberMaster> ShaharMasters { get; set; }
    }
}
