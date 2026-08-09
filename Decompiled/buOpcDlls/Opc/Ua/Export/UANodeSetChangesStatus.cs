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
[XmlType(AnonymousType = true, Namespace = "http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
[XmlRoot(Namespace = "http://opcfoundation.org/UA/2011/03/UANodeSet.xsd", IsNullable = false)]
[ComVisible(true)]
public class UANodeSetChangesStatus
{
	private NodeSetStatus[] nodesToAddField;

	private NodeSetStatus[] referencesToAddField;

	private NodeSetStatus[] nodesToDeleteField;

	private NodeSetStatus[] referencesToDeleteField;

	private DateTime lastModifiedField;

	private bool lastModifiedFieldSpecified;

	private string transactionIdField;

	[XmlArrayItem("Status", IsNullable = false)]
	public NodeSetStatus[] NodesToAdd
	{
		get
		{
			return nodesToAddField;
		}
		set
		{
			nodesToAddField = value;
		}
	}

	[XmlArrayItem("Status", IsNullable = false)]
	public NodeSetStatus[] ReferencesToAdd
	{
		get
		{
			return referencesToAddField;
		}
		set
		{
			referencesToAddField = value;
		}
	}

	[XmlArrayItem("Status", IsNullable = false)]
	public NodeSetStatus[] NodesToDelete
	{
		get
		{
			return nodesToDeleteField;
		}
		set
		{
			nodesToDeleteField = value;
		}
	}

	[XmlArrayItem("Status", IsNullable = false)]
	public NodeSetStatus[] ReferencesToDelete
	{
		get
		{
			return referencesToDeleteField;
		}
		set
		{
			referencesToDeleteField = value;
		}
	}

	[XmlAttribute]
	public DateTime LastModified
	{
		get
		{
			return lastModifiedField;
		}
		set
		{
			lastModifiedField = value;
		}
	}

	[XmlIgnore]
	public bool LastModifiedSpecified
	{
		get
		{
			return lastModifiedFieldSpecified;
		}
		set
		{
			lastModifiedFieldSpecified = value;
		}
	}

	[XmlAttribute]
	public string TransactionId
	{
		get
		{
			return transactionIdField;
		}
		set
		{
			transactionIdField = value;
		}
	}
}
