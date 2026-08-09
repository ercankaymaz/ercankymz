using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class BrowseDescription : IEncodeable, ICloneable, IJsonEncodeable
{
	private NodeId m_nodeId;

	private BrowseDirection m_browseDirection;

	private NodeId m_referenceTypeId;

	private bool m_includeSubtypes;

	private uint m_nodeClassMask;

	private uint m_resultMask;

	private object m_handle;

	[DataMember(Name = "NodeId", IsRequired = false, Order = 1)]
	public NodeId NodeId
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

	[DataMember(Name = "BrowseDirection", IsRequired = false, Order = 2)]
	public BrowseDirection BrowseDirection
	{
		get
		{
			return m_browseDirection;
		}
		set
		{
			m_browseDirection = value;
		}
	}

	[DataMember(Name = "ReferenceTypeId", IsRequired = false, Order = 3)]
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

	[DataMember(Name = "IncludeSubtypes", IsRequired = false, Order = 4)]
	public bool IncludeSubtypes
	{
		get
		{
			return m_includeSubtypes;
		}
		set
		{
			m_includeSubtypes = value;
		}
	}

	[DataMember(Name = "NodeClassMask", IsRequired = false, Order = 5)]
	public uint NodeClassMask
	{
		get
		{
			return m_nodeClassMask;
		}
		set
		{
			m_nodeClassMask = value;
		}
	}

	[DataMember(Name = "ResultMask", IsRequired = false, Order = 6)]
	public uint ResultMask
	{
		get
		{
			return m_resultMask;
		}
		set
		{
			m_resultMask = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.BrowseDescription;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.BrowseDescription_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.BrowseDescription_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.BrowseDescription_Encoding_DefaultJson;

	public object Handle
	{
		get
		{
			return m_handle;
		}
		set
		{
			m_handle = value;
		}
	}

	public BrowseDescription()
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
		m_nodeId = null;
		m_browseDirection = BrowseDirection.Forward;
		m_referenceTypeId = null;
		m_includeSubtypes = true;
		m_nodeClassMask = 0u;
		m_resultMask = 0u;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("NodeId", NodeId);
		encoder.WriteEnumerated("BrowseDirection", BrowseDirection);
		encoder.WriteNodeId("ReferenceTypeId", ReferenceTypeId);
		encoder.WriteBoolean("IncludeSubtypes", IncludeSubtypes);
		encoder.WriteUInt32("NodeClassMask", NodeClassMask);
		encoder.WriteUInt32("ResultMask", ResultMask);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		NodeId = decoder.ReadNodeId("NodeId");
		BrowseDirection = (BrowseDirection)(object)decoder.ReadEnumerated("BrowseDirection", typeof(BrowseDirection));
		ReferenceTypeId = decoder.ReadNodeId("ReferenceTypeId");
		IncludeSubtypes = decoder.ReadBoolean("IncludeSubtypes");
		NodeClassMask = decoder.ReadUInt32("NodeClassMask");
		ResultMask = decoder.ReadUInt32("ResultMask");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is BrowseDescription browseDescription))
		{
			return false;
		}
		if (!Utils.IsEqual(m_nodeId, browseDescription.m_nodeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_browseDirection, browseDescription.m_browseDirection))
		{
			return false;
		}
		if (!Utils.IsEqual(m_referenceTypeId, browseDescription.m_referenceTypeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_includeSubtypes, browseDescription.m_includeSubtypes))
		{
			return false;
		}
		if (!Utils.IsEqual(m_nodeClassMask, browseDescription.m_nodeClassMask))
		{
			return false;
		}
		if (!Utils.IsEqual(m_resultMask, browseDescription.m_resultMask))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (BrowseDescription)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BrowseDescription obj = (BrowseDescription)base.MemberwiseClone();
		obj.m_nodeId = (NodeId)Utils.Clone(m_nodeId);
		obj.m_browseDirection = (BrowseDirection)Utils.Clone(m_browseDirection);
		obj.m_referenceTypeId = (NodeId)Utils.Clone(m_referenceTypeId);
		obj.m_includeSubtypes = (bool)Utils.Clone(m_includeSubtypes);
		obj.m_nodeClassMask = (uint)Utils.Clone(m_nodeClassMask);
		obj.m_resultMask = (uint)Utils.Clone(m_resultMask);
		return obj;
	}
}
