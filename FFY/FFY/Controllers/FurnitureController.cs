﻿using Bytes2you.Validation;
using FFY.Models;
using FFY.Services.Contracts;
using FFY.Web.Models.Furniture;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FFY.Web.Controllers
{
    public class FurnitureController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IProductsService productsService;

        public FurnitureController(IUsersService usersService,
            IProductsService productsService)
        {
            Guard.WhenArgument<IUsersService>(usersService, "Users service cannot be null.")
                .IsNull()
                .Throw();

            Guard.WhenArgument<IProductsService>(productsService, "Products service cannot be null.")
                .IsNull()
                .Throw();

            this.usersService = usersService;
            this.productsService = productsService;
        }

        // GET: Furniture/Product
        public ActionResult Product(int? id, DetailedProductViewModel model)
        {
            model.Product = this.productsService.GetProductById(id.Value);
            model.Quantity = 1;

            this.ModelState.Clear();

            if (model.Product == null)
            {
                // 404
            }

            return this.View(model);
        }

        // GET: Furniture/AddFavorites

        // POST: Furniture/AddFavorites
        [HttpPost]
        public ActionResult AddFavorites(DetailedProductViewModel model)
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("login", "account", new { returnUrl = $"/furniture/product/{model.Product.Id}" });
            }

            var user = this.usersService.GetUserById(this.User.Identity.GetUserId());
            var product = this.productsService.GetProductById(model.Product.Id);

            this.usersService.AddProductToFavorites(user, product);

            return this.RedirectToAction("product", "furniture", new { id = model.Product.Id });
        }

        // POST: Furniture/RemoveFavorites
        [HttpPost]
        public ActionResult RemoveFavorites(DetailedProductViewModel model)
        {

            if (!this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("login", "account", new { returnUrl = $"/furniture/product/{model.Product.Id}" });
            }

            var user = this.usersService.GetUserById(this.User.Identity.GetUserId());
            var product = this.productsService.GetProductById(model.Product.Id);

            this.usersService.RemoveProductFromFavorites(user, product);

            return this.RedirectToAction("product", "furniture", new { id = model.Product.Id });
        }
    }
}