using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations;

public class SetStrokeColorDeviceCmyk : IGraphicsStateOperation
{
	public const string Symbol = "K";

	public string Operator => "K";

	public double C { get; }

	public double M { get; }

	public double Y { get; }

	public double K { get; }

	public SetStrokeColorDeviceCmyk(double c, double m, double y, double k)
	{
		C = c;
		M = m;
		Y = y;
		K = k;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.GetCurrentState().ColorSpaceContext.SetStrokingColorCmyk(C, M, Y, K);
	}

	public void Write(Stream stream)
	{
		stream.WriteDouble(C);
		stream.WriteWhiteSpace();
		stream.WriteDouble(M);
		stream.WriteWhiteSpace();
		stream.WriteDouble(Y);
		stream.WriteWhiteSpace();
		stream.WriteDouble(K);
		stream.WriteWhiteSpace();
		stream.WriteText("K");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return string.Format("{0} {1} {2} {3} {4}", C, M, Y, K, "K");
	}
}
