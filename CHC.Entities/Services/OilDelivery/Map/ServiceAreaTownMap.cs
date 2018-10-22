using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHC.Entities.Services.OilDelivery.Map
{
    public class ServiceAreaTownMap : IEntityTypeConfiguration<ServiceAreaTown>
    {
		public void Configure( EntityTypeBuilder<ServiceAreaTown> builder )
		{
			builder.HasKey( obj => obj.Zip );
			builder.HasMany( obj => obj.ServiceAreas )
				.WithOne( obj => obj.Town )
				.HasForeignKey( f => f.Zip );
			builder.ToTable( "tblServiceAreaTown" );
		}
	}
}
