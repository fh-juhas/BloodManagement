using Microsoft.AspNetCore.Mvc;

namespace BloodManagement.Web.Controllers
{
    public class DonationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}