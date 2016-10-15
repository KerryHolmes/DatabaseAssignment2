using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Movies_Again
{
    public partial class Add : System.Web.UI.Page
    {
        private void InsertData()
        {
            string connString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO movies(title,director,release,rating) Values (@mov,@dir,@rel,@rat);";
                cmd.Parameters.AddWithValue("@mov", Movie.Text);
                cmd.Parameters.AddWithValue("@dir", Director.Text);
                cmd.Parameters.AddWithValue("@rel", Release.Text);
                cmd.Parameters.AddWithValue("@rat", Convert.ToInt32(Rating.Text));
                cmd.ExecuteNonQuery();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        { }
        protected void On_submit(object sender, EventArgs e)
        {
            if(this.IsPostBack)
            {
                this.Validate();
                if(!this.IsValid)
                {
                    string msg = "";
                    // Loop through all validation controls to see which
                    // generated the errors.
                    foreach (IValidator aValidator in this.Validators)
                    {
                        if (!aValidator.IsValid)
                        {
                            msg += "<br />" + aValidator.ErrorMessage;
                        }
                    }
                    Label1.Text = msg;
                }

                InsertData();
                Response.Redirect("CS.aspx");

            }
        }
    }
}