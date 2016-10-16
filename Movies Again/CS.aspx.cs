using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Movies_Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.BindGrid();
        }
    }

    private void BindGrid()
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM movies"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
            }
        }
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindGrid();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string connString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();

        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * From Movies";
            SqlDataReader reader = cmd.ExecuteReader();
            for (int i = 0; i < e.RowIndex + 1; ++i)
            {
                reader.Read();
            }
            var name = reader.GetInt32(0);
            reader.Close();
            cmd.CommandText = "Delete FROM movies WHERE mid=@mid";
            cmd.Parameters.AddWithValue("@mid", name);
            cmd.ExecuteNonQuery();
        }
        conn.Close();
        Response.Redirect("Redirect.apsx");
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        //gridview edit index = -1
        GridView1.EditIndex = -1;
        Page.Response.Redirect(Page.Request.Url.ToString(), true);
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //var name = GridView1.Rows[GridView1.EditIndex].Cells[0].Text;
        string connString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();

        using (SqlCommand cmd = new SqlCommand())
        {
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * From Movies";
            SqlDataReader reader = cmd.ExecuteReader();
            for(int i = 0; i < e.RowIndex+1; ++i)
            {
                reader.Read();
            }
            var name = reader.GetInt32(0);
            reader.Close();
            cmd.CommandText = "UPDATE movies SET title=@mov, director=@dir,release=@rel,rating=@rat WHERE mid=@mid;";
            cmd.Parameters.AddWithValue("@mid", name);
            cmd.Parameters.AddWithValue("@mov", e.NewValues["title"]);
            cmd.Parameters.AddWithValue("@dir", e.NewValues["director"]);
            cmd.Parameters.AddWithValue("@rel", e.NewValues["release"]);
            cmd.Parameters.AddWithValue("@rat", e.NewValues["rating"]);
            cmd.ExecuteNonQuery();
        }
        conn.Close();
        this.BindGrid();
    }
}
