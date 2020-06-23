using Model.EF;
using System.Collections.Generic;
using System.Linq;
using Model.EF;

namespace Model.Dao
{
    public class ProductCategoryDao
    {
        public ShopOnlineDbContext Db { get; private set; }

        public ProductCategoryDao()
        {
            this.Db = new ShopOnlineDbContext();
        }
        public List<ProductCategory> ListCate()
        {
            return Db.ProductCategories.ToList();
        }
        public ProductCategory getById(int id)
        {
            return Db.ProductCategories.Single(i => i.ID == id);
        }
    }
}