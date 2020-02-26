using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Models;
using API.Repositories;
using API.ViewModels;
using API.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers {
    public class ProductController : Controller {
        private readonly ApplicationDbContext _dbContext;

        public ProductController(ApplicationDbContext dbContext) { _dbContext = dbContext; }

        [Route("v1/products")] [HttpGet] public List<ListProductViewModels> Listar() {
            return _dbContext.Products.Include(x => x.Category).Select
                (x => new ListProductViewModels() {
                Id = x.Id,
                Title = x.Title,
                Price = x.Price,
                CategoryId = x.Category.Id,
                Category = x.Category.Title
            }).AsNoTracking().ToList();
        }

        [Route("v1/product/{id}")] [HttpGet] public Product Product(int id) {
            return _dbContext.Products.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        [Route("v1/product")] [HttpPost] public ResultViewModel ResultViewModel([FromBody] EditorProductViewModels models) {
            Product product = new Product() {
                Title = models.Title,
                Quantity = models.Quantity,
                Description = models.Description,
                Price = models.Price,
                Image = models.Image,
                CategoryId = models.Id,
            };

            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            return new ResultViewModel {
                Success = 
            };
        }
    }
}

