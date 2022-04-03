using System;
using System.Collections.Generic;
using To_Do_App.Model;

namespace To_Do_App.Services
{
    public class ToDoService
    {
        List<ToDoModel> ToDoList = new();
        List<ToDoModel> UnCompleteToDoList = new();

        public List<ToDoModel> GetUncompleteToDos()
        {
            return UnCompleteToDoList;
        }

        public List<ToDoModel> AddToDo(ToDoModel model)
        {
            ToDoList.Add(model);
            return ToDoList;
        }

        public void AddToDoAt(ToDoModel model, int index)
        {
            ToDoList.RemoveAt(index);
            ToDoList.Insert(index, model);
        }

        public List<ToDoModel> RemoveToDo(int id)
        {
            int ItemIndex = 0;

            for (int i = 0; i < ToDoList.Count; i++)
            {
                if (ToDoList[i].Id == id)
                {
                    ItemIndex = i;
                }
            }

            ToDoList.RemoveAt(index: ItemIndex);
            return ToDoList;
        }

        public List<ToDoModel> MarkAsDone(ToDoModel model)
        {
            model.IsDone = true;
            model.CompletionDate = DateTime.Now;
            int index = UnCompleteToDoList.FindIndex(m => m.Id == model.Id);
            UnCompleteToDoList.RemoveAt(index);

            return UnCompleteToDoList;
        }

        public ToDoService()
        {
            //Sample tasks
            ToDoList.Add(new ToDoModel { Id = 1, Name = "Homework", Descrip = "Do your homework", IsDone = false });
            ToDoList.Add(new ToDoModel { Id = 2, Name = "Buy groceries", Descrip = "Buy groceries from market", IsDone = false });
            ToDoList.Add(new ToDoModel { Id = 3, Name = "Wash clothes", Descrip = "Wash your clothes", IsDone = false });

            UnCompleteToDoList = ToDoList;
        }
    }
}
