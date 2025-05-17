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
    }
}
