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
    public partial class CategoryManager : Form
    {
        List<CategoryModel> CategoryModels = new List<CategoryModel>();
        public CategoryManager()
        {
            var CategoryRepo = RepositoryFactory<CategoryModel, CategorySearchParameters>.Create((int)RepositoryType.Category);
            InitializeComponent();
            CategoryModels = CategoryRepo.GetAll();
            DeleteBtn.Enabled = false;
            EditBtn.Enabled = false;
            CategoryNameBox.ReadOnly = true;
            var source = new BindingSource(CategoryModels, null);
            CategoryDataGridView.DataSource = source;
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            var CategoryRepo = RepositoryFactory<CategoryModel, CategorySearchParameters>.Create((int)RepositoryType.Category);

            if (CreateBtn.Text == "Create")
            {
                SearchBtn.Enabled = false;
                SearchBox.ReadOnly = true;
                CategoryNameBox.ReadOnly = false;
                CategoryNameBox.Text = "";
                CreateBtn.Text = "Confirm";
                return;
            }

            CategoryModel C = new CategoryModel()
            {
                CategoryName = CategoryNameBox.Text
            };
            CategoryRepo.Create(C);
            CreateBtn.Text = "Create";
            SearchBtn.Enabled = true;
            SearchBox.ReadOnly = false;
            CategoryNameBox.Text = "Category Name";
            CategoryNameBox.ReadOnly = true;

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {

        }

        private void EditBtn_Click(object sender, EventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            var CategoryRepo = RepositoryFactory<CategoryModel, CategorySearchParameters>.Create((int)RepositoryType.Category);
            switch (comboBox1.Text)
            {
                case "Category ID":
                    {
                        List<CategoryModel> SearchResults = new List<CategoryModel>(CategoryRepo.Search(new CategorySearchParameters()
                        {
                            CategoryId = int.Parse(SearchBox.Text)
                        }));
                        var source = new BindingSource(SearchResults, null);
                        CategoryDataGridView.DataSource = source;
                        break;
                    }
                case "Category Name":
                    {
                        List<CategoryModel> SearchResults = new List<CategoryModel>(CategoryRepo.Search(new CategorySearchParameters()
                        {
                            CategoryName = SearchBox.Text
                        }));
                        var source = new BindingSource(SearchResults, null);
                        CategoryDataGridView.DataSource = source;
                        break;
                    }

            }

        }
    }
}
