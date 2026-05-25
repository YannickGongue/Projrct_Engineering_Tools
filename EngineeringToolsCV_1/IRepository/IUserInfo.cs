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
		Task<DataTable> GetUserInfoAsync(string id, string password);
		Task<int> UpdateUserInfosAsync(MUser info);
		Task<int> AddUserInfoAsync(MUser info);

	}
}
