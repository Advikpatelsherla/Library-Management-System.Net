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
    public partial class AddBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null || Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("Login.aspx");
            }


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Validate Total Copies
            int totalCopies;

            if (!int.TryParse(txtTotal.Text.Trim(), out totalCopies))
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Please enter a valid number for Total Copies.";
                return;
            }

            // 2. Validate required fields
            if (txtBookName.Text.Trim() == "" ||
                txtAuthor.Text.Trim() == "" ||
                txtPublication.Text.Trim() == "")
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "All fields are required.";
                return;
            }

            // 3. Database insert
            string cs = ConfigurationManager
                        .ConnectionStrings["LibraryDBConnection"]
                        .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = @"INSERT INTO Books
                        (BookName, Author, Publication, TotalCopies, AvailableCopies)
                        VALUES (@n, @a, @p, @t, @t)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@n", txtBookName.Text.Trim());
                cmd.Parameters.AddWithValue("@a", txtAuthor.Text.Trim());
                cmd.Parameters.AddWithValue("@p", txtPublication.Text.Trim());
                cmd.Parameters.AddWithValue("@t", totalCopies);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Book added successfully.";

                // clear fields
                txtBookName.Text = "";
                txtAuthor.Text = "";
                txtPublication.Text = "";
                txtTotal.Text = "";
            }
        }




    }
}