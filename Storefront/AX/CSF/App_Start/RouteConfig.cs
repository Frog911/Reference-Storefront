﻿//-----------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="Sitecore Corporation">
//     Copyright (c) Sitecore Corporation 1999-2016
// </copyright>
// <summary>Defines the RouteConfig class.</summary>
//-----------------------------------------------------------------------
// Copyright 2016 Sitecore Corporation A/S
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file 
// except in compliance with the License. You may obtain a copy of the License at
//       http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed under the 
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, 
// either express or implied. See the License for the specific language governing permissions 
// and limitations under the License.
// -------------------------------------------------------------------------------------------

namespace Sitecore.Reference.Storefront
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using Sitecore.Reference.Storefront.SitecorePipelines;
    using Util;
    using System.Collections.Generic;

    /// <summary>
    /// Used to register all routes
    /// </summary>
    public static class RouteConfig
    {
        private static List<ApiInfo> _apiInfoList = new List<ApiInfo>()
        {
            new ApiInfo("account-forgotpassword", "Account", "ForgotPassword"),
            new ApiInfo("account-getcurrentuser", "Account", "GetCurrentUser"),
            new ApiInfo("account-register", "Account", "Register"),
            new ApiInfo("account-addresslist", "Account", "AddressList"),
            new ApiInfo("account-recentorders", "Account", "RecentOrders"),
            new ApiInfo("account-addressmodify", "Account", "AddressModify"),
            new ApiInfo("account-addressdelete", "Account", "AddressDelete"),
            new ApiInfo("account-updateprofile", "Account", "UpdateProfile"),
            new ApiInfo("account-changepassword", "Account", "ChangePassword"),
            new ApiInfo("cart-addcartline", "Cart", "AddCartLine"),
            new ApiInfo("cart-addcartlines", "Cart", "AddCartLines"),
            new ApiInfo("cart-applydiscount", "Cart", "ApplyDiscount"),
            new ApiInfo("cart-deletelineitem", "Cart", "DeleteLineItem"),
            new ApiInfo("cart-getcurrentcart", "Cart", "GetCurrentCart"),
            new ApiInfo("cart-removediscount", "Cart", "RemoveDiscount"),
            new ApiInfo("cart-updatelineitem", "Cart", "UpdateLineItem"),
            new ApiInfo("cart-updateminicart", "Cart", "UpdateMiniCart"),
            new ApiInfo("catalog-checkgiftcardbalance", "Catalog", "CheckGiftCardBalance"),
            new ApiInfo("catalog-facetapplied", "Catalog", "FacetApplied"),
            new ApiInfo("checkout-getnearbystores", "Checkout", "GetNearbyStores"),
            new ApiInfo("catalog-getproductstockinfo", "Catalog", "GetCurrentProductStockInfo"),
            new ApiInfo("catalog-signupforbackinstocknotification", "Catalog", "SignUpForBackInStockNotification"),
            new ApiInfo("catalog-sortorderapplied", "Catalog", "SortOrderApplied"),
            new ApiInfo("catalog-switchcurrency", "Catalog", "SwitchCurrency"),
            new ApiInfo("checkout-getavailablestates", "Checkout", "GetAvailableStates"),
            new ApiInfo("checkout-getcheckoutdata", "Checkout", "GetCheckoutData"),
            new ApiInfo("checkout-getshippingmethods", "Checkout", "GetShippingMethods"),
            new ApiInfo("checkout-setshippingmethod", "Checkout", "SetShippingMethods"),
            new ApiInfo("checkout-setpaymentmethod", "Checkout", "SetPaymentMethods"),
			new ApiInfo("checkout-updateloyaltycard", "Checkout", "UpdateLoyaltyCard"),
            new ApiInfo("checkout-submitorder", "Checkout", "SubmitOrder"),
            new ApiInfo("loyalty-activateaccount", "Loyalty", "ActivateAccount"),
            new ApiInfo("loyalty-activeloyaltycards", "Loyalty", "ActiveLoyaltyCards"),
            new ApiInfo("loyalty-getloyaltycards", "Loyalty", "GetLoyaltyCards"),
            new ApiInfo("wishlist-addwishliststocart", "WishList", "AddWishListsToCart"),
            new ApiInfo("wishlist-activewishlists", "WishList", "ActiveWishLists"),
            new ApiInfo("wishlist-addtowishlist", "WishList", "AddToWishList"),
            new ApiInfo("wishlist-createwishlist", "WishList", "CreateWishList"),
            new ApiInfo("wishlist-deletelineitem", "WishList", "DeleteLineItem"),
            new ApiInfo("wishlist-deletewishlist", "WishList", "DeleteWishList"),
            new ApiInfo("wishlist-getwishlist", "WishList", "GetWishList"),
            new ApiInfo("wishlist-updatelineitem", "WishList", "UpdateLineItem"),
            new ApiInfo("wishlist-updatewishlist", "WishList", "UpdateWishList"),
            new ApiInfo("global-culturechosen", "Shared", "CultureChosen")
        };

        /// <summary>
        ///  Called to register any routes
        /// </summary>
        /// <param name="routes">The route collection to add to</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            foreach (var apiInfo in _apiInfoList)
            {
                routes.MapRoute(
                    name: apiInfo.Name,
                    url: apiInfo.Url,
                    defaults: new { controller = apiInfo.Controller, action = apiInfo.Action, id = UrlParameter.Optional });
            }

            routes.MapRoute(
                name: ProductItemResolver.ShopCategoryRouteName,
                url: ProductItemResolver.ShopUrlRoute + "/{id}",
                defaults: new { id = UrlParameter.Optional, itemType = ProductItemResolver.CategoryItemType });

            routes.MapRoute(
                name: ProductItemResolver.ShopProductRouteName,
                url: ProductItemResolver.ShopUrlRoute + "/{category}/{id}",
                defaults: new { id = UrlParameter.Optional, itemType = ProductItemResolver.ProductItemType });

            routes.MapRoute(
                name: ProductItemResolver.ShopCategoryWithCatalogRouteName,
                url: "{catalog}/" + ProductItemResolver.ShopUrlRoute + "/{id}",
                defaults: new { id = UrlParameter.Optional, itemType = ProductItemResolver.CategoryItemType });

            routes.MapRoute(
                name: ProductItemResolver.ShopProductWithCatalogRouteName,
                url: "{catalog}/" + ProductItemResolver.ShopUrlRoute + "/{category}/{id}",
                defaults: new { id = UrlParameter.Optional, itemType = ProductItemResolver.ProductItemType });

            routes.MapRoute(
                name: ProductItemResolver.CategoryRouteName,
                url: ProductItemResolver.CategoryUrlRoute + "/{id}",
                defaults: new { id = UrlParameter.Optional, itemType = ProductItemResolver.CategoryItemType });

            routes.MapRoute(
                name: ProductItemResolver.ProductRouteName,
                url: ProductItemResolver.ProductUrlRoute + "/{id}",
                defaults: new { id = UrlParameter.Optional, itemType = ProductItemResolver.ProductItemType });

            routes.MapRoute(
                name: "ProductAction",
                url: ProductItemResolver.ProductUrlRoute + "/{action}/{id}",
                defaults: new { controller = "Catalog", id = UrlParameter.Optional, itemType = ProductItemResolver.ProductItemType });

            routes.MapRoute(
                name: ProductItemResolver.CategoryWithCatalogRouteName,
                url: "{catalog}/" + ProductItemResolver.CategoryUrlRoute + "/{id}",
                defaults: new { id = UrlParameter.Optional, itemType = ProductItemResolver.CategoryItemType });

            routes.MapRoute(
                name: ProductItemResolver.ProductWithCatalogRouteName,
                url: "{catalog}/" + ProductItemResolver.ProductUrlRoute + "/{id}",
                defaults: new { id = UrlParameter.Optional, itemType = ProductItemResolver.ProductItemType });

            routes.MapRoute(
                name: "catalogitem-all",
                url: ProductItemResolver.NavigationItemName + "/{*pathElements}",
                defaults: new { itemType = ProductItemResolver.CatalogItemType });

            routes.MapRoute(
                name: "logoff",
                url: "logoff",
                defaults: new { controller = "Account", action = "LogOff", storefront = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "GetAvailableStates",
                url: "checkout/GetAvailableStates",
                defaults: new { controller = "Checkout", action = "GetAvailableStates", id = UrlParameter.Optional });
        }
    }
}