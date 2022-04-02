using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using To_Do_App.Model;
using To_Do_App.Services;

namespace To_Do_App.Pages
{
    public class HomeModel : PageModel
    {
        private ToDoService _service;
        public List<ToDoModel> Items { get; set; }

        public HomeModel(ToDoService service)
        {
            _service = service;
        }

        public ActionResult OnGet()
        {
            Items = _service.GetToDos();
            return Page();
        }
    }
}