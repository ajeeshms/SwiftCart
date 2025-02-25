using System;

namespace SwiftCart {
    public partial class SiteMaster : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["UserName"] != null) {
                litUserName.Text = Session["UserName"].ToString();
            }
        }
    }
}
