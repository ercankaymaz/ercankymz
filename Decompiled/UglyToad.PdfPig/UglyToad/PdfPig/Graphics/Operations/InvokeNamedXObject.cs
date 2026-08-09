using System;
using System.IO;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Graphics.Operations;

public class InvokeNamedXObject : IGraphicsStateOperation
{
	public const string Symbol = "Do";

	public string Operator => "Do";

	public NameToken Name { get; }

	public InvokeNamedXObject(NameToken name)
	{
		Name = name ?? throw new ArgumentNullException("name");
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.ApplyXObject(Name);
	}

	public void Write(Stream stream)
	{
		stream.WriteText("/" + Name.Data);
		stream.WriteWhiteSpace();
		stream.WriteText("Do");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return string.Format("{0} {1}", Name, "Do");
	}
}
