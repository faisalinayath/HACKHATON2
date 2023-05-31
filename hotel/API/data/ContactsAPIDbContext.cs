using ContactAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactAPI.data
{
	public class ContactsAPIDbContext:DbContext
	{
		public ContactsAPIDbContext(DbContextOptions options):base(options)
		{
		}

		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Menu> MenuCard { get; set; }
	}
}
