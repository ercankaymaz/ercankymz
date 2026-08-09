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
public class DataTypeField
{
	private LocalizedText[] displayNameField;

	private LocalizedText[] descriptionField;

	private string nameField;

	private string symbolicNameField;

	private string dataTypeField;

	private int valueRankField;

	private string arrayDimensionsField;

	private uint maxStringLengthField;

	private int valueField;

	private bool isOptionalField;

	private bool allowSubTypesField;

	[XmlElement("DisplayName")]
	public LocalizedText[] DisplayName
	{
		get
		{
			return displayNameField;
		}
		set
		{
			displayNameField = value;
		}
	}

	[XmlElement("Description")]
	public LocalizedText[] Description
	{
		get
		{
			return descriptionField;
		}
		set
		{
			descriptionField = value;
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
	[DefaultValue("i=24")]
	public string DataType
	{
		get
		{
			return dataTypeField;
		}
		set
		{
			dataTypeField = value;
		}
	}

	[XmlAttribute]
	[DefaultValue(-1)]
	public int ValueRank
	{
		get
		{
			return valueRankField;
		}
		set
		{
			valueRankField = value;
		}
	}

	[XmlAttribute(DataType = "token")]
	[DefaultValue("")]
	public string ArrayDimensions
	{
		get
		{
			return arrayDimensionsField;
		}
		set
		{
			arrayDimensionsField = value;
		}
	}

	[XmlAttribute]
	[DefaultValue(typeof(uint), "0")]
	public uint MaxStringLength
	{
		get
		{
			return maxStringLengthField;
		}
		set
		{
			maxStringLengthField = value;
		}
	}

	[XmlAttribute]
	[DefaultValue(-1)]
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

	[XmlAttribute]
	[DefaultValue(false)]
	public bool IsOptional
	{
		get
		{
			return isOptionalField;
		}
		set
		{
			isOptionalField = value;
		}
	}

	[XmlAttribute]
	[DefaultValue(false)]
	public bool AllowSubTypes
	{
		get
		{
			return allowSubTypesField;
		}
		set
		{
			allowSubTypesField = value;
		}
	}

	public DataTypeField()
	{
		dataTypeField = "i=24";
		valueRankField = -1;
		arrayDimensionsField = "";
		maxStringLengthField = 0u;
		valueField = -1;
		isOptionalField = false;
		allowSubTypesField = false;
	}
}
