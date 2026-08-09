using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Converters;

[Newtonsoft_002EJson_002ENullableContext(2)]
internal interface IXmlDocumentType : IXmlNode
{
	[Newtonsoft_002EJson_002ENullable(1)]
	string Name
	{
		[Newtonsoft_002EJson_002ENullableContext(1)]
		get;
	}

	string System { get; }

	string Public { get; }

	string InternalSubset { get; }
}
