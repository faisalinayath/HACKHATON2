using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactAPI.Models
{
	public class Menu
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }	
		
		public string DishName { get; set; }
		public string Description { get; set; }
		public int DishPrice { get; set; }

	}
}
