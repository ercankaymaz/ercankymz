using System;
using System.IO;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Writer;

namespace UglyToad.PdfPig.Graphics.Operations;

public class SetStrokeColorSpace : IGraphicsStateOperation
{
	private static readonly TokenWriter TokenWriter = new TokenWriter();

	public const string Symbol = "CS";

	public string Operator => "CS";

	public NameToken Name { get; }

	public SetStrokeColorSpace(NameToken name)
	{
		Name = name ?? throw new ArgumentNullException("name");
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.GetCurrentState().ColorSpaceContext.SetStrokingColorspace(Name);
	}

	public void Write(Stream stream)
	{
		TokenWriter.WriteToken(Name, stream);
		stream.WriteText("CS");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return string.Format("{0} {1}", Name, "CS");
	}
}
