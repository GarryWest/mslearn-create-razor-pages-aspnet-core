using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Pages
{
    public class PizzaListModel : PageModel
    {
        private readonly PizzaService _service;
        public IList<Pizza> PizzaList { get; set; } = default!;

        [BindProperty]
        public Pizza NewPizza { get; set; } = default!;

        public PizzaListModel(PizzaService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            PizzaList = _service.GetPizzas();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid && NewPizza != null)
            {
                _service.AddPizza(NewPizza);
                return RedirectToAction("Get");
            }
            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            if (id > 0)
            {
                _service.DeletePizza(id);
                return RedirectToAction("Get");
            }
            return Page();
        }
    }
}