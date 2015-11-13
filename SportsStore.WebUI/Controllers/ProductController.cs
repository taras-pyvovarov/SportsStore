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

        public ViewResult List(string category, int page = 1)
        {
            var model = new ProductsListViewModel();
            model.Products = _repository.Products
                .Where(x => category == null || x.Category == category)
                .OrderBy(x => x.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize);

            model.PagingInfo = new PagingInfo();
            model.PagingInfo.CurrentPage = page;
            model.PagingInfo.ItemsPerPage = PageSize;
            if (category == null)
                model.PagingInfo.TotalItems = _repository.Products.Count();
            else
                model.PagingInfo.TotalItems = _repository.Products.Count(x => x.Category == category);

            model.CurrentCategory = category;

            return View(model);
        }
    }
}
