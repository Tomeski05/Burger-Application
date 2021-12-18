using BurgerApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BurgerApp.DataAccess.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("Users")
                .HasKey(x => x.Id);

            builder
                .Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(p => p.LastName)
                .HasMaxLength(50);

            builder
                .Property(p => p.Address)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasMany(x => x.Orders)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

        }
    }
}
