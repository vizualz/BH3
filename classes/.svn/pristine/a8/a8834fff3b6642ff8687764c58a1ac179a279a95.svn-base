using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace BoardHunt.classes
{
    public class Image
    {
    }

/*
* Upload any/all images
*/
        //private classes.BoardItem UpLoadAllImages(classes.BoardItem bItem, string[] strImgPathArray)
        //{
        //    string tmpFile;
        //    string thmbNailPath;
        //    string userDir = "";

        //    //get user dir
        //    userDir = Session["userDir"].ToString();

        //        //Collect files names, iterate through each and update accordingly
        //        HttpFileCollection uploadFilCol = System.Web.HttpContext.Current.Request.Files;
        //        int count = uploadFilCol.Count;

        //        //loop thru for each posted file
        //        for (int i = 0; i < count; i++)
        //        {

        //            //get handle to file
        //            HttpPostedFile file = uploadFilCol[i];

        //            if (file.ContentLength > (int)0)
        //            {

        //                //get file name & ext
        //                string fileName = Path.GetFileName(file.FileName);
        //                string fileExt = Path.GetExtension(file.FileName).ToLower();

        //                //check for temp dir and create if non-existent
        //                if (!(Directory.Exists(Server.MapPath(".\\" + @"\users\" + userDir + @"\temp\"))))
        //                {
        //                    Directory.CreateDirectory(Server.MapPath(".\\" + @"\users\" + userDir + @"\temp\"));
        //                }

        //                //get physical path to temp dir for upload
        //                string path = Server.MapPath(".\\" + @"\users\" + userDir + @"\temp\");

        //                //Generate random file name 
        //                tmpFile = GenerateRandomString(8).ToLower();

        //                //concatenate renamed file with ext
        //                tmpFile = tmpFile + fileExt;

        //                //add together path and file name; This is our fully qualified *temp path where the file gets uploaded
        //                strImgPathArray[i] = Path.Combine(path, tmpFile);
        //                //tmpStruct.tmpArray[i] = Path.Combine(path, tmpFile);
        //                thmbNailPath = Path.Combine(path, "thmbNail_" + tmpFile);

        //                //Upload to temp dir; we'll write to perm directory after user confirms on preview!
        //                //FIXME: Check for file type and size

        //                if (fileName != string.Empty)
        //                {
        //                    //resize the image and save
        //                    //Create an image object from the uploaded file.

        //                    try
        //                    {
        //                        System.Drawing.Image UploadedImage = System.Drawing.Image.FromStream(file.InputStream);
        //                        //Larger Image variables
        //                        int maxWidth = 400;
        //                        int maxHeight = 400;
        //                        int sourceWidth = UploadedImage.Width;
        //                        int sourceHeight = UploadedImage.Height;
        //                        int sourceX = 0;
        //                        int sourceY = 0;
        //                        int destX = 0;
        //                        int destY = 0;
        //                        float nPercent = 0;
        //                        float nPercentW = 0;
        //                        float nPercentH = 0;

        //                        //ThumbNail variables
        //                        int maxWidth_T = 75;
        //                        int maxHeight_T = 75;
        //                        int destX_T = 0;
        //                        int destY_T = 0;
        //                        float nPercent_T = 0;
        //                        float nPercentW_T = 0;
        //                        float nPercentH_T = 0;

        //                        //Larger Image percents
        //                        nPercentW = ((float)maxWidth / (float)sourceWidth);
        //                        nPercentH = ((float)maxHeight / (float)sourceHeight);

        //                        //Thumbnail percents
        //                        nPercentW_T = ((float)maxWidth_T / (float)sourceWidth);
        //                        nPercentH_T = ((float)maxHeight_T / (float)sourceHeight); 

        //                        //Find the biggest change(smallest pct)
        //                        if (nPercentH < nPercentW)
        //                        {
        //                            //Larger Image Calculations
        //                            nPercent = nPercentH;
        //                            destX = System.Convert.ToInt16((maxWidth -
        //                                          (sourceWidth * nPercent)) / 2);

        //                            //Thumbnail Calculations
        //                            nPercent_T = nPercentH_T;
        //                            destX_T = System.Convert.ToInt16((maxWidth_T -
        //                                          (sourceWidth * nPercent_T)) / 2);
        //                        }
        //                        else
        //                        {
        //                            //Larger Image Calculations
        //                            nPercent = nPercentW;
        //                            destY    = System.Convert.ToInt16((maxHeight -
        //                                          (sourceHeight * nPercent)) / 2);
                                    
        //                            //ThumbNail Calculations
        //                            nPercent_T = nPercentW_T;
        //                            destY_T    = System.Convert.ToInt16((maxWidth_T -
        //                                          (sourceHeight * nPercent_T)) / 2);
        //                        }

        //                        //Larger Image Calculations
        //                        int destWidth  = (int)(sourceWidth * nPercent);
        //                        int destHeight = (int)(sourceHeight * nPercent);

        //                        //Smaller Image Calculations
        //                        int destWidth_T  = (int)(sourceWidth * nPercent_T);
        //                        int destHeight_T = (int)(sourceHeight * nPercent_T);

        //                        //create the larger bitmap
        //                        Bitmap bmPhoto = new Bitmap(maxWidth, maxHeight);
        //                        bmPhoto.SetResolution(UploadedImage.HorizontalResolution,
        //                                         UploadedImage.VerticalResolution);

        //                        //create the thumbnail bitmap
        //                        Bitmap bmPhotoThmbNail = new Bitmap(maxWidth_T, maxHeight_T);
        //                        bmPhotoThmbNail.SetResolution(UploadedImage.HorizontalResolution,
        //                                                  UploadedImage.VerticalResolution);

        //                        //create larger graphic
        //                        Graphics grPhoto = Graphics.FromImage(bmPhoto);
        //                        grPhoto.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //                        grPhoto.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        //                        grPhoto.Clear(Color.Transparent);
        //                        grPhoto.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

        //                        grPhoto.DrawImage(UploadedImage,
        //                            new Rectangle(destX, destY, destWidth, destHeight),
        //                            new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
        //                            GraphicsUnit.Pixel);

        //                        //create thumbnail graphic
        //                        Graphics grPhotoThmbNail = Graphics.FromImage(bmPhotoThmbNail);
        //                        grPhotoThmbNail.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //                        grPhotoThmbNail.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
        //                        grPhotoThmbNail.Clear(Color.Transparent);
        //                        grPhotoThmbNail.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

        //                        grPhotoThmbNail.DrawImage(UploadedImage,
        //                            new Rectangle(destX_T, destY_T, destWidth_T, destHeight_T),
        //                            new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
        //                            GraphicsUnit.Pixel);

        //                        //int memberID = 0;

        //                        //Save the Image(s)
        //                        // (1) "Saves" the graphic.  It really just updates the bitmap with the contents of the graphic.  
        //                        // Basically saving it in memory.
        //                        // (2) Actually save the bitmap to the file system.

        //                        //Larger
        //                        grPhoto.Save();                  //  (1)
        //                        bmPhoto.Save(strImgPathArray[i]);//  (2)  .., ImageFormat.Jpeg)
                                
        //                        //strip out the superfluous server path and just save the file name;  this was the cause of much grief as we were saving the entire path!
        //                        strImgPathArray[i] = Path.GetFileName(strImgPathArray[i]);

        //                        //Thumbnail
        //                        grPhotoThmbNail.Save();
        //                        bmPhotoThmbNail.Save(thmbNailPath);

        //                        //Find out who is set to "change" or "add" so we know who to update
        //                        //  - We call the clearSelection() to let ourselves know that index has been processed
        //                        //TODO: append  (&& File1.Value.Length>0)
        //                        if (rdoImgMgr1.SelectedValue == "Change" || rdoImgMgr1.SelectedValue == "Add")
        //                        {

        //                            bItem.ImgPath1 = strImgPathArray[i];
        //                            rdoImgMgr1.ClearSelection();

        //                        }
        //                        else if (rdoImgMgr2.SelectedValue == "Change" || rdoImgMgr2.SelectedValue == "Add")
        //                        {

        //                            bItem.ImgPath2 = strImgPathArray[i];
        //                            rdoImgMgr2.ClearSelection();

        //                        }
        //                        else if (rdoImgMgr3.SelectedValue == "Change" || rdoImgMgr2.SelectedValue == "Add")
        //                        {


        //                            bItem.ImgPath3 = strImgPathArray[i];
        //                            rdoImgMgr3.ClearSelection();
        //                        }
        //                        else
        //                        {
        //                            if (rdoImgMgr4.SelectedValue == "Change" || rdoImgMgr2.SelectedValue == "Add")
        //                            {

        //                                bItem.ImgPath4 = strImgPathArray[i];
        //                                rdoImgMgr4.ClearSelection();
        //                            }
        //                        }

        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        ErrorLog.ErrorRoutine(false, "Post_Item:UpdateAllImages-Error: " + ex.Message); 
        //                        lblStatus.Text = "Resize/Save Error!";
        //                    }

        //                }
        //                else
        //                {
        //                    strImgPathArray[i] = string.Empty;
        //                }
        //            }
        //        }
        //    return bItem;
        
        //}//end function
}
