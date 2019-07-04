using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ShoppingCart.Models
{
    public class IndexModel
    {
        int pd_id { get; set; }
        string pd_name { get; set; }
        int pd_price { get; set; }
        string pd_description { get; set; }
        string pd_picture { get; set; }
    }

}