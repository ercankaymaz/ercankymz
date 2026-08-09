using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DataTypeSchemaHeader : IEncodeable, ICloneable, IJsonEncodeable
{
	private StringCollection m_namespaces;

	private StructureDescriptionCollection m_structureDataTypes;

	private EnumDescriptionCollection m_enumDataTypes;

	private SimpleTypeDescriptionCollection m_simpleDataTypes;

	[DataMember(Name = "Namespaces", IsRequired = false, Order = 1)]
	public StringCollection Namespaces
	{
		get
		{
			return m_namespaces;
		}
		set
		{
			m_namespaces = value;
			if (value == null)
			{
				m_namespaces = new StringCollection();
			}
		}
	}

	[DataMember(Name = "StructureDataTypes", IsRequired = false, Order = 2)]
	public StructureDescriptionCollection StructureDataTypes
	{
		get
		{
			return m_structureDataTypes;
		}
		set
		{
			m_structureDataTypes = value;
			if (value == null)
			{
				m_structureDataTypes = new StructureDescriptionCollection();
			}
		}
	}

	[DataMember(Name = "EnumDataTypes", IsRequired = false, Order = 3)]
	public EnumDescriptionCollection EnumDataTypes
	{
		get
		{
			return m_enumDataTypes;
		}
		set
		{
			m_enumDataTypes = value;
			if (value == null)
			{
				m_enumDataTypes = new EnumDescriptionCollection();
			}
		}
	}

	[DataMember(Name = "SimpleDataTypes", IsRequired = false, Order = 4)]
	public SimpleTypeDescriptionCollection SimpleDataTypes
	{
		get
		{
			return m_simpleDataTypes;
		}
		set
		{
			m_simpleDataTypes = value;
			if (value == null)
			{
				m_simpleDataTypes = new SimpleTypeDescriptionCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.DataTypeSchemaHeader;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.DataTypeSchemaHeader_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.DataTypeSchemaHeader_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.DataTypeSchemaHeader_Encoding_DefaultJson;

	public DataTypeSchemaHeader()
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
		m_namespaces = new StringCollection();
		m_structureDataTypes = new StructureDescriptionCollection();
		m_enumDataTypes = new EnumDescriptionCollection();
		m_simpleDataTypes = new SimpleTypeDescriptionCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteStringArray("Namespaces", Namespaces);
		encoder.WriteEncodeableArray("StructureDataTypes", StructureDataTypes.ToArray(), typeof(StructureDescription));
		encoder.WriteEncodeableArray("EnumDataTypes", EnumDataTypes.ToArray(), typeof(EnumDescription));
		encoder.WriteEncodeableArray("SimpleDataTypes", SimpleDataTypes.ToArray(), typeof(SimpleTypeDescription));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Namespaces = decoder.ReadStringArray("Namespaces");
		StructureDataTypes = (StructureDescription[])decoder.ReadEncodeableArray("StructureDataTypes", typeof(StructureDescription));
		EnumDataTypes = (EnumDescription[])decoder.ReadEncodeableArray("EnumDataTypes", typeof(EnumDescription));
		SimpleDataTypes = (SimpleTypeDescription[])decoder.ReadEncodeableArray("SimpleDataTypes", typeof(SimpleTypeDescription));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is DataTypeSchemaHeader dataTypeSchemaHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_namespaces, dataTypeSchemaHeader.m_namespaces))
		{
			return false;
		}
		if (!Utils.IsEqual(m_structureDataTypes, dataTypeSchemaHeader.m_structureDataTypes))
		{
			return false;
		}
		if (!Utils.IsEqual(m_enumDataTypes, dataTypeSchemaHeader.m_enumDataTypes))
		{
			return false;
		}
		if (!Utils.IsEqual(m_simpleDataTypes, dataTypeSchemaHeader.m_simpleDataTypes))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (DataTypeSchemaHeader)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DataTypeSchemaHeader obj = (DataTypeSchemaHeader)base.MemberwiseClone();
		obj.m_namespaces = (StringCollection)Utils.Clone(m_namespaces);
		obj.m_structureDataTypes = (StructureDescriptionCollection)Utils.Clone(m_structureDataTypes);
		obj.m_enumDataTypes = (EnumDescriptionCollection)Utils.Clone(m_enumDataTypes);
		obj.m_simpleDataTypes = (SimpleTypeDescriptionCollection)Utils.Clone(m_simpleDataTypes);
		return obj;
	}
}
