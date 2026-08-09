using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Graphics.Colors;

public sealed class PatternColorSpaceDetails : ColorSpaceDetails
{
	public IReadOnlyDictionary<NameToken, PatternColor> Patterns { get; }

	public override int NumberOfColorComponents
	{
		get
		{
			throw new InvalidOperationException("PatternColorSpaceDetails");
		}
	}

	public override int BaseNumberOfColorComponents => UnderlyingColourSpace.NumberOfColorComponents;

	public ColorSpaceDetails? UnderlyingColourSpace { get; }

	public PatternColorSpaceDetails(IReadOnlyDictionary<NameToken, PatternColor> patterns, ColorSpaceDetails underlyingColourSpace)
		: base(ColorSpace.Pattern)
	{
		Patterns = patterns ?? throw new ArgumentNullException("patterns");
		UnderlyingColourSpace = underlyingColourSpace;
	}

	public PatternColor GetColor(NameToken name)
	{
		return Patterns[name];
	}

	internal override double[] Process(params double[] values)
	{
		throw new InvalidOperationException("PatternColorSpaceDetails");
	}

	public override IColor GetColor(params double[] values)
	{
		throw new InvalidOperationException("PatternColorSpaceDetails");
	}

	public override IColor? GetInitializeColor()
	{
		return null;
	}

	internal override Span<byte> Transform(Span<byte> decoded)
	{
		throw new InvalidOperationException("PatternColorSpaceDetails");
	}
}
