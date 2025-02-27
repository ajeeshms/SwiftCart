using SwiftCart.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;

namespace SwiftCart {
    public partial class ProductDetails : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                LoadProductDetails();
            }
        }

        private void LoadProductDetails() {
            DataView dv = (DataView)ProductDataSource.Select(DataSourceSelectArguments.Empty);
            if (dv.Count > 0) {
                DataRow row = dv[0].Row;

                // Bind data to labels
                lblProductName.Text = row["Name"].ToString();
                lblProductNumber.Text = row["ProductNumber"].ToString();
                lblColor.Text = row["Color"] != DBNull.Value ? row["Color"].ToString() : "N/A";
                lblProductPrice.Text = row["ListPrice"] != DBNull.Value ? Convert.ToDecimal(row["ListPrice"]).ToString("N2") : "0.00";
                lblSize.Text = row["Size"] != DBNull.Value ? row["Size"].ToString() : "N/A";
                lblWeight.Text = row["Weight"] != DBNull.Value ? row["Weight"].ToString() : "N/A";

                // Load product image
                byte[] imageBytes = row["ThumbNailPhoto"] as byte[];
                if (imageBytes != null && imageBytes.Length > 0) {
                    string base64Image = Convert.ToBase64String(imageBytes);
                    imgProduct.ImageUrl = "data:image/png;base64," + base64Image;
                }
                else {
                    imgProduct.ImageUrl = "Images/NoImage.png"; // Default image
                }
            }
            else {
                // No data found
                lblProductName.Text = "Product Not Found";
                imgProduct.ImageUrl = "Images/NoImage.png";
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e) {
            int productId = Convert.ToInt32(Request.QueryString["ProductID"]);
            var cart = Session["Cart"] as List<CartItemModel> ?? new List<CartItemModel>();

            if (cart.Any(x => x.ID == productId)) {
                Response.Redirect("Cart.aspx");
                return;
            }

            cart.Add(new CartItemModel { ID = productId, Quantity = 1 });
            Session["Cart"] = cart;

            // Update cart count on page load
            ClientScript.RegisterStartupScript(this.GetType(), "updateCart", $"updateCartCount({cart.Count});", true);
            // Redirect to cart page
            Response.Redirect("Cart.aspx");
        }
    }
}