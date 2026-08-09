using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Graphics.Core;

internal static class RenderingModeExtensions
{
	public static bool IsFill(this TextRenderingMode mode)
	{
		if (mode != TextRenderingMode.Fill && mode != TextRenderingMode.FillThenStroke && mode != TextRenderingMode.FillClip)
		{
			return mode == TextRenderingMode.FillThenStrokeClip;
		}
		return true;
	}

	public static bool IsStroke(this TextRenderingMode mode)
	{
		if (mode != TextRenderingMode.Stroke && mode != TextRenderingMode.FillThenStroke && mode != TextRenderingMode.StrokeClip)
		{
			return mode == TextRenderingMode.FillThenStrokeClip;
		}
		return true;
	}

	public static bool IsClip(this TextRenderingMode mode)
	{
		if (mode != TextRenderingMode.FillClip && mode != TextRenderingMode.StrokeClip && mode != TextRenderingMode.FillThenStrokeClip)
		{
			return mode == TextRenderingMode.NeitherClip;
		}
		return true;
	}
}
