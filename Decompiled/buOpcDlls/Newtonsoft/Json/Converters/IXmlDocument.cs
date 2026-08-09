using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Converters;

[Newtonsoft_002EJson_002ENullableContext(1)]
internal interface IXmlDocument : IXmlNode
{
	[Newtonsoft_002EJson_002ENullable(2)]
	IXmlElement DocumentElement
	{
		[Newtonsoft_002EJson_002ENullableContext(2)]
		get;
	}

	IXmlNode CreateComment([Newtonsoft_002EJson_002ENullable(2)] string text);

	IXmlNode CreateTextNode([Newtonsoft_002EJson_002ENullable(2)] string text);

	IXmlNode CreateCDataSection([Newtonsoft_002EJson_002ENullable(2)] string data);

	IXmlNode CreateWhitespace([Newtonsoft_002EJson_002ENullable(2)] string text);

	IXmlNode CreateSignificantWhitespace([Newtonsoft_002EJson_002ENullable(2)] string text);

	IXmlNode CreateXmlDeclaration(string version, [Newtonsoft_002EJson_002ENullable(2)] string encoding, [Newtonsoft_002EJson_002ENullable(2)] string standalone);

	[Newtonsoft_002EJson_002ENullableContext(2)]
	[return: Newtonsoft_002EJson_002ENullable(1)]
	IXmlNode CreateXmlDocumentType([Newtonsoft_002EJson_002ENullable(1)] string name, string publicId, string systemId, string internalSubset);

	IXmlNode CreateProcessingInstruction(string target, string data);

	IXmlElement CreateElement(string elementName);

	IXmlElement CreateElement(string qualifiedName, string namespaceUri);

	IXmlNode CreateAttribute(string name, string value);

	IXmlNode CreateAttribute(string qualifiedName, string namespaceUri, string value);
}
