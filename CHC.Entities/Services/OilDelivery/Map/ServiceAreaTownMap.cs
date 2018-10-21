using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHC.Entities.Services.OilDelivery.Map
{
    public class ServiceAreaTownMap : IEntityTypeConfiguration<ServiceAreaTown>
    {
		public void Configure( EntityTypeBuilder<ServiceAreaTown> builder )
		{
			builder.HasKey( obj => obj.Zip );
			builder.ToTable( "tblServiceAreaTown" );
		}
	}
}
