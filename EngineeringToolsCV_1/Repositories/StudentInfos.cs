using EngineeringToolsCV_1.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EngineeringToolsCV_1.IRepository;
using EngineeringToolsCV_1.DatabaseManager;

namespace EngineeringToolsCV_1.Repositories
{
    public class StudentInfos : IStudentInfo
    {
        private DBName _dbName;
        private readonly IConnectionFactory _connectionFactory;

        public StudentInfos(IConnectionFactory connectionFactory, DBName dbName)
        {
            this._connectionFactory = connectionFactory;
            this._dbName = dbName;
        }

        
		  public async Task<int> RemoveStudentInfosAsync(string studentId)
        {
            using var conn = _connectionFactory.Create();
            using var cmd = new SqlCommand(@"
                DELETE FROM TBLStudentsDaten 
                WHERE Id = @Id
            ", conn);

            cmd.Parameters.AddWithValue("@Id", studentId);

            await conn.OpenAsync();
            return await cmd.ExecuteNonQueryAsync();
        }

        

        public async Task<int> AddStudentInfosAsync(MStudentInformations info)
        {
            string strQueryRegister = string.Format("INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}) VALUES(@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13)",
                                                    this._dbName.strTBL_StudentsInfo,
                                                    this._dbName.strId, this._dbName.strName,
                                                    this._dbName.strVorname, this._dbName.strEmail,
                                                    this._dbName.strStraße, this._dbName.strNummer,
                                                    this._dbName.strPostleitzahl, this._dbName.strStadt,
                                                    this._dbName.strDatum, this._dbName.strLand,
                                                    this._dbName.strImageData, this._dbName.strFileName, 
                                                    this._dbName.strContentType);

            using var conn = _connectionFactory.Create();
            using var cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("@1", info.Id);
            cmd.Parameters.AddWithValue("@2", info.Name);
            cmd.Parameters.AddWithValue("@3", info.Vorname);
            cmd.Parameters.AddWithValue("@4", info.Email);
            cmd.Parameters.AddWithValue("@5", info.Straße);
            cmd.Parameters.AddWithValue("@6", info.Straßenummer);
            cmd.Parameters.AddWithValue("@7", info.Postleitzahl);
            cmd.Parameters.AddWithValue("@8", info.Stadt);
            cmd.Parameters.AddWithValue("@9", info.Datum);
            cmd.Parameters.AddWithValue("@10", info.Land);
            cmd.Parameters.Add("@11", SqlDbType.VarBinary,-1).Value = info.ImageToByte;
            cmd.Parameters.AddWithValue("@12", info.FileName);
            cmd.Parameters.AddWithValue("@13", info.ContentType);

			   cmd.CommandTimeout = 120;

			   cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQueryRegister;

            await conn.OpenAsync();
            return await cmd.ExecuteNonQueryAsync();
        }

        public async Task<MStudentInformations> SearchStudentInfosAsync(string search)
        {
			 MStudentInformations studentInfo = null;
			
			 string strQuery = String.Format("SELECT {1},{2},{3},{4},{5},{6},{7},{8},{9} FROM {0} WHERE {10}= @1",
                                             this._dbName.strTBL_StudentsInfo, this._dbName.strName,
                                             this._dbName.strVorname, this._dbName.strEmail,
                                             this._dbName.strStraße, this._dbName.strNummer,
                                             this._dbName.strPostleitzahl, this._dbName.strStadt,
                                             this._dbName.strDatum, this._dbName.strLand, this._dbName.strId);
         
            using var conn = _connectionFactory.Create();
            using var cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("@1", search);
           using (SqlDataReader reader = await cmd.ExecuteReaderAsync()) { 
           if(await reader.ReadAsync())
            {
               studentInfo = new MStudentInformations
               {
                   Id = reader[this._dbName.strId].ToString(),
                   Name = reader[this._dbName.strName].ToString(),
                   Vorname = reader[this._dbName.strVorname].ToString(),
                   Email = reader[this._dbName.strEmail].ToString(),
                   Straße = reader[this._dbName.strStraße].ToString(),
                   Straßenummer = reader[this._dbName.strNummer].ToString(),
                   Postleitzahl = reader[this._dbName.strPostleitzahl].ToString(),
                   Stadt = reader[this._dbName.strStadt].ToString(),
                   Datum = reader[this._dbName.strDatum].ToString(),
                   Land = reader[this._dbName.strLand].ToString()
               };
            }
         
           }
                               
            return studentInfo;
        }

       
    }
}
