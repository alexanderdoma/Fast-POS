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
    public partial class marcas : System.Web.UI.Page
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
                using (var command = new SqlCommand("SELECT id_marca AS Código, nom_marca as Marca FROM marcas", conexion))
                {
                    var ds = new DataSet();
                    var da = new SqlDataAdapter(command);
                    da.Fill(ds);

                    gvDatos.DataSource = ds;
                    gvDatos.DataBind();

                    rptMarcas.DataSource = ds;
                    rptMarcas.DataBind();
                }
            }
        }

        protected void FiltrarMarcas(object sender, EventArgs e)
        {
            using (var conexion = new SqlConnection(strConnection))
            {
                conexion.Open();
                using (var command = new SqlCommand("select id_marca as Código, nom_marca as Marca FROM marcas WHERE nom_marca LIKE concat('%',@consulta,'%')", conexion))
                {
                    command.Parameters.Add("@consulta", SqlDbType.NVarChar).Value = txtConsulta.Text;
                    var ds = new DataSet();
                    var da = new SqlDataAdapter(command);
                    da.Fill(ds);

                        rptMarcas.DataSource = ds;
                        rptMarcas.DataBind();
                    }
            }
        }
    }
}