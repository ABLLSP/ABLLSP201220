using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ABLLSP.Models
{
    public partial class PrantMemberMaster
    {
        [Key]
        public int MemberId { get; set; }
        public byte PrantId { get; set; }
        public string MemberName { get; set; }
        public byte DesignationId { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }
        public string PhotoUrl { get; set; }
        public byte Status { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }

        [ForeignKey("PrantId")]
        public PrantMaster PrantMaster { get; set; }

        [ForeignKey("DesignationId")]
        public PrantDesignationMaster PrantDesignationMaster { get; set; }
    }
}
