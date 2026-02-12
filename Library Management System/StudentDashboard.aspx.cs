using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System
{
    public partial class StudentDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 🔐 SECURITY CHECK
            if (Session["StudentID"] == null ||
                Session["Role"] == null ||
                Session["Role"].ToString() != "Student")
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadProfileData();
                LoadAvailableBooks();
                LoadMyBooks();
            }
        }

        // ================================
        // LOAD PROFILE DATA
        // ================================
        private void LoadProfileData()
        {
            if (Session["StudentID"] == null)
                return;

            string cs = ConfigurationManager
                .ConnectionStrings["LibraryDBConnection"]
                .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    @"SELECT StudentName, Email, Mobile, ProfileImageUrl 
                      FROM Students 
                      WHERE StudentId=@id", con);

                cmd.Parameters.AddWithValue("@id",
                    Session["StudentID"].ToString());

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    lblStudentName.Text = reader["StudentName"].ToString();
                    lblEmail.Text = reader["Email"].ToString();
                    lblMobile.Text = reader["Mobile"].ToString();

                    // 🖼 PROFILE IMAGE FIX
                    string imageUrl = reader["ProfileImageUrl"] == DBNull.Value
                        ? "~/Images/default-user.png"
                        : reader["ProfileImageUrl"].ToString();

                    if (imageUrl.StartsWith("~"))
                        imgProfile.ImageUrl = ResolveUrl(imageUrl);
                    else
                        imgProfile.ImageUrl = imageUrl;
                }

                con.Close();
            }
        }

        // ================================
        // LOAD ALL AVAILABLE BOOKS
        // ================================
        private void LoadAvailableBooks()
        {
            string cs = ConfigurationManager
                        .ConnectionStrings["LibraryDBConnection"]
                        .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query =
                    "SELECT BookName, Author, Publication, AvailableCopies FROM Books";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvBooks.DataSource = dt;
                gvBooks.DataBind();
            }
        }

        // ================================
        // LOAD STUDENT ISSUED BOOKS
        // ================================
        private void LoadMyBooks()
        {
            if (Session["StudentID"] == null)
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
                cmd.Parameters.AddWithValue("@sid",
                    Session["StudentID"].ToString());

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvMyBooks.DataSource = dt;
                gvMyBooks.DataBind();
            }
        }

        // ================================
        // SEARCH BOOKS
        // ================================
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
                cmd.Parameters.AddWithValue("@value",
                    "%" + txtSearch.Text + "%");

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

        // ================================
        // COLOR STATUS COLUMN
        // ================================
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
