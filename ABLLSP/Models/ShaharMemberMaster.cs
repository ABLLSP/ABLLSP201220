using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ABLLSP.Models
{
    public partial class ShaharMemberMaster
    {
        public long MemberId { get; set; }
        public int ShaharId { get; set; }
        public string MemberName { get; set; }
        public byte DesignationId { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }
        public string PhotoUrl { get; set; }
        public byte Status { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }

        [ForeignKey("ShaharId")]
        public ShaharMaster ShaharMaster { get; set; }

        [ForeignKey("DesignationId")]
        public ShaharDesignationMaster ShaharDesignationMaster { get; set; }
    }
}
