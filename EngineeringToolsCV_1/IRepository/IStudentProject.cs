using EngineeringToolsCV_1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringToolsCV_1.IRepository
{
	public interface IStudentProject
	{
		Task<int> AddProjectAsync(MStudentProject ProjectInfo);

		Task<int> UpdateProjectAsync(MStudentProject ProjectInfo);

		Task<int> RemoveProjectAsync(string studentId);

		Task<DataTable> SearchProjectAsync(string search);
	}
}
