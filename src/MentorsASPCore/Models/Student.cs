using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentorsASPCore.Models
{
    public class Student
    {
        public int Id { get; private set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public int Age { get; set; }
        
        public ICollection<MentorStudent> MentorStudent { get; set; }
        public ICollection<StudentTecnology> StudentTecnology { get; set; }

        public Student()
        {
            MentorStudent = new List<MentorStudent>();
            StudentTecnology = new List<StudentTecnology>();
        }

    }
}
