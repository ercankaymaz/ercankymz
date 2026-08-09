using System.Collections.Generic;
using UglyToad.PdfPig.Core;
using UglyToad.PdfPig.Graphics.Colors;
using UglyToad.PdfPig.Graphics.Core;

namespace UglyToad.PdfPig.Graphics;

public class PdfPath : List<PdfSubpath>
{
	public FillingRule FillingRule { get; private set; }

	public bool IsClipping { get; private set; }

	public bool IsFilled { get; private set; }

	public IColor? FillColor { get; private set; }

	public bool IsStroked { get; private set; }

	public IColor? StrokeColor { get; private set; }

	public double LineWidth { get; private set; }

	public LineDashPattern? LineDashPattern { get; private set; }

	public LineCapStyle LineCapStyle { get; private set; }

	public LineJoinStyle LineJoinStyle { get; private set; }

	public void SetClipping(FillingRule fillingRule)
	{
		IsFilled = false;
		IsStroked = false;
		IsClipping = true;
		FillingRule = fillingRule;
	}

	public void SetFilled(FillingRule fillingRule)
	{
		IsFilled = true;
		FillingRule = fillingRule;
	}

	public void SetStroked()
	{
		IsStroked = true;
	}

	public void SetStrokeDetails(CurrentGraphicsState graphicsState)
	{
		LineDashPattern = graphicsState.LineDashPattern;
		StrokeColor = graphicsState.CurrentStrokingColor;
		LineWidth = graphicsState.LineWidth;
		LineCapStyle = graphicsState.CapStyle;
		LineJoinStyle = graphicsState.JoinStyle;
	}

	public void SetFillDetails(CurrentGraphicsState graphicsState)
	{
		FillColor = graphicsState.CurrentNonStrokingColor;
	}

	internal PdfPath CloneEmpty()
	{
		PdfPath pdfPath = new PdfPath();
		if (IsClipping)
		{
			pdfPath.SetClipping(FillingRule);
		}
		else
		{
			if (IsFilled)
			{
				pdfPath.SetFilled(FillingRule);
				pdfPath.FillColor = FillColor;
			}
			if (IsStroked)
			{
				pdfPath.SetStroked();
				pdfPath.LineCapStyle = LineCapStyle;
				pdfPath.LineDashPattern = LineDashPattern;
				pdfPath.LineJoinStyle = LineJoinStyle;
				pdfPath.LineWidth = LineWidth;
				pdfPath.StrokeColor = StrokeColor;
			}
		}
		return pdfPath;
	}

	public PdfRectangle? GetBoundingRectangle()
	{
		return PdfSubpath.GetBoundingRectangle(this);
	}
}
