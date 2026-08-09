using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace Opc.Ua.Export;

[Serializable]
[XmlInclude(typeof(UAView))]
[XmlInclude(typeof(UAMethod))]
[XmlInclude(typeof(UAVariable))]
[XmlInclude(typeof(UAObject))]
[GeneratedCode("xsd", "4.8.3928.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
[ComVisible(true)]
public class UAInstance : UANode
{
	private string parentNodeIdField;

	[XmlAttribute]
	public string ParentNodeId
	{
		get
		{
			return parentNodeIdField;
		}
		set
		{
			parentNodeIdField = value;
		}
	}
}
