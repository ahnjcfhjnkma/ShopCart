using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {

        }

        [DisplayName("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(10)]
        [DisplayName("產品名稱")]
        public string Name { get; set; }
        [DisplayName("產品敘述")]
        public string Discription { get; set; }
        [Required]
        [MaxLength(5)]
        [DisplayName("價格")]
        public int Price { get; set; }
        [DisplayName("圖片")]
        public string PicturePath { get; set; }
    }
}
