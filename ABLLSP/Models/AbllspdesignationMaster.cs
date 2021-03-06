﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ABLLSP.Models
{
    public partial class AbllspdesignationMaster
    {
        public byte DesignationId { get; set; }
        public string DesignationName { get; set; }
        public byte Status { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }

        public ICollection<AbllspmemberMaster> AbllspmemberMaster { get; set; }
    }
}
