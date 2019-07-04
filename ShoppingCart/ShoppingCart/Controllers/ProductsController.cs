using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.domain;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class ProductsController : Controller
    {
        private ShopCartEntities db = new ShopCartEntities();

        // GET: Products
        public ActionResult Index()
        {
            var data = db.Product.ToList();//來自資料庫的資料

            var result = new List<ProductViewModel>();//宣告result是一個內裝 ProductViewModel 的 list物件

            foreach (var item in data)
            {
                result.Add(new ProductViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Discription = item.Discription,
                    Price = item.Price,
                    PicturePath = item.PicturePath
                });
            }
            return View(result);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ProductViewModel result = MapperProductViewModel(product);
            return View(result);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View(new ProductViewModel());
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Discription,Price,PicturePath")] ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                Product pro = new Product();
                pro.Id = product.Id;
                pro.Name = product.Name;
                pro.Discription = product.Discription;
                pro.Price = product.Price;
                pro.PicturePath = product.PicturePath;
                db.Product.Add(pro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Product.Find(id);
            ProductViewModel result = MapperProductViewModel(product);

            if (result == null)
            {
                return HttpNotFound();
            }
            return View(result);
        }

        private static ProductViewModel MapperProductViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Discription = product.Discription,
                Name = product.Name,
                PicturePath = product.PicturePath,
                Price = product.Price
            };
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Discription,Price,PicturePath")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ProductViewModel result = MapperProductViewModel(product);
            return View(result);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public void Order(int id, String customer,string Address)
        {
            Product product = db.Product.Find(id);
            db.OrderList.Add(new OrderList {Product_Id = id,Count = 1 , Price = product.Price, Customer = customer, Customer_Address = Address, Time = DateTime.Now });
            db.SaveChanges();
        }

        public ActionResult OrderList()
        {
            var orader = db.OrderList.ToList();//來自資料庫的資料
            var pdList = db.Product.ToList();
            var product = db.Product.ToList();

            var result = new List<OrderListViewModel>();//宣告result是一個內裝 ProductViewModel 的 list物件

            foreach (var or in orader)
            {

                result.Add(new OrderListViewModel()
                {
                    Id = or.Id,
                    Product_Id = or.Product_Id,
                    Product_Name = pdList.Where(x => x.Id == or.Product_Id).Select(x => x.Name).FirstOrDefault(),
                    Count = or.Count,
                    Price = or.Price,
                    OrderTime = or.Time,
                    Customer = or.Customer,
                    Customer_Address = or.Customer_Address
                });
            }

            return View(result);
        }
        
    }
}
