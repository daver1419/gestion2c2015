using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Helpers;

namespace AerolineaFrba.Login
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            txtPassword.KeyDown += new KeyEventHandler(txtPass_KeyDown);
        }

        void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) btnIngresar.PerformClick();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                Sesion.Login(txtUsername.Text, txtPassword.Text);
                Utility.ShowInfo("Login", "Logueado exitosamente");
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (ApplicationException ex)
            {
                Utility.ShowError("Error", ex);
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
