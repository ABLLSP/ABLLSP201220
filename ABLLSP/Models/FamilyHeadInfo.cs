using System;
using System.Collections.Generic;

#nullable disable

namespace ABLLSP.Models
{
    public partial class FamilyHeadInfo
    {
        public long FamilyId { get; set; }
        public int ShaharId { get; set; }
        public string FamilyHeadName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }
        public string Origin { get; set; }
        public byte Status { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
