using UglyToad.PdfPig.Geometry;

namespace UglyToad.PdfPig.PdfFonts.CidFonts;

internal readonly struct VerticalVectorComponents
{
	public static readonly VerticalVectorComponents Default = new VerticalVectorComponents(800.0, -1000.0);

	public double Position { get; }

	public double Displacement { get; }

	public VerticalVectorComponents(double position, double displacement)
	{
		Position = position;
		Displacement = displacement;
	}

	public PdfVector GetPositionVector(double glyphWidth)
	{
		return new PdfVector(glyphWidth / 2.0, Position);
	}

	public PdfVector GetDisplacementVector()
	{
		return new PdfVector(0.0, Displacement);
	}

	public override string ToString()
	{
		return $"Position: {Position}, Displacement: {Displacement}.";
	}
}
