using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Opc.Ua.Schema.Binary;

[XmlInclude(typeof(StructuredType))]
[XmlInclude(typeof(OpaqueType))]
[XmlInclude(typeof(EnumeratedType))]
[GeneratedCode("xsd", "2.0.50727.312")]
[DataContract]
[DebuggerStepThrough]
[XmlType(Namespace = "http://opcfoundation.org/BinarySchema/")]
[ComVisible(true)]
public class TypeDescription
{
	private XmlQualifiedName m_qname;

	private Documentation documentationField;

	private string nameField;

	private ByteOrder defaultByteOrderField;

	private bool defaultByteOrderFieldSpecified;

	[XmlIgnore]
	public XmlQualifiedName QName
	{
		get
		{
			return m_qname;
		}
		set
		{
			m_qname = value;
		}
	}

	public Documentation Documentation
	{
		get
		{
			return documentationField;
		}
		set
		{
			documentationField = value;
		}
	}

	[XmlAttribute(DataType = "NCName")]
	public string Name
	{
		get
		{
			return nameField;
		}
		set
		{
			nameField = value;
		}
	}

	[XmlAttribute]
	public ByteOrder DefaultByteOrder
	{
		get
		{
			return defaultByteOrderField;
		}
		set
		{
			defaultByteOrderField = value;
		}
	}

	[XmlIgnore]
	public bool DefaultByteOrderSpecified
	{
		get
		{
			return defaultByteOrderFieldSpecified;
		}
		set
		{
			defaultByteOrderFieldSpecified = value;
		}
	}
}
