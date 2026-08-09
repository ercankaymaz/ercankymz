using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class NodeTypeDescription : IEncodeable, ICloneable, IJsonEncodeable
{
	private ExpandedNodeId m_typeDefinitionNode;

	private bool m_includeSubTypes;

	private QueryDataDescriptionCollection m_dataToReturn;

	[DataMember(Name = "TypeDefinitionNode", IsRequired = false, Order = 1)]
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

	[DataMember(Name = "IncludeSubTypes", IsRequired = false, Order = 2)]
	public bool IncludeSubTypes
	{
		get
		{
			return m_includeSubTypes;
		}
		set
		{
			m_includeSubTypes = value;
		}
	}

	[DataMember(Name = "DataToReturn", IsRequired = false, Order = 3)]
	public QueryDataDescriptionCollection DataToReturn
	{
		get
		{
			return m_dataToReturn;
		}
		set
		{
			m_dataToReturn = value;
			if (value == null)
			{
				m_dataToReturn = new QueryDataDescriptionCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.NodeTypeDescription;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.NodeTypeDescription_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.NodeTypeDescription_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.NodeTypeDescription_Encoding_DefaultJson;

	public object Handle { get; set; }

	public bool Processed { get; set; }

	public NodeTypeDescription()
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
		m_typeDefinitionNode = null;
		m_includeSubTypes = true;
		m_dataToReturn = new QueryDataDescriptionCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteExpandedNodeId("TypeDefinitionNode", TypeDefinitionNode);
		encoder.WriteBoolean("IncludeSubTypes", IncludeSubTypes);
		encoder.WriteEncodeableArray("DataToReturn", DataToReturn.ToArray(), typeof(QueryDataDescription));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		TypeDefinitionNode = decoder.ReadExpandedNodeId("TypeDefinitionNode");
		IncludeSubTypes = decoder.ReadBoolean("IncludeSubTypes");
		DataToReturn = (QueryDataDescription[])decoder.ReadEncodeableArray("DataToReturn", typeof(QueryDataDescription));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is NodeTypeDescription nodeTypeDescription))
		{
			return false;
		}
		if (!Utils.IsEqual(m_typeDefinitionNode, nodeTypeDescription.m_typeDefinitionNode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_includeSubTypes, nodeTypeDescription.m_includeSubTypes))
		{
			return false;
		}
		if (!Utils.IsEqual(m_dataToReturn, nodeTypeDescription.m_dataToReturn))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (NodeTypeDescription)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		NodeTypeDescription obj = (NodeTypeDescription)base.MemberwiseClone();
		obj.m_typeDefinitionNode = (ExpandedNodeId)Utils.Clone(m_typeDefinitionNode);
		obj.m_includeSubTypes = (bool)Utils.Clone(m_includeSubTypes);
		obj.m_dataToReturn = (QueryDataDescriptionCollection)Utils.Clone(m_dataToReturn);
		return obj;
	}
}
