using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("ShaharId")]
        public ShaharMaster ShaharMaster { get; set; }

        public ICollection<FamilyMemberInfo> FamilyMemberInfos { get; set; }

        //public ICollection<FamilyHeadInfo> FamilyHeadDetails { get; set; }

        //[ForeignKey("FamilyId")]
        //public FamilyMemberInfo familyMemberInfo { get; set; }

    }
}
