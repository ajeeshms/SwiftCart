//using SwiftCart.Data.Repository;
//using SwiftCart.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web.UI.WebControls;

//namespace SwiftCart {
//    public partial class Cart : System.Web.UI.Page {
//        protected void Page_Load(object sender, EventArgs e) {
//            if (!IsPostBack) {
//                LoadCart();
//            }
//        }

//        private void LoadCart() {
//            List<int> cart = Session["Cart"] as List<int> ?? new List<int>();
//            ClientScript.RegisterStartupScript(this.GetType(), "updateCart", $"localStorage.setItem(\"cartCount\", {cart.Count})", true);

//            var repo = new ProductRepository();
//            var products = repo.Get(cart.ToArray());
//            var productModels = Global.MapperInstance.Map<List<ProductModel>>(products);
//            var cartItems = Global.MapperInstance.Map<List<CartItemModel>>(productModels);

//            CartRepeater.DataSource = cartItems;
//            CartRepeater.DataBind();

//            //decimal total = cartItems.Sum(item=> item.Total);
//            //lblTotalPrice.Text = total.ToString("N2");
//        }

//        protected void btnRemove_Command(object sender, CommandEventArgs e) {
//            if (e.CommandArgument != null) {
//                int productId = Convert.ToInt32(e.CommandArgument);
//                List<CartItemModel> cart = Session["Cart"] as List<CartItemModel> ?? new List<CartItemModel>();

//                cart.RemoveAll(item => item.ID == productId);
//                Session["Cart"] = cart;

//                LoadCart();
//            }
//        }

//        protected void btnCheckout_Click(object sender, EventArgs e) {
//            // Implement checkout logic here
//            Response.Redirect("Checkout.aspx");
//        }
//    }

//}

using SwiftCart.Data.Repository;
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
