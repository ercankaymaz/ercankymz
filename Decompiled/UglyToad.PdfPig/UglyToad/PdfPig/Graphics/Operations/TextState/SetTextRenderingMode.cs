using System.IO;
using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.Graphics.Operations.TextState;

public class SetTextRenderingMode : IGraphicsStateOperation
{
	public const string Symbol = "Tr";

	public string Operator => "Tr";

	public TextRenderingMode Mode { get; }

	public SetTextRenderingMode(TextRenderingMode mode)
	{
		Mode = mode;
	}

	public SetTextRenderingMode(int mode)
	{
		Mode = (TextRenderingMode)mode;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.SetTextRenderingMode(Mode);
	}

	public void Write(Stream stream)
	{
		stream.WriteNumberText((int)Mode, "Tr");
	}

	public override string ToString()
	{
		return string.Format("{0} {1}", Mode, "Tr");
	}
}
