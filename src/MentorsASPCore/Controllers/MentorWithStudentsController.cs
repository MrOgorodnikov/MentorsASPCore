using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MentorsASPCore.Models.DTO;
using MentorsASPCore.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorsASPCore.Controllers
{
    public class MentorWithStudentsController : Controller
    {
        MentorsContext db;

        public MentorWithStudentsController(MentorsContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {

            return View(CreateMentorStudentList());
        }

        private List<MentorStudentDTO> CreateMentorStudentList()
        {
            var msDTO = new List<MentorStudentDTO>();
            var mentorList = db.Mentors.Include(ms => ms.MentorStudent).ThenInclude(s => s.Student).ToList();
            foreach (var mentor in mentorList)
            {
                var studentList = mentor.MentorStudent.Select(s => s.Student).ToList();
                foreach (var student in studentList)
                    msDTO.Add(new MentorStudentDTO { Mentor = mentor, Student = student });
            }

            return msDTO;
        }
    }
}
