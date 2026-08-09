using System;
using System.IO;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Graphics.Operations;

public class PaintShading : IGraphicsStateOperation
{
	public const string Symbol = "sh";

	public string Operator => "sh";

	public NameToken Name { get; }

	public PaintShading(NameToken name)
	{
		Name = name ?? throw new ArgumentNullException("name");
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.PaintShading(Name);
	}

	public void Write(Stream stream)
	{
		stream.WriteText("/" + Name.Data);
		stream.WriteWhiteSpace();
		stream.WriteText("sh");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return string.Format("{0} {1}", Name, "sh");
	}
}
