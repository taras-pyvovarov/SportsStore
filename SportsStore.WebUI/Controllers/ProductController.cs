using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        public int PageSize = 4;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        public ViewResult List(int page = 1)
        {
            var model = new ProductsListViewModel();
            model.Products = _repository.Products
                .OrderBy(x => x.ProductID)
                .Skip((page - 1)*PageSize)
                .Take(PageSize);
            model.PagingInfo = new PagingInfo();
            model.PagingInfo.CurrentPage = page;
            model.PagingInfo.ItemsPerPage = PageSize;
            model.PagingInfo.TotalItems = _repository.Products.Count();
            return View(model);
        }
    }
}
