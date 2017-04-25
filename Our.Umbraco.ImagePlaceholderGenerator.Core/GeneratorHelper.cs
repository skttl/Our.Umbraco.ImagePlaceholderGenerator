using ImageProcessor;
using ImageProcessor.Imaging;
using ImageProcessor.Imaging.Formats;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.IO;

namespace Our.Umbraco.ImagePlaceholderGenerator.Core
{
    public class GeneratorHelper
    {
		private readonly MediaFileSystem _mediaFileSystem;

		public GeneratorHelper()
		{
			_mediaFileSystem = FileSystemProviderManager.Current.GetFileSystemProvider<MediaFileSystem>();
		}

		public string CreateImagePlaceholder(string fullPath, int maxWidth = 4, int maxHeight = 4)
		{
			using (MemoryStream outStream = new MemoryStream())
			{
				using (ImageFactory imageFactory = new ImageFactory(false))
				{
					var image = imageFactory.Load(fullPath);

					var resizeLayer = new ResizeLayer(new System.Drawing.Size(maxWidth, maxHeight), ResizeMode.Max);

					image.Resize(resizeLayer);
					image.Format(new PngFormat());
					image.Save(outStream);
				}

				var bytes = new Byte[outStream.Length];
				outStream.Read(bytes, 0, bytes.Length);
				return "data:image/png;base64," + Convert.ToBase64String(bytes);
			}
		}
    }
}
