using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Converters;

[Newtonsoft_002EJson_002ENullableContext(2)]
internal interface IXmlDeclaration : IXmlNode
{
	string Version { get; }

	string Encoding { get; set; }

	string Standalone { get; set; }
}
