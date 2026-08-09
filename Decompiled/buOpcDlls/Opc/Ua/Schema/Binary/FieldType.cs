using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace Opc.Ua.Schema.Binary;

[GeneratedCode("xsd", "2.0.50727.312")]
[DataContract]
[DebuggerStepThrough]
[XmlType(Namespace = "http://opcfoundation.org/BinarySchema/")]
[ComVisible(true)]
public class FieldType
{
	private Documentation documentationField;

	private string nameField;

	private XmlQualifiedName typeNameField;

	private uint lengthField;

	private bool lengthFieldSpecified;

	private string lengthFieldField;

	private bool isLengthInBytesField;

	private string switchFieldField;

	private uint switchValueField;

	private bool switchValueFieldSpecified;

	private SwitchOperand switchOperandField;

	private bool switchOperandFieldSpecified;

	private byte[] terminatorField;

	private string[] anyAttrField;

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
	public XmlQualifiedName TypeName
	{
		get
		{
			return typeNameField;
		}
		set
		{
			typeNameField = value;
		}
	}

	[XmlAttribute]
	public uint Length
	{
		get
		{
			return lengthField;
		}
		set
		{
			lengthField = value;
		}
	}

	[XmlIgnore]
	public bool LengthSpecified
	{
		get
		{
			return lengthFieldSpecified;
		}
		set
		{
			lengthFieldSpecified = value;
		}
	}

	[XmlAttribute]
	public string LengthField
	{
		get
		{
			return lengthFieldField;
		}
		set
		{
			lengthFieldField = value;
		}
	}

	[XmlAttribute]
	[DefaultValue(false)]
	public bool IsLengthInBytes
	{
		get
		{
			return isLengthInBytesField;
		}
		set
		{
			isLengthInBytesField = value;
		}
	}

	[XmlAttribute]
	public string SwitchField
	{
		get
		{
			return switchFieldField;
		}
		set
		{
			switchFieldField = value;
		}
	}

	[XmlAttribute]
	public uint SwitchValue
	{
		get
		{
			return switchValueField;
		}
		set
		{
			switchValueField = value;
		}
	}

	[XmlIgnore]
	public bool SwitchValueSpecified
	{
		get
		{
			return switchValueFieldSpecified;
		}
		set
		{
			switchValueFieldSpecified = value;
		}
	}

	[XmlAttribute]
	public SwitchOperand SwitchOperand
	{
		get
		{
			return switchOperandField;
		}
		set
		{
			switchOperandField = value;
		}
	}

	[XmlIgnore]
	public bool SwitchOperandSpecified
	{
		get
		{
			return switchOperandFieldSpecified;
		}
		set
		{
			switchOperandFieldSpecified = value;
		}
	}

	[XmlAttribute(DataType = "hexBinary")]
	public byte[] Terminator
	{
		get
		{
			return terminatorField;
		}
		set
		{
			terminatorField = value;
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

	public FieldType()
	{
		isLengthInBytesField = false;
	}
}
