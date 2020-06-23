using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;

namespace Model.Dao
{
    public class CategoryDao

    {
        public ShopOnlineDbContext Db { get; private set; }

        public CategoryDao()
        {
            this.Db = new ShopOnlineDbContext();
        }
        public List<Category> ListCate()
        {
            return Db.Categories.ToList();
        }
        public Category getById(int id)
        {
            return Db.Categories.Single(i => i.ID == id);
        }
    }
}