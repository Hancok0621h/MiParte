using MiParte.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiParte
{
    public partial class tbl_Asignacion : Form
    {
        CDconexion cd_conexion = new CDconexion();
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


        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((string.IsNullOrEmpty(txtCodigoAsignacion.Text) || txtCodigaEmpleado.Text == "" || txtCodigoHabitacion.Text == "" || cboxTipoAsignacion.Text == "" || cboxEstado.Text == "" || dtpFechaAsignacion.Text == "" ))
                {
                    MessageBox.Show("Los campos no pueden estar en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int Contafila = dgvAsignacion.Rows.Add();
                    dgvAsignacion.Rows[Contafila].Cells[0].Value = txtCodigoAsignacion.Text;
                    dgvAsignacion.Rows[Contafila].Cells[1].Value = txtCodigaEmpleado.Text;
                    dgvAsignacion.Rows[Contafila].Cells[2].Value = txtCodigoHabitacion.Text;
                    dgvAsignacion.Rows[Contafila].Cells[3].Value = cboxTipoAsignacion.Text;
                    dgvAsignacion.Rows[Contafila].Cells[4].Value = cboxEstado.Text;
                    dgvAsignacion.Rows[Contafila].Cells[5].Value = dtpFechaAsignacion.Text;
                    

                    MessageBox.Show("Datos Agregados Correctamente", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtdLimpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtCodigaEmpleado.Clear();
            txtCodigoHabitacion.Clear();
            cboxTipoAsignacion.Text = "";
            cboxEstado.Text = "";
            dtpFechaAsignacion.Text = "";
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if ((string.IsNullOrEmpty(txtCodigoAsignacion.Text) || txtCodigaEmpleado.Text == "" || txtCodigoHabitacion.Text == "" || cboxTipoAsignacion.Text == "" || cboxEstado.Text == "" || dtpFechaAsignacion.Text == ""))
                {
                    MessageBox.Show("Los campos no pueden estar en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int editar = dgvAsignacion.CurrentRow.Index;
                    dgvAsignacion.Rows[editar].Cells[0].Value = txtCodigoAsignacion.Text;
                    dgvAsignacion.Rows[editar].Cells[1].Value = txtCodigaEmpleado.Text;
                    dgvAsignacion.Rows[editar].Cells[2].Value = txtCodigoHabitacion.Text;
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
            txtCodigaEmpleado.Text = dgvAsignacion.CurrentRow.Cells[1].Value.ToString();
            txtCodigoHabitacion.Text = dgvAsignacion.CurrentRow.Cells[2].Value.ToString();
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
    }
   
}
