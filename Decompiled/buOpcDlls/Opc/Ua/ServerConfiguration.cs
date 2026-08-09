using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class ServerConfiguration : ServerBaseConfiguration
{
	private UserTokenPolicyCollection m_userTokenPolicies;

	private bool m_diagnosticsEnabled;

	private int m_maxSessionCount;

	private int m_minSessionTimeout;

	private int m_maxSessionTimeout;

	private int m_maxBrowseContinuationPoints;

	private int m_maxQueryContinuationPoints;

	private int m_maxHistoryContinuationPoints;

	private int m_maxRequestAge;

	private int m_minPublishingInterval;

	private int m_maxPublishingInterval;

	private int m_publishingResolution;

	private int m_minSubscriptionLifetime;

	private int m_maxSubscriptionLifetime;

	private int m_maxMessageQueueSize;

	private int m_maxNotificationQueueSize;

	private int m_maxNotificationsPerPublish;

	private int m_minMetadataSamplingInterval;

	private SamplingRateGroupCollection m_availableSamplingRates;

	private EndpointDescription m_registrationEndpoint;

	private int m_maxRegistrationInterval;

	private string m_nodeManagerSaveFile;

	private int m_maxPublishRequestCount;

	private int m_maxSubscriptionCount;

	private int m_maxEventQueueSize;

	private StringCollection m_serverProfileArray;

	private int m_shutdownDelay;

	private StringCollection m_serverCapabilities;

	private StringCollection m_supportedPrivateKeyFormats;

	private int m_maxTrustListSize;

	private bool m_multicastDnsEnabled;

	private ReverseConnectServerConfiguration m_reverseConnect;

	private OperationLimits m_operationLimits;

	private bool m_auditingEnabled;

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 3)]
	public UserTokenPolicyCollection UserTokenPolicies
	{
		get
		{
			return m_userTokenPolicies;
		}
		set
		{
			m_userTokenPolicies = value;
			if (m_userTokenPolicies == null)
			{
				m_userTokenPolicies = new UserTokenPolicyCollection();
			}
		}
	}

	[DataMember(IsRequired = false, Order = 4)]
	public bool DiagnosticsEnabled
	{
		get
		{
			return m_diagnosticsEnabled;
		}
		set
		{
			m_diagnosticsEnabled = value;
		}
	}

	[DataMember(IsRequired = false, Order = 5)]
	public int MaxSessionCount
	{
		get
		{
			return m_maxSessionCount;
		}
		set
		{
			m_maxSessionCount = value;
		}
	}

	[DataMember(IsRequired = false, Order = 6)]
	public int MinSessionTimeout
	{
		get
		{
			return m_minSessionTimeout;
		}
		set
		{
			m_minSessionTimeout = value;
		}
	}

	[DataMember(IsRequired = false, Order = 7)]
	public int MaxSessionTimeout
	{
		get
		{
			return m_maxSessionTimeout;
		}
		set
		{
			m_maxSessionTimeout = value;
		}
	}

	[DataMember(IsRequired = false, Order = 8)]
	public int MaxBrowseContinuationPoints
	{
		get
		{
			return m_maxBrowseContinuationPoints;
		}
		set
		{
			m_maxBrowseContinuationPoints = value;
		}
	}

	[DataMember(IsRequired = false, Order = 9)]
	public int MaxQueryContinuationPoints
	{
		get
		{
			return m_maxQueryContinuationPoints;
		}
		set
		{
			m_maxQueryContinuationPoints = value;
		}
	}

	[DataMember(IsRequired = false, Order = 10)]
	public int MaxHistoryContinuationPoints
	{
		get
		{
			return m_maxHistoryContinuationPoints;
		}
		set
		{
			m_maxHistoryContinuationPoints = value;
		}
	}

	[DataMember(IsRequired = false, Order = 11)]
	public int MaxRequestAge
	{
		get
		{
			return m_maxRequestAge;
		}
		set
		{
			m_maxRequestAge = value;
		}
	}

	[DataMember(IsRequired = false, Order = 12)]
	public int MinPublishingInterval
	{
		get
		{
			return m_minPublishingInterval;
		}
		set
		{
			m_minPublishingInterval = value;
		}
	}

	[DataMember(IsRequired = false, Order = 13)]
	public int MaxPublishingInterval
	{
		get
		{
			return m_maxPublishingInterval;
		}
		set
		{
			m_maxPublishingInterval = value;
		}
	}

	[DataMember(IsRequired = false, Order = 14)]
	public int PublishingResolution
	{
		get
		{
			return m_publishingResolution;
		}
		set
		{
			m_publishingResolution = value;
		}
	}

	[DataMember(IsRequired = false, Order = 15)]
	public int MaxSubscriptionLifetime
	{
		get
		{
			return m_maxSubscriptionLifetime;
		}
		set
		{
			m_maxSubscriptionLifetime = value;
		}
	}

	[DataMember(IsRequired = false, Order = 16)]
	public int MaxMessageQueueSize
	{
		get
		{
			return m_maxMessageQueueSize;
		}
		set
		{
			m_maxMessageQueueSize = value;
		}
	}

	[DataMember(IsRequired = false, Order = 17)]
	public int MaxNotificationQueueSize
	{
		get
		{
			return m_maxNotificationQueueSize;
		}
		set
		{
			m_maxNotificationQueueSize = value;
		}
	}

	[DataMember(IsRequired = false, Order = 18)]
	public int MaxNotificationsPerPublish
	{
		get
		{
			return m_maxNotificationsPerPublish;
		}
		set
		{
			m_maxNotificationsPerPublish = value;
		}
	}

	[DataMember(IsRequired = false, Order = 19)]
	public int MinMetadataSamplingInterval
	{
		get
		{
			return m_minMetadataSamplingInterval;
		}
		set
		{
			m_minMetadataSamplingInterval = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 20)]
	public SamplingRateGroupCollection AvailableSamplingRates
	{
		get
		{
			return m_availableSamplingRates;
		}
		set
		{
			m_availableSamplingRates = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 21)]
	public EndpointDescription RegistrationEndpoint
	{
		get
		{
			return m_registrationEndpoint;
		}
		set
		{
			m_registrationEndpoint = value;
		}
	}

	[DataMember(IsRequired = false, Order = 22)]
	public int MaxRegistrationInterval
	{
		get
		{
			return m_maxRegistrationInterval;
		}
		set
		{
			m_maxRegistrationInterval = value;
		}
	}

	[DataMember(IsRequired = false, Order = 23)]
	public string NodeManagerSaveFile
	{
		get
		{
			return m_nodeManagerSaveFile;
		}
		set
		{
			m_nodeManagerSaveFile = value;
		}
	}

	[DataMember(IsRequired = false, Order = 24)]
	public int MinSubscriptionLifetime
	{
		get
		{
			return m_minSubscriptionLifetime;
		}
		set
		{
			m_minSubscriptionLifetime = value;
		}
	}

	[DataMember(IsRequired = false, Order = 25)]
	public int MaxPublishRequestCount
	{
		get
		{
			return m_maxPublishRequestCount;
		}
		set
		{
			m_maxPublishRequestCount = value;
		}
	}

	[DataMember(IsRequired = false, Order = 26)]
	public int MaxSubscriptionCount
	{
		get
		{
			return m_maxSubscriptionCount;
		}
		set
		{
			m_maxSubscriptionCount = value;
		}
	}

	[DataMember(IsRequired = false, Order = 27)]
	public int MaxEventQueueSize
	{
		get
		{
			return m_maxEventQueueSize;
		}
		set
		{
			m_maxEventQueueSize = value;
		}
	}

	[DataMember(IsRequired = false, Order = 28)]
	public StringCollection ServerProfileArray
	{
		get
		{
			return m_serverProfileArray;
		}
		set
		{
			m_serverProfileArray = value;
			if (m_serverProfileArray == null)
			{
				m_serverProfileArray = new StringCollection();
			}
		}
	}

	[DataMember(IsRequired = false, Order = 29)]
	public int ShutdownDelay
	{
		get
		{
			return m_shutdownDelay;
		}
		set
		{
			m_shutdownDelay = value;
		}
	}

	[DataMember(IsRequired = false, Order = 30)]
	public StringCollection ServerCapabilities
	{
		get
		{
			return m_serverCapabilities;
		}
		set
		{
			m_serverCapabilities = value;
			if (m_serverCapabilities == null)
			{
				m_serverCapabilities = new StringCollection();
			}
		}
	}

	[DataMember(IsRequired = false, Order = 31)]
	public StringCollection SupportedPrivateKeyFormats
	{
		get
		{
			return m_supportedPrivateKeyFormats;
		}
		set
		{
			m_supportedPrivateKeyFormats = value;
			if (m_supportedPrivateKeyFormats == null)
			{
				m_supportedPrivateKeyFormats = new StringCollection();
			}
		}
	}

	[DataMember(IsRequired = false, Order = 32)]
	public int MaxTrustListSize
	{
		get
		{
			return m_maxTrustListSize;
		}
		set
		{
			m_maxTrustListSize = value;
		}
	}

	[DataMember(IsRequired = false, Order = 33)]
	public bool MultiCastDnsEnabled
	{
		get
		{
			return m_multicastDnsEnabled;
		}
		set
		{
			m_multicastDnsEnabled = value;
		}
	}

	[DataMember(IsRequired = false, Order = 34)]
	public ReverseConnectServerConfiguration ReverseConnect
	{
		get
		{
			return m_reverseConnect;
		}
		set
		{
			m_reverseConnect = value;
		}
	}

	[DataMember(IsRequired = false, Order = 35)]
	public OperationLimits OperationLimits
	{
		get
		{
			return m_operationLimits;
		}
		set
		{
			m_operationLimits = value;
		}
	}

	[DataMember(IsRequired = false, Order = 36)]
	public bool AuditingEnabled
	{
		get
		{
			return m_auditingEnabled;
		}
		set
		{
			m_auditingEnabled = value;
		}
	}

	public ServerConfiguration()
	{
		Initialize();
	}

	private void Initialize()
	{
		m_userTokenPolicies = new UserTokenPolicyCollection();
		m_diagnosticsEnabled = false;
		m_maxSessionCount = 100;
		m_maxSessionTimeout = 3600000;
		m_minSessionTimeout = 10000;
		m_maxBrowseContinuationPoints = 10;
		m_maxQueryContinuationPoints = 10;
		m_maxHistoryContinuationPoints = 100;
		m_maxRequestAge = 600000;
		m_minPublishingInterval = 100;
		m_maxPublishingInterval = 3600000;
		m_publishingResolution = 100;
		m_minSubscriptionLifetime = 10000;
		m_maxSubscriptionLifetime = 3600000;
		m_maxMessageQueueSize = 10;
		m_maxNotificationQueueSize = 100;
		m_maxNotificationsPerPublish = 100;
		m_minMetadataSamplingInterval = 1000;
		m_availableSamplingRates = new SamplingRateGroupCollection();
		m_registrationEndpoint = null;
		m_maxRegistrationInterval = 30000;
		m_maxPublishRequestCount = 20;
		m_maxSubscriptionCount = 100;
		m_maxEventQueueSize = 10000;
		m_serverProfileArray = new string[1] { "http://opcfoundation.org/UA-Profile/Server/StandardUA2017" };
		m_shutdownDelay = 5;
		m_serverCapabilities = new string[1] { "DA" };
		m_supportedPrivateKeyFormats = new string[2] { "PFX", "PEM" };
		m_maxTrustListSize = 0;
		m_multicastDnsEnabled = false;
		m_auditingEnabled = false;
	}

	[OnDeserializing]
	public new void Initialize(StreamingContext context)
	{
		Initialize();
	}

	public override void Validate()
	{
		base.Validate();
		if (m_userTokenPolicies.Count == 0)
		{
			m_userTokenPolicies.Add(new UserTokenPolicy());
		}
	}
}
