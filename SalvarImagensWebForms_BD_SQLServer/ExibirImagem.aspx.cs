using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

public partial class ExibirImagem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            int imagemID = Convert.ToInt32(Request.QueryString["id"]);
            //nomeArquivo], [horaUpload], [MIME], [imagem]
            using (SqlConnection Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                const string SQL = "SELECT [MIME], [imagem] FROM [Imagens] WHERE [id] = @id";
                SqlCommand myCommand = new SqlCommand(SQL, Conn);
                myCommand.Parameters.AddWithValue("@id", imagemID);

                Conn.Open();
                SqlDataReader myReader = myCommand.ExecuteReader();

                if (myReader.Read())
                {
                    Response.ContentType = myReader["MIME"].ToString();
                    Response.BinaryWrite((byte[])myReader["imagem"]);
                }

                myReader.Close();
                Conn.Close();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        } 
    }
}
