using System.Collections.Generic;
using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    public class CategoryController : Controller {

        private readonly CategoryRepository _categoryRepository;
        private readonly ProductRepository _productRepository;

        public CategoryController(CategoryRepository dbContext, ProductRepository productRepository) {
            _categoryRepository = dbContext;
            _productRepository = productRepository;
        }

        //mandando uma lista de categorias
        [Route("v1/categories")] [HttpGet] public List<Category> GetListaCategory() {
            return _categoryRepository.Listar();
        }
        
        //mandando uma unica categoria
        [Route("v1/categories/{id}")] [HttpGet] public Category GetCategory(int id) {
            return _categoryRepository.GetBuscar(id);
        }

        //mandando uma lista de produtos
        [Route("v1/categories/{id}/products")] [HttpGet]
        public List<Product> GetListaProducts(int id) {
            return _productRepository.GetListar(id);
        }

        [Route("v1/categories")] [HttpPost] public Category PostCategory([FromBody] Category category) {
            _categoryRepository.Adicionar(category);

            return category;
        }

        [Route("v1/categories")] [HttpPut] public Category PutCategory([FromBody] Category category) {
            _categoryRepository.Editar(category);
            
            return category;
        }

        [Route("v1/categories")] [HttpDelete] public Category DeleteCategory([FromBody] Category category) {
            _categoryRepository.Deletar(category);

            return category;
        }
    }
}






















