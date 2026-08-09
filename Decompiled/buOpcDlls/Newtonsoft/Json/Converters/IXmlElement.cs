using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Converters;

[Newtonsoft_002EJson_002ENullableContext(1)]
internal interface IXmlElement : IXmlNode
{
	bool IsEmpty { get; }

	void SetAttributeNode(IXmlNode attribute);

	[return: Newtonsoft_002EJson_002ENullable(2)]
	string GetPrefixOfNamespace(string namespaceUri);
}
