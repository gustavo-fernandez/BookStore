using BusinessLogicApi.Business;
using BusinessLogicApi.DTO;
using BusinessLogicImpl.BusinessImpl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class FrmLogin : Form
    {
        private IUserBusiness userBusiness;
        public FrmLogin()
        {
            userBusiness = new UserBusiness();
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            CreatedUser user = userBusiness.Login(username, password);
            if (user == null)
            {
                MessageBox.Show("Credenciales incorrectas");
            }
            else
            {
                MessageBox.Show($"Bienvenido {user.Username}!");
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            List<CreatedUser> list = userBusiness.FindAll();
        }
    }
}
