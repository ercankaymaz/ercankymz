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
public class AttributeOperand : FilterOperand, IFormattable
{
	private NodeId m_nodeId;

	private string m_alias;

	private RelativePath m_browsePath;

	private uint m_attributeId;

	private string m_indexRange;

	private bool m_validated;

	private NumericRange m_parsedIndexRange;

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

	[DataMember(Name = "Alias", IsRequired = false, Order = 2)]
	public string Alias
	{
		get
		{
			return m_alias;
		}
		set
		{
			m_alias = value;
		}
	}

	[DataMember(Name = "BrowsePath", IsRequired = false, Order = 3)]
	public RelativePath BrowsePath
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
				m_browsePath = new RelativePath();
			}
		}
	}

	[DataMember(Name = "AttributeId", IsRequired = false, Order = 4)]
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

	[DataMember(Name = "IndexRange", IsRequired = false, Order = 5)]
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

	public override ExpandedNodeId TypeId => DataTypeIds.AttributeOperand;

	public override ExpandedNodeId BinaryEncodingId => ObjectIds.AttributeOperand_Encoding_DefaultBinary;

	public override ExpandedNodeId XmlEncodingId => ObjectIds.AttributeOperand_Encoding_DefaultXml;

	public override ExpandedNodeId JsonEncodingId => ObjectIds.AttributeOperand_Encoding_DefaultJson;

	public bool Validated => m_validated;

	public NumericRange ParsedIndexRange => m_parsedIndexRange;

	public AttributeOperand()
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
		m_alias = null;
		m_browsePath = new RelativePath();
		m_attributeId = 0u;
		m_indexRange = null;
	}

	public override void Encode(IEncoder encoder)
	{
		base.Encode(encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("NodeId", NodeId);
		encoder.WriteString("Alias", Alias);
		encoder.WriteEncodeable("BrowsePath", BrowsePath, typeof(RelativePath));
		encoder.WriteUInt32("AttributeId", AttributeId);
		encoder.WriteString("IndexRange", IndexRange);
		encoder.PopNamespace();
	}

	public override void Decode(IDecoder decoder)
	{
		base.Decode(decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		NodeId = decoder.ReadNodeId("NodeId");
		Alias = decoder.ReadString("Alias");
		BrowsePath = (RelativePath)decoder.ReadEncodeable("BrowsePath", typeof(RelativePath));
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
		if (!(encodeable is AttributeOperand attributeOperand))
		{
			return false;
		}
		if (!base.IsEqual(encodeable))
		{
			return false;
		}
		if (!Utils.IsEqual(m_nodeId, attributeOperand.m_nodeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_alias, attributeOperand.m_alias))
		{
			return false;
		}
		if (!Utils.IsEqual(m_browsePath, attributeOperand.m_browsePath))
		{
			return false;
		}
		if (!Utils.IsEqual(m_attributeId, attributeOperand.m_attributeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_indexRange, attributeOperand.m_indexRange))
		{
			return false;
		}
		return base.IsEqual(encodeable);
	}

	public override object Clone()
	{
		return (AttributeOperand)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		AttributeOperand obj = (AttributeOperand)base.MemberwiseClone();
		obj.m_nodeId = (NodeId)Utils.Clone(m_nodeId);
		obj.m_alias = (string)Utils.Clone(m_alias);
		obj.m_browsePath = (RelativePath)Utils.Clone(m_browsePath);
		obj.m_attributeId = (uint)Utils.Clone(m_attributeId);
		obj.m_indexRange = (string)Utils.Clone(m_indexRange);
		return obj;
	}

	public AttributeOperand(NodeId nodeId, QualifiedName browsePath)
	{
		m_nodeId = nodeId;
		m_attributeId = 13u;
		m_browsePath = new RelativePath();
		RelativePathElement item = new RelativePathElement
		{
			ReferenceTypeId = ReferenceTypeIds.Aggregates,
			IsInverse = false,
			IncludeSubtypes = true,
			TargetName = browsePath
		};
		m_browsePath.Elements.Add(item);
	}

	public AttributeOperand(NodeId nodeId, IList<QualifiedName> browsePaths)
	{
		m_nodeId = nodeId;
		m_attributeId = 13u;
		m_browsePath = new RelativePath();
		for (int i = 0; i < browsePaths.Count; i++)
		{
			RelativePathElement item = new RelativePathElement
			{
				ReferenceTypeId = ReferenceTypeIds.Aggregates,
				IsInverse = false,
				IncludeSubtypes = true,
				TargetName = browsePaths[i]
			};
			m_browsePath.Elements.Add(item);
		}
	}

	public AttributeOperand(FilterContext context, ExpandedNodeId nodeId, RelativePath relativePath)
	{
		m_nodeId = ExpandedNodeId.ToNodeId(nodeId, context.NamespaceUris);
		m_browsePath = relativePath;
		m_attributeId = 13u;
		m_indexRange = null;
		m_alias = null;
	}

	public AttributeOperand(FilterContext context, ExpandedNodeId typeDefinitionId, string browsePath, uint attributeId, string indexRange)
	{
		m_nodeId = ExpandedNodeId.ToNodeId(typeDefinitionId, context.NamespaceUris);
		m_browsePath = RelativePath.Parse(browsePath, context.TypeTree);
		m_attributeId = attributeId;
		m_indexRange = indexRange;
		m_alias = null;
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < m_browsePath.Elements.Count; i++)
			{
				stringBuilder.AppendFormat(formatProvider, "/{0}", m_browsePath.Elements[i].TargetName);
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
		if (!context.TypeTree.IsKnown(m_nodeId))
		{
			return ServiceResult.Create(2153971712u, "AttributeOperand does not have a known TypeDefinitionId ({0}).", m_nodeId);
		}
		if (!Attributes.IsValid(m_attributeId))
		{
			return ServiceResult.Create(2150957056u, "AttributeOperand does not specify a valid AttributeId ({0}).", m_attributeId);
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
				return ServiceResult.Create(e, 2151022592u, "AttributeOperand does not specify a valid BrowsePath ({0}).", m_indexRange);
			}
			if (m_attributeId != 13)
			{
				return ServiceResult.Create(2151022592u, "AttributeOperand specifies an IndexRange for an Attribute other than Value ({0}).", m_attributeId);
			}
		}
		m_validated = true;
		return ServiceResult.Good;
	}

	public override string ToString(INodeTable nodeTable)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (nodeTable.Find(m_nodeId) != null)
		{
			stringBuilder.AppendFormat("{0}", NodeId);
		}
		else
		{
			stringBuilder.AppendFormat("{0}", NodeId);
		}
		if (!RelativePath.IsEmpty(BrowsePath))
		{
			stringBuilder.AppendFormat("/{0}", BrowsePath.Format(nodeTable.TypeTree));
		}
		if (!string.IsNullOrEmpty(IndexRange))
		{
			stringBuilder.AppendFormat("[{0}]", NumericRange.Parse(IndexRange));
		}
		if (!string.IsNullOrEmpty(Alias))
		{
			stringBuilder.AppendFormat("- '{0}'", Alias);
		}
		return stringBuilder.ToString();
	}
}
