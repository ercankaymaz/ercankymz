using System.IO;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Writer;

namespace UglyToad.PdfPig.Graphics.Operations.MarkedContent;

public class BeginMarkedContent : IGraphicsStateOperation
{
	private static readonly TokenWriter TokenWriter = new TokenWriter();

	public const string Symbol = "BMC";

	public string Operator => "BMC";

	public NameToken Name { get; }

	public BeginMarkedContent(NameToken name)
	{
		Name = name;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.BeginMarkedContent(Name, null, null);
	}

	public void Write(Stream stream)
	{
		TokenWriter.WriteToken(Name, stream);
		stream.WriteWhiteSpace();
		stream.WriteText("BMC");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return string.Format("{0} {1}", Name, "BMC");
	}
}
