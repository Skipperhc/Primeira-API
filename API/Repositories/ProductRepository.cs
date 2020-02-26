using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using API.Data;
using API.Models;
using API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories {
    public class ProductRepository : IProductRepository {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        public Product Buscar(int id){
            return _dbContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public Product GetBuscar(int id) {
            return _dbContext.Products.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        public void Adicionar(Product obj) {
            _dbContext.Products.Add(obj);
            _dbContext.SaveChanges();
        }

        public void Deletar(Product obj) {
            _dbContext.Products.Remove(obj);
            _dbContext.SaveChanges();
        }

        public void Editar(Product obj) {
            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public List<Product> Listar() {
            return _dbContext.Products.AsNoTracking().ToList();
        }

        public List<Product> GetListar(int id) {
            return _dbContext.Products.AsNoTracking().Where(x => x.CategoryId == id).ToList();
        }
    }
}


