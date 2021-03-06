﻿using System.Web.Mvc;

namespace FFY.Web.Areas.Administration
{
    public class AdministrationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdministrationUsers",
                "{language}/administration/users/{id}",
                new { controller = "UserManagement", action = "UserProfile", language = "en" }
            );

            context.MapRoute(
                "AdministrationContacts",
                "{language}/administration/contacts/{id}",
                new { controller = "ContactManagement", action = "ContactDetailed", language = "en" }
            );

            context.MapRoute(
                "AdministrationOrders",
                "{language}/administration/orders/{id}",
                new { controller = "OrderManagement", action = "OrderDetailed", language = "en" }
            );

            context.MapRoute(
                "AdministrationAddProduct",
                "{language}/administration/productManagement/add",
                new { controller = "ProductManagement", action = "ProductAddition", language = "en" }
            );

            context.MapRoute(
                "AdministrationEditProduct",
                "{language}/administration/productManagement/edit/{id}",
                new { controller = "ProductManagement", action = "ProductEditing", language = "en" }
            );

            context.MapRoute(
                "AdministrationDefaultWithLanguage",
                "{language}/administration/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional, language = "en" }
            );
        }
    }
}