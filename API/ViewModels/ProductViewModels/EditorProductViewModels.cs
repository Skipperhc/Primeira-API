namespace API.ViewModels.ProductViewModels {
    public class EditorProductViewModels {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
    }
}