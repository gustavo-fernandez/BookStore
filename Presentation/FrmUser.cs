using DataAccess.Context;
using DataAccess.Model;
using System;
using System.Windows.Forms;

namespace BookStoreApp
{
    public partial class FrmUser : Form
    {
        public FrmUser()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            try
            {
                using (BookStoreContext context = new BookStoreContext())
                {
                    User newUser = context.Users.Add(new User()
                    {
                        Username = username,
                        Password = password,
                        CreatedDate = DateTime.Now
                    });
                    context.SaveChanges();
                    MessageBox.Show($"Usuario creado con Id: {newUser.Id}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.ToString()}");
            }
        }

        private void FrmUser_Load(object sender, EventArgs e)
        {
            
        }
    }
}
