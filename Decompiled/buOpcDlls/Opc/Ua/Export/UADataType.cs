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
public class UADataType : UAType
{
	private DataTypeDefinition definitionField;

	private DataTypePurpose purposeField;

	public DataTypeDefinition Definition
	{
		get
		{
			return definitionField;
		}
		set
		{
			definitionField = value;
		}
	}

	[XmlAttribute]
	[DefaultValue(DataTypePurpose.Normal)]
	public DataTypePurpose Purpose
	{
		get
		{
			return purposeField;
		}
		set
		{
			purposeField = value;
		}
	}

	public UADataType()
	{
		purposeField = DataTypePurpose.Normal;
	}
}
