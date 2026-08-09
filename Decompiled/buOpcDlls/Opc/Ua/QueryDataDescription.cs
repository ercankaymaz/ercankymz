using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class QueryDataDescription : IEncodeable, ICloneable, IJsonEncodeable
{
	private RelativePath m_relativePath;

	private uint m_attributeId;

	private string m_indexRange;

	[DataMember(Name = "RelativePath", IsRequired = false, Order = 1)]
	public RelativePath RelativePath
	{
		get
		{
			return m_relativePath;
		}
		set
		{
			m_relativePath = value;
			if (value == null)
			{
				m_relativePath = new RelativePath();
			}
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

	public virtual ExpandedNodeId TypeId => DataTypeIds.QueryDataDescription;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.QueryDataDescription_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.QueryDataDescription_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.QueryDataDescription_Encoding_DefaultJson;

	public NumericRange ParsedIndexRange { get; set; }

	public QueryDataDescription()
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
		m_relativePath = new RelativePath();
		m_attributeId = 0u;
		m_indexRange = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RelativePath", RelativePath, typeof(RelativePath));
		encoder.WriteUInt32("AttributeId", AttributeId);
		encoder.WriteString("IndexRange", IndexRange);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RelativePath = (RelativePath)decoder.ReadEncodeable("RelativePath", typeof(RelativePath));
		AttributeId = decoder.ReadUInt32("AttributeId");
		IndexRange = decoder.ReadString("IndexRange");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is QueryDataDescription queryDataDescription))
		{
			return false;
		}
		if (!Utils.IsEqual(m_relativePath, queryDataDescription.m_relativePath))
		{
			return false;
		}
		if (!Utils.IsEqual(m_attributeId, queryDataDescription.m_attributeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_indexRange, queryDataDescription.m_indexRange))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (QueryDataDescription)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		QueryDataDescription obj = (QueryDataDescription)base.MemberwiseClone();
		obj.m_relativePath = (RelativePath)Utils.Clone(m_relativePath);
		obj.m_attributeId = (uint)Utils.Clone(m_attributeId);
		obj.m_indexRange = (string)Utils.Clone(m_indexRange);
		return obj;
	}
}
