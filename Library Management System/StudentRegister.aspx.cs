using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Library_Management_System
{
    public partial class StudentRegister : System.Web.UI.Page
    {
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager
                        .ConnectionStrings["LibraryDBConnection"]
                        .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                // 🔹 Check if email already exists
                SqlCommand checkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Students WHERE Email=@email", con);

                checkCmd.Parameters.AddWithValue("@email", txtEmail.Text);

                int exists = (int)checkCmd.ExecuteScalar();

                if (exists > 0)
                {
                    lblMsg.Text = "Email already registered!";
                    return;
                }

                // 🔹 Insert Student (NO StudentId - identity auto)
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Students
                      (StudentName, Department, Email, Mobile, Password)
                      VALUES
                      (@name, @dept, @email, @mobile, @pass)", con);

                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@dept", txtDept.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@mobile", txtMobile.Text);
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

                cmd.ExecuteNonQuery();

                lblMsg.Text = "Registration Successful!";
            }
        }
    }
}
