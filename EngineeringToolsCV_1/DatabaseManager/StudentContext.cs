using EngineeringToolsCV_1.Models;
using Standard.Licensing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;

namespace EngineeringToolsCV_1.DatabaseManager
{
	public class StudentContext : DbContext
	{
		public DbSet<MUser> Users { get; set; }
		public DbSet<MStudentInformations> StudentInformations { get; set; }
		public DbSet<MStudentWorkInfo> StudentWorkInfo { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			//Configure domain classes using modelBuilder here.
			modelBuilder.Entity<MStudentWorkInfo>()
				  .HasRequired<MUser>(c => c.mUsers)
				  .WithMany(g => g.mStudentWorkInfos)
			     .HasForeignKey(s => s.UserEmail);	


			modelBuilder.Entity<MUser>()
				 .HasOptional(a => a.mStudentInformations)
				 .WithRequired(ad => ad.mUser);


			
		}

	}


}
