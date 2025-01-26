using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Infrastructure.Persistence.Configurations
{
    public class RawMaterialConfigurations : IEntityTypeConfiguration<RawMaterialEntity>
    {
        public void Configure(EntityTypeBuilder<RawMaterialEntity> builder)
        {
            builder
            .HasKey(x => x.Id);
        }
    }
}
