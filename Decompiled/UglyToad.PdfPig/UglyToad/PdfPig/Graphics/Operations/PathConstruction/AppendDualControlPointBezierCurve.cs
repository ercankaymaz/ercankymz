using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations.PathConstruction;

public class AppendDualControlPointBezierCurve : IGraphicsStateOperation
{
	public const string Symbol = "c";

	public string Operator => "c";

	public double X1 { get; }

	public double Y1 { get; }

	public double X2 { get; }

	public double Y2 { get; }

	public double X3 { get; }

	public double Y3 { get; }

	public AppendDualControlPointBezierCurve(double x1, double y1, double x2, double y2, double x3, double y3)
	{
		X1 = x1;
		Y1 = y1;
		X2 = x2;
		Y2 = y2;
		X3 = x3;
		Y3 = y3;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.BezierCurveTo(X1, Y1, X2, Y2, X3, Y3);
	}

	public void Write(Stream stream)
	{
		stream.WriteDouble(X1);
		stream.WriteWhiteSpace();
		stream.WriteDouble(Y1);
		stream.WriteWhiteSpace();
		stream.WriteDouble(X2);
		stream.WriteWhiteSpace();
		stream.WriteDouble(Y2);
		stream.WriteWhiteSpace();
		stream.WriteDouble(X3);
		stream.WriteWhiteSpace();
		stream.WriteDouble(Y3);
		stream.WriteWhiteSpace();
		stream.WriteText("c");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return string.Format("{0} {1} {2} {3} {4} {5} {6}", X1, Y1, X2, Y2, X3, Y3, "c");
	}
}
