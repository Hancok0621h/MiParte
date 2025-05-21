using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiParte.Datos
{
    public class CDasignaciones
    {
        CDconexion cd_conexion = new CDconexion();

        public List<dynamic> MtdListaHabitacion()
        {
            List<dynamic> ListaHabitacion = new List<dynamic>();
            string QueryListaHabitacion = "Select CodigoHabitacion, numero from tbl_Habitaciones";
            SqlCommand cmd = new SqlCommand(QueryListaHabitacion, cd_conexion.MtdAbrirConexion());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListaHabitacion.Add(new
                {
                    Value = reader["CodigoHabitacion"],
                    Text = $"{reader["CodigoHabitacion"]} - {reader["numero"]}"
                });
            }

            cd_conexion.MtdCerrarConexion();
            return ListaHabitacion;
        }
        public List<dynamic> MtdListaEmpleado()
        {
            List<dynamic> ListaEmpleado = new List<dynamic>();
            string QueryListaEmpleado = "Select CodigoEmpleado, nombre from tbl_Empleado";
            SqlCommand cmd = new SqlCommand(QueryListaEmpleado, cd_conexion.MtdAbrirConexion());
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ListaEmpleado.Add(new
                {
                    Value = reader["CodigoEmpleado"],
                    Text = $"{reader["CodigoEmpleado"]} - {reader["nombre"]}"
                });
            }

            cd_conexion.MtdCerrarConexion();
            return ListaEmpleado;
        }


        public DataTable MtdConsultarAsignaciones()
        {
            string QueryConsultarAsignaciones = "Select * from tbl_Asignaciones";
            SqlDataAdapter Adapter = new SqlDataAdapter(QueryConsultarAsignaciones, cd_conexion.MtdAbrirConexion());
            DataTable Dt = new DataTable();
            Adapter.Fill(Dt);
            cd_conexion.MtdCerrarConexion();
            return Dt;
        }

        public void MtdAgregarAsignacion(int CodigoEmpleado, int CodigoHabitacion, string TipoAsignacion, DateTime FechaAsignacion, string Estado, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryAgregar = "Insert into tbl_Asignaciones (CodigoEmpleado, CodigoHabitacion, TipoAsignacion, FechaAsignacion, Estado, UsuarioSistema, FechaSistema) values (@CodigoEmpleado, @CodigoHabitacion, @TipoAsignacion, @FechaAsignacion, @Estado, @UsuarioSistema, @FechaSistema)";
            SqlCommand cmd = new SqlCommand(QueryAgregar, cd_conexion.MtdAbrirConexion());
            
            cmd.Parameters.AddWithValue("@CodigoHabitacion", CodigoHabitacion);
            cmd.Parameters.AddWithValue("@TipoAsignacion", TipoAsignacion);
            cmd.Parameters.AddWithValue("@FechaAsignacion", FechaAsignacion);
            cmd.Parameters.AddWithValue("@Estado", Estado);
            cmd.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);
            cmd.Parameters.AddWithValue("@FechaSistema", FechaSistema);
            cmd.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdActualizarAsignacion(int CodigoAsignacion, int CodigoEmpleado, int CodigoHabitacion, string TipoAsignacion, DateTime FechaAsignacion, string Estado, string UsuarioSistema, DateTime FechaSistema)
        {
            string QueryActualizar = "Insert into tbl_Asignaciones (CodigoAsignacion, CodigoEmpleado, CodigoHabitacion, TipoAsignacion, FechaAsignacion, Estado, UsuarioSistema, FechaSistema) values (@CodigoAsignacion, @CodigoEmpleado, @CodigoHabitacion, @TipoAsignacion, @FechaAsignacion, @Estado, @UsuarioSistema, @FechaSistema)";
            SqlCommand cmd = new SqlCommand(QueryActualizar, cd_conexion.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@CodigoAsignacion", CodigoAsignacion);
            cmd.Parameters.AddWithValue("@CodigoHabitacion", CodigoHabitacion);
            cmd.Parameters.AddWithValue("@TipoAsignacion", TipoAsignacion);
            cmd.Parameters.AddWithValue("@FechaAsignacion", FechaAsignacion);
            cmd.Parameters.AddWithValue("@Estado", Estado);
            cmd.Parameters.AddWithValue("@UsuarioSistema", UsuarioSistema);
            cmd.Parameters.AddWithValue("@FechaSistema", FechaSistema);
            cmd.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

        public void MtdEliminarProveedores(int CodigoAsignacion)
        {
            string QueryEliminar = "Delete from tbl_Asignaciones where CodigoAsignacion=@CodigoAsignacion";
            SqlCommand cmd = new SqlCommand(QueryEliminar, cd_conexion.MtdAbrirConexion());
            cmd.Parameters.AddWithValue("@CodigoAsignacion", CodigoAsignacion);
            cmd.ExecuteNonQuery();
            cd_conexion.MtdCerrarConexion();
        }

    }
}
