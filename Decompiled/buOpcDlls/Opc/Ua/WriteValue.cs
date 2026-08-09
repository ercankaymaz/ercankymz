using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class WriteValue : IEncodeable, ICloneable, IJsonEncodeable
{
	private NodeId m_nodeId;

	private uint m_attributeId;

	private string m_indexRange;

	private DataValue m_value;

	private object m_handle;

	private bool m_processed;

	private NumericRange m_parsedIndexRange = NumericRange.Empty;

	[DataMember(Name = "NodeId", IsRequired = false, Order = 1)]
	public NodeId NodeId
	{
		get
		{
			return m_nodeId;
		}
		set
		{
			m_nodeId = value;
		}
	}

	[DataMember(Name = "AttributeId", IsRequired = false, Order = 2)]
	public uint AttributeId
	{
		get
		{
			return m_attributeId;
		}
		set
		{
			m_attributeId = value;
		}
	}

	[DataMember(Name = "IndexRange", IsRequired = false, Order = 3)]
	public string IndexRange
	{
		get
		{
			return m_indexRange;
		}
		set
		{
			m_indexRange = value;
		}
	}

	[DataMember(Name = "Value", IsRequired = false, Order = 4)]
	public DataValue Value
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.WriteValue;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.WriteValue_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.WriteValue_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.WriteValue_Encoding_DefaultJson;

	public object Handle
	{
		get
		{
			return m_handle;
		}
		set
		{
			m_handle = value;
		}
	}

	public bool Processed
	{
		get
		{
			return m_processed;
		}
		set
		{
			m_processed = value;
		}
	}

	public NumericRange ParsedIndexRange
	{
		get
		{
			return m_parsedIndexRange;
		}
		set
		{
			m_parsedIndexRange = value;
		}
	}

	public WriteValue()
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
		m_nodeId = null;
		m_attributeId = 0u;
		m_indexRange = null;
		m_value = new DataValue();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("NodeId", NodeId);
		encoder.WriteUInt32("AttributeId", AttributeId);
		encoder.WriteString("IndexRange", IndexRange);
		encoder.WriteDataValue("Value", Value);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		NodeId = decoder.ReadNodeId("NodeId");
		AttributeId = decoder.ReadUInt32("AttributeId");
		IndexRange = decoder.ReadString("IndexRange");
		Value = decoder.ReadDataValue("Value");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is WriteValue writeValue))
		{
			return false;
		}
		if (!Utils.IsEqual(m_nodeId, writeValue.m_nodeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_attributeId, writeValue.m_attributeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_indexRange, writeValue.m_indexRange))
		{
			return false;
		}
		if (!Utils.IsEqual(m_value, writeValue.m_value))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (WriteValue)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		WriteValue obj = (WriteValue)base.MemberwiseClone();
		obj.m_nodeId = (NodeId)Utils.Clone(m_nodeId);
		obj.m_attributeId = (uint)Utils.Clone(m_attributeId);
		obj.m_indexRange = (string)Utils.Clone(m_indexRange);
		obj.m_value = (DataValue)Utils.Clone(m_value);
		return obj;
	}

	public static ServiceResult Validate(WriteValue value)
	{
		if (value == null)
		{
			return 2152071168u;
		}
		if (value.NodeId == null)
		{
			return 2150825984u;
		}
		if (!Attributes.IsValid(value.AttributeId))
		{
			return 2150957056u;
		}
		value.ParsedIndexRange = NumericRange.Empty;
		if (!string.IsNullOrEmpty(value.IndexRange))
		{
			try
			{
				value.ParsedIndexRange = NumericRange.Parse(value.IndexRange);
			}
			catch (Exception e)
			{
				return ServiceResult.Create(e, 2151022592u, string.Empty);
			}
			if (value.ParsedIndexRange.SubRanges != null)
			{
				if (!(value.Value.Value is Matrix) && (!(value.Value.Value is Array) || value.Value.WrappedValue.TypeInfo.BuiltInType != BuiltInType.String) && value.Value.WrappedValue.TypeInfo.BuiltInType != BuiltInType.ByteString)
				{
					return 2155085824u;
				}
			}
			else if (value.Value.Value is Array array)
			{
				NumericRange parsedIndexRange = value.ParsedIndexRange;
				if (parsedIndexRange.End >= 0 && parsedIndexRange.End - parsedIndexRange.Begin != array.Length - 1)
				{
					return 2151088128u;
				}
				if (parsedIndexRange.End < 0 && array.Length != 1)
				{
					return 2151022592u;
				}
			}
			else
			{
				if (!(value.Value.Value is string text))
				{
					return 2155085824u;
				}
				NumericRange parsedIndexRange2 = value.ParsedIndexRange;
				if (parsedIndexRange2.End >= 0 && parsedIndexRange2.End - parsedIndexRange2.Begin != text.Length - 1)
				{
					return 2151088128u;
				}
				if (parsedIndexRange2.End < 0 && text.Length != 1)
				{
					return 2151022592u;
				}
			}
		}
		else
		{
			value.ParsedIndexRange = NumericRange.Empty;
		}
		return null;
	}
}
