using EngineeringToolsCV_1.DatabaseManager;
using EngineeringToolsCV_1.IRepository;
using EngineeringToolsCV_1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace EngineeringToolsCV_1.Repositories
{
    public class StudentWorkInfo : IStudentWorkInfo
    {
        private StudentContext _studentContext;
        public StudentWorkInfo(StudentContext studentContext)
        {
            this._studentContext = studentContext;
        }

        public async Task<int> AddWorkInfosAsync(MStudentWorkInfo info)
        {
			//string strQueryRegister = string.Format("INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10}) " +
			//                                        "VALUES ( @1, @2, @3, @4, @5, @6, @7, @8, @9, @10)",
			//                                        this._dbName.strTBL_Beruf, this._dbName.strTitel,
			//                                        this._dbName.strEmail, this._dbName.strSkills,
			//                                        this._dbName.strFirma, this._dbName.strStartDatum,
			//                                        this._dbName.strEndDatum, this._dbName.strStandOrt,
			//                                        this._dbName.strOrtsTyp, this._dbName.strAufgabe,
			//                                        this._dbName.strArbeitArt);

			//using var conn = _connectionFactory.Create();
			//using var cmd = new SqlCommand(strQueryRegister, conn);

			//cmd.Parameters.AddWithValue("@1", info.Titel);
			//cmd.Parameters.AddWithValue("@2", info.UserEmail);
			//cmd.Parameters.AddWithValue("@3", info.Skills);
			//cmd.Parameters.AddWithValue("@4", info.Firma);
			//cmd.Parameters.AddWithValue("@5", info.StartDatum);
			//cmd.Parameters.AddWithValue("@6", info.EndDatum);
			//cmd.Parameters.AddWithValue("@7", info.Standort);
			//cmd.Parameters.AddWithValue("@8", info.OrtType);
			//cmd.Parameters.AddWithValue("@9", info.Aufgabe);
			//cmd.Parameters.AddWithValue("@10", info.ArbeitsArt);

			//await conn.OpenAsync();

			//return await cmd.ExecuteNonQueryAsync();

			this._studentContext.StudentWorkInfo.Add(info);
			return await this._studentContext.SaveChangesAsync();
		}

        public Task<int> UpdateWorkInfosAsync(MStudentWorkInfo info)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveWorkInfosAsync(string studentId)
        {
            throw new NotImplementedException();
        }

        public Task<DataTable> SearchWorkInfosAsync(string search)
        {
            throw new NotImplementedException();
        }
    }
}
