<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="SwiftCart.ProductDetails" MasterPageFile="~/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <div class="row">
            <!-- Product Image Section -->
            <div class="col-md-5">
                <asp:Image ID="imgProduct" runat="server" CssClass="img-fluid rounded shadow" />
            </div>

            <!-- Product Information -->
            <div class="col-md-7">
                <h2 class="fw-bold">
                    <asp:Label ID="lblProductName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                </h2>
                <p class="text-muted">Product Number: <asp:Label ID="lblProductNumber" runat="server" Text='<%# Eval("ProductNumber") %>'></asp:Label></p>
                <p class="fw-bold text-primary h4">$<asp:Label ID="lblProductPrice" runat="server" Text='<%# Eval("ListPrice", "{0:N2}") %>'></asp:Label></p>

                <table class="table mt-3">
                    <tr>
                        <th>Color:</th>
                        <td><asp:Label ID="lblColor" runat="server" Text='<%# Eval("Color") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <th>Size:</th>
                        <td><asp:Label ID="lblSize" runat="server" Text='<%# Eval("Size") %>'></asp:Label></td>
                    </tr>
                    <tr>
                        <th>Weight:</th>
                        <td><asp:Label ID="lblWeight" runat="server" Text='<%# Eval("Weight") %>'></asp:Label> kg</td>
                    </tr>
                </table>

                <!-- Add to Cart Button -->
                <asp:Button ID="btnAddToCart" runat="server" CssClass="btn btn-success btn-lg mt-3" Text="Add to Cart" OnClick="btnAddToCart_Click" />
            </div>
        </div>
    </div>

    <!-- SqlDataSource Control -->
    <asp:SqlDataSource ID="ProductDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:AdventureWorksDB %>" 
        SelectCommand="SELECT Name, ProductNumber, Color, ListPrice, Size, Weight, ThumbNailPhoto FROM SalesLT.Product WHERE ProductID = @ProductID">
        <SelectParameters>
            <asp:QueryStringParameter Name="ProductID" QueryStringField="ProductID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
