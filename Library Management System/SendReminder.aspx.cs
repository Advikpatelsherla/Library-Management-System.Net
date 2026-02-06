using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Library_Management_System
{
    public partial class SendReminder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadIssuedStudents();
            }
        }
        private void LoadIssuedStudents()
        {
            string cs = ConfigurationManager
                        .ConnectionStrings["LibraryDBConnection"]
                        .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = @"
            SELECT 
                s.StudentName,
                s.Email,
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

                gvIssuedAll.DataSource = dt;
                gvIssuedAll.DataBind();
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
            SELECT 
                s.StudentName,
                s.Email,
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
            WHERE ib.ReturnDate IS NULL
              AND s.StudentName LIKE @name";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", "%" + txtSearch.Text + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvIssuedAll.DataSource = dt;
                gvIssuedAll.DataBind();
            }
        }

        protected void btnAll_Click(object sender, EventArgs e)
        {
            LoadIssuedStudents();
        }



        protected void btnSend_Click(object sender, EventArgs e)
        {
            int sent = 0;

            foreach (GridViewRow row in gvIssuedAll.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");

                if (chk != null && chk.Checked)
                {
                    string name = row.Cells[1].Text;
                    string email = row.Cells[2].Text;
                    string book = row.Cells[3].Text;
                    DateTime due = Convert.ToDateTime(row.Cells[5].Text);

                    SendEmail(email, name, book, due);
                    sent++;
                }
            }

            lblMsg.ForeColor = System.Drawing.Color.Green;
            lblMsg.Text = sent + " reminder emails sent successfully.";
        }


        private void SendEmail(string toEmail, string name, string book, DateTime dueDate)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("yourgmail@gmail.com");
            mail.To.Add(toEmail);
            mail.Subject = "Library Book Overdue Reminder";

            mail.Body = $"Dear {name},\n\n" +
                        $"The book \"{book}\" was due on {dueDate:dd-MMM-yyyy}.\n" +
                        $"Please return it as soon as possible.\n\n" +
                        $"Library Management";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(
                "rinkusherla8@gmail.com",
                "fzpk awoj yfxw ospm");
            smtp.EnableSsl = true;

            smtp.Send(mail);
        }



    }
}