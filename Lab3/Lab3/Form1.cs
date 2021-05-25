using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        //This method is called when the save button in the navbar is pressed
        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e) {
            
            //Various try/catch statements for different errors that could occur
            try {
                this.Validate();
                this.productsBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.northwindDataSet);
            } catch(NoNullAllowedException ex) {
                MessageBox.Show("Error! " + ex.Message, "NULL value found");
            } catch(DBConcurrencyException ex) {
                MessageBox.Show("Error! " + ex.Message + " Please try again!");
            } catch(OverflowException ex) {
                MessageBox.Show("Error! " + ex.Message);
            } catch(SqlException ex) {
                MessageBox.Show("Error! " + ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'northwindDataSet.Order_Details' table. You can move, or remove it, as needed.
            this.order_DetailsTableAdapter.Fill(this.northwindDataSet.Order_Details);
            // TODO: This line of code loads data into the 'northwindDataSet.Categories' table. You can move, or remove it, as needed.
            this.categoriesTableAdapter.Fill(this.northwindDataSet.Categories);
            // TODO: This line of code loads data into the 'northwindDataSet.Suppliers' table. You can move, or remove it, as needed.
            this.suppliersTableAdapter.Fill(this.northwindDataSet.Suppliers);
            // TODO: This line of code loads data into the 'northwindDataSet.Products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.northwindDataSet.Products);
        }

        //Another try catch to see if the user types in a letter in UnitPrice text box
        private void unitPriceTextBox_TextChanged(object sender, EventArgs e) {
            try {
                if(unitPriceTextBox.Text != "") {
                    Convert.ToDecimal(unitPriceTextBox.Text);
                }
            } catch(FormatException ex) {
                MessageBox.Show(ex.Message);
                unitPriceTextBox.Text = "";
            }
        }
    }
}
