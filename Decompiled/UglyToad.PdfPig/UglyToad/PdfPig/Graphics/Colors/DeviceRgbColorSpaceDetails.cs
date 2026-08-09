using System;

namespace UglyToad.PdfPig.Graphics.Colors;

public sealed class DeviceRgbColorSpaceDetails : ColorSpaceDetails
{
	public static readonly DeviceRgbColorSpaceDetails Instance = new DeviceRgbColorSpaceDetails();

	public override int NumberOfColorComponents => 3;

	public override int BaseNumberOfColorComponents => NumberOfColorComponents;

	private DeviceRgbColorSpaceDetails()
		: base(ColorSpace.DeviceRGB)
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
		if (num == 0.0 && num2 == 0.0 && num3 == 0.0)
		{
			return RGBColor.Black;
		}
		if (num == 1.0 && num2 == 1.0 && num3 == 1.0)
		{
			return RGBColor.White;
		}
		return new RGBColor(num, num2, num3);
	}

	public override IColor GetInitializeColor()
	{
		return RGBColor.Black;
	}

	internal override Span<byte> Transform(Span<byte> decoded)
	{
		return decoded;
	}
}
