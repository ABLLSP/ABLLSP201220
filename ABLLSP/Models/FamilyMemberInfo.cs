using System;
using System.Collections.Generic;

#nullable disable

namespace ABLLSP.Models
{
    public partial class FamilyMemberInfo
    {
        public long FamilyMemberId { get; set; }
        public long FamilyId { get; set; }
        public string FamilyMemberName { get; set; }
        public string Relation { get; set; }
        public byte? Age { get; set; }
        public string Education { get; set; }
        public string MaritalStatus { get; set; }
        public string Occupation { get; set; }
        public byte Status { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
