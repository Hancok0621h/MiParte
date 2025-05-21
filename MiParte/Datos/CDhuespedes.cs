using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiParte
{
    public class CDhuespedes
    {
        CDconexion cd_conexion = new CDconexion();


        public DataTable MtdConsultarHuespedes()
        {
            string QueryConsultarHuespedes = "Select * from tbl_Huespedes";
            SqlDataAdapter Adapter = new SqlDataAdapter(QueryConsultarHuespedes, cd_conexion.MtdAbrirConexion());
            DataTable Dt = new DataTable();
            Adapter.Fill(Dt);
            cd_conexion.MtdCerrarConexion();
            return Dt;
        }

        public void MtdAgregarHuespedes(string Nombre, int Nit, int Telefono, string tipo, string Estado, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryAgregar = "Insert into tbl_Huespedes (Nombre, Nit, Telefono, tipo, Estado, UsuarioSistema, FechaSistema) values (@Nombre, @Nit, @Telefono, @tipo, @Estado, @UsuarioSistema, @FechaSistema)";
            SqlCommand cmd = new SqlCommand(QueryAgregar, cd_conexion.MtdAbrirConexion());
           
            cmd.Parameters.AddWithValue("@Nombre", Nombre);
            cmd.Parameters.AddWithValue("@Nit", Nit);
            cmd.Parameters.AddWithValue("@Telefono", Telefono);
            cmd.Parameters.AddWithValue("@Estado", Estado);
            cmd.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);
            cmd.Parameters.AddWithValue("@FechaSistema", FechaSistema);
            cmd.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarHuespeds(int CodigoHuesped, string Nombre, int Nit, int Telefono, string tipo, string Estado, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryActualizar = "Insert into tbl_Huespedes (CodigoHuesped, Nombre, Nit, Telefono, tipo, Estado, UsuarioSistema, FechaSistema) values (@CodigoHuesped, @Nombre, @Nit, @Telefono, @tipo, @Estado, @UsuarioSistema, @FechaSistema)";
            SqlCommand cmd = new SqlCommand(QueryActualizar, cd_conexion.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@CodigoHuesped", CodigoHuesped);
            cmd.Parameters.AddWithValue("@Nombre", Nombre);
            cmd.Parameters.AddWithValue("@Nit", Nit);
            cmd.Parameters.AddWithValue("@Telefono", Telefono);
            cmd.Parameters.AddWithValue("@Estado", Estado);
            cmd.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);
            cmd.Parameters.AddWithValue("@FechaSistema", FechaSistema);
            cmd.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }
    }
}
