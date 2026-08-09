using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class Argument : IEncodeable, ICloneable, IJsonEncodeable
{
	private string m_name;

	private NodeId m_dataType;

	private int m_valueRank;

	private UInt32Collection m_arrayDimensions;

	private LocalizedText m_description;

	private object m_value;

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

	[DataMember(Name = "DataType", IsRequired = false, Order = 2)]
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

	[DataMember(Name = "ValueRank", IsRequired = false, Order = 3)]
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

	[DataMember(Name = "ArrayDimensions", IsRequired = false, Order = 4)]
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

	[DataMember(Name = "Description", IsRequired = false, Order = 5)]
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.Argument;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.Argument_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.Argument_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.Argument_Encoding_DefaultJson;

	public object Value
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

	public Argument()
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
		m_dataType = null;
		m_valueRank = 0;
		m_arrayDimensions = new UInt32Collection();
		m_description = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteString("Name", Name);
		encoder.WriteNodeId("DataType", DataType);
		encoder.WriteInt32("ValueRank", ValueRank);
		encoder.WriteUInt32Array("ArrayDimensions", ArrayDimensions);
		encoder.WriteLocalizedText("Description", Description);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Name = decoder.ReadString("Name");
		DataType = decoder.ReadNodeId("DataType");
		ValueRank = decoder.ReadInt32("ValueRank");
		ArrayDimensions = decoder.ReadUInt32Array("ArrayDimensions");
		Description = decoder.ReadLocalizedText("Description");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is Argument argument))
		{
			return false;
		}
		if (!Utils.IsEqual(m_name, argument.m_name))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataType, argument.m_dataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_valueRank, argument.m_valueRank))
		{
			return false;
		}
		if (!Utils.IsEqual(m_arrayDimensions, argument.m_arrayDimensions))
		{
			return false;
		}
		if (!Utils.IsEqual(m_description, argument.m_description))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (Argument)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		Argument obj = (Argument)base.MemberwiseClone();
		obj.m_name = (string)Utils.Clone(m_name);
		obj.m_dataType = (NodeId)Utils.Clone(m_dataType);
		obj.m_valueRank = (int)Utils.Clone(m_valueRank);
		obj.m_arrayDimensions = (UInt32Collection)Utils.Clone(m_arrayDimensions);
		obj.m_description = (LocalizedText)Utils.Clone(m_description);
		return obj;
	}

	public Argument(string name, NodeId dataType, int valueRank, string description)
	{
		m_name = name;
		m_dataType = dataType;
		m_valueRank = valueRank;
		m_description = description;
	}
}
