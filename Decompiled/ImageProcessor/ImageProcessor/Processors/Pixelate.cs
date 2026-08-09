using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using ImageProcessor.Common.Exceptions;
using ImageProcessor.Common.Extensions;
using ImageProcessor.Imaging;

namespace ImageProcessor.Processors;

public class Pixelate : IGraphicsProcessor
{
	public dynamic DynamicParameter { get; set; }

	public Dictionary<string, string> Settings { get; set; }

	public Pixelate()
	{
		Settings = new Dictionary<string, string>();
	}

	public Image ProcessImage(ImageFactory factory)
	{
		Bitmap bitmap = null;
		Image image = factory.Image;
		try
		{
			Tuple<int, Rectangle?> tuple = DynamicParameter;
			int size = tuple.Item1;
			Rectangle rectangle = tuple.Item2 ?? new Rectangle(0, 0, image.Width, image.Height);
			int x = rectangle.X;
			int y = rectangle.Y;
			int offset = size / 2;
			int width = rectangle.Width;
			int height = rectangle.Height;
			int maxWidth = image.Width;
			int maxHeight = image.Height;
			bitmap = new Bitmap(image);
			bitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);
			FastBitmap fastBitmap = new FastBitmap(bitmap);
			try
			{
				IEnumerable<int> source = y.SteppedRange((int i) => i < y + height && i < maxHeight, size);
				Parallel.ForEach(source, delegate(int j)
				{
					for (int i = x; i < x + width && i < maxWidth; i += size)
					{
						int num = offset;
						int num2 = offset;
						while (j + num2 >= maxHeight)
						{
							num2--;
						}
						while (i + num >= maxWidth)
						{
							num--;
						}
						Color pixel = fastBitmap.GetPixel(i + num, j + num2);
						for (int k = j; k < j + size && k < maxHeight; k++)
						{
							for (int l = i; l < i + size && l < maxWidth; l++)
							{
								fastBitmap.SetPixel(l, k, pixel);
							}
						}
					}
				});
			}
			finally
			{
				if (fastBitmap != null)
				{
					((IDisposable)fastBitmap).Dispose();
				}
			}
			image.Dispose();
			return bitmap;
		}
		catch (Exception innerException)
		{
			bitmap?.Dispose();
			throw new ImageProcessingException("Error processing image with " + GetType().Name, innerException);
		}
	}
}
