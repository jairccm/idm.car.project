using idm.car.project.application.Contracts.Persistence;
using idm.car.project.domain.Entities;

namespace idm.car.project.infraestructure.Repositories;

public class CartRepository : ICartRepository
{
    private readonly List<Product> _products;

    public CartRepository()
    {
        _products = new List < Product >();
    }

    public async Task AddAsync(Product entity)
    {
        _products.Add(entity);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Product entity)
    {
        var productToRemove = _products.FirstOrDefault(p => p.ProductId == entity.ProductId);

        _products.Remove(productToRemove);

        await Task.CompletedTask;
    }

    public async Task<IReadOnlyList<Product>> GetAllAsync()
    {
        return await Task.FromResult(_products);
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        var product = _products.FirstOrDefault(p => p.ProductId == id);
        return await Task.FromResult(product);
    }

    public async Task UpdateAsync(Product entity)
    {
        var existingProduct = _products.FirstOrDefault(p => p.ProductId == entity.ProductId);

        _products.Remove(existingProduct);
        _products.Add(entity);

        await Task.CompletedTask;
    }
}
