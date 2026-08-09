using System;
using System.Numerics;
using SixLabors.ImageSharp.Formats.Tiff.Utils;
using SixLabors.ImageSharp.Memory;
using SixLabors.ImageSharp.PixelFormats;

namespace SixLabors.ImageSharp.Formats.Tiff.PhotometricInterpretation;

internal class RgbaTiffColor<TPixel> : TiffBaseColorDecoder<TPixel> where TPixel : unmanaged, IPixel<TPixel>
{
	private readonly float rFactor;

	private readonly float gFactor;

	private readonly float bFactor;

	private readonly float aFactor;

	private readonly ushort bitsPerSampleR;

	private readonly ushort bitsPerSampleG;

	private readonly ushort bitsPerSampleB;

	private readonly ushort bitsPerSampleA;

	private readonly TiffExtraSampleType? extraSamplesType;

	public RgbaTiffColor(TiffExtraSampleType? extraSampleType, TiffBitsPerSample bitsPerSample)
	{
		bitsPerSampleR = bitsPerSample.Channel0;
		bitsPerSampleG = bitsPerSample.Channel1;
		bitsPerSampleB = bitsPerSample.Channel2;
		bitsPerSampleA = bitsPerSample.Channel3;
		rFactor = (float)(1 << (int)bitsPerSampleR) - 1f;
		gFactor = (float)(1 << (int)bitsPerSampleG) - 1f;
		bFactor = (float)(1 << (int)bitsPerSampleB) - 1f;
		aFactor = (float)(1 << (int)bitsPerSampleA) - 1f;
		extraSamplesType = extraSampleType;
	}

	public override void Decode(ReadOnlySpan<byte> data, Buffer2D<TPixel> pixels, int left, int top, int width, int height)
	{
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		TPixel val = default(TPixel);
		BitReader bitReader = new BitReader(data);
		bool flag = extraSamplesType.HasValue && extraSamplesType == TiffExtraSampleType.AssociatedAlphaData;
		Vector4 vector = default(Vector4);
		for (int i = top; i < top + height; i++)
		{
			Span<TPixel> span = pixels.DangerousGetRowSpan(i).Slice(left, width);
			for (int j = 0; j < span.Length; j++)
			{
				float num = (float)bitReader.ReadBits(bitsPerSampleR) / rFactor;
				float num2 = (float)bitReader.ReadBits(bitsPerSampleG) / gFactor;
				float num3 = (float)bitReader.ReadBits(bitsPerSampleB) / bFactor;
				float num4 = (float)bitReader.ReadBits(bitsPerSampleB) / aFactor;
				((Vector4)(ref vector))._002Ector(num, num2, num3, num4);
				if (flag)
				{
					span[j] = TiffUtils.UnPremultiply(ref vector, val);
					continue;
				}
				val.FromScaledVector4(vector);
				span[j] = val;
			}
			bitReader.NextRow();
		}
	}
}
