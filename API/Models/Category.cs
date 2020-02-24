using System.Collections.Generic;
using System.ComponentModel;

namespace API.Models {
    public class Category {
        public int ID { get; set; }
        public string Title { get; set; }
        public List<Product> Products { get; set; }
    }
}