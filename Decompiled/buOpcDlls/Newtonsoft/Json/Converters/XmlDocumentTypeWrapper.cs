using System.Runtime.CompilerServices;
using System.Xml;

namespace Newtonsoft.Json.Converters;

[Newtonsoft_002EJson_002ENullableContext(2)]
[Newtonsoft_002EJson_002ENullable(0)]
internal class XmlDocumentTypeWrapper : XmlNodeWrapper, IXmlDocumentType, IXmlNode
{
	[Newtonsoft_002EJson_002ENullable(1)]
	private readonly XmlDocumentType _documentType;

	[Newtonsoft_002EJson_002ENullable(1)]
	public string Name
	{
		[Newtonsoft_002EJson_002ENullableContext(1)]
		get
		{
			return _documentType.Name;
		}
	}

	public string System => _documentType.SystemId;

	public string Public => _documentType.PublicId;

	public string InternalSubset => _documentType.InternalSubset;

	public override string LocalName => "DOCTYPE";

	[Newtonsoft_002EJson_002ENullableContext(1)]
	public XmlDocumentTypeWrapper(XmlDocumentType documentType)
		: base(documentType)
	{
		_documentType = documentType;
	}
}
