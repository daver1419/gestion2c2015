using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AerolineaFrba.Login;
using System.Data.SqlClient;
using AerolineaFrba.DTO;
using AerolineaFrba.Helpers;

namespace AerolineaFrba
{
    public partial class PantallaInicio : Form
    {
        #region Contructores
        public PantallaInicio()
        {
            InitializeComponent();
        }
        #endregion Constructores

        #region Atributos
        private bool LoguedIn
        {
            set
            {
                if (value)
                {

                    this.mostrarFuncionalidadesSegunPerfil();
                    this.labelIniciarSesion.Hide();
                    this.panelUsuario.Enabled = true;
                    this.panelUsuario.Show();
                }
                else
                {

                    labelIniciarSesion.Show();
                    this.panelUsuario.Enabled = false;
                    this.mostrarFuncionalidadesSegunPerfil();
                }

            }
        }
        #endregion Atributos

        #region Metodos
        private void mostrarFuncionalidadesSegunPerfil()
        {

            try
            {
                comboBoxRoles.DataSource = Sesion.Roles;
                this.listBoxFunc.DataSource = (comboBoxRoles.SelectedItem as RolDTO).ListaFunc;

            }
            catch (SqlException ex)
            {
                Utility.ShowError("Error base de datos.", ex);
                this.Close();
            }
        }
        #endregion Metodos

        #region Eventos
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void OpenSession_Click(object sender, EventArgs e)
        {
            try
            {
                if (new FormLogin() { Icon = this.Icon, StartPosition = FormStartPosition.CenterParent }.ShowDialog(this) == DialogResult.OK)
                    this.LoguedIn = true;

            }
            catch (SqlException ex)
            {
                Utility.ShowError("Error al iniciar sesion", ex);
            }
        }

        private void EndSession_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro de que desea salir?", "Cerrar sesion", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Sesion.Logout();
                this.LoguedIn = false;

            }
        }
        #endregion Eventos

        private void abrirFormularioSeleccionado()
        {


            if (listBoxFunc.SelectedIndex == -1 || !listBoxFunc.Enabled) return;

            try
            {
                switch (((FuncionalidadDTO)listBoxFunc.SelectedItem).toFuncionalidad())
                {
                    /*
                    case FuncionalidadDTO.Funcionalidad.ABM_CLIENTES:

                        new ABM_de_Cliente.FormCliente() { Icon = this.Icon, StartPosition = FormStartPosition.CenterParent }.ShowDialog(this);

                        break;
                    */
                    case FuncionalidadDTO.Funcionalidad.ABM_ROL:

                        new Abm_Rol.IndiceRol(){ Icon = this.Icon, StartPosition = FormStartPosition.CenterParent }.ShowDialog(this);

                        break;

                    case FuncionalidadDTO.Funcionalidad.ABM_CIUDAD:

                        new Abm_Ciudad.IndiceCiudad() { Icon = this.Icon, StartPosition = FormStartPosition.CenterScreen }.ShowDialog(this);

                        break;

                    case FuncionalidadDTO.Funcionalidad.ABM_RUTA_AEREA:

                        new Abm_Ruta.IndiceRuta() { Icon = this.Icon, StartPosition = FormStartPosition.CenterScreen }.ShowDialog(this);

                        break;

                    case FuncionalidadDTO.Funcionalidad.ABM_AERONAVE:


                        new Abm_Aeronave.IndiceAeronave() { Icon = this.Icon, StartPosition = FormStartPosition.CenterParent }.ShowDialog(this);

                        break;

                    case FuncionalidadDTO.Funcionalidad.GENERAR_VIAJE:

                        new Generacion_Viaje.GeneracionViaje() { Icon = this.Icon }.ShowDialog(this);

                        break;

                    case FuncionalidadDTO.Funcionalidad.CANCELAR_PASAJE_ENCOMIENDA:
                        new Devolucion.Form1(){ Icon = this.Icon, StartPosition = FormStartPosition.CenterParent }.ShowDialog(this);

                        break;

                    case FuncionalidadDTO.Funcionalidad.REGISTRO_LLEGADA_DESTINO:

                        new  Registro_Llegada_Destino.Form1() { Icon = this.Icon, StartPosition = FormStartPosition.CenterParent }.ShowDialog(this);

                        break;


                    case FuncionalidadDTO.Funcionalidad.COMPRA_PASAJE_ENCOMIENDA:

                        new Compra.Form1() { Icon = this.Icon, StartPosition = FormStartPosition.CenterParent }.ShowDialog(this);

                        break;

                    case FuncionalidadDTO.Funcionalidad.CONSULTA_MILLAS:

                        new Consulta_Millas.Form1() { Icon = this.Icon, StartPosition = FormStartPosition.CenterScreen }.ShowDialog(this);

                        break;

                    case FuncionalidadDTO.Funcionalidad.CANJE_MILLAS:

                        new Canje_Millas.Form1() { Icon = this.Icon, StartPosition = FormStartPosition.CenterScreen }.ShowDialog(this);

                        break;

                    case FuncionalidadDTO.Funcionalidad.LISTADO_ESTADISTICO:
                        new Listado_Estadistico.FormEstadisticas(){ Icon = this.Icon, StartPosition = FormStartPosition.CenterScreen }.ShowDialog(this);
                        break;
                }

            }
            catch (Exception e)
            {

                Utility.ShowError("Error", e);

            }


        }

        private void listBoxFunc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                abrirFormularioSeleccionado();
            }
        }

        private void PantallaInicio_Load(object sender, EventArgs e)
        {
            Sesion.StartAsClient();
            listBoxFunc.DataSource = Sesion.Rol.ListaFunc;
        }

        private void PantallaInicio_Closed(object sender, FormClosedEventArgs e)
        {
            Sesion.Reset_estado();
        }

        private void comboBoxRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxFunc.DataSource = (comboBoxRoles.SelectedItem as RolDTO).ListaFunc;
        }
    }
}
