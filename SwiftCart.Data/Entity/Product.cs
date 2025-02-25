using System;

namespace SwiftCart.Data.Entity {

    [Serializable]
    public class Product {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }

        public decimal ListPrice { get; set; }

        public byte[] ThumbNailPhoto { get; set; }
    }
}
