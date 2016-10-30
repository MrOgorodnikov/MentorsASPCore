using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MentorsASPCore.Models
{
    public class Mentor
    {
        
        public int Id { get;  set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public int Age { get; set; }
        [Required]
        public int ExperienceInYear { get; set; }
        [Required]
        public int MaxStudentCount { get; set; }
        public string PlaceOfWork { get; set; }

        public ICollection<MentorStudent> MentorStudent { get; set; }
        public ICollection<MentorTecnology> MentorTecnology { get; set; }
        public Mentor()
        {
            MentorStudent = new List<MentorStudent>();
            MentorTecnology = new List<MentorTecnology>();
        }


    }
}
