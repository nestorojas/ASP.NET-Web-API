using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DataModel
{
	public class Blog
	{
		[Key]
		public int Id { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
		public DateTime PublishDate { get; set; }
		public bool IsDraft { get; set; }

	}
}
