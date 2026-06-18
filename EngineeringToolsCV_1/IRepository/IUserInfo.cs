using EngineeringToolsCV_1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringToolsCV_1.IRepository
{
	public interface IUserInfo
	{
		Task<MUser> GetUserInfoAsync(string id, string password);
		Task<bool> LoginUserAsync(string strId, string Password);
		Task<bool> UpdateUserInfosAsync(string userId, string password);
		Task<int> AddUserInfoAsync(MUser info);
		Task<MUser> SearchUserInfoAsync(string search);
	}
}
