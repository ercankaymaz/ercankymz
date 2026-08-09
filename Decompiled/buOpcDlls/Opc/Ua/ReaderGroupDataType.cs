using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ReaderGroupDataType : PubSubGroupDataType
{
	private ExtensionObject m_transportSettings;

	private ExtensionObject m_messageSettings;

	private DataSetReaderDataTypeCollection m_dataSetReaders;

	[DataMember(Name = "TransportSettings", IsRequired = false, Order = 1)]
	public ExtensionObject TransportSettings
	{
		get
		{
			return m_transportSettings;
		}
		set
		{
			m_transportSettings = value;
		}
	}

	[DataMember(Name = "MessageSettings", IsRequired = false, Order = 2)]
	public ExtensionObject MessageSettings
	{
		get
		{
			return m_messageSettings;
		}
		set
		{
			m_messageSettings = value;
		}
	}

	[DataMember(Name = "DataSetReaders", IsRequired = false, Order = 3)]
	public DataSetReaderDataTypeCollection DataSetReaders
	{
		get
		{
			return m_dataSetReaders;
		}
		set
		{
			m_dataSetReaders = value;
			if (value == null)
			{
				m_dataSetReaders = new DataSetReaderDataTypeCollection();
			}
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.ReaderGroupDataType;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.ReaderGroupDataType_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.ReaderGroupDataType_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.ReaderGroupDataType_Encoding_DefaultJson;

	public ReaderGroupDataType()
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
		m_transportSettings = null;
		m_messageSettings = null;
		m_dataSetReaders = new DataSetReaderDataTypeCollection();
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteExtensionObject("TransportSettings", TransportSettings);
		encoder.WriteExtensionObject("MessageSettings", MessageSettings);
		encoder.WriteEncodeableArray("DataSetReaders", DataSetReaders.ToArray(), typeof(DataSetReaderDataType));
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		TransportSettings = decoder.ReadExtensionObject("TransportSettings");
		MessageSettings = decoder.ReadExtensionObject("MessageSettings");
		DataSetReaders = (DataSetReaderDataType[])decoder.ReadEncodeableArray("DataSetReaders", typeof(DataSetReaderDataType));
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ReaderGroupDataType readerGroupDataType))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_transportSettings, readerGroupDataType.m_transportSettings))
		{
			return false;
		}
		if (!Utils.IsEqual(m_messageSettings, readerGroupDataType.m_messageSettings))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataSetReaders, readerGroupDataType.m_dataSetReaders))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (ReaderGroupDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ReaderGroupDataType obj = (ReaderGroupDataType)base.MemberwiseClone();
		obj.m_transportSettings = (ExtensionObject)Utils.Clone(m_transportSettings);
		obj.m_messageSettings = (ExtensionObject)Utils.Clone(m_messageSettings);
		obj.m_dataSetReaders = (DataSetReaderDataTypeCollection)Utils.Clone(m_dataSetReaders);
		return obj;
	}
}
