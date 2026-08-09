using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations;

public class SetStrokeColorDeviceRgb : IGraphicsStateOperation
{
	public const string Symbol = "RG";

	public string Operator => "RG";

	public double R { get; }

	public double G { get; }

	public double B { get; }

	public SetStrokeColorDeviceRgb(double r, double g, double b)
	{
		R = r;
		G = g;
		B = b;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.GetCurrentState().ColorSpaceContext.SetStrokingColorRgb(R, G, B);
	}

	public void Write(Stream stream)
	{
		stream.WriteDouble(R);
		stream.WriteWhiteSpace();
		stream.WriteDouble(G);
		stream.WriteWhiteSpace();
		stream.WriteDouble(B);
		stream.WriteWhiteSpace();
		stream.WriteText("RG");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return string.Format("{0} {1} {2} {3}", R, G, B, "RG");
	}
}
