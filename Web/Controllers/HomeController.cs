using System.Web.Mvc;
using Web.BLL.Interface;
using Web.BLL.Services;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        IEmployeeService _service;
        public HomeController()
        {
            _service = new InSessionEmployeeService();
        }
        public ActionResult Index()
        {            
            return View();
        }        
    }
}