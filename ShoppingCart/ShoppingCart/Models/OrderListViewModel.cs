using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models
{
    public class OrderListViewModel
    {
        public OrderListViewModel()
        {

        }
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("產品ID")]
        public int Product_Id { get; set; }
        [DisplayName("產品名稱")]
        public string Product_Name { get; set; }
        [DisplayName("訂購數量")]
        public int Count { get; set; }
        [DisplayName("價格")]
        public int Price { get; set; }
        [DisplayName("下訂時間")]
        public DateTime OrderTime { get; set; }
        [DisplayName("訂購者")]
        public string Customer { get; set; }
        [DisplayName("郵寄地址")]
        public string Customer_Address { get; set; }
    }
}