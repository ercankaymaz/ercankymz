using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class CurrencyUnitType : IEncodeable, ICloneable, IJsonEncodeable
{
	private short m_numericCode;

	private sbyte m_exponent;

	private string m_alphabeticCode;

	private LocalizedText m_currency;

	[DataMember(Name = "NumericCode", IsRequired = false, Order = 1)]
	public short NumericCode
	{
		get
		{
			return m_numericCode;
		}
		set
		{
			m_numericCode = value;
		}
	}

	[DataMember(Name = "Exponent", IsRequired = false, Order = 2)]
	public sbyte Exponent
	{
		get
		{
			return m_exponent;
		}
		set
		{
			m_exponent = value;
		}
	}

	[DataMember(Name = "AlphabeticCode", IsRequired = false, Order = 3)]
	public string AlphabeticCode
	{
		get
		{
			return m_alphabeticCode;
		}
		set
		{
			m_alphabeticCode = value;
		}
	}

	[DataMember(Name = "Currency", IsRequired = false, Order = 4)]
	public LocalizedText Currency
	{
		get
		{
			return m_currency;
		}
		set
		{
			m_currency = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.CurrencyUnitType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.CurrencyUnitType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.CurrencyUnitType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.CurrencyUnitType_Encoding_DefaultJson;

	public CurrencyUnitType()
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
		m_numericCode = 0;
		m_exponent = 0;
		m_alphabeticCode = null;
		m_currency = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteInt16("NumericCode", NumericCode);
		encoder.WriteSByte("Exponent", Exponent);
		encoder.WriteString("AlphabeticCode", AlphabeticCode);
		encoder.WriteLocalizedText("Currency", Currency);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		NumericCode = decoder.ReadInt16("NumericCode");
		Exponent = decoder.ReadSByte("Exponent");
		AlphabeticCode = decoder.ReadString("AlphabeticCode");
		Currency = decoder.ReadLocalizedText("Currency");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is CurrencyUnitType currencyUnitType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_numericCode, currencyUnitType.m_numericCode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_exponent, currencyUnitType.m_exponent))
		{
			return false;
		}
		if (!Utils.IsEqual(m_alphabeticCode, currencyUnitType.m_alphabeticCode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_currency, currencyUnitType.m_currency))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (CurrencyUnitType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		CurrencyUnitType obj = (CurrencyUnitType)base.MemberwiseClone();
		obj.m_numericCode = (short)Utils.Clone(m_numericCode);
		obj.m_exponent = (sbyte)Utils.Clone(m_exponent);
		obj.m_alphabeticCode = (string)Utils.Clone(m_alphabeticCode);
		obj.m_currency = (LocalizedText)Utils.Clone(m_currency);
		return obj;
	}
}
