using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;

namespace Opc.Ua.Export;

[Serializable]
[XmlInclude(typeof(UAType))]
[XmlInclude(typeof(UAReferenceType))]
[XmlInclude(typeof(UADataType))]
[XmlInclude(typeof(UAVariableType))]
[XmlInclude(typeof(UAObjectType))]
[XmlInclude(typeof(UAInstance))]
[XmlInclude(typeof(UAView))]
[XmlInclude(typeof(UAMethod))]
[XmlInclude(typeof(UAVariable))]
[XmlInclude(typeof(UAObject))]
[GeneratedCode("xsd", "4.8.3928.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
[ComVisible(true)]
public class UANode
{
	private LocalizedText[] displayNameField;

	private LocalizedText[] descriptionField;

	private string[] categoryField;

	private string documentationField;

	private Reference[] referencesField;

	private RolePermission[] rolePermissionsField;

	private XmlElement[] extensionsField;

	private string nodeIdField;

	private string browseNameField;

	private uint writeMaskField;

	private uint userWriteMaskField;

	private ushort accessRestrictionsField;

	private bool accessRestrictionsFieldSpecified;

	private bool hasNoPermissionsField;

	private string symbolicNameField;

	private ReleaseStatus releaseStatusField;

	[XmlElement("DisplayName")]
	public LocalizedText[] DisplayName
	{
		get
		{
			return displayNameField;
		}
		set
		{
			displayNameField = value;
		}
	}

	[XmlElement("Description")]
	public LocalizedText[] Description
	{
		get
		{
			return descriptionField;
		}
		set
		{
			descriptionField = value;
		}
	}

	[XmlElement("Category")]
	public string[] Category
	{
		get
		{
			return categoryField;
		}
		set
		{
			categoryField = value;
		}
	}

	public string Documentation
	{
		get
		{
			return documentationField;
		}
		set
		{
			documentationField = value;
		}
	}

	[XmlArrayItem(IsNullable = false)]
	public Reference[] References
	{
		get
		{
			return referencesField;
		}
		set
		{
			referencesField = value;
		}
	}

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

	[XmlArrayItem("Extension", IsNullable = false)]
	public XmlElement[] Extensions
	{
		get
		{
			return extensionsField;
		}
		set
		{
			extensionsField = value;
		}
	}

	[XmlAttribute]
	public string NodeId
	{
		get
		{
			return nodeIdField;
		}
		set
		{
			nodeIdField = value;
		}
	}

	[XmlAttribute]
	public string BrowseName
	{
		get
		{
			return browseNameField;
		}
		set
		{
			browseNameField = value;
		}
	}

	[XmlAttribute]
	[DefaultValue(typeof(uint), "0")]
	public uint WriteMask
	{
		get
		{
			return writeMaskField;
		}
		set
		{
			writeMaskField = value;
		}
	}

	[XmlAttribute]
	[DefaultValue(typeof(uint), "0")]
	public uint UserWriteMask
	{
		get
		{
			return userWriteMaskField;
		}
		set
		{
			userWriteMaskField = value;
		}
	}

	[XmlAttribute]
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

	[XmlIgnore]
	public bool AccessRestrictionsSpecified
	{
		get
		{
			return accessRestrictionsFieldSpecified;
		}
		set
		{
			accessRestrictionsFieldSpecified = value;
		}
	}

	[XmlAttribute]
	[DefaultValue(false)]
	public bool HasNoPermissions
	{
		get
		{
			return hasNoPermissionsField;
		}
		set
		{
			hasNoPermissionsField = value;
		}
	}

	[XmlAttribute]
	public string SymbolicName
	{
		get
		{
			return symbolicNameField;
		}
		set
		{
			symbolicNameField = value;
		}
	}

	[XmlAttribute]
	[DefaultValue(ReleaseStatus.Released)]
	public ReleaseStatus ReleaseStatus
	{
		get
		{
			return releaseStatusField;
		}
		set
		{
			releaseStatusField = value;
		}
	}

	public UANode()
	{
		writeMaskField = 0u;
		userWriteMaskField = 0u;
		hasNoPermissionsField = false;
		releaseStatusField = ReleaseStatus.Released;
	}
}
