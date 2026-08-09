using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Newtonsoft.Json.Converters;

[Newtonsoft_002EJson_002ENullableContext(2)]
[Newtonsoft_002EJson_002ENullable(0)]
internal class XDocumentTypeWrapper : XObjectWrapper, IXmlDocumentType, IXmlNode
{
	[Newtonsoft_002EJson_002ENullable(1)]
	private readonly XDocumentType _documentType;

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
	public XDocumentTypeWrapper(XDocumentType documentType)
		: base(documentType)
	{
		_documentType = documentType;
	}
}
