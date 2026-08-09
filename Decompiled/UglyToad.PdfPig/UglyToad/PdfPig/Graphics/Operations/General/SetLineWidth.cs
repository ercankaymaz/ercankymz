using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations.General;

public class SetLineWidth : IGraphicsStateOperation
{
	public const string Symbol = "w";

	public string Operator => "w";

	public double Width { get; }

	public SetLineWidth(double width)
	{
		Width = width;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.SetLineWidth(Width);
	}

	public void Write(Stream stream)
	{
		stream.WriteNumberText(Width, "w");
	}

	public override string ToString()
	{
		return string.Format("{0} {1}", Width, "w");
	}
}
