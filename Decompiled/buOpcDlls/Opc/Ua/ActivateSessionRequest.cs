using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ActivateSessionRequest : IEncodeable, ICloneable, IJsonEncodeable, IServiceRequest
{
	private RequestHeader m_requestHeader;

	private SignatureData m_clientSignature;

	private SignedSoftwareCertificateCollection m_clientSoftwareCertificates;

	private StringCollection m_localeIds;

	private ExtensionObject m_userIdentityToken;

	private SignatureData m_userTokenSignature;

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

	[DataMember(Name = "ClientSignature", IsRequired = false, Order = 2)]
	public SignatureData ClientSignature
	{
		get
		{
			return m_clientSignature;
		}
		set
		{
			m_clientSignature = value;
			if (value == null)
			{
				m_clientSignature = new SignatureData();
			}
		}
	}

	[DataMember(Name = "ClientSoftwareCertificates", IsRequired = false, Order = 3)]
	public SignedSoftwareCertificateCollection ClientSoftwareCertificates
	{
		get
		{
			return m_clientSoftwareCertificates;
		}
		set
		{
			m_clientSoftwareCertificates = value;
			if (value == null)
			{
				m_clientSoftwareCertificates = new SignedSoftwareCertificateCollection();
			}
		}
	}

	[DataMember(Name = "LocaleIds", IsRequired = false, Order = 4)]
	public StringCollection LocaleIds
	{
		get
		{
			return m_localeIds;
		}
		set
		{
			m_localeIds = value;
			if (value == null)
			{
				m_localeIds = new StringCollection();
			}
		}
	}

	[DataMember(Name = "UserIdentityToken", IsRequired = false, Order = 5)]
	public ExtensionObject UserIdentityToken
	{
		get
		{
			return m_userIdentityToken;
		}
		set
		{
			m_userIdentityToken = value;
		}
	}

	[DataMember(Name = "UserTokenSignature", IsRequired = false, Order = 6)]
	public SignatureData UserTokenSignature
	{
		get
		{
			return m_userTokenSignature;
		}
		set
		{
			m_userTokenSignature = value;
			if (value == null)
			{
				m_userTokenSignature = new SignatureData();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.ActivateSessionRequest;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ActivateSessionRequest_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ActivateSessionRequest_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ActivateSessionRequest_Encoding_DefaultJson;

	public ActivateSessionRequest()
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
		m_clientSignature = new SignatureData();
		m_clientSoftwareCertificates = new SignedSoftwareCertificateCollection();
		m_localeIds = new StringCollection();
		m_userIdentityToken = null;
		m_userTokenSignature = new SignatureData();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeable("RequestHeader", RequestHeader, typeof(RequestHeader));
		encoder.WriteEncodeable("ClientSignature", ClientSignature, typeof(SignatureData));
		encoder.WriteEncodeableArray("ClientSoftwareCertificates", ClientSoftwareCertificates.ToArray(), typeof(SignedSoftwareCertificate));
		encoder.WriteStringArray("LocaleIds", LocaleIds);
		encoder.WriteExtensionObject("UserIdentityToken", UserIdentityToken);
		encoder.WriteEncodeable("UserTokenSignature", UserTokenSignature, typeof(SignatureData));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		RequestHeader = (RequestHeader)decoder.ReadEncodeable("RequestHeader", typeof(RequestHeader));
		ClientSignature = (SignatureData)decoder.ReadEncodeable("ClientSignature", typeof(SignatureData));
		ClientSoftwareCertificates = (SignedSoftwareCertificate[])decoder.ReadEncodeableArray("ClientSoftwareCertificates", typeof(SignedSoftwareCertificate));
		LocaleIds = decoder.ReadStringArray("LocaleIds");
		UserIdentityToken = decoder.ReadExtensionObject("UserIdentityToken");
		UserTokenSignature = (SignatureData)decoder.ReadEncodeable("UserTokenSignature", typeof(SignatureData));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ActivateSessionRequest activateSessionRequest))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHeader, activateSessionRequest.m_requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_clientSignature, activateSessionRequest.m_clientSignature))
		{
			return false;
		}
		if (!Utils.IsEqual(m_clientSoftwareCertificates, activateSessionRequest.m_clientSoftwareCertificates))
		{
			return false;
		}
		if (!Utils.IsEqual(m_localeIds, activateSessionRequest.m_localeIds))
		{
			return false;
		}
		if (!Utils.IsEqual(m_userIdentityToken, activateSessionRequest.m_userIdentityToken))
		{
			return false;
		}
		if (!Utils.IsEqual(m_userTokenSignature, activateSessionRequest.m_userTokenSignature))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ActivateSessionRequest)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ActivateSessionRequest obj = (ActivateSessionRequest)base.MemberwiseClone();
		obj.m_requestHeader = (RequestHeader)Utils.Clone(m_requestHeader);
		obj.m_clientSignature = (SignatureData)Utils.Clone(m_clientSignature);
		obj.m_clientSoftwareCertificates = (SignedSoftwareCertificateCollection)Utils.Clone(m_clientSoftwareCertificates);
		obj.m_localeIds = (StringCollection)Utils.Clone(m_localeIds);
		obj.m_userIdentityToken = (ExtensionObject)Utils.Clone(m_userIdentityToken);
		obj.m_userTokenSignature = (SignatureData)Utils.Clone(m_userTokenSignature);
		return obj;
	}
}
