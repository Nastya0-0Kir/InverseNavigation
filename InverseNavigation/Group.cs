using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InverseNavigation
{
    public class Group
    {
        public Guid Id { get; set; }
        public string NameGroup { get; set; }
        public List<Student> Students { get; set; }
       // public string NameStudent;
        
    }
}
