﻿namespace API.ViewModels.ProductViewModels {
    public class ListProductViewModels {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
    }
}