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
    public partial class ViewBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadBooks();
            }
        }
        private void LoadBooks()
        {
            string cs = ConfigurationManager
                        .ConnectionStrings["LibraryDBConnection"]
                        .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT * FROM Books";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvBooks.DataSource = dt;
                gvBooks.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager
                        .ConnectionStrings["LibraryDBConnection"]
                        .ConnectionString;

            string column = ddlSearchType.SelectedValue;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = $"SELECT * FROM Books WHERE {column} LIKE @value";
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
            LoadBooks();
        }


        protected void gvBooks_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvBooks.EditIndex = e.NewEditIndex;
            LoadBooks();
        }

        protected void gvBooks_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvBooks.EditIndex = -1;
            LoadBooks();
        }

        protected void gvBooks_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int bookId = Convert.ToInt32(gvBooks.DataKeys[e.RowIndex].Value);

            string bookName = ((TextBox)gvBooks.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            string author = ((TextBox)gvBooks.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            string publication = ((TextBox)gvBooks.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
            int total = int.Parse(((TextBox)gvBooks.Rows[e.RowIndex].Cells[4].Controls[0]).Text);

            string cs = ConfigurationManager
                        .ConnectionStrings["LibraryDBConnection"]
                        .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = @"UPDATE Books 
                         SET BookName=@n, Author=@a, Publication=@p, TotalCopies=@t
                         WHERE BookId=@id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@n", bookName);
                cmd.Parameters.AddWithValue("@a", author);
                cmd.Parameters.AddWithValue("@p", publication);
                cmd.Parameters.AddWithValue("@t", total);
                cmd.Parameters.AddWithValue("@id", bookId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            gvBooks.EditIndex = -1;
            LoadBooks();
        }

        protected void gvBooks_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int bookId = Convert.ToInt32(gvBooks.DataKeys[e.RowIndex].Value);

            string cs = ConfigurationManager
                        .ConnectionStrings["LibraryDBConnection"]
                        .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "DELETE FROM Books WHERE BookId=@id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", bookId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            LoadBooks();
        }




    }
}