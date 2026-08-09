using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class PublishedDataItemsDataType : PublishedDataSetSourceDataType
{
	private PublishedVariableDataTypeCollection m_publishedData;

	[DataMember(Name = "PublishedData", IsRequired = false, Order = 1)]
	public PublishedVariableDataTypeCollection PublishedData
	{
		get
		{
			return m_publishedData;
		}
		set
		{
			m_publishedData = value;
			if (value == null)
			{
				m_publishedData = new PublishedVariableDataTypeCollection();
			}
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.PublishedDataItemsDataType;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.PublishedDataItemsDataType_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.PublishedDataItemsDataType_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.PublishedDataItemsDataType_Encoding_DefaultJson;

	public PublishedDataItemsDataType()
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
		m_publishedData = new PublishedVariableDataTypeCollection();
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeableArray("PublishedData", PublishedData.ToArray(), typeof(PublishedVariableDataType));
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		PublishedData = (PublishedVariableDataType[])decoder.ReadEncodeableArray("PublishedData", typeof(PublishedVariableDataType));
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is PublishedDataItemsDataType publishedDataItemsDataType))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_publishedData, publishedDataItemsDataType.m_publishedData))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (PublishedDataItemsDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		PublishedDataItemsDataType obj = (PublishedDataItemsDataType)base.MemberwiseClone();
		obj.m_publishedData = (PublishedVariableDataTypeCollection)Utils.Clone(m_publishedData);
		return obj;
	}
}
