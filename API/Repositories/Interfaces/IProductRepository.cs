using System.Collections.Generic;
using API.Models;

namespace API.Repositories.Interfaces {
    public interface IProductRepository : IRepository<Product> {
        Product GetBuscar(int id);
        List<Product> GetListar(int id);
    }
}