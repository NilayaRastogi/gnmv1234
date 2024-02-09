using Interview.Web.Models;
using Sparcpoint.SqlServer.Abstractions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Interview.Web.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ISqlExecutor _db;
        public ProductRepository(ISqlExecutor db)
        {
            _db = db;
        }

        public void Delete(Product product)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            
            Func<IDbConnection, IDbTransaction, IEnumerable<Product>> getProducts = (connection, transaction) =>
            {
                string query = "SELECT * FROM Product";
                using (var command = connection.CreateCommand())
                {
                    command.Transaction = transaction;
                    command.CommandText = query;
                    return (IEnumerable<Product>)command.ExecuteReader() ;
                }
            };

            return _db.Execute(getProducts);
            //throw new System.NotImplementedException();
        }
        public IEnumerable<Product> GetProductBySku(string sku)
        {

            Func<IDbConnection, IDbTransaction, IEnumerable<Product>> getProducts = (connection, transaction) =>
            {
                string query = "SELECT * FROM Product where ValidSkus = @ValidSkus";
                using (var command = connection.CreateCommand())
                {
                    command.Transaction = transaction;
                    command.CommandText = query;
                    command.Parameters.Add(new SqlParameter("@ValidSkus", SqlDbType.VarChar) { Value = sku });
                    return (IEnumerable<Product>)command.ExecuteReader();
                }
            };

            return _db.Execute(getProducts);
            //throw new System.NotImplementedException();
        }

        public Product GetById(int productId)
        {
            throw new System.NotImplementedException();
        }

        public int Insert(Product product)
        {
            Func<IDbConnection, IDbTransaction, int> createProducts = (connection, transaction) =>
            {
                using (var command = connection.CreateCommand())
                {
                    command.Transaction = transaction;
                    
                    command.CommandText = "INSERT INTO Product (Name, Description, ProductImageUris, ValidSkus) VALUES (@Value1, @Value2, @Value3, @Value4)";
                    command.Parameters.Add(new SqlParameter("@Value1", SqlDbType.VarChar) { Value = product.Name });
                    command.Parameters.Add(new SqlParameter("@Value2", SqlDbType.VarChar) { Value = product.Description });
                    command.Parameters.Add(new SqlParameter("@Value3", SqlDbType.VarChar) { Value = product.ProductImageUris});
                    command.Parameters.Add(new SqlParameter("@Value4", SqlDbType.VarChar) { Value = product.ValidSkus });

                    return command.ExecuteNonQuery();
                }
            };

            return _db.Execute(createProducts);
        }

        public void save()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}
