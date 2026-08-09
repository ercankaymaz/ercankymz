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
public class NodeToDelete
{
	private bool deleteReverseReferencesField;

	private string valueField;

	[XmlAttribute]
	[DefaultValue(true)]
	public bool DeleteReverseReferences
	{
		get
		{
			return deleteReverseReferencesField;
		}
		set
		{
			deleteReverseReferencesField = value;
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

	public NodeToDelete()
	{
		deleteReverseReferencesField = true;
	}
}
