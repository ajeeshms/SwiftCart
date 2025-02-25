<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="SwiftCart.ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2 class="text-center text-primary mb-4">Contact Us</h2>

        <div class="row">
            <!-- Contact Form -->
            <div class="col-md-6">
                <dx:ASPxPanel runat="server" CssClass="card shadow-sm p-4">
                    <PanelCollection>
                        <dx:PanelContent>
                            <div class="mb-3">
                                <dx:ASPxLabel runat="server" Text="Your Name:" CssClass="fw-bold" />
                                <dx:ASPxTextBox ID="txtName" runat="server" Width="100%"></dx:ASPxTextBox>
                                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                                    ErrorMessage="Name is required!" CssClass="text-danger" Display="Dynamic" />
                            </div>

                            <div class="mb-3">
                                <dx:ASPxLabel runat="server" Text="Your Email:" CssClass="fw-bold" />
                                <dx:ASPxTextBox ID="txtEmail" runat="server" Width="100%"></dx:ASPxTextBox>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                    ErrorMessage="Email is required!" CssClass="text-danger" Display="Dynamic" />
                            </div>

                            <div class="mb-3">
                                <dx:ASPxLabel runat="server" Text="Message:" CssClass="fw-bold" />
                                <dx:ASPxMemo ID="txtMessage" runat="server" Width="100%" Height="100px"></dx:ASPxMemo>
                                <asp:RequiredFieldValidator ID="rfvMessage" runat="server" ControlToValidate="txtMessage"
                                    ErrorMessage="Message is required!" CssClass="text-danger" Display="Dynamic" />
                            </div>

                            <dx:ASPxButton ID="btnSubmit" runat="server" Text="Send Message" CssClass="btn btn-primary w-100"
                                OnClick="btnSubmit_Click" />

                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </div>

            <!-- Contact Details & Map -->
            <div class="col-md-6">
                <dx:ASPxPanel runat="server" CssClass="card shadow-sm p-4">
                    <PanelCollection>
                        <dx:PanelContent>
                            <h5 class="text-primary">Our Office</h5>
                            <p>SwiftCart Pvt Ltd<br />123 E-Commerce Street, Tech City, TX 75001</p>

                            <h5 class="text-primary">Call Us</h5>
                            <p><i class="fas fa-phone-alt"></i> +1 (555) 123-4567</p>

                            <h5 class="text-primary">Email</h5>
                            <p><i class="fas fa-envelope"></i> support@swiftcart.com</p>

                            <h5 class="text-primary">Find Us</h5>
                            <iframe class="w-100 rounded" height="200"
                                src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3151.8354345095547!2d144.95373531550492!3d-37.81627974202144!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x6ad65d43f065fffd%3A0x2b3f1bba82d9e8b1!2sE-Commerce%20Plaza!5e0!3m2!1sen!2sus!4v1645786178547"
                                allowfullscreen="" loading="lazy"></iframe>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </div>
        </div>
    </div>
</asp:Content>
