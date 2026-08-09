using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations.PathConstruction;

public class BeginNewSubpath : IGraphicsStateOperation
{
	public const string Symbol = "m";

	public string Operator => "m";

	public double X { get; }

	public double Y { get; }

	public BeginNewSubpath(double x, double y)
	{
		X = x;
		Y = y;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.MoveTo(X, Y);
	}

	public void Write(Stream stream)
	{
		stream.WriteDouble(X);
		stream.WriteWhiteSpace();
		stream.WriteDouble(Y);
		stream.WriteWhiteSpace();
		stream.WriteText("m");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return string.Format("{0} {1} {2}", X, Y, "m");
	}
}
