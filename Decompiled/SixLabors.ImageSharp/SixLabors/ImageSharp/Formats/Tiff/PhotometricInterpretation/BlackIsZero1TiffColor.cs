using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SixLabors.ImageSharp.Memory;
using SixLabors.ImageSharp.PixelFormats;

namespace SixLabors.ImageSharp.Formats.Tiff.PhotometricInterpretation;

internal class BlackIsZero1TiffColor<TPixel> : TiffBaseColorDecoder<TPixel> where TPixel : unmanaged, IPixel<TPixel>
{
	public override void Decode(ReadOnlySpan<byte> data, Buffer2D<TPixel> pixels, int left, int top, int width, int height)
	{
		nuint num = 0u;
		TPixel val = default(TPixel);
		TPixel val2 = default(TPixel);
		val.FromRgba32(Color.Black);
		val2.FromRgba32(Color.White);
		ref byte reference = ref MemoryMarshal.GetReference<byte>(data);
		for (nuint num2 = (uint)top; num2 < (uint)(top + height); num2++)
		{
			ref TPixel reference2 = ref MemoryMarshal.GetReference<TPixel>(pixels.DangerousGetRowSpan((int)num2));
			for (nuint num3 = (uint)left; num3 < (uint)(left + width); num3 += 8)
			{
				byte b = Unsafe.Add(ref reference, num++);
				UIntPtr uIntPtr = Math.Min((uint)(left + width) - num3, (nuint)8u);
				if (uIntPtr == (UIntPtr)(nuint)8u)
				{
					int num4 = (b >> 7) & 1;
					Unsafe.Add(ref reference2, num3) = ((num4 == 0) ? val : val2);
					num4 = (b >> 6) & 1;
					Unsafe.Add(ref reference2, num3 + 1) = ((num4 == 0) ? val : val2);
					num4 = (b >> 5) & 1;
					Unsafe.Add(ref reference2, num3 + 2) = ((num4 == 0) ? val : val2);
					num4 = (b >> 4) & 1;
					Unsafe.Add(ref reference2, num3 + 3) = ((num4 == 0) ? val : val2);
					num4 = (b >> 3) & 1;
					Unsafe.Add(ref reference2, num3 + 4) = ((num4 == 0) ? val : val2);
					num4 = (b >> 2) & 1;
					Unsafe.Add(ref reference2, num3 + 5) = ((num4 == 0) ? val : val2);
					num4 = (b >> 1) & 1;
					Unsafe.Add(ref reference2, num3 + 6) = ((num4 == 0) ? val : val2);
					num4 = b & 1;
					Unsafe.Add(ref reference2, num3 + 7) = ((num4 == 0) ? val : val2);
				}
				else
				{
					for (nuint num5 = 0u; num5 < (nuint)uIntPtr; num5++)
					{
						int num6 = (b >> 7 - (int)num5) & 1;
						Unsafe.Add(ref reference2, num3 + num5) = ((num6 == 0) ? val : val2);
					}
				}
			}
		}
	}
}
