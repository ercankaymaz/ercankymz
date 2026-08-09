using System;
using System.IO;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Writer;

namespace UglyToad.PdfPig.Graphics.Operations;

public class SetNonStrokeColorSpace : IGraphicsStateOperation
{
	private static readonly TokenWriter TokenWriter = new TokenWriter();

	public const string Symbol = "cs";

	public string Operator => "cs";

	public NameToken Name { get; }

	public SetNonStrokeColorSpace(NameToken name)
	{
		Name = name ?? throw new ArgumentNullException("name");
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.GetCurrentState().ColorSpaceContext.SetNonStrokingColorspace(Name);
	}

	public void Write(Stream stream)
	{
		TokenWriter.WriteToken(Name, stream);
		stream.WriteText("cs");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return string.Format("{0} {1}", Name, "cs");
	}
}
