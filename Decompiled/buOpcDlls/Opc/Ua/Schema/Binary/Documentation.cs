using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Opc.Ua.Schema.Binary;

[GeneratedCode("xsd", "2.0.50727.312")]
[DataContract]
[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://opcfoundation.org/BinarySchema/")]
[XmlRoot(Namespace = "http://opcfoundation.org/BinarySchema/", IsNullable = false)]
[ComVisible(true)]
public class Documentation
{
	private XmlElement[] itemsField;

	private string[] textField;

	private string[] anyAttrField;

	[XmlAnyElement]
	public XmlElement[] Items
	{
		get
		{
			return itemsField;
		}
		set
		{
			itemsField = value;
		}
	}

	[XmlText]
	public string[] Text
	{
		get
		{
			return textField;
		}
		set
		{
			textField = value;
		}
	}

	public string[] AnyAttr
	{
		get
		{
			return anyAttrField;
		}
		set
		{
			anyAttrField = value;
		}
	}
}
