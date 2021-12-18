using BurgerApp.DataAccess.Mapping;
using BurgerApp.Domain.Enums;
using BurgerApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BurgerApp.DataAccess
{
    public class BurgerContext : DbContext
    {
        public BurgerContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Burger> Burgers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());

            #region Model Mappings

            //Burger model mapping
            modelBuilder.Entity<Burger>()
                .ToTable("Burgers")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Burger>()
                .Property(p => p.Name)
                .HasMaxLength(50);

            modelBuilder.Entity<Burger>()
                .Property(p => p.Price)
                .IsRequired();

            modelBuilder.Entity<Burger>()
                .HasMany(x => x.BurgerOrders)
                .WithOne(x => x.Burger)
                .HasForeignKey(x => x.BurgerId);

            //Order model mapping
            modelBuilder.Entity<Order>()
                .ToTable("Orders")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Order>()
                .HasMany(p => p.BurgerOrders)
                .WithOne(p => p.Order)
                .HasForeignKey(p => p.OrderId);

            //Feedback model mapping
            modelBuilder.Entity<Feedback>()
                .ToTable("Feedbacks")
                .HasKey(x => x.Id);

            #endregion

            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Filip",
                    LastName = "Tomeski",
                    Address = "Skopje",
                    Phone = 12344567890
                },
                new User
                {
                    Id = 2,
                    FirstName = "Bob",
                    LastName = "Bobsky",
                    Address = "Bitola",
                    Phone = 12344321
                }

                );

            // pizza data
            modelBuilder.Entity<Burger>()
                .HasData(
                    new Burger()
                    {
                        Id = 1,
                        Name = "Walter White",
                        Price = 7,
                        Size = BurgerSize.Normal,
                        Image = ""
                    },
                   new Burger()
                   {
                       Id = 2,
                       Name = "Walter White",
                       Price = 7,
                       Size = BurgerSize.Junior,
                       Image = ""
                   },
                   new Burger()
                   {
                       Id = 3,
                       Name = "Jessie Pinkman",
                       Price = 9,
                       Size = BurgerSize.Normal,
                       Image = ""
                   },
                   new Burger()
                   {
                       Id = 4,
                       Name = "Jessie Pinkman",
                       Price = 8,
                       Size = BurgerSize.Junior,
                       Image = ""
                   },
                   new Burger()
                   {
                       Id = 5,
                       Name = "Crispy Chicken",
                       Price = 10.5,
                       Size = BurgerSize.Normal,
                       Image = ""
                   },
                   new Burger()
                   {
                       Id = 6,
                       Name = "Crispy Chicken",
                       Price = 10.5,
                       Size = BurgerSize.Junior,
                       Image = ""
                   },
                   new Burger()
                   {
                       Id = 7,
                       Name = "Chili Burger",
                       Price = 6.5,
                       Size = BurgerSize.Normal,
                       Image = ""
                   },
                   new Burger()
                   {
                       Id = 8,
                       Name = "SChili Burger",
                       Price = 9.5,
                       Size = BurgerSize.Junior,
                       Image = ""
                   }
                );

            // porder data
            modelBuilder.Entity<Order>()
                .HasData(
                    new Order
                    {
                        Id = 1,
                        UserId = 1
                    },
                    new Order
                    {
                        Id = 2,
                        UserId = 1
                    },
                    new Order
                    {
                        Id = 3,
                        UserId = 2
                    }
                );

            // pizza order data
            modelBuilder.Entity<BurgerOrder>()
                .HasData(
                    new BurgerOrder()
                    {
                        Id = 1,
                        OrderId = 1,
                        BurgerId = 1
                    },
                    new BurgerOrder()
                    {
                        Id = 2,
                        OrderId = 1,
                        BurgerId = 4
                    },
                    new BurgerOrder()
                    {
                        Id = 3,
                        OrderId = 2,
                        BurgerId = 1
                    },
                    new BurgerOrder()
                    {
                        Id = 4,
                        OrderId = 2,
                        BurgerId = 5
                    },
                    new BurgerOrder()
                    {
                        Id = 5,
                        OrderId = 2,
                        BurgerId = 7
                    },
                    new BurgerOrder()
                    {
                        Id = 6,
                        OrderId = 3,
                        BurgerId = 5
                    },
                    new BurgerOrder()
                    {
                        Id = 7,
                        OrderId = 3,
                        BurgerId = 8
                    },
                    new BurgerOrder()
                    {
                        Id = 8,
                        OrderId = 3,
                        BurgerId = 6
                    }
                    );
        }

    }
}
