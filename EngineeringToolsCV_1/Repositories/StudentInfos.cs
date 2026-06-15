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

		public async Task<MStudentInformations> GetStudentInfosByEmailAsync(string email)
		{
			return await this.dbContext.StudentInformations
										   	.Where(c => c.StudentEmail == email)
										   	.FirstOrDefaultAsync();
		}

		public async Task RemoveStudentInfosAsync(string studentId)
      {
          var studentInfo = await GetStudentInfosByEmailAsync(studentId);
			
			 this.dbContext.StudentInformations.Remove(studentInfo);
			 await this.dbContext.SaveChangesAsync();

		}



		public async Task<int> AddStudentInfosAsync(MStudentInformations info)
      {
          this.dbContext.StudentInformations.Add(info);
          return await this.dbContext.SaveChangesAsync();
		}

        public async Task<List<MStudentInformations>> SearchStudentInfosAsync(string search)
        {
			 //List<MStudentInformations> studentInfos = new List<MStudentInformations>();
			
			 //string strQuery = String.Format("SELECT {1},{2},{3},{4},{5},{6},{7},{8},{9} FROM {0} WHERE {10}= @1",
    //                                         this._dbName.strTBL_StudentsInfo, this._dbName.strName,
    //                                         this._dbName.strVorname, this._dbName.strEmail,
    //                                         this._dbName.strStraße, this._dbName.strNummer,
    //                                         this._dbName.strPostleitzahl, this._dbName.strStadt,
    //                                         this._dbName.strDatum, this._dbName.strLand, this._dbName.strId);
         
    //        using var conn = _connectionFactory.Create();
    //        using var cmd = new SqlCommand();
    //        cmd.Connection = conn;

    //        cmd.Parameters.AddWithValue("@1", search);
    //       using (SqlDataReader reader = await cmd.ExecuteReaderAsync()) { 
    //       if(await reader.ReadAsync())
    //        {
    //           studentInfo = new MStudentInformations
    //           {
    //               Id = reader[this._dbName.strId].ToString(),
    //               Name = reader[this._dbName.strName].ToString(),
    //               Vorname = reader[this._dbName.strVorname].ToString(),
    //               Email = reader[this._dbName.strEmail].ToString(),
    //               Straße = reader[this._dbName.strStraße].ToString(),
    //               Straßenummer = reader[this._dbName.strNummer].ToString(),
    //               Postleitzahl = reader[this._dbName.strPostleitzahl].ToString(),
    //               Stadt = reader[this._dbName.strStadt].ToString(),
    //               Datum = reader[this._dbName.strDatum].ToString(),
    //               Land = reader[this._dbName.strLand].ToString()
    //           };
    //        }
         
    //       }
                               
            return await this.dbContext.StudentInformations
                                        .Where(c => c.UserId == search)
                                        .ToListAsync();
        }

       
    }
}
