using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class UnregisterNodesRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private NodeIdCollection m_nodesToUnregister;

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

	[DataMember(Name = "NodesToUnregister", IsRequired = false, Order = 2)]
	public NodeIdCollection NodesToUnregister
	{
		get
		{
			return m_nodesToUnregister;
		}
		set
		{
			m_nodesToUnregister = value;
			if (value == null)
			{
				m_nodesToUnregister = new NodeIdCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.UnregisterNodesRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.UnregisterNodesRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.UnregisterNodesRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.UnregisterNodesRequest_Encoding_DefaultJson;

	public UnregisterNodesRequest()
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
		m_nodesToUnregister = new NodeIdCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteNodeIdArray("NodesToUnregister", NodesToUnregister);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		NodesToUnregister = decoder.ReadNodeIdArray("NodesToUnregister");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is UnregisterNodesRequest unregisterNodesRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, unregisterNodesRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_nodesToUnregister, unregisterNodesRequest.m_nodesToUnregister))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (UnregisterNodesRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		UnregisterNodesRequest obj = (UnregisterNodesRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_nodesToUnregister = (NodeIdCollection)Utils.Clone(m_nodesToUnregister);
		return obj;
	}
}
