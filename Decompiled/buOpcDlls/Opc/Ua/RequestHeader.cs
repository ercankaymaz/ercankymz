using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class RequestHeader : IEncodeable, ICloneable, IJsonEncodeable
{
	private NodeId m_authenticationToken;

	private DateTime m_timestamp;

	private uint m_requestHandle;

	private uint m_returnDiagnostics;

	private string m_auditEntryId;

	private uint m_timeoutHint;

	private ExtensionObject m_additionalHeader;

	[DataMember(Name = "AuthenticationToken", IsRequired = false, Order = 1)]
	public NodeId AuthenticationToken
	{
		get
		{
			return m_authenticationToken;
		}
		set
		{
			m_authenticationToken = value;
		}
	}

	[DataMember(Name = "Timestamp", IsRequired = false, Order = 2)]
	public DateTime Timestamp
	{
		get
		{
			return m_timestamp;
		}
		set
		{
			m_timestamp = value;
		}
	}

	[DataMember(Name = "RequestHandle", IsRequired = false, Order = 3)]
	public uint RequestHandle
	{
		get
		{
			return m_requestHandle;
		}
		set
		{
			m_requestHandle = value;
		}
	}

	[DataMember(Name = "ReturnDiagnostics", IsRequired = false, Order = 4)]
	public uint ReturnDiagnostics
	{
		get
		{
			return m_returnDiagnostics;
		}
		set
		{
			m_returnDiagnostics = value;
		}
	}

	[DataMember(Name = "AuditEntryId", IsRequired = false, Order = 5)]
	public string AuditEntryId
	{
		get
		{
			return m_auditEntryId;
		}
		set
		{
			m_auditEntryId = value;
		}
	}

	[DataMember(Name = "TimeoutHint", IsRequired = false, Order = 6)]
	public uint TimeoutHint
	{
		get
		{
			return m_timeoutHint;
		}
		set
		{
			m_timeoutHint = value;
		}
	}

	[DataMember(Name = "AdditionalHeader", IsRequired = false, Order = 7)]
	public ExtensionObject AdditionalHeader
	{
		get
		{
			return m_additionalHeader;
		}
		set
		{
			m_additionalHeader = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.RequestHeader;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.RequestHeader_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.RequestHeader_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.RequestHeader_Encoding_DefaultJson;

	public RequestHeader()
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
		m_authenticationToken = null;
		m_timestamp = DateTime.MinValue;
		m_requestHandle = 0u;
		m_returnDiagnostics = 0u;
		m_auditEntryId = null;
		m_timeoutHint = 0u;
		m_additionalHeader = null;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("AuthenticationToken", AuthenticationToken);
		encoder.WriteDateTime("Timestamp", Timestamp);
		encoder.WriteUInt32("RequestHandle", RequestHandle);
		encoder.WriteUInt32("ReturnDiagnostics", ReturnDiagnostics);
		encoder.WriteString("AuditEntryId", AuditEntryId);
		encoder.WriteUInt32("TimeoutHint", TimeoutHint);
		encoder.WriteExtensionObject("AdditionalHeader", AdditionalHeader);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		AuthenticationToken = decoder.ReadNodeId("AuthenticationToken");
		Timestamp = decoder.ReadDateTime("Timestamp");
		RequestHandle = decoder.ReadUInt32("RequestHandle");
		ReturnDiagnostics = decoder.ReadUInt32("ReturnDiagnostics");
		AuditEntryId = decoder.ReadString("AuditEntryId");
		TimeoutHint = decoder.ReadUInt32("TimeoutHint");
		AdditionalHeader = decoder.ReadExtensionObject("AdditionalHeader");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is RequestHeader requestHeader))
		{
			return false;
		}
		if (!Utils.IsEqual(m_authenticationToken, requestHeader.m_authenticationToken))
		{
			return false;
		}
		if (!Utils.IsEqual(m_timestamp, requestHeader.m_timestamp))
		{
			return false;
		}
		if (!Utils.IsEqual(m_requestHandle, requestHeader.m_requestHandle))
		{
			return false;
		}
		if (!Utils.IsEqual(m_returnDiagnostics, requestHeader.m_returnDiagnostics))
		{
			return false;
		}
		if (!Utils.IsEqual(m_auditEntryId, requestHeader.m_auditEntryId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_timeoutHint, requestHeader.m_timeoutHint))
		{
			return false;
		}
		if (!Utils.IsEqual(m_additionalHeader, requestHeader.m_additionalHeader))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (RequestHeader)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		RequestHeader obj = (RequestHeader)base.MemberwiseClone();
		obj.m_authenticationToken = (NodeId)Utils.Clone(m_authenticationToken);
		obj.m_timestamp = (DateTime)Utils.Clone(m_timestamp);
		obj.m_requestHandle = (uint)Utils.Clone(m_requestHandle);
		obj.m_returnDiagnostics = (uint)Utils.Clone(m_returnDiagnostics);
		obj.m_auditEntryId = (string)Utils.Clone(m_auditEntryId);
		obj.m_timeoutHint = (uint)Utils.Clone(m_timeoutHint);
		obj.m_additionalHeader = (ExtensionObject)Utils.Clone(m_additionalHeader);
		return obj;
	}
}
