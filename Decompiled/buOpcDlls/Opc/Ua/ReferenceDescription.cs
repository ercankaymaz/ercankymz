using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ReferenceDescription : IEncodeable, ICloneable, IJsonEncodeable, IFormattable
{
	private NodeId m_referenceTypeId;

	private bool m_isForward;

	private ExpandedNodeId m_nodeId;

	private QualifiedName m_browseName;

	private LocalizedText m_displayName;

	private NodeClass m_nodeClass;

	private ExpandedNodeId m_typeDefinition;

	private bool m_unfiltered;

	[DataMember(Name = "ReferenceTypeId", IsRequired = false, Order = 1)]
	public NodeId ReferenceTypeId
	{
		get
		{
			return m_referenceTypeId;
		}
		set
		{
			m_referenceTypeId = value;
		}
	}

	[DataMember(Name = "IsForward", IsRequired = false, Order = 2)]
	public bool IsForward
	{
		get
		{
			return m_isForward;
		}
		set
		{
			m_isForward = value;
		}
	}

	[DataMember(Name = "NodeId", IsRequired = false, Order = 3)]
	public ExpandedNodeId NodeId
	{
		get
		{
			return m_nodeId;
		}
		set
		{
			m_nodeId = value;
		}
	}

	[DataMember(Name = "BrowseName", IsRequired = false, Order = 4)]
	public QualifiedName BrowseName
	{
		get
		{
			return m_browseName;
		}
		set
		{
			m_browseName = value;
		}
	}

	[DataMember(Name = "DisplayName", IsRequired = false, Order = 5)]
	public LocalizedText DisplayName
	{
		get
		{
			return m_displayName;
		}
		set
		{
			m_displayName = value;
		}
	}

	[DataMember(Name = "NodeClass", IsRequired = false, Order = 6)]
	public NodeClass NodeClass
	{
		get
		{
			return m_nodeClass;
		}
		set
		{
			m_nodeClass = value;
		}
	}

	[DataMember(Name = "TypeDefinition", IsRequired = false, Order = 7)]
	public ExpandedNodeId TypeDefinition
	{
		get
		{
			return m_typeDefinition;
		}
		set
		{
			m_typeDefinition = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.ReferenceDescription;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ReferenceDescription_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ReferenceDescription_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ReferenceDescription_Encoding_DefaultJson;

	public bool Unfiltered
	{
		get
		{
			return m_unfiltered;
		}
		set
		{
			m_unfiltered = value;
		}
	}

	public ReferenceDescription()
	{
		Initialize();
	}

	[OnDeserializing]
	private void Initialize(StreamingContext context)
	{
		Initialize();
	}

	private void Initialize()
	{
		m_referenceTypeId = null;
		m_isForward = true;
		m_nodeId = null;
		m_browseName = null;
		m_displayName = null;
		m_nodeClass = NodeClass.Unspecified;
		m_typeDefinition = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("ReferenceTypeId", ReferenceTypeId);
		encoder.WriteBoolean("IsForward", IsForward);
		encoder.WriteExpandedNodeId("NodeId", NodeId);
		encoder.WriteQualifiedName("BrowseName", BrowseName);
		encoder.WriteLocalizedText("DisplayName", DisplayName);
		encoder.WriteEnumerated("NodeClass", NodeClass);
		encoder.WriteExpandedNodeId("TypeDefinition", TypeDefinition);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ReferenceTypeId = decoder.ReadNodeId("ReferenceTypeId");
		IsForward = decoder.ReadBoolean("IsForward");
		NodeId = decoder.ReadExpandedNodeId("NodeId");
		BrowseName = decoder.ReadQualifiedName("BrowseName");
		DisplayName = decoder.ReadLocalizedText("DisplayName");
		NodeClass = (NodeClass)(object)decoder.ReadEnumerated("NodeClass", typeof(NodeClass));
		TypeDefinition = decoder.ReadExpandedNodeId("TypeDefinition");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ReferenceDescription referenceDescription))
		{
			return false;
		}
		if (!Utils.IsEqual(m_referenceTypeId, referenceDescription.m_referenceTypeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_isForward, referenceDescription.m_isForward))
		{
			return false;
		}
		if (!Utils.IsEqual(m_nodeId, referenceDescription.m_nodeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_browseName, referenceDescription.m_browseName))
		{
			return false;
		}
		if (!Utils.IsEqual(m_displayName, referenceDescription.m_displayName))
		{
			return false;
		}
		if (!Utils.IsEqual(m_nodeClass, referenceDescription.m_nodeClass))
		{
			return false;
		}
		if (!Utils.IsEqual(m_typeDefinition, referenceDescription.m_typeDefinition))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ReferenceDescription)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ReferenceDescription obj = (ReferenceDescription)base.MemberwiseClone();
		obj.m_referenceTypeId = (NodeId)Utils.Clone(m_referenceTypeId);
		obj.m_isForward = (bool)Utils.Clone(m_isForward);
		obj.m_nodeId = (ExpandedNodeId)Utils.Clone(m_nodeId);
		obj.m_browseName = (QualifiedName)Utils.Clone(m_browseName);
		obj.m_displayName = (LocalizedText)Utils.Clone(m_displayName);
		obj.m_nodeClass = (NodeClass)Utils.Clone(m_nodeClass);
		obj.m_typeDefinition = (ExpandedNodeId)Utils.Clone(m_typeDefinition);
		return obj;
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			if (m_displayName != null && !string.IsNullOrEmpty(m_displayName.Text))
			{
				return m_displayName.Text;
			}
			if (!QualifiedName.IsNull(m_browseName))
			{
				return m_browseName.Name;
			}
			object[] array = new object[1];
			NodeClass nodeClass = m_nodeClass;
			array[0] = nodeClass.ToString().ToLower();
			return Utils.Format("(unknown {0})", array);
		}
		throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
	}

	public override string ToString()
	{
		return ToString(null, null);
	}

	public void SetReferenceType(BrowseResultMask resultMask, NodeId referenceTypeId, bool isForward)
	{
		if ((resultMask & BrowseResultMask.ReferenceTypeId) != BrowseResultMask.None)
		{
			m_referenceTypeId = referenceTypeId;
		}
		else
		{
			m_referenceTypeId = null;
		}
		if ((resultMask & BrowseResultMask.IsForward) != BrowseResultMask.None)
		{
			m_isForward = isForward;
		}
		else
		{
			m_isForward = false;
		}
	}

	public void SetTargetAttributes(BrowseResultMask resultMask, NodeClass nodeClass, QualifiedName browseName, LocalizedText displayName, ExpandedNodeId typeDefinition)
	{
		if ((resultMask & BrowseResultMask.NodeClass) != BrowseResultMask.None)
		{
			m_nodeClass = nodeClass;
		}
		else
		{
			m_nodeClass = NodeClass.Unspecified;
		}
		if ((resultMask & BrowseResultMask.BrowseName) != BrowseResultMask.None)
		{
			m_browseName = browseName;
		}
		else
		{
			m_browseName = null;
		}
		if ((resultMask & BrowseResultMask.DisplayName) != BrowseResultMask.None)
		{
			m_displayName = displayName;
		}
		else
		{
			m_displayName = null;
		}
		if ((resultMask & BrowseResultMask.TypeDefinition) != BrowseResultMask.None)
		{
			m_typeDefinition = typeDefinition;
		}
		else
		{
			m_typeDefinition = null;
		}
	}
}
