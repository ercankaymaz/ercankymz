using System.Collections.Generic;

namespace UglyToad.PdfPig.Annotations;

public class AnnotationBorder
{
	public static AnnotationBorder Default { get; } = new AnnotationBorder(0.0, 0.0, 1.0, null);

	public double HorizontalCornerRadius { get; }

	public double VerticalCornerRadius { get; }

	public double BorderWidth { get; }

	public IReadOnlyList<double>? LineDashPattern { get; }

	public AnnotationBorder(double horizontalCornerRadius, double verticalCornerRadius, double borderWidth, IReadOnlyList<double>? lineDashPattern)
	{
		HorizontalCornerRadius = horizontalCornerRadius;
		VerticalCornerRadius = verticalCornerRadius;
		BorderWidth = borderWidth;
		LineDashPattern = lineDashPattern;
	}

	public override string ToString()
	{
		return $"{HorizontalCornerRadius} {VerticalCornerRadius} {BorderWidth}";
	}
}
