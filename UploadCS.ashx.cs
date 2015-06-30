using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Text;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text.RegularExpressions;
namespace BoardHunt
{
    /// <summary>
    /// Summary description for UploadCS
    /// </summary>
    public class UploadCS : IHttpHandler, IRequiresSessionState
    {

        public static ArrayList filenewname = new ArrayList();
        public static ArrayList filenewpath = new ArrayList();

        public void ProcessRequest(HttpContext context)
        {
            string savepath = "";

            try
            {

                List<HttpPostedFile> files = (List<HttpPostedFile>)context.Session["Files"];
                HttpPostedFile postedFile = context.Request.Files["Filedata"];
                StringBuilder sb = new StringBuilder();
                //savepath = HttpContext.Current.Server.MapPath("");
                string filePath = "/TempAddImages/";
                //extension = Path.GetExtension(postedFile.FileName);
                if (!Directory.Exists(context.Server.MapPath(filePath)))
                {
                    Directory.CreateDirectory(savepath);
                }
                //Guid.NewGuid().ToString()  +
                if (context.Request.Files.Count <= 0)
                {
                    context.Response.Write("No file uploaded");
                }
                else
                {
                    HttpFileCollection uploadedVideoFiles = context.Request.Files;
                    int count = uploadedVideoFiles.Count;
                    HttpPostedFile file = context.Request.Files[0];

                    if (file.ContentLength > 0)
                    {
                        double scaleFactor = 0.07;

                        files = new List<HttpPostedFile>();
                        string filenames = postedFile.FileName;
                        string filename = Regex.Replace(filenames, @"\s+", "");
                        file.SaveAs(context.Server.MapPath(filePath + filename));
                        string targetPath = context.Server.MapPath(filePath + filename);

                        //FileStream fs = new FileStream(context.Server.MapPath(filePath + filename), FileMode.Open, FileAccess.Read);

                        //BinaryReader br = new BinaryReader(fs);

                        //byte[] image = br.ReadBytes((int)fs.Length);

                        //br.Close();

                        //fs.Close();
                        //MemoryStream stream = new MemoryStream(image);
                        //System.Drawing.Image UploadedImage = System.Drawing.Image.FromStream(stream);


                        //var newWidth = (int)(UploadedImage.Width * scaleFactor);
                        //var newHeight = (int)(UploadedImage.Height * scaleFactor);
                        //var thumbnailImg = new Bitmap(newWidth, newHeight);
                        //var thumbGraph = Graphics.FromImage(thumbnailImg);
                        //thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                        //thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                        //thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        //var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                        //thumbGraph.DrawImage(UploadedImage, imageRectangle);
                        //thumbnailImg.Save(targetPath, UploadedImage.RawFormat);


                        context.Response.Write(filename);
                        context.Response.StatusCode = 200;
                        files.Add(postedFile);

                    }


                }

            }
            catch (Exception ex)
            {
                context.Response.Write("Error: " + ex.Message);
            }
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}