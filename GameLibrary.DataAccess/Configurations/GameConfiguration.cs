using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameLibrary.DataAccess.Configurations
{
    public class GameConfiguration: IEntityTypeConfiguration<GameEntity>
    {
        public void Configure(EntityTypeBuilder<GameEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Name)
                .IsRequired();
            builder.Property(b => b.Genres)
                .IsRequired();
            builder.Property(b => b.GameDeveloper)
                .IsRequired();
        }
    }
}
