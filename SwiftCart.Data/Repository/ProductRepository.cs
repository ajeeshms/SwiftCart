using Microsoft.Practices.EnterpriseLibrary.Data;
using SwiftCart.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace SwiftCart.Data.Repository {
    public class ProductRepository {
        public IEnumerable<Product> Get(int page, int size) {

            try {
                Database db = DatabaseFactory.CreateDatabase("AdventureWorksDB");
                string query = @"SELECT ProductID AS Id, Name, ProductNumber, ListPrice, ThumbNailPhoto
FROM [SalesLT].[Product]
WHERE ThumbNailPhoto IS NOT NULL
ORDER BY NEWID()
OFFSET (@PageNumber - 1) * @PageSize ROWS
FETCH NEXT @PageSize ROWS ONLY;";

                List<Product> products = new List<Product>();

                using (DbCommand cmd = db.GetSqlStringCommand(query)) {

                    db.AddInParameter(cmd, "@PageNumber", DbType.Int32, page);
                    db.AddInParameter(cmd, "@PageSize", DbType.Int32, size);

                    using (IDataReader reader = db.ExecuteReader(cmd)) {
                        while (reader.Read()) {
                            products.Add(new Product {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                ProductNumber = reader["ProductNumber"].ToString(),
                                ListPrice = Convert.ToDecimal(reader["ListPrice"]),
                                ThumbNailPhoto = reader["ThumbNailPhoto"] as byte[]
                            });
                        }
                    }
                }

                return products;
            }
            catch (Exception ex) {
                // Log or handle error
                throw ex;
            }
        }

        public IEnumerable<Product> Get(params int[] productIds) {

            if(productIds.Count() == 0) {
                return new List<Product>();
            }

            try {
                Database db = DatabaseFactory.CreateDatabase("AdventureWorksDB");
                string query = "SELECT ProductID AS Id, Name, ProductNumber, ListPrice, ThumbNailPhoto " +
                              "FROM [SalesLT].[Product] WHERE ProductID IN (" + string.Join(",", productIds) + ")";


                List<Product> products = new List<Product>();

                using (DbCommand cmd = db.GetSqlStringCommand(query)) {

                    using (IDataReader reader = db.ExecuteReader(cmd)) {
                        while (reader.Read()) {
                            products.Add(new Product {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                ProductNumber = reader["ProductNumber"].ToString(),
                                ListPrice = Convert.ToDecimal(reader["ListPrice"]),
                                ThumbNailPhoto = reader["ThumbNailPhoto"] as byte[]
                            });
                        }
                    }
                }

                return products;
            }
            catch (Exception ex) {
                // Log or handle error
                throw ex;
            }
        }

        public bool Update(Product product) {
            using (var connection = new SqlConnection(Settings.ConnectionString)) {

                using (var command = connection.CreateCommand()) {

                    command.CommandText = "update SalesLT.Product set name = @name, @listprice = @listPrice where productid = @prodId";
                    command.Parameters.AddWithValue("@prodId", product.Id);
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@listPrice", product.ListPrice);

                    connection.Open();

                    try {
                        return command.ExecuteNonQuery() == 1;
                    }
                    catch {
                        return false;
                    }
                }
            }
        }
    }
}

