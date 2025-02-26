<%@ Page Title="Cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="SwiftCart.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="mb-4">Shopping Cart</h2>
        
        <table class="table table-bordered">
            <thead class="thead-dark">
                <tr>
                    <th>Product</th>
                    <th>Price</th>
                    <th>Quantity</th>
                    <th>Total</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="CartRepeater" runat="server">
                    <ItemTemplate>
                        <tr data-id='<%# Eval("ID") %>'>
                            <td>
                                <img src='<%# Eval("ImageUrl") %>' class="img-thumbnail" style="width: 60px; height: 60px;">
                                <%# Eval("Name") %>
                            </td>
                            <td class="price">$<%# Eval("Price", "{0:N2}") %></td>
                            <td>
                                <input type="number" class="form-control qty-input" min="1" value='<%# Eval("Quantity") %>' 
                                    data-id='<%# Eval("ID") %>' data-price='<%# Eval("Price") %>' />
                            </td>
                            <td class="total-price">$<%# (Convert.ToDouble(Eval("Price")) * Convert.ToInt32(Eval("Quantity"))).ToString("N2") %></td>
                            <td>
                                <button class="btn btn-danger remove-item" data-id='<%# Eval("ID") %>'>
                                    <i class="fas fa-trash-alt"></i> Remove
                                </button>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>

        <div class="text-right">
            <h4>Total: <span id="cartTotal">$0.00</span></h4>
        </div>

        <button onclick="placeOrder(); return false;" class="btn btn-primary">Place Order</button>
    </div>

    <script>
        document.addEventListener("DOMContentLoaded", function () {
            updateCartTotal();

            // Handle quantity change
            document.querySelectorAll('.qty-input').forEach(input => {
                input.addEventListener('change', function () {
                    let productId = this.dataset.id;
                    let newQuantity = parseInt(this.value);
                    let price = parseFloat(this.dataset.price);

                    if (newQuantity < 1) {
                        this.value = 1;
                        newQuantity = 1;
                    }

                    let row = this.closest("tr");
                    row.querySelector(".total-price").innerText = "$" + (newQuantity * price).toFixed(2);

                    updateCartTotal();
                    updateSession(productId, newQuantity);
                });
            });

            // Handle item removal
            document.querySelectorAll(".remove-item").forEach(button => {
                button.addEventListener("click", function () {
                    let productId = this.dataset.id;
                    this.closest("tr").remove();
                    updateCartTotal();
                    removeFromSession(productId);
                });
            });

            function updateCartTotal() {
                let total = 0;
                document.querySelectorAll(".total-price").forEach(cell => {
                    total += parseFloat(cell.innerText.replace("$", "").replace(",", ""));
                });
                document.getElementById("cartTotal").innerText = "$" + total.toFixed(2);
            }

            function updateSession(productId, quantity) {
                fetch("Cart.aspx", {
                    method: "POST",
                    headers: { "Content-Type": "application/x-www-form-urlencoded" },
                    body: "action=update&productId=" + productId + "&quantity=" + quantity
                });
            }

            function removeFromSession(productId) {
                fetch("Cart.aspx", {
                    method: "POST",
                    headers: { "Content-Type": "application/x-www-form-urlencoded" },
                    body: "action=remove&productId=" + productId
                });
            }
        });

        function placeOrder() {
            alert('Order placed');
            window.location.href = '/invoice';
            return false;
        }
    </script>
</asp:Content>
