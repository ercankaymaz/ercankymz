using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class AddReferencesRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private AddReferencesItemCollection m_referencesToAdd;

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

	[DataMember(Name = "ReferencesToAdd", IsRequired = false, Order = 2)]
	public AddReferencesItemCollection ReferencesToAdd
	{
		get
		{
			return m_referencesToAdd;
		}
		set
		{
			m_referencesToAdd = value;
			if (value == null)
			{
				m_referencesToAdd = new AddReferencesItemCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.AddReferencesRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.AddReferencesRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.AddReferencesRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.AddReferencesRequest_Encoding_DefaultJson;

	public AddReferencesRequest()
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
		m_referencesToAdd = new AddReferencesItemCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteEncodeableArray("ReferencesToAdd", ReferencesToAdd.ToArray(), typeof(AddReferencesItem));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		ReferencesToAdd = (AddReferencesItem[])decoder.ReadEncodeableArray("ReferencesToAdd", typeof(AddReferencesItem));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is AddReferencesRequest addReferencesRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, addReferencesRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_referencesToAdd, addReferencesRequest.m_referencesToAdd))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (AddReferencesRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		AddReferencesRequest obj = (AddReferencesRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_referencesToAdd = (AddReferencesItemCollection)Utils.Clone(m_referencesToAdd);
		return obj;
	}
}
