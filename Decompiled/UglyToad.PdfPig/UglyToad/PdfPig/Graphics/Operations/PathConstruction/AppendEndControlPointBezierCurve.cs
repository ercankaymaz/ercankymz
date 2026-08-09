using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations.PathConstruction;

public class AppendEndControlPointBezierCurve : IGraphicsStateOperation
{
	public const string Symbol = "y";

	public string Operator => "y";

	public double X1 { get; }

	public double Y1 { get; }

	public double X3 { get; }

	public double Y3 { get; }

	public AppendEndControlPointBezierCurve(double x1, double y1, double x3, double y3)
	{
		X1 = x1;
		Y1 = y1;
		X3 = x3;
		Y3 = y3;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.BezierCurveTo(X1, Y1, X3, Y3, X3, Y3);
	}

	public void Write(Stream stream)
	{
		stream.WriteDouble(X1);
		stream.WriteWhiteSpace();
		stream.WriteDouble(Y1);
		stream.WriteWhiteSpace();
		stream.WriteDouble(X3);
		stream.WriteWhiteSpace();
		stream.WriteDouble(Y3);
		stream.WriteWhiteSpace();
		stream.WriteText("y");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return string.Format("{0} {1} {2} {3} {4}", X1, Y1, X3, Y3, "y");
	}
}
