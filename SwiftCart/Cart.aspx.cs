﻿using SwiftCart.Data.Repository;
using SwiftCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SwiftCart {
    public partial class Cart : System.Web.UI.Page {

        private List<CartItemModel> cartItems;
        protected List<CartItemModel> CartItems {
            get {
                if (cartItems == default)
                    LoadCartItems();
                return cartItems;
            }
            set  {
                cartItems = value;
                Session["Cart"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (IsPostBack) {
                string action = Request.Form["action"];
                if (action == "update") {
                    int productId = int.Parse(Request.Form["productId"]);
                    int quantity = int.Parse(Request.Form["quantity"]);
                    UpdateCartQuantity(productId, quantity);
                }
                else if (action == "remove") {
                    int productId = int.Parse(Request.Form["productId"]);
                    RemoveFromCart(productId);
                }
                Response.End();
            }
            else {
                BindCart();
            }
        }

        private void BindCart() {
            CartRepeater.DataSource = CartItems;
            CartRepeater.DataBind();
        }

        private void UpdateCartQuantity(int productId, int quantity) {
            var cart = CartItems;
            var product = cart.Find(p => p.ID == productId);
            if (product != null) {
                product.Quantity = quantity;
                Session["Cart"] = cart;
            }
        }

        private void RemoveFromCart(int productId) {
            var cart = CartItems;
            cart.RemoveAll(p => p.ID == productId);
            Session["Cart"] = cart;
        }

        private void LoadCartItems() {
            var cart = Session["Cart"] as List<CartItemModel> ?? new List<CartItemModel>();
            ClientScript.RegisterStartupScript(this.GetType(), "updateCart", $"localStorage.setItem(\"cartCount\", {cart.Count})", true);

            var repo = new ProductRepository();
            var products = repo.Get(cart.Select(c=> c.ID).ToArray());
            var productModels = Global.MapperInstance.Map<List<ProductModel>>(products);
            this.cartItems = Global.MapperInstance.Map<List<CartItemModel>>(productModels);
            foreach (var item in cartItems) {
                item.Quantity = 1;
            }
            Session["Cart"] = this.cartItems;
        }
    }
}
