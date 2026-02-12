using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

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

                string defaultImage = "~/Images/default-user.png";
                string imageUrl = defaultImage;

                // If student uploads image
                if (fuProfilePic.HasFile)
                {
                    string storageConnectionString =
                        ConfigurationManager.AppSettings["BlobConnectionString"];

                    CloudStorageAccount storageAccount =
                        CloudStorageAccount.Parse(storageConnectionString);

                    CloudBlobClient blobClient =
                        storageAccount.CreateCloudBlobClient();

                    CloudBlobContainer container =
    blobClient.GetContainerReference("student-images");

                    if (container.CreateIfNotExists())
                    {
                        container.SetPermissions(
                            new BlobContainerPermissions
                            {
                                PublicAccess = BlobContainerPublicAccessType.Blob
                            });
                    }

                    string fileName = Guid.NewGuid().ToString() +
                        System.IO.Path.GetExtension(fuProfilePic.FileName);

                    CloudBlockBlob blockBlob =
                        container.GetBlockBlobReference(fileName);

                    blockBlob.UploadFromStream(fuProfilePic.FileContent);

                    imageUrl = blockBlob.Uri.ToString();

                }

                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO Students
              (StudentName, Department, Email, Mobile, Password, ProfileImageUrl)
              VALUES
              (@name, @dept, @email, @mobile, @pass, @img)", con);

                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@dept", txtDept.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@mobile", txtMobile.Text);
                cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                cmd.Parameters.AddWithValue("@img", imageUrl);

                cmd.ExecuteNonQuery();

                lblMsg.Text = "Registration Successful!";
            }
        }


    }
}
