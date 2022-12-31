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
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var UserRepo = RepositoryFactory<UserModel, UserSearchParameter>.Create((int)RepositoryType.User);

            try
            {
                MainWindow M = new MainWindow(UserRepo.Search(new UserSearchParameter()
                {
                    FirstName = FullNameBox.Text.Substring(0, FullNameBox.Text.IndexOf(" ")).Trim(),
                    LastName = FullNameBox.Text.Substring(FullNameBox.Text.IndexOf(" ")).Trim(),
                    Password = PasswordBox.Text
                })[0]);
                this.Hide();
                M.ShowDialog();
            }catch(Exception ex)
            {
                var dialog = MessageBox.Show(ex.Message, "Error",
                                                               MessageBoxButtons.OK,
                                                               MessageBoxIcon.Warning);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var UserRepo = RepositoryFactory<UserModel, UserSearchParameter>.Create((int)RepositoryType.User);
            var created = new UserModel()
            {
                FirstName = "Guest",
                LastName = "Guest",
                PhoneNumber = "+xxxxxxxxxxx",
                Password = "xxxxxxx",
                UserId = 999,
                IsAdmin = false

            };
            MainWindow M = new MainWindow(created);
            this.Hide();
            M.ShowDialog();
        }
    }
}
