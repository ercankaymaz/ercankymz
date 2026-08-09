using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ReadValueId : IEncodeable, ICloneable, IJsonEncodeable
{
	private NodeId m_nodeId;

	private uint m_attributeId;

	private string m_indexRange;

	private QualifiedName m_dataEncoding;

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

	[DataMember(Name = "DataEncoding", IsRequired = false, Order = 4)]
	public QualifiedName DataEncoding
	{
		get
		{
			return m_dataEncoding;
		}
		set
		{
			m_dataEncoding = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.ReadValueId;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ReadValueId_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ReadValueId_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ReadValueId_Encoding_DefaultJson;

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

	public ReadValueId()
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
		m_dataEncoding = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("NodeId", NodeId);
		encoder.WriteUInt32("AttributeId", AttributeId);
		encoder.WriteString("IndexRange", IndexRange);
		encoder.WriteQualifiedName("DataEncoding", DataEncoding);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		NodeId = decoder.ReadNodeId("NodeId");
		AttributeId = decoder.ReadUInt32("AttributeId");
		IndexRange = decoder.ReadString("IndexRange");
		DataEncoding = decoder.ReadQualifiedName("DataEncoding");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ReadValueId readValueId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_nodeId, readValueId.m_nodeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_attributeId, readValueId.m_attributeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_indexRange, readValueId.m_indexRange))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataEncoding, readValueId.m_dataEncoding))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ReadValueId)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ReadValueId obj = (ReadValueId)base.MemberwiseClone();
		obj.m_nodeId = (NodeId)Utils.Clone(m_nodeId);
		obj.m_attributeId = (uint)Utils.Clone(m_attributeId);
		obj.m_indexRange = (string)Utils.Clone(m_indexRange);
		obj.m_dataEncoding = (QualifiedName)Utils.Clone(m_dataEncoding);
		return obj;
	}

	public static ServiceResult Validate(ReadValueId valueId)
	{
		if (valueId == null)
		{
			return 2152071168u;
		}
		if (valueId.NodeId == null)
		{
			return 2150825984u;
		}
		if (!Attributes.IsValid(valueId.AttributeId))
		{
			return 2150957056u;
		}
		if (valueId.AttributeId != 13)
		{
			if (!string.IsNullOrEmpty(valueId.IndexRange))
			{
				return 2151088128u;
			}
			if (!QualifiedName.IsNull(valueId.DataEncoding))
			{
				return 2151153664u;
			}
		}
		valueId.ParsedIndexRange = NumericRange.Empty;
		if (!string.IsNullOrEmpty(valueId.IndexRange))
		{
			try
			{
				valueId.ParsedIndexRange = NumericRange.Parse(valueId.IndexRange);
			}
			catch (Exception e)
			{
				return ServiceResult.Create(e, 2151022592u, string.Empty);
			}
		}
		else
		{
			valueId.ParsedIndexRange = NumericRange.Empty;
		}
		return null;
	}
}
