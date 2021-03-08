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
    public class DeleteModel : PageModel
    {
        private readonly ABLLSP.Models.ABLLSPContext _context;

        public DeleteModel(ABLLSP.Models.ABLLSPContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MatriMonialProfileAttachment = await _context.MatriMonialProfileAttachments.FindAsync(id);

            if (MatriMonialProfileAttachment != null)
            {
                _context.MatriMonialProfileAttachments.Remove(MatriMonialProfileAttachment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
