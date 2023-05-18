using Microsoft.EntityFrameworkCore;

namespace razorweb.models
{
    public class MyBlogContext : DbContext
    {
        public MyBlogContext(DbContextOptions<MyBlogContext> options) : base(options)
        {

        } //phương thức khởi tạo với tham số là đối tượng DbContextOptions<MyBlogContext> để khi đăng kí dịch vụ (DI) vào hệ thống có thể thiết lập các options cho việc kết nối đến cơ sở dữ liệu. Từ đó, hệ thống có thể tự động khởi tạo đối tượng kế thừa lớp DbContext này khi chạy chương trình và trong đối tượng được khởi tạp có những options cho việc kết nối đến cơ sở dữ liệu

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Article> articles {set; get;}

        

        
    }
}