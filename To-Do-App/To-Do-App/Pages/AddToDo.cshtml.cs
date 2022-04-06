/*
 * Razor page to add a new todo
 */


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using To_Do_App.Model;
using To_Do_App.Services;

namespace To_Do_App.Pages
{

    public class AddToDoModel: PageModel
    {
        public ToDoModel ToDoItem = new();
        private ToDoService _service;

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Descrip { get; set; }

        public AddToDoModel(ToDoService service)
        {
            _service = service;
        }

        //Fill the field if user came from edit button
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id != null)
            {
                List<ToDoModel> items = _service.GetUncompleteToDos();

                ToDoItem = items.FirstOrDefault(m => m.Id == id);

                Name = ToDoItem.Name;
                Descrip = ToDoItem.Descrip;
            }

            return Page();
        }


        //Called on Submit to button to create a new todo or edit a todo
        public IActionResult OnPostSubmit(ToDoModel model)
        {
            if (model.Name == null)
            {
                return null;
            }

            if (model.Id == null)
            {
                model.Id = _service.GetUncompleteToDos().Count + 1;
                model.IsDone = false;
                _service.AddToDo(model);
            }
            else
            {
                List<ToDoModel> items = _service.GetUncompleteToDos();
                int index = items.FindIndex(m => m.Id == model.Id);
                _service.AddToDoAt(model, index);
            }

            return RedirectToPage("Home");

        }

    }
}