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
public class RolePermission
{
	private uint permissionsField;

	private string valueField;

	[XmlAttribute]
	[DefaultValue(typeof(uint), "0")]
	public uint Permissions
	{
		get
		{
			return permissionsField;
		}
		set
		{
			permissionsField = value;
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

	public RolePermission()
	{
		permissionsField = 0u;
	}
}
