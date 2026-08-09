using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations.TextState;

public class Type3SetGlyphWidthAndBoundingBox : IGraphicsStateOperation
{
	public const string Symbol = "d1";

	public string Operator => "d1";

	public double HorizontalDisplacement { get; }

	public double VerticalDisplacement { get; }

	public double LowerLeftX { get; }

	public double LowerLeftY { get; }

	public double UpperRightX { get; }

	public double UpperRightY { get; }

	public Type3SetGlyphWidthAndBoundingBox(double horizontalDisplacement, double verticalDisplacement, double lowerLeftX, double lowerLeftY, double upperRightX, double upperRightY)
	{
		HorizontalDisplacement = horizontalDisplacement;
		VerticalDisplacement = verticalDisplacement;
		LowerLeftX = lowerLeftX;
		LowerLeftY = lowerLeftY;
		UpperRightX = upperRightX;
		UpperRightY = upperRightY;
	}

	public void Run(IOperationContext operationContext)
	{
	}

	public void Write(Stream stream)
	{
		stream.WriteDouble(HorizontalDisplacement);
		stream.WriteWhiteSpace();
		stream.WriteDouble(VerticalDisplacement);
		stream.WriteWhiteSpace();
		stream.WriteDouble(LowerLeftX);
		stream.WriteWhiteSpace();
		stream.WriteDouble(LowerLeftY);
		stream.WriteWhiteSpace();
		stream.WriteDouble(UpperRightX);
		stream.WriteWhiteSpace();
		stream.WriteNumberText(UpperRightY, "d1");
	}

	public override string ToString()
	{
		return string.Format("{0} {1} {2} {3} {4} {5} {6}", HorizontalDisplacement, VerticalDisplacement, LowerLeftX, LowerLeftY, UpperRightX, UpperRightY, "d1");
	}
}
