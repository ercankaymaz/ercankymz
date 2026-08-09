using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ModelChangeStructureDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private NodeId m_affected;

	private NodeId m_affectedType;

	private byte m_verb;

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

	[DataMember(Name = "Verb", IsRequired = false, Order = 3)]
	public byte Verb
	{
		get
		{
			return m_verb;
		}
		set
		{
			m_verb = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.ModelChangeStructureDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ModelChangeStructureDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ModelChangeStructureDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ModelChangeStructureDataType_Encoding_DefaultJson;

	public ModelChangeStructureDataType()
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
		m_verb = 0;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("Affected", Affected);
		encoder.WriteNodeId("AffectedType", AffectedType);
		encoder.WriteByte("Verb", Verb);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Affected = decoder.ReadNodeId("Affected");
		AffectedType = decoder.ReadNodeId("AffectedType");
		Verb = decoder.ReadByte("Verb");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ModelChangeStructureDataType modelChangeStructureDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_affected, modelChangeStructureDataType.m_affected))
		{
			return false;
		}
		if (!Utils.IsEqual(m_affectedType, modelChangeStructureDataType.m_affectedType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_verb, modelChangeStructureDataType.m_verb))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ModelChangeStructureDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ModelChangeStructureDataType obj = (ModelChangeStructureDataType)base.MemberwiseClone();
		obj.m_affected = (NodeId)Utils.Clone(m_affected);
		obj.m_affectedType = (NodeId)Utils.Clone(m_affectedType);
		obj.m_verb = (byte)Utils.Clone(m_verb);
		return obj;
	}
}
