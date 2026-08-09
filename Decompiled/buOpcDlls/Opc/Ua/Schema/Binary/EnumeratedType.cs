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
public class EnumeratedType : OpaqueType
{
	private EnumeratedValue[] enumeratedValueField;

	[XmlElement("EnumeratedValue")]
	public EnumeratedValue[] EnumeratedValue
	{
		get
		{
			return enumeratedValueField;
		}
		set
		{
			enumeratedValueField = value;
		}
	}
}
