using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class ServerDiagnosticsSummaryDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private uint m_serverViewCount;

	private uint m_currentSessionCount;

	private uint m_cumulatedSessionCount;

	private uint m_securityRejectedSessionCount;

	private uint m_rejectedSessionCount;

	private uint m_sessionTimeoutCount;

	private uint m_sessionAbortCount;

	private uint m_currentSubscriptionCount;

	private uint m_cumulatedSubscriptionCount;

	private uint m_publishingIntervalCount;

	private uint m_securityRejectedRequestsCount;

	private uint m_rejectedRequestsCount;

	[DataMember(Name = "ServerViewCount", IsRequired = false, Order = 1)]
	public uint ServerViewCount
	{
		get
		{
			return m_serverViewCount;
		}
		set
		{
			m_serverViewCount = value;
		}
	}

	[DataMember(Name = "CurrentSessionCount", IsRequired = false, Order = 2)]
	public uint CurrentSessionCount
	{
		get
		{
			return m_currentSessionCount;
		}
		set
		{
			m_currentSessionCount = value;
		}
	}

	[DataMember(Name = "CumulatedSessionCount", IsRequired = false, Order = 3)]
	public uint CumulatedSessionCount
	{
		get
		{
			return m_cumulatedSessionCount;
		}
		set
		{
			m_cumulatedSessionCount = value;
		}
	}

	[DataMember(Name = "SecurityRejectedSessionCount", IsRequired = false, Order = 4)]
	public uint SecurityRejectedSessionCount
	{
		get
		{
			return m_securityRejectedSessionCount;
		}
		set
		{
			m_securityRejectedSessionCount = value;
		}
	}

	[DataMember(Name = "RejectedSessionCount", IsRequired = false, Order = 5)]
	public uint RejectedSessionCount
	{
		get
		{
			return m_rejectedSessionCount;
		}
		set
		{
			m_rejectedSessionCount = value;
		}
	}

	[DataMember(Name = "SessionTimeoutCount", IsRequired = false, Order = 6)]
	public uint SessionTimeoutCount
	{
		get
		{
			return m_sessionTimeoutCount;
		}
		set
		{
			m_sessionTimeoutCount = value;
		}
	}

	[DataMember(Name = "SessionAbortCount", IsRequired = false, Order = 7)]
	public uint SessionAbortCount
	{
		get
		{
			return m_sessionAbortCount;
		}
		set
		{
			m_sessionAbortCount = value;
		}
	}

	[DataMember(Name = "CurrentSubscriptionCount", IsRequired = false, Order = 8)]
	public uint CurrentSubscriptionCount
	{
		get
		{
			return m_currentSubscriptionCount;
		}
		set
		{
			m_currentSubscriptionCount = value;
		}
	}

	[DataMember(Name = "CumulatedSubscriptionCount", IsRequired = false, Order = 9)]
	public uint CumulatedSubscriptionCount
	{
		get
		{
			return m_cumulatedSubscriptionCount;
		}
		set
		{
			m_cumulatedSubscriptionCount = value;
		}
	}

	[DataMember(Name = "PublishingIntervalCount", IsRequired = false, Order = 10)]
	public uint PublishingIntervalCount
	{
		get
		{
			return m_publishingIntervalCount;
		}
		set
		{
			m_publishingIntervalCount = value;
		}
	}

	[DataMember(Name = "SecurityRejectedRequestsCount", IsRequired = false, Order = 11)]
	public uint SecurityRejectedRequestsCount
	{
		get
		{
			return m_securityRejectedRequestsCount;
		}
		set
		{
			m_securityRejectedRequestsCount = value;
		}
	}

	[DataMember(Name = "RejectedRequestsCount", IsRequired = false, Order = 12)]
	public uint RejectedRequestsCount
	{
		get
		{
			return m_rejectedRequestsCount;
		}
		set
		{
			m_rejectedRequestsCount = value;
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.ServerDiagnosticsSummaryDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.ServerDiagnosticsSummaryDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.ServerDiagnosticsSummaryDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.ServerDiagnosticsSummaryDataType_Encoding_DefaultJson;

	public ServerDiagnosticsSummaryDataType()
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
		m_serverViewCount = 0u;
		m_currentSessionCount = 0u;
		m_cumulatedSessionCount = 0u;
		m_securityRejectedSessionCount = 0u;
		m_rejectedSessionCount = 0u;
		m_sessionTimeoutCount = 0u;
		m_sessionAbortCount = 0u;
		m_currentSubscriptionCount = 0u;
		m_cumulatedSubscriptionCount = 0u;
		m_publishingIntervalCount = 0u;
		m_securityRejectedRequestsCount = 0u;
		m_rejectedRequestsCount = 0u;
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteUInt32("ServerViewCount", ServerViewCount);
		encoder.WriteUInt32("CurrentSessionCount", CurrentSessionCount);
		encoder.WriteUInt32("CumulatedSessionCount", CumulatedSessionCount);
		encoder.WriteUInt32("SecurityRejectedSessionCount", SecurityRejectedSessionCount);
		encoder.WriteUInt32("RejectedSessionCount", RejectedSessionCount);
		encoder.WriteUInt32("SessionTimeoutCount", SessionTimeoutCount);
		encoder.WriteUInt32("SessionAbortCount", SessionAbortCount);
		encoder.WriteUInt32("CurrentSubscriptionCount", CurrentSubscriptionCount);
		encoder.WriteUInt32("CumulatedSubscriptionCount", CumulatedSubscriptionCount);
		encoder.WriteUInt32("PublishingIntervalCount", PublishingIntervalCount);
		encoder.WriteUInt32("SecurityRejectedRequestsCount", SecurityRejectedRequestsCount);
		encoder.WriteUInt32("RejectedRequestsCount", RejectedRequestsCount);
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		ServerViewCount = decoder.ReadUInt32("ServerViewCount");
		CurrentSessionCount = decoder.ReadUInt32("CurrentSessionCount");
		CumulatedSessionCount = decoder.ReadUInt32("CumulatedSessionCount");
		SecurityRejectedSessionCount = decoder.ReadUInt32("SecurityRejectedSessionCount");
		RejectedSessionCount = decoder.ReadUInt32("RejectedSessionCount");
		SessionTimeoutCount = decoder.ReadUInt32("SessionTimeoutCount");
		SessionAbortCount = decoder.ReadUInt32("SessionAbortCount");
		CurrentSubscriptionCount = decoder.ReadUInt32("CurrentSubscriptionCount");
		CumulatedSubscriptionCount = decoder.ReadUInt32("CumulatedSubscriptionCount");
		PublishingIntervalCount = decoder.ReadUInt32("PublishingIntervalCount");
		SecurityRejectedRequestsCount = decoder.ReadUInt32("SecurityRejectedRequestsCount");
		RejectedRequestsCount = decoder.ReadUInt32("RejectedRequestsCount");
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is ServerDiagnosticsSummaryDataType serverDiagnosticsSummaryDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serverViewCount, serverDiagnosticsSummaryDataType.m_serverViewCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_currentSessionCount, serverDiagnosticsSummaryDataType.m_currentSessionCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_cumulatedSessionCount, serverDiagnosticsSummaryDataType.m_cumulatedSessionCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_securityRejectedSessionCount, serverDiagnosticsSummaryDataType.m_securityRejectedSessionCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_rejectedSessionCount, serverDiagnosticsSummaryDataType.m_rejectedSessionCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_sessionTimeoutCount, serverDiagnosticsSummaryDataType.m_sessionTimeoutCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_sessionAbortCount, serverDiagnosticsSummaryDataType.m_sessionAbortCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_currentSubscriptionCount, serverDiagnosticsSummaryDataType.m_currentSubscriptionCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_cumulatedSubscriptionCount, serverDiagnosticsSummaryDataType.m_cumulatedSubscriptionCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_publishingIntervalCount, serverDiagnosticsSummaryDataType.m_publishingIntervalCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_securityRejectedRequestsCount, serverDiagnosticsSummaryDataType.m_securityRejectedRequestsCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_rejectedRequestsCount, serverDiagnosticsSummaryDataType.m_rejectedRequestsCount))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (ServerDiagnosticsSummaryDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		ServerDiagnosticsSummaryDataType obj = (ServerDiagnosticsSummaryDataType)base.MemberwiseClone();
		obj.m_serverViewCount = (uint)Utils.Clone(m_serverViewCount);
		obj.m_currentSessionCount = (uint)Utils.Clone(m_currentSessionCount);
		obj.m_cumulatedSessionCount = (uint)Utils.Clone(m_cumulatedSessionCount);
		obj.m_securityRejectedSessionCount = (uint)Utils.Clone(m_securityRejectedSessionCount);
		obj.m_rejectedSessionCount = (uint)Utils.Clone(m_rejectedSessionCount);
		obj.m_sessionTimeoutCount = (uint)Utils.Clone(m_sessionTimeoutCount);
		obj.m_sessionAbortCount = (uint)Utils.Clone(m_sessionAbortCount);
		obj.m_currentSubscriptionCount = (uint)Utils.Clone(m_currentSubscriptionCount);
		obj.m_cumulatedSubscriptionCount = (uint)Utils.Clone(m_cumulatedSubscriptionCount);
		obj.m_publishingIntervalCount = (uint)Utils.Clone(m_publishingIntervalCount);
		obj.m_securityRejectedRequestsCount = (uint)Utils.Clone(m_securityRejectedRequestsCount);
		obj.m_rejectedRequestsCount = (uint)Utils.Clone(m_rejectedRequestsCount);
		return obj;
	}
}
