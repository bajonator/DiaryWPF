using DiaryWPF.Models.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryWPF.Models.Configurations
{
    public class StudentConfiguraton : EntityTypeConfiguration<Student>
    {
        public StudentConfiguraton()
        {
            ToTable("dbo.Students");

            HasKey(x => x.Id);

            Property(x => x.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.LastName)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
