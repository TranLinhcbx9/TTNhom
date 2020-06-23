using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;


namespace ShopOnline.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/LinhKienMayTinh
        public ActionResult Delete(int id)
        {
            ViewBag.Title = "Xóa sản phẩm";
            ProductDao dao = new ProductDao();
            dao.Delete(id);
            return Redirect("~/Admin/Product/Index");
        }

        public ActionResult Add()
        {
            ViewBag.Title = "Thêm sản phám ";
            var product = new ProductDao();
            var productcatogory = new ProductCategoryDao();
         
            ViewBag.productcatogory = productcatogory.ListCate();
            
            return View(product.ListCate());
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Title = "Sửa sản phẩm";
            var Loaisp = new ProductCategoryDao();
            var category = new CategoryDao();
         
            ViewBag.category = category.ListCate();
           
            var proDao = new ProductDao();
            ViewBag.pro = proDao.getById(id);
            return View(Loaisp.ListCate());
        }

        [HttpPost]
        public ActionResult Edit(int id, string MLLK, string MLM, string MNCC, string TLK, string TSKT, string TGBH, string MT, HttpPostedFileBase photo, string photos)
        {
            ViewBag.Title = "Cập nhật giá trị mới cho sản phẩm";
            ProductDao dao = new ProductDao();
            var product = dao.getById(id);

            if (ModelState.IsValid)
            {
                if (photo != null && photo.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/Photo/"),
                                            System.IO.Path.GetFileName(photo.FileName));
                    photo.SaveAs(path);

                    product.Image = photo.FileName;

                }
                dao.Add(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        [HttpPost]
        public ActionResult Add(string MLLK, string MLM,  string TLK, string TSKT, string MT, HttpPostedFileBase photo)
        {
            ViewBag.Title = "Thêm sản phẩm mới";
            var product = new Product();
            product.ID = int.Parse(MLLK);
            product.CategoryID = int.Parse(MLM);
            
            product.Name = TLK;
            product.Detail = TSKT;
           
            product.Description = MT;
            if (ModelState.IsValid)
            {
                if (photo != null && photo.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Areas/Admin/Content/Photo/"),
                                            System.IO.Path.GetFileName(photo.FileName));
                    photo.SaveAs(path);
                    product.Image = photo.FileName;
                    var dao = new ProductDao();
                    dao.Add(product);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Quản lý Mỹ phẩm";
            var llk = new ProductCategoryDao();
            var lm = new CategoryDao();
           
            ViewBag.lm = lm.ListCate();
            
            ViewBag.llk = llk.ListCate();
            ProductDao dao = new ProductDao();
            return View(dao.ListProductPage(1, 5));
        }
    }

    internal class ProductCategoryDao
    {
        public ProductCategoryDao()
        {
        }

        internal dynamic ListCate()
        {
            throw new NotImplementedException();
        }
    }
}