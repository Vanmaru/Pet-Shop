using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public Product Product{ get; set; }
        public string Category { get; set; }
        public string Kind { get; set; }
        public int Quantity { get; set; }
    }
}