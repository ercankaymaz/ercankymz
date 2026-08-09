using System.IO;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Writer;

namespace UglyToad.PdfPig.Graphics.Operations.MarkedContent;

public class DesignateMarkedContentPoint : IGraphicsStateOperation
{
	private static readonly TokenWriter TokenWriter = new TokenWriter();

	public const string Symbol = "MP";

	public string Operator => "MP";

	public NameToken Name { get; }

	public DesignateMarkedContentPoint(NameToken name)
	{
		Name = name;
	}

	public void Run(IOperationContext operationContext)
	{
	}

	public void Write(Stream stream)
	{
		TokenWriter.WriteToken(Name, stream);
		stream.WriteWhiteSpace();
		stream.WriteText("MP");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return string.Format("{0} {1}", Name, "MP");
	}
}
