using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorsASPCore.Models.View
{
    public class StudentView
    {
        public Student Student { get; set; }
        public List<Mentor> Mentors { get; set; }
        public List<Tecnology> Tecnologies { get; set; }
    }
}
