using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Library_Management_System
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnRegister.Visible = false; // default hidden
            }
        }


        protected void ddlRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRole.SelectedValue == "Student")
            {
                btnRegister.Visible = true;
            }
            else
            {
                btnRegister.Visible = false;
            }
        }


        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentRegister.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string role = ddlRole.SelectedValue;
            string cs = ConfigurationManager
                        .ConnectionStrings["LibraryDBConnection"]
                        .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                // 🔹 ADMIN LOGIN
                if (role == "Admin")
                {
                    SqlCommand cmd = new SqlCommand(
                        "SELECT UserId FROM Users WHERE Username=@u AND Password=@p",
                        con);

                    cmd.Parameters.AddWithValue("@u", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@p", txtPassword.Text);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        Session["User"] = txtUsername.Text;
                        Session["Role"] = "Admin";
                        Response.Redirect("Dashboard.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "Invalid Admin Credentials";
                    }
                }

                // 🔹 STUDENT LOGIN (USING EMAIL)
                else if (role == "Student")
                {
                    SqlCommand cmd = new SqlCommand(
                        "SELECT StudentId FROM Students WHERE Email=@email AND Password=@p",
                        con);

                    cmd.Parameters.AddWithValue("@email", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@p", txtPassword.Text);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        Session["UserId"] = result.ToString();   // MUST exist
                        Session["Role"] = "Student";
                        Response.Redirect("StudentDashboard.aspx");
                    }

                    else
                    {
                        lblMessage.Text = "Invalid Student Email or Password";
                    }
                }
            }
        }
    }
}
