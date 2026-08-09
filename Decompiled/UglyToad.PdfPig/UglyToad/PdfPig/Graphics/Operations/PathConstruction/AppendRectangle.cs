using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations.PathConstruction;

public class AppendRectangle : IGraphicsStateOperation
{
	public const string Symbol = "re";

	public string Operator => "re";

	public double LowerLeftX { get; }

	public double LowerLeftY { get; }

	public double Width { get; }

	public double Height { get; }

	public AppendRectangle(double x, double y, double width, double height)
	{
		LowerLeftX = x;
		LowerLeftY = y;
		Width = width;
		Height = height;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.Rectangle(LowerLeftX, LowerLeftY, Width, Height);
	}

	public void Write(Stream stream)
	{
		stream.WriteDouble(LowerLeftX);
		stream.WriteWhiteSpace();
		stream.WriteDouble(LowerLeftY);
		stream.WriteWhiteSpace();
		stream.WriteDouble(Width);
		stream.WriteWhiteSpace();
		stream.WriteDouble(Height);
		stream.WriteWhiteSpace();
		stream.WriteText("re");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return string.Format("{0} {1} {2} {3} {4}", LowerLeftX, LowerLeftY, Width, Height, "re");
	}
}
