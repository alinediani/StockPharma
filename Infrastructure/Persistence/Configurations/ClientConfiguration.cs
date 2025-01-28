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
    public class ClientConfigurations : IEntityTypeConfiguration<ClientEntity>
    {
        public void Configure(EntityTypeBuilder<ClientEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Email)
                   .HasMaxLength(200);

            builder.HasMany(x => x.Orders)  // Referência ao relacionamento de Orders na entidade Client
                .WithOne(x => x.Client)  // Relacionamento inverso
                .HasForeignKey(x => x.ClientId)  // A chave estrangeira deve ser especificada
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
