using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DeleteNodesRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private DeleteNodesItemCollection m_nodesToDelete;

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

	[DataMember(Name = "NodesToDelete", IsRequired = false, Order = 2)]
	public DeleteNodesItemCollection NodesToDelete
	{
		get
		{
			return m_nodesToDelete;
		}
		set
		{
			m_nodesToDelete = value;
			if (value == null)
			{
				m_nodesToDelete = new DeleteNodesItemCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.DeleteNodesRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.DeleteNodesRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.DeleteNodesRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.DeleteNodesRequest_Encoding_DefaultJson;

	public DeleteNodesRequest()
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
		m_nodesToDelete = new DeleteNodesItemCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteEncodeableArray("NodesToDelete", NodesToDelete.ToArray(), typeof(DeleteNodesItem));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		NodesToDelete = (DeleteNodesItem[])decoder.ReadEncodeableArray("NodesToDelete", typeof(DeleteNodesItem));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is DeleteNodesRequest deleteNodesRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, deleteNodesRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_nodesToDelete, deleteNodesRequest.m_nodesToDelete))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (DeleteNodesRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DeleteNodesRequest obj = (DeleteNodesRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_nodesToDelete = (DeleteNodesItemCollection)Utils.Clone(m_nodesToDelete);
		return obj;
	}
}
