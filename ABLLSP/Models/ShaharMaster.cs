using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("PrantId")]
        public PrantMaster PrantMaster { get; set; }

        public ICollection<ShaharMemberMaster> ShaharMembers { get; set; }

        public ICollection<FamilyHeadInfo> FamilyHeadInfos { get; set; }
        //public object ShaharMasters { get; internal set; }
    }
}
