using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class OptionSet : IEncodeable, ICloneable, IJsonEncodeable
{
	private byte[] m_value;

	private byte[] m_validBits;

	[DataMember(Name = "Value", IsRequired = false, Order = 1)]
	public byte[] Value
	{
		get
		{
			return m_value;
		}
		set
		{
			m_value = value;
		}
	}

	[DataMember(Name = "ValidBits", IsRequired = false, Order = 2)]
	public byte[] ValidBits
	{
		get
		{
			return m_validBits;
		}
		set
		{
			m_validBits = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.OptionSet;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.OptionSet_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.OptionSet_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.OptionSet_Encoding_DefaultJson;

	public OptionSet()
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
		m_value = null;
		m_validBits = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteByteString("Value", Value);
		encoder.WriteByteString("ValidBits", ValidBits);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Value = decoder.ReadByteString("Value");
		ValidBits = decoder.ReadByteString("ValidBits");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is OptionSet optionSet))
		{
			return false;
		}
		if (!Utils.IsEqual(m_value, optionSet.m_value))
		{
			return false;
		}
		if (!Utils.IsEqual(m_validBits, optionSet.m_validBits))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (OptionSet)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		OptionSet obj = (OptionSet)base.MemberwiseClone();
		obj.m_value = (byte[])Utils.Clone(m_value);
		obj.m_validBits = (byte[])Utils.Clone(m_validBits);
		return obj;
	}
}
