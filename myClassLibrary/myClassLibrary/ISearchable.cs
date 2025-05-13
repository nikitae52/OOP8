using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myClassLibrary
{
    public interface ISearchable
    {
        List<Student> SearchStudents(string keyword);
    }
}
