using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace razorweb.models
{
    // [Table("posts")] //thiết lập tên bảng với Model này trên SQL Server. Nếu không thiết lập thì tên bảng trên SQL Server sẽ lấy theo tên thuộc tính DbContext
    public class Article
    {
        [Key]
        public int Id {set; get;}

        [StringLength(255)]
        [Required]
        [Column(TypeName = "nvarchar")] //thiết lập kiểu dữ liệu lưu trên SQL Server
        public string Title {set; get;}

        [DataType(DataType.Date)] //1 cách khác thiết lập kiểu dữ liệu lưu trên SQL Server
        [Required]
        public DateTime Created {set; get;}

        [Column(TypeName = "ntext")]
        public string Content {set; get;}
    }
}