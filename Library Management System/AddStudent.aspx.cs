using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;


namespace Library_Management_System
{
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtStudentName.Text.Trim() == "" ||
                txtDepartment.Text.Trim() == "" ||
                txtEmail.Text.Trim() == "" ||
                txtMobile.Text.Trim() == "")
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "All fields are required.";
                return;
            }

            string cs = ConfigurationManager
                        .ConnectionStrings["LibraryDBConnection"]
                        .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = @"INSERT INTO Students
                        (StudentName, Department, Email, Mobile)
                        VALUES (@n, @d, @e, @m)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@n", txtStudentName.Text.Trim());
                cmd.Parameters.AddWithValue("@d", txtDepartment.Text.Trim());
                cmd.Parameters.AddWithValue("@e", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@m", txtMobile.Text.Trim());

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Student added successfully.";

                txtStudentName.Text = "";
                txtDepartment.Text = "";
                txtEmail.Text = "";
                txtMobile.Text = "";
            }
        }

    }
}