using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace BoardHunt.Labs
{
    public partial class Uploader : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string tmpFile;
            string[] strImgPathArray = new string[4];
            string thmbNailPath;


            ErrorLog.ErrorRoutine(false, "Uploader:Page_Load");

            //DataRow dr in dsItems.Tables[0].Rows


            //ErrorLog.ErrorRoutine(false, "HeaderCount: " + Request.Headers.Count);

            //ErrorLog.ErrorRoutine(false, "FormCount: " + Request.Form.Count);
            //ErrorLog.ErrorRoutine(false, "Content-Length: " + Request.ContentLength);

            ////NameValueCollection coll = Request.Form;
            //foreach (string key in Request.Headers)
            //{
            //    ErrorLog.ErrorRoutine(false, "Header: " + key + ": " + Request.Headers[key]);
            //} 


            ////NameValueCollection coll = Request.Form;
            //foreach (string key in Request.Form) 
            //{
            //    //ErrorLog.ErrorRoutine(false,"Key: " + key + ": " + Request.Form[key]); 
            //} 

            //init img array with blank space
            for (int j = 0; j <= 3; j++)
            {
                strImgPathArray[j] = "";
            }

            //Collect files names, iterate through each and update accordingly
            HttpFileCollection uploadFilCol = System.Web.HttpContext.Current.Request.Files;
            int count = uploadFilCol.Count;

            ErrorLog.ErrorRoutine(false, "Uploader:Page_Load:FileCount: " + count);

               if (count < 1)
                    return;

                //loop thru for each posted file
                for (int i = 0; i < count; i++)
                {

                    //get handle to file
                    HttpPostedFile file = uploadFilCol[i];

                    if (file.ContentLength > (int)0)    //needed?  we already checked
                    {
                        strImgPathArray[i] = string.Empty;


                        //get file name & ext
                        string fileName = Path.GetFileName(file.FileName);
                        string fileExt = Path.GetExtension(file.FileName).ToLower();

                        ErrorLog.ErrorRoutine(false,"fileName: " + fileName + " Ext: " + fileExt);

                        //check for temp dir and create if non-existent
                        if (!(Directory.Exists(Server.MapPath("..\\" + @"\tmp\"))))
                        {
                            ErrorLog.ErrorRoutine(false, "creating dir");
                            try
                            {
                                Directory.CreateDirectory(Server.MapPath("..\\" + @"\tmp\"));
                            }
                            catch (Exception ex)
                            {
                                ErrorLog.ErrorRoutine(false, "error: " + ex.Message);
                                return;

                            }
                            ErrorLog.ErrorRoutine(false, "done dir");
                        }

                        //get physical path to temp dir for upload
                        string path = Server.MapPath("..\\" + @"\tmp\");
                        ErrorLog.ErrorRoutine(false, "Path: " + path);

                        //Generate random file name 
                        //tmpFile = classes.RandomPassword.(8).ToLower();
                        BoardHunt.classes.RandomPassword oRp = new BoardHunt.classes.RandomPassword();
                        tmpFile = oRp.Generate(8);

                        //concatenate renamed file with ext
                        tmpFile = tmpFile + fileExt;

                        //add together path and file name; This is our fully qualified *temp path where the file gets uploaded
                        strImgPathArray[i] = Path.Combine(path, tmpFile);
                        //tmpStruct.tmpArray[i] = Path.Combine(path, tmpFile);
                        thmbNailPath = Path.Combine(path, "thmbNail_" + tmpFile);

                        //Upload to temp dir; we'll write to perm directory after user confirms on preview!
                        //FIXME: Check for file type and size

                        if (fileName != string.Empty)
                        {
                            //resize the image and save
                            //Create an image object from the uploaded file.

                            try
                            {
                                System.Drawing.Image UploadedImage = System.Drawing.Image.FromStream(file.InputStream);
                                //Larger Image variables
                                int maxWidth = 400;
                                int maxHeight = 400;
                                int sourceWidth = UploadedImage.Width;
                                int sourceHeight = UploadedImage.Height;
                                int sourceX = 0;
                                int sourceY = 0;
                                int destX = 0;
                                int destY = 0;
                                float nPercent = 0;
                                float nPercentW = 0;
                                float nPercentH = 0;

                                //ThumbNail variables
                                int maxWidth_T = 75;
                                int maxHeight_T = 75;
                                int destX_T = 0;
                                int destY_T = 0;
                                float nPercent_T = 0;
                                float nPercentW_T = 0;
                                float nPercentH_T = 0;

                                //Larger Image percents
                                nPercentW = ((float)maxWidth / (float)sourceWidth);
                                nPercentH = ((float)maxHeight / (float)sourceHeight);

                                //Thumbnail percents
                                nPercentW_T = ((float)maxWidth_T / (float)sourceWidth);
                                nPercentH_T = ((float)maxHeight_T / (float)sourceHeight); 

                                //Find the biggest change(smallest pct)
                                if (nPercentH < nPercentW)
                                {
                                    //Larger Image Calculations
                                    nPercent = nPercentH;
                                    destX = System.Convert.ToInt16((maxWidth -
                                                  (sourceWidth * nPercent)) / 2);

                                    //Thumbnail Calculations
                                    nPercent_T = nPercentH_T;
                                    destX_T = System.Convert.ToInt16((maxWidth_T -
                                                  (sourceWidth * nPercent_T)) / 2);
                                }
                                else
                                {
                                    //Larger Image Calculations
                                    nPercent = nPercentW;
                                    destY    = System.Convert.ToInt16((maxHeight -
                                                  (sourceHeight * nPercent)) / 2);
                                    
                                    //ThumbNail Calculations
                                    nPercent_T = nPercentW_T;
                                    destY_T    = System.Convert.ToInt16((maxWidth_T -
                                                  (sourceHeight * nPercent_T)) / 2);
                                }

                                //Larger Image Calculations
                                int destWidth  = (int)(sourceWidth * nPercent);
                                int destHeight = (int)(sourceHeight * nPercent);

                                //Smaller Image Calculations
                                int destWidth_T  = (int)(sourceWidth * nPercent_T);
                                int destHeight_T = (int)(sourceHeight * nPercent_T);

                                //create the larger bitmap
                                Bitmap bmPhoto = new Bitmap(maxWidth, maxHeight);
                                bmPhoto.SetResolution(UploadedImage.HorizontalResolution,
                                                 UploadedImage.VerticalResolution);

                                //create the thumbnail bitmap
                                Bitmap bmPhotoThmbNail = new Bitmap(maxWidth_T, maxHeight_T);
                                bmPhotoThmbNail.SetResolution(UploadedImage.HorizontalResolution,
                                                          UploadedImage.VerticalResolution);

                                //create larger graphic
                                Graphics grPhoto = Graphics.FromImage(bmPhoto);
                                grPhoto.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                grPhoto.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                                grPhoto.Clear(Color.Transparent);
                                grPhoto.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                                grPhoto.DrawImage(UploadedImage,
                                    new Rectangle(destX, destY, destWidth, destHeight),
                                    new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                                    GraphicsUnit.Pixel);

                                //create thumbnail graphic
                                Graphics grPhotoThmbNail = Graphics.FromImage(bmPhotoThmbNail);
                                grPhotoThmbNail.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                                grPhotoThmbNail.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                                grPhotoThmbNail.Clear(Color.Transparent);
                                grPhotoThmbNail.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                                grPhotoThmbNail.DrawImage(UploadedImage,
                                    new Rectangle(destX_T, destY_T, destWidth_T, destHeight_T),
                                    new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                                    GraphicsUnit.Pixel);

                                //int memberID = 0;

                                //Save the Image(s)
                                // (1) "Saves" the graphic.  It really just updates the bitmap with the contents of the graphic.  
                                // Basically saving it in memory.
                                // (2) Actually save the bitmap to the file system.

                                //Larger
                                grPhoto.Save();                  //  (1)
                                bmPhoto.Save(strImgPathArray[i]);//  (2)  .., ImageFormat.Jpeg)
                                ErrorLog.ErrorRoutine(false, "Saved Photo: " + strImgPathArray[i]);

                                //strip out the superfluous server path and just save the file name;  this was the cause of much grief as we were saving the entire path!
                                strImgPathArray[i] = Path.GetFileName(strImgPathArray[i]);

                                //Thumbnail
                                grPhotoThmbNail.Save();
                                bmPhotoThmbNail.Save(thmbNailPath);
                                ErrorLog.ErrorRoutine(false, "Saved thmbNailPath: " + thmbNailPath);

                            }
                            catch (Exception ex)
                            {
                                ErrorLog.ErrorRoutine(false, "Uploader:UpdateAllImages-Error: " + ex.Message); 
                            }

                        }
                        else
                        {
                            strImgPathArray[i] = string.Empty;
                        }
                    }
                }
        }

        public string UploadFile(byte[] f, string fileName)
        {

            return string.Empty;
            // the byte array argument contains the content of the file 

            // the string argument contains the name and extension 

            // of the file passed in the byte array 

            //try
            //{

            //    // instance a memory stream and pass the 

            //    // byte array to its constructor 

            //    MemoryStream ms = new MemoryStream(f);



            //    // instance a filestream pointing to the 

            //    // storage folder, use the original file name 

            //    // to name the resulting file 

            //    FileStream fs = new FileStream(System.Web.Hosting.HostingEnvironment.MapPath

            //                ("~/TransientStorage/") + fileName, FileMode.Create);


            //    // write the memory stream containing the original 

            //    // file as a byte array to the filestream 

            //    ms.WriteTo(fs);


            //    // clean up 

            //    ms.Close();

            //    fs.Close();

            //    fs.Dispose();


            //    // return OK if we made it this far 

            //    return "OK";

            //}

            //catch (Exception ex)
            //{

            //    // return the error message if the operation fails 

            //    return ex.Message.ToString();

            //} 


        
        }
    }
}
