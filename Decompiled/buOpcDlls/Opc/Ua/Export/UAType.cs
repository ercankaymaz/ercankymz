using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace Opc.Ua.Export;

[Serializable]
[XmlInclude(typeof(UAReferenceType))]
[XmlInclude(typeof(UADataType))]
[XmlInclude(typeof(UAVariableType))]
[XmlInclude(typeof(UAObjectType))]
[GeneratedCode("xsd", "4.8.3928.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
[ComVisible(true)]
public class UAType : UANode
{
	private bool isAbstractField;

	[XmlAttribute]
	[DefaultValue(false)]
	public bool IsAbstract
	{
		get
		{
			return isAbstractField;
		}
		set
		{
			isAbstractField = value;
		}
	}

	public UAType()
	{
		isAbstractField = false;
	}
}
