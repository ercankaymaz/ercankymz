using System;
using System.Numerics;
using SixLabors.ImageSharp.Memory;
using SixLabors.ImageSharp.PixelFormats;

namespace SixLabors.ImageSharp.Formats.Tiff.PhotometricInterpretation;

internal class BlackIsZero32FloatTiffColor<TPixel> : TiffBaseColorDecoder<TPixel> where TPixel : unmanaged, IPixel<TPixel>
{
	private readonly bool isBigEndian;

	public BlackIsZero32FloatTiffColor(bool isBigEndian)
	{
		this.isBigEndian = isBigEndian;
	}

	public override void Decode(ReadOnlySpan<byte> data, Buffer2D<TPixel> pixels, int left, int top, int width, int height)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		TPixel val = default(TPixel);
		val.FromScaledVector4(Vector4.Zero);
		Span<byte> span = stackalloc byte[4];
		int num = 0;
		Vector4 vector = default(Vector4);
		Vector4 vector2 = default(Vector4);
		for (int i = top; i < top + height; i++)
		{
			Span<TPixel> span2 = pixels.DangerousGetRowSpan(i).Slice(left, width);
			if (isBigEndian)
			{
				for (int j = 0; j < span2.Length; j++)
				{
					data.Slice(num, 4).CopyTo(span);
					MemoryExtensions.Reverse<byte>(span);
					float num2 = BitConverter.ToSingle(span);
					num += 4;
					((Vector4)(ref vector))._002Ector(num2, num2, num2, 1f);
					val.FromScaledVector4(vector);
					span2[j] = val;
				}
			}
			else
			{
				for (int k = 0; k < span2.Length; k++)
				{
					float num3 = BitConverter.ToSingle(data.Slice(num, 4));
					num += 4;
					((Vector4)(ref vector2))._002Ector(num3, num3, num3, 1f);
					val.FromScaledVector4(vector2);
					span2[k] = val;
				}
			}
		}
	}
}
