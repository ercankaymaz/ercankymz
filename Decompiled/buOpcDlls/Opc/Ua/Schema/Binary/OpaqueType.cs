using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Opc.Ua.Schema.Binary;

[XmlInclude(typeof(EnumeratedType))]
[GeneratedCode("xsd", "2.0.50727.312")]
[DataContract]
[DebuggerStepThrough]
[XmlType(Namespace = "http://opcfoundation.org/BinarySchema/")]
[ComVisible(true)]
public class OpaqueType : TypeDescription
{
	private int lengthInBitsField;

	private bool lengthInBitsFieldSpecified;

	private bool byteOrderSignificantField;

	[XmlAttribute]
	public int LengthInBits
	{
		get
		{
			return lengthInBitsField;
		}
		set
		{
			lengthInBitsField = value;
		}
	}

	[XmlIgnore]
	public bool LengthInBitsSpecified
	{
		get
		{
			return lengthInBitsFieldSpecified;
		}
		set
		{
			lengthInBitsFieldSpecified = value;
		}
	}

	[XmlAttribute]
	[DefaultValue(false)]
	public bool ByteOrderSignificant
	{
		get
		{
			return byteOrderSignificantField;
		}
		set
		{
			byteOrderSignificantField = value;
		}
	}

	public OpaqueType()
	{
		byteOrderSignificantField = false;
	}
}
