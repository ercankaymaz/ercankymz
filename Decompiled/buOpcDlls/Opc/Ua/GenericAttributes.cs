using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class GenericAttributes : NodeAttributes
{
	private GenericAttributeValueCollection m_attributeValues;

	[DataMember(Name = "AttributeValues", IsRequired = false, Order = 1)]
	public GenericAttributeValueCollection AttributeValues
	{
		get
		{
			return m_attributeValues;
		}
		set
		{
			m_attributeValues = value;
			if (value == null)
			{
				m_attributeValues = new GenericAttributeValueCollection();
			}
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.GenericAttributes;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.GenericAttributes_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.GenericAttributes_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.GenericAttributes_Encoding_DefaultJson;

	public GenericAttributes()
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
		m_attributeValues = new GenericAttributeValueCollection();
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeableArray("AttributeValues", AttributeValues.ToArray(), typeof(GenericAttributeValue));
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		AttributeValues = (GenericAttributeValue[])decoder.ReadEncodeableArray("AttributeValues", typeof(GenericAttributeValue));
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is GenericAttributes genericAttributes))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_attributeValues, genericAttributes.m_attributeValues))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (GenericAttributes)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		GenericAttributes obj = (GenericAttributes)base.MemberwiseClone();
		obj.m_attributeValues = (GenericAttributeValueCollection)Utils.Clone(m_attributeValues);
		return obj;
	}
}
