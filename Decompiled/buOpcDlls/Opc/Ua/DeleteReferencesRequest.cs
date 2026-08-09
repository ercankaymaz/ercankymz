using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DeleteReferencesRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private DeleteReferencesItemCollection m_referencesToDelete;

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

	[DataMember(Name = "ReferencesToDelete", IsRequired = false, Order = 2)]
	public DeleteReferencesItemCollection ReferencesToDelete
	{
		get
		{
			return m_referencesToDelete;
		}
		set
		{
			m_referencesToDelete = value;
			if (value == null)
			{
				m_referencesToDelete = new DeleteReferencesItemCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.DeleteReferencesRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.DeleteReferencesRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.DeleteReferencesRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.DeleteReferencesRequest_Encoding_DefaultJson;

	public DeleteReferencesRequest()
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
		m_referencesToDelete = new DeleteReferencesItemCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteEncodeableArray("ReferencesToDelete", ReferencesToDelete.ToArray(), typeof(DeleteReferencesItem));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		ReferencesToDelete = (DeleteReferencesItem[])decoder.ReadEncodeableArray("ReferencesToDelete", typeof(DeleteReferencesItem));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is DeleteReferencesRequest deleteReferencesRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, deleteReferencesRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_referencesToDelete, deleteReferencesRequest.m_referencesToDelete))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (DeleteReferencesRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		DeleteReferencesRequest obj = (DeleteReferencesRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_referencesToDelete = (DeleteReferencesItemCollection)Utils.Clone(m_referencesToDelete);
		return obj;
	}
}
