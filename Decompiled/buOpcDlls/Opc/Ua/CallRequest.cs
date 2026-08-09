using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class CallRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private CallMethodRequestCollection m_methodsToCall;

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

	[DataMember(Name = "MethodsToCall", IsRequired = false, Order = 2)]
	public CallMethodRequestCollection MethodsToCall
	{
		get
		{
			return m_methodsToCall;
		}
		set
		{
			m_methodsToCall = value;
			if (value == null)
			{
				m_methodsToCall = new CallMethodRequestCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.CallRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.CallRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.CallRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.CallRequest_Encoding_DefaultJson;

	public CallRequest()
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
		m_methodsToCall = new CallMethodRequestCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteEncodeableArray("MethodsToCall", MethodsToCall.ToArray(), typeof(CallMethodRequest));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		MethodsToCall = (CallMethodRequest[])decoder.ReadEncodeableArray("MethodsToCall", typeof(CallMethodRequest));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is CallRequest callRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, callRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_methodsToCall, callRequest.m_methodsToCall))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (CallRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		CallRequest obj = (CallRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_methodsToCall = (CallMethodRequestCollection)Utils.Clone(m_methodsToCall);
		return obj;
	}
}
