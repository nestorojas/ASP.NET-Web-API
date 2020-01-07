﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyEntity.DataModel;
using MyEntity.DataModel.Tables;

namespace MyRepository.DataModel
{
    public class Repository : IRepository
    {
        DataModelContext _context;

        public Repository(DataModelContext context)
        {
            _context = context;
        }
        public IQueryable<Blog> GetBlogs()
        {
            var blog = from b in _context.Blog select b;
            return blog.OrderByDescending(x=>x.PublishDate);
        }
        public Blog ReadBlog(int Id)
        {
            Blog blog = new Blog();
            blog = (from b in _context.Blog where b.Id == Id select b).FirstOrDefault();
            return blog;
        }
        public bool CreateBlog(Blog blog)
        {
            bool result = false;
            try
            {
                _context.Blog.Add(blog);
                _context.SaveChanges();
                result = true;
            }
            catch
            {

            }
            return result;
        }
        public bool UpdateBlog(Blog blog)
        {
            bool result = false;
            var blog_ = (from f in _context.Blog where f.Id == blog.Id select f).FirstOrDefault();
            if(blog_ != null)
            {
                try
                {
                    blog_.Title = blog.Title;
                    blog_.Body = blog.Body;
                    _context.SaveChanges();
                    result = true;
                }
                catch
                {

                }

            }
            return result;
        }
       public bool DeleteBlog(int Id)
        {
            bool result = false;
            var blog_ = (from f in _context.Blog where f.Id == Id select f).FirstOrDefault();
            if (blog_ != null)
            {
                try
                {
                    _context.Remove(blog_);
                    _context.SaveChanges();
                    result = true;
                }
                catch
                {

                }
            }
            return result;
        }
    }
}
