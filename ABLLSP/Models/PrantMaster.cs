using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ABLLSP.Models
{
    public partial class PrantMaster
    {
        public byte PrantId { get; set; }
        public string PrantName { get; set; }
        public string PrantInfo { get; set; }
        public byte Status { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }

        //[InverseProperty("PrantMemberMaster")]
        public ICollection<PrantMemberMaster> PrantMembers { get; set; }

        public ICollection<ShaharMaster> ShaharMasters { get; set; }
    }
}
