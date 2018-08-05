using Gif.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace Stromatolite.Helpers
{
    public static class ImageHelpers
    {
        public static void ConvertFile(string fileName, string fileBack, string fileFront, string path, string retFile)
        {
            string fN = fileName.Substring(fileName.LastIndexOf('\\'));

            string fType = fN.Substring(fN.LastIndexOf('.')).ToLower();

            string erlog;

            if (fType == ".gif")
            {
                var images = GetImages(fileName);
                AnimatedGifEncoder e = new AnimatedGifEncoder();
            }


            using (Image backImg = Image.FromFile(fileBack), frontImg = Image.FromFile(fileFront), img = Image.FromFile(fileName), newImg = new Bitmap(400, 250))
            {


                decimal p1 = (decimal)newImg.Height / (decimal)img.Height;
                decimal p2 = (decimal)newImg.Width/ (decimal)img.Width;

                var shift1 = 0;
                var shift2 = 0;
                decimal newHeight = img.Height;
                decimal newWidth = img.Width;

                if (p1 > p2)
                {
                    var c2 = (decimal)img.Width * p1;
                    var s2 = (c2 - (decimal)newImg.Width) / 2;

                    newWidth = (decimal)newImg.Width / p1;
                    shift1 = (int)(s2 / p1);
                }
                else
                {
                    var c1 = (decimal)img.Height * p2;
                    var s1 = (c1 - (decimal)newImg.Height) / 2;

                    newHeight = (decimal)newImg.Height / p2;
                    shift2 = (int)(s1 / p2);
                }


                using (Graphics gr = Graphics.FromImage(newImg))
                {
                    try
                    {
                        //gr.DrawImage(backImg, new Point(0, 0));
                        gr.DrawImage(img, new RectangleF(0, 0, 400, 250),new RectangleF(shift1, shift2, (int)newWidth, (int)newHeight),GraphicsUnit.Pixel);
                        //gr.DrawImage(frontImg, new Point(0, 0));
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
                try
                {
                    ImageFormat format;
                    switch (fType)
                    {
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                        case ".emf":
                            format = ImageFormat.Emf;
                            break;
                        case ".gif":
                            format = ImageFormat.Gif;
                            break;
                        case ".png":
                            format = ImageFormat.Png;
                            break;
                        case ".tiff":
                            format = ImageFormat.Tiff;
                            break;
                        default:
                            format = ImageFormat.Jpeg;
                            break;
                    }


                    newImg.Save(Path.Combine(path, retFile), format);
                    //Image tumb1 = newImg.GetThumbnailImage(260, 260, null, IntPtr.Zero);
                    //tumb1.Save(Path.Combine(path.Replace("big", "mid"), retFile), format);
                    //Image tumb2 = newImg.GetThumbnailImage(137, 137, null, IntPtr.Zero);
                    //tumb2.Save(Path.Combine(path.Replace("big", "sm"), retFile), format);
                }
                catch (Exception e)
                {

                }

            }

        }

        public static void ConvertFile2(string fileName, string fileBack, string fileFront, string path, string retFile)
        {
            string fN = fileName.Substring(fileName.LastIndexOf('\\'));

            string fType = fN.Substring(fN.LastIndexOf('.')).ToLower();

            string erlog;

            if (fType == ".gif")
            {
                var images = GetImages(fileName);
                AnimatedGifEncoder e = new AnimatedGifEncoder();
            }


            using (Image backImg = Image.FromFile(fileBack), frontImg = Image.FromFile(fileFront), img = Image.FromFile(fileName), newImg = new Bitmap(600, 600))
            {


                decimal p1 = (decimal)newImg.Height / (decimal)img.Height;
                decimal p2 = (decimal)newImg.Width / (decimal)img.Width;

                var shift1 = 0;
                var shift2 = 0;
                decimal newHeight = img.Height;
                decimal newWidth = img.Width;

                if (p1 > p2)
                {
                    var c2 = (decimal)img.Width * p1;
                    var s2 = (c2 - (decimal)newImg.Width) / 2;

                    newWidth = (decimal)newImg.Width / p1;
                    shift1 = (int)(s2 / p1);
                }
                else
                {
                    var c1 = (decimal)img.Height * p2;
                    var s1 = (c1 - (decimal)newImg.Height) / 2;

                    newHeight = (decimal)newImg.Height / p2;
                    shift2 = (int)(s1 / p2);
                }


                using (Graphics gr = Graphics.FromImage(newImg))
                {
                    try
                    {
                        //gr.DrawImage(backImg, new Point(0, 0));
                        gr.DrawImage(img, new RectangleF(0, 0, 600, 600), new RectangleF(shift1, shift2, (int)newWidth, (int)newHeight), GraphicsUnit.Pixel);
                        //gr.DrawImage(frontImg, new Point(0, 0));
                    }
                    catch (Exception)
                    {
                        throw;
                    }

                }
                try
                {
                    ImageFormat format;
                    switch (fType)
                    {
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                        case ".emf":
                            format = ImageFormat.Emf;
                            break;
                        case ".gif":
                            format = ImageFormat.Gif;
                            break;
                        case ".png":
                            format = ImageFormat.Png;
                            break;
                        case ".tiff":
                            format = ImageFormat.Tiff;
                            break;
                        default:
                            format = ImageFormat.Jpeg;
                            break;
                    }


                    newImg.Save(Path.Combine(path, retFile), format);
                    //Image tumb1 = newImg.GetThumbnailImage(260, 260, null, IntPtr.Zero);
                    //tumb1.Save(Path.Combine(path.Replace("big", "mid"), retFile), format);
                    //Image tumb2 = newImg.GetThumbnailImage(137, 137, null, IntPtr.Zero);
                    //tumb2.Save(Path.Combine(path.Replace("big", "sm"), retFile), format);
                }
                catch (Exception e)
                {

                }

            }

        }


        private static IEnumerable<Bitmap> GetImages(String file)
        {
            using (var gifImage = Image.FromFile(file))
            {
                var dimension = new FrameDimension(gifImage.FrameDimensionsList[0]); // GUID
                var frameCount = gifImage.GetFrameCount(dimension);
                for (int i = 0; i < frameCount; i++)
                {
                    gifImage.SelectActiveFrame(dimension, i);
                    yield return (Bitmap)gifImage.Clone();
                }
            }
        }


    }
}