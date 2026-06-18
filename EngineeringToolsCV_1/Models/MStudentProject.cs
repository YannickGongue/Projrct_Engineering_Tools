using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EngineeringToolsCV_1.Models
{
	public class MStudentProject
	{
		[Key]
		public string UserEmail { get; set; }
		public string ProjectName { get; set; }
		public string ProjectDescription { get; set; }
		public string Skills { get; set; }
		public MUser mUsers { get; set; }


	}
}
