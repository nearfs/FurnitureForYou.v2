﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FFY.Models
{
    public class User : IdentityUser
    {
        private ICollection<Order> orders;

        public User()
        {
            this.Orders = new HashSet<Order>();
        }

        public User(string username,
            string firstName,
            string lastName,
            string email,
            string userRole) : this()
        {
            this.UserName = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.UserRole = userRole;
        }

        //TODO: Remove possibly
        //[Key]
        //public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public override string UserName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string UserRole { get; set; }

        public virtual ICollection<Order> Orders
        {
            get
            {
                return this.orders;
            }
            set
            {
                this.orders = value;
            }
        }

        public virtual ShoppingCart ShoppingCart { get; set; }

        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            // note the authenticationtype must match the one defined in cookieauthenticationoptions.authenticationtype
            var useridentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // add custom user claims here
            return useridentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}
