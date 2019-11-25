using MyBlog.Models;
using MyBlog.Repository.Base;
using MyBlog.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Repository
{
    public class SortRepository : DataFactory<gxyContext>, ISortRepository
    {
        public bool AddSort(Sort sort)
        {
            sort.SortId = Guid.NewGuid().ToString().ToUpper();
            Db.Sort.Add(sort);
            int count = Db.SaveChanges();
            if (count == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int DeleteSort(string sortId)
        {
            Sort sort = Db.Sort.Single(s => s.SortId == sortId);
            Db.Sort.Remove(sort);
            return Db.SaveChanges();
        }

        public List<Sort> GetAllSorts()
        {
            List<Sort> sorts = Db.Sort.ToList();
            return sorts;
        }

        public Sort GetSortBySortId(string sortId)
        {
            Sort sort = Db.Sort.FirstOrDefault(s => s.SortId == sortId);
            return sort;
        }

        public int UpdateSort(Sort sort)
        {
            Db.Sort.Update(sort);
            return Db.SaveChanges();
        }
    }
}
