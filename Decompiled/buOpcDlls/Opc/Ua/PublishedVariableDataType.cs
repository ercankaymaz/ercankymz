using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class PublishedVariableDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private NodeId m_publishedVariable;

	private uint m_attributeId;

	private double m_samplingIntervalHint;

	private uint m_deadbandType;

	private double m_deadbandValue;

	private string m_indexRange;

	private Variant m_substituteValue;

	private QualifiedNameCollection m_metaDataProperties;

	[DataMember(Name = "PublishedVariable", IsRequired = false, Order = 1)]
	public NodeId PublishedVariable
	{
		get
		{
			return m_publishedVariable;
		}
		set
		{
			m_publishedVariable = value;
		}
	}

	[DataMember(Name = "AttributeId", IsRequired = false, Order = 2)]
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

	[DataMember(Name = "SamplingIntervalHint", IsRequired = false, Order = 3)]
	public double SamplingIntervalHint
	{
		get
		{
			return m_samplingIntervalHint;
		}
		set
		{
			m_samplingIntervalHint = value;
		}
	}

	[DataMember(Name = "DeadbandType", IsRequired = false, Order = 4)]
	public uint DeadbandType
	{
		get
		{
			return m_deadbandType;
		}
		set
		{
			m_deadbandType = value;
		}
	}

	[DataMember(Name = "DeadbandValue", IsRequired = false, Order = 5)]
	public double DeadbandValue
	{
		get
		{
			return m_deadbandValue;
		}
		set
		{
			m_deadbandValue = value;
		}
	}

	[DataMember(Name = "IndexRange", IsRequired = false, Order = 6)]
	public string IndexRange
	{
		get
		{
			return m_indexRange;
		}
		set
		{
			m_indexRange = value;
		}
	}

	[DataMember(Name = "SubstituteValue", IsRequired = false, Order = 7)]
	public Variant SubstituteValue
	{
		get
		{
			return m_substituteValue;
		}
		set
		{
			m_substituteValue = value;
		}
	}

	[DataMember(Name = "MetaDataProperties", IsRequired = false, Order = 8)]
	public QualifiedNameCollection MetaDataProperties
	{
		get
		{
			return m_metaDataProperties;
		}
		set
		{
			m_metaDataProperties = value;
			if (value == null)
			{
				m_metaDataProperties = new QualifiedNameCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.PublishedVariableDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.PublishedVariableDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.PublishedVariableDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.PublishedVariableDataType_Encoding_DefaultJson;

	public PublishedVariableDataType()
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
		m_publishedVariable = null;
		m_attributeId = 0u;
		m_samplingIntervalHint = 0.0;
		m_deadbandType = 0u;
		m_deadbandValue = 0.0;
		m_indexRange = null;
		m_substituteValue = Variant.Null;
		m_metaDataProperties = new QualifiedNameCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("PublishedVariable", PublishedVariable);
		encoder.WriteUInt32("AttributeId", AttributeId);
		encoder.WriteDouble("SamplingIntervalHint", SamplingIntervalHint);
		encoder.WriteUInt32("DeadbandType", DeadbandType);
		encoder.WriteDouble("DeadbandValue", DeadbandValue);
		encoder.WriteString("IndexRange", IndexRange);
		encoder.WriteVariant("SubstituteValue", SubstituteValue);
		encoder.WriteQualifiedNameArray("MetaDataProperties", MetaDataProperties);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		PublishedVariable = decoder.ReadNodeId("PublishedVariable");
		AttributeId = decoder.ReadUInt32("AttributeId");
		SamplingIntervalHint = decoder.ReadDouble("SamplingIntervalHint");
		DeadbandType = decoder.ReadUInt32("DeadbandType");
		DeadbandValue = decoder.ReadDouble("DeadbandValue");
		IndexRange = decoder.ReadString("IndexRange");
		SubstituteValue = decoder.ReadVariant("SubstituteValue");
		MetaDataProperties = decoder.ReadQualifiedNameArray("MetaDataProperties");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is PublishedVariableDataType publishedVariableDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_publishedVariable, publishedVariableDataType.m_publishedVariable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_attributeId, publishedVariableDataType.m_attributeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_samplingIntervalHint, publishedVariableDataType.m_samplingIntervalHint))
		{
			return false;
		}
		if (!Utils.IsEqual(m_deadbandType, publishedVariableDataType.m_deadbandType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_deadbandValue, publishedVariableDataType.m_deadbandValue))
		{
			return false;
		}
		if (!Utils.IsEqual(m_indexRange, publishedVariableDataType.m_indexRange))
		{
			return false;
		}
		if (!Utils.IsEqual(m_substituteValue, publishedVariableDataType.m_substituteValue))
		{
			return false;
		}
		if (!Utils.IsEqual(m_metaDataProperties, publishedVariableDataType.m_metaDataProperties))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (PublishedVariableDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		PublishedVariableDataType obj = (PublishedVariableDataType)base.MemberwiseClone();
		obj.m_publishedVariable = (NodeId)Utils.Clone(m_publishedVariable);
		obj.m_attributeId = (uint)Utils.Clone(m_attributeId);
		obj.m_samplingIntervalHint = (double)Utils.Clone(m_samplingIntervalHint);
		obj.m_deadbandType = (uint)Utils.Clone(m_deadbandType);
		obj.m_deadbandValue = (double)Utils.Clone(m_deadbandValue);
		obj.m_indexRange = (string)Utils.Clone(m_indexRange);
		obj.m_substituteValue = (Variant)Utils.Clone(m_substituteValue);
		obj.m_metaDataProperties = (QualifiedNameCollection)Utils.Clone(m_metaDataProperties);
		return obj;
	}
}
