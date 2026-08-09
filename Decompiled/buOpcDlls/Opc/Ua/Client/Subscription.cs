using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Opc.Ua.Types.Utils;

namespace Opc.Ua.Client;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class Subscription : IDisposable, ICloneable
{
	private class IncomingMessage
	{
		public uint SequenceNumber;

		public DateTime Timestamp;

		public NotificationMessage Message;

		public bool Processed;

		public bool Republished;
	}

	private string m_displayName;

	private int m_publishingInterval;

	private uint m_keepAliveCount;

	private uint m_lifetimeCount;

	private uint m_minLifetimeInterval;

	private uint m_maxNotificationsPerPublish;

	private bool m_publishingEnabled;

	private byte m_priority;

	private TimestampsToReturn m_timestampsToReturn;

	private List<MonitoredItem> m_deletedItems;

	private MonitoredItem m_defaultItem;

	private SubscriptionChangeMask m_changeMask;

	private ISession m_session;

	private object m_handle;

	private uint m_id;

	private uint m_transferId;

	private double m_currentPublishingInterval;

	private uint m_currentKeepAliveCount;

	private uint m_currentLifetimeCount;

	private bool m_currentPublishingEnabled;

	private byte m_currentPriority;

	private Timer m_publishTimer;

	private DateTime m_lastNotificationTime;

	private int m_publishLateCount;

	private object m_cache = new object();

	private LinkedList<NotificationMessage> m_messageCache;

	private IList<uint> m_availableSequenceNumbers;

	private int m_maxMessageCount;

	private bool m_republishAfterTransfer;

	private SortedDictionary<uint, MonitoredItem> m_monitoredItems;

	private bool m_disableMonitoredItemCache;

	private FastDataChangeNotificationEventHandler m_fastDataChangeCallback;

	private FastEventNotificationEventHandler m_fastEventCallback;

	private FastKeepAliveNotificationEventHandler m_fastKeepAliveCallback;

	private AsyncAutoResetEvent m_messageWorkerEvent;

	private ManualResetEvent m_messageWorkerShutdownEvent;

	private Task m_messageWorkerTask;

	private int m_outstandingMessageWorkers;

	private bool m_sequentialPublishing;

	private uint m_lastSequenceNumberProcessed;

	private bool m_resyncLastSequenceNumberProcessed;

	private LinkedList<IncomingMessage> m_incomingMessages;

	private static long s_globalSubscriptionCounter;

	[DataMember(Order = 1)]
	public string DisplayName
	{
		get
		{
			return m_displayName;
		}
		set
		{
			m_displayName = value;
		}
	}

	[DataMember(Order = 2)]
	public int PublishingInterval
	{
		get
		{
			return m_publishingInterval;
		}
		set
		{
			m_publishingInterval = value;
		}
	}

	[DataMember(Order = 3)]
	public uint KeepAliveCount
	{
		get
		{
			return m_keepAliveCount;
		}
		set
		{
			m_keepAliveCount = value;
		}
	}

	[DataMember(Order = 4)]
	public uint LifetimeCount
	{
		get
		{
			return m_lifetimeCount;
		}
		set
		{
			m_lifetimeCount = value;
		}
	}

	[DataMember(Order = 5)]
	public uint MaxNotificationsPerPublish
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

	[DataMember(Order = 6)]
	public bool PublishingEnabled
	{
		get
		{
			return m_publishingEnabled;
		}
		set
		{
			m_publishingEnabled = value;
		}
	}

	[DataMember(Order = 7)]
	public byte Priority
	{
		get
		{
			return m_priority;
		}
		set
		{
			m_priority = value;
		}
	}

	[DataMember(Order = 8)]
	public TimestampsToReturn TimestampsToReturn
	{
		get
		{
			return m_timestampsToReturn;
		}
		set
		{
			m_timestampsToReturn = value;
		}
	}

	[DataMember(Order = 9)]
	public int MaxMessageCount
	{
		get
		{
			lock (m_cache)
			{
				return m_maxMessageCount;
			}
		}
		set
		{
			lock (m_cache)
			{
				m_maxMessageCount = value;
			}
		}
	}

	[DataMember(Order = 10)]
	public MonitoredItem DefaultItem
	{
		get
		{
			return m_defaultItem;
		}
		set
		{
			m_defaultItem = value;
		}
	}

	[DataMember(Order = 12)]
	public uint MinLifetimeInterval
	{
		get
		{
			return m_minLifetimeInterval;
		}
		set
		{
			m_minLifetimeInterval = value;
		}
	}

	[DataMember(Order = 13)]
	public bool DisableMonitoredItemCache
	{
		get
		{
			return m_disableMonitoredItemCache;
		}
		set
		{
			m_disableMonitoredItemCache = value;
		}
	}

	[DataMember(Order = 14)]
	public bool SequentialPublishing
	{
		get
		{
			lock (m_cache)
			{
				return m_sequentialPublishing;
			}
		}
		set
		{
			lock (m_cache)
			{
				m_sequentialPublishing = value;
			}
		}
	}

	[DataMember(Name = "RepublishAfterTransfer", Order = 15)]
	public bool RepublishAfterTransfer
	{
		get
		{
			return m_republishAfterTransfer;
		}
		set
		{
			lock (m_cache)
			{
				m_republishAfterTransfer = value;
			}
		}
	}

	[DataMember(Name = "TransferId", Order = 16)]
	public uint TransferId
	{
		get
		{
			return m_transferId;
		}
		set
		{
			m_transferId = value;
		}
	}

	public FastDataChangeNotificationEventHandler FastDataChangeCallback
	{
		get
		{
			return m_fastDataChangeCallback;
		}
		set
		{
			m_fastDataChangeCallback = value;
		}
	}

	public FastEventNotificationEventHandler FastEventCallback
	{
		get
		{
			return m_fastEventCallback;
		}
		set
		{
			m_fastEventCallback = value;
		}
	}

	public FastKeepAliveNotificationEventHandler FastKeepAliveCallback
	{
		get
		{
			return m_fastKeepAliveCallback;
		}
		set
		{
			m_fastKeepAliveCallback = value;
		}
	}

	public IEnumerable<MonitoredItem> MonitoredItems
	{
		get
		{
			lock (m_cache)
			{
				return new List<MonitoredItem>(m_monitoredItems.Values);
			}
		}
	}

	[DataMember(Name = "MonitoredItems", Order = 11)]
	private List<MonitoredItem> SavedMonitoredItems
	{
		get
		{
			lock (m_cache)
			{
				return new List<MonitoredItem>(m_monitoredItems.Values);
			}
		}
		set
		{
			if (Created)
			{
				throw new InvalidOperationException("Cannot update a subscription that has been created on the server.");
			}
			lock (m_cache)
			{
				m_monitoredItems.Clear();
				foreach (MonitoredItem item in value)
				{
					AddItem(item);
				}
			}
		}
	}

	public bool ChangesPending
	{
		get
		{
			if (m_deletedItems.Count > 0)
			{
				return true;
			}
			foreach (MonitoredItem value in m_monitoredItems.Values)
			{
				if (Created && !value.Status.Created)
				{
					return true;
				}
				if (value.AttributesModified)
				{
					return true;
				}
			}
			return false;
		}
	}

	public uint MonitoredItemCount
	{
		get
		{
			lock (m_cache)
			{
				return (uint)m_monitoredItems.Count;
			}
		}
	}

	public ISession Session
	{
		get
		{
			return m_session;
		}
		internal set
		{
			m_session = value;
		}
	}

	public object Handle
	{
		get
		{
			return m_handle;
		}
		set
		{
			m_handle = value;
		}
	}

	public uint Id => m_id;

	public bool Created => m_id != 0;

	[DataMember(Name = "CurrentPublishInterval", Order = 20)]
	public double CurrentPublishingInterval
	{
		get
		{
			return m_currentPublishingInterval;
		}
		set
		{
			m_currentPublishingInterval = value;
		}
	}

	[DataMember(Name = "CurrentKeepAliveCount", Order = 21)]
	public uint CurrentKeepAliveCount
	{
		get
		{
			return m_currentKeepAliveCount;
		}
		set
		{
			m_currentKeepAliveCount = value;
		}
	}

	[DataMember(Name = "CurrentLifetimeCount", Order = 22)]
	public uint CurrentLifetimeCount
	{
		get
		{
			return m_currentLifetimeCount;
		}
		set
		{
			m_currentLifetimeCount = value;
		}
	}

	public bool CurrentPublishingEnabled => m_currentPublishingEnabled;

	public byte CurrentPriority => m_currentPriority;

	public DateTime PublishTime
	{
		get
		{
			lock (m_cache)
			{
				if (m_messageCache.Count > 0)
				{
					return m_messageCache.Last.Value.PublishTime;
				}
			}
			return DateTime.MinValue;
		}
	}

	public DateTime LastNotificationTime
	{
		get
		{
			lock (m_cache)
			{
				return m_lastNotificationTime;
			}
		}
	}

	public uint SequenceNumber
	{
		get
		{
			lock (m_cache)
			{
				if (m_messageCache.Count > 0)
				{
					return m_messageCache.Last.Value.SequenceNumber;
				}
			}
			return 0u;
		}
	}

	public uint NotificationCount
	{
		get
		{
			lock (m_cache)
			{
				if (m_messageCache.Count > 0)
				{
					return (uint)m_messageCache.Last.Value.NotificationData.Count;
				}
			}
			return 0u;
		}
	}

