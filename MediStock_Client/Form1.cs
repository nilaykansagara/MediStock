using MediStock_Client.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediStock_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            panel_update.Visible = false;
            panel_invoice_2.Visible = false;
            panel_invoice_1.Visible = false;
            panel_addStock.Visible = false;
            panel_total_rvn.Visible = false;
            panel_search_bill.Visible = false;
            panel_search.Visible = false;
            panel_revenue.Visible = false;
            panel_title.Visible = true;
            label5.Visible = true;
            panel1.Visible = true;
            panel2.Visible = false;
            item_name.Visible = false;
            label2.Visible = false;
            search.Visible = false;
            update_btn.Visible = false;
            dataGridView1.Visible = false;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            panel_addStock.Visible = false;
            panel_invoice_2.Visible = false;
            panel_invoice_1.Visible = false;
            panel_search.Visible = true;
            panel_total_rvn.Visible = false;
            panel_title.Visible = false;
            panel_update.Visible = false;
            panel_search_bill.Visible = false;
            update_btn.Visible = false;
            panel_revenue.Visible = false;
            //panel1.Visible = true;
            label5.Visible = false;
            item_name.Visible = !item_name.Visible; 
            label2.Visible = true;     // Toggle visibility
            search.Visible = true;   // Toggle visibility
            dataGridView1.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel_addStock.Visible = false;
            panel_invoice_2.Visible = false;
            panel_invoice_1.Visible = false;
            panel_update.Visible = false;
            panel_search.Visible = false;
            panel_title.Visible = false;
            panel_total_rvn.Visible = false;
            panel_search_bill.Visible = false;
            panel_revenue.Visible = false;
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            dataGridView1.Columns.Clear();
            MediStock_Client.ServiceReference1.stock_serviceClient proxy =
                new ServiceReference1.stock_serviceClient();
            item_name.Visible = false;
            label2.Visible = false;
            search.Visible = false;
            dataGridView1.Visible = false;
            update_btn.Visible = false;

            try
            {
                DataSet ds = proxy.GetStock();

                if (ds != null && ds.Tables.Contains("Stock") && ds.Tables["Stock"].Rows.Count > 0)
                {
                    dataGridView1.DataSource = ds.Tables["Stock"];
                    panel_update.Visible = false;
                    panel_revenue.Visible = false;
                    panel_invoice_2.Visible = false;
                    panel_invoice_1.Visible = false;
                    dataGridView1.Visible = true;
                    label5.Visible = false;
                    item_name.Visible = false;
                    label2.Visible = false;
                    search.Visible = false;
                    update_btn.Visible = false;
                    panel_search_bill.Visible = false;
                    panel_total_rvn.Visible = false;
                }
                else
                {
                    label5.Text = "No data available.";
                    panel_update.Visible = false;
                    panel_total_rvn.Visible = false;
                    panel_invoice_2.Visible = false;
                    panel_invoice_1.Visible = false;
                    panel_search_bill.Visible = false;
                    label5.Visible = true;
                    panel_revenue.Visible = false;
                    item_name.Visible = false;
                    label2.Visible = false;
                    panel_search_bill.Visible = false;
                    search.Visible = false;
                    dataGridView1.Visible = false;
                    update_btn.Visible = false;
                }
            }
            catch (Exception ex)
            {
                label5.Text = "An error occurred: " + ex.Message;
                label5.Visible = true;
                panel_invoice_2.Visible = false;
                panel_search_bill.Visible = false;
                panel_invoice_1.Visible = false;
                panel_search_bill.Visible = false;
                item_name.Visible = false;
                panel_total_rvn.Visible = false;
                panel_update.Visible = false;
                label2.Visible = false;
                search.Visible = false;
                dataGridView1.Visible = false;
                update_btn.Visible = false;
            }
            finally
            {
                proxy.Close();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //private void search_Click(object sender, EventArgs e)
        //{
        //    // Create an instance of the stock service client
        //    MediStock_Client.ServiceReference1.stock_serviceClient proxy =
        //        new ServiceReference1.stock_serviceClient();

        //    //proxy.Open();
        //    try
        //    {
        //        // Call the GetStockItem method of the service by passing the value from item_name.Text
        //        Stock[] stockArray = proxy.GetStockItem(item_name.Text);

        //        // Update the user interface with the fetched data
        //        if (stockArray != null && stockArray.Length > 0)
        //        {
        //            // Clear any existing items in the list view

        //            // Populate the list view with the fetched data
        //            foreach (var stock in stockArray)
        //            {
        //                ListViewItem item = new ListViewItem(stock.ToString()); 
        //                item.SubItems.Add(stock.item_available.ToString()); 
        //                //listView1.Items.Add(item);
        //                //dataGridView1.
        //            }
        //            label5.Visible = false;
        //            item_name.Visible = false;
        //            textBox2.Visible = false;
        //            textBox3.Visible = false;
        //            label2.Visible = false;
        //            label3.Visible = false;
        //            label4.Visible = false;
        //            search.Visible = false;
        //            dataGridView1.Visible = true;

        //        }
        //        else
        //        {
        //            // Handle case when no data is returned
        //            MessageBox.Show("No data found for the entered query.");
        //            label5.Visible = false;
        //            item_name.Visible = false;
        //            textBox2.Visible = false;
        //            textBox3.Visible = false;
        //            label2.Visible = false;
        //            label3.Visible = false;
        //            label4.Visible = false;
        //            search.Visible = false;
        //            dataGridView1.Visible = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exceptions
        //        MessageBox.Show("An error occurred: " + ex.Message);
        //        label5.Visible = false;
        //        item_name.Visible = false;
        //        textBox2.Visible = false;
        //        textBox3.Visible = false;
        //        label2.Visible = false;
        //        label3.Visible = false;
        //        label4.Visible = false;
        //        search.Visible = false;
        //        dataGridView1.Visible = true;
        //    }
        //    finally
        //    {
        //        // Always close the proxy after usage
        //        proxy.Close();
        //        label5.Visible = false;
        //        item_name.Visible = false;
        //        textBox2.Visible = false;
        //        textBox3.Visible = false;
        //        label2.Visible = false;
        //        label3.Visible = false;
        //        label4.Visible = false;
        //        search.Visible = false;
        //        dataGridView1.Visible = true;
        //    }
        //}

        private void search_Click(object sender, EventArgs e)
        {
            panel_addStock.Visible = false;
            panel_invoice_1.Visible = false;
            panel_update.Visible = false;
            panel_revenue.Visible = false;
            panel_invoice_2.Visible = false;
            panel_total_rvn.Visible = false;
            panel_search_bill.Visible = false;
            panel_search.Visible = true;
            label_sug_update.Visible = true;
            panel_search.Visible = true;
            panel_title.Visible = false;
            dataGridView1.DataSource = null;
            update_btn.Visible = false;
            panel_search_bill.Visible = false;

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            // Create an instance of the stock service client
            MediStock_Client.ServiceReference1.stock_serviceClient proxy =
                new ServiceReference1.stock_serviceClient();

            try
            {
                
                // Call the GetStockItem method of the service by passing the value from item_name.Text
                Stock[] stockArray = proxy.GetStockItem(item_name.Text,null);

                // Update the user interface with the fetched data
                if (stockArray != null && stockArray.Length > 0)
                {
                    // Clear any existing items in the data grid view
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();

                    // Add columns to the data grid view
                    dataGridView1.Columns.Add("Id", "Item ID");

                    DataGridViewTextBoxColumn expDateColumn = new DataGridViewTextBoxColumn();
                    expDateColumn.HeaderText = "Ttem Name";
                    expDateColumn.Name = "in"; // Assign a name to the column
                    dataGridView1.Columns.Add(expDateColumn);
                    dataGridView1.Columns["in"].DefaultCellStyle.BackColor = Color.LightGreen;

                    dataGridView1.Columns.Add("Company", "Company");
                    dataGridView1.Columns.Add("ExpDate", "Expiration Date");
                    dataGridView1.Columns.Add("Price", "Price");
                    dataGridView1.Columns.Add("Available", "Available");
                    dataGridView1.Columns.Add("MedPerPacket", "Med Per Packet");
                    dataGridView1.Columns.Add("StorageCol", "Storage Column");
                    dataGridView1.Columns.Add("StorageRow", "Storage Row");

                    // Populate the data grid view with the fetched data
                    foreach (var stock in stockArray)
                    {
                        dataGridView1.Rows.Add(stock.item_id, stock.item_name, stock.item_comp, stock.item_exp, stock.item_price, stock.item_available, stock.med_per_packate, stock.storage_col, stock.storage_row);
                    }
                    panel_search.Visible = false;
                    // Hide unnecessary UI elements
                    HideUIElements();
                }
                else
                {
                    // Handle case when no data is returned
                    MessageBox.Show("No data found for the entered query.");
                    HideUIElements();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show("An error occurred: " + ex.Message);
                HideUIElements();
            }
            finally
            {
                // Always close the proxy after usage
                proxy.Close();
            }
        }

        private void HideUIElements()
        {
            // Hide unnecessary UI elements
            label5.Visible = false;
            panel_invoice_1.Visible = false;
            item_name.Visible = false;
            panel_revenue.Visible = false;
            label2.Visible = false;
            search.Visible = false;
            panel_total_rvn.Visible = false;
            dataGridView1.Visible = true;
            panel_update.Visible = false;
            update_btn.Visible = false;
            panel_search_bill.Visible = false;
        }

        private void Show_Less_Stock_Click(object sender, EventArgs e)
        {
            panel_addStock.Visible = false;
            panel_invoice_2.Visible = false;
            panel_total_rvn.Visible = false;
            panel_revenue.Visible = false;
            panel_invoice_1.Visible = false;
            panel_search.Visible = false;
            panel_title.Visible = false;
            dataGridView1.DataSource = null;
            panel_update.Visible = false;
            update_btn.Visible = false;
            panel_search_bill.Visible = false;

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            MediStock_Client.ServiceReference1.stock_serviceClient proxy =
                new ServiceReference1.stock_serviceClient();

            try
            {
                Stock[] stockArray = proxy.GetLessStock();

                if (stockArray != null && stockArray.Length > 0)
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();

                    dataGridView1.Columns.Add("Id", "Item ID");
                    dataGridView1.Columns.Add("Name", "Item Name");
                    dataGridView1.Columns.Add("Company", "Company");
                    dataGridView1.Columns.Add("ExpDate", "Expiration Date");
                    dataGridView1.Columns.Add("Price", "Price");

                    DataGridViewTextBoxColumn expDateColumn = new DataGridViewTextBoxColumn();
                    expDateColumn.HeaderText = "Availbale";
                    expDateColumn.Name = "avl"; // Assign a name to the column
                    dataGridView1.Columns.Add(expDateColumn);

                    dataGridView1.Columns["avl"].DefaultCellStyle.BackColor = Color.LightSalmon;

                    dataGridView1.Columns.Add("MedPerPacket", "Med Per Packet");
                    dataGridView1.Columns.Add("StorageCol", "Storage Column");
                    dataGridView1.Columns.Add("StorageRow", "Storage Row");

                    foreach (var stock in stockArray)
                    {
                        dataGridView1.Rows.Add(stock.item_id, stock.item_name, stock.item_comp, stock.item_exp, stock.item_price, stock.item_available, stock.med_per_packate, stock.storage_col, stock.storage_row);
                    }

                    HideUIElements();
                }
                else
                {
                    MessageBox.Show("No data found for the entered query.");
                    HideUIElements();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                HideUIElements();
            }
            finally
            {
                proxy.Close();
            }
        }

        private void Expired_Click(object sender, EventArgs e)
        {
            panel_addStock.Visible = false;
            panel_invoice_1.Visible = false;
            panel_invoice_2.Visible = false;
            panel_update.Visible = false;
            panel_search.Visible = false;
            panel_title.Visible = false;
            panel_revenue.Visible = false;
            dataGridView1.DataSource = null;
            update_btn.Visible = false;
            panel_search_bill.Visible = false;
            panel_total_rvn.Visible = false;

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            MediStock_Client.ServiceReference1.stock_serviceClient proxy =
                new ServiceReference1.stock_serviceClient();

            try
            {
                Stock[] stockArray = proxy.GetExpiredStock();

                if (stockArray != null && stockArray.Length > 0)
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();

                    dataGridView1.Columns.Add("Id", "Item ID");
                    dataGridView1.Columns.Add("Name", "Item Name");
                    dataGridView1.Columns.Add("Company", "Company");

                    DataGridViewTextBoxColumn expDateColumn = new DataGridViewTextBoxColumn();
                    expDateColumn.HeaderText = "Expiration Date";
                    expDateColumn.Name = "ExpDate"; // Assign a name to the column
                    dataGridView1.Columns.Add(expDateColumn);

                    dataGridView1.Columns["ExpDate"].DefaultCellStyle.BackColor = Color.LightSalmon;

                    dataGridView1.Columns.Add("Price", "Price");
                    dataGridView1.Columns.Add("Available", "Available");
                    dataGridView1.Columns.Add("MedPerPacket", "Med Per Packet");
                    dataGridView1.Columns.Add("StorageCol", "Storage Column");
                    dataGridView1.Columns.Add("StorageRow", "Storage Row");

                    foreach (var stock in stockArray)
                    {
                        dataGridView1.Rows.Add(stock.item_id, stock.item_name, stock.item_comp, stock.item_exp, stock.item_price, stock.item_available, stock.med_per_packate, stock.storage_col, stock.storage_row);
                    }

                    HideUIElements();
                }
                else
                {
                    MessageBox.Show("No data found for the entered query.");
                    HideUIElements();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                HideUIElements();
            }
            finally
            {
                proxy.Close();
            }
        }

        private void About_to_Expire_Click(object sender, EventArgs e)
        {
            panel_addStock.Visible = false;
            panel_invoice_2.Visible = false;
            panel_invoice_1.Visible = false;panel_total_rvn.Visible = false;
            panel_update.Visible = false;
            panel_search.Visible = false;
            panel_title.Visible = false; 
            update_btn.Visible = false;
            panel_revenue.Visible = false;
            dataGridView1.DataSource = null;
            panel_search_bill.Visible = false;

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            MediStock_Client.ServiceReference1.stock_serviceClient proxy =
                new ServiceReference1.stock_serviceClient();

            try
            {
                Stock[] stockArray = proxy.GetUpcomingExpStock();

                if (stockArray != null && stockArray.Length > 0)
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Columns.Clear();

                    dataGridView1.Columns.Add("Id", "Item ID");
                    dataGridView1.Columns.Add("Name", "Item Name");
                    dataGridView1.Columns.Add("Company", "Company");

                    DataGridViewTextBoxColumn expDateColumn = new DataGridViewTextBoxColumn();
                    expDateColumn.HeaderText = "Expiration Date";
                    expDateColumn.Name = "ExpDate"; // Assign a name to the column
                    dataGridView1.Columns.Add(expDateColumn);

                    dataGridView1.Columns.Add("Price", "Price");
                    dataGridView1.Columns.Add("Available", "Available");
                    dataGridView1.Columns.Add("MedPerPacket", "Med Per Packet");
                    dataGridView1.Columns.Add("StorageCol", "Storage Column");
                    dataGridView1.Columns.Add("StorageRow", "Storage Row");
                    dataGridView1.Columns["ExpDate"].DefaultCellStyle.BackColor = Color.LightSalmon;
                    foreach (var stock in stockArray)
                    {

                        dataGridView1.Rows.Add(stock.item_id, stock.item_name, stock.item_comp, stock.item_exp, stock.item_price, stock.item_available, stock.med_per_packate, stock.storage_col, stock.storage_row);
                    }

                    HideUIElements();
                }
                else
                {
                    MessageBox.Show("No data found for the entered query.");
                    HideUIElements();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
                HideUIElements();
            }
            finally
            {
                proxy.Close();
            }
        }

        private void Add_item_Click(object sender, EventArgs e)
        {
            MediStock_Client.ServiceReference1.stock_serviceClient proxy =
                new ServiceReference1.stock_serviceClient();
            panel_addStock.Visible = false;
            panel_invoice_2.Visible = false;
            panel_update.Visible = false;
            panel_invoice_1.Visible = false;
            panel_total_rvn.Visible = false;
            panel_revenue.Visible = false;
            panel_search.Visible = false;
            panel_title.Visible = true;
            update_btn.Visible = false;
            label5.Visible = true;
            panel_search_bill.Visible = false;
            label5.Text = "Item Added";

            string productName = product_name.Text;
            int? productPrice = string.IsNullOrEmpty(product_price.Text) ? null : (int?)Convert.ToDecimal(product_price.Text);
            DateTime? productExpDate = string.IsNullOrEmpty(product_exp_date.Text) ? null : (DateTime?)DateTime.Parse(product_exp_date.Text);
            string productCompany = product_company.Text;
            int? availableProduct = string.IsNullOrEmpty(avl_product.Text) ? null : (int?)Convert.ToInt32(avl_product.Text);
            int? colProduct = string.IsNullOrEmpty(col_product.Text) ? null : (int?)Convert.ToInt32(col_product.Text);
            int? rowProduct = string.IsNullOrEmpty(row_product.Text) ? null : (int?)Convert.ToInt32(row_product.Text);
            int? medPerPacket = string.IsNullOrEmpty(med_per_pkt.Text) ? null : (int?)Convert.ToInt32(med_per_pkt.Text);

            // Create an object with the extracted values
            Stock item = new Stock
            {
                item_name = productName,
                item_price = productPrice,
                item_exp = productExpDate,
                item_comp = productCompany,
                item_available = availableProduct,
                storage_row = rowProduct,
                storage_col = colProduct,
                med_per_packate = medPerPacket
            };

            // Call the service method to add the item
            try
            {
                // Assuming you have a service client object named 'serviceClient'
                proxy.AddStock(item);
                label5.Visible = true;
                label5.Text = "Item Added";
            }
            catch (Exception ex)
            {
                // Handle exception
                MessageBox.Show("Error: " + ex.Message);
            }
            finally { 
                proxy.Close();
                product_price.Text = "";
                product_name.Text = "";
                product_exp_date.Text = "";
                avl_product.Text = "";
                col_product.Text = "";
                row_product.Text = "";
                med_per_pkt.Text = "";
                product_company.Text = "";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Analyse_stock_Click(object sender, EventArgs e)
        {
            label5.Visible = true;
            panel_update.Visible = false;
            panel_invoice_1.Visible = false;
            label5.Text = "Try Above Options to Analyse the stock...";
            panel1.Visible = true;
            panel2.Visible = true;
            panel_invoice_2.Visible = false;
            button2.Visible = true;
            button1.Visible = true;
            Expired.Visible = true;
            Show_Less_Stock.Visible = true;
            About_to_Expire.Visible = true;
            Add_Stock.Visible = false;
            Update_Stock.Visible = false;
            Search_Invoice.Visible = false;
            Revenue_Check.Visible = false;
            item_name.Visible = false;
            label2.Visible = false;
            search.Visible = false;
            dataGridView1.Visible = false;
            panel_addStock.Visible = false;
            panel_search.Visible = false;
            panel_total_rvn.Visible = false;
            panel_title.Visible = true;
            update_btn.Visible = false;
            panel_search_bill.Visible = false;
            panel_revenue.Visible = false;
        }

        private void Fill_Stock_Click(object sender, EventArgs e)
        {
            label5.Visible = true;
            panel_invoice_2.Visible = false;
            panel_update.Visible = false;
            panel_invoice_1.Visible = false;
            label5.Text = "Try Above Options to Fill the stock...";
            panel1.Visible = true;
            panel2.Visible = true;
            button2.Visible = false;
            button1.Visible = false;
            Expired.Visible = false;
            Show_Less_Stock.Visible = false;
            About_to_Expire.Visible = false;
            Add_Stock.Visible = true;
            Update_Stock.Visible = true;
            Search_Invoice.Visible = false;
            Revenue_Check.Visible = false;
            item_name.Visible = false;
            label2.Visible = false;
            search.Visible = false;
            dataGridView1.Visible = false;
            panel_addStock.Visible = false;
            panel_search.Visible = false;
            panel_title.Visible = true;
            update_btn.Visible = false;
            panel_total_rvn.Visible = false;
            panel_search_bill.Visible = false;
            panel_revenue.Visible = false;
        }

        private void Analyse_Invoice_Click(object sender, EventArgs e)
        {
            label5.Visible = true;
            panel_invoice_2.Visible = false;
            panel_invoice_1.Visible = false;
            panel_update.Visible = false;
            label5.Text = "Try Above Options to Analyse The Invoices...";
            panel1.Visible = true;
            panel2.Visible = true;
            button2.Visible = false;
            button1.Visible = false;
            Expired.Visible = false;
            Show_Less_Stock.Visible = false;
            About_to_Expire.Visible = false;
            Add_Stock.Visible = false;
            Update_Stock.Visible = false;
            Search_Invoice.Visible = true;
            Revenue_Check.Visible = true;
            item_name.Visible = false;
            label2.Visible = false;
            search.Visible = false;
            dataGridView1.Visible = false;
            panel_addStock.Visible = false;
            panel_search.Visible = false;
            panel_title.Visible = true;
            panel_total_rvn.Visible = false;
            update_btn.Visible = false;
            panel_search_bill.Visible = false;
            panel_revenue.Visible = false;
        }

        private void Generate_Invoice_Click(object sender, EventArgs e)
        {
            label5.Visible = true;
            panel_invoice_1.Visible = true;
            panel_update.Visible = false;
            label5.Text = "Try Above Options to Fill the stock...";
            panel1.Visible = true;
            panel2.Visible = false;
            button2.Visible = false;
            button1.Visible = false;
            Expired.Visible = false;
            Show_Less_Stock.Visible = false;
            About_to_Expire.Visible = false;
            Add_Stock.Visible = false;
            Update_Stock.Visible = false;
            Search_Invoice.Visible = false;
            panel_invoice_2.Visible = false;
            Revenue_Check.Visible = false;
            item_name.Visible = false;
            label2.Visible = false;
            search.Visible = false;
            panel_total_rvn.Visible = false;
            dataGridView1.Visible = false;
            panel_addStock.Visible = false;
            panel_search.Visible = false;
            panel_title.Visible = true;
            update_btn.Visible = false;
            panel_search_bill.Visible = false;
            go_bill_btn.Visible = false;
            panel_revenue.Visible = false;
        }

        private void Search_Invoice_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            panel_invoice_2.Visible = false;
            panel_invoice_1.Visible = false;
            panel_update.Visible = false;
            panel_addStock.Visible = false;
            panel_search.Visible = false;
            panel_title.Visible = false;
            update_btn.Visible = false;
            panel_total_rvn.Visible = false;
            panel_search_bill.Visible = true;
            panel_revenue.Visible = false;

        }


        private void Revenue_Check_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            panel_invoice_2.Visible = false;
            panel_invoice_1.Visible = false;
            panel_total_rvn.Visible = false;
            panel_update.Visible = false;
            panel_addStock.Visible = false;
            panel_search.Visible = false;
            panel_title.Visible = false;
            update_btn.Visible = false;
            panel_revenue.Visible = true;
            panel_search_bill.Visible = false;

        }

        private void Add_Stock_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            panel_invoice_2.Visible = false;
            panel_revenue.Visible = false;
            panel_invoice_1.Visible = false;
            update_btn.Visible = false;
            label5.Text = "Try Above Options to Analyse The invoice...";
            panel1.Visible = true;
            panel_update.Visible = false;
            panel2.Visible = true;
            panel3.Visible = true;
            button2.Visible = false;
            button1.Visible = false;
            Expired.Visible = false;
            Show_Less_Stock.Visible = false;
            About_to_Expire.Visible = false;
            Add_Stock.Visible = true;
            panel_total_rvn.Visible = false;
            Update_Stock.Visible = true;
            Search_Invoice.Visible = false;
            Revenue_Check.Visible = false;
            item_name.Visible = false;
            label2.Visible = false;
            search.Visible = false;
            dataGridView1.Visible = false;
            panel_addStock.Visible = true;
            panel_search.Visible = false;
            panel_title.Visible = false;
        }

        private void Update_Stock_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            panel_invoice_2.Visible = false;
            panel_total_rvn.Visible = false;
            panel_addStock.Visible = false;
            panel_invoice_1.Visible = false;
            panel_search.Visible = false;
            panel_update.Visible = true;
            panel_title.Visible = false;
            label_sug_update.Visible = true;
            panel_revenue.Visible = false;
            update_btn.Visible = false;
        }

        private void Company_Product_Click(object sender, EventArgs e)
        {
            panel_addStock.Visible = false;
            panel_invoice_1.Visible = false;
            update_btn.Visible = false;
            panel_revenue.Visible = false;
            panel_update.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            panel_addStock.Visible = false;
        }

        private void med_per_pkt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Search_update_Click(object sender, EventArgs e)
        {
            panel_addStock.Visible = false;
            panel_revenue.Visible = false;
            panel_invoice_2.Visible = false;
            panel_update.Visible = false;
            panel_search.Visible = false;
            panel_total_rvn.Visible = false;
            panel_invoice_1.Visible = false;
            panel_title.Visible = false;
            update_btn.Visible = true;

            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            // Create an instance of the stock service client
            MediStock_Client.ServiceReference1.stock_serviceClient proxy =
                new ServiceReference1.stock_serviceClient();
            proxy.Open();

            try
            {
                // Call the GetStockItem method of the service by passing the value from item_name.Text
                Stock[] stockArray = proxy.GetStockItem(text_update_serach.Text, text_com_name.Text);

                Console.WriteLine(stockArray);
                // Update the user interface with the fetched data
                if (stockArray != null && stockArray.Length > 0)
                {
                    // Add columns to the data grid view
                    dataGridView1.Columns.Add("ItemId", "Item ID");
                    dataGridView1.Columns.Add("ItemName", "Item Name"); // corrected column name
                    dataGridView1.Columns.Add("Company", "Company");
                    dataGridView1.Columns.Add("ExpDate", "Expiration Date");
                    dataGridView1.Columns.Add("Price", "Price");
                    dataGridView1.Columns.Add("Available", "Available");
                    dataGridView1.Columns.Add("MedPerPacket", "Med Per Packet");
                    dataGridView1.Columns.Add("StorageCol", "Storage Column");
                    dataGridView1.Columns.Add("StorageRow", "Storage Row");

                    // Populate the data grid view with the fetched data
                    foreach (var stock in stockArray)
                    {
                        // Add rows with editable cells
                        dataGridView1.Rows.Add(stock.item_id, stock.item_name, stock.item_comp, stock.item_exp, stock.item_price, stock.item_available, stock.med_per_packate, stock.storage_col, stock.storage_row);
                    }

                    // Make DataGridView cells editable except for the Id column
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        if (col.Name != "ItemId") // Ensure Id column is not editable
                            col.ReadOnly = false;
                        else
                            col.ReadOnly = true;
                    }

                    // Hide unnecessary UI elements
                    HideUIElements();
                    update_btn.Visible = true;
                }
                else
                {
                    // Handle case when no data is returned
                    MessageBox.Show("No data found for the entered query.");
                    HideUIElements();
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show("An error occurred: " + ex.Message);
                HideUIElements();
            }
            finally
            {
                // Always close the proxy after usage
                proxy.Close();
            }
        }








        private void label_sug_update_Click(object sender, EventArgs e)
        {

        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            // Get the updated data from DataGridView
            Stock updatedStock = new Stock();
            DataGridViewRow row = dataGridView1.CurrentRow;
            updatedStock.item_id = Convert.ToInt32(row.Cells["ItemId"].Value);
            updatedStock.item_name = row.Cells["ItemName"].Value.ToString();
            updatedStock.item_comp = row.Cells["Company"].Value.ToString();
            updatedStock.item_exp = Convert.ToDateTime(row.Cells["ExpDate"].Value);
            updatedStock.item_price = Convert.ToInt32(row.Cells["Price"].Value);
            updatedStock.item_available = Convert.ToInt32(row.Cells["Available"].Value);
            updatedStock.med_per_packate = Convert.ToInt32(row.Cells["MedPerPacket"].Value);
            updatedStock.storage_col = Convert.ToInt32(row.Cells["StorageCol"].Value);
            updatedStock.storage_row = Convert.ToInt32(row.Cells["StorageRow"].Value);

            // Call the backend method UpdateStock using the proxy
            MediStock_Client.ServiceReference1.stock_serviceClient proxy =
                new ServiceReference1.stock_serviceClient();
            proxy.Open();

            try
            {
                proxy.UpdateStock(updatedStock);
                MessageBox.Show("Stock updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the stock: " + ex.Message);
            }
            finally
            {
                // Close the proxy
                proxy.Close();
            }
        }

        List<Invoice_Order> ordersList = new List<Invoice_Order>();
        int bill_amount = 0;
        private void order_add_btn_Click(object sender, EventArgs e)
        {
            label5.Visible = true;
            panel_invoice_2.Visible = false;
            panel_invoice_1.Visible = true;
            panel_update.Visible = false;
            label5.Text = "Try Above Options to Fill the stock...";
            panel1.Visible = true;
            panel2.Visible = false;
            button2.Visible = false;
            button1.Visible = false;
            Expired.Visible = false;
            panel_revenue.Visible = false;
            Show_Less_Stock.Visible = false;
            About_to_Expire.Visible = false;
            panel_total_rvn.Visible = false;
            Add_Stock.Visible = false;
            Update_Stock.Visible = false;
            Search_Invoice.Visible = false;
            Revenue_Check.Visible = false;
            item_name.Visible = false;
            label2.Visible = false;
            search.Visible = false;
            dataGridView1.Visible = false;
            panel_addStock.Visible = false;
            panel_search.Visible = false;
            panel_title.Visible = true;
            update_btn.Visible = false;
            
            // Create a new Invoice_Order object
            Invoice_Order newOrder = new Invoice_Order();

            // Populate its properties with values from text boxes
            newOrder.item_name = text_pur_name.Text;
            newOrder.item_com_name = text_pur_com_name.Text;
            // Ensure no_of_packet is parsed correctly from text_pur_qnt TextBox
            if (int.TryParse(text_pur_qnt.Text, out int noOfPackets))
            {
                newOrder.no_of_packet = noOfPackets;
            }
            else
            {
                // Handle parsing error, if any
                MessageBox.Show("Invalid value for number of packets.");
                return; // Exit method if parsing fails
            }
            MediStock_Client.ServiceReference1.stock_serviceClient proxy =
                new ServiceReference1.stock_serviceClient();
            Stock[] stocks = proxy.GetStockItem(newOrder.item_name, newOrder.item_com_name);
            if (stocks.Length==0) {
                MessageBox.Show("Give correct Comapny name Or item name");
            }
            else if (stocks[0].item_available >= newOrder.no_of_packet)
            {
                ordersList.Add(newOrder);
            }
            else {
                MessageBox.Show("Not have sufficient stock for Item " + newOrder.item_name + " Only " + stocks[0].item_available + " packets are available.");
            }
            if (ordersList.Count != 0)
            {
                go_bill_btn.Visible = true;
            }

            // Clear text boxes
            text_pur_name.Clear();
            text_pur_com_name.Clear();
            text_pur_qnt.Clear();
        }

        private void go_bill_btn_Click(object sender, EventArgs e)
        {
            label5.Visible = true;
            panel_invoice_1.Visible = false;
            panel_invoice_2.Visible = true;
            panel_update.Visible = false;
            label5.Text = "Try Above Options to Fill the stock...";
            panel1.Visible = true;
            panel2.Visible = false;
            button2.Visible = false;
            button1.Visible = false;
            Expired.Visible = false;
            panel_revenue.Visible = false;
            panel_total_rvn.Visible = false;
            Show_Less_Stock.Visible = false;
            About_to_Expire.Visible = false;
            Add_Stock.Visible = false;
            Update_Stock.Visible = false;
            Search_Invoice.Visible = false;
            Revenue_Check.Visible = false;
            item_name.Visible = false;
            label2.Visible = false;
            search.Visible = false;
            dataGridView1.Visible = false;
            panel_addStock.Visible = false;
            panel_search.Visible = false;
            panel_title.Visible = true;
            update_btn.Visible = false;
            int totalBillAmount = 0;

            // Create an instance of the stock service client proxy
            MediStock_Client.ServiceReference1.stock_serviceClient proxy =
                new ServiceReference1.stock_serviceClient();


            foreach (var order in ordersList)
            {
                // Call the GetStockItem method to retrieve stock information
                Stock[] stocks = proxy.GetStockItem(order.item_name, order.item_com_name);

                // Calculate the total price for this item
                int itemTotalPrice = 0;
                foreach (var stock in stocks)
                {
                    int itemPrice = stock.item_price ?? 0; // If stock.item_price is null, use 0
                    int noOfPacket = order.no_of_packet ?? 0;
                    // Assuming you have a property named item_price in the Stock class
                    itemTotalPrice += itemPrice * noOfPacket;
                }

                // Add the item's total price to the total bill amount
                totalBillAmount += itemTotalPrice;
            }
            bill_amount = totalBillAmount;
            // Close the proxy after usage
            proxy.Close();

            // Display or use the total bill amount as needed
            MessageBox.Show("Total Bill Amount: " + totalBillAmount.ToString("C"));
        }

        private void add_bill_btn_Click(object sender, EventArgs e)
        {
            // Create a new Invoice object
            Invoice newInvoice = new Invoice();
            Invoice addedInvoice = new Invoice();

            newInvoice.date = DateTime.Now;
            newInvoice.doc_name = text_doc_name.Text;
            newInvoice.contact = text_contact.Text;

            newInvoice.total_amount = bill_amount;

            newInvoice.customer_name = text_cus_name.Text;

            // Create a proxy instance
            MediStock_Client.ServiceReference1.stock_serviceClient proxy =
                new ServiceReference1.stock_serviceClient();

            try
            {
                // Call a method on the proxy to save the invoice and get the added invoice
                addedInvoice = proxy.MakeInvoice(newInvoice);

                // Optionally, show a success message or perform any additional actions
                MessageBox.Show("Invoice saved successfully.");

                // Iterate through the order lists and add orders for each order list object
                foreach (var order in ordersList)
                {
                    // Call the AddOrders method for each order object
                    Invoice_Order invoiceOrder = new Invoice_Order();
                    invoiceOrder.bill_no = addedInvoice.bill_no;
                    invoiceOrder.item_name = order.item_name;
                    invoiceOrder.item_com_name = order.item_com_name;
                    invoiceOrder.no_of_packet = order.no_of_packet;

                    Stock[] stockArray = proxy.GetStockItem(order.item_name, order.item_com_name);

                    stockArray[0].item_available = stockArray[0].item_available - order.no_of_packet;
                    proxy.UpdateStock(stockArray[0]);
                    invoiceOrder.item_id = stockArray[0].item_id;
                    // Call the AddOrders method using the proxy
                    proxy.AddOrders(invoiceOrder);

                    // Optionally, show a success message or perform any additional actions
                    MessageBox.Show("Order added successfully for item: " + order.item_name);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, such as displaying an error message
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Close the proxy after usage
                ordersList = new List<Invoice_Order>();
                bill_amount = 0;
                proxy.Close();
                panel_invoice_1.Visible = true;
                panel_invoice_2.Visible = false;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void search_bill_btn_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            panel_invoice_1.Visible = false;
            panel_invoice_2.Visible = false;
            panel_update.Visible = false;
            panel1.Visible = true;
            panel2.Visible = true;
            button2.Visible = false;
            button1.Visible = false;
            Expired.Visible = false;
            Show_Less_Stock.Visible = false;
            About_to_Expire.Visible = false;
            Add_Stock.Visible = false;
            Update_Stock.Visible = false;
            Search_Invoice.Visible = true;
            Revenue_Check.Visible = true;
            item_name.Visible = false;
            label2.Visible = false;
            search.Visible = false;
            dataGridView1.Visible = false;
            panel_addStock.Visible = false;
            panel_search.Visible = false;
            panel_title.Visible = false;
            update_btn.Visible = false;
            panel_revenue.Visible = false;
            dataGridView1.Visible = true;
            panel_search_bill.Visible = false;
            panel_total_rvn.Visible = false;
            MediStock_Client.ServiceReference1.stock_serviceClient proxy =
                new ServiceReference1.stock_serviceClient();
            // Extract the bill number from the text box
            string billNoText = text_bill_no.Text;
            int? billNo = null;
            if (!string.IsNullOrEmpty(billNoText))
            {
                // Parse the bill number if provided
                if (int.TryParse(billNoText, out int parsedBillNo))
                {
                    billNo = parsedBillNo;
                }
                else
                {
                    MessageBox.Show("Invalid bill number. Please enter a valid integer value.");
                    return;
                }
            }

            // Call the SearchInvoice method to retrieve the invoice
            Invoice foundInvoice = proxy.SearchInvoice(null, billNo);

            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            // Add columns to dataGridView1
            dataGridView1.Columns.Add("bill_no", "Bill No");
            dataGridView1.Columns.Add("customer_name", "Customer Name");
            dataGridView1.Columns.Add("total_amount", "Total Amount");
            dataGridView1.Columns.Add("contact", "Contact");
            dataGridView1.Columns.Add("date", "Date");
            dataGridView1.Columns.Add("doc_name", "Doc Name");
            
      
            
            

            // Display the result in dataGridView1
            if (foundInvoice != null)
            {
                // Clear existing data in dataGridView1
                dataGridView1.Rows.Clear();

                // Add the found invoice data to dataGridView1
                dataGridView1.Rows.Add(
                    foundInvoice.bill_no,
                    foundInvoice.customer_name,
                    foundInvoice.total_amount,
                    foundInvoice.contact,
                    foundInvoice.date,
                    foundInvoice.doc_name
                );
                
            }
            else
            {
                MessageBox.Show("Invoice not found.");
            }
        }

        private void rvn_btn_Click(object sender, EventArgs e)
        {
            label5.Visible = false;
            panel_invoice_1.Visible = false;
            panel_invoice_2.Visible = false;
            panel_update.Visible = false;
            panel1.Visible = true;
            panel2.Visible = true;
            button2.Visible = false;
            button1.Visible = false;
            Expired.Visible = false;
            Show_Less_Stock.Visible = false;
            About_to_Expire.Visible = false;
            Add_Stock.Visible = false;
            Update_Stock.Visible = false;
            Search_Invoice.Visible = true;
            Revenue_Check.Visible = true;
            item_name.Visible = false;
            label2.Visible = false;
            search.Visible = false;
            dataGridView1.Visible = false;
            panel_addStock.Visible = false;
            panel_search.Visible = false;
            panel_title.Visible = false;
            update_btn.Visible = false;
            dataGridView1.Visible = true;
            panel_search_bill.Visible = false;
            panel_total_rvn.Visible = true;
            panel_revenue.Visible = false;
            dataGridView1.Visible = true;

            // Parse the date from the text box
            if (!DateTime.TryParseExact(text_date_rvn.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime selectedDate))
            {
                MessageBox.Show("Please enter a valid date in the format yyyy-MM-dd.");
                return;
            }



            MediStock_Client.ServiceReference1.stock_serviceClient proxy =
                new ServiceReference1.stock_serviceClient();

            // Call the GetInvoiceofdDate method to retrieve invoices for the selected date
            Invoice[] invoices = proxy.GetInvoiceofdDate(selectedDate);

            // Clear existing columns in dataGridView1
            dataGridView1.Columns.Clear();

            // Add columns to dataGridView1 in the desired order
            dataGridView1.Columns.Add("bill_no", "Bill No");
            dataGridView1.Columns.Add("customer_name", "Customer Name");
            dataGridView1.Columns.Add("total_amount", "Total Amount");
            dataGridView1.Columns.Add("contact", "Contact");
            dataGridView1.Columns.Add("date", "Date");
            dataGridView1.Columns.Add("doc_name", "Doc Name");

            // Set the total_amount column to display in green
            dataGridView1.Columns["total_amount"].DefaultCellStyle.BackColor = Color.Green;

            // Clear existing rows in dataGridView1
            dataGridView1.Rows.Clear();

            int total = 0;
            // Add rows to dataGridView1 from the invoices list
            foreach (var invoice in invoices)
            {
                dataGridView1.Rows.Add(
                    invoice.bill_no,
                    invoice.customer_name,
                    invoice.total_amount,
                    invoice.contact,
                    invoice.date,
                    invoice.doc_name
                );
                total = total + invoice.total_amount ?? 0;
            }

            // Calculate the total of all total_amount values


            // Display the total below dataGridView1
            label12.Text = "Total Revenue of Date " + text_date_rvn.Text + " is: " + total.ToString();
        }
    }
}
