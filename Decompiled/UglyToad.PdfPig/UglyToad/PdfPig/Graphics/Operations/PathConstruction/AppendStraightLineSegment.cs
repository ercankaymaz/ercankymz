using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations.PathConstruction;

public class AppendStraightLineSegment : IGraphicsStateOperation
{
	public const string Symbol = "l";

	public string Operator => "l";

	public double X { get; }

	public double Y { get; }

	public AppendStraightLineSegment(double x, double y)
	{
		X = x;
		Y = y;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.LineTo(X, Y);
	}

	public void Write(Stream stream)
	{
		stream.WriteDouble(X);
		stream.WriteWhiteSpace();
		stream.WriteDouble(Y);
		stream.WriteWhiteSpace();
		stream.WriteText("l");
		stream.WriteWhiteSpace();
	}

	public override string ToString()
	{
		return string.Format("{0} {1} {2}", X, Y, "l");
	}
}
