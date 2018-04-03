using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLapse.Core
{
    public static class ImageFormatToExtensionHelper
    {
        public static IList<string> GetExtensionsByImageFormat(ImageFormats format)
        {
            IList<string> listExtensions = new List<string>();

            switch (format)
            {
                case ImageFormats.JPG:
                    listExtensions.Add(".jpg");
                    listExtensions.Add(".jpeg");
                    listExtensions.Add(".JPG");
                    break;
                default:
                    break;
            }

            return listExtensions;
        }
    }
}
