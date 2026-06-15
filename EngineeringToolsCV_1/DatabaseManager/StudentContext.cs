using EngineeringToolsCV_1.Models;
using Microsoft.EntityFrameworkCore;
using Standard.Licensing;
using System;
using System.Collections.Generic;
using System.Text;

namespace EngineeringToolsCV_1.DatabaseManager
{
	public class StudentContext : DbContext
	{
		public StudentContext(DbContextOptions<StudentContext> Lebenslauf) : base(Lebenslauf) { }

		public DbSet<MUser> Users { get; set; }
		public DbSet<MStudentInformations> StudentInformations { get; set; }
		public DbSet<MStudentWorkInfo> StudentWorkInfo { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Configure domain classes using modelBuilder here.
			modelBuilder.Entity<MStudentWorkInfo>()
				  .HasOne<MUser>(c => c.mUsers)
				  .WithMany(g => g.mStudentWorkInfos)
			     .HasForeignKey(s => s.UserEmail);


			modelBuilder.Entity<MUser>()
				 .HasKey(ad => ad.User_Id);

			modelBuilder.Entity<MStudentInformations>()
				 .HasOne(st => st.mUser)
				 .WithOne(u => u.mStudentInformations)
				 .HasForeignKey<MStudentInformations>(st => st.UserId);
				 		
		}

	}


}
