using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediStock_Service
{
    public class Stock_Service_Imp: stock_service
    {
        public void AddOrders(Invoice_Order obj)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MediStock;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            string sql = "INSERT INTO Invoice_Orders (item_id, bill_no, no_of_packet, item_name, item_com_name) VALUES (@val1, @val2, @val3, @val4, @val5)";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@val1", obj.item_id);
            command.Parameters.AddWithValue("@val2", obj.bill_no);
            command.Parameters.AddWithValue("@val3", obj.no_of_packet);
            command.Parameters.AddWithValue("@val4", obj.item_name);
            command.Parameters.AddWithValue("@val5", obj.item_com_name);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();
        }


        public void AddStock(Stock obj)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MediStock;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string sql = "INSERT INTO Stock (name, price, company, exp_date, med_per_packet, available, storage_row, storage_col) VALUES (@val2, @val3, @val4, @val5, @val6, @val7, @val8, @val9)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@val2", obj.item_name);
                    command.Parameters.AddWithValue("@val3", obj.item_price);
                    command.Parameters.AddWithValue("@val4", obj.item_comp);
                    command.Parameters.AddWithValue("@val5", obj.item_exp);
                    command.Parameters.AddWithValue("@val6", obj.med_per_packate);
                    command.Parameters.AddWithValue("@val7", obj.item_available);
                    command.Parameters.AddWithValue("@val8", obj.storage_row);
                    command.Parameters.AddWithValue("@val9", obj.storage_col);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        Console.WriteLine("Item added successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }


        public void DeleteStock(int id)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MediStock;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            string sql = "DELETE FROM Stock WHERE Id = @id";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }


        public List<Stock> GetExpiredStock()
        {
            List<Stock> expiredStocks = new List<Stock>();
            DateTime crdate = DateTime.Today.Date;


            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MediStock;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                string sql = "SELECT * FROM Stock WHERE exp_date <= @cdate";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@cdate", crdate);
                    try
                    {
                        Console.WriteLine(crdate);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Stock expiredStock = new Stock
                                {
                                    item_id = Convert.ToInt32(reader["Id"]),
                                    item_name = Convert.ToString(reader["name"]),
                                    item_comp = Convert.ToString(reader["company"]),
                                    item_exp = Convert.ToDateTime(reader["exp_date"]),
                                    item_price = Convert.ToInt32(reader["price"]),
                                    item_available = Convert.ToInt32(reader["available"]),
                                    med_per_packate = Convert.ToInt32(reader["med_per_packet"]),
                                    storage_col = Convert.ToInt32(reader["storage_col"]),
                                    storage_row = Convert.ToInt32(reader["storage_row"])
                                };

                                Console.WriteLine(expiredStock);

                                expiredStocks.Add(expiredStock);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }

            return expiredStocks;
        }


        public List<Invoice> GetInvoiceofdDate(DateTime dt)
        {
            List<Invoice> invoices = new List<Invoice>();

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MediStock;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string sql = "SELECT * FROM Invoice WHERE date = @dt";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@dt", dt);

                DataTable dtResult = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dtResult);

                    foreach (DataRow row in dtResult.Rows)
                    {
                        Invoice invoice = new Invoice
                        {
                            bill_no = Convert.ToInt32(row["bill_no"]),
                            doc_name = Convert.ToString(row["doc_name"]),
                            date = Convert.ToDateTime(row["date"]),
                            contact = Convert.ToString(row["contact"]),
                            total_amount = Convert.ToInt32(row["total_amount"]),
                            customer_name = Convert.ToString(row["customer_name"])
                        };

                        invoices.Add(invoice);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return invoices;
        }


        public List<Stock> GetLessStock()
        {
            List<Stock> lessStocks = new List<Stock>();

            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MediStock;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                string sql = "SELECT * FROM Stock WHERE available <= 10";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "Stock");

                        foreach (DataRow row in dataSet.Tables["Stock"].Rows)
                        {
                            Stock lessStock = new Stock
                            {
                                item_id = Convert.ToInt32(row["Id"]),
                                item_name = Convert.ToString(row["name"]),
                                item_comp = Convert.ToString(row["company"]),
                                item_exp = Convert.ToDateTime(row["exp_date"]),
                                item_price = Convert.ToInt32(row["price"]),
                                item_available = Convert.ToInt32(row["available"]),
                                med_per_packate = Convert.ToInt32(row["med_per_packet"]),
                                storage_col = Convert.ToInt32(row["storage_col"]),
                                storage_row = Convert.ToInt32(row["storage_row"])
                            };

                            lessStocks.Add(lessStock);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }
            return lessStocks;
        }


        public List<Invoice_Order> GetOrder(int bill_no)
        {
            List<Invoice_Order> orders = new List<Invoice_Order>();

            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MediStock;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                string sql = "SELECT * FROM Invoice_Order WHERE bill_no = @bn";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@bn", bill_no);
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Invoice_Order order = new Invoice_Order
                                {
                                    id = Convert.ToInt32(reader["Id"]),
                                    bill_no = Convert.ToInt32(reader["bill_no"]),
                                    item_id = Convert.ToInt32(reader["item_id"]),
                                    item_name = Convert.ToString(reader["item_name"]),
                                    no_of_packet = Convert.ToInt32(reader["no_of_packet"]),
                                    item_com_name = Convert.ToString(reader["item_com_name"])
                                };

                                orders.Add(order);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }
            return orders;
        }

        public DataSet GetStock()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * from stock", @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MediStock;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"); 
            DataSet ds = new DataSet(); 
            adapter.Fill(ds, "stock"); 
            return ds;
        }

        public List<Stock> GetStockItem(string name, string com_name = null)
        {
            List<Stock> Stocks = new List<Stock>();
            Console.WriteLine("Hello first");
            Console.WriteLine(name);

            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MediStock;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                string sql=null;
                if (com_name == null)
                {
                    sql = "SELECT * FROM Stock WHERE name = @nm";
                }
                else if (com_name != null)
                {
                    sql = "SELECT * FROM Stock WHERE name = @nm AND company = @cm";
                }
                

                Console.WriteLine(name);

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@nm", name);
                    if (com_name != null) {
                        command.Parameters.AddWithValue("@cm", com_name);
                    }
                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet, "Stock");

                        foreach (DataRow row in dataSet.Tables["Stock"].Rows)
                        {
                            Stock lessStock = new Stock
                            {
                                item_id = Convert.ToInt32(row["Id"]),
                                item_name = Convert.ToString(row["name"]),
                                item_comp = Convert.ToString(row["company"]),
                                item_exp = Convert.ToDateTime(row["exp_date"]),
                                item_price = Convert.ToInt32(row["price"]),
                                item_available = Convert.ToInt32(row["available"]),
                                med_per_packate = Convert.ToInt32(row["med_per_packet"]),
                                storage_col = Convert.ToInt32(row["storage_col"]),
                                storage_row = Convert.ToInt32(row["storage_row"])
                            };

                            Stocks.Add(lessStock);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }
            return Stocks;
        }


        public List<Stock> GetUpcomingExpStock()
        {
            //List<Stock> expiredStocks = new List<Stock>();
            DateTime dt = DateTime.Today.Date;
            List<Stock> upcomingExpStocks = new List<Stock>();



            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MediStock;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                string sql = "SELECT * FROM Stock WHERE exp_date BETWEEN @startDate AND DATEADD(MONTH, 3, @startDate)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@startDate", dt);

                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Stock upcomingExpStock = new Stock
                                {
                                    item_id = Convert.ToInt32(reader["Id"]),
                                    item_name = Convert.ToString(reader["name"]),
                                    item_comp = Convert.ToString(reader["company"]),
                                    item_exp = Convert.ToDateTime(reader["exp_date"]),
                                    item_price = Convert.ToInt32(reader["price"]),
                                    item_available = Convert.ToInt32(reader["available"]),
                                    med_per_packate = Convert.ToInt32(reader["med_per_packet"]),
                                    storage_col = Convert.ToInt32(reader["storage_col"]),
                                    storage_row = Convert.ToInt32(reader["storage_row"])
                                };

                                upcomingExpStocks.Add(upcomingExpStock);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }
            return upcomingExpStocks;
        }


        public Invoice MakeInvoice(Invoice obj)
        {
            // Initialize the newInvoice object to return
            Invoice newInvoice = null;

            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MediStock;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                // Your SQL query to insert the invoice into the database
                string insertQuery = "INSERT INTO Invoice (date, doc_name, contact, total_amount, customer_name) VALUES (@val2, @val3, @val4, @val5, @val6)";

                // Create a SqlCommand object with the insert query and connection
                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@val2", obj.date);
                insertCommand.Parameters.AddWithValue("@val3", obj.doc_name);
                insertCommand.Parameters.AddWithValue("@val4", obj.contact);
                insertCommand.Parameters.AddWithValue("@val5", obj.total_amount);
                insertCommand.Parameters.AddWithValue("@val6", obj.customer_name);

                // Open the connection
                connection.Open();

                // Execute the insert command
                insertCommand.ExecuteNonQuery();

                // Your SQL query to fetch the newly added entry
                string selectQuery = "SELECT TOP 1 * FROM Invoice ORDER BY bill_no DESC"; // Assuming bill_no is an identity column

                // Create a SqlDataAdapter object with the select query and connection
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectQuery, connection);

                // Create a DataSet to hold the retrieved data
                DataSet dataSet = new DataSet();

                // Fill the DataSet with data from the database
                dataAdapter.Fill(dataSet);

                // Close the connection
                connection.Close();

                // Check if any rows were returned
                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    // Retrieve data from the first row
                    DataRow row = dataSet.Tables[0].Rows[0];

                    // Populate the newInvoice object with the retrieved data
                    newInvoice = new Invoice
                    {
                        bill_no = Convert.ToInt32(row["bill_no"]),
                        date = Convert.ToDateTime(row["date"]),
                        doc_name = Convert.ToString(row["doc_name"]),
                        contact = Convert.ToString(row["contact"]),
                        total_amount = Convert.ToInt32(row["total_amount"]),
                        customer_name = Convert.ToString(row["customer_name"])
                    };
                }
            }

            // Return the newly added Invoice object
            return newInvoice;
        }


        public Invoice SearchInvoice(string contact = null, int? bill_no = null)
        {
            Invoice foundInvoice = null;
            string sql = null;
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MediStock;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (bill_no == null)
                {
                    sql = "SELECT * FROM Invoice WHERE contact = @cn";
                }
                else if (bill_no != null)
                {
                    sql = "SELECT * FROM Invoice WHERE bill_no = @bl";
                }

                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                if (contact != null) {
                    adapter.SelectCommand.Parameters.AddWithValue("@cn", contact);
                }
                
                if (bill_no != null)
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@bl", bill_no);
                }

                DataTable dt = new DataTable();
                try
                {
                    connection.Open();
                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        foundInvoice = new Invoice
                        {
                            bill_no = Convert.ToInt32(row["bill_no"]),
                            doc_name = Convert.ToString(row["doc_name"]),
                            date = Convert.ToDateTime(row["date"]),
                            contact = Convert.ToString(row["contact"]),
                            total_amount = Convert.ToInt32(row["total_amount"]),
                            customer_name = Convert.ToString(row["customer_name"])
                        };
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            return foundInvoice;
        }


        public void UpdateStock(Stock obj)
        {
            Console.WriteLine("in update");
            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MediStock;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                string sql = @"UPDATE Stock 
                       SET 
                           name = @val2,
                           price = @val3,
                           company = @val4,
                           exp_date = @val5,
                           med_per_packet = @val6,
                           available = @val7,
                           storage_row = @val8,
                           storage_col = @val9
                       WHERE Id = @objid";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@objid", obj.item_id);
                    command.Parameters.AddWithValue("@val2", obj.item_name);
                    command.Parameters.AddWithValue("@val3", obj.item_price);
                    command.Parameters.AddWithValue("@val4", obj.item_comp);
                    command.Parameters.AddWithValue("@val5", obj.item_exp);
                    command.Parameters.AddWithValue("@val6", obj.med_per_packate);
                    command.Parameters.AddWithValue("@val7", obj.item_available);
                    command.Parameters.AddWithValue("@val8", obj.storage_row);
                    command.Parameters.AddWithValue("@val9", obj.storage_col);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
            }
        }
    }
}
