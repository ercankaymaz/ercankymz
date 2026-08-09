using System;

namespace UglyToad.PdfPig.Graphics.Colors;

public abstract class ColorSpaceDetails
{
	public ColorSpace Type { get; }

	public abstract int NumberOfColorComponents { get; }

	public ColorSpace BaseType { get; protected set; }

	public abstract int BaseNumberOfColorComponents { get; }

	protected internal ColorSpaceDetails(ColorSpace type)
	{
		Type = type;
		BaseType = type;
	}

	public abstract IColor GetColor(params double[] values);

	internal abstract double[] Process(params double[] values);

	public abstract IColor? GetInitializeColor();

	internal abstract Span<byte> Transform(Span<byte> decoded);

	protected static byte ConvertToByte(double componentValue)
	{
		return (byte)Math.Round(componentValue * 255.0, MidpointRounding.AwayFromZero);
	}
}
