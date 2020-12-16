using System;
using System.Collections.Generic;

#nullable disable

namespace ABLLSP.Models
{
    public partial class MatriMonialProfile
    {
        public long ProfileId { get; set; }
        public string CandidateName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string SiblingInfo { get; set; }
        public string OtherInfo { get; set; }
        public byte Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthTime { get; set; }
        public string BirthPlace { get; set; }
        public string Height { get; set; }
        public int? Weight { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }
        public string MaritalStatus { get; set; }
        public string Education { get; set; }
        public string Occupation { get; set; }
        public string Hobbies { get; set; }
        public long? FamilyId { get; set; }
        public string PhotoUrl { get; set; }
        public byte Status { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
