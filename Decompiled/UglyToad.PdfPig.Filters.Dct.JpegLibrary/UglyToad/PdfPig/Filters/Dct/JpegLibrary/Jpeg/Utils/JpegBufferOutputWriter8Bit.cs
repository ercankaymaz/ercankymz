using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UglyToad.PdfPig.Filters.Dct.JpegLibrary.Jpeg.Utils;

internal sealed class JpegBufferOutputWriter8Bit : JpegBlockOutputWriter
{
	private readonly int _width;

	private readonly int _height;

	private readonly int _componentCount;

	private readonly Memory<byte> _output;

	public JpegBufferOutputWriter8Bit(int width, int height, int componentCount, Memory<byte> output)
	{
		if (output.Length < width * height * componentCount)
		{
			throw new ArgumentException("Destination buffer is too small.");
		}
		_width = width;
		_height = height;
		_componentCount = componentCount;
		_output = output;
	}

	public override void WriteBlock(ref short blockRef, int componentIndex, int x, int y)
	{
		int componentCount = _componentCount;
		int width = _width;
		int height = _height;
		if (x > width || y > _height)
		{
			return;
		}
		int num = Math.Min(width - x, 8);
		int num2 = Math.Min(height - y, 8);
		ref byte source = ref Unsafe.Add(ref MemoryMarshal.GetReference(_output.Span), y * width * componentCount + x * componentCount + componentIndex);
		for (int i = 0; i < num2; i++)
		{
			ref byte source2 = ref Unsafe.Add(ref source, i * width * componentCount);
			for (int j = 0; j < num; j++)
			{
				Unsafe.Add(ref source2, j * componentCount) = ClampTo8Bit(Unsafe.Add(ref blockRef, j));
			}
			blockRef = ref Unsafe.Add(ref blockRef, 8);
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static byte ClampTo8Bit(short input)
	{
		if (input > 255)
		{
			return byte.MaxValue;
		}
		if (input < 0)
		{
			return 0;
		}
		return (byte)input;
	}
}
