using DiaryWPF.Models.Domains;
using System.Data.Entity.ModelConfiguration;

namespace DiaryWPF.Models.Configurations
{
    public class RatingConfiguration : EntityTypeConfiguration<Rating>
    {

        public RatingConfiguration() 
        {
            ToTable("dbo.Ratings");

            HasKey(x => x.Id);
        }
    }
}
