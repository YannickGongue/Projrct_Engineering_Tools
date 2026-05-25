using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using EngineeringToolsCV_1.Models;

namespace EngineeringToolsCV_1.IRepository
{
    public  interface IStudentWorkInfo
    {
        Task<int> AddWorkInfosAsync(MStudentWorkInfo info);

        Task<int> UpdateWorkInfosAsync(MStudentWorkInfo info);

        Task<int> RemoveWorkInfosAsync(string studentId);

        Task<DataTable> SearchWorkInfosAsync(string search);

    }
}
