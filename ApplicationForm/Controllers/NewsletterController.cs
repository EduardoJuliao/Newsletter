using ApplicationForm.Business;
using ApplicationForm.Models;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace ApplicationForm.Controllers
{
    public class NewsletterController : Controller
    {
        private NewsletterManager NewsletterManager { get; }


        public NewsletterController()
        {
            this.NewsletterManager = new NewsletterManager();
        }

        public ActionResult Index()
        {
            return View();
        }

        // GET: Newsletter
        public ActionResult Header()
        {
            return View();
        }

        public ActionResult PastMonths()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Apply(ApplyModel apply)
        {
            if (ModelState.IsValid)
            {
                NewsletterManager.Apply(apply);
                return Json(new HttpStatusCodeResult(HttpStatusCode.OK), JsonRequestBehavior.AllowGet);
            }
            else
                throw new System.Exception(ModelState.GetErrorString());
        }
    }
}