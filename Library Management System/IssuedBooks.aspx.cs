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
    public partial class IssuedBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
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
            SELECT 
                s.StudentName,
                b.BookName,
                ib.IssueDate,
                ib.DueDate,
                CASE 
                    WHEN ib.DueDate < CAST(GETDATE() AS DATE) 
                    THEN 'Overdue'
                    ELSE 'On Time'
                END AS Status
            FROM IssuedBooks ib
            INNER JOIN Students s ON ib.StudentId = s.StudentId
            INNER JOIN Books b ON ib.BookId = b.BookId
            WHERE ib.ReturnDate IS NULL";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvIssued.DataSource = dt;
                gvIssued.DataBind();
            }
        }


    }
}