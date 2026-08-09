using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Graphics.Colors;

public sealed class ShadingPatternColor : PatternColor, IEquatable<ShadingPatternColor>
{
	public Shading Shading { get; }

	public ShadingPatternColor(TransformationMatrix matrix, DictionaryToken extGState, DictionaryToken patternDictionary, Shading shading)
		: base(PatternType.Shading, patternDictionary, extGState, matrix)
	{
		Shading = shading;
	}

	public override bool Equals(object? obj)
	{
		if (obj is ShadingPatternColor other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(ShadingPatternColor? other)
	{
		if ((object)other == null)
		{
			return (object)this == null;
		}
		if (base.PatternType.Equals(other.PatternType) && base.Matrix.Equals(other.Matrix))
		{
			if (base.ExtGState != null || other.ExtGState != null)
			{
				DictionaryToken extGState = base.ExtGState;
				if (extGState == null || !extGState.Equals(other.ExtGState))
				{
					goto IL_007b;
				}
			}
			return Shading.Equals(other.Shading);
		}
		goto IL_007b;
		IL_007b:
		return false;
	}

	public override int GetHashCode()
	{
		return (base.PatternType, base.Matrix, base.ExtGState, Shading).GetHashCode();
	}

	public static bool operator ==(ShadingPatternColor color1, ShadingPatternColor color2)
	{
		return EqualityComparer<ShadingPatternColor>.Default.Equals(color1, color2);
	}

	public static bool operator !=(ShadingPatternColor color1, ShadingPatternColor color2)
	{
		return !(color1 == color2);
	}
}
