using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class GenericAttributeValue : IEncodeable, ICloneable, IJsonEncodeable
{
	private uint m_attributeId;

	private Variant m_value;

	[DataMember(Name = "AttributeId", IsRequired = false, Order = 1)]
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.GenericAttributeValue;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.GenericAttributeValue_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.GenericAttributeValue_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.GenericAttributeValue_Encoding_DefaultJson;

	public GenericAttributeValue()
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
		m_attributeId = 0u;
		m_value = Variant.Null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteUInt32("AttributeId", AttributeId);
		encoder.WriteVariant("Value", Value);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		AttributeId = decoder.ReadUInt32("AttributeId");
		Value = decoder.ReadVariant("Value");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is GenericAttributeValue genericAttributeValue))
		{
			return false;
		}
		if (!Utils.IsEqual(m_attributeId, genericAttributeValue.m_attributeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_value, genericAttributeValue.m_value))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (GenericAttributeValue)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		GenericAttributeValue obj = (GenericAttributeValue)base.MemberwiseClone();
		obj.m_attributeId = (uint)Utils.Clone(m_attributeId);
		obj.m_value = (Variant)Utils.Clone(m_value);
		return obj;
	}
}
