using idm.car.project.domain.Entities;

namespace idm.car.project.application.Contracts.Persistence;

public interface ICartRepository 
{
    Task<IReadOnlyList<Product>> GetAllAsync();

    Task<Product> GetByIdAsync(int id);

    Task AddAsync(Product entity);

    Task UpdateAsync(Product entity);

    Task DeleteAsync(Product entity);
}
