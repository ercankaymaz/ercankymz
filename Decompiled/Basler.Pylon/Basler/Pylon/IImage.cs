using System;
using System.Runtime.InteropServices;

namespace Basler.Pylon;

public interface IImage
{
	ImageOrientation Orientation { get; }

	int PaddingX { get; }

	int Height { get; }

	int Width { get; }

	PixelType PixelTypeValue { get; }

	IntPtr PixelDataPointer { get; }

	object PixelData { get; }

	bool IsValid
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get;
	}
}
