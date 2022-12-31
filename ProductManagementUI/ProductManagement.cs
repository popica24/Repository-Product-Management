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
    public partial class ProductManagement : Form
    {
        private int SelectedId;
        public List<string> Categories = new List<string>();
        public Dictionary<int, string> CategoryKeys = new Dictionary<int, string>();
        
        public ProductManagement()
        {
            InitializeComponent();
            var ProductRepo = RepositoryFactory<ProductModel, ProductSearchParameters>.Create((int)RepositoryType.Product);
            var CategoryRepo = RepositoryFactory<CategoryModel, CategorySearchParameters>.Create((int)RepositoryType.Category);
           
            foreach(var item in CategoryRepo.GetAll())
            {
                CategoryComboBox.Items.Add(item.CategoryName);
                CategoryKeys.Add(item.CategoryId, item.CategoryName);
            }

            var source = new BindingSource(ProductRepo.GetAll(), null);
            ProductDataGridView.DataSource = source;

            DeleteBtn.Enabled = false;
            EditBtn.Enabled = false;
            DescriptionBox.ReadOnly = true;
            PriceBox.ReadOnly = true;
        }

        private void CategoryComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            
            Categories.Add(CategoryComboBox.SelectedItem.ToString());
          
                CategoryList.Text += '\n'+ CategoryComboBox.SelectedItem.ToString() + '\n';
            
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            var ProductRepo = RepositoryFactory<ProductModel, ProductSearchParameters>.Create((int)RepositoryType.Product);
            var ProdCatRepo = RepositoryFactory<ProductCategoryModel, ProductCategorySearchParameters>.Create((int)RepositoryType.ProductCategory);
           
            if (CreateBtn.Text == "Create")
            {

                Categories.Clear();
                
                SearchBtn.Enabled = false;
                SearchBox.ReadOnly = true;
                DescriptionBox.ReadOnly = false;
                PriceBox.ReadOnly = false;
                DescriptionBox.Text = "";
                PriceBox.Text = "";
                CreateBtn.Text = "Confirm";
                return;
            }

            ProductModel P = new ProductModel()
            {
                Description = DescriptionBox.Text,
                Price = int.Parse(PriceBox.Text),
                DateManufactured = DateTime.Parse(DateManufacturedBox.Text)
            };
            var ProductId= ProductRepo.Create(P);

            foreach(var c in Categories)
            {
                var CategoryId = CategoryKeys.FirstOrDefault(x => x.Value == c).Key;
                ProdCatRepo.Create(new ProductCategoryModel()
                {
                    CategoryId = CategoryId,
                    ProductId = ProductId
                });
            }

            CreateBtn.Text = "Create";
            SearchBtn.Enabled = true;
            SearchBox.ReadOnly = false;
            DescriptionBox.ReadOnly = true;
            PriceBox.ReadOnly = true;
            CategoryList.Text = "";
            DescriptionBox.Text = "Description";
            PriceBox.Text = "Price";
      
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            var ProductRepo = RepositoryFactory<ProductModel, ProductSearchParameters>.Create((int)RepositoryType.Product);
         
            var ProdCatRepo = RepositoryFactory<ProductCategoryModel, ProductCategorySearchParameters>.Create((int)RepositoryType.ProductCategory);
            foreach (var P in ProdCatRepo.Search(new ProductCategorySearchParameters() { ProductId = SelectedId }))
            {
                ProdCatRepo.Delete(P);
            }
            foreach (var P in ProductRepo.Search(new ProductSearchParameters() { ProductId = SelectedId }))
            {
                ProductRepo.Delete(P);
            }

            DeleteBtn.Enabled = false;
            DescriptionBox.Text = "Description";
            PriceBox.Text = "Price";
            DateManufacturedBox.Text = DateTime.Now.ToString();
        }

        private void ProductDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow SelectedRow = ProductDataGridView.CurrentRow;
            if (!SelectedRow.IsNewRow)
            {
                DescriptionBox.Text = SelectedRow.Cells["Description"].Value.ToString();
                PriceBox.Text = SelectedRow.Cells["Price"].Value.ToString();
                DateManufacturedBox.Text = SelectedRow.Cells["DateManufactured"].Value.ToString();
                SelectedId = int.Parse(SelectedRow.Cells["ProductId"].Value.ToString());
                DeleteBtn.Enabled = true;
                

            }
        }
    }
}
