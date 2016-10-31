using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MentorsASPCore.Models;
using Microsoft.EntityFrameworkCore;
using MentorsASPCore.Models.DTO;
using MentorsASPCore.BussinesLogic;
using System.Collections.Generic;

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
            return View(Home.CreateMentorStudentList(db));
        }

        public IActionResult Mentors()
        {
            return View(Home.CreateMentorTecnologyList(db));
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
            return View(new MentorTecnologiesDTO
            {
                Mentor = mentor,
                AllTecnologies = tecnologiesList,
                MentorsTecnologies = mentorsTecnologies
            });
        }

        [HttpPost]
        public RedirectResult ChangeMentorInfo(Mentor mentor)
        {
            db.Mentors.Update(mentor);

            var ment = db.Mentors.Include(m => m.MentorTecnology).First(m => m.Id == mentor.Id);

            for(int i = 0; i < ment.MentorTecnology.Count; i++)
            {
                var mentTec = ment.MentorTecnology.First(mt => mt.MentorId == ment.Id);
                ment.MentorTecnology.Remove(mentTec);
                db.SaveChanges();
            }
                        
            
            Home.AddTecnologiesToMentor(mentor, Request.Form.Keys.ToList(), db);
            

            return Redirect("~/Home/Mentors");
        }

        public IActionResult AddMentor()
        {
            return View(db.Tecnologies.ToList());
        }

        [HttpPost]
        public RedirectResult AddMentor(Mentor mentor)
        {
            Home.AddMentor(mentor, Request.Form.Keys.ToList(), db);

            return Redirect("~/Home/Mentors");
        }

        

        

        

       
    }
}
