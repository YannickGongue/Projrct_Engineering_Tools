using Microsoft.VisualStudio.TestTools.UnitTesting;
using EngineeringToolsCV_1.IRepository;
using EngineeringToolsCV_1.Models;
using System.Data;
using EngineeringToolsCV_1.DatabaseManager;
using System.Threading.Tasks;

namespace EngineeringsToolsCv.UnitTests
{
    [TestClass]
    public class UserInfosTests
    {
        private readonly IUserInfo _userRepository;
        private readonly IUserWorkInfo _userWorkInfo;
        private DataTable dtTable;
        [TestMethod]
        public async void GetUserInfoAsyncReturnsDataTableWhenUserExists()
        {
            
            this.dtTable = new DataTable();

            // ARrahge
            var dbManager = new DbManager( this._userRepository, this._userWorkInfo);
            // Act
            dtTable = await dbManager.GetUserInfoAsync("gonguego", "dyna1605");
            // Assert
            Assert.IsNotNull(dtTable);
        }
    }
}
