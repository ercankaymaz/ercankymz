using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DataSetMetaDataType : DataTypeSchemaHeader
{
	private string m_name;

	private LocalizedText m_description;

	private FieldMetaDataCollection m_fields;

	private Uuid m_dataSetClassId;

	private ConfigurationVersionDataType m_configurationVersion;

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

	[DataMember(Name = "Description", IsRequired = false, Order = 2)]
	public LocalizedText Description
	{
		get
		{
			return m_description;
		}
		set
		{
			m_description = value;
		}
	}

	[DataMember(Name = "Fields", IsRequired = false, Order = 3)]
	public FieldMetaDataCollection Fields
	{
		get
		{
			return m_fields;
		}
		set
		{
			m_fields = value;
			if (value == null)
			{
				m_fields = new FieldMetaDataCollection();
			}
		}
	}

	[DataMember(Name = "DataSetClassId", IsRequired = false, Order = 4)]
	public Uuid DataSetClassId
	{
		get
		{
			return m_dataSetClassId;
		}
		set
		{
			m_dataSetClassId = value;
		}
	}

	[DataMember(Name = "ConfigurationVersion", IsRequired = false, Order = 5)]
	public ConfigurationVersionDataType ConfigurationVersion
	{
		get
		{
			return m_configurationVersion;
		}
		set
		{
			m_configurationVersion = value;
			if (value == null)
			{
				m_configurationVersion = new ConfigurationVersionDataType();
			}
		}
	}

	public override ExpandedNodeId TypeId => DataTypeIds.DataSetMetaDataType;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.DataSetMetaDataType_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.DataSetMetaDataType_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.DataSetMetaDataType_Encoding_DefaultJson;

	public DataSetMetaDataType()
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
		m_description = null;
		m_fields = new FieldMetaDataCollection();
		m_dataSetClassId = Uuid.Empty;
		m_configurationVersion = new ConfigurationVersionDataType();
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("Name", Name);
		encoder.WriteLocalizedText("Description", Description);
		encoder.WriteEncodeableArray("Fields", Fields.ToArray(), typeof(FieldMetaData));
		encoder.WriteGuid("DataSetClassId", DataSetClassId);
		encoder.WriteEncodeable("ConfigurationVersion", ConfigurationVersion, typeof(ConfigurationVersionDataType));
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Name = decoder.ReadString("Name");
		Description = decoder.ReadLocalizedText("Description");
		Fields = (FieldMetaData[])decoder.ReadEncodeableArray("Fields", typeof(FieldMetaData));
		DataSetClassId = decoder.ReadGuid("DataSetClassId");
		ConfigurationVersion = (ConfigurationVersionDataType)decoder.ReadEncodeable("ConfigurationVersion", typeof(ConfigurationVersionDataType));
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is DataSetMetaDataType dataSetMetaDataType))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_name, dataSetMetaDataType.m_name))
		{
			return false;
		}
		if (!Utils.IsEqual(m_description, dataSetMetaDataType.m_description))
		{
			return false;
		}
		if (!Utils.IsEqual(m_fields, dataSetMetaDataType.m_fields))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataSetClassId, dataSetMetaDataType.m_dataSetClassId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_configurationVersion, dataSetMetaDataType.m_configurationVersion))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (DataSetMetaDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DataSetMetaDataType obj = (DataSetMetaDataType)base.MemberwiseClone();
		obj.m_name = (string)Utils.Clone(m_name);
		obj.m_description = (LocalizedText)Utils.Clone(m_description);
		obj.m_fields = (FieldMetaDataCollection)Utils.Clone(m_fields);
		obj.m_dataSetClassId = (Uuid)Utils.Clone(m_dataSetClassId);
		obj.m_configurationVersion = (ConfigurationVersionDataType)Utils.Clone(m_configurationVersion);
		return obj;
	}
}
