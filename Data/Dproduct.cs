using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Dproduct
    {
        public List<Product> Get()
        {
            List<Product> productos = new List<Product>();

            try
            {
                using (SqlConnection connection = new SqlConnection(AccesoDatos.cadena))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT product_id, name, price, stock, active FROM products WHERE active = 1", connection);

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Product product = new Product
                        {
                            product_id = Convert.ToInt32(reader["product_id"]),
                            name = reader["name"].ToString(),
                            price = Convert.ToDouble(reader["price"]),
                            stock = Convert.ToInt32(reader["stock"]),
                            active = Convert.ToBoolean(reader["active"])
                        };

                        productos.Add(product);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones según sea necesario
                throw new Exception("Error al obtener productos: " + ex.Message);
            }

            return productos;
        }
    }
}