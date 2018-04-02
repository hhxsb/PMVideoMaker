using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLapse.Core
{
    public class TimeLapseCreationOptions
    {
        public string InputFolder { get; set; }

        public string InputFileExtensions { get; set; }

        public string OutputFolder { get; set; }

        public string OutputFileName { get; set; }

        public int FramesPerSecond { get; set; }
    }
}
