using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel.DataAnnotations;


namespace EngineeringToolsCV_1.Models
{
    public class MStudentInformations
    {
		  [Key]
		  public string StudentEmail { get; set; }
		  public string UserId { get; set; }
		  public string Name { get; set; }
        public string Vorname { get; set; }
        public Byte[] ImageData { get; set; }
        public string ContentType { get; set; }
		  
        public string Stadt { get; set; }
        public string Postleitzahl { get; set; }
        public string Straße { get; set; }
        public string Straßenummer { get; set; }
        public string Datum { get; set; }
        public string Land { get; set; }
        public string FileName { get; set; }

        public MUser mUser { get; set; }
	}
}
