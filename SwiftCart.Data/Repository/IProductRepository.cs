using SwiftCart.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftCart.Data.Repository {
    public interface IProductRepository {
        IEnumerable<Product> Get(int page, int size);
        IEnumerable<Product> Get(params int[] productIds);
        bool Update(Product product);
    }
}
