using System;
using System.Collections.Generic;
using System.Linq;
using Model.EF;
//using PagedList;
namespace Model.Dao
{
    public class ProductDao
    {
        public ProductDao()
        {
            this.Db = new ShopOnlineDbContext();
        }

        public ShopOnlineDbContext Db { get; private set; }
        public List<Product> ListProduct()
        {
            return Db.Products.ToList();
        }
        public void Add(Product pro)
        {
            Db.Products.Add(pro);
            Db.SaveChanges();
        }
        public void Edit(Product pro)
        {
            Product product = getById(pro.ID);
            if (product != null)
            {
                product.Name = pro.Name;
                product.CategoryID = pro.CategoryID;
                product.Image = pro.Image;
                product.Price = pro.Price;
                
                product.Code = pro.Code;
                product.Detail = pro.Detail;
                product.Description = pro.Description;
                
                Db.SaveChanges();
            }


        }

    public object ListCate()
    {
        throw new NotImplementedException();
    }

    private Product getById(long iD)
    {
        throw new NotImplementedException();
    }

    public int Delete(int id)
        {
            Product pro = Db.Products.Find(id);
            if (pro != null)
            {
                Db.Products.Remove(pro);
                return Db.SaveChanges();
            }
            else
                return -1;
        }



        public Product getById(int id)
        {
            return Db.Products.Single(i => i.ID == id);
        }

        public List<Product> ListProduct(int Pagenum, int PageSize)
        {
            return Db.Products.Skip((Pagenum - 1) * PageSize).Take(PageSize).ToList();
        }

        public object ListProductPage(int v1, int v2)
        {
            throw new NotImplementedException();
        }




        //public IEnumerable<Product> ListProductPage(int Pagenum, int PageSize)
        //{

        //    return Db.Products.OrderByDescending(a => a.ID).ToPagedList(Pagenum, PageSize);
        //}

    }
}