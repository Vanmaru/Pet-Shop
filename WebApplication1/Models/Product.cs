using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter price.")]
        public int Price { get; set; }
        //[Required(ErrorMessage = "Please enter a url.")]
        public string ImgUrl { get; set; }
        public string Material { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int KindId { get; set; }
        public Kind Kind { get; set; }
    }
}
