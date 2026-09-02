using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EngineeringToolsCV_1.Models
{
    public class MStudentWorkInfo
    {
        public string UserId { get; set; }
		 public string Titel { get; set; }
        public string Beschreibung { get; set; }
        public string Skills { get; set; }
        public string Firma { get; set; }
        public string StartDatum { get; set; }
        public string EndDatum { get; set; }
        public string Standort { get; set; }
        public string OrtType { get; set; }
        public string ArbeitsArt { get; set; }
		  [Key]
		  public string Email { get; set; }

		  public MUser mUsers { get; set; }
	}
}
