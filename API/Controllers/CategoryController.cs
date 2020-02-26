using System.Collections.Generic;
using System.Net.Mime;
using API.Data;
using API.Models;
using API.Repositories;
using API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers {
    public class CategoryController : Controller {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public CategoryController(ICategoryRepository dbContext, IProductRepository productRepository) {
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
        [Route("v1/categories/{id}/products")] [HttpGet] public List<Product> GetListaProducts(int id) {
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

        [Route("v1/categories/{id}")] [HttpDelete] public Category DeleteCategory(int id) {
            var category = _categoryRepository.GetBuscar(id);
            _categoryRepository.Deletar(category);

            return category;
        }

        [Route("v1/products")] [HttpPost] public Product PostProduct([FromBody] Product product) {
            _productRepository.Adicionar(product);

            return product;
        }
    }
}






















