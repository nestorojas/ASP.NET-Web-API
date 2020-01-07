using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyEntity.DataModel.Tables
{
    public class Blog
    {
        [Key]
        [Column("Id", TypeName = "int")]
        public int Id { get; set; }
        [Column("Title", TypeName = "varchar(50)")]
        public string Title { get; set; }
        [Column("Body", TypeName = "text")]
        public string Body { get; set; }
        [Column("PublishDate", TypeName = "datetime")]
        public DateTime PublishDate { get; set; }
        [Column("IsDraft", TypeName = "bit")]
        public bool IsDraft { get; set; }

    }
}
