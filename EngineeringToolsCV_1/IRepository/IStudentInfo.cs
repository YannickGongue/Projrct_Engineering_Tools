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
    public interface IStudentInfo
    {
        Task<int> AddStudentInfosAsync(MStudentInformations info);
        Task<bool> RemoveStudentInfosAsync(string studentId);
        Task<List<MStudentInformations>> SearchStudentInfosAsync(string search);
        Task<MStudentInformations> GetStudentInfosByEmailAsync(string email);
	}
}
