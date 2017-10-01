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
    public partial class FrmUpdateUser : Form
    {
        private IUserBusiness userBusiness;
        public FrmUpdateUser()
        {
            userBusiness = new UserBusiness();
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string passwordAgain = txtPasswordAgain.Text;
            if (!password.Equals(passwordAgain))
            {
                MessageBox.Show("Contraseñas no coinciden!");
                return;
            }
            try
            {
                CreatedUser user = userBusiness.FindByUsername(username);
                if (user == null)
                {
                    MessageBox.Show($"Usuario {username} no existe");
                    return;
                }
                user = userBusiness.Update(new UpdatedUser()
                {
                    Id = user.Id,
                    Password = password
                });
                MessageBox.Show("Usuario actualizado!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.ToString()}");
            }
        }
    }
}
