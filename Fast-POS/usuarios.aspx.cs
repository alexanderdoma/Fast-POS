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
    public partial class usuarios : System.Web.UI.Page
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
                using (var command = new SqlCommand("SELECT id_usuario AS Código, nom_usuario as Nombres, correo_usuario as EMail FROM usuarios", conexion))
                {
                    var ds = new DataSet();
                    var da = new SqlDataAdapter(command);
                    da.Fill(ds);

                    gvDatos.DataSource = ds;
                    gvDatos.DataBind();

                    rptUsuarios.DataSource = ds;
                    rptUsuarios.DataBind();
                }
            }
        }

        protected void FiltrarUsuarios(object sender, EventArgs e)
        {
            using (var conexion = new SqlConnection(strConnection))
            {
                conexion.Open();
                using (var command = new SqlCommand("SELECT id_usuario AS Código, nom_usuario AS Nombres, correo_usuario AS Email FROM usuarios WHERE nom_usuario LIKE concat('%',@consulta,'%')", conexion))
                {
                    command.Parameters.Add("@consulta", SqlDbType.NVarChar).Value = txtConsulta.Text;
                    var ds = new DataSet();
                    var da = new SqlDataAdapter(command);
                    da.Fill(ds);

                    gvDatos.DataSource = ds;
                    gvDatos.DataBind();

                    rptUsuarios.DataSource = ds;
                    rptUsuarios.DataBind();
                }
            }
        }
    }
}