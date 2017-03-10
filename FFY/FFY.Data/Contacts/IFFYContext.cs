﻿using FFY.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace FFY.Data.Contracts
{
    public interface IFFYContext
    {
        IDbSet<Address> Addresses { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Contact> Contacts { get; set; }

        IDbSet<Order> Orders { get; set; }

        IDbSet<CartProduct> CartProducts { get; set; }

        IDbSet<ShoppingCart> ShoppingCarts { get; set; }

        IDbSet<Product> Products { get; set; }

        IDbSet<Room> Rooms { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}
