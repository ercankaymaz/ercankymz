using System;
using System.Collections.Concurrent;

namespace UglyToad.PdfPig.Graphics.Colors;

public sealed class IndexedColorSpaceDetails : ColorSpaceDetails
{
	private readonly ConcurrentDictionary<double, IColor> cache = new ConcurrentDictionary<double, IColor>();

	private readonly byte[] colorTable;

	public override int NumberOfColorComponents => 1;

	public override int BaseNumberOfColorComponents => BaseColorSpace.BaseNumberOfColorComponents;

	public ColorSpaceDetails BaseColorSpace { get; }

	public byte HiVal { get; }

	public ReadOnlySpan<byte> ColorTable => colorTable;

	internal static ColorSpaceDetails Stencil(ColorSpaceDetails colorSpaceDetails)
	{
		return new IndexedColorSpaceDetails(colorSpaceDetails, 1, new byte[2] { 0, 255 });
	}

	public IndexedColorSpaceDetails(ColorSpaceDetails baseColorSpaceDetails, byte hiVal, byte[] colorTable)
		: base(ColorSpace.Indexed)
	{
		BaseColorSpace = baseColorSpaceDetails ?? throw new ArgumentNullException("baseColorSpaceDetails");
		HiVal = hiVal;
		this.colorTable = colorTable;
		base.BaseType = baseColorSpaceDetails.Type;
	}

	internal override double[] Process(params double[] values)
	{
		Span<byte> span = UnwrapIndexedColorSpaceBytes(new Span<byte>(new byte[1] { (byte)values[0] }));
		double[] array = new double[span.Length];
		for (int i = 0; i < span.Length; i++)
		{
			array[i] = (double)(int)span[i] / 255.0;
		}
		return BaseColorSpace.Process(array);
	}

	public override IColor GetColor(params double[] values)
	{
		if (values == null || values.Length != NumberOfColorComponents)
		{
			throw new ArgumentException($"Invalid number of inputs, expecting {NumberOfColorComponents} but got {((values != null) ? values.Length : 0)}", "values");
		}
		return cache.GetOrAdd(values[0], delegate(double v)
		{
			Span<byte> span = UnwrapIndexedColorSpaceBytes(new Span<byte>(new byte[1] { (byte)v }));
			double[] array = new double[span.Length];
			for (int i = 0; i < span.Length; i++)
			{
				array[i] = (double)(int)span[i] / 255.0;
			}
			return BaseColorSpace.GetColor(array);
		});
	}

	internal Span<byte> UnwrapIndexedColorSpaceBytes(Span<byte> input)
	{
		switch (base.BaseType)
		{
		case ColorSpace.DeviceRGB:
		case ColorSpace.CalRGB:
		case ColorSpace.Lab:
		{
			Span<byte> result3 = new byte[input.Length * 3];
			int num3 = 0;
			Span<byte> span3 = input;
			for (int i = 0; i < span3.Length; i++)
			{
				byte b3 = span3[i];
				for (int l = 0; l < 3; l++)
				{
					result3[num3++] = ColorTable[b3 * 3 + l];
				}
			}
			return result3;
		}
		case ColorSpace.DeviceCMYK:
		{
			Span<byte> result2 = new byte[input.Length * 4];
			int num2 = 0;
			Span<byte> span2 = input;
			for (int i = 0; i < span2.Length; i++)
			{
				byte b2 = span2[i];
				for (int k = 0; k < 4; k++)
				{
					result2[num2++] = ColorTable[b2 * 4 + k];
				}
			}
			return result2;
		}
		case ColorSpace.DeviceGray:
		case ColorSpace.CalGray:
		case ColorSpace.Separation:
		{
			for (int m = 0; m < input.Length; m++)
			{
				ref byte reference2 = ref input[m];
				reference2 = ColorTable[reference2];
			}
			return input;
		}
		case ColorSpace.ICCBased:
		case ColorSpace.DeviceN:
		{
			int num = 0;
			if (BaseColorSpace.NumberOfColorComponents == 1)
			{
				for (num = 0; num < input.Length; num++)
				{
					ref byte reference = ref input[num];
					reference = ColorTable[reference];
				}
				return input;
			}
			Span<byte> result = new byte[input.Length * BaseColorSpace.NumberOfColorComponents];
			Span<byte> span = input;
			for (int i = 0; i < span.Length; i++)
			{
				byte b = span[i];
				for (int j = 0; j < BaseColorSpace.NumberOfColorComponents; j++)
				{
					result[num++] = ColorTable[b * BaseColorSpace.NumberOfColorComponents + j];
				}
			}
			return result;
		}
		default:
			return input;
		}
	}

	public override IColor GetInitializeColor()
	{
		return GetColor(default(double));
	}

	internal override Span<byte> Transform(Span<byte> decoded)
	{
		Span<byte> decoded2 = UnwrapIndexedColorSpaceBytes(decoded);
		return BaseColorSpace.Transform(decoded2);
	}
}
