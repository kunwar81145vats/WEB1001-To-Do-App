/*
 * Model class for the todo
 */


using System;
namespace To_Do_App.Model
{
    public class ToDoModel
    {
        public int? Id { get; set; }
        public String Name { get; set; }
        public String Descrip { get; set; }
        public bool IsDone { get; set; }
        public DateTime CompletionDate { get; set; }

        public ToDoModel()
        {
        }
    }
}
