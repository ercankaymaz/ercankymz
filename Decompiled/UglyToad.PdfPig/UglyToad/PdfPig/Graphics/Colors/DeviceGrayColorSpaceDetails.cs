using System;

namespace UglyToad.PdfPig.Graphics.Colors;

public sealed class DeviceGrayColorSpaceDetails : ColorSpaceDetails
{
	public static readonly DeviceGrayColorSpaceDetails Instance = new DeviceGrayColorSpaceDetails();

	public override int NumberOfColorComponents => 1;

	public override int BaseNumberOfColorComponents => NumberOfColorComponents;

	private DeviceGrayColorSpaceDetails()
		: base(ColorSpace.DeviceGray)
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
		if (num == 0.0)
		{
			return GrayColor.Black;
		}
		if (num == 1.0)
		{
			return GrayColor.White;
		}
		return new GrayColor(num);
	}

	public override IColor GetInitializeColor()
	{
		return GrayColor.Black;
	}

	internal override Span<byte> Transform(Span<byte> decoded)
	{
		return decoded;
	}
}
