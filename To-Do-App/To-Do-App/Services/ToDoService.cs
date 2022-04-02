using System;
using System.Collections.Generic;
using To_Do_App.Model;

namespace To_Do_App.Services
{
    public class ToDoService
    {
        List<ToDoModel> ToDoList = new List<ToDoModel>();

        public List<ToDoModel> GetToDos()
        {

            //Sample tasks
            ToDoList.Add( new ToDoModel { Id = 1, Name = "Homework", Descrip = "Do your homework"});
            ToDoList.Add(new ToDoModel { Id = 2, Name = "Buy groceries", Descrip = "Buy groceries from market" });
            ToDoList.Add(new ToDoModel { Id = 3, Name = "Wash clothes", Descrip = "Wash your clothes" });

            return ToDoList;
        }
        public ToDoService()
        {
        }
    }
}
