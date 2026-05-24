using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Text;
using System.Windows.Media;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace EngineeringToolsCV_1.Models
{
    public interface IUserInfo
    {
        Task<DataTable> GetUserInfoAsync(string id, string password);

        Task<int> AddStudentInfosAsync(MStudentInformations info);
        Task<int> AddUserInfoAsync(MUser info);

        Task<int> UpdateUserInfosAsync(MUser info);

        Task<int> RemoveStudentInfosAsync(string studentId);

        Task<DataTable> SearchStudentInfosAsync(string search);
       
    }
}
