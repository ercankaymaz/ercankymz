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
public class ReferenceChange
{
	private string sourceField;

	private string referenceTypeField;

	private bool isForwardField;

	private string valueField;

	[XmlAttribute]
	public string Source
	{
		get
		{
			return sourceField;
		}
		set
		{
			sourceField = value;
		}
	}

	[XmlAttribute]
	public string ReferenceType
	{
		get
		{
			return referenceTypeField;
		}
		set
		{
			referenceTypeField = value;
		}
	}

	[XmlAttribute]
	[DefaultValue(true)]
	public bool IsForward
	{
		get
		{
			return isForwardField;
		}
		set
		{
			isForwardField = value;
		}
	}

	[XmlText]
	public string Value
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

	public ReferenceChange()
	{
		isForwardField = true;
	}
}
