using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class AddNodesResult : IEncodeable, ICloneable, IJsonEncodeable
{
	private StatusCode m_statusCode;

	private NodeId m_addedNodeId;

	[DataMember(Name = "StatusCode", IsRequired = false, Order = 1)]
	public StatusCode StatusCode
	{
		get
		{
			return m_statusCode;
		}
		set
		{
			m_statusCode = value;
		}
	}

	[DataMember(Name = "AddedNodeId", IsRequired = false, Order = 2)]
	public NodeId AddedNodeId
	{
		get
		{
			return m_addedNodeId;
		}
		set
		{
			m_addedNodeId = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.AddNodesResult;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.AddNodesResult_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.AddNodesResult_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.AddNodesResult_Encoding_DefaultJson;

	public AddNodesResult()
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
		m_statusCode = 0u;
		m_addedNodeId = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteStatusCode("StatusCode", StatusCode);
		encoder.WriteNodeId("AddedNodeId", AddedNodeId);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		StatusCode = decoder.ReadStatusCode("StatusCode");
		AddedNodeId = decoder.ReadNodeId("AddedNodeId");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is AddNodesResult addNodesResult))
		{
			return false;
		}
		if (!Utils.IsEqual(m_statusCode, addNodesResult.m_statusCode))
		{
			return false;
		}
		if (!Utils.IsEqual(m_addedNodeId, addNodesResult.m_addedNodeId))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (AddNodesResult)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		AddNodesResult obj = (AddNodesResult)base.MemberwiseClone();
		obj.m_statusCode = (StatusCode)Utils.Clone(m_statusCode);
		obj.m_addedNodeId = (NodeId)Utils.Clone(m_addedNodeId);
		return obj;
	}
}
