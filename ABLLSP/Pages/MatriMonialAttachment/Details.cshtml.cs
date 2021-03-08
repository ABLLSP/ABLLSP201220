using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ABLLSP.Models;

namespace ABLLSP.Pages.MatriMonialAttachment
{
    public class DetailsModel : PageModel
    {
        private readonly ABLLSP.Models.ABLLSPContext _context;

        public DetailsModel(ABLLSP.Models.ABLLSPContext context)
        {
            _context = context;
        }

        public MatriMonialProfileAttachment MatriMonialProfileAttachment { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MatriMonialProfileAttachment = await _context.MatriMonialProfileAttachments.FirstOrDefaultAsync(m => m.AttachmentId == id);

            if (MatriMonialProfileAttachment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
