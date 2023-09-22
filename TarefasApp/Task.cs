using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefasApp
{
    public class Task
    {
        public String taskTitle { get; set; }
        public String taskDescription { get; set; }
        public DateTime CreationDate { get; set; }
        public string Priority { get; set; }
    }
}


