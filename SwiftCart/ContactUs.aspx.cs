using System;
using System.Web.UI;

namespace SwiftCart {
    public partial class ContactUs : Page {
        protected void Page_Load(object sender, EventArgs e) {
        }

        protected void btnSubmit_Click(object sender, EventArgs e) {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string message = txtMessage.Text;

            // Here you can send an email or save to DB (mock response)
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Thank you, we will contact you soon!');", true);
        }
    }
}
