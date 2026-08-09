using System.Drawing;
using System.IO;
using ImageProcessor;
using ImageProcessor.Imaging.Formats;

namespace buCore;

public class buImageProcessor
{
	public static void LoadImage(string ImageName, ref Image returnImage, ref byte[] photoBytes)
	{
		byte[] buffer = File.ReadAllBytes(ImageName);
		using MemoryStream stream = new MemoryStream(buffer);
		using MemoryStream memoryStream = new MemoryStream();
		using ImageFactory imageFactory = new ImageFactory(preserveExifData: true);
		imageFactory.Load(stream);
		imageFactory.Save(memoryStream);
		returnImage = Image.FromStream(memoryStream);
		photoBytes = memoryStream.ToArray();
	}

	public static void PhoteBytesToImage(byte[] photoBytes, ref Image returnImage)
	{
		using MemoryStream stream = new MemoryStream(photoBytes);
		using MemoryStream stream2 = new MemoryStream();
		using ImageFactory imageFactory = new ImageFactory(preserveExifData: true);
		imageFactory.Load(stream);
		imageFactory.Save(stream2);
		returnImage = Image.FromStream(stream2);
	}

	public static void Resize(byte[] photoBytes, Size newSize, ref byte[] returnPhotoBytes)
	{
		new JpegFormat().Quality = 70;
		Size size = new Size(150, 0);
		using MemoryStream stream = new MemoryStream(photoBytes);
		using MemoryStream memoryStream = new MemoryStream();
		using ImageFactory imageFactory = new ImageFactory(preserveExifData: true);
		imageFactory.Load(stream);
		imageFactory.Resize(newSize);
		imageFactory.Save(memoryStream);
		returnPhotoBytes = memoryStream.ToArray();
	}
}
