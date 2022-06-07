using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fast_POS
{
    public partial class proveedores : System.Web.UI.Page
    {
        readonly string strConnection = "Server= DESKTOP-AFFVEDI\\SQLEXPRESS; Database=FastPOS; Integrated Security=true";
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        void CargarDatos()
        {
            using (var conexion = new SqlConnection(strConnection))
            {
                conexion.Open();
                using (var command = new SqlCommand("select id_categoria as Código, nom_categoria as Nombre FROM categorias", conexion))
                {
                    var ds = new DataSet();
                    var da = new SqlDataAdapter(command);
                    da.Fill(ds);

                    gvDatos.DataSource = ds;
                    gvDatos.DataBind();

                    rptCategorias.DataSource = ds;
                    rptCategorias.DataBind();
                }
            }
        }

        protected void FiltrarCategorias(object sender, EventArgs e)
        {
            using (var conexion = new SqlConnection(strConnection))
            {
                conexion.Open();
                using (var command = new SqlCommand("select id_categoria as Código, nom_categoria as Nombre FROM categorias WHERE nom_categoria LIKE concat('%',@consulta,'%')", conexion))
                {
                    command.Parameters.Add("@consulta", SqlDbType.NVarChar).Value = txtConsulta.Text;
                    var ds = new DataSet();
                    var da = new SqlDataAdapter(command);
                    da.Fill(ds);

                    gvDatos.DataSource = ds;
                    gvDatos.DataBind();

                    rptCategorias.DataSource = ds;
                    rptCategorias.DataBind();
                }
            }
        }
    }
}