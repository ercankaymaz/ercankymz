using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace Opc.Ua.Export;

[Serializable]
[GeneratedCode("xsd", "4.8.3928.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
[ComVisible(true)]
public class DataTypeDefinition
{
	private DataTypeField[] fieldField;

	private string nameField;

	private string symbolicNameField;

	private bool isUnionField;

	private bool isOptionSetField;

	private string baseTypeField;

	[XmlElement("Field")]
	public DataTypeField[] Field
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
	public string SymbolicName
	{
		get
		{
			return symbolicNameField;
		}
		set
		{
			symbolicNameField = value;
		}
	}

	[XmlAttribute]
	[DefaultValue(false)]
	public bool IsUnion
	{
		get
		{
			return isUnionField;
		}
		set
		{
			isUnionField = value;
		}
	}

	[XmlAttribute]
	[DefaultValue(false)]
	public bool IsOptionSet
	{
		get
		{
			return isOptionSetField;
		}
		set
		{
			isOptionSetField = value;
		}
	}

	[XmlAttribute]
	[DefaultValue("")]
	public string BaseType
	{
		get
		{
			return baseTypeField;
		}
		set
		{
			baseTypeField = value;
		}
	}

	public DataTypeDefinition()
	{
		isUnionField = false;
		isOptionSetField = false;
		baseTypeField = "";
	}
}
