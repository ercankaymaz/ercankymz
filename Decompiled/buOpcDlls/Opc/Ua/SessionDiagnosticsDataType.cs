using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class SessionDiagnosticsDataType : IEncodeable, ICloneable, IJsonEncodeable
{
	private NodeId m_sessionId;

	private string m_sessionName;

	private ApplicationDescription m_clientDescription;

	private string m_serverUri;

	private string m_endpointUrl;

	private StringCollection m_localeIds;

	private double m_actualSessionTimeout;

	private uint m_maxResponseMessageSize;

	private DateTime m_clientConnectionTime;

	private DateTime m_clientLastContactTime;

	private uint m_currentSubscriptionsCount;

	private uint m_currentMonitoredItemsCount;

	private uint m_currentPublishRequestsInQueue;

	private ServiceCounterDataType m_totalRequestCount;

	private uint m_unauthorizedRequestCount;

	private ServiceCounterDataType m_readCount;

	private ServiceCounterDataType m_historyReadCount;

	private ServiceCounterDataType m_writeCount;

	private ServiceCounterDataType m_historyUpdateCount;

	private ServiceCounterDataType m_callCount;

	private ServiceCounterDataType m_createMonitoredItemsCount;

	private ServiceCounterDataType m_modifyMonitoredItemsCount;

	private ServiceCounterDataType m_setMonitoringModeCount;

	private ServiceCounterDataType m_setTriggeringCount;

	private ServiceCounterDataType m_deleteMonitoredItemsCount;

	private ServiceCounterDataType m_createSubscriptionCount;

	private ServiceCounterDataType m_modifySubscriptionCount;

	private ServiceCounterDataType m_setPublishingModeCount;

	private ServiceCounterDataType m_publishCount;

	private ServiceCounterDataType m_republishCount;

	private ServiceCounterDataType m_transferSubscriptionsCount;

	private ServiceCounterDataType m_deleteSubscriptionsCount;

	private ServiceCounterDataType m_addNodesCount;

	private ServiceCounterDataType m_addReferencesCount;

	private ServiceCounterDataType m_deleteNodesCount;

	private ServiceCounterDataType m_deleteReferencesCount;

	private ServiceCounterDataType m_browseCount;

	private ServiceCounterDataType m_browseNextCount;

	private ServiceCounterDataType m_translateBrowsePathsToNodeIdsCount;

	private ServiceCounterDataType m_queryFirstCount;

	private ServiceCounterDataType m_queryNextCount;

	private ServiceCounterDataType m_registerNodesCount;

	private ServiceCounterDataType m_unregisterNodesCount;

	[DataMember(Name = "SessionId", IsRequired = false, Order = 1)]
	public NodeId SessionId
	{
		get
		{
			return m_sessionId;
		}
		set
		{
			m_sessionId = value;
		}
	}

	[DataMember(Name = "SessionName", IsRequired = false, Order = 2)]
	public string SessionName
	{
		get
		{
			return m_sessionName;
		}
		set
		{
			m_sessionName = value;
		}
	}

	[DataMember(Name = "ClientDescription", IsRequired = false, Order = 3)]
	public ApplicationDescription ClientDescription
	{
		get
		{
			return m_clientDescription;
		}
		set
		{
			m_clientDescription = value;
			if (value == null)
			{
				m_clientDescription = new ApplicationDescription();
			}
		}
	}

	[DataMember(Name = "ServerUri", IsRequired = false, Order = 4)]
	public string ServerUri
	{
		get
		{
			return m_serverUri;
		}
		set
		{
			m_serverUri = value;
		}
	}

	[DataMember(Name = "EndpointUrl", IsRequired = false, Order = 5)]
	public string EndpointUrl
	{
		get
		{
			return m_endpointUrl;
		}
		set
		{
			m_endpointUrl = value;
		}
	}

	[DataMember(Name = "LocaleIds", IsRequired = false, Order = 6)]
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

	[DataMember(Name = "ActualSessionTimeout", IsRequired = false, Order = 7)]
	public double ActualSessionTimeout
	{
		get
		{
			return m_actualSessionTimeout;
		}
		set
		{
			m_actualSessionTimeout = value;
		}
	}

	[DataMember(Name = "MaxResponseMessageSize", IsRequired = false, Order = 8)]
	public uint MaxResponseMessageSize
	{
		get
		{
			return m_maxResponseMessageSize;
		}
		set
		{
			m_maxResponseMessageSize = value;
		}
	}

	[DataMember(Name = "ClientConnectionTime", IsRequired = false, Order = 9)]
	public DateTime ClientConnectionTime
	{
		get
		{
			return m_clientConnectionTime;
		}
		set
		{
			m_clientConnectionTime = value;
		}
	}

	[DataMember(Name = "ClientLastContactTime", IsRequired = false, Order = 10)]
	public DateTime ClientLastContactTime
	{
		get
		{
			return m_clientLastContactTime;
		}
		set
		{
			m_clientLastContactTime = value;
		}
	}

	[DataMember(Name = "CurrentSubscriptionsCount", IsRequired = false, Order = 11)]
	public uint CurrentSubscriptionsCount
	{
		get
		{
			return m_currentSubscriptionsCount;
		}
		set
		{
			m_currentSubscriptionsCount = value;
		}
	}

	[DataMember(Name = "CurrentMonitoredItemsCount", IsRequired = false, Order = 12)]
	public uint CurrentMonitoredItemsCount
	{
		get
		{
			return m_currentMonitoredItemsCount;
		}
		set
		{
			m_currentMonitoredItemsCount = value;
		}
	}

	[DataMember(Name = "CurrentPublishRequestsInQueue", IsRequired = false, Order = 13)]
	public uint CurrentPublishRequestsInQueue
	{
		get
		{
			return m_currentPublishRequestsInQueue;
		}
		set
		{
			m_currentPublishRequestsInQueue = value;
		}
	}

	[DataMember(Name = "TotalRequestCount", IsRequired = false, Order = 14)]
	public ServiceCounterDataType TotalRequestCount
	{
		get
		{
			return m_totalRequestCount;
		}
		set
		{
			m_totalRequestCount = value;
			if (value == null)
			{
				m_totalRequestCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "UnauthorizedRequestCount", IsRequired = false, Order = 15)]
	public uint UnauthorizedRequestCount
	{
		get
		{
			return m_unauthorizedRequestCount;
		}
		set
		{
			m_unauthorizedRequestCount = value;
		}
	}

	[DataMember(Name = "ReadCount", IsRequired = false, Order = 16)]
	public ServiceCounterDataType ReadCount
	{
		get
		{
			return m_readCount;
		}
		set
		{
			m_readCount = value;
			if (value == null)
			{
				m_readCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "HistoryReadCount", IsRequired = false, Order = 17)]
	public ServiceCounterDataType HistoryReadCount
	{
		get
		{
			return m_historyReadCount;
		}
		set
		{
			m_historyReadCount = value;
			if (value == null)
			{
				m_historyReadCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "WriteCount", IsRequired = false, Order = 18)]
	public ServiceCounterDataType WriteCount
	{
		get
		{
			return m_writeCount;
		}
		set
		{
			m_writeCount = value;
			if (value == null)
			{
				m_writeCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "HistoryUpdateCount", IsRequired = false, Order = 19)]
	public ServiceCounterDataType HistoryUpdateCount
	{
		get
		{
			return m_historyUpdateCount;
		}
		set
		{
			m_historyUpdateCount = value;
			if (value == null)
			{
				m_historyUpdateCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "CallCount", IsRequired = false, Order = 20)]
	public ServiceCounterDataType CallCount
	{
		get
		{
			return m_callCount;
		}
		set
		{
			m_callCount = value;
			if (value == null)
			{
				m_callCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "CreateMonitoredItemsCount", IsRequired = false, Order = 21)]
	public ServiceCounterDataType CreateMonitoredItemsCount
	{
		get
		{
			return m_createMonitoredItemsCount;
		}
		set
		{
			m_createMonitoredItemsCount = value;
			if (value == null)
			{
				m_createMonitoredItemsCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "ModifyMonitoredItemsCount", IsRequired = false, Order = 22)]
	public ServiceCounterDataType ModifyMonitoredItemsCount
	{
		get
		{
			return m_modifyMonitoredItemsCount;
		}
		set
		{
			m_modifyMonitoredItemsCount = value;
			if (value == null)
			{
				m_modifyMonitoredItemsCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "SetMonitoringModeCount", IsRequired = false, Order = 23)]
	public ServiceCounterDataType SetMonitoringModeCount
	{
		get
		{
			return m_setMonitoringModeCount;
		}
		set
		{
			m_setMonitoringModeCount = value;
			if (value == null)
			{
				m_setMonitoringModeCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "SetTriggeringCount", IsRequired = false, Order = 24)]
	public ServiceCounterDataType SetTriggeringCount
	{
		get
		{
			return m_setTriggeringCount;
		}
		set
		{
			m_setTriggeringCount = value;
			if (value == null)
			{
				m_setTriggeringCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "DeleteMonitoredItemsCount", IsRequired = false, Order = 25)]
	public ServiceCounterDataType DeleteMonitoredItemsCount
	{
		get
		{
			return m_deleteMonitoredItemsCount;
		}
		set
		{
			m_deleteMonitoredItemsCount = value;
			if (value == null)
			{
				m_deleteMonitoredItemsCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "CreateSubscriptionCount", IsRequired = false, Order = 26)]
	public ServiceCounterDataType CreateSubscriptionCount
	{
		get
		{
			return m_createSubscriptionCount;
		}
		set
		{
			m_createSubscriptionCount = value;
			if (value == null)
			{
				m_createSubscriptionCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "ModifySubscriptionCount", IsRequired = false, Order = 27)]
	public ServiceCounterDataType ModifySubscriptionCount
	{
		get
		{
			return m_modifySubscriptionCount;
		}
		set
		{
			m_modifySubscriptionCount = value;
			if (value == null)
			{
				m_modifySubscriptionCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "SetPublishingModeCount", IsRequired = false, Order = 28)]
	public ServiceCounterDataType SetPublishingModeCount
	{
		get
		{
			return m_setPublishingModeCount;
		}
		set
		{
			m_setPublishingModeCount = value;
			if (value == null)
			{
				m_setPublishingModeCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "PublishCount", IsRequired = false, Order = 29)]
	public ServiceCounterDataType PublishCount
	{
		get
		{
			return m_publishCount;
		}
		set
		{
			m_publishCount = value;
			if (value == null)
			{
				m_publishCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "RepublishCount", IsRequired = false, Order = 30)]
	public ServiceCounterDataType RepublishCount
	{
		get
		{
			return m_republishCount;
		}
		set
		{
			m_republishCount = value;
			if (value == null)
			{
				m_republishCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "TransferSubscriptionsCount", IsRequired = false, Order = 31)]
	public ServiceCounterDataType TransferSubscriptionsCount
	{
		get
		{
			return m_transferSubscriptionsCount;
		}
		set
		{
			m_transferSubscriptionsCount = value;
			if (value == null)
			{
				m_transferSubscriptionsCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "DeleteSubscriptionsCount", IsRequired = false, Order = 32)]
	public ServiceCounterDataType DeleteSubscriptionsCount
	{
		get
		{
			return m_deleteSubscriptionsCount;
		}
		set
		{
			m_deleteSubscriptionsCount = value;
			if (value == null)
			{
				m_deleteSubscriptionsCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "AddNodesCount", IsRequired = false, Order = 33)]
	public ServiceCounterDataType AddNodesCount
	{
		get
		{
			return m_addNodesCount;
		}
		set
		{
			m_addNodesCount = value;
			if (value == null)
			{
				m_addNodesCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "AddReferencesCount", IsRequired = false, Order = 34)]
	public ServiceCounterDataType AddReferencesCount
	{
		get
		{
			return m_addReferencesCount;
		}
		set
		{
			m_addReferencesCount = value;
			if (value == null)
			{
				m_addReferencesCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "DeleteNodesCount", IsRequired = false, Order = 35)]
	public ServiceCounterDataType DeleteNodesCount
	{
		get
		{
			return m_deleteNodesCount;
		}
		set
		{
			m_deleteNodesCount = value;
			if (value == null)
			{
				m_deleteNodesCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "DeleteReferencesCount", IsRequired = false, Order = 36)]
	public ServiceCounterDataType DeleteReferencesCount
	{
		get
		{
			return m_deleteReferencesCount;
		}
		set
		{
			m_deleteReferencesCount = value;
			if (value == null)
			{
				m_deleteReferencesCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "BrowseCount", IsRequired = false, Order = 37)]
	public ServiceCounterDataType BrowseCount
	{
		get
		{
			return m_browseCount;
		}
		set
		{
			m_browseCount = value;
			if (value == null)
			{
				m_browseCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "BrowseNextCount", IsRequired = false, Order = 38)]
	public ServiceCounterDataType BrowseNextCount
	{
		get
		{
			return m_browseNextCount;
		}
		set
		{
			m_browseNextCount = value;
			if (value == null)
			{
				m_browseNextCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "TranslateBrowsePathsToNodeIdsCount", IsRequired = false, Order = 39)]
	public ServiceCounterDataType TranslateBrowsePathsToNodeIdsCount
	{
		get
		{
			return m_translateBrowsePathsToNodeIdsCount;
		}
		set
		{
			m_translateBrowsePathsToNodeIdsCount = value;
			if (value == null)
			{
				m_translateBrowsePathsToNodeIdsCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "QueryFirstCount", IsRequired = false, Order = 40)]
	public ServiceCounterDataType QueryFirstCount
	{
		get
		{
			return m_queryFirstCount;
		}
		set
		{
			m_queryFirstCount = value;
			if (value == null)
			{
				m_queryFirstCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "QueryNextCount", IsRequired = false, Order = 41)]
	public ServiceCounterDataType QueryNextCount
	{
		get
		{
			return m_queryNextCount;
		}
		set
		{
			m_queryNextCount = value;
			if (value == null)
			{
				m_queryNextCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "RegisterNodesCount", IsRequired = false, Order = 42)]
	public ServiceCounterDataType RegisterNodesCount
	{
		get
		{
			return m_registerNodesCount;
		}
		set
		{
			m_registerNodesCount = value;
			if (value == null)
			{
				m_registerNodesCount = new ServiceCounterDataType();
			}
		}
	}

	[DataMember(Name = "UnregisterNodesCount", IsRequired = false, Order = 43)]
	public ServiceCounterDataType UnregisterNodesCount
	{
		get
		{
			return m_unregisterNodesCount;
		}
		set
		{
			m_unregisterNodesCount = value;
			if (value == null)
			{
				m_unregisterNodesCount = new ServiceCounterDataType();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.SessionDiagnosticsDataType;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.SessionDiagnosticsDataType_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.SessionDiagnosticsDataType_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.SessionDiagnosticsDataType_Encoding_DefaultJson;

	public SessionDiagnosticsDataType()
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
		m_sessionId = null;
		m_sessionName = null;
		m_clientDescription = new ApplicationDescription();
		m_serverUri = null;
		m_endpointUrl = null;
		m_localeIds = new StringCollection();
		m_actualSessionTimeout = 0.0;
		m_maxResponseMessageSize = 0u;
		m_clientConnectionTime = DateTime.MinValue;
		m_clientLastContactTime = DateTime.MinValue;
		m_currentSubscriptionsCount = 0u;
		m_currentMonitoredItemsCount = 0u;
		m_currentPublishRequestsInQueue = 0u;
		m_totalRequestCount = new ServiceCounterDataType();
		m_unauthorizedRequestCount = 0u;
		m_readCount = new ServiceCounterDataType();
		m_historyReadCount = new ServiceCounterDataType();
		m_writeCount = new ServiceCounterDataType();
		m_historyUpdateCount = new ServiceCounterDataType();
		m_callCount = new ServiceCounterDataType();
		m_createMonitoredItemsCount = new ServiceCounterDataType();
		m_modifyMonitoredItemsCount = new ServiceCounterDataType();
		m_setMonitoringModeCount = new ServiceCounterDataType();
		m_setTriggeringCount = new ServiceCounterDataType();
		m_deleteMonitoredItemsCount = new ServiceCounterDataType();
		m_createSubscriptionCount = new ServiceCounterDataType();
		m_modifySubscriptionCount = new ServiceCounterDataType();
		m_setPublishingModeCount = new ServiceCounterDataType();
		m_publishCount = new ServiceCounterDataType();
		m_republishCount = new ServiceCounterDataType();
		m_transferSubscriptionsCount = new ServiceCounterDataType();
		m_deleteSubscriptionsCount = new ServiceCounterDataType();
		m_addNodesCount = new ServiceCounterDataType();
		m_addReferencesCount = new ServiceCounterDataType();
		m_deleteNodesCount = new ServiceCounterDataType();
		m_deleteReferencesCount = new ServiceCounterDataType();
		m_browseCount = new ServiceCounterDataType();
		m_browseNextCount = new ServiceCounterDataType();
		m_translateBrowsePathsToNodeIdsCount = new ServiceCounterDataType();
		m_queryFirstCount = new ServiceCounterDataType();
		m_queryNextCount = new ServiceCounterDataType();
		m_registerNodesCount = new ServiceCounterDataType();
		m_unregisterNodesCount = new ServiceCounterDataType();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteNodeId("SessionId", SessionId);
		encoder.WriteString("SessionName", SessionName);
		encoder.WriteEncodeable("ClientDescription", ClientDescription, typeof(ApplicationDescription));
		encoder.WriteString("ServerUri", ServerUri);
		encoder.WriteString("EndpointUrl", EndpointUrl);
		encoder.WriteStringArray("LocaleIds", LocaleIds);
		encoder.WriteDouble("ActualSessionTimeout", ActualSessionTimeout);
		encoder.WriteUInt32("MaxResponseMessageSize", MaxResponseMessageSize);
		encoder.WriteDateTime("ClientConnectionTime", ClientConnectionTime);
		encoder.WriteDateTime("ClientLastContactTime", ClientLastContactTime);
		encoder.WriteUInt32("CurrentSubscriptionsCount", CurrentSubscriptionsCount);
		encoder.WriteUInt32("CurrentMonitoredItemsCount", CurrentMonitoredItemsCount);
		encoder.WriteUInt32("CurrentPublishRequestsInQueue", CurrentPublishRequestsInQueue);
		encoder.WriteEncodeable("TotalRequestCount", TotalRequestCount, typeof(ServiceCounterDataType));
		encoder.WriteUInt32("UnauthorizedRequestCount", UnauthorizedRequestCount);
		encoder.WriteEncodeable("ReadCount", ReadCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("HistoryReadCount", HistoryReadCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("WriteCount", WriteCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("HistoryUpdateCount", HistoryUpdateCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("CallCount", CallCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("CreateMonitoredItemsCount", CreateMonitoredItemsCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("ModifyMonitoredItemsCount", ModifyMonitoredItemsCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("SetMonitoringModeCount", SetMonitoringModeCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("SetTriggeringCount", SetTriggeringCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("DeleteMonitoredItemsCount", DeleteMonitoredItemsCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("CreateSubscriptionCount", CreateSubscriptionCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("ModifySubscriptionCount", ModifySubscriptionCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("SetPublishingModeCount", SetPublishingModeCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("PublishCount", PublishCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("RepublishCount", RepublishCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("TransferSubscriptionsCount", TransferSubscriptionsCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("DeleteSubscriptionsCount", DeleteSubscriptionsCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("AddNodesCount", AddNodesCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("AddReferencesCount", AddReferencesCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("DeleteNodesCount", DeleteNodesCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("DeleteReferencesCount", DeleteReferencesCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("BrowseCount", BrowseCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("BrowseNextCount", BrowseNextCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("TranslateBrowsePathsToNodeIdsCount", TranslateBrowsePathsToNodeIdsCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("QueryFirstCount", QueryFirstCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("QueryNextCount", QueryNextCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("RegisterNodesCount", RegisterNodesCount, typeof(ServiceCounterDataType));
		encoder.WriteEncodeable("UnregisterNodesCount", UnregisterNodesCount, typeof(ServiceCounterDataType));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		SessionId = decoder.ReadNodeId("SessionId");
		SessionName = decoder.ReadString("SessionName");
		ClientDescription = (ApplicationDescription)decoder.ReadEncodeable("ClientDescription", typeof(ApplicationDescription));
		ServerUri = decoder.ReadString("ServerUri");
		EndpointUrl = decoder.ReadString("EndpointUrl");
		LocaleIds = decoder.ReadStringArray("LocaleIds");
		ActualSessionTimeout = decoder.ReadDouble("ActualSessionTimeout");
		MaxResponseMessageSize = decoder.ReadUInt32("MaxResponseMessageSize");
		ClientConnectionTime = decoder.ReadDateTime("ClientConnectionTime");
		ClientLastContactTime = decoder.ReadDateTime("ClientLastContactTime");
		CurrentSubscriptionsCount = decoder.ReadUInt32("CurrentSubscriptionsCount");
		CurrentMonitoredItemsCount = decoder.ReadUInt32("CurrentMonitoredItemsCount");
		CurrentPublishRequestsInQueue = decoder.ReadUInt32("CurrentPublishRequestsInQueue");
		TotalRequestCount = (ServiceCounterDataType)decoder.ReadEncodeable("TotalRequestCount", typeof(ServiceCounterDataType));
		UnauthorizedRequestCount = decoder.ReadUInt32("UnauthorizedRequestCount");
		ReadCount = (ServiceCounterDataType)decoder.ReadEncodeable("ReadCount", typeof(ServiceCounterDataType));
		HistoryReadCount = (ServiceCounterDataType)decoder.ReadEncodeable("HistoryReadCount", typeof(ServiceCounterDataType));
		WriteCount = (ServiceCounterDataType)decoder.ReadEncodeable("WriteCount", typeof(ServiceCounterDataType));
		HistoryUpdateCount = (ServiceCounterDataType)decoder.ReadEncodeable("HistoryUpdateCount", typeof(ServiceCounterDataType));
		CallCount = (ServiceCounterDataType)decoder.ReadEncodeable("CallCount", typeof(ServiceCounterDataType));
		CreateMonitoredItemsCount = (ServiceCounterDataType)decoder.ReadEncodeable("CreateMonitoredItemsCount", typeof(ServiceCounterDataType));
		ModifyMonitoredItemsCount = (ServiceCounterDataType)decoder.ReadEncodeable("ModifyMonitoredItemsCount", typeof(ServiceCounterDataType));
		SetMonitoringModeCount = (ServiceCounterDataType)decoder.ReadEncodeable("SetMonitoringModeCount", typeof(ServiceCounterDataType));
		SetTriggeringCount = (ServiceCounterDataType)decoder.ReadEncodeable("SetTriggeringCount", typeof(ServiceCounterDataType));
		DeleteMonitoredItemsCount = (ServiceCounterDataType)decoder.ReadEncodeable("DeleteMonitoredItemsCount", typeof(ServiceCounterDataType));
		CreateSubscriptionCount = (ServiceCounterDataType)decoder.ReadEncodeable("CreateSubscriptionCount", typeof(ServiceCounterDataType));
		ModifySubscriptionCount = (ServiceCounterDataType)decoder.ReadEncodeable("ModifySubscriptionCount", typeof(ServiceCounterDataType));
		SetPublishingModeCount = (ServiceCounterDataType)decoder.ReadEncodeable("SetPublishingModeCount", typeof(ServiceCounterDataType));
		PublishCount = (ServiceCounterDataType)decoder.ReadEncodeable("PublishCount", typeof(ServiceCounterDataType));
		RepublishCount = (ServiceCounterDataType)decoder.ReadEncodeable("RepublishCount", typeof(ServiceCounterDataType));
		TransferSubscriptionsCount = (ServiceCounterDataType)decoder.ReadEncodeable("TransferSubscriptionsCount", typeof(ServiceCounterDataType));
		DeleteSubscriptionsCount = (ServiceCounterDataType)decoder.ReadEncodeable("DeleteSubscriptionsCount", typeof(ServiceCounterDataType));
		AddNodesCount = (ServiceCounterDataType)decoder.ReadEncodeable("AddNodesCount", typeof(ServiceCounterDataType));
		AddReferencesCount = (ServiceCounterDataType)decoder.ReadEncodeable("AddReferencesCount", typeof(ServiceCounterDataType));
		DeleteNodesCount = (ServiceCounterDataType)decoder.ReadEncodeable("DeleteNodesCount", typeof(ServiceCounterDataType));
		DeleteReferencesCount = (ServiceCounterDataType)decoder.ReadEncodeable("DeleteReferencesCount", typeof(ServiceCounterDataType));
		BrowseCount = (ServiceCounterDataType)decoder.ReadEncodeable("BrowseCount", typeof(ServiceCounterDataType));
		BrowseNextCount = (ServiceCounterDataType)decoder.ReadEncodeable("BrowseNextCount", typeof(ServiceCounterDataType));
		TranslateBrowsePathsToNodeIdsCount = (ServiceCounterDataType)decoder.ReadEncodeable("TranslateBrowsePathsToNodeIdsCount", typeof(ServiceCounterDataType));
		QueryFirstCount = (ServiceCounterDataType)decoder.ReadEncodeable("QueryFirstCount", typeof(ServiceCounterDataType));
		QueryNextCount = (ServiceCounterDataType)decoder.ReadEncodeable("QueryNextCount", typeof(ServiceCounterDataType));
		RegisterNodesCount = (ServiceCounterDataType)decoder.ReadEncodeable("RegisterNodesCount", typeof(ServiceCounterDataType));
		UnregisterNodesCount = (ServiceCounterDataType)decoder.ReadEncodeable("UnregisterNodesCount", typeof(ServiceCounterDataType));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is SessionDiagnosticsDataType sessionDiagnosticsDataType))
		{
			return false;
		}
		if (!Utils.IsEqual(m_sessionId, sessionDiagnosticsDataType.m_sessionId))
		{
			return false;
		}
		if (!Utils.IsEqual(m_sessionName, sessionDiagnosticsDataType.m_sessionName))
		{
			return false;
		}
		if (!Utils.IsEqual(m_clientDescription, sessionDiagnosticsDataType.m_clientDescription))
		{
			return false;
		}
		if (!Utils.IsEqual(m_serverUri, sessionDiagnosticsDataType.m_serverUri))
		{
			return false;
		}
		if (!Utils.IsEqual(m_endpointUrl, sessionDiagnosticsDataType.m_endpointUrl))
		{
			return false;
		}
		if (!Utils.IsEqual(m_localeIds, sessionDiagnosticsDataType.m_localeIds))
		{
			return false;
		}
		if (!Utils.IsEqual(m_actualSessionTimeout, sessionDiagnosticsDataType.m_actualSessionTimeout))
		{
			return false;
		}
		if (!Utils.IsEqual(m_maxResponseMessageSize, sessionDiagnosticsDataType.m_maxResponseMessageSize))
		{
			return false;
		}
		if (!Utils.IsEqual(m_clientConnectionTime, sessionDiagnosticsDataType.m_clientConnectionTime))
		{
			return false;
		}
		if (!Utils.IsEqual(m_clientLastContactTime, sessionDiagnosticsDataType.m_clientLastContactTime))
		{
			return false;
		}
		if (!Utils.IsEqual(m_currentSubscriptionsCount, sessionDiagnosticsDataType.m_currentSubscriptionsCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_currentMonitoredItemsCount, sessionDiagnosticsDataType.m_currentMonitoredItemsCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_currentPublishRequestsInQueue, sessionDiagnosticsDataType.m_currentPublishRequestsInQueue))
		{
			return false;
		}
		if (!Utils.IsEqual(m_totalRequestCount, sessionDiagnosticsDataType.m_totalRequestCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_unauthorizedRequestCount, sessionDiagnosticsDataType.m_unauthorizedRequestCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_readCount, sessionDiagnosticsDataType.m_readCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_historyReadCount, sessionDiagnosticsDataType.m_historyReadCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_writeCount, sessionDiagnosticsDataType.m_writeCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_historyUpdateCount, sessionDiagnosticsDataType.m_historyUpdateCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_callCount, sessionDiagnosticsDataType.m_callCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_createMonitoredItemsCount, sessionDiagnosticsDataType.m_createMonitoredItemsCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_modifyMonitoredItemsCount, sessionDiagnosticsDataType.m_modifyMonitoredItemsCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_setMonitoringModeCount, sessionDiagnosticsDataType.m_setMonitoringModeCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_setTriggeringCount, sessionDiagnosticsDataType.m_setTriggeringCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_deleteMonitoredItemsCount, sessionDiagnosticsDataType.m_deleteMonitoredItemsCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_createSubscriptionCount, sessionDiagnosticsDataType.m_createSubscriptionCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_modifySubscriptionCount, sessionDiagnosticsDataType.m_modifySubscriptionCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_setPublishingModeCount, sessionDiagnosticsDataType.m_setPublishingModeCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_publishCount, sessionDiagnosticsDataType.m_publishCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_republishCount, sessionDiagnosticsDataType.m_republishCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_transferSubscriptionsCount, sessionDiagnosticsDataType.m_transferSubscriptionsCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_deleteSubscriptionsCount, sessionDiagnosticsDataType.m_deleteSubscriptionsCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_addNodesCount, sessionDiagnosticsDataType.m_addNodesCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_addReferencesCount, sessionDiagnosticsDataType.m_addReferencesCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_deleteNodesCount, sessionDiagnosticsDataType.m_deleteNodesCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_deleteReferencesCount, sessionDiagnosticsDataType.m_deleteReferencesCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_browseCount, sessionDiagnosticsDataType.m_browseCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_browseNextCount, sessionDiagnosticsDataType.m_browseNextCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_translateBrowsePathsToNodeIdsCount, sessionDiagnosticsDataType.m_translateBrowsePathsToNodeIdsCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_queryFirstCount, sessionDiagnosticsDataType.m_queryFirstCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_queryNextCount, sessionDiagnosticsDataType.m_queryNextCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_registerNodesCount, sessionDiagnosticsDataType.m_registerNodesCount))
		{
			return false;
		}
		if (!Utils.IsEqual(m_unregisterNodesCount, sessionDiagnosticsDataType.m_unregisterNodesCount))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (SessionDiagnosticsDataType)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		SessionDiagnosticsDataType obj = (SessionDiagnosticsDataType)base.MemberwiseClone();
		obj.m_sessionId = (NodeId)Utils.Clone(m_sessionId);
		obj.m_sessionName = (string)Utils.Clone(m_sessionName);
		obj.m_clientDescription = (ApplicationDescription)Utils.Clone(m_clientDescription);
		obj.m_serverUri = (string)Utils.Clone(m_serverUri);
		obj.m_endpointUrl = (string)Utils.Clone(m_endpointUrl);
		obj.m_localeIds = (StringCollection)Utils.Clone(m_localeIds);
		obj.m_actualSessionTimeout = (double)Utils.Clone(m_actualSessionTimeout);
		obj.m_maxResponseMessageSize = (uint)Utils.Clone(m_maxResponseMessageSize);
		obj.m_clientConnectionTime = (DateTime)Utils.Clone(m_clientConnectionTime);
		obj.m_clientLastContactTime = (DateTime)Utils.Clone(m_clientLastContactTime);
		obj.m_currentSubscriptionsCount = (uint)Utils.Clone(m_currentSubscriptionsCount);
		obj.m_currentMonitoredItemsCount = (uint)Utils.Clone(m_currentMonitoredItemsCount);
		obj.m_currentPublishRequestsInQueue = (uint)Utils.Clone(m_currentPublishRequestsInQueue);
		obj.m_totalRequestCount = (ServiceCounterDataType)Utils.Clone(m_totalRequestCount);
		obj.m_unauthorizedRequestCount = (uint)Utils.Clone(m_unauthorizedRequestCount);
		obj.m_readCount = (ServiceCounterDataType)Utils.Clone(m_readCount);
		obj.m_historyReadCount = (ServiceCounterDataType)Utils.Clone(m_historyReadCount);
		obj.m_writeCount = (ServiceCounterDataType)Utils.Clone(m_writeCount);
		obj.m_historyUpdateCount = (ServiceCounterDataType)Utils.Clone(m_historyUpdateCount);
		obj.m_callCount = (ServiceCounterDataType)Utils.Clone(m_callCount);
		obj.m_createMonitoredItemsCount = (ServiceCounterDataType)Utils.Clone(m_createMonitoredItemsCount);
		obj.m_modifyMonitoredItemsCount = (ServiceCounterDataType)Utils.Clone(m_modifyMonitoredItemsCount);
		obj.m_setMonitoringModeCount = (ServiceCounterDataType)Utils.Clone(m_setMonitoringModeCount);
		obj.m_setTriggeringCount = (ServiceCounterDataType)Utils.Clone(m_setTriggeringCount);
		obj.m_deleteMonitoredItemsCount = (ServiceCounterDataType)Utils.Clone(m_deleteMonitoredItemsCount);
		obj.m_createSubscriptionCount = (ServiceCounterDataType)Utils.Clone(m_createSubscriptionCount);
		obj.m_modifySubscriptionCount = (ServiceCounterDataType)Utils.Clone(m_modifySubscriptionCount);
		obj.m_setPublishingModeCount = (ServiceCounterDataType)Utils.Clone(m_setPublishingModeCount);
		obj.m_publishCount = (ServiceCounterDataType)Utils.Clone(m_publishCount);
		obj.m_republishCount = (ServiceCounterDataType)Utils.Clone(m_republishCount);
		obj.m_transferSubscriptionsCount = (ServiceCounterDataType)Utils.Clone(m_transferSubscriptionsCount);
		obj.m_deleteSubscriptionsCount = (ServiceCounterDataType)Utils.Clone(m_deleteSubscriptionsCount);
		obj.m_addNodesCount = (ServiceCounterDataType)Utils.Clone(m_addNodesCount);
		obj.m_addReferencesCount = (ServiceCounterDataType)Utils.Clone(m_addReferencesCount);
		obj.m_deleteNodesCount = (ServiceCounterDataType)Utils.Clone(m_deleteNodesCount);
		obj.m_deleteReferencesCount = (ServiceCounterDataType)Utils.Clone(m_deleteReferencesCount);
		obj.m_browseCount = (ServiceCounterDataType)Utils.Clone(m_browseCount);
		obj.m_browseNextCount = (ServiceCounterDataType)Utils.Clone(m_browseNextCount);
		obj.m_translateBrowsePathsToNodeIdsCount = (ServiceCounterDataType)Utils.Clone(m_translateBrowsePathsToNodeIdsCount);
		obj.m_queryFirstCount = (ServiceCounterDataType)Utils.Clone(m_queryFirstCount);
		obj.m_queryNextCount = (ServiceCounterDataType)Utils.Clone(m_queryNextCount);
		obj.m_registerNodesCount = (ServiceCounterDataType)Utils.Clone(m_registerNodesCount);
		obj.m_unregisterNodesCount = (ServiceCounterDataType)Utils.Clone(m_unregisterNodesCount);
		return obj;
	}
}
