using System;
using TimeLapse.Core;
using Serilog;

namespace TimeLapse.CLTool
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TimeLapseCreationOptions options = new TimeLapseCreationOptions();

            options.InputFolder = "C:/Users/heyin/OneDrive/Pictures/2018-03";
            options.InputImageFormat = ImageFormats.JPG;
            options.OutputFolder = "C:/Projects/Video/Timelapse";
            options.OutputFileName = $"TimeLapse_{DateTime.Now.ToString("yyyyMMddHHmmss")}";
            options.FramesPerSecond = 24;

            TimeLapseCreater timeLapseCreater = new TimeLapseCreater(options, Log);

            //Wait for user input before closing.
            Console.WriteLine("TimeLapse CL main workflow finished. Press ANY key to exit.");
            Console.ReadLine();
        }
    }
}
