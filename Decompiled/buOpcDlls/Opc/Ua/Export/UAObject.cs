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
public class UAObject : UAInstance
{
	private byte eventNotifierField;

	[XmlAttribute]
	[DefaultValue(typeof(byte), "0")]
	public byte EventNotifier
	{
		get
		{
			return eventNotifierField;
		}
		set
		{
			eventNotifierField = value;
		}
	}

	public UAObject()
	{
		eventNotifierField = 0;
	}
}
