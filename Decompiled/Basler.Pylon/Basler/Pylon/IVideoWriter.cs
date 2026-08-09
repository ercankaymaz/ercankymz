using System;
using System.Runtime.InteropServices;

namespace Basler.Pylon;

public interface IVideoWriter : IDisposable
{
	bool IsOpen
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get;
	}

	void Create(string filename, double playbackFramesPerSecond, ICamera camera);

	void Create(string filename, double playbackFramesPerSecond, PixelType pixelType, int width, int height);

	void Close();

	[return: MarshalAs(UnmanagedType.U1)]
	bool CanWriteWithoutConversion(PixelType pixelType, int width, int height, int paddingX, ImageOrientation orientation);

	[return: MarshalAs(UnmanagedType.U1)]
	bool CanWriteWithoutConversion(IImage image);

	void Write<T>(T[] pixelData, PixelType pixelType, int width, int height, int paddingX, ImageOrientation orientation);

	void Write(IImage image);
}
