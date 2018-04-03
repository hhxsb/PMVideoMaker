using System;
using TimeLapse.Core;
using Serilog;

namespace TimeLapse.CL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TimeLapseCreationOptions options = new TimeLapseCreationOptions();

            options.InputFolder = "<Input folder>";
            options.InputImageFormat = ImageFormats.JPG;
            options.OutputFolder = "C:/Projects/Video/Timelapse";
            options.OutputFileName = $"TimeLapse_{DateTime.Now.ToString("yyyyMMddHHmmss")}.mp4";
            options.OutputVideoFormat = VideoFormats.MP4;
            options.FramesPerSecond = 24;
            options.TargetResolution = VideoResolutions.Resolution1080P;

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            TimeLapseCreater timeLapseCreater = new TimeLapseCreater(options, Log.Logger);
            timeLapseCreater.Create();

            //Wait for user input before closing.
            Console.WriteLine("TimeLapse CL main workflow finished. Press ANY key to exit.");
            Console.ReadLine();
        }
    }
}
