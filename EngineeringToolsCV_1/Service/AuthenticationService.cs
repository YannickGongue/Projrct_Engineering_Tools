using EngineeringToolsCV_1.DatabaseManager;
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
		private readonly DbManager _dbManager;
		private MUser _mUser;
		public AuthenticationService(DbManager dbManager, MUser mUser) {
			this._dbManager = dbManager;
			this._mUser = mUser;
		}

		public async Task<DataTable> LoginAsync()
		{
			var dt = await _dbManager.GetUserInfoAsync(this._mUser.Id,this._mUser.Passwort);
			return dt;
		}
	}
}
