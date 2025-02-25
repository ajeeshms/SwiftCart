<%@ Page Title="Terms & Conditions" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Terms.aspx.cs" Inherits="SwiftCart.Terms" %>
<%@ Register Assembly="DevExpress.Web.v24.2, Version=24.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <dx:ASPxPanel ID="pnlTerms" runat="server" CssClass="card shadow-sm p-4">
            <PanelCollection>
                <dx:PanelContent>
                    <!-- Terms and Conditions -->
                    <dx:ASPxLabel ID="lblTitle" runat="server" Text="Terms & Conditions" CssClass="h3 fw-bold"></dx:ASPxLabel>
                    <hr />

                    <dx:ASPxLabel ID="lblTermsContent" runat="server" CssClass="text-muted" EncodeHtml="false" Text='
    Welcome to SwiftCart! Please read these Terms and Conditions carefully before using our website.<br /><br />
    • All transactions are subject to availability and confirmation of payment.<br />
    • Prices and product availability are subject to change without notice.<br />
    • Unauthorized use of this website may give rise to a claim for damages.<br />
    • All content is owned by SwiftCart. Reproduction is prohibited without permission.<br />
'></dx:ASPxLabel>


                    <!-- Frequently Asked Questions (FAQ) -->
                    <dx:ASPxLabel ID="lblFAQ" runat="server" Text="Frequently Asked Questions (FAQ)" CssClass="h4 fw-bold mt-4"></dx:ASPxLabel>
                    <hr />

                    <dx:ASPxCallbackPanel ID="faqPanel" runat="server" CssClass="mt-3">
                        <PanelCollection>
                            <dx:PanelContent>
                                <div class="accordion" id="faqAccordion">
                                    <div class="accordion-item">
                                        <h2 class="accordion-header" id="headingOne">
                                            <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne">
                                                How can I track my order?
                                            </button>
                                        </h2>
                                        <div id="collapseOne" class="accordion-collapse collapse" data-bs-parent="#faqAccordion">
                                            <div class="accordion-body">
                                                You can track your order by logging into your account and navigating to the "Order History" section.
                                            </div>
                                        </div>
                                    </div>

                                    <div class="accordion-item">
                                        <h2 class="accordion-header" id="headingTwo">
                                            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwo">
                                                What payment methods do you accept?
                                            </button>
                                        </h2>
                                        <div id="collapseTwo" class="accordion-collapse collapse" data-bs-parent="#faqAccordion">
                                            <div class="accordion-body">
                                                We accept credit/debit cards, PayPal, and other secure payment options.
                                            </div>
                                        </div>
                                    </div>

                                    <div class="accordion-item">
                                        <h2 class="accordion-header" id="headingThree">
                                            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseThree">
                                                Can I return a product?
                                            </button>
                                        </h2>
                                        <div id="collapseThree" class="accordion-collapse collapse" data-bs-parent="#faqAccordion">
                                            <div class="accordion-body">
                                                Yes, you can return products within 14 days of delivery. Please check our return policy for details.
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxCallbackPanel>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxPanel>
    </div>
</asp:Content>
