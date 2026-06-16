using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using EngineeringToolsCV_1.DatabaseManager;
using EngineeringToolsCV_1.Repositories;
using EngineeringToolsCV_1.Models;
using Microsoft.EntityFrameworkCore;

namespace EngineeringsToolsTest
{
	[TestClass]
	public class UserInfoTest
	{
		[TestMethod]
		public async Task Login_WithCorrectCredentials_ShouldReturnUser()
		{
			var options = new DbContextOptionsBuilder<StudentContext>()
				 .UseInMemoryDatabase("Lebenslauf")
				 .Options;

			using var context = new StudentContext(options);

			//context.Users.Add(new MUser
			//{
			//	User_Id = "gonguego",
			//	Passwort = "dyna1605"
			//});

			//await context.SaveChangesAsync();

			var repository = new UserInfo(context);

			var result = await repository.LoginUserAsync("gonguego", "dyna1605");

			Assert.IsNotNull(result);
		}

		[TestMethod]
		public async Task Login_WithCorrectCredentials_ShouldNOTReturnUser()
		{
			var options = new DbContextOptionsBuilder<StudentContext>()
				 .UseInMemoryDatabase("Lebenslauf")
				 .Options;

			using var context = new StudentContext(options);

			//context.Users.Add(new MUser
			//{
			//	User_Id = "gonguego",
			//	Passwort = "dyna1605"
			//});

			//await context.SaveChangesAsync();

			var repository = new UserInfo(context);

			var result = await repository.LoginUserAsync(" ", " ");

			Assert.IsNull(result);
		}
	}
}
