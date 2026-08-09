namespace UglyToad.PdfPig.Outline.Destinations;

public class ExplicitDestinationCoordinates
{
	public static ExplicitDestinationCoordinates Empty { get; } = new ExplicitDestinationCoordinates(null, null, null, null);

	public double? Left { get; }

	public double? Top { get; }

	public double? Right { get; }

	public double? Bottom { get; }

	public ExplicitDestinationCoordinates(double? left)
	{
		Left = left;
	}

	public ExplicitDestinationCoordinates(double? left, double? top)
	{
		Left = left;
		Top = top;
	}

	public ExplicitDestinationCoordinates(double? left, double? top, double? right, double? bottom)
	{
		Left = left;
		Top = top;
		Right = right;
		Bottom = bottom;
	}
}
