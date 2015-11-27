using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductRepository _repository;

        public AdminController(IProductRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            return View(_repository.Products);
        }

        public ViewResult Edit(int? productId)
        {
            Product product = _repository.Products.Single(x => x.ProductID == productId);
            return View(product);
        }
    }
}
