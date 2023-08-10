using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IRepository repository;
        public ContactsController(IRepository _repository)
        {
            repository = _repository;
        }
        public IActionResult ContactsPage()
        {
            ViewBag.Kinds = repository.GetKinds();
            return View();
        }
    }
}
