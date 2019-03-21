using Stromatolite.DAL;
using Stromatolite.ViewModels;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace Stromatolite.Controllers
{
    public class HomeController : Controller
    {
        private DataAccessLayer DAL = new DataAccessLayer();
        public async Task<ActionResult> Index()
        {
            OfferViewModel offerViewModel = await OfferViewModel.CreateAsync();
            var title = await DAL.uof.GeneralSettingRepository.GetByFieldAsync(f => f.SettingName == "Заголовок главной траницы (Title)");
            ViewBag.Title = title.SettingValue;
            var metaDescription = await DAL.uof.GeneralSettingRepository.GetByFieldAsync(f => f.SettingName == "MetaDescription");
            ViewBag.MetaDescription = metaDescription.SettingValue;
            var metaKeywords = await DAL.uof.GeneralSettingRepository.GetByFieldAsync(f => f.SettingName == "MetaKeywords");
            ViewBag.MetaKeywords = metaKeywords.SettingValue;
            return View(offerViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}