using System;

namespace UglyToad.PdfPig.Graphics.Colors;

public sealed class DeviceCmykColorSpaceDetails : ColorSpaceDetails
{
	public static readonly DeviceCmykColorSpaceDetails Instance = new DeviceCmykColorSpaceDetails();

	public override int NumberOfColorComponents => 4;

	public override int BaseNumberOfColorComponents => NumberOfColorComponents;

	private DeviceCmykColorSpaceDetails()
		: base(ColorSpace.DeviceCMYK)
	{
	}

	internal override double[] Process(params double[] values)
	{
		return values;
	}

	public override IColor GetColor(params double[] values)
	{
		if (values == null || values.Length != NumberOfColorComponents)
		{
			throw new ArgumentException($"Invalid number of inputs, expecting {NumberOfColorComponents} but got {((values != null) ? values.Length : 0)}", "values");
		}
		double num = values[0];
		double num2 = values[1];
		double num3 = values[2];
		double num4 = values[3];
		if (num == 0.0 && num2 == 0.0 && num3 == 0.0 && num4 == 1.0)
		{
			return CMYKColor.Black;
		}
		if (num == 0.0 && num2 == 0.0 && num3 == 0.0 && num4 == 0.0)
		{
			return CMYKColor.White;
		}
		return new CMYKColor(num, num2, num3, num4);
	}

	public override IColor GetInitializeColor()
	{
		return CMYKColor.Black;
	}

	internal override Span<byte> Transform(Span<byte> decoded)
	{
		return decoded;
	}
}
