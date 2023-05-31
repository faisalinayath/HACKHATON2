using ContactAPI.data;
using ContactAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ContactAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CardsController : Controller
	{
		private readonly ContactsAPIDbContext dbContext;

		public CardsController(ContactsAPIDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllCards()
		{
			var menuCards = await dbContext.MenuCard.ToListAsync();
			return Ok(menuCards);
		}


		[HttpGet]
		[Route("{id:int}")]
		[ActionName("GetCard")]
		public async Task<IActionResult> GetSingleCard([FromRoute] int id)
		{
			var menuCard = await dbContext.MenuCard.FirstOrDefaultAsync(x => x.Id == id);
			if (menuCard != null)
			{
				return Ok(menuCard);
			}
			return NotFound();
		}

		[HttpPost]
		public async Task<IActionResult> AddCard([FromBody] Menu menu)
		{
			
				await dbContext.MenuCard.AddAsync(menu);
				await dbContext.SaveChangesAsync();
				return Ok(menu);
			
		}

		[HttpPut]
		[Route("{id:int}")]
		
		public async Task<IActionResult> UpdateCard([FromRoute] int id, [FromBody] Menu menu)
		{
			var ExistingMenuCard = await dbContext.MenuCard.FirstOrDefaultAsync(x => x.Id == id);
			if (ExistingMenuCard != null)
			{
				ExistingMenuCard.DishName= menu.DishName;
				ExistingMenuCard.Description = menu.Description;
				ExistingMenuCard.DishPrice = menu.DishPrice;

				await dbContext.SaveChangesAsync();
				return Ok(ExistingMenuCard);
			}
			return NotFound("Menu Card Not Found");
		}

		[HttpDelete]
		[Route("{id:int}")]

		public async Task<IActionResult> DeleteCard([FromRoute] int id)
		{
			var ExistingMenuCard = await dbContext.MenuCard.FirstOrDefaultAsync(x => x.Id == id);
			if (ExistingMenuCard != null)
			{
				dbContext.Remove(ExistingMenuCard);
				await dbContext.SaveChangesAsync();
				return Ok("Deleted Successfully");
			}
			return NotFound("Menu Card Not Found");
		}

	}
}
