using System;
using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Graphics.Colors;

public sealed class TilingPatternColor : PatternColor, IEquatable<TilingPatternColor>
{
	public StreamToken PatternStream { get; }

	public PatternPaintType PaintType { get; }

	public PatternTilingType TilingType { get; }

	public PdfRectangle BBox { get; }

	public double XStep { get; }

	public double YStep { get; }

	public DictionaryToken Resources { get; }

	public ReadOnlyMemory<byte> Data { get; }

	public TilingPatternColor(TransformationMatrix matrix, DictionaryToken extGState, StreamToken patternStream, PatternPaintType paintType, PatternTilingType tilingType, PdfRectangle bbox, double xStep, double yStep, DictionaryToken resources, ReadOnlyMemory<byte> data)
		: base(PatternType.Tiling, patternStream.StreamDictionary, extGState, matrix)
	{
		PatternStream = patternStream;
		PaintType = paintType;
		TilingType = tilingType;
		BBox = bbox;
		XStep = xStep;
		YStep = yStep;
		Resources = resources;
		Data = data;
	}

	public override bool Equals(object? obj)
	{
		if (obj is TilingPatternColor other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(TilingPatternColor? other)
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
					goto IL_0133;
				}
			}
			if (PaintType.Equals(other.PaintType) && TilingType.Equals(other.TilingType) && BBox.Equals(other.BBox) && XStep.Equals(other.XStep) && YStep.Equals(other.YStep) && Resources.Equals(other.Resources))
			{
				ReadOnlyMemory<byte> data = Data;
				ReadOnlySpan<byte> span = data.Span;
				data = other.Data;
				return span.SequenceEqual(data.Span);
			}
		}
		goto IL_0133;
		IL_0133:
		return false;
	}

	public override int GetHashCode()
	{
		return (base.PatternType, base.Matrix, base.ExtGState, PaintType, TilingType, BBox, XStep, YStep, Resources, Data).GetHashCode();
	}

	public override string ToString()
	{
		return base.ToString() + $"[{PaintType}][{TilingType}]";
	}

	public static bool operator ==(TilingPatternColor color1, TilingPatternColor color2)
	{
		return EqualityComparer<TilingPatternColor>.Default.Equals(color1, color2);
	}

	public static bool operator !=(TilingPatternColor color1, TilingPatternColor color2)
	{
		return !(color1 == color2);
	}
}
