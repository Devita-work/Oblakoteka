using Oblakoteka.Models;

namespace Oblakoteka;

public class ProductService : IProductService
{
    private readonly TestDbContext _context;

    public ProductService(TestDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductViewModel>> GetProductsAsync(string filter)
    {
        List<Product> query = _context.Product.ToList();

        if (!string.IsNullOrEmpty(filter))
        {
            query = query.Where(p => p.Name.Contains(filter)).ToList();
        }

        List<ProductViewModel> result = new List<ProductViewModel>();

        foreach (var product in query)
        {
            result.Add(
            new ProductViewModel(
                id: product.ID,
                name: product.Name,
                description: product.Description));
        }

        return result;
    }

    public async Task AddProductAsync(Product product)
    {
        await _context.Product.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task<Product> GetProductByIdAsync(Guid id)
    {
        return await _context.Product.FindAsync(id);
    }

    public async Task UpdateProductAsync(Product product)
    {
        _context.Product.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(Guid id)
    {
        var product = await _context.Product.FindAsync(id);
        if (product != null)
        {
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}