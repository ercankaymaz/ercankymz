using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class FieldTargetDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private Uuid m_dataSetFieldId;

	private string m_receiverIndexRange;

	private NodeId m_targetNodeId;

	private uint m_attributeId;

	private string m_writeIndexRange;

	private OverrideValueHandling m_overrideValueHandling;

	private Variant m_overrideValue;

	[DataMember(Name = "DataSetFieldId", IsRequired = false, Order = 1)]
	public Uuid DataSetFieldId
	{
		get
		{
			return m_dataSetFieldId;
		}
		set
		{
			m_dataSetFieldId = value;
		}
	}

	[DataMember(Name = "ReceiverIndexRange", IsRequired = false, Order = 2)]
	public string ReceiverIndexRange
	{
		get
		{
			return m_receiverIndexRange;
		}
		set
		{
			m_receiverIndexRange = value;
		}
	}

	[DataMember(Name = "TargetNodeId", IsRequired = false, Order = 3)]
	public NodeId TargetNodeId
	{
		get
		{
			return m_targetNodeId;
		}
		set
		{
			m_targetNodeId = value;
		}
	}

	[DataMember(Name = "AttributeId", IsRequired = false, Order = 4)]
	public uint AttributeId
	{
		get
		{
			return m_attributeId;
		}
		set
		{
			m_attributeId = value;
		}
	}

	[DataMember(Name = "WriteIndexRange", IsRequired = false, Order = 5)]
	public string WriteIndexRange
	{
		get
		{
			return m_writeIndexRange;
		}
		set
		{
			m_writeIndexRange = value;
		}
	}

	[DataMember(Name = "OverrideValueHandling", IsRequired = false, Order = 6)]
	public OverrideValueHandling OverrideValueHandling
	{
		get
		{
			return m_overrideValueHandling;
		}
		set
		{
			m_overrideValueHandling = value;
		}
	}

	[DataMember(Name = "OverrideValue", IsRequired = false, Order = 7)]
	public Variant OverrideValue
	{
		get
		{
			return m_overrideValue;
		}
		set
		{
			m_overrideValue = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.FieldTargetDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.FieldTargetDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.FieldTargetDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.FieldTargetDataType_Encoding_DefaultJson;

	public FieldTargetDataType()
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
		m_dataSetFieldId = Uuid.Empty;
		m_receiverIndexRange = null;
		m_targetNodeId = null;
		m_attributeId = 0u;
		m_writeIndexRange = null;
		m_overrideValueHandling = OverrideValueHandling.Disabled;
		m_overrideValue = Variant.Null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteGuid("DataSetFieldId", DataSetFieldId);
		encoder.WriteString("ReceiverIndexRange", ReceiverIndexRange);
		encoder.WriteNodeId("TargetNodeId", TargetNodeId);
		encoder.WriteUInt32("AttributeId", AttributeId);
		encoder.WriteString("WriteIndexRange", WriteIndexRange);
		encoder.WriteEnumerated("OverrideValueHandling", OverrideValueHandling);
		encoder.WriteVariant("OverrideValue", OverrideValue);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		DataSetFieldId = decoder.ReadGuid("DataSetFieldId");
		ReceiverIndexRange = decoder.ReadString("ReceiverIndexRange");
		TargetNodeId = decoder.ReadNodeId("TargetNodeId");
		AttributeId = decoder.ReadUInt32("AttributeId");
		WriteIndexRange = decoder.ReadString("WriteIndexRange");
		OverrideValueHandling = (OverrideValueHandling)(object)decoder.ReadEnumerated("OverrideValueHandling", typeof(OverrideValueHandling));
		OverrideValue = decoder.ReadVariant("OverrideValue");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is FieldTargetDataType fieldTargetDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataSetFieldId, fieldTargetDataType.m_dataSetFieldId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_receiverIndexRange, fieldTargetDataType.m_receiverIndexRange))
		{
			return false;
		}
		if (!Utils.IsEqual(m_targetNodeId, fieldTargetDataType.m_targetNodeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_attributeId, fieldTargetDataType.m_attributeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_writeIndexRange, fieldTargetDataType.m_writeIndexRange))
		{
			return false;
		}
		if (!Utils.IsEqual(m_overrideValueHandling, fieldTargetDataType.m_overrideValueHandling))
		{
			return false;
		}
		if (!Utils.IsEqual(m_overrideValue, fieldTargetDataType.m_overrideValue))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (FieldTargetDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		FieldTargetDataType obj = (FieldTargetDataType)base.MemberwiseClone();
		obj.m_dataSetFieldId = (Uuid)Utils.Clone(m_dataSetFieldId);
		obj.m_receiverIndexRange = (string)Utils.Clone(m_receiverIndexRange);
		obj.m_targetNodeId = (NodeId)Utils.Clone(m_targetNodeId);
		obj.m_attributeId = (uint)Utils.Clone(m_attributeId);
		obj.m_writeIndexRange = (string)Utils.Clone(m_writeIndexRange);
		obj.m_overrideValueHandling = (OverrideValueHandling)Utils.Clone(m_overrideValueHandling);
		obj.m_overrideValue = (Variant)Utils.Clone(m_overrideValue);
		return obj;
	}
}