	public NotificationMessage LastNotification
	{
		get
		{
			lock (m_cache)
			{
				if (m_messageCache.Count > 0)
				{
					return m_messageCache.Last.Value;
				}
				return null;
			}
		}
	}

	public IEnumerable<NotificationMessage> Notifications
	{
		get
		{
			lock (m_cache)
			{
				return new List<NotificationMessage>(m_messageCache);
			}
		}
	}

	public IEnumerable<uint> AvailableSequenceNumbers
	{
		get
		{
			lock (m_cache)
			{
				return new List<uint>(m_availableSequenceNumbers);
			}
		}
	}

	public bool PublishingStopped
	{
		get
		{
			lock (m_cache)
			{
				int num = (int)Math.Min(m_currentPublishingInterval * (double)(m_currentKeepAliveCount + 1), 2147483147.0);
				if ((DateTime.UtcNow - m_lastNotificationTime).TotalMilliseconds > (double)(num + 500))
				{
					return true;
				}
				return false;
			}
		}
	}

	public int OutstandingMessageWorkers => m_outstandingMessageWorkers;

	public event SubscriptionStateChangedEventHandler StateChanged
	{
		add
		{
			m_StateChanged += value;
		}
		remove
		{
			m_StateChanged -= value;
		}
	}

	public event PublishStateChangedEventHandler PublishStatusChanged
	{
		add
		{
			lock (m_cache)
			{
				m_publishStatusChanged += value;
			}
		}
		remove
		{
			lock (m_cache)
			{
				m_publishStatusChanged -= value;
			}
		}
	}

	private event SubscriptionStateChangedEventHandler m_StateChanged;

	private event PublishStateChangedEventHandler m_publishStatusChanged;

	public Subscription()
	{
		Initialize();
	}

	public Subscription(Subscription template)
		: this(template, copyEventHandlers: false)
	{
	}

	public Subscription(Subscription template, bool copyEventHandlers)
	{
		Initialize();
		if (template == null)
		{
			return;
		}
		string text = template.DisplayName;
		if (string.IsNullOrEmpty(text))
		{
			text = m_displayName;
		}
		int num = text.LastIndexOf(' ');
		if (num != -1)
		{
			try
			{
				text = text.Substring(0, num);
			}
			catch
			{
			}
		}
		m_displayName = Utils.Format("{0} {1}", text, Utils.IncrementIdentifier(ref s_globalSubscriptionCounter));
		m_publishingInterval = template.m_publishingInterval;
		m_keepAliveCount = template.m_keepAliveCount;
		m_lifetimeCount = template.m_lifetimeCount;
		m_minLifetimeInterval = template.m_minLifetimeInterval;
		m_maxNotificationsPerPublish = template.m_maxNotificationsPerPublish;
		m_publishingEnabled = template.m_publishingEnabled;
		m_priority = template.m_priority;
		m_timestampsToReturn = template.m_timestampsToReturn;
		m_maxMessageCount = template.m_maxMessageCount;
		m_sequentialPublishing = template.m_sequentialPublishing;
		m_republishAfterTransfer = template.m_republishAfterTransfer;
		m_defaultItem = (MonitoredItem)template.m_defaultItem.Clone();
		m_handle = template.m_handle;
		m_disableMonitoredItemCache = template.m_disableMonitoredItemCache;
		m_transferId = template.m_transferId;
		if (copyEventHandlers)
		{
			this.m_StateChanged = template.m_StateChanged;
			this.m_publishStatusChanged = template.m_publishStatusChanged;
			m_fastDataChangeCallback = template.m_fastDataChangeCallback;
			m_fastEventCallback = template.m_fastEventCallback;
			m_fastKeepAliveCallback = template.m_fastKeepAliveCallback;
		}
		foreach (MonitoredItem monitoredItem2 in template.MonitoredItems)
		{
			MonitoredItem monitoredItem = monitoredItem2.CloneMonitoredItem(copyEventHandlers, copyClientHandle: true);
			monitoredItem.DisplayName = monitoredItem2.DisplayName;
			AddItem(monitoredItem);
		}
	}

	private void ResetPublishTimerAndWorkerState()
	{
		Utils.SilentDispose(m_publishTimer);
		m_publishTimer = null;
		m_messageWorkerShutdownEvent.Set();
		m_messageWorkerEvent.Set();
		m_messageWorkerTask = null;
	}

	[OnDeserializing]
	protected void Initialize(StreamingContext context)
	{
		m_cache = new object();
		Initialize();
	}

