using Serilog;
using System.IO;
using Emgu.CV;
using System;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Linq;

namespace TimeLapse.Core
{
    public class TimeLapseCreater
    {
        private readonly TimeLapseCreationOptions _options;
        private readonly ILogger _logger;

        public TimeLapseCreater(TimeLapseCreationOptions options, ILogger logger)
        {
            _options = options;
            _logger = logger;
        }

        public void Create()
        {
            int sourceImageHeight = 0;
            int sourceImageWidth = 0;
            bool foundFirstImage = false;

            foreach (string fileName in Directory.GetFiles(_options.InputFolder))
            {
                _logger.Debug($"Scanning {_options.InputFolder} for first image, Looking at '{fileName}'");
                foreach (string extension in
                    ImageFormatToExtensionHelper.GetExtensionsByImageFormat(_options.InputImageFormat))
                {
                    if (fileName.EndsWith(extension))
                    {
                        _logger.Debug($"Found first image: '{fileName}'");
                        Mat firstImage = CvInvoke.Imread(Path.Combine(_options.InputFolder, fileName));
                        sourceImageHeight = firstImage.Height;
                        sourceImageWidth = firstImage.Width;
                        foundFirstImage = true;
                        break;
                    }
                }

                if (foundFirstImage)
                {
                    break;
                }
            }

            if (!foundFirstImage)
            {
                throw new InvalidDataException($"After scanning all files at {_options.InputFolder}, we didn't find any file in format {_options.InputImageFormat.ToString()}");
            }

            if (sourceImageHeight == 0 || sourceImageWidth == 0)
            {
                throw new InvalidDataException($"After scanning all files at {_options.InputFolder}, we didn't gather meaningful input image dimension");
            }
            else
            {
                _logger.Debug($"Using first image as reference: height = {sourceImageHeight}, width = {sourceImageWidth}");
            }

            int frameIndex = 0;

            using (VideoWriter videoWriter = new VideoWriter(
                Path.Combine(_options.OutputFolder, _options.OutputFileName),
                _options.FramesPerSecond,
                VideoResolutionToSizeHelper.GetSizeFromResolution(_options.TargetResolution),
                true))
            {
                DirectoryInfo info = new DirectoryInfo(_options.InputFolder);
                FileInfo[] files = info.GetFiles().OrderBy(p => p.CreationTime).ToArray();
                foreach (FileInfo file in files)
                {
                    foreach (string extension in
                        ImageFormatToExtensionHelper.GetExtensionsByImageFormat(_options.InputImageFormat))
                    {
                        if (file.Name.EndsWith(extension))
                        {
                            _logger.Debug($"Found {frameIndex}: '{file.Name}'");
                            Mat image = CvInvoke.Imread(Path.Combine(_options.InputFolder, file.Name));
                            CvInvoke.Resize(image, image, VideoResolutionToSizeHelper.GetSizeFromResolution(_options.TargetResolution), 0, 0, Inter.Linear);
                            videoWriter.Write(image);
                            frameIndex++;
                        }
                    }
                }

                CvInvoke.DestroyAllWindows();
            }

            _logger.Debug($"End of TimeLapse creation. {frameIndex} frames added to output video '{_options.OutputFileName}'");
        }
    }
}
