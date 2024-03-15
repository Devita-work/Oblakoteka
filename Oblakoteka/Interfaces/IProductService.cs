using Oblakoteka.Models;

namespace Oblakoteka;

public interface IProductService
{
    /// <summary>
    /// Получает список продуктов с возможностью фильтрации по наименованию.
    /// </summary>
    /// <param name="filter">Строка для фильтрации по наименованию изделия.</param>
    /// <returns>Список изделий.</returns>
    Task <List<ProductViewModel>> GetProductsAsync(string filter);

    /// <summary>
    /// Добавляет новый продукт.
    /// </summary>
    /// <param name="product">Модель представления нового продукта.</param>
    /// <returns>Асинхронная задача.</returns>
    Task AddProductAsync(Product product);

    /// <summary>
    /// Обновляет существующий продукт.
    /// </summary>
    /// <param name="product">Модель представления для обновления продукта.</param>
    /// <returns>Асинхронная задача.</returns>
    Task UpdateProductAsync(Product product);

    /// <summary>
    /// Находит продукт по id.
    /// </summary>
    /// <param name="id">Id для обновления продукта.</param>
    /// <returns>Асинхронная задача.</returns>
    Task<Product> GetProductByIdAsync(Guid id);

    /// <summary>
    /// Удаляет продукт по id.
    /// </summary>
    /// <param name="id">Id для удаления продукта.</param>
    /// <returns>Асинхронная задача.</returns>
    Task DeleteProductAsync(Guid id);
}