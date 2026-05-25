using EngineeringToolsCV_1.DatabaseManager;
using EngineeringToolsCV_1.IRepository;
using EngineeringToolsCV_1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringToolsCV_1.Service
{
	public class AuthenticationService : IAuthenticationService
	{
		private IUserInfo _userInfo;
		private MUser _mUser;
		public AuthenticationService(IUserInfo userInfo, MUser mUser) {
			this._userInfo = userInfo;
			this._mUser = mUser;
		}

		public async Task<int> LoginAsync()
		{
			int count = await _userInfo.GetUserInfoAsync(this._mUser.User_Id,this._mUser.Passwort);
			return count;
		}
	}
}
