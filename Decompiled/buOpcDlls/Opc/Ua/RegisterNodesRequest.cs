using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class RegisterNodesRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private NodeIdCollection m_nodesToRegister;

	[DataMember(Name = "RequestHeader", IsRequired = false, Order = 1)]
	public RequestHeader RequestHeader
	{
		get
		{
			return m_requestHeader;
		}
		set
		{
			m_requestHeader = value;
			if (value == null)
			{
				m_requestHeader = new RequestHeader();
			}
		}
	}

	[DataMember(Name = "NodesToRegister", IsRequired = false, Order = 2)]
	public NodeIdCollection NodesToRegister
	{
		get
		{
			return m_nodesToRegister;
		}
		set
		{
			m_nodesToRegister = value;
			if (value == null)
			{
				m_nodesToRegister = new NodeIdCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.RegisterNodesRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.RegisterNodesRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.RegisterNodesRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.RegisterNodesRequest_Encoding_DefaultJson;

	public RegisterNodesRequest()
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
		m_requestHeader = new RequestHeader();
		m_nodesToRegister = new NodeIdCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteNodeIdArray("NodesToRegister", NodesToRegister);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		NodesToRegister = decoder.ReadNodeIdArray("NodesToRegister");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is RegisterNodesRequest registerNodesRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, registerNodesRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_nodesToRegister, registerNodesRequest.m_nodesToRegister))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (RegisterNodesRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		RegisterNodesRequest obj = (RegisterNodesRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_nodesToRegister = (NodeIdCollection)Utils.Clone(m_nodesToRegister);
		return obj;
	}
}
