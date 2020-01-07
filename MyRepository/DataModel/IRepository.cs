using MyEntity.DataModel.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyRepository.DataModel
{
    public interface IRepository
    {
        IQueryable<Blog> GetBlogs();
        Blog ReadBlog(int Id);
        bool CreateBlog(Blog blog);
        bool UpdateBlog(Blog blog);
        bool DeleteBlog(int Id);
    }
}
