using System.IO;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Graphics.Operations.SpecialGraphicsState;

public class SetGraphicsStateParametersFromDictionary : IGraphicsStateOperation
{
	public const string Symbol = "gs";

	public string Operator => "gs";

	public NameToken Name { get; }

	public SetGraphicsStateParametersFromDictionary(NameToken name)
	{
		Name = name;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.SetNamedGraphicsState(Name);
	}

	public void Write(Stream stream)
	{
		stream.WriteText("/" + Name.Data);
		stream.WriteWhiteSpace();
		stream.WriteText("gs");
		stream.WriteNewLine();
	}

	public override string ToString()
	{
		return string.Format("{0} {1}", Name, "gs");
	}
}
