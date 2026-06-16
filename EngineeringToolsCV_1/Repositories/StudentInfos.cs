using EngineeringToolsCV_1.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EngineeringToolsCV_1.IRepository;
using EngineeringToolsCV_1.DatabaseManager;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EngineeringToolsCV_1.Repositories
{
    public class StudentInfos : IStudentInfo
    {
        private StudentContext dbContext;

        public StudentInfos( StudentContext studentContext)
        {
            this.dbContext = studentContext;
        }

		public async Task<MStudentInformations> GetStudentInfosByEmailAsync(string studentId)
		{
			return await this.dbContext.StudentInformations
										   	.Where(c => c.UserId == studentId)
										   	.FirstOrDefaultAsync();
		}

		public async Task<bool> RemoveStudentInfosAsync(string studentId)
      {
         var studentInfo = await GetStudentInfosByEmailAsync(studentId);
			
			this.dbContext.StudentInformations.Remove(studentInfo);
			if( await this.dbContext.SaveChangesAsync() > 0)
         {
				return true;
			}
         else
         {
				return false;
			}
		}

		public async Task<int> AddStudentInfosAsync(MStudentInformations info)
      {
          this.dbContext.StudentInformations.Add(info);
          return await this.dbContext.SaveChangesAsync();
		}

      public async Task<List<MStudentInformations>> SearchStudentInfosAsync(string search)
      {                    
         return await this.dbContext.StudentInformations
                                        .Where(c => c.UserId == search)
                                        .ToListAsync();
      }   
    }
}
