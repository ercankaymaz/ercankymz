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
public class UAMethod : UAInstance
{
	private UAMethodArgument[] argumentDescriptionField;

	private bool executableField;

	private bool userExecutableField;

	private string methodDeclarationIdField;

	[XmlElement("ArgumentDescription")]
	public UAMethodArgument[] ArgumentDescription
	{
		get
		{
			return argumentDescriptionField;
		}
		set
		{
			argumentDescriptionField = value;
		}
	}

	[XmlAttribute]
	[DefaultValue(true)]
	public bool Executable
	{
		get
		{
			return executableField;
		}
		set
		{
			executableField = value;
		}
	}

	[XmlAttribute]
	[DefaultValue(true)]
	public bool UserExecutable
	{
		get
		{
			return userExecutableField;
		}
		set
		{
			userExecutableField = value;
		}
	}

	[XmlAttribute]
	public string MethodDeclarationId
	{
		get
		{
			return methodDeclarationIdField;
		}
		set
		{
			methodDeclarationIdField = value;
		}
	}

	public UAMethod()
	{
		executableField = true;
		userExecutableField = true;
	}
}
