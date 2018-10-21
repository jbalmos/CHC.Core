using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHC.Entities.Customers.Map
{
    public class FillPipeLocationMap : IEntityTypeConfiguration<FillPipeLocation>
    {
		public void Configure( EntityTypeBuilder<FillPipeLocation> builder )
		{
			builder.HasKey( obj => obj.ID );
			builder.Property( obj => obj.ID ).HasColumnName( "FillPipeLocationID" );
			builder.ToTable( "tblFillPipeLocation" );
		}
	}
}
