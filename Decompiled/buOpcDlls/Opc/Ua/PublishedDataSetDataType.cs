using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class PublishedDataSetDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private string m_name;

	private StringCollection m_dataSetFolder;

	private DataSetMetaDataType m_dataSetMetaData;

	private KeyValuePairCollection m_extensionFields;

	private ExtensionObject m_dataSetSource;

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

	[DataMember(Name = "DataSetFolder", IsRequired = false, Order = 2)]
	public StringCollection DataSetFolder
	{
		get
		{
			return m_dataSetFolder;
		}
		set
		{
			m_dataSetFolder = value;
			if (value == null)
			{
				m_dataSetFolder = new StringCollection();
			}
		}
	}

	[DataMember(Name = "DataSetMetaData", IsRequired = false, Order = 3)]
	public DataSetMetaDataType DataSetMetaData
	{
		get
		{
			return m_dataSetMetaData;
		}
		set
		{
			m_dataSetMetaData = value;
			if (value == null)
			{
				m_dataSetMetaData = new DataSetMetaDataType();
			}
		}
	}

	[DataMember(Name = "ExtensionFields", IsRequired = false, Order = 4)]
	public KeyValuePairCollection ExtensionFields
	{
		get
		{
			return m_extensionFields;
		}
		set
		{
			m_extensionFields = value;
			if (value == null)
			{
				m_extensionFields = new KeyValuePairCollection();
			}
		}
	}

	[DataMember(Name = "DataSetSource", IsRequired = false, Order = 5)]
	public ExtensionObject DataSetSource
	{
		get
		{
			return m_dataSetSource;
		}
		set
		{
			m_dataSetSource = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.PublishedDataSetDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.PublishedDataSetDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.PublishedDataSetDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.PublishedDataSetDataType_Encoding_DefaultJson;

	public PublishedDataSetDataType()
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
		m_dataSetFolder = new StringCollection();
		m_dataSetMetaData = new DataSetMetaDataType();
		m_extensionFields = new KeyValuePairCollection();
		m_dataSetSource = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("Name", Name);
		encoder.WriteStringArray("DataSetFolder", DataSetFolder);
		encoder.WriteEncodeable("DataSetMetaData", DataSetMetaData, typeof(DataSetMetaDataType));
		encoder.WriteEncodeableArray("ExtensionFields", ExtensionFields.ToArray(), typeof(KeyValuePair));
		encoder.WriteExtensionObject("DataSetSource", DataSetSource);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Name = decoder.ReadString("Name");
		DataSetFolder = decoder.ReadStringArray("DataSetFolder");
		DataSetMetaData = (DataSetMetaDataType)decoder.ReadEncodeable("DataSetMetaData", typeof(DataSetMetaDataType));
		ExtensionFields = (KeyValuePair[])decoder.ReadEncodeableArray("ExtensionFields", typeof(KeyValuePair));
		DataSetSource = decoder.ReadExtensionObject("DataSetSource");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is PublishedDataSetDataType publishedDataSetDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_name, publishedDataSetDataType.m_name))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataSetFolder, publishedDataSetDataType.m_dataSetFolder))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataSetMetaData, publishedDataSetDataType.m_dataSetMetaData))
		{
			return false;
		}
		if (!Utils.IsEqual(m_extensionFields, publishedDataSetDataType.m_extensionFields))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataSetSource, publishedDataSetDataType.m_dataSetSource))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (PublishedDataSetDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		PublishedDataSetDataType obj = (PublishedDataSetDataType)base.MemberwiseClone();
		obj.m_name = (string)Utils.Clone(m_name);
		obj.m_dataSetFolder = (StringCollection)Utils.Clone(m_dataSetFolder);
		obj.m_dataSetMetaData = (DataSetMetaDataType)Utils.Clone(m_dataSetMetaData);
		obj.m_extensionFields = (KeyValuePairCollection)Utils.Clone(m_extensionFields);
		obj.m_dataSetSource = (ExtensionObject)Utils.Clone(m_dataSetSource);
		return obj;
	}
}
