using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class StructureField : IEncodeable, ICloneable, IJsonEncodeable
{
	private string m_name;

	private LocalizedText m_description;

	private NodeId m_dataType;

	private int m_valueRank;

	private UInt32Collection m_arrayDimensions;

	private uint m_maxStringLength;

	private bool m_isOptional;

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

	[DataMember(Name = "DataType", IsRequired = false, Order = 3)]
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

	[DataMember(Name = "ValueRank", IsRequired = false, Order = 4)]
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

	[DataMember(Name = "ArrayDimensions", IsRequired = false, Order = 5)]
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

	[DataMember(Name = "MaxStringLength", IsRequired = false, Order = 6)]
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

	[DataMember(Name = "IsOptional", IsRequired = false, Order = 7)]
	public bool IsOptional
	{
		get
		{
			return m_isOptional;
		}
		set
		{
			m_isOptional = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.StructureField;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.StructureField_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.StructureField_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.StructureField_Encoding_DefaultJson;

	public StructureField()
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
		m_dataType = null;
		m_valueRank = 0;
		m_arrayDimensions = new UInt32Collection();
		m_maxStringLength = 0u;
		m_isOptional = false;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("Name", Name);
		encoder.WriteLocalizedText("Description", Description);
		encoder.WriteNodeId("DataType", DataType);
		encoder.WriteInt32("ValueRank", ValueRank);
		encoder.WriteUInt32Array("ArrayDimensions", ArrayDimensions);
		encoder.WriteUInt32("MaxStringLength", MaxStringLength);
		encoder.WriteBoolean("IsOptional", IsOptional);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Name = decoder.ReadString("Name");
		Description = decoder.ReadLocalizedText("Description");
		DataType = decoder.ReadNodeId("DataType");
		ValueRank = decoder.ReadInt32("ValueRank");
		ArrayDimensions = decoder.ReadUInt32Array("ArrayDimensions");
		MaxStringLength = decoder.ReadUInt32("MaxStringLength");
		IsOptional = decoder.ReadBoolean("IsOptional");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is StructureField structureField))
		{
			return false;
		}
		if (!Utils.IsEqual(m_name, structureField.m_name))
		{
			return false;
		}
		if (!Utils.IsEqual(m_description, structureField.m_description))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataType, structureField.m_dataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_valueRank, structureField.m_valueRank))
		{
			return false;
		}
		if (!Utils.IsEqual(m_arrayDimensions, structureField.m_arrayDimensions))
		{
			return false;
		}
		if (!Utils.IsEqual(m_maxStringLength, structureField.m_maxStringLength))
		{
			return false;
		}
		if (!Utils.IsEqual(m_isOptional, structureField.m_isOptional))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (StructureField)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		StructureField obj = (StructureField)base.MemberwiseClone();
		obj.m_name = (string)Utils.Clone(m_name);
		obj.m_description = (LocalizedText)Utils.Clone(m_description);
		obj.m_dataType = (NodeId)Utils.Clone(m_dataType);
		obj.m_valueRank = (int)Utils.Clone(m_valueRank);
		obj.m_arrayDimensions = (UInt32Collection)Utils.Clone(m_arrayDimensions);
		obj.m_maxStringLength = (uint)Utils.Clone(m_maxStringLength);
		obj.m_isOptional = (bool)Utils.Clone(m_isOptional);
		return obj;
	}
}
