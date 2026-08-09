using System.IO;
using UglyToad.PdfPig.Tokens;
using UglyToad.PdfPig.Writer;

namespace UglyToad.PdfPig.Graphics.Operations.MarkedContent;

public class DesignateMarkedContentPointWithProperties : IGraphicsStateOperation
{
	private static readonly TokenWriter TokenWriter = new TokenWriter();

	public const string Symbol = "DP";

	public string Operator => "DP";

	public NameToken Name { get; }

	public NameToken? PropertyDictionaryName { get; }

	public DictionaryToken? Properties { get; }

	public DesignateMarkedContentPointWithProperties(NameToken name, NameToken propertyDictionaryName)
	{
		Name = name;
		PropertyDictionaryName = propertyDictionaryName;
	}

	public DesignateMarkedContentPointWithProperties(NameToken name, DictionaryToken properties)
	{
		Name = name;
		Properties = properties;
	}

	public void Run(IOperationContext operationContext)
	{
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
		stream.WriteText("DP");
		stream.WriteNewLine();
	}
}
