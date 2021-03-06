﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CHC.Entities.Services.OilDelivery.Map
{
    public class PriceLevelFeeMap : IEntityTypeConfiguration<PriceLevelFee>
	{
		public void Configure( EntityTypeBuilder<PriceLevelFee> builder )
		{
			builder.HasKey( obj => obj.ID );
			builder.Property( obj => obj.ID ).HasColumnName( "OilDeliveryPriceLevelFeeID" );
			builder.ToTable( "tblOilDeliveryPriceLevelFee" );
		}
	}
}
