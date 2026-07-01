using App.Models;
using System.Collections.Generic;

namespace App.ViewModels
{
    public class StudentListViewModel
    {
        public IEnumerable<Student> Students { get; set; }
    }
}
