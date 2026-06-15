using EngineeringToolsCV_1.DatabaseManager;
using EngineeringToolsCV_1.IRepository;
using EngineeringToolsCV_1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringToolsCV_1.Repositories
{
	public class UserInfo : IUserInfo
	{
		private StudentContext _stDbContext;

		public UserInfo( StudentContext stDbContext)
		{
			this._stDbContext = stDbContext;

		}

		public async Task<int> AddUserInfoAsync(MUser info)
		{
			//string strQueryRegister = string.Format("INSERT INTO {0} ({1},{2},{3}) VALUES(@1,@2,@3)",
			//													 this._dbName.StrTBL_User,
			//													 this._dbName.strId,
			//													 this._dbName.strEmail,
			//													 this._dbName.StrPasswort);
			//using var conn = _connectionFactory.Create();
			//using var cmd = new SqlCommand();
			//cmd.Connection = conn;
			//cmd.Parameters.AddWithValue("@1", info.User_Id);
			//cmd.Parameters.AddWithValue("@2", info.Email);
			//cmd.Parameters.AddWithValue("@3", info.Passwort);
			//cmd.CommandType = CommandType.Text;
			//cmd.CommandText = strQueryRegister;
			//await conn.OpenAsync();
			//return await cmd.ExecuteNonQueryAsync();

			this._stDbContext.Users.Add(info);
			return await this._stDbContext.SaveChangesAsync();
		}

		public async Task<bool> LoginUserAsync(string strId, string strPassword)
		{
			return await this._stDbContext.Users.AnyAsync(u =>
															 u.User_Id == strId &&
															 u.Passwort == strPassword);
		}

		public async Task<MUser> GetUserInfoAsync(string id, string password)
		{
			//string strQueryLogin = String.Format("SELECT * FROM {0} WHERE {1}= @1 AND {2}= @2",
			//												this._dbName.StrTBL_User,
			//												this._dbName.strId,
			//												this._dbName.StrPasswort);

			//using var conn = _connectionFactory.Create();
			//using var cmd = new SqlCommand();
			//cmd.Connection = conn;

			//cmd.Parameters.AddWithValue("@1", id);
			//cmd.Parameters.AddWithValue("@2", password);

			//cmd.CommandType = CommandType.Text;
			//cmd.CommandText = strQueryLogin;

			//await conn.OpenAsync();

			//var dt = new DataTable();
			//using var adapter = new SqlDataAdapter(cmd);
			//adapter.Fill(dt);

			//return dt;

			return await this._stDbContext.Users.SingleOrDefaultAsync(u =>
			                                     u.User_Id == id &&
			                                     u.Passwort == password);
		}

		public async Task<bool> UpdateUserInfosAsync(string userId, string email, string password)
		{
			//string strQueryRegister = string.Format("UPDATE {0} SET {1}= @1, {2}=@2 WHERE {3} = @3 ",
			//													  this._dbName.StrTBL_User,
			//													  this._dbName.strEmail,
			//													  this._dbName.StrPasswort,
			//													  this._dbName.strId);

			//using var conn = _connectionFactory.Create();
			//using var cmd = new SqlCommand();
			//cmd.Connection = conn;

			//cmd.Parameters.AddWithValue("@1", info.Email);
			//cmd.Parameters.AddWithValue("@2", info.Passwort);
			//cmd.Parameters.AddWithValue("@3", info.User_Id);

			//cmd.CommandType = CommandType.Text;
			//cmd.CommandText = strQueryRegister;
			//await conn.OpenAsync();
			//return await cmd.ExecuteNonQueryAsync();

			var user = await _stDbContext.Users
										  .FirstOrDefaultAsync(u => u.User_Id == userId);

			if (user == null)
			{
				return false;
			}

			user.Email = email;
			user.Passwort = password;

			await _stDbContext.SaveChangesAsync();

			return true;
		}

		public async Task<MUser> SearchUserInfoAsync(string search)
		{
			//string strQueryLogin = String.Format("SELECT * FROM {0} WHERE {1}= @1",
			//												this._dbName.StrTBL_User,
			//												this._dbName.strId);

			//using var conn = _connectionFactory.Create();
			//using var cmd = new SqlCommand();
			//cmd.Connection = conn;

			//cmd.Parameters.AddWithValue("@1", search);
			//cmd.CommandType = CommandType.Text;
			//cmd.CommandText = strQueryLogin;

			//await conn.OpenAsync();

			//var dt = new DataTable();
			//using var adapter = new SqlDataAdapter(cmd);
			//adapter.Fill(dt);

			//return dt;
			return await this._stDbContext.Users
										.FirstOrDefaultAsync(u =>
											 u.User_Id == search);
		}
	}
}
