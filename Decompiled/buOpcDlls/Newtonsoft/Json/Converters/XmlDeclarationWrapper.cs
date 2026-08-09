using System.Runtime.CompilerServices;
using System.Xml;

namespace Newtonsoft.Json.Converters;

[Newtonsoft_002EJson_002ENullableContext(2)]
[Newtonsoft_002EJson_002ENullable(0)]
internal class XmlDeclarationWrapper : XmlNodeWrapper, IXmlDeclaration, IXmlNode
{
	[Newtonsoft_002EJson_002ENullable(1)]
	private readonly XmlDeclaration _declaration;

	public string Version => _declaration.Version;

	public string Encoding
	{
		get
		{
			return _declaration.Encoding;
		}
		set
		{
			_declaration.Encoding = value;
		}
	}

	public string Standalone
	{
		get
		{
			return _declaration.Standalone;
		}
		set
		{
			_declaration.Standalone = value;
		}
	}

	[Newtonsoft_002EJson_002ENullableContext(1)]
	public XmlDeclarationWrapper(XmlDeclaration declaration)
		: base(declaration)
	{
		_declaration = declaration;
	}
}
