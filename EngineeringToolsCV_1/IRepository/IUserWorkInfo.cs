using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using EngineeringToolsCV_1.Models;

namespace EngineeringToolsCV_1.IRepository
{
    public  interface IUserWorkInfo
    {
        Task<int> AddWorkInfosAsync(MUserWorkInfo info);

        Task<int> UpdateWorkInfosAsync(MUserWorkInfo info);

        Task<int> RemoveWorkInfosAsync(string studentId);

        Task<DataTable> SearchWorkInfosAsync(string search);

    }
}
