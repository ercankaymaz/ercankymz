using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class RegisterNodesResponse : IEncodeable, ICloneable, IJsonEncodeable, IServiceResponse
{
	private ResponseHeader m_responseHeader;

	private NodeIdCollection m_registeredNodeIds;

	[DataMember(Name = "ResponseHeader", IsRequired = false, Order = 1)]
	public ResponseHeader ResponseHeader
	{
		get
		{
			return m_responseHeader;
		}
		set
		{
			m_responseHeader = value;
			if (value == null)
			{
				m_responseHeader = new ResponseHeader();
			}
		}
	}

	[DataMember(Name = "RegisteredNodeIds", IsRequired = false, Order = 2)]
	public NodeIdCollection RegisteredNodeIds
	{
		get
		{
			return m_registeredNodeIds;
		}
		set
		{
			m_registeredNodeIds = value;
			if (value == null)
			{
				m_registeredNodeIds = new NodeIdCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.RegisterNodesResponse;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.RegisterNodesResponse_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.RegisterNodesResponse_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.RegisterNodesResponse_Encoding_DefaultJson;

	public RegisterNodesResponse()
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
		m_responseHeader = new ResponseHeader();
		m_registeredNodeIds = new NodeIdCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("ResponseHeader", ResponseHeader, typeof(ResponseHeader));
		encoder.WriteNodeIdArray("RegisteredNodeIds", RegisteredNodeIds);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ResponseHeader = (ResponseHeader)decoder.ReadEncodeable("ResponseHeader", typeof(ResponseHeader));
		RegisteredNodeIds = decoder.ReadNodeIdArray("RegisteredNodeIds");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is RegisterNodesResponse registerNodesResponse))
		{
			return false;
		}
		if (!Utils.IsEqual(m_responseHeader, registerNodesResponse.m_responseHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_registeredNodeIds, registerNodesResponse.m_registeredNodeIds))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (RegisterNodesResponse)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		RegisterNodesResponse obj = (RegisterNodesResponse)base.MemberwiseClone();
		obj.m_responseHeader = (ResponseHeader)Utils.Clone(m_responseHeader);
		obj.m_registeredNodeIds = (NodeIdCollection)Utils.Clone(m_registeredNodeIds);
		return obj;
	}
}
