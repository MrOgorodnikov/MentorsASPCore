using MentorsASPCore.Models;
using MentorsASPCore.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorsASPCore.BussinesLogic
{
    public class Home
    {
        public static List<MentorTecnologyDTO> CreateMentorTecnologyList(MentorsContext db)
        {
            var mtDTO = new List<MentorTecnologyDTO>();
            var mentorList = db.Mentors
                            .Include(mt => mt.MentorTecnology)
                            .ThenInclude(t => t.Tecnology)
                            .ToList();
            foreach (var mentor in mentorList)
            {
                var tecnologyList = mentor.MentorTecnology
                                    .Select(t => t.Tecnology)
                                    .ToList();
                foreach (var tecnology in tecnologyList)
                    mtDTO.Add(new MentorTecnologyDTO { Mentor = mentor, Tecnology = tecnology});
            }

            return mtDTO;
        }

        public static List<MentorStudentDTO> CreateMentorStudentList(MentorsContext db)
        {
            var msDTO = new List<MentorStudentDTO>();
            var mentorList = db.Mentors
                            .Include(ms => ms.MentorStudent)
                            .ThenInclude(s => s.Student)
                            .ToList();
            foreach (var mentor in mentorList)
            {
                var studentList = mentor.MentorStudent
                                 .Select(s => s.Student)
                                 .ToList();
                foreach (var student in studentList)
                    msDTO.Add(new MentorStudentDTO { Mentor = mentor, Student = student });
            }

            return msDTO;
        }

        public static void AddMentor(Mentor mentor, List<string> requestFormKeys, MentorsContext db)
        {
            var newMentor = new Mentor
            {
                Name = mentor.Name,
                Surname = mentor.Surname,
                Age = mentor.Age,
                ExperienceInYear = mentor.ExperienceInYear,
                MaxStudentCount = mentor.MaxStudentCount,
                PlaceOfWork = mentor.PlaceOfWork
            };
            db.Mentors.Add(newMentor);
            db.SaveChanges();
            AddTecnologiesToMentor(newMentor, requestFormKeys, db);

            db.SaveChanges();
        }

        public static void AddTecnologiesToMentor(Mentor mentor, List<string> requestFormKeys, MentorsContext db)
        {
            foreach (var x in requestFormKeys)
            {
                int id;
                if (int.TryParse(x, out id))
                    db.Mentors
                        .First(m => m.Id == mentor.Id)
                        .MentorTecnology
                        .Add(new MentorTecnology
                        {
                            Mentor = mentor,
                            Tecnology =
                        db.Tecnologies.First(t => t.Id == id)
                        });
            }
        }
    }
}
