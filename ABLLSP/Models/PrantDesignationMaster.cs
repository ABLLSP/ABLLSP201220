using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ABLLSP.Models
{
    public partial class PrantDesignationMaster
    {
        [Key]
        public byte DesignationId { get; set; }
        public string DesignationName { get; set; }
        public byte Status { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }

        //[InverseProperty("PrantMemberMaster")]
        public ICollection<PrantMemberMaster> PrantMembers { get; set; }
    }
}
