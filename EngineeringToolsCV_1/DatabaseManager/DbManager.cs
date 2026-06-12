using EngineeringToolsCV_1.IRepository;
using EngineeringToolsCV_1.Models;
using System.Data;
using System.Threading.Tasks;

namespace EngineeringToolsCV_1.DatabaseManager
{
    public class DbManager
    {
        private readonly IStudentInfo _userInfo;
        private readonly IStudentWorkInfo _userWorkInfo;

        public DbManager(IStudentInfo userInfo, IStudentWorkInfo userWorkInfo)
        {
            this._userInfo = userInfo;
            this._userWorkInfo = userWorkInfo;
        }

        //public Task<MStudentInformations> SearchStudentInfosAsync(string search)
        //{
        //    return _userInfo.SearchStudentInfosAsync(search);
        //}

        //public Task<int> GetUserInfoAsync(string id, string password)
        //{
        //    return _userInfo.GetUserInfoAsync(id, password);
        //}

        public Task<int> AddStudentInfosAsync(MStudentInformations info)
        {
            return _userInfo.AddStudentInfosAsync(info);
        }

        public Task<int> AddWorkInfosAsync(MStudentWorkInfo info)
        {
            return _userWorkInfo.AddWorkInfosAsync(info);
        }

        //public Task<int> UpdateStudentInfosAsync(MUser info)
        //{
        //    return _userInfo.UpdateUserInfosAsync(info);
        //}


        //public Task<int> AddUserInfo(MUser UserInfo)
        //{ 
        //  return _userInfo.AddUserInfoAsync(UserInfo);
		  //}

        //public Task<int> RemoveStudentInfosAsync(string id)
        //{
        //    return _userInfo.RemoveStudentInfosAsync(id);
        //}


    }
}
