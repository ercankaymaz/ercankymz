using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class KeyValuePair : IEncodeable, ICloneable, IJsonEncodeable
{
	private QualifiedName m_key;

	private Variant m_value;

	[DataMember(Name = "Key", IsRequired = false, Order = 1)]
	public QualifiedName Key
	{
		get
		{
			return m_key;
		}
		set
		{
			m_key = value;
		}
	}

	[DataMember(Name = "Value", IsRequired = false, Order = 2)]
	public Variant Value
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.KeyValuePair;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.KeyValuePair_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.KeyValuePair_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.KeyValuePair_Encoding_DefaultJson;

	public KeyValuePair()
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
		m_key = null;
		m_value = Variant.Null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteQualifiedName("Key", Key);
		encoder.WriteVariant("Value", Value);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Key = decoder.ReadQualifiedName("Key");
		Value = decoder.ReadVariant("Value");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is KeyValuePair keyValuePair))
		{
			return false;
		}
		if (!Utils.IsEqual(m_key, keyValuePair.m_key))
		{
			return false;
		}
		if (!Utils.IsEqual(m_value, keyValuePair.m_value))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (KeyValuePair)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		KeyValuePair obj = (KeyValuePair)base.MemberwiseClone();
		obj.m_key = (QualifiedName)Utils.Clone(m_key);
		obj.m_value = (Variant)Utils.Clone(m_value);
		return obj;
	}
}
