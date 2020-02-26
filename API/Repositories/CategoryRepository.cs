using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using API.Data;
using API.Models;
using API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories {
    public class CategoryRepository : ICategoryRepository {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        public Category Buscar(int id) {
            return _dbContext.Categories.FirstOrDefault(x => x.Id == id);
        }
        
        public Category GetBuscar(int id) {
            return _dbContext.Categories.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        public void Adicionar(Category obj) {
            _dbContext.Categories.Add(obj);
            _dbContext.SaveChanges();
        }

        public void Deletar(Category obj) {
            _dbContext.Categories.Remove(obj);
            _dbContext.SaveChanges();
        }

        public void Editar(Category obj){
            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public List<Category> Listar() {
            return _dbContext.Categories.AsNoTracking().ToList();
        }

        public List<Category> GetListar() {
            return _dbContext.Categories.AsNoTracking().ToList();
        }
    }
}










