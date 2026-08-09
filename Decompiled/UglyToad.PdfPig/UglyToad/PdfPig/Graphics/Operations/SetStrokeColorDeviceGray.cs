using System.IO;

namespace UglyToad.PdfPig.Graphics.Operations;

public class SetStrokeColorDeviceGray : IGraphicsStateOperation
{
	public const string Symbol = "G";

	public string Operator => "G";

	public double Gray { get; }

	public SetStrokeColorDeviceGray(double gray)
	{
		Gray = gray;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.GetCurrentState().ColorSpaceContext.SetStrokingColorGray(Gray);
	}

	public void Write(Stream stream)
	{
		stream.WriteNumberText(Gray, "G");
	}

	public override string ToString()
	{
		return string.Format("{0} {1}", Gray, "G");
	}
}
