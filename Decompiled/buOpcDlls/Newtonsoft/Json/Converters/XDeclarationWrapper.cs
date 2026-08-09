using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Linq;

namespace Newtonsoft.Json.Converters;

[Newtonsoft_002EJson_002ENullableContext(2)]
[Newtonsoft_002EJson_002ENullable(0)]
internal class XDeclarationWrapper : XObjectWrapper, IXmlDeclaration, IXmlNode
{
	[Newtonsoft_002EJson_002ENullable(1)]
	[field: Newtonsoft_002EJson_002ENullable(1)]
	internal XDeclaration Declaration
	{
		[Newtonsoft_002EJson_002ENullableContext(1)]
		get;
	}

	public override XmlNodeType NodeType => XmlNodeType.XmlDeclaration;

	public string Version => Declaration.Version;

	public string Encoding
	{
		get
		{
			return Declaration.Encoding;
		}
		set
		{
			Declaration.Encoding = value;
		}
	}

	public string Standalone
	{
		get
		{
			return Declaration.Standalone;
		}
		set
		{
			Declaration.Standalone = value;
		}
	}

	[Newtonsoft_002EJson_002ENullableContext(1)]
	public XDeclarationWrapper(XDeclaration declaration)
		: base(null)
	{
		Declaration = declaration;
	}
}
