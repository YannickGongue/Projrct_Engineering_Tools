using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EngineeringToolsCV_1.Models
{
    public class MUser
    {
        [Key]
        public string User_Id { get; set;}
        public string Email { get; set; }
        public string Passwort { get; set; }        
        public MStudentInformations mStudentInformations { get; set; }
		  public ICollection<MStudentWorkInfo> mStudentWorkInfos { get; set; }
		  public ICollection<MStudentProject> mStudentProjects { get; set; }

	}
}
