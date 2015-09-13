using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class ToDoModel
    {
        private ToDoItem[] _todoItems;

        public ToDoModel()
        { }

        public ToDoModel(IEnumerable<ToDoItem> todoItems)
        {
            _todoItems = todoItems.ToArray();
        }

        public IEnumerable<ToDoItem> Items
        {
            get
            {
                return _todoItems;
            }
        }

        [Required]
        [MinLength(1)]
        public string NewItemName { get; set; }
    }
}