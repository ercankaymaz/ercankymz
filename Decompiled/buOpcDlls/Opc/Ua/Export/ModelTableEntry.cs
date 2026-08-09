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
public class ModelTableEntry
{
	private RolePermission[] rolePermissionsField;

	private ModelTableEntry[] requiredModelField;

	private string modelUriField;

	private string xmlSchemaUriField;

	private string versionField;

	private DateTime publicationDateField;

	private bool publicationDateFieldSpecified;

	private ushort accessRestrictionsField;

	[XmlArrayItem(IsNullable = false)]
	public RolePermission[] RolePermissions
	{
		get
		{
			return rolePermissionsField;
		}
		set
		{
			rolePermissionsField = value;
		}
	}

	[XmlElement("RequiredModel")]
	public ModelTableEntry[] RequiredModel
	{
		get
		{
			return requiredModelField;
		}
		set
		{
			requiredModelField = value;
		}
	}

	[XmlAttribute]
	public string ModelUri
	{
		get
		{
			return modelUriField;
		}
		set
		{
			modelUriField = value;
		}
	}

	[XmlAttribute]
	public string XmlSchemaUri
	{
		get
		{
			return xmlSchemaUriField;
		}
		set
		{
			xmlSchemaUriField = value;
		}
	}

	[XmlAttribute]
	public string Version
	{
		get
		{
			return versionField;
		}
		set
		{
			versionField = value;
		}
	}

	[XmlAttribute]
	public DateTime PublicationDate
	{
		get
		{
			return publicationDateField;
		}
		set
		{
			publicationDateField = value;
		}
	}

	[XmlIgnore]
	public bool PublicationDateSpecified
	{
		get
		{
			return publicationDateFieldSpecified;
		}
		set
		{
			publicationDateFieldSpecified = value;
		}
	}

	[XmlAttribute]
	[DefaultValue(typeof(ushort), "0")]
	public ushort AccessRestrictions
	{
		get
		{
			return accessRestrictionsField;
		}
		set
		{
			accessRestrictionsField = value;
		}
	}

	public ModelTableEntry()
	{
		accessRestrictionsField = 0;
	}
}
