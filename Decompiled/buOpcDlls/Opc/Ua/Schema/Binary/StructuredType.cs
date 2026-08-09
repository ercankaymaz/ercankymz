using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Opc.Ua.Schema.Binary;

[GeneratedCode("xsd", "2.0.50727.312")]
[DataContract]
[DebuggerStepThrough]
[XmlType(Namespace = "http://opcfoundation.org/BinarySchema/")]
[ComVisible(true)]
public class StructuredType : TypeDescription
{
	private FieldType[] fieldField;

	private string[] anyAttrField;

	[XmlElement("Field")]
	public FieldType[] Field
	{
		get
		{
			return fieldField;
		}
		set
		{
			fieldField = value;
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
