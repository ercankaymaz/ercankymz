using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class FieldMetaData : IEncodeable, ICloneable, IJsonEncodeable
{
	private string m_name;

	private LocalizedText m_description;

	private ushort m_fieldFlags;

	private byte m_builtInType;

	private NodeId m_dataType;

	private int m_valueRank;

	private UInt32Collection m_arrayDimensions;

	private uint m_maxStringLength;

	private Uuid m_dataSetFieldId;

	private KeyValuePairCollection m_properties;

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

	[DataMember(Name = "FieldFlags", IsRequired = false, Order = 3)]
	public ushort FieldFlags
	{
		get
		{
			return m_fieldFlags;
		}
		set
		{
			m_fieldFlags = value;
		}
	}

	[DataMember(Name = "BuiltInType", IsRequired = false, Order = 4)]
	public byte BuiltInType
	{
		get
		{
			return m_builtInType;
		}
		set
		{
			m_builtInType = value;
		}
	}

	[DataMember(Name = "DataType", IsRequired = false, Order = 5)]
	public NodeId DataType
	{
		get
		{
			return m_dataType;
		}
		set
		{
			m_dataType = value;
		}
	}

	[DataMember(Name = "ValueRank", IsRequired = false, Order = 6)]
	public int ValueRank
	{
		get
		{
			return m_valueRank;
		}
		set
		{
			m_valueRank = value;
		}
	}

	[DataMember(Name = "ArrayDimensions", IsRequired = false, Order = 7)]
	public UInt32Collection ArrayDimensions
	{
		get
		{
			return m_arrayDimensions;
		}
		set
		{
			m_arrayDimensions = value;
			if (value == null)
			{
				m_arrayDimensions = new UInt32Collection();
			}
		}
	}

	[DataMember(Name = "MaxStringLength", IsRequired = false, Order = 8)]
	public uint MaxStringLength
	{
		get
		{
			return m_maxStringLength;
		}
		set
		{
			m_maxStringLength = value;
		}
	}

	[DataMember(Name = "DataSetFieldId", IsRequired = false, Order = 9)]
	public Uuid DataSetFieldId
	{
		get
		{
			return m_dataSetFieldId;
		}
		set
		{
			m_dataSetFieldId = value;
		}
	}

	[DataMember(Name = "Properties", IsRequired = false, Order = 10)]
	public KeyValuePairCollection Properties
	{
		get
		{
			return m_properties;
		}
		set
		{
			m_properties = value;
			if (value == null)
			{
				m_properties = new KeyValuePairCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.FieldMetaData;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.FieldMetaData_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.FieldMetaData_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.FieldMetaData_Encoding_DefaultJson;

	public FieldMetaData()
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
		m_fieldFlags = 0;
		m_builtInType = 0;
		m_dataType = null;
		m_valueRank = 0;
		m_arrayDimensions = new UInt32Collection();
		m_maxStringLength = 0u;
		m_dataSetFieldId = Uuid.Empty;
		m_properties = new KeyValuePairCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("Name", Name);
		encoder.WriteLocalizedText("Description", Description);
		encoder.WriteUInt16("FieldFlags", FieldFlags);
		encoder.WriteByte("BuiltInType", BuiltInType);
		encoder.WriteNodeId("DataType", DataType);
		encoder.WriteInt32("ValueRank", ValueRank);
		encoder.WriteUInt32Array("ArrayDimensions", ArrayDimensions);
		encoder.WriteUInt32("MaxStringLength", MaxStringLength);
		encoder.WriteGuid("DataSetFieldId", DataSetFieldId);
		encoder.WriteEncodeableArray("Properties", Properties.ToArray(), typeof(KeyValuePair));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Name = decoder.ReadString("Name");
		Description = decoder.ReadLocalizedText("Description");
		FieldFlags = decoder.ReadUInt16("FieldFlags");
		BuiltInType = decoder.ReadByte("BuiltInType");
		DataType = decoder.ReadNodeId("DataType");
		ValueRank = decoder.ReadInt32("ValueRank");
		ArrayDimensions = decoder.ReadUInt32Array("ArrayDimensions");
		MaxStringLength = decoder.ReadUInt32("MaxStringLength");
		DataSetFieldId = decoder.ReadGuid("DataSetFieldId");
		Properties = (KeyValuePair[])decoder.ReadEncodeableArray("Properties", typeof(KeyValuePair));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is FieldMetaData fieldMetaData))
		{
			return false;
		}
		if (!Utils.IsEqual(m_name, fieldMetaData.m_name))
		{
			return false;
		}
		if (!Utils.IsEqual(m_description, fieldMetaData.m_description))
		{
			return false;
		}
		if (!Utils.IsEqual(m_fieldFlags, fieldMetaData.m_fieldFlags))
		{
			return false;
		}
		if (!Utils.IsEqual(m_builtInType, fieldMetaData.m_builtInType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataType, fieldMetaData.m_dataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_valueRank, fieldMetaData.m_valueRank))
		{
			return false;
		}
		if (!Utils.IsEqual(m_arrayDimensions, fieldMetaData.m_arrayDimensions))
		{
			return false;
		}
		if (!Utils.IsEqual(m_maxStringLength, fieldMetaData.m_maxStringLength))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataSetFieldId, fieldMetaData.m_dataSetFieldId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_properties, fieldMetaData.m_properties))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (FieldMetaData)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		FieldMetaData obj = (FieldMetaData)base.MemberwiseClone();
		obj.m_name = (string)Utils.Clone(m_name);
		obj.m_description = (LocalizedText)Utils.Clone(m_description);
		obj.m_fieldFlags = (ushort)Utils.Clone(m_fieldFlags);
		obj.m_builtInType = (byte)Utils.Clone(m_builtInType);
		obj.m_dataType = (NodeId)Utils.Clone(m_dataType);
		obj.m_valueRank = (int)Utils.Clone(m_valueRank);
		obj.m_arrayDimensions = (UInt32Collection)Utils.Clone(m_arrayDimensions);
		obj.m_maxStringLength = (uint)Utils.Clone(m_maxStringLength);
		obj.m_dataSetFieldId = (Uuid)Utils.Clone(m_dataSetFieldId);
		obj.m_properties = (KeyValuePairCollection)Utils.Clone(m_properties);
		return obj;
	}
}