	private void Initialize()
	{
		m_transferId = (m_id = 0u);
		m_displayName = "Subscription";
		m_publishingInterval = 0;
		m_keepAliveCount = 0u;
		m_lifetimeCount = 0u;
		m_maxNotificationsPerPublish = 0u;
		m_publishingEnabled = false;
		m_timestampsToReturn = TimestampsToReturn.Both;
		m_maxMessageCount = 10;
		m_republishAfterTransfer = false;
		m_outstandingMessageWorkers = 0;
		m_sequentialPublishing = false;
		m_lastSequenceNumberProcessed = 0u;
		m_messageCache = new LinkedList<NotificationMessage>();
		m_monitoredItems = new SortedDictionary<uint, MonitoredItem>();
		m_deletedItems = new List<MonitoredItem>();
		m_messageWorkerEvent = new AsyncAutoResetEvent();
		m_messageWorkerShutdownEvent = new ManualResetEvent(initialState: false);
		m_resyncLastSequenceNumberProcessed = false;
		m_defaultItem = new MonitoredItem
		{
			DisplayName = "MonitoredItem",
			SamplingInterval = -1,
			MonitoringMode = MonitoringMode.Reporting,
			QueueSize = 0u,
			DiscardOldest = true
		};
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			ResetPublishTimerAndWorkerState();
		}
	}

	public virtual object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		return new Subscription(this);
	}

	public virtual Subscription CloneSubscription(bool copyEventHandlers)
	{
		return new Subscription(this, copyEventHandlers);
	}

	public void ChangesCompleted()
	{
		if (this.m_StateChanged != null)
		{
			this.m_StateChanged(this, new SubscriptionStateChangedEventArgs(m_changeMask));
		}
		m_changeMask = SubscriptionChangeMask.None;
	}

	public void Create()
	{
		VerifySubscriptionState(created: false);
		uint keepAliveCount = m_keepAliveCount;
		uint lifetimeCount = m_lifetimeCount;
		AdjustCounts(ref keepAliveCount, ref lifetimeCount);
		m_session.CreateSubscription(null, m_publishingInterval, lifetimeCount, keepAliveCount, m_maxNotificationsPerPublish, m_publishingEnabled, m_priority, out var subscriptionId, out var revisedPublishingInterval, out lifetimeCount, out keepAliveCount);
		CreateSubscription(subscriptionId, revisedPublishingInterval, keepAliveCount, lifetimeCount);
		CreateItems();
		ChangesCompleted();
		TraceState("CREATED");
	}

	public bool Transfer(ISession session, uint id, UInt32Collection availableSequenceNumbers)
	{
		if (Created)
		{
			if (id != m_id)
			{
				return false;
			}
			ISession session2 = m_session;
			if (session2 == null || !session2.RemoveTransferredSubscription(this))
			{
				Utils.LogError("SubscriptionId {0}: Failed to remove transferred subscription from owner SessionId={1}.", Id, m_session?.SessionId);
				return false;
			}
			List<Subscription> subscriptions = session.Subscriptions.Where((Subscription s) => !s.Created && s.TransferId == Id).ToList();
			session.RemoveSubscriptions(subscriptions);
			if (!session.AddSubscription(this))
			{
				Utils.LogError("SubscriptionId {0}: Failed to add transferred subscription to SessionId={1}.", Id, session.SessionId);
				return false;
			}
		}
		else
		{
			if (!GetMonitoredItems(out var serverHandles, out var clientHandles))
			{
				Utils.LogError("SubscriptionId {0}: The server failed to respond to GetMonitoredItems after transfer.", Id);
				return false;
			}
			if (serverHandles.Count != m_monitoredItems.Count || clientHandles.Count != m_monitoredItems.Count)
			{
				Utils.LogError("SubscriptionId {0}: Number of Monitored Items on client and server do not match after transfer {1}!={2}", Id, serverHandles.Count, m_monitoredItems.Count);
				return false;
			}
			m_id = id;
			TransferItems(serverHandles, clientHandles, out var _);
			ModifyItems();
		}
		ProcessTransferredSequenceNumbers(availableSequenceNumbers);
		m_changeMask |= SubscriptionChangeMask.Transferred;
		ChangesCompleted();
		StartKeepAliveTimer();
		TraceState("TRANSFERRED");
		return true;
	}

	public async Task<bool> TransferAsync(ISession session, uint id, UInt32Collection availableSequenceNumbers, CancellationToken ct = default(CancellationToken))
	{
		if (Created)
		{
			if (id != m_id)
			{
				return false;
			}
			ISession session2 = m_session;
			if (session2 == null || !session2.RemoveTransferredSubscription(this))
			{
				Utils.LogError("SubscriptionId {0}: Failed to remove transferred subscription from owner SessionId={1}.", Id, m_session?.SessionId);
				return false;
			}
			List<Subscription> subscriptions = session.Subscriptions.Where((Subscription s) => !s.Created && s.TransferId == Id).ToList();
			await session.RemoveSubscriptionsAsync(subscriptions, ct).ConfigureAwait(continueOnCapturedContext: false);
			if (!session.AddSubscription(this))
			{
				Utils.LogError("SubscriptionId {0}: Failed to add transferred subscription to SessionId={1}.", Id, session.SessionId);
				return false;
			}
		}
		else
		{
			var (flag, uInt32Collection, uInt32Collection2) = await GetMonitoredItemsAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
			if (!flag)
			{
				Utils.LogError("SubscriptionId {0}: The server failed to respond to GetMonitoredItems after transfer.", Id);
				return false;
			}
			if (uInt32Collection.Count != m_monitoredItems.Count || uInt32Collection2.Count != m_monitoredItems.Count)
			{
				Utils.LogError("SubscriptionId {0}: Number of Monitored Items on client and server do not match after transfer {1}!={2}", Id, uInt32Collection.Count, m_monitoredItems.Count);
				return false;
			}
			m_id = id;
			TransferItems(uInt32Collection, uInt32Collection2, out var _);
			await ModifyItemsAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
		}
		ProcessTransferredSequenceNumbers(availableSequenceNumbers);
		m_changeMask |= SubscriptionChangeMask.Transferred;
		ChangesCompleted();
		StartKeepAliveTimer();
		TraceState("TRANSFERRED ASYNC");
		return true;
	}

	public void Delete(bool silent)
	{
		if (!silent)
		{
			VerifySubscriptionState(created: true);
		}
		if (!Created)
		{
			return;
		}
		try
		{
			TraceState("DELETE");
			lock (m_cache)
			{
				ResetPublishTimerAndWorkerState();
			}
			UInt32Collection uInt32Collection = new uint[1] { m_id };
			StatusCodeCollection results;
			DiagnosticInfoCollection diagnosticInfos;
			ResponseHeader responseHeader = m_session.DeleteSubscriptions(null, uInt32Collection, out results, out diagnosticInfos);
			ClientBase.ValidateResponse(results, uInt32Collection);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos, uInt32Collection);
			if (StatusCode.IsBad(results[0]))
			{
				throw new ServiceResultException(ClientBase.GetResult(results[0], 0, diagnosticInfos, responseHeader));
			}
		}
		catch (Exception e)
		{
			if (!silent)
			{
				throw new ServiceResultException(e, 2147549184u);
			}
		}
		finally
		{
			DeleteSubscription();
		}
		ChangesCompleted();
	}

	public void Modify()
	{
		VerifySubscriptionState(created: true);
		uint keepAliveCount = m_keepAliveCount;
		uint lifetimeCount = m_lifetimeCount;
		AdjustCounts(ref keepAliveCount, ref lifetimeCount);
		m_session.ModifySubscription(null, m_id, m_publishingInterval, lifetimeCount, keepAliveCount, m_maxNotificationsPerPublish, m_priority, out var revisedPublishingInterval, out lifetimeCount, out keepAliveCount);
		ModifySubscription(revisedPublishingInterval, keepAliveCount, lifetimeCount);
		ChangesCompleted();
		TraceState("MODIFIED");
	}

	public void SetPublishingMode(bool enabled)
	{
		VerifySubscriptionState(created: true);
		UInt32Collection request = new uint[1] { m_id };
		StatusCodeCollection results;
		DiagnosticInfoCollection diagnosticInfos;
		ResponseHeader responseHeader = m_session.SetPublishingMode(null, enabled, new uint[1] { m_id }, out results, out diagnosticInfos);
		ClientBase.ValidateResponse(results, request);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, request);
		if (StatusCode.IsBad(results[0]))
		{
			throw new ServiceResultException(ClientBase.GetResult(results[0], 0, diagnosticInfos, responseHeader));
		}
		m_currentPublishingEnabled = (m_publishingEnabled = enabled);
		m_changeMask |= SubscriptionChangeMask.Modified;
		ChangesCompleted();
		TraceState(enabled ? "PUBLISHING ENABLED" : "PUBLISHING DISABLED");
	}

	public NotificationMessage Republish(uint sequenceNumber)
	{
		VerifySubscriptionState(created: true);
		m_session.Republish(null, m_id, sequenceNumber, out var notificationMessage);
		return notificationMessage;
	}

	public void ApplyChanges()
	{
		DeleteItems();
		ModifyItems();
		CreateItems();
	}

	public void ResolveItemNodeIds()
	{
		VerifySubscriptionState(created: true);
		BrowsePathCollection browsePathCollection = new BrowsePathCollection();
		List<MonitoredItem> list = new List<MonitoredItem>();
		PrepareResolveItemNodeIds(browsePathCollection, list);
		if (browsePathCollection.Count != 0)
		{
			BrowsePathResultCollection results;
			DiagnosticInfoCollection diagnosticInfos;
			ResponseHeader responseHeader = m_session.TranslateBrowsePathsToNodeIds(null, browsePathCollection, out results, out diagnosticInfos);
			ClientBase.ValidateResponse(results, browsePathCollection);
			ClientBase.ValidateDiagnosticInfos(diagnosticInfos, browsePathCollection);
			for (int i = 0; i < results.Count; i++)
			{
				list[i].SetResolvePathResult(results[i], i, diagnosticInfos, responseHeader);
			}
			m_changeMask |= SubscriptionChangeMask.ItemsModified;
		}
	}

	public IList<MonitoredItem> CreateItems()
	{
		List<MonitoredItem> itemsToCreate;
		MonitoredItemCreateRequestCollection monitoredItemCreateRequestCollection = PrepareItemsToCreate(out itemsToCreate);
		if (monitoredItemCreateRequestCollection.Count == 0)
		{
			return itemsToCreate;
		}
		MonitoredItemCreateResultCollection results;
		DiagnosticInfoCollection diagnosticInfos;
		ResponseHeader responseHeader = m_session.CreateMonitoredItems(null, m_id, m_timestampsToReturn, monitoredItemCreateRequestCollection, out results, out diagnosticInfos);
		ClientBase.ValidateResponse(results, itemsToCreate);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, itemsToCreate);
		for (int i = 0; i < results.Count; i++)
		{
			itemsToCreate[i].SetCreateResult(monitoredItemCreateRequestCollection[i], results[i], i, diagnosticInfos, responseHeader);
		}
		m_changeMask |= SubscriptionChangeMask.ItemsCreated;
		ChangesCompleted();
		return itemsToCreate;
	}

	public IList<MonitoredItem> ModifyItems()
	{
		VerifySubscriptionState(created: true);
		MonitoredItemModifyRequestCollection monitoredItemModifyRequestCollection = new MonitoredItemModifyRequestCollection();
		List<MonitoredItem> list = new List<MonitoredItem>();
		PrepareItemsToModify(monitoredItemModifyRequestCollection, list);
		if (monitoredItemModifyRequestCollection.Count == 0)
		{
			return list;
		}
		MonitoredItemModifyResultCollection results;
		DiagnosticInfoCollection diagnosticInfos;
		ResponseHeader responseHeader = m_session.ModifyMonitoredItems(null, m_id, m_timestampsToReturn, monitoredItemModifyRequestCollection, out results, out diagnosticInfos);
		ClientBase.ValidateResponse(results, list);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, list);
		for (int i = 0; i < results.Count; i++)
		{
			list[i].SetModifyResult(monitoredItemModifyRequestCollection[i], results[i], i, diagnosticInfos, responseHeader);
		}
		m_changeMask |= SubscriptionChangeMask.ItemsModified;
		ChangesCompleted();
		return list;
	}

	public IList<MonitoredItem> DeleteItems()
	{
		VerifySubscriptionState(created: true);
		if (m_deletedItems.Count == 0)
		{
			return new List<MonitoredItem>();
		}
		List<MonitoredItem> deletedItems = m_deletedItems;
		m_deletedItems = new List<MonitoredItem>();
		UInt32Collection uInt32Collection = new UInt32Collection();
		foreach (MonitoredItem item in deletedItems)
		{
			uInt32Collection.Add(item.Status.Id);
		}
		StatusCodeCollection results;
		DiagnosticInfoCollection diagnosticInfos;
		ResponseHeader responseHeader = m_session.DeleteMonitoredItems(null, m_id, uInt32Collection, out results, out diagnosticInfos);
		ClientBase.ValidateResponse(results, uInt32Collection);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, uInt32Collection);
		for (int i = 0; i < results.Count; i++)
		{
			deletedItems[i].SetDeleteResult(results[i], i, diagnosticInfos, responseHeader);
		}
		m_changeMask |= SubscriptionChangeMask.ItemsDeleted;
		ChangesCompleted();
		return deletedItems;
	}

	public List<ServiceResult> SetMonitoringMode(MonitoringMode monitoringMode, IList<MonitoredItem> monitoredItems)
	{
		if (monitoredItems == null)
		{
			throw new ArgumentNullException("monitoredItems");
		}
		VerifySubscriptionState(created: true);
		if (monitoredItems.Count == 0)
		{
			return null;
		}
		UInt32Collection uInt32Collection = new UInt32Collection();
		foreach (MonitoredItem monitoredItem in monitoredItems)
		{
			uInt32Collection.Add(monitoredItem.Status.Id);
		}
		StatusCodeCollection results;
		DiagnosticInfoCollection diagnosticInfos;
		ResponseHeader responseHeader = m_session.SetMonitoringMode(null, m_id, monitoringMode, uInt32Collection, out results, out diagnosticInfos);
		ClientBase.ValidateResponse(results, uInt32Collection);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, uInt32Collection);
		List<ServiceResult> list = new List<ServiceResult>();
		bool num = UpdateMonitoringMode(monitoredItems, list, results, diagnosticInfos, responseHeader, monitoringMode);
		m_changeMask |= SubscriptionChangeMask.ItemsModified;
		ChangesCompleted();
		if (num)
		{
			return null;
		}
		return list;
	}

	public void SaveMessageInCache(IList<uint> availableSequenceNumbers, NotificationMessage message, IList<string> stringTable)
	{
		PublishStateChangedEventHandler publishStateChangedEventHandler = null;
		lock (m_cache)
		{
			if (availableSequenceNumbers != null)
			{
				m_availableSequenceNumbers = availableSequenceNumbers;
			}
			if (message == null)
			{
				return;
			}
			if (PublishingStopped)
			{
				publishStateChangedEventHandler = this.m_publishStatusChanged;
				TraceState("PUBLISHING RECOVERED");
			}
			DateTime dateTime = (m_lastNotificationTime = DateTime.UtcNow);
			message.StringTable = new List<string>(stringTable);
			if (m_incomingMessages == null)
			{
				m_incomingMessages = new LinkedList<IncomingMessage>();
			}
			IncomingMessage incomingMessage = FindOrCreateEntry(dateTime, message.SequenceNumber);
			if (message.NotificationData.Count > 0)
			{
				incomingMessage.Message = message;
				incomingMessage.Processed = false;
			}
			LinkedListNode<IncomingMessage> linkedListNode = m_incomingMessages.First;
			while (linkedListNode != null)
			{
				incomingMessage = linkedListNode.Value;
				LinkedListNode<IncomingMessage> next = linkedListNode.Next;
				if (next != null && next.Value.SequenceNumber > incomingMessage.SequenceNumber + 1)
				{
					IncomingMessage incomingMessage2 = new IncomingMessage();
					incomingMessage2.SequenceNumber = incomingMessage.SequenceNumber + 1;
					incomingMessage2.Timestamp = dateTime;
					linkedListNode = m_incomingMessages.AddAfter(linkedListNode, incomingMessage2);
				}
				else
				{
					linkedListNode = next;
				}
			}
			linkedListNode = m_incomingMessages.First;
			while (linkedListNode != null)
			{
				incomingMessage = linkedListNode.Value;
				LinkedListNode<IncomingMessage> next2 = linkedListNode.Next;
				if (!incomingMessage.Processed && (!incomingMessage.Republished || !(incomingMessage.Timestamp.AddSeconds(10.0) < dateTime)))
				{
					break;
				}
				if (next2 != null)
				{
					if (incomingMessage.SequenceNumber == m_lastSequenceNumberProcessed + 1)
					{
						if (!incomingMessage.Processed)
						{
							Utils.LogWarning("SubscriptionId {0} skipping PublishResponse Sequence Number {1}", Id, incomingMessage.SequenceNumber);
						}
						m_lastSequenceNumberProcessed = incomingMessage.SequenceNumber;
					}
					m_incomingMessages.Remove(linkedListNode);
				}
				linkedListNode = next2;
			}
			m_messageWorkerEvent.Set();
		}
		if (publishStateChangedEventHandler != null)
		{
			try
			{
				publishStateChangedEventHandler(this, new PublishStateChangedEventArgs(PublishStateChangedMask.Recovered));
			}
			catch (Exception exception)
			{
				Utils.LogError(exception, "Error while raising PublishStateChanged event.");
			}
		}
	}

	public void AddItem(MonitoredItem monitoredItem)
	{
		if (monitoredItem == null)
		{
			throw new ArgumentNullException("monitoredItem");
		}
		lock (m_cache)
		{
			if (m_monitoredItems.ContainsKey(monitoredItem.ClientHandle))
			{
				return;
			}
			m_monitoredItems.Add(monitoredItem.ClientHandle, monitoredItem);
			monitoredItem.Subscription = this;
		}
		m_changeMask |= SubscriptionChangeMask.ItemsAdded;
		ChangesCompleted();
	}

	public void AddItems(IEnumerable<MonitoredItem> monitoredItems)
	{
		if (monitoredItems == null)
		{
			throw new ArgumentNullException("monitoredItems");
		}
		bool flag = false;
		lock (m_cache)
		{
			foreach (MonitoredItem monitoredItem in monitoredItems)
			{
				if (!m_monitoredItems.ContainsKey(monitoredItem.ClientHandle))
				{
					m_monitoredItems.Add(monitoredItem.ClientHandle, monitoredItem);
					monitoredItem.Subscription = this;
					flag = true;
				}
			}
		}
		if (flag)
		{
			m_changeMask |= SubscriptionChangeMask.ItemsAdded;
			ChangesCompleted();
		}
	}

	public void RemoveItem(MonitoredItem monitoredItem)
	{
		if (monitoredItem == null)
		{
			throw new ArgumentNullException("monitoredItem");
		}
		lock (m_cache)
		{
			if (!m_monitoredItems.Remove(monitoredItem.ClientHandle))
			{
				return;
			}
			monitoredItem.Subscription = null;
		}
		if (monitoredItem.Status.Created)
		{
			m_deletedItems.Add(monitoredItem);
		}
		m_changeMask |= SubscriptionChangeMask.ItemsRemoved;
		ChangesCompleted();
	}

	public void RemoveItems(IEnumerable<MonitoredItem> monitoredItems)
	{
		if (monitoredItems == null)
		{
			throw new ArgumentNullException("monitoredItems");
		}
		bool flag = false;
		lock (m_cache)
		{
			foreach (MonitoredItem monitoredItem in monitoredItems)
			{
				if (m_monitoredItems.Remove(monitoredItem.ClientHandle))
				{
					monitoredItem.Subscription = null;
					if (monitoredItem.Status.Created)
					{
						m_deletedItems.Add(monitoredItem);
					}
					flag = true;
				}
			}
		}
		if (flag)
		{
			m_changeMask |= SubscriptionChangeMask.ItemsRemoved;
			ChangesCompleted();
		}
	}

	public MonitoredItem FindItemByClientHandle(uint clientHandle)
	{
		lock (m_cache)
		{
			MonitoredItem value = null;
			if (m_monitoredItems.TryGetValue(clientHandle, out value))
			{
				return value;
			}
			return null;
		}
	}

	public bool ConditionRefresh()
	{
		VerifySubscriptionState(created: true);
		try
		{
			m_session.Call(ObjectTypeIds.ConditionType, MethodIds.ConditionType_ConditionRefresh, m_id);
			return true;
		}
		catch (ServiceResultException exception)
		{
			Utils.LogError(exception, "SubscriptionId {0}: Failed to call ConditionRefresh on server", m_id);
		}
		return false;
	}

	public bool ResendData()
	{
		VerifySubscriptionState(created: true);
		try
		{
			m_session.Call(ObjectIds.Server, MethodIds.Server_ResendData, m_id);
			return true;
		}
		catch (ServiceResultException exception)
		{
			Utils.LogError(exception, "SubscriptionId {0}: Failed to call ResendData on server", m_id);
		}
		return false;
	}

	private void ProcessTransferredSequenceNumbers(UInt32Collection availableSequenceNumbers)
	{
		lock (m_cache)
		{
			m_lastSequenceNumberProcessed = 0u;
			m_resyncLastSequenceNumberProcessed = true;
			m_incomingMessages = new LinkedList<IncomingMessage>();
			m_availableSequenceNumbers = (UInt32Collection)availableSequenceNumbers.MemberwiseClone();
			if (availableSequenceNumbers.Count == 0 || !m_republishAfterTransfer)
			{
				return;
			}
			if (m_incomingMessages == null)
			{
				m_incomingMessages = new LinkedList<IncomingMessage>();
			}
			foreach (uint availableSequenceNumber in availableSequenceNumbers)
			{
				if (availableSequenceNumber >= m_lastSequenceNumberProcessed)
				{
					m_lastSequenceNumberProcessed = availableSequenceNumber + 1;
				}
			}
			Utils.LogInfo("SubscriptionId {0}: Republishing {1} messages, next sequencenumber {2} after transfer.", m_id, availableSequenceNumbers.Count, m_lastSequenceNumberProcessed);
			DateTime utcNow = DateTime.UtcNow.AddSeconds(-5.0);
			foreach (uint availableSequenceNumber2 in availableSequenceNumbers)
			{
				FindOrCreateEntry(utcNow, availableSequenceNumber2);
			}
			availableSequenceNumbers.Clear();
		}
	}

	private bool GetMonitoredItems(out UInt32Collection serverHandles, out UInt32Collection clientHandles)
	{
		serverHandles = new UInt32Collection();
		clientHandles = new UInt32Collection();
		try
		{
			IList<object> list = m_session.Call(ObjectIds.Server, MethodIds.Server_GetMonitoredItems, m_transferId);
			if (list != null && list.Count == 2)
			{
				serverHandles.AddRange((uint[])list[0]);
				clientHandles.AddRange((uint[])list[1]);
				return true;
			}
		}
		catch (ServiceResultException exception)
		{
			Utils.LogError(exception, "SubscriptionId {0}: Failed to call GetMonitoredItems on server", m_id);
		}
		return false;
	}

	private async Task<(bool, UInt32Collection, UInt32Collection)> GetMonitoredItemsAsync(CancellationToken ct = default(CancellationToken))
	{
		UInt32Collection serverHandles = new UInt32Collection();
		UInt32Collection clientHandles = new UInt32Collection();
		try
		{
			IList<object> list = await m_session.CallAsync(ObjectIds.Server, MethodIds.Server_GetMonitoredItems, ct, m_transferId).ConfigureAwait(continueOnCapturedContext: false);
			if (list != null && list.Count == 2)
			{
				serverHandles.AddRange((uint[])list[0]);
				clientHandles.AddRange((uint[])list[1]);
				return (true, serverHandles, clientHandles);
			}
		}
		catch (ServiceResultException exception)
		{
			Utils.LogError(exception, "SubscriptionId {0}: Failed to call GetMonitoredItems on server", m_id);
		}
		return (false, serverHandles, clientHandles);
	}

	private void StartKeepAliveTimer()
	{
		int num;
		lock (m_cache)
		{
			Utils.SilentDispose(m_publishTimer);
			m_publishTimer = null;
			m_lastNotificationTime = DateTime.UtcNow;
			num = (int)Math.Min(m_currentPublishingInterval * (double)m_currentKeepAliveCount, 2147483647.0);
			m_publishTimer = new Timer(OnKeepAlive, num, num, num);
			if (m_messageWorkerTask == null || m_messageWorkerTask.IsCompleted)
			{
				m_messageWorkerShutdownEvent.Reset();
				m_messageWorkerTask = Task.Run(() => PublishResponseMessageWorkerAsync());
			}
		}
		m_session.BeginPublish(Math.Min(num, 715827882) * 3);
	}

	private void OnKeepAlive(object state)
	{
		PublishStateChangedEventHandler publishStateChangedEventHandler = null;
		lock (m_cache)
		{
			if (!PublishingStopped)
			{
				return;
			}
			publishStateChangedEventHandler = this.m_publishStatusChanged;
			m_publishLateCount++;
		}
		TraceState("PUBLISHING STOPPED");
		if (publishStateChangedEventHandler != null)
		{
			try
			{
				publishStateChangedEventHandler(this, new PublishStateChangedEventArgs(PublishStateChangedMask.Stopped));
			}
			catch (Exception exception)
			{
				Utils.LogError(exception, "Error while raising PublishStateChanged event.");
			}
		}
		int val = (int)Math.Min(m_currentPublishingInterval * (double)m_currentKeepAliveCount, 2147483647.0);
		m_session?.BeginPublish(Math.Min(val, 715827882) * 3);
	}

	private async Task PublishResponseMessageWorkerAsync()
	{
		_ = 1;
		try
		{
			Utils.LogTrace("SubscriptionId {0} - Publish Thread {1:X8} Started.", m_id, Environment.CurrentManagedThreadId);
			while (true)
			{
				await m_messageWorkerEvent.WaitAsync().ConfigureAwait(continueOnCapturedContext: false);
				if (m_messageWorkerShutdownEvent.WaitOne(0))
				{
					break;
				}
				await OnMessageReceivedAsync(CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false);
			}
			Utils.LogTrace("SubscriptionId {0} - Publish Thread {1:X8} Exited Normally.", m_id, Environment.CurrentManagedThreadId);
		}
		catch (Exception exception)
		{
			Utils.LogError(exception, "SubscriptionId {0} - Publish Worker Thread {1:X8} Exited Unexpectedly.", m_id, Environment.CurrentManagedThreadId);
		}
	}

	internal void TraceState(string context)
	{
		CoreClientUtils.EventLog.SubscriptionState(context, m_id, m_lastNotificationTime, m_session?.GoodPublishRequestCount ?? 0, m_currentPublishingInterval, m_currentKeepAliveCount, m_currentPublishingEnabled, MonitoredItemCount);
	}

	private void ModifySubscription(double revisedPublishingInterval, uint revisedKeepAliveCount, uint revisedLifetimeCounter)
	{
		CreateOrModifySubscription(created: false, 0u, revisedPublishingInterval, revisedKeepAliveCount, revisedLifetimeCounter);
	}

	private void CreateSubscription(uint subscriptionId, double revisedPublishingInterval, uint revisedKeepAliveCount, uint revisedLifetimeCounter)
	{
		CreateOrModifySubscription(created: true, subscriptionId, revisedPublishingInterval, revisedKeepAliveCount, revisedLifetimeCounter);
	}

	private void CreateOrModifySubscription(bool created, uint subscriptionId, double revisedPublishingInterval, uint revisedKeepAliveCount, uint revisedLifetimeCounter)
	{
		m_currentPublishingInterval = revisedPublishingInterval;
		m_currentKeepAliveCount = revisedKeepAliveCount;
		m_currentLifetimeCount = revisedLifetimeCounter;
		m_currentPriority = m_priority;
		if (!created)
		{
			m_changeMask |= SubscriptionChangeMask.Modified;
		}
		else
		{
			m_currentPublishingEnabled = m_publishingEnabled;
			m_transferId = (m_id = subscriptionId);
			StartKeepAliveTimer();
			m_changeMask |= SubscriptionChangeMask.Created;
		}
		if (m_keepAliveCount != revisedKeepAliveCount)
		{
			Utils.LogInfo("For subscription {0}, Keep alive count was revised from {1} to {2}", Id, m_keepAliveCount, revisedKeepAliveCount);
		}
		if (m_lifetimeCount != revisedLifetimeCounter)
		{
			Utils.LogInfo("For subscription {0}, Lifetime count was revised from {1} to {2}", Id, m_lifetimeCount, revisedLifetimeCounter);
		}
		if ((double)m_publishingInterval != revisedPublishingInterval)
		{
			Utils.LogInfo("For subscription {0}, Publishing interval was revised from {1} to {2}", Id, m_publishingInterval, revisedPublishingInterval);
		}
		if (revisedLifetimeCounter < revisedKeepAliveCount * 3)
		{
			Utils.LogInfo("For subscription {0}, Revised lifetime counter (value={1}) is less than three times the keep alive count (value={2})", Id, revisedLifetimeCounter, revisedKeepAliveCount);
		}
		if (m_currentPriority == 0)
		{
			Utils.LogInfo("For subscription {0}, the priority was set to 0.", Id);
		}
	}

	private void DeleteSubscription()
	{
		m_transferId = (m_id = 0u);
		m_currentPublishingInterval = 0.0;
		m_currentKeepAliveCount = 0u;
		m_currentPublishingEnabled = false;
		m_currentPriority = 0;
		lock (m_cache)
		{
			foreach (MonitoredItem value in m_monitoredItems.Values)
			{
				value.SetDeleteResult(0u, -1, null, null);
			}
		}
		m_deletedItems.Clear();
		m_changeMask |= SubscriptionChangeMask.Deleted;
	}

	private void AdjustCounts(ref uint keepAliveCount, ref uint lifetimeCount)
	{
		if (keepAliveCount == 0)
		{
			Utils.LogInfo("Adjusted KeepAliveCount from value={0}, to value={1}, for subscription {2}.", keepAliveCount, 10u, Id);
			keepAliveCount = 10u;
		}
		if (m_publishingInterval > 0)
		{
			if (m_minLifetimeInterval != 0 && (double)m_minLifetimeInterval < m_session.SessionTimeout)
			{
				Utils.LogWarning("A smaller minLifetimeInterval {0}ms than session timeout {1}ms configured for subscription {2}.", m_minLifetimeInterval, m_session.SessionTimeout, Id);
			}
			uint num = (uint)(m_minLifetimeInterval / m_publishingInterval);
			if (lifetimeCount < num)
			{
				lifetimeCount = num;
				if (m_minLifetimeInterval % m_publishingInterval != 0L)
				{
					lifetimeCount++;
				}
				Utils.LogInfo("Adjusted LifetimeCount to value={0}, for subscription {1}. ", lifetimeCount, Id);
			}
			if ((double)(lifetimeCount * m_publishingInterval) < m_session.SessionTimeout)
			{
				Utils.LogWarning("Lifetime {0}ms configured for subscription {1} is less than session timeout {2}ms.", lifetimeCount * m_publishingInterval, Id, m_session.SessionTimeout);
			}
		}
		else if (lifetimeCount == 0)
		{
			Utils.LogInfo("Adjusted LifetimeCount from value={0}, to value={1}, for subscription {2}. ", lifetimeCount, 1000u, Id);
			lifetimeCount = 1000u;
		}
		uint num2 = 3 * keepAliveCount;
		if (lifetimeCount < num2)
		{
			Utils.LogInfo("Adjusted LifetimeCount from value={0}, to value={1}, for subscription {2}. ", lifetimeCount, num2, Id);
			lifetimeCount = num2;
		}
	}

	private async Task OnMessageReceivedAsync(CancellationToken ct)
	{
		try
		{
			Interlocked.Increment(ref m_outstandingMessageWorkers);
			ISession session = null;
			uint subscriptionId = 0u;
			PublishStateChangedEventHandler publishStateChangedEventHandler = null;
			List<NotificationMessage> list = null;
			List<IncomingMessage> list2 = null;
			List<IncomingMessage> messagesToRepublish = null;
			PublishStateChangedMask publishStateChangedMask = PublishStateChangedMask.None;
			lock (m_cache)
			{
				for (LinkedListNode<IncomingMessage> linkedListNode = m_incomingMessages.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
				{
					if (linkedListNode.Value.Message != null && !linkedListNode.Value.Processed && (!m_sequentialPublishing || ValidSequentialPublishMessage(linkedListNode.Value)))
					{
						if (list == null)
						{
							list = new List<NotificationMessage>();
						}
						list.Add(linkedListNode.Value.Message);
						while (m_messageCache.Count > m_maxMessageCount)
						{
							m_messageCache.RemoveFirst();
						}
						m_messageCache.AddLast(linkedListNode.Value.Message);
						linkedListNode.Value.Processed = true;
						if (linkedListNode.Value.SequenceNumber > m_lastSequenceNumberProcessed || (linkedListNode.Value.SequenceNumber == 1 && m_lastSequenceNumberProcessed == uint.MaxValue))
						{
							m_lastSequenceNumberProcessed = linkedListNode.Value.SequenceNumber;
							if (m_resyncLastSequenceNumberProcessed)
							{
								Utils.LogInfo("SubscriptionId {0}: Resynced last sequence number processed to {1}.", Id, m_lastSequenceNumberProcessed);
								m_resyncLastSequenceNumberProcessed = false;
							}
						}
					}
					else if (linkedListNode.Next == null && linkedListNode.Value.Message == null && !linkedListNode.Value.Processed)
					{
						if (list2 == null)
						{
							list2 = new List<IncomingMessage>();
						}
						list2.Add(linkedListNode.Value);
						publishStateChangedMask |= PublishStateChangedMask.KeepAlive;
					}
					else if (linkedListNode.Next != null && linkedListNode.Value.Message == null && !linkedListNode.Value.Processed && !linkedListNode.Value.Republished && linkedListNode.Value.Timestamp.AddSeconds(2.0) < DateTime.UtcNow)
					{
						if (messagesToRepublish == null)
						{
							messagesToRepublish = new List<IncomingMessage>();
						}
						messagesToRepublish.Add(linkedListNode.Value);
						linkedListNode.Value.Republished = true;
						publishStateChangedMask |= PublishStateChangedMask.Republish;
					}
				}
				session = m_session;
				subscriptionId = m_id;
				publishStateChangedEventHandler = this.m_publishStatusChanged;
			}
			FastKeepAliveNotificationEventHandler fastKeepAliveCallback = m_fastKeepAliveCallback;
			if (list2 != null && fastKeepAliveCallback != null)
			{
				foreach (IncomingMessage item in list2)
				{
					NotificationData notification = new NotificationData
					{
						PublishTime = item.Timestamp,
						SequenceNumber = item.SequenceNumber
					};
					fastKeepAliveCallback(this, notification);
				}
			}
			if (list != null)
			{
				FastDataChangeNotificationEventHandler fastDataChangeCallback = m_fastDataChangeCallback;
				FastEventNotificationEventHandler fastEventCallback = m_fastEventCallback;
				foreach (NotificationMessage item2 in list)
				{
					int num = 0;
					try
					{
						foreach (ExtensionObject notificationDatum in item2.NotificationData)
						{
							if (notificationDatum.Body is DataChangeNotification dataChangeNotification)
							{
								dataChangeNotification.PublishTime = item2.PublishTime;
								dataChangeNotification.SequenceNumber = item2.SequenceNumber;
								num += dataChangeNotification.MonitoredItems.Count;
								if (!m_disableMonitoredItemCache)
								{
									SaveDataChange(item2, dataChangeNotification, item2.StringTable);
								}
								fastDataChangeCallback?.Invoke(this, dataChangeNotification, item2.StringTable);
							}
							if (notificationDatum.Body is EventNotificationList eventNotificationList)
							{
								eventNotificationList.PublishTime = item2.PublishTime;
								eventNotificationList.SequenceNumber = item2.SequenceNumber;
								num += eventNotificationList.Events.Count;
								if (!m_disableMonitoredItemCache)
								{
									SaveEvents(item2, eventNotificationList, item2.StringTable);
								}
								fastEventCallback?.Invoke(this, eventNotificationList, item2.StringTable);
							}
							if (notificationDatum.Body is StatusChangeNotification statusChangeNotification)
							{
								statusChangeNotification.PublishTime = item2.PublishTime;
								statusChangeNotification.SequenceNumber = item2.SequenceNumber;
								Utils.LogWarning("StatusChangeNotification received with Status = {0} for SubscriptionId={1}.", statusChangeNotification.Status.ToString(), Id);
								if (statusChangeNotification.Status == 2949120u)
								{
									publishStateChangedMask |= PublishStateChangedMask.Transferred;
									ResetPublishTimerAndWorkerState();
								}
								else if (statusChangeNotification.Status == 2148139008u)
								{
									publishStateChangedMask |= PublishStateChangedMask.Timeout;
								}
							}
						}
					}
					catch (Exception exception)
					{
						Utils.LogError(exception, "Error while processing incoming message #{0}.", item2.SequenceNumber);
					}
					if (MaxNotificationsPerPublish != 0 && num > MaxNotificationsPerPublish)
					{
						Utils.LogWarning("For subscription {0}, more notifications were received={1} than the max notifications per publish value={2}", Id, num, MaxNotificationsPerPublish);
					}
				}
				if (publishStateChangedEventHandler != null && publishStateChangedMask != PublishStateChangedMask.None)
				{
					try
					{
						publishStateChangedEventHandler(this, new PublishStateChangedEventArgs(publishStateChangedMask));
					}
					catch (Exception exception2)
					{
						Utils.LogError(exception2, "Error while raising PublishStateChanged event.");
					}
				}
			}
			if (messagesToRepublish == null || session == null || subscriptionId == 0)
			{
				return;
			}
			for (int ii = 0; ii < messagesToRepublish.Count; ii++)
			{
				if (!(await session.RepublishAsync(subscriptionId, messagesToRepublish[ii].SequenceNumber, ct).ConfigureAwait(continueOnCapturedContext: false)))
				{
					messagesToRepublish[ii].Republished = false;
				}
			}
		}
		catch (Exception exception3)
		{
			Utils.LogError(exception3, "Error while processing incoming messages.");
		}
		finally
		{
			Interlocked.Decrement(ref m_outstandingMessageWorkers);
		}
	}

	private void VerifySubscriptionState(bool created)
	{
		if (created && m_id == 0)
		{
			throw new ServiceResultException(2158952448u, "Subscription has not been created.");
		}
		if (!created && m_id != 0)
		{
			throw new ServiceResultException(2158952448u, "Subscription has alredy been created.");
		}
	}

	private bool ValidSequentialPublishMessage(IncomingMessage message)
	{
		if (message.SequenceNumber > m_lastSequenceNumberProcessed + 1 && !m_resyncLastSequenceNumberProcessed)
		{
			if (message.SequenceNumber == 1)
			{
				return m_lastSequenceNumberProcessed == uint.MaxValue;
			}
			return false;
		}
		return true;
	}

	private bool UpdateMonitoringMode(IList<MonitoredItem> monitoredItems, IList<ServiceResult> errors, StatusCodeCollection results, DiagnosticInfoCollection diagnosticInfos, ResponseHeader responseHeader, MonitoringMode monitoringMode)
	{
		bool result = true;
		for (int i = 0; i < results.Count; i++)
		{
			ServiceResult item = null;
			if (StatusCode.IsBad(results[i]))
			{
				item = ClientBase.GetResult(results[i], i, diagnosticInfos, responseHeader);
				result = false;
			}
			else
			{
				monitoredItems[i].MonitoringMode = monitoringMode;
				monitoredItems[i].Status.SetMonitoringMode(monitoringMode);
			}
			errors.Add(item);
		}
		return result;
	}

	private MonitoredItemCreateRequestCollection PrepareItemsToCreate(out List<MonitoredItem> itemsToCreate)
	{
		VerifySubscriptionState(created: true);
		ResolveItemNodeIds();
		MonitoredItemCreateRequestCollection monitoredItemCreateRequestCollection = new MonitoredItemCreateRequestCollection();
		itemsToCreate = new List<MonitoredItem>();
		lock (m_cache)
		{
			foreach (MonitoredItem value in m_monitoredItems.Values)
			{
				if (!value.Status.Created)
				{
					MonitoredItemCreateRequest monitoredItemCreateRequest = new MonitoredItemCreateRequest();
					monitoredItemCreateRequest.ItemToMonitor.NodeId = value.ResolvedNodeId;
					monitoredItemCreateRequest.ItemToMonitor.AttributeId = value.AttributeId;
					monitoredItemCreateRequest.ItemToMonitor.IndexRange = value.IndexRange;
					monitoredItemCreateRequest.ItemToMonitor.DataEncoding = value.Encoding;
					monitoredItemCreateRequest.MonitoringMode = value.MonitoringMode;
					monitoredItemCreateRequest.RequestedParameters.ClientHandle = value.ClientHandle;
					monitoredItemCreateRequest.RequestedParameters.SamplingInterval = value.SamplingInterval;
					monitoredItemCreateRequest.RequestedParameters.QueueSize = value.QueueSize;
					monitoredItemCreateRequest.RequestedParameters.DiscardOldest = value.DiscardOldest;
					if (value.Filter != null)
					{
						monitoredItemCreateRequest.RequestedParameters.Filter = new ExtensionObject(value.Filter);
					}
					monitoredItemCreateRequestCollection.Add(monitoredItemCreateRequest);
					itemsToCreate.Add(value);
				}
			}
			return monitoredItemCreateRequestCollection;
		}
	}

	private void PrepareItemsToModify(MonitoredItemModifyRequestCollection requestItems, IList<MonitoredItem> itemsToModify)
	{
		lock (m_cache)
		{
			foreach (MonitoredItem value in m_monitoredItems.Values)
			{
				if (value.Status.Created && value.AttributesModified)
				{
					MonitoredItemModifyRequest monitoredItemModifyRequest = new MonitoredItemModifyRequest();
					monitoredItemModifyRequest.MonitoredItemId = value.Status.Id;
					monitoredItemModifyRequest.RequestedParameters.ClientHandle = value.ClientHandle;
					monitoredItemModifyRequest.RequestedParameters.SamplingInterval = value.SamplingInterval;
					monitoredItemModifyRequest.RequestedParameters.QueueSize = value.QueueSize;
					monitoredItemModifyRequest.RequestedParameters.DiscardOldest = value.DiscardOldest;
					if (value.Filter != null)
					{
						monitoredItemModifyRequest.RequestedParameters.Filter = new ExtensionObject(value.Filter);
					}
					requestItems.Add(monitoredItemModifyRequest);
					itemsToModify.Add(value);
				}
			}
		}
	}

	private void TransferItems(UInt32Collection serverHandles, UInt32Collection clientHandles, out IList<MonitoredItem> itemsToModify)
	{
		lock (m_cache)
		{
			itemsToModify = new List<MonitoredItem>();
			SortedDictionary<uint, MonitoredItem> sortedDictionary = new SortedDictionary<uint, MonitoredItem>();
			foreach (MonitoredItem monitoredItem in m_monitoredItems.Values)
			{
				int num = serverHandles.FindIndex((uint handle) => handle == monitoredItem.Status.Id);
				if (num >= 0 && num < clientHandles.Count)
				{
					uint num2 = clientHandles[num];
					sortedDictionary[num2] = monitoredItem;
					monitoredItem.SetTransferResult(num2);
				}
				else
				{
					sortedDictionary[monitoredItem.ClientHandle] = monitoredItem;
					itemsToModify.Add(monitoredItem);
				}
			}
			m_monitoredItems = sortedDictionary;
		}
	}

	private void PrepareResolveItemNodeIds(BrowsePathCollection browsePaths, IList<MonitoredItem> itemsToBrowse)
	{
		lock (m_cache)
		{
			foreach (MonitoredItem value in m_monitoredItems.Values)
			{
				if (!string.IsNullOrEmpty(value.RelativePath) && NodeId.IsNull(value.ResolvedNodeId))
				{
					if (value.Created)
					{
						throw new ServiceResultException(2158952448u, "Cannot modify item path after it is created.");
					}
					BrowsePath browsePath = new BrowsePath();
					browsePath.StartingNode = value.StartNodeId;
					try
					{
						browsePath.RelativePath = RelativePath.Parse(value.RelativePath, m_session.TypeTree);
					}
					catch (Exception exception)
					{
						value.SetError(new ServiceResult(exception));
						continue;
					}
					browsePaths.Add(browsePath);
					itemsToBrowse.Add(value);
				}
			}
		}
	}

	private void SaveDataChange(NotificationMessage message, DataChangeNotification notifications, IList<string> stringTable)
	{
		if (notifications.MonitoredItems == null || notifications.MonitoredItems.Count == 0)
		{
			Utils.LogInfo("Publish response contains empty MonitoredItems list for SubscriptionId = {0}.", m_id);
			return;
		}
		for (int i = 0; i < notifications.MonitoredItems.Count; i++)
		{
			MonitoredItemNotification monitoredItemNotification = notifications.MonitoredItems[i];
			MonitoredItem value = null;
			lock (m_cache)
			{
				if (!m_monitoredItems.TryGetValue(monitoredItemNotification.ClientHandle, out value))
				{
					Utils.LogWarning("Publish response contains invalid MonitoredItem. SubscriptionId = {0}, ClientHandle = {1}", m_id, monitoredItemNotification.ClientHandle);
					continue;
				}
			}
			monitoredItemNotification.Message = message;
			if (notifications.DiagnosticInfos.Count > i)
			{
				monitoredItemNotification.DiagnosticInfo = notifications.DiagnosticInfos[i];
			}
			value.SaveValueInCache(monitoredItemNotification);
		}
	}

	private void SaveEvents(NotificationMessage message, EventNotificationList notifications, IList<string> stringTable)
	{
		for (int i = 0; i < notifications.Events.Count; i++)
		{
			EventFieldList eventFieldList = notifications.Events[i];
			MonitoredItem value = null;
			lock (m_cache)
			{
				if (!m_monitoredItems.TryGetValue(eventFieldList.ClientHandle, out value))
				{
					Utils.LogWarning("Publish response contains invalid MonitoredItem.SubscriptionId = {0}, ClientHandle = {1}", m_id, eventFieldList.ClientHandle);
					continue;
				}
			}
			eventFieldList.Message = message;
			value.SaveValueInCache(eventFieldList);
		}
	}

	private IncomingMessage FindOrCreateEntry(DateTime utcNow, uint sequenceNumber)
	{
		IncomingMessage incomingMessage = null;
		LinkedListNode<IncomingMessage> linkedListNode = m_incomingMessages.Last;
		while (linkedListNode != null)
		{
			incomingMessage = linkedListNode.Value;
			LinkedListNode<IncomingMessage> previous = linkedListNode.Previous;
			if (incomingMessage.SequenceNumber == sequenceNumber)
			{
				incomingMessage.Timestamp = utcNow;
				break;
			}
			if (incomingMessage.SequenceNumber < sequenceNumber)
			{
				incomingMessage = new IncomingMessage();
				incomingMessage.SequenceNumber = sequenceNumber;
				incomingMessage.Timestamp = utcNow;
				m_incomingMessages.AddAfter(linkedListNode, incomingMessage);
				break;
			}
			linkedListNode = previous;
			incomingMessage = null;
		}
		if (incomingMessage == null)
		{
			incomingMessage = new IncomingMessage();
			incomingMessage.SequenceNumber = sequenceNumber;
			incomingMessage.Timestamp = utcNow;
			m_incomingMessages.AddLast(incomingMessage);
		}
		return incomingMessage;
	}

	public async Task CreateAsync(CancellationToken ct = default(CancellationToken))
	{
		VerifySubscriptionState(created: false);
		uint keepAliveCount = m_keepAliveCount;
		uint lifetimeCount = m_lifetimeCount;
		AdjustCounts(ref keepAliveCount, ref lifetimeCount);
		CreateSubscriptionResponse createSubscriptionResponse = await m_session.CreateSubscriptionAsync(null, m_publishingInterval, lifetimeCount, keepAliveCount, m_maxNotificationsPerPublish, m_publishingEnabled, m_priority, ct).ConfigureAwait(continueOnCapturedContext: false);
		CreateSubscription(createSubscriptionResponse.SubscriptionId, createSubscriptionResponse.RevisedPublishingInterval, createSubscriptionResponse.RevisedMaxKeepAliveCount, createSubscriptionResponse.RevisedLifetimeCount);
		await CreateItemsAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
		ChangesCompleted();
	}

	public async Task DeleteAsync(bool silent, CancellationToken ct = default(CancellationToken))
	{
		if (!silent)
		{
			VerifySubscriptionState(created: true);
		}
		if (!Created)
		{
			return;
		}
		try
		{
			lock (m_cache)
			{
				Utils.SilentDispose(m_publishTimer);
				m_publishTimer = null;
				m_messageWorkerEvent.Set();
				m_messageWorkerTask = null;
			}
			UInt32Collection subscriptionIds = new uint[1] { m_id };
			DeleteSubscriptionsResponse deleteSubscriptionsResponse = await m_session.DeleteSubscriptionsAsync(null, subscriptionIds, ct).ConfigureAwait(continueOnCapturedContext: false);
			ClientBase.ValidateResponse(deleteSubscriptionsResponse.Results, subscriptionIds);
			ClientBase.ValidateDiagnosticInfos(deleteSubscriptionsResponse.DiagnosticInfos, subscriptionIds);
			if (StatusCode.IsBad(deleteSubscriptionsResponse.Results[0]))
			{
				throw new ServiceResultException(ClientBase.GetResult(deleteSubscriptionsResponse.Results[0], 0, deleteSubscriptionsResponse.DiagnosticInfos, deleteSubscriptionsResponse.ResponseHeader));
			}
		}
		catch (Exception e)
		{
			if (!silent)
			{
				throw new ServiceResultException(e, 2147549184u);
			}
		}
		finally
		{
			DeleteSubscription();
		}
		ChangesCompleted();
	}

	public async Task ModifyAsync(CancellationToken ct = default(CancellationToken))
	{
		VerifySubscriptionState(created: true);
		uint keepAliveCount = m_keepAliveCount;
		uint lifetimeCount = m_lifetimeCount;
		AdjustCounts(ref keepAliveCount, ref lifetimeCount);
		ModifySubscriptionResponse modifySubscriptionResponse = await m_session.ModifySubscriptionAsync(null, m_id, m_publishingInterval, lifetimeCount, keepAliveCount, m_maxNotificationsPerPublish, m_priority, ct).ConfigureAwait(continueOnCapturedContext: false);
		ModifySubscription(modifySubscriptionResponse.RevisedPublishingInterval, modifySubscriptionResponse.RevisedMaxKeepAliveCount, modifySubscriptionResponse.RevisedLifetimeCount);
		ChangesCompleted();
	}

	public async Task SetPublishingModeAsync(bool enabled, CancellationToken ct = default(CancellationToken))
	{
		VerifySubscriptionState(created: true);
		UInt32Collection subscriptionIds = new uint[1] { m_id };
		SetPublishingModeResponse setPublishingModeResponse = await m_session.SetPublishingModeAsync(null, enabled, new uint[1] { m_id }, ct).ConfigureAwait(continueOnCapturedContext: false);
		ClientBase.ValidateResponse(setPublishingModeResponse.Results, subscriptionIds);
		ClientBase.ValidateDiagnosticInfos(setPublishingModeResponse.DiagnosticInfos, subscriptionIds);
		if (StatusCode.IsBad(setPublishingModeResponse.Results[0]))
		{
			throw new ServiceResultException(ClientBase.GetResult(setPublishingModeResponse.Results[0], 0, setPublishingModeResponse.DiagnosticInfos, setPublishingModeResponse.ResponseHeader));
		}
		m_currentPublishingEnabled = (m_publishingEnabled = enabled);
		m_changeMask |= SubscriptionChangeMask.Modified;
		ChangesCompleted();
	}

	public async Task<NotificationMessage> RepublishAsync(uint sequenceNumber, CancellationToken ct = default(CancellationToken))
	{
		VerifySubscriptionState(created: true);
		return (await m_session.RepublishAsync(null, m_id, sequenceNumber, ct).ConfigureAwait(continueOnCapturedContext: false)).NotificationMessage;
	}

	public async Task ApplyChangesAsync(CancellationToken ct = default(CancellationToken))
	{
		await DeleteItemsAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
		await ModifyItemsAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
		await CreateItemsAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
	}

	public async Task ResolveItemNodeIdsAsync(CancellationToken ct)
	{
		VerifySubscriptionState(created: true);
		BrowsePathCollection browsePaths = new BrowsePathCollection();
		List<MonitoredItem> itemsToBrowse = new List<MonitoredItem>();
		PrepareResolveItemNodeIds(browsePaths, itemsToBrowse);
		if (browsePaths.Count != 0)
		{
			TranslateBrowsePathsToNodeIdsResponse translateBrowsePathsToNodeIdsResponse = await m_session.TranslateBrowsePathsToNodeIdsAsync(null, browsePaths, ct).ConfigureAwait(continueOnCapturedContext: false);
			BrowsePathResultCollection results = translateBrowsePathsToNodeIdsResponse.Results;
			ClientBase.ValidateResponse(results, browsePaths);
			ClientBase.ValidateDiagnosticInfos(translateBrowsePathsToNodeIdsResponse.DiagnosticInfos, browsePaths);
			for (int i = 0; i < results.Count; i++)
			{
				itemsToBrowse[i].SetResolvePathResult(results[i], i, translateBrowsePathsToNodeIdsResponse.DiagnosticInfos, translateBrowsePathsToNodeIdsResponse.ResponseHeader);
			}
			m_changeMask |= SubscriptionChangeMask.ItemsModified;
		}
	}

	public async Task<IList<MonitoredItem>> CreateItemsAsync(CancellationToken ct = default(CancellationToken))
	{
		List<MonitoredItem> itemsToCreate;
		MonitoredItemCreateRequestCollection requestItems = PrepareItemsToCreate(out itemsToCreate);
		if (requestItems.Count == 0)
		{
			return itemsToCreate;
		}
		CreateMonitoredItemsResponse createMonitoredItemsResponse = await m_session.CreateMonitoredItemsAsync(null, m_id, m_timestampsToReturn, requestItems, ct).ConfigureAwait(continueOnCapturedContext: false);
		MonitoredItemCreateResultCollection results = createMonitoredItemsResponse.Results;
		ClientBase.ValidateResponse(results, itemsToCreate);
		ClientBase.ValidateDiagnosticInfos(createMonitoredItemsResponse.DiagnosticInfos, itemsToCreate);
		for (int i = 0; i < results.Count; i++)
		{
			itemsToCreate[i].SetCreateResult(requestItems[i], results[i], i, createMonitoredItemsResponse.DiagnosticInfos, createMonitoredItemsResponse.ResponseHeader);
		}
		m_changeMask |= SubscriptionChangeMask.ItemsCreated;
		ChangesCompleted();
		return itemsToCreate;
	}

	public async Task<IList<MonitoredItem>> ModifyItemsAsync(CancellationToken ct = default(CancellationToken))
	{
		VerifySubscriptionState(created: true);
		MonitoredItemModifyRequestCollection requestItems = new MonitoredItemModifyRequestCollection();
		List<MonitoredItem> itemsToModify = new List<MonitoredItem>();
		PrepareItemsToModify(requestItems, itemsToModify);
		if (requestItems.Count == 0)
		{
			return itemsToModify;
		}
		ModifyMonitoredItemsResponse modifyMonitoredItemsResponse = await m_session.ModifyMonitoredItemsAsync(null, m_id, m_timestampsToReturn, requestItems, ct).ConfigureAwait(continueOnCapturedContext: false);
		MonitoredItemModifyResultCollection results = modifyMonitoredItemsResponse.Results;
		ClientBase.ValidateResponse(results, itemsToModify);
		ClientBase.ValidateDiagnosticInfos(modifyMonitoredItemsResponse.DiagnosticInfos, itemsToModify);
		for (int i = 0; i < results.Count; i++)
		{
			itemsToModify[i].SetModifyResult(requestItems[i], results[i], i, modifyMonitoredItemsResponse.DiagnosticInfos, modifyMonitoredItemsResponse.ResponseHeader);
		}
		m_changeMask |= SubscriptionChangeMask.ItemsModified;
		ChangesCompleted();
		return itemsToModify;
	}

	public async Task<IList<MonitoredItem>> DeleteItemsAsync(CancellationToken ct)
	{
		VerifySubscriptionState(created: true);
		if (m_deletedItems.Count == 0)
		{
			return new List<MonitoredItem>();
		}
		List<MonitoredItem> itemsToDelete = m_deletedItems;
		m_deletedItems = new List<MonitoredItem>();
		UInt32Collection monitoredItemIds = new UInt32Collection();
		foreach (MonitoredItem item in itemsToDelete)
		{
			monitoredItemIds.Add(item.Status.Id);
		}
		DeleteMonitoredItemsResponse deleteMonitoredItemsResponse = await m_session.DeleteMonitoredItemsAsync(null, m_id, monitoredItemIds, ct).ConfigureAwait(continueOnCapturedContext: false);
		StatusCodeCollection results = deleteMonitoredItemsResponse.Results;
		ClientBase.ValidateResponse(results, monitoredItemIds);
		ClientBase.ValidateDiagnosticInfos(deleteMonitoredItemsResponse.DiagnosticInfos, monitoredItemIds);
		for (int i = 0; i < results.Count; i++)
		{
			itemsToDelete[i].SetDeleteResult(results[i], i, deleteMonitoredItemsResponse.DiagnosticInfos, deleteMonitoredItemsResponse.ResponseHeader);
		}
		m_changeMask |= SubscriptionChangeMask.ItemsDeleted;
		ChangesCompleted();
		return itemsToDelete;
	}

	public async Task<List<ServiceResult>> SetMonitoringModeAsync(MonitoringMode monitoringMode, IList<MonitoredItem> monitoredItems, CancellationToken ct = default(CancellationToken))
	{
		if (monitoredItems == null)
		{
			throw new ArgumentNullException("monitoredItems");
		}
		VerifySubscriptionState(created: true);
		if (monitoredItems.Count == 0)
		{
			return null;
		}
		UInt32Collection monitoredItemIds = new UInt32Collection();
		foreach (MonitoredItem monitoredItem in monitoredItems)
		{
			monitoredItemIds.Add(monitoredItem.Status.Id);
		}
		SetMonitoringModeResponse setMonitoringModeResponse = await m_session.SetMonitoringModeAsync(null, m_id, monitoringMode, monitoredItemIds, ct).ConfigureAwait(continueOnCapturedContext: false);
		StatusCodeCollection results = setMonitoringModeResponse.Results;
		ClientBase.ValidateResponse(results, monitoredItemIds);
		ClientBase.ValidateDiagnosticInfos(setMonitoringModeResponse.DiagnosticInfos, monitoredItemIds);
		List<ServiceResult> list = new List<ServiceResult>();
		bool num = UpdateMonitoringMode(monitoredItems, list, results, setMonitoringModeResponse.DiagnosticInfos, setMonitoringModeResponse.ResponseHeader, monitoringMode);
		m_changeMask |= SubscriptionChangeMask.ItemsModified;
		ChangesCompleted();
		if (num)
		{
			return null;
		}
		return list;
	}

	public async Task ConditionRefreshAsync(CancellationToken ct = default(CancellationToken))
	{
		VerifySubscriptionState(created: true);
		CallMethodRequestCollection callMethodRequestCollection = new CallMethodRequestCollection();
		callMethodRequestCollection.Add(new CallMethodRequest
		{
			MethodId = MethodIds.ConditionType_ConditionRefresh,
			InputArguments = new VariantCollection
			{
				new Variant(m_id)
			}
		});
		await m_session.CallAsync(null, callMethodRequestCollection, ct).ConfigureAwait(continueOnCapturedContext: false);
	}
}
