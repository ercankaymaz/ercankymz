using System;
using System.Runtime.InteropServices;

namespace Basler.Pylon;

public interface IDataComponent : IDisposable, IImage
{
	new ImageOrientation Orientation { get; }

	long Timestamp { get; }

	new IntPtr PixelDataPointer { get; }

	new object PixelData { get; }

	new int PaddingX { get; }

	int OffsetY { get; }

	int OffsetX { get; }

	new int Height { get; }

	new int Width { get; }

	new PixelType PixelTypeValue { get; }

	ComponentType ComponentTypeValue { get; }

	new bool IsValid
	{
		[return: MarshalAs(UnmanagedType.U1)]
		get;
	}
}
