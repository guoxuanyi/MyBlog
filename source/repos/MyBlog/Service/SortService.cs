using MyBlog.Models;
using MyBlog.Repository;
using MyBlog.Repository.IRepository;
using MyBlog.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Service
{
    public class SortService : DataFactory<ISortRepository>, ISortService
    {

        public bool AddSort(Sort sort)
        {
            return Repository.AddSort(sort);
        }

        public int DeleteSort(string sortId)
        {
            return Repository.DeleteSort(sortId);
        }

        public List<Sort> GetAllSorts()
        {
            return Repository.GetAllSorts();
        }

        public Sort GetSortBySortId(string sortId)
        {
            return Repository.GetSortBySortId(sortId);
        }

        public int UpdateSort(Sort sort)
        {
            return Repository.UpdateSort(sort);
        }
    }
}
