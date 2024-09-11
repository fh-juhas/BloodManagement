using Microsoft.AspNetCore.Mvc;

namespace BloodManagement.Web.Controllers
{
    public class DonorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}