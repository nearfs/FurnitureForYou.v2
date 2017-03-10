﻿using FFY.Data.Contracts;
using FFY.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FFY.Data
{
    public class FFYContext : IdentityDbContext<User>, IFFYContext
    {
        public FFYContext() : base("FurnitureForYou")
        {
        }

        public virtual IDbSet<Address> Addresses { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Contact> Contacts { get; set; }

        public virtual IDbSet<CartProduct> CartProducts { get; set; }

        public virtual IDbSet<ShoppingCart> ShoppingCarts { get; set; }

        public virtual IDbSet<Order> Orders { get; set; }

        public virtual IDbSet<Product> Products { get; set; }

        public virtual IDbSet<Room> Rooms { get; set; }

        public static FFYContext Create()
        {
            return new FFYContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Entity<ShoppingCart>()
                .HasRequired(s => s.User)
                .WithOptional(s => s.ShoppingCart);

            base.OnModelCreating(modelBuilder);
        }

        IDbSet<T> IFFYContext.Set<T>()
        {
            return base.Set<T>();
        }
    }
}