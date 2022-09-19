using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InverseNavigation
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        
    }
}
