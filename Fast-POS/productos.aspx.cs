using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Fast_POS
{
    public partial class _default : System.Web.UI.Page
    {
        string strConnection = "Server= DESKTOP-AFFVEDI\\SQLEXPRESS; Database=FastPOS; Integrated Security=true";
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        protected void FiltrarProductos(object sender, EventArgs e)
        {
            using (var conexion = new SqlConnection(strConnection))
            {
                conexion.Open();
                using (var command = new SqlCommand("sp_filtrarProductos", conexion))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@consulta", SqlDbType.NVarChar).Value = txtConsulta.Text;
                    var ds = new DataSet();
                    var da = new SqlDataAdapter(command);
                    da.Fill(ds);

                    gvDatos.DataSource = ds;
                    gvDatos.DataBind();
                    rptProductos.DataSource = ds;
                    rptProductos.DataBind();
                }
            }
        }
        void CargarDatos()
        {
            using (var conexion = new SqlConnection(strConnection))
            {
                conexion.Open();
                using (var command = new SqlCommand("sp_listarProductos", conexion))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    var ds = new DataSet();
                    var da = new SqlDataAdapter(command);
                    da.Fill(ds);

                    gvDatos.DataSource = ds;
                    gvDatos.DataBind();
                }
            }
        }
    }
}