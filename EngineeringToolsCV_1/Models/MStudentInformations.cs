using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace EngineeringToolsCV_1.Models
{
    public class MStudentInformations
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public string ImagePath { get; set; }
        public Byte[] ImageToByte { get; set; }
        public string ContentType { get; set; }
        public string Email { get; set; }
        public string Stadt { get; set; }
        public string Postleitzahl { get; set; }
        public string Straße { get; set; }
        public string Straßenummer { get; set; }
        public string Datum { get; set; }
        public string Land { get; set; }
        public string FileName { get; set; }


    }
}
