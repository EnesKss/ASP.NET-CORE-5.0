using App.Models;
using System.Collections.Generic;

namespace App.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetAllStudents();
    }
}
