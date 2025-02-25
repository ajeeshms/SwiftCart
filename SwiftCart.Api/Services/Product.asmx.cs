using SwiftCart.Data.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;

namespace SwiftCart.Api.Services {
    /// <summary>
    /// Summary description for Product
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Product : System.Web.Services.WebService {

        [WebMethod]
        public List<ProductModel> GetProducts(int page, int size) {
            var repo = new Data.Repository.ProductRepository();
            var products = repo.Get(page, size);
            var productModels = Global.MapperInstance.Map<List<ProductModel>>(products);
            return productModels;
        }
    }
}
