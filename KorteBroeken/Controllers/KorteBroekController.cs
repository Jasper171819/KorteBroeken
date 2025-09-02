using Microsoft.AspNetCore.Mvc;

namespace KorteBroeken.Controllers
{
    public class KorteBroekController : Controller
    {
        // GET: /KorteBroek/Index/{id?}
        public IActionResult Index()
        {
            string vraag = "Kan ik vandaag een korte broek aan?";
            return View("Index", vraag);
        }

        public IActionResult Weer()
        {
            var weerData = (temperatuur: 22, regenkans: 68);
            return View("Weer", weerData);
        }
    }
}