using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DataSetWriterDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private string m_name;

	private bool m_enabled;

	private ushort m_dataSetWriterId;

	private uint m_dataSetFieldContentMask;

	private uint m_keyFrameCount;

	private string m_dataSetName;

	private KeyValuePairCollection m_dataSetWriterProperties;

	private ExtensionObject m_transportSettings;

	private ExtensionObject m_messageSettings;

	[DataMember(Name = "Name", IsRequired = false, Order = 1)]
	public string Name
	{
		get
		{
			return m_name;
		}
		set
		{
			m_name = value;
		}
	}

	[DataMember(Name = "Enabled", IsRequired = false, Order = 2)]
	public bool Enabled
	{
		get
		{
			return m_enabled;
		}
		set
		{
			m_enabled = value;
		}
	}

	[DataMember(Name = "DataSetWriterId", IsRequired = false, Order = 3)]
	public ushort DataSetWriterId
	{
		get
		{
			return m_dataSetWriterId;
		}
		set
		{
			m_dataSetWriterId = value;
		}
	}

	[DataMember(Name = "DataSetFieldContentMask", IsRequired = false, Order = 4)]
	public uint DataSetFieldContentMask
	{
		get
		{
			return m_dataSetFieldContentMask;
		}
		set
		{
			m_dataSetFieldContentMask = value;
		}
	}

	[DataMember(Name = "KeyFrameCount", IsRequired = false, Order = 5)]
	public uint KeyFrameCount
	{
		get
		{
			return m_keyFrameCount;
		}
		set
		{
			m_keyFrameCount = value;
		}
	}

	[DataMember(Name = "DataSetName", IsRequired = false, Order = 6)]
	public string DataSetName
	{
		get
		{
			return m_dataSetName;
		}
		set
		{
			m_dataSetName = value;
		}
	}

	[DataMember(Name = "DataSetWriterProperties", IsRequired = false, Order = 7)]
	public KeyValuePairCollection DataSetWriterProperties
	{
		get
		{
			return m_dataSetWriterProperties;
		}
		set
		{
			m_dataSetWriterProperties = value;
			if (value == null)
			{
				m_dataSetWriterProperties = new KeyValuePairCollection();
			}
		}
	}

	[DataMember(Name = "TransportSettings", IsRequired = false, Order = 8)]
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

	[DataMember(Name = "MessageSettings", IsRequired = false, Order = 9)]
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.DataSetWriterDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.DataSetWriterDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.DataSetWriterDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.DataSetWriterDataType_Encoding_DefaultJson;

	public DataSetWriterDataType()
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
		m_name = null;
		m_enabled = true;
		m_dataSetWriterId = 0;
		m_dataSetFieldContentMask = 0u;
		m_keyFrameCount = 0u;
		m_dataSetName = null;
		m_dataSetWriterProperties = new KeyValuePairCollection();
		m_transportSettings = null;
		m_messageSettings = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("Name", Name);
		encoder.WriteBoolean("Enabled", Enabled);
		encoder.WriteUInt16("DataSetWriterId", DataSetWriterId);
		encoder.WriteUInt32("DataSetFieldContentMask", DataSetFieldContentMask);
		encoder.WriteUInt32("KeyFrameCount", KeyFrameCount);
		encoder.WriteString("DataSetName", DataSetName);
		encoder.WriteEncodeableArray("DataSetWriterProperties", DataSetWriterProperties.ToArray(), typeof(KeyValuePair));
		encoder.WriteExtensionObject("TransportSettings", TransportSettings);
		encoder.WriteExtensionObject("MessageSettings", MessageSettings);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Name = decoder.ReadString("Name");
		Enabled = decoder.ReadBoolean("Enabled");
		DataSetWriterId = decoder.ReadUInt16("DataSetWriterId");
		DataSetFieldContentMask = decoder.ReadUInt32("DataSetFieldContentMask");
		KeyFrameCount = decoder.ReadUInt32("KeyFrameCount");
		DataSetName = decoder.ReadString("DataSetName");
		DataSetWriterProperties = (KeyValuePair[])decoder.ReadEncodeableArray("DataSetWriterProperties", typeof(KeyValuePair));
		TransportSettings = decoder.ReadExtensionObject("TransportSettings");
		MessageSettings = decoder.ReadExtensionObject("MessageSettings");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is DataSetWriterDataType dataSetWriterDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_name, dataSetWriterDataType.m_name))
		{
			return false;
		}
		if (!Utils.IsEqual(m_enabled, dataSetWriterDataType.m_enabled))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataSetWriterId, dataSetWriterDataType.m_dataSetWriterId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataSetFieldContentMask, dataSetWriterDataType.m_dataSetFieldContentMask))
		{
			return false;
		}
		if (!Utils.IsEqual(m_keyFrameCount, dataSetWriterDataType.m_keyFrameCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataSetName, dataSetWriterDataType.m_dataSetName))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataSetWriterProperties, dataSetWriterDataType.m_dataSetWriterProperties))
		{
			return false;
		}
		if (!Utils.IsEqual(m_transportSettings, dataSetWriterDataType.m_transportSettings))
		{
			return false;
		}
		if (!Utils.IsEqual(m_messageSettings, dataSetWriterDataType.m_messageSettings))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (DataSetWriterDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DataSetWriterDataType obj = (DataSetWriterDataType)base.MemberwiseClone();
		obj.m_name = (string)Utils.Clone(m_name);
		obj.m_enabled = (bool)Utils.Clone(m_enabled);
		obj.m_dataSetWriterId = (ushort)Utils.Clone(m_dataSetWriterId);
		obj.m_dataSetFieldContentMask = (uint)Utils.Clone(m_dataSetFieldContentMask);
		obj.m_keyFrameCount = (uint)Utils.Clone(m_keyFrameCount);
		obj.m_dataSetName = (string)Utils.Clone(m_dataSetName);
		obj.m_dataSetWriterProperties = (KeyValuePairCollection)Utils.Clone(m_dataSetWriterProperties);
		obj.m_transportSettings = (ExtensionObject)Utils.Clone(m_transportSettings);
		obj.m_messageSettings = (ExtensionObject)Utils.Clone(m_messageSettings);
		return obj;
	}
}
