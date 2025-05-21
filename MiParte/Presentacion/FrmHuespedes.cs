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
    public partial class Form_tlb_Huespedes : Form
    {
        CDconexion cd_conexion = new CDconexion();
        public Form_tlb_Huespedes()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((string.IsNullOrEmpty(txtCodigoHuesped.Text) || txtNombre.Text == "" || txtNit.Text == "" || txtTelefono.Text == "" || cboxTipo.Text == "" || cboxEstado.Text == ""))
                {
                    MessageBox.Show("Los campos no pueden estar en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int Contafila = dgvHuespedes.Rows.Add();
                    dgvHuespedes.Rows[Contafila].Cells[0].Value = txtCodigoHuesped.Text;
                    dgvHuespedes.Rows[Contafila].Cells[1].Value = txtNombre.Text;
                    dgvHuespedes.Rows[Contafila].Cells[2].Value = txtNit.Text;
                    dgvHuespedes.Rows[Contafila].Cells[3].Value = txtTelefono.Text;
                    dgvHuespedes.Rows[Contafila].Cells[4].Value = cboxTipo.Text;
                    dgvHuespedes.Rows[Contafila].Cells[5].Value = cboxEstado.Text;


                    MessageBox.Show("Datos Agregados Correctamente", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtdLimpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void mtdLimpiar()
        {
            txtCodigoHuesped.Clear();
            txtNombre.Clear();
            txtNit.Clear();
            txtTelefono.Clear(); ;
            cboxTipo.Text = "";
            cboxEstado.Text = "";
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if ((string.IsNullOrEmpty(txtCodigoHuesped.Text) || txtNombre.Text == "" || txtNit.Text == "" || txtTelefono.Text == "" || cboxTipo.Text == "" || cboxEstado.Text == ""))
                {
                    MessageBox.Show("Los campos no pueden estar en blanco", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int editar = dgvHuespedes.CurrentRow.Index;
                    dgvHuespedes.Rows[editar].Cells[0].Value = txtCodigoHuesped.Text;
                    dgvHuespedes.Rows[editar].Cells[1].Value = txtNombre.Text;
                    dgvHuespedes.Rows[editar].Cells[2].Value = txtNit.Text;
                    dgvHuespedes.Rows[editar].Cells[3].Value = txtTelefono.Text;
                    dgvHuespedes.Rows[editar].Cells[4].Value = cboxTipo.Text;
                    dgvHuespedes.Rows[editar].Cells[5].Value = cboxEstado.Text;

                    MessageBox.Show("Datos Editado Correctamente", "EXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mtdLimpiar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            mtdLimpiar();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            int eliminarfila = dgvHuespedes.CurrentRow.Index;

            dgvHuespedes.Rows.RemoveAt(eliminarfila);
        }

        private void dgvHuespedes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoHuesped.Text = dgvHuespedes.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgvHuespedes.CurrentRow.Cells[1].Value.ToString();
            txtNit.Text = dgvHuespedes.CurrentRow.Cells[2].Value.ToString();
            txtTelefono.Text = dgvHuespedes.CurrentRow.Cells[3].Value.ToString();
            cboxTipo.Text = dgvHuespedes.CurrentRow.Cells[4].Value.ToString();
            cboxEstado.Text = dgvHuespedes.CurrentRow.Cells[5].Value.ToString();
            //UsuarioSistema = DgvEmpleados.CurrentRow.Cells[6].Value.ToString();
            //FechaSistema = DgvEmpleados.CurrentRow.Cells[7].Value.ToString();
        }

        private void Form_tlb_Huespedes_Load(object sender, EventArgs e)
        {

        }
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
    }
}
