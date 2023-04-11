using Entity.DataModel;


namespace MyRepository.DataModel
{
    public interface IRepository
    {
        List<Blog> GetBlogs();
        Blog ReadBlog(int Id);
        bool CreateBlog(Blog blog);
        bool UpdateBlog(Blog blog);
        bool DeleteBlog(int Id);
    }
}
