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


        public DataTable MtdConsultarAsignaciones()
        {
            string QueryConsultarAsignaciones = "Select * from tbl_Asignaciones";
            SqlDataAdapter Adapter = new SqlDataAdapter(QueryConsultarAsignaciones, cd_conexion.MtdAbrirConexion());
            DataTable Dt = new DataTable();
            Adapter.Fill(Dt);
            cd_conexion.MtdCerrarConexion();
            return Dt;
        }
    }
}
