using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class QueryDataSet : IEncodeable, ICloneable, IJsonEncodeable
{
	private ExpandedNodeId m_nodeId;

	private ExpandedNodeId m_typeDefinitionNode;

	private VariantCollection m_values;

	[DataMember(Name = "NodeId", IsRequired = false, Order = 1)]
	public ExpandedNodeId NodeId
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

	[DataMember(Name = "TypeDefinitionNode", IsRequired = false, Order = 2)]
	public ExpandedNodeId TypeDefinitionNode
	{
		get
		{
			return m_typeDefinitionNode;
		}
		set
		{
			m_typeDefinitionNode = value;
		}
	}

	[DataMember(Name = "Values", IsRequired = false, Order = 3)]
	public VariantCollection Values
	{
		get
		{
			return m_values;
		}
		set
		{
			m_values = value;
			if (value == null)
			{
				m_values = new VariantCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.QueryDataSet;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.QueryDataSet_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.QueryDataSet_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.QueryDataSet_Encoding_DefaultJson;

	public QueryDataSet()
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
		m_typeDefinitionNode = null;
		m_values = new VariantCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteExpandedNodeId("NodeId", NodeId);
		encoder.WriteExpandedNodeId("TypeDefinitionNode", TypeDefinitionNode);
		encoder.WriteVariantArray("Values", Values);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		NodeId = decoder.ReadExpandedNodeId("NodeId");
		TypeDefinitionNode = decoder.ReadExpandedNodeId("TypeDefinitionNode");
		Values = decoder.ReadVariantArray("Values");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is QueryDataSet queryDataSet))
		{
			return false;
		}
		if (!Utils.IsEqual(m_nodeId, queryDataSet.m_nodeId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_typeDefinitionNode, queryDataSet.m_typeDefinitionNode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_values, queryDataSet.m_values))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (QueryDataSet)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		QueryDataSet obj = (QueryDataSet)base.MemberwiseClone();
		obj.m_nodeId = (ExpandedNodeId)Utils.Clone(m_nodeId);
		obj.m_typeDefinitionNode = (ExpandedNodeId)Utils.Clone(m_typeDefinitionNode);
		obj.m_values = (VariantCollection)Utils.Clone(m_values);
		return obj;
	}
}
