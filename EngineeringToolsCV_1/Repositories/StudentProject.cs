using EngineeringToolsCV_1.DatabaseManager;
using EngineeringToolsCV_1.IRepository;
using EngineeringToolsCV_1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringToolsCV_1.Repositories
{
	public class StudentProject : IStudentProject
	{
		private StudentContext _studentContext;
		public StudentProject(StudentContext studentContext)
		{
			_studentContext = studentContext;
		}

		public async Task<int> AddProjectAsync(MStudentProject ProjectInfo)
		{
			return await Task.FromResult(0);
		}

		public async Task<int> RemoveProjectAsync(string studentId)
		{
			return await Task.FromResult(0);
		}

		public async Task<DataTable> SearchProjectAsync(string search)
		{
			return await Task.FromResult(new DataTable());
		}

		public async Task<int> UpdateProjectAsync(MStudentProject ProjectInfo)
		{
			return await Task.FromResult(0);
		}

		public async Task DeleteProjectAsync(string studentId)
		{

		}
	}
}