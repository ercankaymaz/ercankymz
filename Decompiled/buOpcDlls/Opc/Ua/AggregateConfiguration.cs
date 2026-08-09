using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class AggregateConfiguration : IEncodeable, ICloneable, IJsonEncodeable
{
	private bool m_useServerCapabilitiesDefaults;

	private bool m_treatUncertainAsBad;

	private byte m_percentDataBad;

	private byte m_percentDataGood;

	private bool m_useSlopedExtrapolation;

	[DataMember(Name = "UseServerCapabilitiesDefaults", IsRequired = false, Order = 1)]
	public bool UseServerCapabilitiesDefaults
	{
		get
		{
			return m_useServerCapabilitiesDefaults;
		}
		set
		{
			m_useServerCapabilitiesDefaults = value;
		}
	}

	[DataMember(Name = "TreatUncertainAsBad", IsRequired = false, Order = 2)]
	public bool TreatUncertainAsBad
	{
		get
		{
			return m_treatUncertainAsBad;
		}
		set
		{
			m_treatUncertainAsBad = value;
		}
	}

	[DataMember(Name = "PercentDataBad", IsRequired = false, Order = 3)]
	public byte PercentDataBad
	{
		get
		{
			return m_percentDataBad;
		}
		set
		{
			m_percentDataBad = value;
		}
	}

	[DataMember(Name = "PercentDataGood", IsRequired = false, Order = 4)]
	public byte PercentDataGood
	{
		get
		{
			return m_percentDataGood;
		}
		set
		{
			m_percentDataGood = value;
		}
	}

	[DataMember(Name = "UseSlopedExtrapolation", IsRequired = false, Order = 5)]
	public bool UseSlopedExtrapolation
	{
		get
		{
			return m_useSlopedExtrapolation;
		}
		set
		{
			m_useSlopedExtrapolation = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.AggregateConfiguration;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.AggregateConfiguration_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.AggregateConfiguration_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.AggregateConfiguration_Encoding_DefaultJson;

	public AggregateConfiguration()
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
		m_useServerCapabilitiesDefaults = true;
		m_treatUncertainAsBad = true;
		m_percentDataBad = 0;
		m_percentDataGood = 0;
		m_useSlopedExtrapolation = true;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteBoolean("UseServerCapabilitiesDefaults", UseServerCapabilitiesDefaults);
		encoder.WriteBoolean("TreatUncertainAsBad", TreatUncertainAsBad);
		encoder.WriteByte("PercentDataBad", PercentDataBad);
		encoder.WriteByte("PercentDataGood", PercentDataGood);
		encoder.WriteBoolean("UseSlopedExtrapolation", UseSlopedExtrapolation);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		UseServerCapabilitiesDefaults = decoder.ReadBoolean("UseServerCapabilitiesDefaults");
		TreatUncertainAsBad = decoder.ReadBoolean("TreatUncertainAsBad");
		PercentDataBad = decoder.ReadByte("PercentDataBad");
		PercentDataGood = decoder.ReadByte("PercentDataGood");
		UseSlopedExtrapolation = decoder.ReadBoolean("UseSlopedExtrapolation");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is AggregateConfiguration aggregateConfiguration))
		{
			return false;
		}
		if (!Utils.IsEqual(m_useServerCapabilitiesDefaults, aggregateConfiguration.m_useServerCapabilitiesDefaults))
		{
			return false;
		}
		if (!Utils.IsEqual(m_treatUncertainAsBad, aggregateConfiguration.m_treatUncertainAsBad))
		{
			return false;
		}
		if (!Utils.IsEqual(m_percentDataBad, aggregateConfiguration.m_percentDataBad))
		{
			return false;
		}
		if (!Utils.IsEqual(m_percentDataGood, aggregateConfiguration.m_percentDataGood))
		{
			return false;
		}
		if (!Utils.IsEqual(m_useSlopedExtrapolation, aggregateConfiguration.m_useSlopedExtrapolation))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (AggregateConfiguration)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		AggregateConfiguration obj = (AggregateConfiguration)base.MemberwiseClone();
		obj.m_useServerCapabilitiesDefaults = (bool)Utils.Clone(m_useServerCapabilitiesDefaults);
		obj.m_treatUncertainAsBad = (bool)Utils.Clone(m_treatUncertainAsBad);
		obj.m_percentDataBad = (byte)Utils.Clone(m_percentDataBad);
		obj.m_percentDataGood = (byte)Utils.Clone(m_percentDataGood);
		obj.m_useSlopedExtrapolation = (bool)Utils.Clone(m_useSlopedExtrapolation);
		return obj;
	}
}
