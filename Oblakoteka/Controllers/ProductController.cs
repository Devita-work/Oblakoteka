using Microsoft.AspNetCore.Mvc;
using Oblakoteka.Models;

namespace Oblakoteka;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index(string filter)
    {
        var products = await _productService.GetProductsAsync(filter);
        return View(products);
    }

    // GET: Product/Add
    public ActionResult Add()
    {
        var model = new ProductViewModel();

        return PartialView("_ProductAddForm", model);
    }

    // GET: Product/Create
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(ProductViewModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var product = new Product
                {
                    ID = Guid.NewGuid(),
                    Name = model.Name,
                    Description = model.Description,
                };

                await _productService.AddProductAsync(product);

                return RedirectToAction("Index", "Product");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Произошла ошибка при добавлении продукта. Пожалуйста, попробуйте еще раз или обратитесь к администратору.");
            }
        }
        return PartialView("_ProductAddForm", model);
    }

    // Метод для отображения формы редактирования модального окна
    [HttpGet]
    public async Task<IActionResult> EditModal(Guid id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        var model = new ProductViewModel
        {
            ID = product.ID,
            Name = product.Name,
            Description = product.Description
        };

        return PartialView("_ProductEditForm", model);
    }

    // Метод для обработки POST-запроса из формы редактирования модального окна
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditModal(ProductViewModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var product = new Product
                {
                    ID = model.ID,
                    Name = model.Name,
                    Description = model.Description,
                };

                await _productService.UpdateProductAsync(product);

                return RedirectToAction("Index", "Product");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Произошла ошибка при редактировании продукта. Пожалуйста, попробуйте еще раз или обратитесь к администратору.");
            }
        }
        return PartialView("_ProductEditForm", model);
    }

    [HttpDelete]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete([FromQuery] Guid id)
    {
        try
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            return RedirectToAction("Index");
        }
    }
}
