using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Library_Management_System
{
    public partial class StudentDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadAvailableBooks();
                LoadMyBooks();
            }
        }


        private void LoadAvailableBooks()
        {
            string cs = ConfigurationManager
                        .ConnectionStrings["LibraryDBConnection"]
                        .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT BookName, Author, Publication, AvailableCopies FROM Books";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvBooks.DataSource = dt;
                gvBooks.DataBind();
            }
        }

        private void LoadMyBooks()
        {
            if (Session["UserId"] == null)
                return;

            string cs = ConfigurationManager
                .ConnectionStrings["LibraryDBConnection"]
                .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = @"
SELECT 
    B.BookName,
    I.IssueDate,
    I.DueDate,
    CASE 
        WHEN I.ReturnDate IS NOT NULL THEN 'Returned'
        ELSE 'Not Returned'
    END AS Status
FROM IssuedBooks I
INNER JOIN Books B ON I.BookId = B.BookId
WHERE I.StudentId = @sid";


                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@sid", Session["UserId"].ToString());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvMyBooks.DataSource = dt;
                gvMyBooks.DataBind();
            }
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager
                        .ConnectionStrings["LibraryDBConnection"]
                        .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = @"
                    SELECT BookName, Author, Publication, AvailableCopies
                    FROM Books
                    WHERE BookName LIKE @value
                    OR Author LIKE @value";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@value", "%" + txtSearch.Text + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvBooks.DataSource = dt;
                gvBooks.DataBind();
            }
        }

        protected void btnAll_Click(object sender, EventArgs e)
        {
            LoadAvailableBooks();
        }

        protected void gvMyBooks_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = e.Row.Cells[3].Text;

                if (status == "Returned")
                {
                    e.Row.Cells[3].ForeColor = System.Drawing.Color.Green;
                    e.Row.Cells[3].Font.Bold = true;
                }
                else
                {
                    e.Row.Cells[3].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[3].Font.Bold = true;
                }
            }
        }

    }
}
