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
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null || Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("Login.aspx");
            }

        }

        protected void btnBooks_Click(object sender, EventArgs e)
        {
            LoadReport("SELECT * FROM Books");
        }

        protected void btnIssued_Click(object sender, EventArgs e)
        {
            LoadReport(@"
        SELECT 
            s.StudentName,
            b.BookName,
            ib.IssueDate,
            ib.DueDate
        FROM IssuedBooks ib
        INNER JOIN Students s ON ib.StudentId = s.StudentId
        INNER JOIN Books b ON ib.BookId = b.BookId
        WHERE ib.ReturnDate IS NULL");
        }

        private void LoadReport(string query)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            string cs = ConfigurationManager
                        .ConnectionStrings["LibraryDBConnection"]
                        .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvReport.DataSource = dt;
                gvReport.DataBind();
            }
        }

    }
}