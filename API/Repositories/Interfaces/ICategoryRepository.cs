using System.Collections.Generic;
using API.Models;

namespace API.Repositories.Interfaces {
    public interface ICategoryRepository : IRepository<Category> {
        Category GetBuscar(int id);
        List<Category> GetListar();
        void GetEditar(Category category);
    }
}