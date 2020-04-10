using System.Threading.Tasks;
using HelpLocally.Domain;
using HelpLocally.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpLocally.Web.Pages.Companies
{
    public class EditModel : PageModel
    {
        private readonly HelpLocallyContext _context;

        [BindProperty(SupportsGet = true)] 
        public int Id { get; set; }

        [BindProperty] 
        public Company Company { get; set; }

        public EditModel(HelpLocallyContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Company = await _context.Companies.FindAsync(Id);
        }

        public async Task OnPostAsync()
        {
            var company = await _context.Companies.FindAsync(Company.Id);
            company.Name = Company.Name;
            await _context.SaveChangesAsync();
        }
    }
}