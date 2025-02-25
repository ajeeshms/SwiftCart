using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;
using DevExpress.Web;
using SwiftCart.Models;

namespace SwiftCart {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                LoadFeaturedImages();
                LoadProducts(1, 20);
                LoadCart();
            }
        }

        private void LoadFeaturedImages() {
            FeaturedSlider.Items.Clear(); // Clear existing items

            for (int i = 0; i < 5; i++) // 5 featured products
            {
                ImageSliderItem item = new ImageSliderItem();
                item.ImageUrl = $"https://picsum.photos/800/400?random={i}";
                item.Text = $"<div class='slider-overlay'><h3>Featured Product {i + 1}</h3><p>High-quality, best-selling item!</p></div>";

                FeaturedSlider.Items.Add(item);
            }
        }



        private void LoadProducts(int page, int size) {

            var repo = new Data.Repository.ProductRepository();
            var products = repo.Get(page, size);
            var productModels = Global.MapperInstance.Map<List<ProductModel>>(products);

            ProductRepeater.DataSource = productModels;
            ProductRepeater.DataBind();
        }

        protected void btnNext_Click(object sender, EventArgs e) {
            int currentPage = Convert.ToInt32(hfPage.Value);
            int nextPage = currentPage + 1;

            hfPage.Value = nextPage.ToString();
            LoadProducts(nextPage, 5);
        }

        protected void btnPrevious_Click(object sender, EventArgs e) {
            int currentPage = Convert.ToInt32(hfPage.Value);
            int prevPage = Math.Max(1, currentPage - 1);

            hfPage.Value = prevPage.ToString();
            LoadProducts(prevPage, 5);
        }

        protected void btnAddToCart_Command(object sender, CommandEventArgs e) {
            if (e.CommandArgument != null) {
                int productId = Convert.ToInt32(e.CommandArgument);
                AddToCart(productId);
            }
        }

        private void AddToCart(int productId) {
            var cart = Session["Cart"] as List<CartItemModel> ?? new List<CartItemModel>();
            
            if (cart.Any(x => x.ID == productId))
                return;

            cart.Add(new CartItemModel { ID = productId, Quantity = 1 });
            Session["Cart"] = cart;

            // Update cart count on page load
            ClientScript.RegisterStartupScript(this.GetType(), "updateCart", $"updateCartCount({cart.Count});", true);
        }

        private void LoadCart() {
            var cart = Session["Cart"] as List<CartItemModel> ?? new List<CartItemModel>();
            ClientScript.RegisterStartupScript(this.GetType(), "updateCart", $"localStorage.setItem(\"cartCount\", {cart.Count})", true);
        }
    }
}
