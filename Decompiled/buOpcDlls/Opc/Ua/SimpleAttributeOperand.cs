using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class SimpleAttributeOperand : FilterOperand, IFormattable
{
	private NodeId m_typeDefinitionId;

	private QualifiedNameCollection m_browsePath;

	private uint m_attributeId;

	private string m_indexRange;

	private bool m_validated;

	private NumericRange m_parsedIndexRange;

	[DataMember(Name = "TypeDefinitionId", IsRequired = false, Order = 1)]
	public NodeId TypeDefinitionId
	{
		get
		{
			return m_typeDefinitionId;
		}
		set
		{
			m_typeDefinitionId = value;
		}
	}

	[DataMember(Name = "BrowsePath", IsRequired = false, Order = 2)]
	public QualifiedNameCollection BrowsePath
	{
		get
		{
			return m_browsePath;
		}
		set
		{
			m_browsePath = value;
			if (value == null)
			{
				m_browsePath = new QualifiedNameCollection();
			}
		}
	}

	[DataMember(Name = "AttributeId", IsRequired = false, Order = 3)]
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

	[DataMember(Name = "IndexRange", IsRequired = false, Order = 4)]
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

	public override ExpandedNodeId TypeId => DataTypeIds.SimpleAttributeOperand;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.SimpleAttributeOperand_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.SimpleAttributeOperand_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.SimpleAttributeOperand_Encoding_DefaultJson;

	public bool Validated => m_validated;

	public NumericRange ParsedIndexRange => m_parsedIndexRange;

	public SimpleAttributeOperand()
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
		m_typeDefinitionId = null;
		m_browsePath = new QualifiedNameCollection();
		m_attributeId = 0u;
		m_indexRange = null;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("TypeDefinitionId", TypeDefinitionId);
		encoder.WriteQualifiedNameArray("BrowsePath", BrowsePath);
		encoder.WriteUInt32("AttributeId", AttributeId);
		encoder.WriteString("IndexRange", IndexRange);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		TypeDefinitionId = decoder.ReadNodeId("TypeDefinitionId");
		BrowsePath = decoder.ReadQualifiedNameArray("BrowsePath");
		AttributeId = decoder.ReadUInt32("AttributeId");
		IndexRange = decoder.ReadString("IndexRange");
		decoder.PopNamespace();
	}

	public override bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is SimpleAttributeOperand simpleAttributeOperand))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_typeDefinitionId, simpleAttributeOperand.m_typeDefinitionId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_browsePath, simpleAttributeOperand.m_browsePath))
		{
			return false;
		}
		if (!Utils.IsEqual(m_attributeId, simpleAttributeOperand.m_attributeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_indexRange, simpleAttributeOperand.m_indexRange))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (SimpleAttributeOperand)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SimpleAttributeOperand obj = (SimpleAttributeOperand)base.MemberwiseClone();
		obj.m_typeDefinitionId = (NodeId)Utils.Clone(m_typeDefinitionId);
		obj.m_browsePath = (QualifiedNameCollection)Utils.Clone(m_browsePath);
		obj.m_attributeId = (uint)Utils.Clone(m_attributeId);
		obj.m_indexRange = (string)Utils.Clone(m_indexRange);
		return obj;
	}

	public SimpleAttributeOperand(NodeId typeId, QualifiedName browsePath)
	{
		m_typeDefinitionId = typeId;
		m_browsePath = new QualifiedNameCollection();
		m_attributeId = 13u;
		m_indexRange = null;
		m_browsePath.Add(browsePath);
	}

	public SimpleAttributeOperand(NodeId typeId, IList<QualifiedName> browsePath)
	{
		m_typeDefinitionId = typeId;
		m_browsePath = new QualifiedNameCollection(browsePath);
		m_attributeId = 13u;
		m_indexRange = null;
	}

	public SimpleAttributeOperand(FilterContext context, ExpandedNodeId typeId, IList<QualifiedName> browsePath)
	{
		m_typeDefinitionId = ExpandedNodeId.ToNodeId(typeId, context.NamespaceUris);
		m_browsePath = new QualifiedNameCollection(browsePath);
		m_attributeId = 13u;
		m_indexRange = null;
	}

	public SimpleAttributeOperand(FilterContext context, ExpandedNodeId typeDefinitionId, string browsePath, uint attributeId, string indexRange)
	{
		m_typeDefinitionId = ExpandedNodeId.ToNodeId(typeDefinitionId, context.NamespaceUris);
		m_browsePath = Parse(browsePath);
		m_attributeId = attributeId;
		m_indexRange = indexRange;
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < m_browsePath.Count; i++)
			{
				stringBuilder.AppendFormat(formatProvider, "/{0}", m_browsePath[i]);
			}
			return stringBuilder.ToString();
		}
		throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
	}

	public override string ToString()
	{
		return ToString(null, null);
	}

	public override ServiceResult Validate(FilterContext context, int index)
	{
		m_validated = false;
		if (!Attributes.IsValid(m_attributeId))
		{
			return ServiceResult.Create(2150957056u, "SimpleAttributeOperand does not specify a valid AttributeId ({0}).", m_attributeId);
		}
		m_parsedIndexRange = NumericRange.Empty;
		if (!string.IsNullOrEmpty(m_indexRange))
		{
			try
			{
				m_parsedIndexRange = NumericRange.Parse(m_indexRange);
			}
			catch (Exception e)
			{
				return ServiceResult.Create(e, 2151022592u, "SimpleAttributeOperand does not specify a valid BrowsePath ({0}).", m_indexRange);
			}
			if (m_attributeId != 13)
			{
				return ServiceResult.Create(2151022592u, "SimpleAttributeOperand specifies an IndexRange for an Attribute other than Value ({0}).", m_attributeId);
			}
		}
		m_validated = true;
		return ServiceResult.Good;
	}

	public override string ToString(INodeTable nodeTable)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (nodeTable.Find(TypeDefinitionId) != null)
		{
			stringBuilder.AppendFormat("{0}", TypeDefinitionId);
		}
		else
		{
			stringBuilder.AppendFormat("{0}", TypeDefinitionId);
		}
		if (BrowsePath != null && BrowsePath.Count > 0)
		{
			stringBuilder.AppendFormat("{0}", Format(BrowsePath));
		}
		if (!string.IsNullOrEmpty(IndexRange))
		{
			stringBuilder.AppendFormat("[{0}]", NumericRange.Parse(IndexRange));
		}
		return stringBuilder.ToString();
	}

	public static string Format(IList<QualifiedName> browsePath)
	{
		if (browsePath == null || browsePath.Count == 0)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < browsePath.Count; i++)
		{
			QualifiedName qualifiedName = browsePath[i];
			if (QualifiedName.IsNull(qualifiedName))
			{
				throw ServiceResultException.Create(2153775104u, "BrowseName cannot be null");
			}
			stringBuilder.Append('/');
			if (qualifiedName.NamespaceIndex != 0)
			{
				stringBuilder.AppendFormat("{0}:", qualifiedName.NamespaceIndex);
			}
			for (int j = 0; j < qualifiedName.Name.Length; j++)
			{
				char c = qualifiedName.Name[j];
				if (c == '&' || c == '/')
				{
					stringBuilder.Append('&');
				}
				stringBuilder.Append(c);
			}
		}
		return stringBuilder.ToString();
	}

	public static QualifiedNameCollection Parse(string browsePath)
	{
		QualifiedNameCollection qualifiedNameCollection = new QualifiedNameCollection();
		if (string.IsNullOrEmpty(browsePath))
		{
			return qualifiedNameCollection;
		}
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = false;
		foreach (char c in browsePath)
		{
			if (flag)
			{
				stringBuilder.Append(c);
				flag = false;
				continue;
			}
			switch (c)
			{
			case '&':
				flag = true;
				break;
			case '/':
				if (stringBuilder.Length > 0)
				{
					QualifiedName item = QualifiedName.Parse(stringBuilder.ToString());
					qualifiedNameCollection.Add(item);
				}
				stringBuilder.Length = 0;
				break;
			default:
				stringBuilder.Append(c);
				break;
			}
		}
		if (stringBuilder.Length > 0)
		{
			QualifiedName item2 = QualifiedName.Parse(stringBuilder.ToString());
			qualifiedNameCollection.Add(item2);
		}
		return qualifiedNameCollection;
	}
}
