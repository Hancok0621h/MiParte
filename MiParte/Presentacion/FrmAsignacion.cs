using MiParte.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiParte
{
    public partial class tbl_Asignacion : Form
    {
        
        CDasignaciones cd_asignaciones = new CDasignaciones();
        CLasignacion cl_asignacion = new CLasignacion();
        public tbl_Asignacion()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {
           

        }
        private void MtdMostrarListaHabitacion()
        {
            var ListaHabitacion = cd_asignaciones.MtdListaHabitacion();

            foreach (var Habitacion in ListaHabitacion)
            {
                cboxHabitacion.Items.Add(Habitacion);
            }

            cboxHabitacion.DisplayMember = "Text";
            cboxHabitacion.ValueMember = "Value";
        }
        private void MtdMostrarListaEmpleado()
        {
            var ListaEmpleado = cd_asignaciones.MtdListaEmpleado();

            foreach (var empleado in ListaEmpleado)
            {
                cboxEmpleado.Items.Add(empleado);
            }

            cboxEmpleado.DisplayMember = "Text";
            cboxEmpleado.ValueMember = "Value";
        }
        private void MtdConsultarAsignacion()
        {
            DataTable Dt = cd_asignaciones.MtdConsultarAsignaciones();
            dgvAsignacion.DataSource = Dt;
        }
        private void FrmMedicamentos_Load(object sender, EventArgs e)
        {

            MtdMostrarListaHabitacion();
            MtdConsultarAsignacion();
            MtdMostrarListaEmpleado();

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            
                if ((string.IsNullOrEmpty(cboxEmpleado.Text) || string.IsNullOrEmpty(cboxHabitacion.Text) || string.IsNullOrEmpty(cboxTipoAsignacion.Text) ||
                    string.IsNullOrEmpty(cboxEstado.Text) || string.IsNullOrEmpty(dtpFechaAsignacion.Text) ))
                {
                    MessageBox.Show("Los campos no pueden estar en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        
                        
                        string TipoAsignacion = cboxTipoAsignacion.Text;
                        DateTime FechaAsignacion = dtpFechaAsignacion.Value;
                        int Empleado = (int)((dynamic)cboxEmpleado.SelectedItem).Value;
                        int Habitacion = (int)((dynamic)cboxHabitacion.SelectedItem).Value;
                        string Estado = cboxEstado.Text;
                        DateTime FechaSistema = cl_asignacion.MtdFechaHoy();
                        string UsuarioSistema = "Chavez";

                        cd_asignaciones.MtdAgregarAsignacion(Empleado, Habitacion, TipoAsignacion, FechaAsignacion, Estado, UsuarioSistema, FechaSistema);
                        MessageBox.Show("Medicamento agregado", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MtdConsultarAsignacion();
                        mtdLimpiar();
                    }
                    catch (Exception ex)
                    {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                  
                }
            
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void mtdLimpiar()
        {
            txtCodigoAsignacion.Clear();
            cboxEmpleado.Text = "";
            cboxHabitacion.Text = "";
            cboxTipoAsignacion.Text = "";
            cboxEstado.Text = "";
            dtpFechaAsignacion.Text = "";
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if ((string.IsNullOrEmpty(txtCodigoAsignacion.Text) || cboxEmpleado.Text == "" || cboxHabitacion.Text == "" || cboxTipoAsignacion.Text == "" || cboxEstado.Text == "" || dtpFechaAsignacion.Text == ""))
                {
                    MessageBox.Show("Los campos no pueden estar en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int editar = dgvAsignacion.CurrentRow.Index;
                    dgvAsignacion.Rows[editar].Cells[0].Value = txtCodigoAsignacion.Text;
                    dgvAsignacion.Rows[editar].Cells[1].Value = cboxEmpleado.Text;
                    dgvAsignacion.Rows[editar].Cells[2].Value = cboxHabitacion.Text;
                    dgvAsignacion.Rows[editar].Cells[3].Value = cboxTipoAsignacion.Text;
                    dgvAsignacion.Rows[editar].Cells[4].Value = cboxEstado.Text;
                    dgvAsignacion.Rows[editar].Cells[5].Value = dtpFechaAsignacion.Text;

                    MessageBox.Show("Datos Editado Correctamente", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtdLimpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAsignacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoAsignacion.Text = dgvAsignacion.CurrentRow.Cells[0].Value.ToString();
            cboxEmpleado.Text = dgvAsignacion.CurrentRow.Cells[1].Value.ToString();
            cboxHabitacion.Text = dgvAsignacion.CurrentRow.Cells[2].Value.ToString();
            cboxTipoAsignacion.Text = dgvAsignacion.CurrentRow.Cells[3].Value.ToString();
            cboxEstado.Text = dgvAsignacion.CurrentRow.Cells[4].Value.ToString();
            dtpFechaAsignacion.Text = dgvAsignacion.CurrentRow.Cells[5].Value.ToString();
            //UsuarioSistema = DgvEmpleados.CurrentRow.Cells[6].Value.ToString();
            //FechaSistema = DgvEmpleados.CurrentRow.Cells[7].Value.ToString();
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            mtdLimpiar();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            int eliminarfila = dgvAsignacion.CurrentRow.Index;

            dgvAsignacion.Rows.RemoveAt(eliminarfila);
        }

        private void tbl_Asignacion_Load(object sender, EventArgs e)
        {

        }
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
    }
   
}
