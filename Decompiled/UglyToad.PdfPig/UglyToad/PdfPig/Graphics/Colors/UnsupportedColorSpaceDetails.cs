using System;

namespace UglyToad.PdfPig.Graphics.Colors;

public sealed class UnsupportedColorSpaceDetails : ColorSpaceDetails
{
	public static readonly UnsupportedColorSpaceDetails Instance = new UnsupportedColorSpaceDetails();

	public override int NumberOfColorComponents
	{
		get
		{
			throw new InvalidOperationException("UnsupportedColorSpaceDetails");
		}
	}

	public override int BaseNumberOfColorComponents => NumberOfColorComponents;

	private UnsupportedColorSpaceDetails()
		: base(ColorSpace.DeviceGray)
	{
	}

	internal override double[] Process(params double[] values)
	{
		throw new InvalidOperationException("UnsupportedColorSpaceDetails");
	}

	public override IColor GetColor(params double[] values)
	{
		throw new InvalidOperationException("UnsupportedColorSpaceDetails");
	}

	public override IColor? GetInitializeColor()
	{
		throw new InvalidOperationException("UnsupportedColorSpaceDetails");
	}

	internal override Span<byte> Transform(Span<byte> decoded)
	{
		throw new InvalidOperationException("UnsupportedColorSpaceDetails");
	}
}
