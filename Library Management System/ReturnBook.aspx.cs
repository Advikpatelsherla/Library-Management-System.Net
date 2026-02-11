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
    public partial class ReturnBook : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null || Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("Login.aspx");
            }


            if (!IsPostBack)
            {
                LoadIssuedBooks();
            }
        }

        private void LoadIssuedBooks()
        {
            string cs = ConfigurationManager
                        .ConnectionStrings["LibraryDBConnection"]
                        .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = @"
            SELECT ib.IssueId,
                   s.StudentName,
                   b.BookName,
                   ib.IssueDate,
                   ib.DueDate
            FROM IssuedBooks ib
            INNER JOIN Students s ON ib.StudentId = s.StudentId
            INNER JOIN Books b ON ib.BookId = b.BookId
            WHERE ib.ReturnDate IS NULL";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvIssuedBooks.DataSource = dt;
                gvIssuedBooks.DataBind();
            }
        }



        protected void gvIssuedBooks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ReturnBook")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                int issueId = Convert.ToInt32(gvIssuedBooks.DataKeys[rowIndex].Value);

                string cs = ConfigurationManager
                            .ConnectionStrings["LibraryDBConnection"]
                            .ConnectionString;

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    // get BookId
                    SqlCommand getBookCmd = new SqlCommand(
                        "SELECT BookId FROM IssuedBooks WHERE IssueId=@iid", con);
                    getBookCmd.Parameters.AddWithValue("@iid", issueId);
                    int bookId = Convert.ToInt32(getBookCmd.ExecuteScalar());

                    // mark returned
                    SqlCommand returnCmd = new SqlCommand(
                        "UPDATE IssuedBooks SET ReturnDate=GETDATE() WHERE IssueId=@iid", con);
                    returnCmd.Parameters.AddWithValue("@iid", issueId);
                    returnCmd.ExecuteNonQuery();

                    // increase stock
                    SqlCommand updateCmd = new SqlCommand(
                        "UPDATE Books SET AvailableCopies = AvailableCopies + 1 WHERE BookId=@bid", con);
                    updateCmd.Parameters.AddWithValue("@bid", bookId);
                    updateCmd.ExecuteNonQuery();

                    con.Close();
                }

                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Book returned successfully.";

                LoadIssuedBooks();
            }
        }




    }
}