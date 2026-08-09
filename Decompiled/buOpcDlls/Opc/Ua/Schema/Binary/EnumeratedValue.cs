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
public class EnumeratedValue
{
	private Documentation documentationField;

	private string nameField;

	private int valueField;

	private bool valueFieldSpecified;

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

	[XmlAttribute]
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
	public int Value
	{
		get
		{
			return valueField;
		}
		set
		{
			valueField = value;
		}
	}

	[XmlIgnore]
	public bool ValueSpecified
	{
		get
		{
			return valueFieldSpecified;
		}
		set
		{
			valueFieldSpecified = value;
		}
	}
}
