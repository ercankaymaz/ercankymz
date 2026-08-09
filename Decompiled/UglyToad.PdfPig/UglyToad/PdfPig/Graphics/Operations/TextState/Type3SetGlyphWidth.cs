using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations.TextState;

public class Type3SetGlyphWidth : IGraphicsStateOperation
{
	public const string Symbol = "d0";

	public string Operator => "d0";

	public double HorizontalDisplacement { get; }

	public double VerticalDisplacement { get; }

	public Type3SetGlyphWidth(double horizontalDisplacement, double verticalDisplacement)
	{
		HorizontalDisplacement = horizontalDisplacement;
		VerticalDisplacement = verticalDisplacement;
	}

	public void Run(IOperationContext operationContext)
	{
	}

	public void Write(Stream stream)
	{
		stream.WriteDouble(HorizontalDisplacement);
		stream.WriteWhiteSpace();
		stream.WriteNumberText(VerticalDisplacement, "d0");
	}

	public override string ToString()
	{
		return string.Format("{0} {1} {2}", HorizontalDisplacement, VerticalDisplacement, "d0");
	}
}
