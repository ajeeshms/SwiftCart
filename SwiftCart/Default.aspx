<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SwiftCart.Default" %>

<%@ Register Assembly="DevExpress.Web.v24.2" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">
        <!-- Featured Product Slider using Ipsum.photos API -->
        <dx:ASPxImageSlider ID="FeaturedSlider" runat="server"
            Width="100%" Height="400px"
            SlideShow="True" SlideShowInterval="3000"
            ShowPager="True" EnablePaging="True">
        </dx:ASPxImageSlider>

    </div>

    <div class="container mt-4">
        <h2 class="text-center mb-4">Our Products</h2>

        <div class="row">
            <asp:Repeater ID="ProductRepeater" runat="server">
                <ItemTemplate>
                    <div class="col-md-3 mb-4">
                        <!-- 4 columns per row -->
                        <div class="card shadow-sm">
                            <img src='<%# Eval("ImageUrl") %>' class="card-img-top" alt="Product Image" style="height: 200px; object-fit: cover;">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Name") %></h5>
                                <p class="card-text text-muted"><%# Eval("Description") %></p>
                                <p class="fw-bold text-primary">$<%# Eval("Price", "{0:N2}") %></p>
                                <!-- Add to Cart Button -->
                                <asp:Button ID="btnAddToCart" runat="server" CssClass="btn btn-success w-100 mt-2"
                                    Text="Add to Cart" CommandArgument='<%# Eval("ID") %>'
                                    OnCommand="btnAddToCart_Command"
                                    OnClientClick="updateCartCount(); return true;"/>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="row">
            <div clas="col-md-12 text-center">
                <asp:HiddenField ID="hfPage" runat="server" Value="1" />
                <asp:Button ID="btnPrevious" runat="server" Text="Previous" CssClass="btn btn-secondary" OnClick="btnPrevious_Click" />
                <asp:Button ID="btnNext" runat="server" Text="Next" CssClass="btn btn-primary" OnClick="btnNext_Click" />
            </div>
        </div>
    </div>
    <style>
        .product-card {
            display: flex;
            flex-direction: column;
            align-items: center;
            border: 1px solid #ddd;
            padding: 10px;
            border-radius: 5px;
            box-shadow: 2px 2px 5px rgba(0,0,0,0.1);
            margin: 10px;
            max-width: 200px;
        }

        .product-image {
            width: 100%;
            height: 150px;
            object-fit: cover;
            border-radius: 5px;
        }

        .product-details {
            text-align: center;
            padding: 5px;
        }
    </style>

</asp:Content>
