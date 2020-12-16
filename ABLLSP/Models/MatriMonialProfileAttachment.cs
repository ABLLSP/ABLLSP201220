using System;
using System.Collections.Generic;

#nullable disable

namespace ABLLSP.Models
{
    public partial class MatriMonialProfileAttachment
    {
        public long AttachmentId { get; set; }
        public long ProfileId { get; set; }
        public string AttachmentUrl { get; set; }
        public byte Status { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
