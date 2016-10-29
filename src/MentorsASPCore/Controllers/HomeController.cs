using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MentorsASPCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using MentorsASPCore.Models.DTO;

namespace MentorsASPCore.Controllers
{
    public class HomeController : Controller
    {
        MentorsContext db;

        public HomeController(MentorsContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MentorStudent()
        {
            return View(CreateMentorStudentList());
        }

        public IActionResult Mentors()
        {
            return View(CreateMentorTecnologyList());
        }
        [HttpGet]
        public IActionResult ChangeMentorInfo(int Id)
        {
            var mentor = db.Mentors.First(m => m.Id == Id);
            var tecnologiesList = db.Tecnologies.ToList();
            var mentorsTecnologies = db.Mentors
                                    .Include(mt => mt.MentorTecnology)
                                    .ThenInclude(t => t.Tecnology)
                                    .ToList()
                                    .First(id => id.Id == Id)
                                    .MentorTecnology
                                    .Select(t => t.Tecnology)
                                    .ToList();
                
            
            ViewBag.MentorId = Id;
            return View(new MentorTecnologiesDTO { Mentor = mentor, AllTecnologies = tecnologiesList, MentorsTecnologies = mentorsTecnologies});
        }

        [HttpPost]
        public RedirectResult ChangeMentorInfo(Mentor mentor)
        {
            db.Mentors.Update(mentor);
            db.SaveChanges();

            //Use it Tecnology.Id only int

            //foreach (var x in Request.Form.Keys)
            //{
            //    x.A
            //}
            

            return Redirect("~/Home/Mentors");
        }

        private List<MentorTecnologyDTO> CreateMentorTecnologyList()
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

        private List<MentorStudentDTO> CreateMentorStudentList()
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

       
    }
}
