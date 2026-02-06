using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Library_Management_System
{
    public partial class IssueBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadStudents();
                LoadBooks();
            }
        }

        private void LoadStudents()
        {
            string cs = ConfigurationManager
                        .ConnectionStrings["LibraryDBConnection"]
                        .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter da =
                    new SqlDataAdapter("SELECT StudentId, StudentName FROM Students", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlStudent.DataSource = dt;
                ddlStudent.DataTextField = "StudentName";
                ddlStudent.DataValueField = "StudentId";
                ddlStudent.DataBind();
            }
        }

        private void LoadBooks()
        {
            string cs = ConfigurationManager
                        .ConnectionStrings["LibraryDBConnection"]
                        .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter da =
                    new SqlDataAdapter(
                        "SELECT BookId, BookName FROM Books WHERE AvailableCopies > 0",
                        con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlBook.DataSource = dt;
                ddlBook.DataTextField = "BookName";
                ddlBook.DataValueField = "BookId";
                ddlBook.DataBind();
            }
        }





        protected void btnIssue_Click(object sender, EventArgs e)
        {
            int studentId = int.Parse(ddlStudent.SelectedValue);
            int bookId = int.Parse(ddlBook.SelectedValue);

            string cs = ConfigurationManager
                        .ConnectionStrings["LibraryDBConnection"]
                        .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                SqlCommand issueCmd = new SqlCommand(
                    @"INSERT INTO IssuedBooks
              (StudentId, BookId, IssueDate, DueDate)
              VALUES (@sid, @bid, GETDATE(), DATEADD(day,14,GETDATE()))",
                    con);

                issueCmd.Parameters.AddWithValue("@sid", studentId);
                issueCmd.Parameters.AddWithValue("@bid", bookId);
                issueCmd.ExecuteNonQuery();

                SqlCommand updateCmd = new SqlCommand(
                    "UPDATE Books SET AvailableCopies = AvailableCopies - 1 WHERE BookId=@bid",
                    con);

                updateCmd.Parameters.AddWithValue("@bid", bookId);
                updateCmd.ExecuteNonQuery();

                con.Close();
            }

            lblMsg.ForeColor = System.Drawing.Color.Green;
            lblMsg.Text = "Book issued successfully.";

            LoadBooks(); // refresh available books
        }



    }
}