using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductManagementDataAccess;

namespace ProductManagementUI
{
    public partial class UserManager : Form
    {
        
        List<UserModel> userModels = new List<UserModel>();
        

        public UserManager()
        {
            var UserRepo = RepositoryFactory<UserModel, UserSearchParameter>.Create((int)RepositoryType.User);
            InitializeComponent();
           
            DeleteBtn.Enabled = false;
            EditBtn.Enabled = false;
            FirstNameBox.ReadOnly = true;
            LastNameBox.ReadOnly = true;
            PhoneNumberBox.ReadOnly = true;
            PasswordBox.ReadOnly = true;
            var source = new BindingSource(UserRepo.GetAll(), null);
            UsersDataGridView.DataSource = source;
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            var UserRepo = RepositoryFactory<UserModel, UserSearchParameter>.Create((int)RepositoryType.User);

            if(CreateBtn.Text == "Create") {
                SearchBtn.Enabled = false;
                SearchBox.ReadOnly = true;
                FirstNameBox.ReadOnly = false;
                LastNameBox.ReadOnly = false;
                PhoneNumberBox.ReadOnly = false;
                PasswordBox.ReadOnly = false;
                FirstNameBox.Text = "";
                LastNameBox.Text = "";
                PasswordBox.Text = "";
                PhoneNumberBox.Text = "";
                CreateBtn.Text = "Confirm";
                return;
            }
          
            UserModel u = new UserModel()
            {
                IsAdmin = AdminCheckBox.Checked,
                FirstName = FirstNameBox.Text,
                LastName = LastNameBox.Text,
                PhoneNumber = PhoneNumberBox.Text,
                Password = PasswordBox.Text
            };
            UserRepo.Create(u);
            CreateBtn.Text = "Create";
            SearchBtn.Enabled = true;
            SearchBox.ReadOnly = false;
            FirstNameBox.ReadOnly = true;
            LastNameBox.ReadOnly = true;
            PhoneNumberBox.ReadOnly = true;
            PasswordBox.ReadOnly = true;
            FirstNameBox.Text = "First Name";
            LastNameBox.Text = "Last Name";
            PasswordBox.Text = "Password";
            PhoneNumberBox.Text = "Phone Number";
            AdminCheckBox.Checked = false;
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            var UserRepo = RepositoryFactory<UserModel, UserSearchParameter>.Create((int)RepositoryType.User);
            switch (comboBox1.Text) {
                case "ID":
                    {
                        List<UserModel> SearchResults = new List<UserModel>(UserRepo.Search(new UserSearchParameter()
                        {
                            UserId = int.Parse(SearchBox.Text)
                        }));
                        var source = new BindingSource(SearchResults, null);
                        UsersDataGridView.DataSource = source;
                        break;
                    }
                case "Phone Number":
                    {
                        List<UserModel> SearchResults = new List<UserModel>(UserRepo.Search(new UserSearchParameter()
                        {
                            PhoneNumber = SearchBox.Text
                        }));
                        var source = new BindingSource(SearchResults, null);
                        UsersDataGridView.DataSource = source;
                        break;

                    }
                case "First Name":
                    {
                        List<UserModel> SearchResults = new List<UserModel>(UserRepo.Search(new UserSearchParameter()
                        {
                            FirstName = SearchBox.Text
                        }));
                        var source = new BindingSource(SearchResults, null);
                        UsersDataGridView.DataSource = source;
                        break;

                    }
                case "Last Name":
                    {
                        List<UserModel> SearchResults = new List<UserModel>(UserRepo.Search(new UserSearchParameter()
                        {
                            LastName = SearchBox.Text
                        }));
                        var source = new BindingSource(SearchResults, null);
                        UsersDataGridView.DataSource = source;
                        break;

                    }
            }
        
          
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
