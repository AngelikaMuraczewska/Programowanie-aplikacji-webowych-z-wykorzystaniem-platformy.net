using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HRapp.Data;
using HRapp.Pages.Models;

namespace HRapp.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly HRapp.Data.HRappContext _context;

        public DeleteModel(HRapp.Data.HRappContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Employee == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FirstOrDefaultAsync(m => m.Id == id);

            if (employee == null)
            {
                return NotFound();
            }
            else 
            {
                Employee = employee;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Employee == null)
            {
                return NotFound();
            }
            var employee = await _context.Employee.FindAsync(id);

            if (employee != null)
            {
                Employee = employee;
                _context.Employee.Remove(Employee);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
