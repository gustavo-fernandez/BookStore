using BusinessLogicApi.Business;
using BusinessLogicApi.DTO;
using BusinessLogicImpl.BusinessImpl;
using DataAccess.Context;
using DataAccess.Model;
using System;
using System.Windows.Forms;

namespace BookStoreApp
{
    public partial class FrmCreateUser : Form
    {
        private IUserBusiness userBusiness;

        public FrmCreateUser()
        {
            userBusiness = new UserBusiness();
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            try
            {
                CreatedUser createdUser = userBusiness.Create(new NewUser()
                {
                    Username = username,
                    Password = password
                });
                MessageBox.Show($"Usuario creado con Id: {createdUser.Id}");
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
