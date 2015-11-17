using MVC00.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC00.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var status = new Status()
            {
                Author = "Caycedo",
                ImageUrl = "https://pbs.twimg.com/profile_images/623901785057439744/IyFrAnhy.jpg",
                Project = "Hawk",
                Text = "This status messages now are even better that mere twits. You can say a lot of thngs here, but mostly, more importante, we will say that we now know how to create a simple model to feed a view that is served by a Controller Action Method. Boom!",
                Timestamp = DateTime.Now
            };

            var timeLine = new List<Status>();
            timeLine.Add(status);

            ViewBag.UserName = "rickersilva";

            return View(timeLine);
        }

        public ActionResult NewStatus()
        {
            return View();
        }

        [HttpPost]
        [ActionName("New")]
        public ActionResult NewStatus(Status model)
        {
            if (ModelState.IsValid)
            {
                var status = new Status()
                {
                    Author = "Caycedo",
                    ImageUrl = "https://pbs.twimg.com/profile_images/623901785057439744/IyFrAnhy.jpg",
                    Project = "Hawk",
                    Text = "This status messages now are even better that mere twits. You can say a lot of thngs here, but mostly, more importante, we will say that we now know how to create a simple model to feed a view that is served by a Controller Action Method. Boom!",
                    Timestamp = DateTime.Now.AddSeconds(-5)
                };
                var timeline = new List<Status>();
                timeline.Add(status);

                status = new Status()
                {
                    Author = "Caycedo",
                    ImageUrl = "https://pbs.twimg.com/profile_images/623901785057439744/IyFrAnhy.jpg",
                    Project = model.Project,
                    Text = model.Text,
                    Timestamp = DateTime.Now
                };
                timeline.Add(status);

                return View("Index", timeline.OrderByDescending(s=>s.Timestamp).ToList());
            }

            return PartialView(model);
        }

        public async Task<ActionResult> LoadTimeLine()
        {
            //Do Soemthing that may take an unknown amount of time
            var results = new List<Status>();
            
            return PartialView("TimeLine", results);
        }
    }
}