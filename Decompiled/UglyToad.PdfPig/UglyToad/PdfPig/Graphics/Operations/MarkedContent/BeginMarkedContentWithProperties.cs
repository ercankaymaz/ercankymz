using System.IO;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Writer;

namespace UglyToad.PdfPig.Graphics.Operations.MarkedContent;

public class BeginMarkedContentWithProperties : IGraphicsStateOperation
{
	private static readonly TokenWriter TokenWriter = new TokenWriter();

	public const string Symbol = "BDC";

	public string Operator => "BDC";

	public NameToken Name { get; }

	public NameToken? PropertyDictionaryName { get; }

	public DictionaryToken? Properties { get; }

	public BeginMarkedContentWithProperties(NameToken name, NameToken propertyDictionaryName)
	{
		Name = name;
		PropertyDictionaryName = propertyDictionaryName;
	}

	public BeginMarkedContentWithProperties(NameToken name, DictionaryToken properties)
	{
		Name = name;
		Properties = properties;
	}

	public void Run(IOperationContext operationContext)
	{
		operationContext.BeginMarkedContent(Name, PropertyDictionaryName, Properties);
	}

	public void Write(Stream stream)
	{
		TokenWriter.WriteToken(Name, stream);
		stream.WriteWhiteSpace();
		if (PropertyDictionaryName != null)
		{
			TokenWriter.WriteToken(PropertyDictionaryName, stream);
		}
		else
		{
			TokenWriter.WriteToken(Properties, stream);
		}
		stream.WriteWhiteSpace();
		stream.WriteText("BDC");
		stream.WriteNewLine();
	}
}
