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
public class ImportDirective
{
	private string namespaceField;

	private string locationField;

	[XmlAttribute]
	public string Namespace
	{
		get
		{
			return namespaceField;
		}
		set
		{
			namespaceField = value;
		}
	}

	[XmlAttribute]
	public string Location
	{
		get
		{
			return locationField;
		}
		set
		{
			locationField = value;
		}
	}
}
