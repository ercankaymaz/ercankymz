using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Opc.Ua.Schema.Binary;

[GeneratedCode("xsd", "2.0.50727.312")]
[DataContract]
[DebuggerStepThrough]
[XmlType(AnonymousType = true, Namespace = "http://opcfoundation.org/BinarySchema/")]
[XmlRoot(Namespace = "http://opcfoundation.org/BinarySchema/", IsNullable = false)]
[ComVisible(true)]
public class TypeDictionary
{
	private Documentation documentationField;

	private ImportDirective[] importField;

	private TypeDescription[] itemsField;

	private string targetNamespaceField;

	private ByteOrder defaultByteOrderField;

	private bool defaultByteOrderFieldSpecified;

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

	[XmlElement("Import")]
	public ImportDirective[] Import
	{
		get
		{
			return importField;
		}
		set
		{
			importField = value;
		}
	}

	[XmlElement("EnumeratedType", typeof(EnumeratedType))]
	[XmlElement("OpaqueType", typeof(OpaqueType))]
	[XmlElement("StructuredType", typeof(StructuredType))]
	public TypeDescription[] Items
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

	[XmlAttribute]
	public string TargetNamespace
	{
		get
		{
			return targetNamespaceField;
		}
		set
		{
			targetNamespaceField = value;
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
