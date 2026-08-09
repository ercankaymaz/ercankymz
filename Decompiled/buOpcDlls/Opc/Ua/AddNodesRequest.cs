using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class AddNodesRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private AddNodesItemCollection m_nodesToAdd;

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

	[DataMember(Name = "NodesToAdd", IsRequired = false, Order = 2)]
	public AddNodesItemCollection NodesToAdd
	{
		get
		{
			return m_nodesToAdd;
		}
		set
		{
			m_nodesToAdd = value;
			if (value == null)
			{
				m_nodesToAdd = new AddNodesItemCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.AddNodesRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.AddNodesRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.AddNodesRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.AddNodesRequest_Encoding_DefaultJson;

	public AddNodesRequest()
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
		m_nodesToAdd = new AddNodesItemCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteEncodeableArray("NodesToAdd", NodesToAdd.ToArray(), typeof(AddNodesItem));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		NodesToAdd = (AddNodesItem[])decoder.ReadEncodeableArray("NodesToAdd", typeof(AddNodesItem));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is AddNodesRequest addNodesRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, addNodesRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_nodesToAdd, addNodesRequest.m_nodesToAdd))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (AddNodesRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		AddNodesRequest obj = (AddNodesRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_nodesToAdd = (AddNodesItemCollection)Utils.Clone(m_nodesToAdd);
		return obj;
	}
}
