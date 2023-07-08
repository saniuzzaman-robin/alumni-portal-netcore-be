using System.Text;
using System.Drawing.Imaging;
using System.Net.Mime;
using System.Drawing;
using Imgur.API.Endpoints;
using Imgur.API.Models;
using Imgur.API;
using System.Diagnostics;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Net;
using AlumniPortal.Application.Contract;

namespace AlumniPortal.Application.Implementation
{
    public class ImgurImageConverterService : IImageConverterService
    {
        private const string ImgurApiEndpoint = "https://api.imgur.com/3/image";
        private const string ClientId = "663c1333a496a63";
        public async Task<string> ConvertAsync(string imageUri)
        {
            string imageUrl = imageUri;

            try
            {
                // Download the image from the URL
                byte[] imageBytes = await DownloadImageAsync(imageUrl);

                // Compress and resize the image
                byte[] compressedImageBytes = CompressAndResizeImage(imageBytes, 800, 600, 50); // Adjust the dimensions and quality as needed

                // Upload the compressed image to Imgur
                return await UploadImageToImgur(compressedImageBytes);

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return "failed to upload image";
            }
        }

        static async Task<byte[]> DownloadImageAsync(string imageUri)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetByteArrayAsync(imageUri);
            }
        }

        static byte[] CompressAndResizeImage(byte[] imageBytes, int maxWidth, int maxHeight, int quality)
        {
            using (MemoryStream memoryStream = new MemoryStream(imageBytes))
            {
                using (System.Drawing.Image image = System.Drawing.Image.FromStream(memoryStream))
                {
                    int newWidth, newHeight;
                    if (image.Width > maxWidth || image.Height > maxHeight)
                    {
                        double aspectRatio = (double)image.Width / image.Height;

                        if (image.Width > image.Height)
                        {
                            newWidth = maxWidth;
                            newHeight = (int)Math.Round(newWidth / aspectRatio);
                        }
                        else
                        {
                            newHeight = maxHeight;
                            newWidth = (int)Math.Round(newHeight * aspectRatio);
                        }
                    }
                    else
                    {
                        newWidth = image.Width;
                        newHeight = image.Height;
                    }

                    using (Bitmap resizedImage = new Bitmap(newWidth, newHeight))
                    {
                        using (Graphics graphics = Graphics.FromImage(resizedImage))
                        {
                            graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                            graphics.DrawImage(image, 0, 0, newWidth, newHeight);
                        }

                        using (MemoryStream outputMemoryStream = new MemoryStream())
                        {
                            EncoderParameters encoderParameters = new EncoderParameters(1);
                            encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

                            ImageCodecInfo jpegCodecInfo = GetEncoderInfo(ImageFormat.Jpeg);

                            resizedImage.Save(outputMemoryStream, jpegCodecInfo, encoderParameters);
                            return outputMemoryStream.ToArray();
                        }
                    }
                }
            }
        }

        static ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        static async Task<string> UploadImageToImgur(byte[] imageBytes)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Client-ID {ClientId}");

                MultipartFormDataContent form = new MultipartFormDataContent();
                form.Add(new ByteArrayContent(imageBytes), "image", "image.png");

                HttpResponseMessage response = await client.PostAsync(ImgurApiEndpoint, form);
                string responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // Extract the uploaded image URL from the response
                    dynamic jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(responseContent);
                    string imageUrl = jsonResponse.data.link;
                    return imageUrl;
                }
                else
                {
                    // Handle error response
                    Console.WriteLine($"Image upload failed. Error: {responseContent}");
                    return null;
                }
            }
        }
    }
}
