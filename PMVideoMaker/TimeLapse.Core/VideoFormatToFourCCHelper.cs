using Emgu.CV;
using System;

namespace TimeLapse.Core
{
    public static class VideoFormatToFourCCHelper
    {
        public static int GetFourCC(VideoFormats format)
        {
            // Looked up from https://www.fourcc.org/codecs.php
            switch (format)
            {
                case VideoFormats.MP4:
                    return VideoWriter.Fourcc('M', 'P', '4', '2');
                default:
                    throw new NotImplementedException($"Video format {format} is not yet supported. Please implement first!!");
            }
        }
    }
}
