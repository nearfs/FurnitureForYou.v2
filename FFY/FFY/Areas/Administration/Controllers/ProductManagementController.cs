﻿using Bytes2you.Validation;
using FFY.Data.Factories;
using FFY.Models;
using FFY.Services.Contracts;
using FFY.Services.Utilities;
using FFY.Web.Areas.Administration.Models;
using FFY.Web.Areas.Administration.Models.ProductManagement;
using FFY.Web.Custom.Attributes;
using FFY.Web.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FFY.Web.Areas.Administration.Controllers
{
    [Localize]
    [Security(Roles = "Administrator, Moderator", RedirectUrl = "~/en/error/unauthorized")]
    public class ProductManagementController : Controller
    {
        private const int ProductsPerPage = 10;

        private const string DefaultRoomImageFileName = "default-room-image";
        private const string DefaultCategoryImageFileName = "default-category-image";
        private const string DefaultProductImageFileName = "default-product-image";
        private const string DefaultRoomFolderName = "rooms";
        private const string DefaultCategoryFolderName = "categories";
        private const string DefaultProductFolderName = "products";

        private readonly IMapperProvider mapper;
        private readonly IImageUploader imageUploader;
        private readonly IProductFactory productFactory;
        private readonly IProductsService productsService;
        private readonly IRoomFactory roomFactory;
        private readonly IRoomsService roomsService;
        private readonly ICategoryFactory categoryFactory;
        private readonly ICategoriesService categoriesService;

        public ProductManagementController(IMapperProvider mapper,
            IImageUploader imageUploader,
            IProductFactory productFactory,
            IProductsService productsService,
            IRoomFactory roomFactory,
            IRoomsService roomsService,
            ICategoryFactory categoryFactory,
            ICategoriesService categoriesService)
        {

            Guard.WhenArgument<IMapperProvider>(mapper, "Mapper provider cannot be null.")
                .IsNull()
                .Throw();

            Guard.WhenArgument<IImageUploader>(imageUploader, "Image uploader cannot be null.")
                .IsNull()
                .Throw();

            Guard.WhenArgument<IProductFactory>(productFactory, "Product factory cannot be null.")
                .IsNull()
                .Throw();

            Guard.WhenArgument<IProductsService>(productsService, "Products service cannot be null.")
                .IsNull()
                .Throw();

            Guard.WhenArgument<IRoomFactory>(roomFactory, "Room factory cannot be null.")
                .IsNull()
                .Throw();

            Guard.WhenArgument<IRoomsService>(roomsService, "Rooms service cannot be null.")
                .IsNull()
                .Throw();

            Guard.WhenArgument<ICategoryFactory>(categoryFactory, "Room factory cannot be null.")
                .IsNull()
                .Throw();

            Guard.WhenArgument<ICategoriesService>(categoriesService, "Rooms service cannot be null.")
                .IsNull()
                .Throw();

            this.mapper = mapper;
            this.imageUploader = imageUploader;
            this.productFactory = productFactory;
            this.productsService = productsService;
            this.roomFactory = roomFactory;
            this.roomsService = roomsService;
            this.categoryFactory = categoryFactory;
            this.categoriesService = categoriesService;
        }

        // GET: Administration/ProductManagement
        public ViewResult Index(ProductsViewModel model)
        {
            return this.View(model);
        }

        // GET: Administration/SearchProducts
        public PartialViewResult SearchProducts(SearchModel searchModel, ProductsViewModel productsModel, int? page)
        {
            int actualPage = page ?? 1;

            var result = this.productsService.SearchProducts(searchModel.SearchWord, searchModel.SortBy, actualPage, ProductsPerPage);
            var count = this.productsService.GetProductsCount(searchModel.SearchWord);

            productsModel.SearchModel = searchModel;
            productsModel.ProductsCount = count;
            productsModel.Pages = (int)Math.Ceiling((double)count / ProductsPerPage);
            productsModel.Page = actualPage;
            productsModel.Products = mapper.Map<IEnumerable<SingleProductViewModel>>(result);

            return this.PartialView("ProductsPartial", productsModel);
        }

        // GET: Administration/ProductAddition
        public ViewResult ProductAddition()
        {
            this.ViewBag.Rooms = this.roomsService.GetRooms();
            this.ViewBag.Categories = this.categoriesService.GetCategories();

            return this.View();
        }

        // POST: Administration/AddProduct
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduct(ProductAdditionViewModel model)
        {
            var file = Request.Files[0];

            string imageFileName = DefaultProductImageFileName;
            string folderName = DefaultProductFolderName;

            model.ImagePath = this.imageUploader.Upload(file, Server, imageFileName, folderName);

            model.Room = this.roomsService.GetRoomById(model.RoomId);
            model.Category = this.categoriesService.GetCategoryById(model.CategoryId);

            var product = this.productFactory.CreateProduct(model.Name,
                model.Quantity,
                model.Price,
                model.DiscountedPrice,
                model.DiscountPercentage,
                model.DiscountPercentage > 0 ? true : false,
                model.Description,
                model.Category.Id,
                model.Category,
                model.Room.Id,
                model.Room,
                model.ImagePath,
                false);

            try
            {
                this.productsService.AddProduct(product);

                return this.RedirectToAction("productAddition", "productManagement", new { area = "administration" });
            }
            catch (Exception)
            {
                this.ModelState.AddModelError("", "Problem occured during product addition.");
                return this.View("productAddition", model);
            }
        }

        // POST: Administration/AddRoom
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRoom(RoomPartialViewModel model)
        {
            var file = Request.Files[0];

            string imageFileName = DefaultRoomImageFileName;
            string folderName = DefaultRoomFolderName;

            model.ImagePath = this.imageUploader.Upload(file, Server, imageFileName, folderName);

            var room = this.roomFactory.CreateRoom(model.Name, model.ImagePath);

            try
            {
                this.roomsService.AddRoom(room);

                return this.RedirectToAction("productAddition", "productManagement", new { area = "administration" });
            }
            catch (Exception)
            {
            }

            return this.RedirectToAction("productAddition", "productManagement", new { area = "administration" });
        }

        // POST: Administration/AddCategory
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCategory(CategoryPartialViewModel model)
        {
            var file = Request.Files[0];

            string imageFileName = DefaultCategoryImageFileName;
            string folderName = DefaultCategoryFolderName;

            model.ImagePath = this.imageUploader.Upload(file, Server, imageFileName, folderName);

            var category = this.categoryFactory.CreateCategory(model.Name, model.ImagePath);

            try
            {
                this.categoriesService.AddCategory(category);

                this.RedirectToAction("productAddition", "productManagement", new { area = "administration" });
            }
            catch (Exception)
            {
            }

            return this.RedirectToAction("productAddition", "productManagement", new { area = "administration" });
        }
    }
}