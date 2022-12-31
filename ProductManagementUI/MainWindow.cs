using ProductManagementDataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductManagementUI
{
    public partial class MainWindow : Form
    {
        public Dictionary<int, string> CategoryKeys = new Dictionary<int, string>();
        public int SelectedId;
        UserModel CurentUser;
        public MainWindow(UserModel U)
        {
            CurentUser = U;
         
            var ProductRepo = RepositoryFactory<ProductModel, ProductSearchParameters>.Create((int)RepositoryType.Product);
            var CategoryRepo = RepositoryFactory<CategoryModel, CategorySearchParameters>.Create((int)RepositoryType.Category);
           
            InitializeComponent();
            RatingPanel.Visible = false;
            RateBtn.Enabled = false;
            if(!CurentUser.IsAdmin)
            {
                AdminPanel.Visible = false;
                RatingPanel.Visible = true;
            }
            if (CurentUser.UserId == 999)
            {
                RatingPanel.Visible = false;
                CSVExportBtn.Visible = false;
                JSONExportBtn.Visible = false;

            }
            var source = new BindingSource(ProductRepo.GetAll(),null);
            ProductDataGridView.DataSource = source;
            foreach(var P in CategoryRepo.GetAll())
            {
                CategoryKeys.Add(P.CategoryId, P.CategoryName);
                CategoryComboBox.Items.Add(P.CategoryName);
            }
            
        }

        private void UserManagerBtn_Click(object sender, EventArgs e)
        {

            using(UserManager U = new UserManager())
            {
                U.ShowDialog();
            }
        }

        private void CategoryManagerBtn_Click(object sender, EventArgs e)
        {
            using (CategoryManager C = new CategoryManager())
            {
                C.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (ProductManagement P = new ProductManagement())
            {
                P.ShowDialog();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FlexibleSearchBtn.Text = "Search By Category";
        }

        private void FlexibleSearchBtn_Click(object sender, EventArgs e)
        {
            var ProductRepo = RepositoryFactory<ProductModel, ProductSearchParameters>.Create((int)RepositoryType.Product);

            switch (FlexibleSearchBtn.Text)
            {
                case "Search By Category":
                    var CategoryId = CategoryKeys.FirstOrDefault(x => x.Value == CategoryComboBox.SelectedItem.ToString()).Key;
                    var sourceByCategory = new BindingSource(ProductRepo.Search(new ProductSearchParameters
                    {
                        CategoryId = CategoryId
                    }), null);
                    ProductDataGridView.DataSource = sourceByCategory;
                    FlexibleSearchBtn.Text = "Reset Filter";
                    break;
                case "Search By Name":
                    var sourceByName = new BindingSource(ProductRepo.Search(new ProductSearchParameters
                    {
                        Description = NameBox.Text
                    }), null);
                    ProductDataGridView.DataSource = sourceByName;
                    FlexibleSearchBtn.Text = "Reset Filter";
                    break;
                case "Search By Price":
                    var sourceByPrice = new BindingSource(ProductRepo.Search(new ProductSearchParameters
                    {
                        BottomPrice = Convert.ToInt32(MinValue.Value),
                        TopPrice = Convert.ToInt32(HighValue.Value)
                    }), null) ;
                    ProductDataGridView.DataSource = sourceByPrice;
                    FlexibleSearchBtn.Text = "Reset Filter";
                    break;
                case "Search By Rating":
                    var sourceByRating = new BindingSource(ProductRepo.Search(new ProductSearchParameters()
                    {
                        Rating = RatingSearchBar.Value
                    }), null);
                    ProductDataGridView.DataSource = sourceByRating;
                    FlexibleSearchBtn.Text = "Reset Filter";
                    break;
                case "Reset Filter":
                    var defaultSource = new BindingSource(ProductRepo.GetAll(), null);
                    ProductDataGridView.DataSource = defaultSource;
                    FlexibleSearchBtn.Text = "";
                    break;
            }
        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {
            FlexibleSearchBtn.Text = "Search By Name";
        }

        private void MinValue_ValueChanged(object sender, EventArgs e)
        {
            FlexibleSearchBtn.Text = "Search By Price";
        }

        private void HighValue_ValueChanged(object sender, EventArgs e)
        {
            FlexibleSearchBtn.Text = "Search By Price";
        }

        private void ProductDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow SelectedRow = ProductDataGridView.CurrentRow;
            if (!SelectedRow.IsNewRow)
            {
               SelectedId = int.Parse(SelectedRow.Cells["ProductId"].Value.ToString());
            }
            RateBtn.Enabled = true;
        }

        private void RateBtn_Click(object sender, EventArgs e)
        {
            var RatingRepo = RepositoryFactory<RatingModel, RatingSearchParameters>.Create((int)RepositoryType.Rating);
            RatingRepo.Create(new RatingModel()
            {
                ProductId = SelectedId,
                UserId = CurentUser.UserId,
                Value = RatingBar.Value
            });
            RateBtn.Enabled = false;
        }

        private void CSVExportBtn_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            foreach(DataGridViewColumn col in ProductDataGridView.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach(DataGridViewRow row in ProductDataGridView.Rows)
            {
                DataRow dtRow = dt.NewRow();
                foreach(DataGridViewCell cell in row.Cells)
                {
                    dtRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dtRow);
            }

            /*StringBuilder result = new StringBuilder();
            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().Select(col => col.ColumnName);

            result.AppendLine(String.Join("\n", columnNames));
          
            foreach(DataRow Row in dt.Rows)
            {
                IEnumerable<string> values = Row.ItemArray.Select(value => value.ToString());
                result.AppendLine(String.Join("\n", values));
                
            }*/
            dt.WriteToCsvFile("Export.csv");
        }

        private void RatingSearchBar_ValueChanged(object sender, EventArgs e)
        {
            FlexibleSearchBtn.Text = "Search By Rating";
        }

        private void JSONExportBtn_Click(object sender, EventArgs e)
        {

        }
    }
    public static class DataTableExtensions
    {
        public static void WriteToCsvFile(this DataTable dataTable, string filePath)
        {
            StringBuilder fileContent = new StringBuilder();

            foreach (var col in dataTable.Columns)
            {
                fileContent.Append(col.ToString() + ",");
            }

            fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);

            foreach (DataRow dr in dataTable.Rows)
            {
                foreach (var column in dr.ItemArray)
                {
                    fileContent.Append("\"" + column.ToString() + "\",");
                }

                fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);
            }

            System.IO.File.WriteAllText(filePath, fileContent.ToString());
        }
    }
}
