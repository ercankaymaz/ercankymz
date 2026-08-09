using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;

namespace Opc.Ua.Export;

[Serializable]
[GeneratedCode("xsd", "4.8.3928.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
[ComVisible(true)]
public class UAVariableType : UAType
{
	private XmlElement valueField;

	private string dataTypeField;

	private int valueRankField;

	private string arrayDimensionsField;

	public XmlElement Value
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

	public UAVariableType()
	{
		dataTypeField = "i=24";
		valueRankField = -1;
		arrayDimensionsField = "";
	}
}
