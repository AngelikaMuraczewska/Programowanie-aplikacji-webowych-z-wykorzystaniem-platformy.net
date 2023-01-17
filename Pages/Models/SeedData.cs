using Microsoft.EntityFrameworkCore;
using HRapp.Data;
using Microsoft.AspNetCore.Identity;

namespace HRapp.Pages.Models
{
    public class SeedData
    {
        public static void Initialize(
            IServiceProvider serviceProvider)
        {
            using (var context = new HRappContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<HRappContext>>()))
            {
                if (context == null || context.Employee == null)
                {
                    throw new ArgumentNullException("Null HRappContext");
                }

                if (context.Employee.Any())
                {
                    return;
                }

                context.Employee.AddRange(
               new Employee
               {
                   Name = "Alicja",
                   Surname = "Włodarczyk",
                   ReleaseDate = DateTime.Parse("2010-2-12"),
                   DateOfBirth = DateTime.Parse("1980-6-18"),
                   DateOfStart = DateTime.Parse("2010-3-1"),
                   Departament = "Helpdesk",
                   Position = "Młodszy Specjalista ds. Klientów"
               },

                new Employee
                {
                    Name = "Katarzyna",
                    Surname = "Siewczyk",
                    ReleaseDate = DateTime.Parse("2020-1-1"),
                    DateOfBirth = DateTime.Parse("1987-6-11"),
                    DateOfStart = DateTime.Parse("2020-1-1"),
                    Departament = "Helpdesk",
                    Position = "Młodszy Specjalista ds. Klientów"
                },

                 new Employee
                 {
                     Name = "Kinga",
                     Surname = "Cabecka",
                     ReleaseDate = DateTime.Parse("2011-8-20"),
                     DateOfBirth = DateTime.Parse("1987-2-21"),
                     DateOfStart = DateTime.Parse("2011-9-1"),
                     Departament = "Sales",
                     Position = "Specjalista ds. Handlowych"
                 }
            );
                context.SaveChanges();
            }
        }

        internal static void Initialize(object serviceProvider)
        {
            throw new NotImplementedException();
        }
    }
}





