using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRapp.Data;
using HRapp.Pages.Models;

namespace HRapp.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly HRapp.Data.HRappContext _context;

        public IndexModel(HRapp.Data.HRappContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Surname { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? EmployeeSurname { get; set; }

        public async Task OnGetAsync()
        {

            IQueryable<string> surnameQuery = from m in _context.Employee
                                              orderby m.Surname
                                              select m.Surname;

            var employees = from m in _context.Employee
                            select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                employees = employees.Where(s => s.Departament.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(EmployeeSurname))
            {
                employees = employees.Where(x => x.Surname == EmployeeSurname);
            }
            Surname = new SelectList(await surnameQuery.Distinct().ToListAsync());

            Employee = await employees.ToListAsync();

            employees = _context.Employee;
        }   
    }
}

