using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class SemanticChangeStructureDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private NodeId m_affected;

	private NodeId m_affectedType;

	[DataMember(Name = "Affected", IsRequired = false, Order = 1)]
	public NodeId Affected
	{
		get
		{
			return m_affected;
		}
		set
		{
			m_affected = value;
		}
	}

	[DataMember(Name = "AffectedType", IsRequired = false, Order = 2)]
	public NodeId AffectedType
	{
		get
		{
			return m_affectedType;
		}
		set
		{
			m_affectedType = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.SemanticChangeStructureDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.SemanticChangeStructureDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.SemanticChangeStructureDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.SemanticChangeStructureDataType_Encoding_DefaultJson;

	public SemanticChangeStructureDataType()
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
		m_affected = null;
		m_affectedType = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("Affected", Affected);
		encoder.WriteNodeId("AffectedType", AffectedType);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Affected = decoder.ReadNodeId("Affected");
		AffectedType = decoder.ReadNodeId("AffectedType");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is SemanticChangeStructureDataType semanticChangeStructureDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_affected, semanticChangeStructureDataType.m_affected))
		{
			return false;
		}
		if (!Utils.IsEqual(m_affectedType, semanticChangeStructureDataType.m_affectedType))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (SemanticChangeStructureDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SemanticChangeStructureDataType obj = (SemanticChangeStructureDataType)base.MemberwiseClone();
		obj.m_affected = (NodeId)Utils.Clone(m_affected);
		obj.m_affectedType = (NodeId)Utils.Clone(m_affectedType);
		return obj;
	}
}
