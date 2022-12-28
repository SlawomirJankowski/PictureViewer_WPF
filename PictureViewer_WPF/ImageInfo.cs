using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace PictureViewer_WPF
{
    internal static class ImageInfo
    {
        public static string ShowImageProperties(string imageLocationPath)
        {
            if (string.IsNullOrEmpty(imageLocationPath))
            {
                return string.Empty;
            }
            
            Image img = Image.FromStream(File.OpenRead(imageLocationPath), false, false);
            ImageFormat format = img.RawFormat;

            string imageDetailsString =
                $"Image Type : {GetImageFormat(format)} \n" +
                $"Image width : {img.Width} px. \n" +
                $"Image height : {img.Height} px \n" +
                $"Image resolution : {img.VerticalResolution}px * {img.HorizontalResolution}px \n" +
                $"Image Pixel depth : {Image.GetPixelFormatSize(img.PixelFormat)}\n";

            return imageDetailsString;
        }

        private static string GetImageFormat(ImageFormat format)
        {
            var formatGuid = format.Guid.ToString().Remove(8);
            
            switch (formatGuid)
            {
                case "b96b3caa":
                    return "Memory BMP - image was constructed from a memory bitmap.";
                case "b96b3cab":
                    return " Microsoft Windowsbitmap (BMP) format.";
                case "b96b3cad":
                    return "Windows Metafile Format (WMF) format.";
                case "b96b3cac":
                    return "Enhanced Metafile(EMF) format.";
                case "b96b3cae":
                    return "JPEG format.";
                case "b96b3caf":
                    return "Portable Network Graphics (PNG) format.";
                case "b96b3cb0":
                    return "Graphics Interchange Format (GIF) format.";
                case "b96b3cb1":
                    return "Tagged Image File Format (TIFF) format.";
                case "b96b3cb2":
                    return "Exif(Exchangeable Image File) format.";
                case "b96b3cb3":
                    return " Photo CD format.";
                case "b96b3cb4":
                    return "Flash PIX format.";
                case "b96b3cb5":
                    return "Icon format.";
            }
            return "Format undefined.";
        }
    }
}
