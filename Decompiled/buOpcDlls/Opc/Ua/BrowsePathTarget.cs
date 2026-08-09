using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class BrowsePathTarget : IEncodeable, ICloneable, IJsonEncodeable
{
	private ExpandedNodeId m_targetId;

	private uint m_remainingPathIndex;

	[DataMember(Name = "TargetId", IsRequired = false, Order = 1)]
	public ExpandedNodeId TargetId
	{
		get
		{
			return m_targetId;
		}
		set
		{
			m_targetId = value;
		}
	}

	[DataMember(Name = "RemainingPathIndex", IsRequired = false, Order = 2)]
	public uint RemainingPathIndex
	{
		get
		{
			return m_remainingPathIndex;
		}
		set
		{
			m_remainingPathIndex = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.BrowsePathTarget;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.BrowsePathTarget_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.BrowsePathTarget_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.BrowsePathTarget_Encoding_DefaultJson;

	public BrowsePathTarget()
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
		m_targetId = null;
		m_remainingPathIndex = 0u;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteExpandedNodeId("TargetId", TargetId);
		encoder.WriteUInt32("RemainingPathIndex", RemainingPathIndex);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		TargetId = decoder.ReadExpandedNodeId("TargetId");
		RemainingPathIndex = decoder.ReadUInt32("RemainingPathIndex");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is BrowsePathTarget browsePathTarget))
		{
			return false;
		}
		if (!Utils.IsEqual(m_targetId, browsePathTarget.m_targetId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_remainingPathIndex, browsePathTarget.m_remainingPathIndex))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (BrowsePathTarget)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		BrowsePathTarget obj = (BrowsePathTarget)base.MemberwiseClone();
		obj.m_targetId = (ExpandedNodeId)Utils.Clone(m_targetId);
		obj.m_remainingPathIndex = (uint)Utils.Clone(m_remainingPathIndex);
		return obj;
	}
}
