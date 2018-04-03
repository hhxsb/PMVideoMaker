using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLapse.Core
{
    public static class VideoResolutionToSizeHelper
    {
        public static Size GetSizeFromResolution(VideoResolutions resolution)
        {
            switch (resolution)
            {
                case VideoResolutions.Resolution1080P:
                    return new Size(1920, 1080);
                default:
                    throw new NotImplementedException($"Resolution {resolution} is not yet supported. Please implement first!!");
            }
        }
    }
}
