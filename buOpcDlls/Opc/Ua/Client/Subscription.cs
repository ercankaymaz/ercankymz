// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.Subscription
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Opc.Ua.Types.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua.Client;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class Subscription : IDisposable, ICloneable
{
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
  private LinkedList<Subscription.IncomingMessage> m_incomingMessages;
  private static long s_globalSubscriptionCounter;

  public Subscription() => this.Initialize();

  public Subscription(Subscription template)
    : this(template, false)
  {
  }

  public Subscription(Subscription template, bool copyEventHandlers)
  {
    this.Initialize();
    if (template == null)
      return;
    string str = template.DisplayName;
    if (string.IsNullOrEmpty(str))
      str = this.m_displayName;
    int length = str.LastIndexOf(' ');
    if (length != -1)
    {
      try
      {
        str = str.Substring(0, length);
      }
      catch
      {
      }
    }
    this.m_displayName = Opc.Ua.Utils.Format("{0} {1}", (object) str, (object) Opc.Ua.Utils.IncrementIdentifier(ref Subscription.s_globalSubscriptionCounter));
    this.m_publishingInterval = template.m_publishingInterval;
    this.m_keepAliveCount = template.m_keepAliveCount;
    this.m_lifetimeCount = template.m_lifetimeCount;
    this.m_minLifetimeInterval = template.m_minLifetimeInterval;
    this.m_maxNotificationsPerPublish = template.m_maxNotificationsPerPublish;
    this.m_publishingEnabled = template.m_publishingEnabled;
    this.m_priority = template.m_priority;
    this.m_timestampsToReturn = template.m_timestampsToReturn;
    this.m_maxMessageCount = template.m_maxMessageCount;
    this.m_sequentialPublishing = template.m_sequentialPublishing;
    this.m_republishAfterTransfer = template.m_republishAfterTransfer;
    this.m_defaultItem = (MonitoredItem) template.m_defaultItem.Clone();
    this.m_handle = template.m_handle;
    this.m_disableMonitoredItemCache = template.m_disableMonitoredItemCache;
    this.m_transferId = template.m_transferId;
    if (copyEventHandlers)
    {
      this.m_StateChanged = template.m_StateChanged;
      this.m_publishStatusChanged = template.m_publishStatusChanged;
      this.m_fastDataChangeCallback = template.m_fastDataChangeCallback;
      this.m_fastEventCallback = template.m_fastEventCallback;
      this.m_fastKeepAliveCallback = template.m_fastKeepAliveCallback;
    }
    foreach (MonitoredItem monitoredItem1 in template.MonitoredItems)
    {
      MonitoredItem monitoredItem2 = monitoredItem1.CloneMonitoredItem(copyEventHandlers, true);
      monitoredItem2.DisplayName = monitoredItem1.DisplayName;
      this.AddItem(monitoredItem2);
    }
  }

  private void ResetPublishTimerAndWorkerState()
  {
    Opc.Ua.Utils.SilentDispose((IDisposable) this.m_publishTimer);
    this.m_publishTimer = (Timer) null;
    this.m_messageWorkerShutdownEvent.Set();
    this.m_messageWorkerEvent.Set();
    this.m_messageWorkerTask = (Task) null;
  }

  [OnDeserializing]
  protected void Initialize(StreamingContext context)
  {
    this.m_cache = new object();
    this.Initialize();
  }

  private void Initialize()
  {
    this.m_id = 0U;
    this.m_transferId = 0U;
    this.m_displayName = nameof (Subscription);
    this.m_publishingInterval = 0;
    this.m_keepAliveCount = 0U;
    this.m_lifetimeCount = 0U;
    this.m_maxNotificationsPerPublish = 0U;
    this.m_publishingEnabled = false;
    this.m_timestampsToReturn = TimestampsToReturn.Both;
    this.m_maxMessageCount = 10;
    this.m_republishAfterTransfer = false;
    this.m_outstandingMessageWorkers = 0;
    this.m_sequentialPublishing = false;
    this.m_lastSequenceNumberProcessed = 0U;
    this.m_messageCache = new LinkedList<NotificationMessage>();
    this.m_monitoredItems = new SortedDictionary<uint, MonitoredItem>();
    this.m_deletedItems = new List<MonitoredItem>();
    this.m_messageWorkerEvent = new AsyncAutoResetEvent();
    this.m_messageWorkerShutdownEvent = new ManualResetEvent(false);
    this.m_resyncLastSequenceNumberProcessed = false;
    this.m_defaultItem = new MonitoredItem()
    {
      DisplayName = "MonitoredItem",
      SamplingInterval = -1,
      MonitoringMode = MonitoringMode.Reporting,
      QueueSize = 0U,
      DiscardOldest = true
    };
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!disposing)
      return;
    this.ResetPublishTimerAndWorkerState();
  }

  public virtual object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone() => (object) new Subscription(this);

  public virtual Subscription CloneSubscription(bool copyEventHandlers)
  {
    return new Subscription(this, copyEventHandlers);
  }

  public event SubscriptionStateChangedEventHandler StateChanged
  {
    add => this.m_StateChanged += value;
    remove => this.m_StateChanged -= value;
  }

  public event PublishStateChangedEventHandler PublishStatusChanged
  {
    add
    {
      lock (this.m_cache)
        this.m_publishStatusChanged += value;
    }
    remove
    {
      lock (this.m_cache)
        this.m_publishStatusChanged -= value;
    }
  }

  [DataMember(Order = 1)]
  public string DisplayName
  {
    get => this.m_displayName;
    set => this.m_displayName = value;
  }

  [DataMember(Order = 2)]
  public int PublishingInterval
  {
    get => this.m_publishingInterval;
    set => this.m_publishingInterval = value;
  }

  [DataMember(Order = 3)]
  public uint KeepAliveCount
  {
    get => this.m_keepAliveCount;
    set => this.m_keepAliveCount = value;
  }

  [DataMember(Order = 4)]
  public uint LifetimeCount
  {
    get => this.m_lifetimeCount;
    set => this.m_lifetimeCount = value;
  }

  [DataMember(Order = 5)]
  public uint MaxNotificationsPerPublish
  {
    get => this.m_maxNotificationsPerPublish;
    set => this.m_maxNotificationsPerPublish = value;
  }

  [DataMember(Order = 6)]
  public bool PublishingEnabled
  {
    get => this.m_publishingEnabled;
    set => this.m_publishingEnabled = value;
  }

  [DataMember(Order = 7)]
  public byte Priority
  {
    get => this.m_priority;
    set => this.m_priority = value;
  }

  [DataMember(Order = 8)]
  public TimestampsToReturn TimestampsToReturn
  {
    get => this.m_timestampsToReturn;
    set => this.m_timestampsToReturn = value;
  }

  [DataMember(Order = 9)]
  public int MaxMessageCount
  {
    get
    {
      lock (this.m_cache)
        return this.m_maxMessageCount;
    }
    set
    {
      lock (this.m_cache)
        this.m_maxMessageCount = value;
    }
  }

  [DataMember(Order = 10)]
  public MonitoredItem DefaultItem
  {
    get => this.m_defaultItem;
    set => this.m_defaultItem = value;
  }

  [DataMember(Order = 12)]
  public uint MinLifetimeInterval
  {
    get => this.m_minLifetimeInterval;
    set => this.m_minLifetimeInterval = value;
  }

  [DataMember(Order = 13)]
  public bool DisableMonitoredItemCache
  {
    get => this.m_disableMonitoredItemCache;
    set => this.m_disableMonitoredItemCache = value;
  }

  [DataMember(Order = 14)]
  public bool SequentialPublishing
  {
    get
    {
      lock (this.m_cache)
        return this.m_sequentialPublishing;
    }
    set
    {
      lock (this.m_cache)
        this.m_sequentialPublishing = value;
    }
  }

  [DataMember(Name = "RepublishAfterTransfer", Order = 15)]
  public bool RepublishAfterTransfer
  {
    get => this.m_republishAfterTransfer;
    set
    {
      lock (this.m_cache)
        this.m_republishAfterTransfer = value;
    }
  }

  [DataMember(Name = "TransferId", Order = 16 /*0x10*/)]
  public uint TransferId
  {
    get => this.m_transferId;
    set => this.m_transferId = value;
  }

  public FastDataChangeNotificationEventHandler FastDataChangeCallback
  {
    get => this.m_fastDataChangeCallback;
    set => this.m_fastDataChangeCallback = value;
  }

  public FastEventNotificationEventHandler FastEventCallback
  {
    get => this.m_fastEventCallback;
    set => this.m_fastEventCallback = value;
  }

  public FastKeepAliveNotificationEventHandler FastKeepAliveCallback
  {
    get => this.m_fastKeepAliveCallback;
    set => this.m_fastKeepAliveCallback = value;
  }

  public IEnumerable<MonitoredItem> MonitoredItems
  {
    get
    {
      lock (this.m_cache)
        return (IEnumerable<MonitoredItem>) new List<MonitoredItem>((IEnumerable<MonitoredItem>) this.m_monitoredItems.Values);
    }
  }

  [DataMember(Name = "MonitoredItems", Order = 11)]
  private List<MonitoredItem> SavedMonitoredItems
  {
    get
    {
      lock (this.m_cache)
        return new List<MonitoredItem>((IEnumerable<MonitoredItem>) this.m_monitoredItems.Values);
    }
    set
    {
      if (this.Created)
        throw new InvalidOperationException("Cannot update a subscription that has been created on the server.");
      lock (this.m_cache)
      {
        this.m_monitoredItems.Clear();
        foreach (MonitoredItem monitoredItem in value)
          this.AddItem(monitoredItem);
      }
    }
  }

  public bool ChangesPending
  {
    get
    {
      if (this.m_deletedItems.Count > 0)
        return true;
      foreach (MonitoredItem monitoredItem in this.m_monitoredItems.Values)
      {
        if (this.Created && !monitoredItem.Status.Created || monitoredItem.AttributesModified)
          return true;
      }
      return false;
    }
  }

  public uint MonitoredItemCount
  {
    get
    {
      lock (this.m_cache)
        return (uint) this.m_monitoredItems.Count;
    }
  }

  public ISession Session
  {
    get => this.m_session;
    internal set => this.m_session = value;
  }

  public object Handle
  {
    get => this.m_handle;
    set => this.m_handle = value;
  }

  public uint Id => this.m_id;

  public bool Created => this.m_id > 0U;

  [DataMember(Name = "CurrentPublishInterval", Order = 20)]
  public double CurrentPublishingInterval
  {
    get => this.m_currentPublishingInterval;
    set => this.m_currentPublishingInterval = value;
  }

  [DataMember(Name = "CurrentKeepAliveCount", Order = 21)]
  public uint CurrentKeepAliveCount
  {
    get => this.m_currentKeepAliveCount;
    set => this.m_currentKeepAliveCount = value;
  }

  [DataMember(Name = "CurrentLifetimeCount", Order = 22)]
  public uint CurrentLifetimeCount
  {
    get => this.m_currentLifetimeCount;
    set => this.m_currentLifetimeCount = value;
  }

  public bool CurrentPublishingEnabled => this.m_currentPublishingEnabled;

  public byte CurrentPriority => this.m_currentPriority;

  public DateTime PublishTime
  {
    get
    {
      lock (this.m_cache)
      {
        if (this.m_messageCache.Count > 0)
          return this.m_messageCache.Last.Value.PublishTime;
      }
      return DateTime.MinValue;
    }
  }

  public DateTime LastNotificationTime
  {
    get
    {
      lock (this.m_cache)
        return this.m_lastNotificationTime;
    }
  }

  public uint SequenceNumber
  {
    get
    {
      lock (this.m_cache)
      {
        if (this.m_messageCache.Count > 0)
          return this.m_messageCache.Last.Value.SequenceNumber;
      }
      return 0;
    }
  }

  public uint NotificationCount
  {
    get
    {
      lock (this.m_cache)
      {
        if (this.m_messageCache.Count > 0)
          return (uint) this.m_messageCache.Last.Value.NotificationData.Count;
      }
      return 0;
    }
  }

  public NotificationMessage LastNotification
  {
    get
    {
      lock (this.m_cache)
        return this.m_messageCache.Count > 0 ? this.m_messageCache.Last.Value : (NotificationMessage) null;
    }
  }

  public IEnumerable<NotificationMessage> Notifications
  {
    get
    {
      lock (this.m_cache)
        return (IEnumerable<NotificationMessage>) new List<NotificationMessage>((IEnumerable<NotificationMessage>) this.m_messageCache);
    }
  }

  public IEnumerable<uint> AvailableSequenceNumbers
  {
    get
    {
      lock (this.m_cache)
        return (IEnumerable<uint>) new List<uint>((IEnumerable<uint>) this.m_availableSequenceNumbers);
    }
  }

  public void ChangesCompleted()
  {
    if (this.m_StateChanged != null)
      this.m_StateChanged(this, new SubscriptionStateChangedEventArgs(this.m_changeMask));
    this.m_changeMask = SubscriptionChangeMask.None;
  }

  public bool PublishingStopped
  {
    get
    {
      lock (this.m_cache)
        return (DateTime.UtcNow - this.m_lastNotificationTime).TotalMilliseconds > (double) ((int) Math.Min(this.m_currentPublishingInterval * (double) (this.m_currentKeepAliveCount + 1U), 2147483147.0) + 500);
    }
  }

  public void Create()
  {
    this.VerifySubscriptionState(false);
    uint revisedMaxKeepAliveCount = this.m_keepAliveCount;
    uint revisedLifetimeCount = this.m_lifetimeCount;
    this.AdjustCounts(ref revisedMaxKeepAliveCount, ref revisedLifetimeCount);
    uint subscriptionId;
    double revisedPublishingInterval;
    this.m_session.CreateSubscription((RequestHeader) null, (double) this.m_publishingInterval, revisedLifetimeCount, revisedMaxKeepAliveCount, this.m_maxNotificationsPerPublish, this.m_publishingEnabled, this.m_priority, out subscriptionId, out revisedPublishingInterval, out revisedLifetimeCount, out revisedMaxKeepAliveCount);
    this.CreateSubscription(subscriptionId, revisedPublishingInterval, revisedMaxKeepAliveCount, revisedLifetimeCount);
    this.CreateItems();
    this.ChangesCompleted();
    this.TraceState("CREATED");
  }

  public bool Transfer(ISession session, uint id, UInt32Collection availableSequenceNumbers)
  {
    if (this.Created)
    {
      if ((int) id != (int) this.m_id)
        return false;
      ISession session1 = this.m_session;
      if ((session1 != null ? (!session1.RemoveTransferredSubscription(this) ? 1 : 0) : 1) != 0)
      {
        Opc.Ua.Utils.LogError("SubscriptionId {0}: Failed to remove transferred subscription from owner SessionId={1}.", (object) this.Id, (object) this.m_session?.SessionId);
        return false;
      }
      List<Subscription> list = session.Subscriptions.Where<Subscription>((Func<Subscription, bool>) (s => !s.Created && (int) s.TransferId == (int) this.Id)).ToList<Subscription>();
      session.RemoveSubscriptions((IEnumerable<Subscription>) list);
      if (!session.AddSubscription(this))
      {
        Opc.Ua.Utils.LogError("SubscriptionId {0}: Failed to add transferred subscription to SessionId={1}.", (object) this.Id, (object) session.SessionId);
        return false;
      }
    }
    else
    {
      UInt32Collection serverHandles;
      UInt32Collection clientHandles;
      if (!this.GetMonitoredItems(out serverHandles, out clientHandles))
      {
        Opc.Ua.Utils.LogError("SubscriptionId {0}: The server failed to respond to GetMonitoredItems after transfer.", (object) this.Id);
        return false;
      }
      if (serverHandles.Count == this.m_monitoredItems.Count && clientHandles.Count == this.m_monitoredItems.Count)
      {
        this.m_id = id;
        this.TransferItems(serverHandles, clientHandles, out IList<MonitoredItem> _);
        this.ModifyItems();
      }
      else
      {
        Opc.Ua.Utils.LogError("SubscriptionId {0}: Number of Monitored Items on client and server do not match after transfer {1}!={2}", (object) this.Id, (object) serverHandles.Count, (object) this.m_monitoredItems.Count);
        return false;
      }
    }
    this.ProcessTransferredSequenceNumbers(availableSequenceNumbers);
    this.m_changeMask |= SubscriptionChangeMask.Transferred;
    this.ChangesCompleted();
    this.StartKeepAliveTimer();
    this.TraceState("TRANSFERRED");
    return true;
  }

  public async Task<bool> TransferAsync(
    ISession session,
    uint id,
    UInt32Collection availableSequenceNumbers,
    CancellationToken ct = default (CancellationToken))
  {
    Subscription subscription = this;
    if (subscription.Created)
    {
      if ((int) id != (int) subscription.m_id)
        return false;
      ISession session1 = subscription.m_session;
      if ((session1 != null ? (!session1.RemoveTransferredSubscription(subscription) ? 1 : 0) : 1) != 0)
      {
        Opc.Ua.Utils.LogError("SubscriptionId {0}: Failed to remove transferred subscription from owner SessionId={1}.", (object) subscription.Id, (object) subscription.m_session?.SessionId);
        return false;
      }
      // ISSUE: reference to a compiler-generated method
      int num = await session.RemoveSubscriptionsAsync((IEnumerable<Subscription>) session.Subscriptions.Where<Subscription>(new Func<Subscription, bool>(subscription.\u003CTransferAsync\u003Eb__122_0)).ToList<Subscription>(), ct).ConfigureAwait(false) ? 1 : 0;
      if (!session.AddSubscription(subscription))
      {
        Opc.Ua.Utils.LogError("SubscriptionId {0}: Failed to add transferred subscription to SessionId={1}.", (object) subscription.Id, (object) session.SessionId);
        return false;
      }
    }
    else
    {
      (bool flag, UInt32Collection serverHandles, UInt32Collection clientHandles) = await subscription.GetMonitoredItemsAsync(ct).ConfigureAwait(false);
      if (!flag)
      {
        Opc.Ua.Utils.LogError("SubscriptionId {0}: The server failed to respond to GetMonitoredItems after transfer.", (object) subscription.Id);
        return false;
      }
      if (serverHandles.Count == subscription.m_monitoredItems.Count && clientHandles.Count == subscription.m_monitoredItems.Count)
      {
        subscription.m_id = id;
        subscription.TransferItems(serverHandles, clientHandles, out IList<MonitoredItem> _);
        IList<MonitoredItem> monitoredItemList = await subscription.ModifyItemsAsync(ct).ConfigureAwait(false);
      }
      else
      {
        Opc.Ua.Utils.LogError("SubscriptionId {0}: Number of Monitored Items on client and server do not match after transfer {1}!={2}", (object) subscription.Id, (object) serverHandles.Count, (object) subscription.m_monitoredItems.Count);
        return false;
      }
    }
    subscription.ProcessTransferredSequenceNumbers(availableSequenceNumbers);
    subscription.m_changeMask |= SubscriptionChangeMask.Transferred;
    subscription.ChangesCompleted();
    subscription.StartKeepAliveTimer();
    subscription.TraceState("TRANSFERRED ASYNC");
    return true;
  }

  public void Delete(bool silent)
  {
    if (!silent)
      this.VerifySubscriptionState(true);
    if (!this.Created)
      return;
    try
    {
      this.TraceState("DELETE");
      lock (this.m_cache)
        this.ResetPublishTimerAndWorkerState();
      UInt32Collection uint32Collection = (UInt32Collection) new uint[1]
      {
        this.m_id
      };
      StatusCodeCollection results;
      DiagnosticInfoCollection diagnosticInfos;
      ResponseHeader responseHeader = this.m_session.DeleteSubscriptions((RequestHeader) null, uint32Collection, out results, out diagnosticInfos);
      ClientBase.ValidateResponse((IList) results, (IList) uint32Collection);
      ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) uint32Collection);
      if (StatusCode.IsBad(results[0]))
        throw new ServiceResultException(ClientBase.GetResult(results[0], 0, diagnosticInfos, responseHeader));
    }
    catch (Exception ex)
    {
      if (!silent)
        throw new ServiceResultException(ex, 2147549184U /*0x80010000*/);
    }
    finally
    {
      this.DeleteSubscription();
    }
    this.ChangesCompleted();
  }

  public void Modify()
  {
    this.VerifySubscriptionState(true);
    uint revisedMaxKeepAliveCount = this.m_keepAliveCount;
    uint revisedLifetimeCount = this.m_lifetimeCount;
    this.AdjustCounts(ref revisedMaxKeepAliveCount, ref revisedLifetimeCount);
    double revisedPublishingInterval;
    this.m_session.ModifySubscription((RequestHeader) null, this.m_id, (double) this.m_publishingInterval, revisedLifetimeCount, revisedMaxKeepAliveCount, this.m_maxNotificationsPerPublish, this.m_priority, out revisedPublishingInterval, out revisedLifetimeCount, out revisedMaxKeepAliveCount);
    this.ModifySubscription(revisedPublishingInterval, revisedMaxKeepAliveCount, revisedLifetimeCount);
    this.ChangesCompleted();
    this.TraceState("MODIFIED");
  }

  public void SetPublishingMode(bool enabled)
  {
    this.VerifySubscriptionState(true);
    UInt32Collection request = (UInt32Collection) new uint[1]
    {
      this.m_id
    };
    StatusCodeCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    ResponseHeader responseHeader = this.m_session.SetPublishingMode((RequestHeader) null, (enabled ? 1 : 0) != 0, (UInt32Collection) new uint[1]
    {
      this.m_id
    }, out results, out diagnosticInfos);
    ClientBase.ValidateResponse((IList) results, (IList) request);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) request);
    if (StatusCode.IsBad(results[0]))
      throw new ServiceResultException(ClientBase.GetResult(results[0], 0, diagnosticInfos, responseHeader));
    this.m_currentPublishingEnabled = this.m_publishingEnabled = enabled;
    this.m_changeMask |= SubscriptionChangeMask.Modified;
    this.ChangesCompleted();
    this.TraceState(enabled ? "PUBLISHING ENABLED" : "PUBLISHING DISABLED");
  }

  public NotificationMessage Republish(uint sequenceNumber)
  {
    this.VerifySubscriptionState(true);
    NotificationMessage notificationMessage;
    this.m_session.Republish((RequestHeader) null, this.m_id, sequenceNumber, out notificationMessage);
    return notificationMessage;
  }

  public void ApplyChanges()
  {
    this.DeleteItems();
    this.ModifyItems();
    this.CreateItems();
  }

  public void ResolveItemNodeIds()
  {
    this.VerifySubscriptionState(true);
    BrowsePathCollection browsePathCollection = new BrowsePathCollection();
    List<MonitoredItem> itemsToBrowse = new List<MonitoredItem>();
    this.PrepareResolveItemNodeIds(browsePathCollection, (IList<MonitoredItem>) itemsToBrowse);
    if (browsePathCollection.Count == 0)
      return;
    BrowsePathResultCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    ResponseHeader nodeIds = this.m_session.TranslateBrowsePathsToNodeIds((RequestHeader) null, browsePathCollection, out results, out diagnosticInfos);
    ClientBase.ValidateResponse((IList) results, (IList) browsePathCollection);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) browsePathCollection);
    for (int index = 0; index < results.Count; ++index)
      itemsToBrowse[index].SetResolvePathResult(results[index], index, diagnosticInfos, nodeIds);
    this.m_changeMask |= SubscriptionChangeMask.ItemsModified;
  }

  public IList<MonitoredItem> CreateItems()
  {
    List<MonitoredItem> itemsToCreate;
    MonitoredItemCreateRequestCollection create = this.PrepareItemsToCreate(out itemsToCreate);
    if (create.Count == 0)
      return (IList<MonitoredItem>) itemsToCreate;
    MonitoredItemCreateResultCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    ResponseHeader monitoredItems = this.m_session.CreateMonitoredItems((RequestHeader) null, this.m_id, this.m_timestampsToReturn, create, out results, out diagnosticInfos);
    ClientBase.ValidateResponse((IList) results, (IList) itemsToCreate);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) itemsToCreate);
    for (int index = 0; index < results.Count; ++index)
      itemsToCreate[index].SetCreateResult(create[index], results[index], index, diagnosticInfos, monitoredItems);
    this.m_changeMask |= SubscriptionChangeMask.ItemsCreated;
    this.ChangesCompleted();
    return (IList<MonitoredItem>) itemsToCreate;
  }

  public IList<MonitoredItem> ModifyItems()
  {
    this.VerifySubscriptionState(true);
    MonitoredItemModifyRequestCollection requestCollection = new MonitoredItemModifyRequestCollection();
    List<MonitoredItem> monitoredItemList = new List<MonitoredItem>();
    this.PrepareItemsToModify(requestCollection, (IList<MonitoredItem>) monitoredItemList);
    if (requestCollection.Count == 0)
      return (IList<MonitoredItem>) monitoredItemList;
    MonitoredItemModifyResultCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    ResponseHeader responseHeader = this.m_session.ModifyMonitoredItems((RequestHeader) null, this.m_id, this.m_timestampsToReturn, requestCollection, out results, out diagnosticInfos);
    ClientBase.ValidateResponse((IList) results, (IList) monitoredItemList);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) monitoredItemList);
    for (int index = 0; index < results.Count; ++index)
      monitoredItemList[index].SetModifyResult(requestCollection[index], results[index], index, diagnosticInfos, responseHeader);
    this.m_changeMask |= SubscriptionChangeMask.ItemsModified;
    this.ChangesCompleted();
    return (IList<MonitoredItem>) monitoredItemList;
  }

  public IList<MonitoredItem> DeleteItems()
  {
    this.VerifySubscriptionState(true);
    if (this.m_deletedItems.Count == 0)
      return (IList<MonitoredItem>) new List<MonitoredItem>();
    List<MonitoredItem> deletedItems = this.m_deletedItems;
    this.m_deletedItems = new List<MonitoredItem>();
    UInt32Collection uint32Collection = new UInt32Collection();
    foreach (MonitoredItem monitoredItem in deletedItems)
      uint32Collection.Add(monitoredItem.Status.Id);
    StatusCodeCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    ResponseHeader responseHeader = this.m_session.DeleteMonitoredItems((RequestHeader) null, this.m_id, uint32Collection, out results, out diagnosticInfos);
    ClientBase.ValidateResponse((IList) results, (IList) uint32Collection);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) uint32Collection);
    for (int index = 0; index < results.Count; ++index)
      deletedItems[index].SetDeleteResult(results[index], index, diagnosticInfos, responseHeader);
    this.m_changeMask |= SubscriptionChangeMask.ItemsDeleted;
    this.ChangesCompleted();
    return (IList<MonitoredItem>) deletedItems;
  }

  public List<ServiceResult> SetMonitoringMode(
    MonitoringMode monitoringMode,
    IList<MonitoredItem> monitoredItems)
  {
    if (monitoredItems == null)
      throw new ArgumentNullException(nameof (monitoredItems));
    this.VerifySubscriptionState(true);
    if (monitoredItems.Count == 0)
      return (List<ServiceResult>) null;
    UInt32Collection uint32Collection = new UInt32Collection();
    foreach (MonitoredItem monitoredItem in (IEnumerable<MonitoredItem>) monitoredItems)
      uint32Collection.Add(monitoredItem.Status.Id);
    StatusCodeCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    ResponseHeader responseHeader = this.m_session.SetMonitoringMode((RequestHeader) null, this.m_id, monitoringMode, uint32Collection, out results, out diagnosticInfos);
    ClientBase.ValidateResponse((IList) results, (IList) uint32Collection);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) uint32Collection);
    List<ServiceResult> errors = new List<ServiceResult>();
    int num = this.UpdateMonitoringMode(monitoredItems, (IList<ServiceResult>) errors, results, diagnosticInfos, responseHeader, monitoringMode) ? 1 : 0;
    this.m_changeMask |= SubscriptionChangeMask.ItemsModified;
    this.ChangesCompleted();
    return num != 0 ? (List<ServiceResult>) null : errors;
  }

  public void SaveMessageInCache(
    IList<uint> availableSequenceNumbers,
    NotificationMessage message,
    IList<string> stringTable)
  {
    PublishStateChangedEventHandler changedEventHandler = (PublishStateChangedEventHandler) null;
    lock (this.m_cache)
    {
      if (availableSequenceNumbers != null)
        this.m_availableSequenceNumbers = availableSequenceNumbers;
      if (message == null)
        return;
      if (this.PublishingStopped)
      {
        changedEventHandler = this.m_publishStatusChanged;
        this.TraceState("PUBLISHING RECOVERED");
      }
      DateTime utcNow = this.m_lastNotificationTime = DateTime.UtcNow;
      message.StringTable = new List<string>((IEnumerable<string>) stringTable);
      if (this.m_incomingMessages == null)
        this.m_incomingMessages = new LinkedList<Subscription.IncomingMessage>();
      Subscription.IncomingMessage orCreateEntry = this.FindOrCreateEntry(utcNow, message.SequenceNumber);
      if (message.NotificationData.Count > 0)
      {
        orCreateEntry.Message = message;
        orCreateEntry.Processed = false;
      }
      LinkedListNode<Subscription.IncomingMessage> node1 = this.m_incomingMessages.First;
      while (node1 != null)
      {
        Subscription.IncomingMessage incomingMessage = node1.Value;
        LinkedListNode<Subscription.IncomingMessage> next = node1.Next;
        if (next != null && next.Value.SequenceNumber > incomingMessage.SequenceNumber + 1U)
          node1 = this.m_incomingMessages.AddAfter(node1, new Subscription.IncomingMessage()
          {
            SequenceNumber = incomingMessage.SequenceNumber + 1U,
            Timestamp = utcNow
          });
        else
          node1 = next;
      }
      LinkedListNode<Subscription.IncomingMessage> next1;
      for (LinkedListNode<Subscription.IncomingMessage> node2 = this.m_incomingMessages.First; node2 != null; node2 = next1)
      {
        Subscription.IncomingMessage incomingMessage = node2.Value;
        next1 = node2.Next;
        if (incomingMessage.Processed || incomingMessage.Republished && incomingMessage.Timestamp.AddSeconds(10.0) < utcNow)
        {
          if (next1 != null)
          {
            if ((int) incomingMessage.SequenceNumber == (int) this.m_lastSequenceNumberProcessed + 1)
            {
              if (!incomingMessage.Processed)
                Opc.Ua.Utils.LogWarning("SubscriptionId {0} skipping PublishResponse Sequence Number {1}", (object) this.Id, (object) incomingMessage.SequenceNumber);
              this.m_lastSequenceNumberProcessed = incomingMessage.SequenceNumber;
            }
            this.m_incomingMessages.Remove(node2);
          }
        }
        else
          break;
      }
      this.m_messageWorkerEvent.Set();
    }
    if (changedEventHandler == null)
      return;
    try
    {
      changedEventHandler(this, new PublishStateChangedEventArgs(PublishStateChangedMask.Recovered));
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      Opc.Ua.Utils.LogError(ex, "Error while raising PublishStateChanged event.", objArray);
    }
  }

  public int OutstandingMessageWorkers => this.m_outstandingMessageWorkers;

  public void AddItem(MonitoredItem monitoredItem)
  {
    if (monitoredItem == null)
      throw new ArgumentNullException(nameof (monitoredItem));
    lock (this.m_cache)
    {
      if (this.m_monitoredItems.ContainsKey(monitoredItem.ClientHandle))
        return;
      this.m_monitoredItems.Add(monitoredItem.ClientHandle, monitoredItem);
      monitoredItem.Subscription = this;
    }
    this.m_changeMask |= SubscriptionChangeMask.ItemsAdded;
    this.ChangesCompleted();
  }

  public void AddItems(IEnumerable<MonitoredItem> monitoredItems)
  {
    if (monitoredItems == null)
      throw new ArgumentNullException(nameof (monitoredItems));
    bool flag = false;
    lock (this.m_cache)
    {
      foreach (MonitoredItem monitoredItem in monitoredItems)
      {
        if (!this.m_monitoredItems.ContainsKey(monitoredItem.ClientHandle))
        {
          this.m_monitoredItems.Add(monitoredItem.ClientHandle, monitoredItem);
          monitoredItem.Subscription = this;
          flag = true;
        }
      }
    }
    if (!flag)
      return;
    this.m_changeMask |= SubscriptionChangeMask.ItemsAdded;
    this.ChangesCompleted();
  }

  public void RemoveItem(MonitoredItem monitoredItem)
  {
    if (monitoredItem == null)
      throw new ArgumentNullException(nameof (monitoredItem));
    lock (this.m_cache)
    {
      if (!this.m_monitoredItems.Remove(monitoredItem.ClientHandle))
        return;
      monitoredItem.Subscription = (Subscription) null;
    }
    if (monitoredItem.Status.Created)
      this.m_deletedItems.Add(monitoredItem);
    this.m_changeMask |= SubscriptionChangeMask.ItemsRemoved;
    this.ChangesCompleted();
  }

  public void RemoveItems(IEnumerable<MonitoredItem> monitoredItems)
  {
    if (monitoredItems == null)
      throw new ArgumentNullException(nameof (monitoredItems));
    bool flag = false;
    lock (this.m_cache)
    {
      foreach (MonitoredItem monitoredItem in monitoredItems)
      {
        if (this.m_monitoredItems.Remove(monitoredItem.ClientHandle))
        {
          monitoredItem.Subscription = (Subscription) null;
          if (monitoredItem.Status.Created)
            this.m_deletedItems.Add(monitoredItem);
          flag = true;
        }
      }
    }
    if (!flag)
      return;
    this.m_changeMask |= SubscriptionChangeMask.ItemsRemoved;
    this.ChangesCompleted();
  }

  public MonitoredItem FindItemByClientHandle(uint clientHandle)
  {
    lock (this.m_cache)
    {
      MonitoredItem monitoredItem = (MonitoredItem) null;
      return this.m_monitoredItems.TryGetValue(clientHandle, out monitoredItem) ? monitoredItem : (MonitoredItem) null;
    }
  }

  public bool ConditionRefresh()
  {
    this.VerifySubscriptionState(true);
    try
    {
      this.m_session.Call(ObjectTypeIds.ConditionType, MethodIds.ConditionType_ConditionRefresh, (object) this.m_id);
      return true;
    }
    catch (ServiceResultException ex)
    {
      object[] objArray = new object[1]
      {
        (object) this.m_id
      };
      Opc.Ua.Utils.LogError((Exception) ex, "SubscriptionId {0}: Failed to call ConditionRefresh on server", objArray);
    }
    return false;
  }

  public bool ResendData()
  {
    this.VerifySubscriptionState(true);
    try
    {
      this.m_session.Call(ObjectIds.Server, MethodIds.Server_ResendData, (object) this.m_id);
      return true;
    }
    catch (ServiceResultException ex)
    {
      object[] objArray = new object[1]
      {
        (object) this.m_id
      };
      Opc.Ua.Utils.LogError((Exception) ex, "SubscriptionId {0}: Failed to call ResendData on server", objArray);
    }
    return false;
  }

  private void ProcessTransferredSequenceNumbers(UInt32Collection availableSequenceNumbers)
  {
    lock (this.m_cache)
    {
      this.m_lastSequenceNumberProcessed = 0U;
      this.m_resyncLastSequenceNumberProcessed = true;
      this.m_incomingMessages = new LinkedList<Subscription.IncomingMessage>();
      this.m_availableSequenceNumbers = (IList<uint>) availableSequenceNumbers.MemberwiseClone();
      if (availableSequenceNumbers.Count == 0 || !this.m_republishAfterTransfer)
        return;
      if (this.m_incomingMessages == null)
        this.m_incomingMessages = new LinkedList<Subscription.IncomingMessage>();
      foreach (uint availableSequenceNumber in (List<uint>) availableSequenceNumbers)
      {
        if (availableSequenceNumber >= this.m_lastSequenceNumberProcessed)
          this.m_lastSequenceNumberProcessed = availableSequenceNumber + 1U;
      }
      Opc.Ua.Utils.LogInfo("SubscriptionId {0}: Republishing {1} messages, next sequencenumber {2} after transfer.", (object) this.m_id, (object) availableSequenceNumbers.Count, (object) this.m_lastSequenceNumberProcessed);
      DateTime utcNow = DateTime.UtcNow.AddSeconds(-5.0);
      foreach (uint availableSequenceNumber in (List<uint>) availableSequenceNumbers)
        this.FindOrCreateEntry(utcNow, availableSequenceNumber);
      availableSequenceNumbers.Clear();
    }
  }

  private bool GetMonitoredItems(
    out UInt32Collection serverHandles,
    out UInt32Collection clientHandles)
  {
    serverHandles = new UInt32Collection();
    clientHandles = new UInt32Collection();
    try
    {
      IList<object> objectList = this.m_session.Call(ObjectIds.Server, MethodIds.Server_GetMonitoredItems, (object) this.m_transferId);
      if (objectList != null)
      {
        if (objectList.Count == 2)
        {
          serverHandles.AddRange((IEnumerable<uint>) (uint[]) objectList[0]);
          clientHandles.AddRange((IEnumerable<uint>) (uint[]) objectList[1]);
          return true;
        }
      }
    }
    catch (ServiceResultException ex)
    {
      object[] objArray = new object[1]
      {
        (object) this.m_id
      };
      Opc.Ua.Utils.LogError((Exception) ex, "SubscriptionId {0}: Failed to call GetMonitoredItems on server", objArray);
    }
    return false;
  }

  private async Task<(bool, UInt32Collection, UInt32Collection)> GetMonitoredItemsAsync(
    CancellationToken ct = default (CancellationToken))
  {
    UInt32Collection serverHandles = new UInt32Collection();
    UInt32Collection clientHandles = new UInt32Collection();
    try
    {
      IList<object> objectList = await this.m_session.CallAsync(ObjectIds.Server, MethodIds.Server_GetMonitoredItems, ct, (object) this.m_transferId).ConfigureAwait(false);
      if (objectList != null)
      {
        if (objectList.Count == 2)
        {
          serverHandles.AddRange((IEnumerable<uint>) (uint[]) objectList[0]);
          clientHandles.AddRange((IEnumerable<uint>) (uint[]) objectList[1]);
          return (true, serverHandles, clientHandles);
        }
      }
    }
    catch (ServiceResultException ex)
    {
      object[] objArray = new object[1]
      {
        (object) this.m_id
      };
      Opc.Ua.Utils.LogError((Exception) ex, "SubscriptionId {0}: Failed to call GetMonitoredItems on server", objArray);
    }
    return (false, serverHandles, clientHandles);
  }

  private void StartKeepAliveTimer()
  {
    int num;
    lock (this.m_cache)
    {
      Opc.Ua.Utils.SilentDispose((IDisposable) this.m_publishTimer);
      this.m_publishTimer = (Timer) null;
      this.m_lastNotificationTime = DateTime.UtcNow;
      num = (int) Math.Min(this.m_currentPublishingInterval * (double) this.m_currentKeepAliveCount, (double) int.MaxValue);
      this.m_publishTimer = new Timer(new TimerCallback(this.OnKeepAlive), (object) num, num, num);
      if (this.m_messageWorkerTask != null)
      {
        if (!this.m_messageWorkerTask.IsCompleted)
          goto label_7;
      }
      this.m_messageWorkerShutdownEvent.Reset();
      this.m_messageWorkerTask = Task.Run((Func<Task>) (() => this.PublishResponseMessageWorkerAsync()));
    }
label_7:
    this.m_session.BeginPublish(Math.Min(num, 715827882) * 3);
  }

  private void OnKeepAlive(object state)
  {
    PublishStateChangedEventHandler changedEventHandler = (PublishStateChangedEventHandler) null;
    lock (this.m_cache)
    {
      if (!this.PublishingStopped)
        return;
      changedEventHandler = this.m_publishStatusChanged;
      ++this.m_publishLateCount;
    }
    this.TraceState("PUBLISHING STOPPED");
    if (changedEventHandler != null)
    {
      try
      {
        changedEventHandler(this, new PublishStateChangedEventArgs(PublishStateChangedMask.Stopped));
      }
      catch (Exception ex)
      {
        object[] objArray = Array.Empty<object>();
        Opc.Ua.Utils.LogError(ex, "Error while raising PublishStateChanged event.", objArray);
      }
    }
    this.m_session?.BeginPublish(Math.Min((int) Math.Min(this.m_currentPublishingInterval * (double) this.m_currentKeepAliveCount, (double) int.MaxValue), 715827882) * 3);
  }

  private async Task PublishResponseMessageWorkerAsync()
  {
    try
    {
      Opc.Ua.Utils.LogTrace("SubscriptionId {0} - Publish Thread {1:X8} Started.", (object) this.m_id, (object) Environment.CurrentManagedThreadId);
      ConfiguredTaskAwaitable.ConfiguredTaskAwaiter awaiter;
      while (true)
      {
        ConfiguredTaskAwaitable configuredTaskAwaitable = this.m_messageWorkerEvent.WaitAsync().ConfigureAwait(false);
        awaiter = configuredTaskAwaitable.GetAwaiter();
        if (awaiter.IsCompleted)
        {
          awaiter.GetResult();
          if (!this.m_messageWorkerShutdownEvent.WaitOne(0))
          {
            configuredTaskAwaitable = this.OnMessageReceivedAsync(CancellationToken.None).ConfigureAwait(false);
            awaiter = configuredTaskAwaitable.GetAwaiter();
            if (awaiter.IsCompleted)
              awaiter.GetResult();
            else
              goto label_7;
          }
          else
            break;
        }
        else
          goto label_8;
      }
      Opc.Ua.Utils.LogTrace("SubscriptionId {0} - Publish Thread {1:X8} Exited Normally.", (object) this.m_id, (object) Environment.CurrentManagedThreadId);
      return;
label_7:
      int num = 1;
      // ISSUE: explicit reference operation
      // ISSUE: reference to a compiler-generated field
      (^this).\u003C\u003E1__state = 1;
      ConfiguredTaskAwaitable.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
      // ISSUE: explicit reference operation
      // ISSUE: reference to a compiler-generated field
      (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable.ConfiguredTaskAwaiter, Subscription.\u003CPublishResponseMessageWorkerAsync\u003Ed__148>(ref awaiter, this);
      return;
label_8:
      num = 0;
      // ISSUE: explicit reference operation
      // ISSUE: reference to a compiler-generated field
      (^this).\u003C\u003E1__state = 0;
      configuredTaskAwaiter = awaiter;
      // ISSUE: explicit reference operation
      // ISSUE: reference to a compiler-generated field
      (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable.ConfiguredTaskAwaiter, Subscription.\u003CPublishResponseMessageWorkerAsync\u003Ed__148>(ref awaiter, this);
    }
    catch (Exception ex)
    {
      object[] objArray = new object[2]
      {
        (object) this.m_id,
        (object) Environment.CurrentManagedThreadId
      };
      Opc.Ua.Utils.LogError(ex, "SubscriptionId {0} - Publish Worker Thread {1:X8} Exited Unexpectedly.", objArray);
    }
  }

  internal void TraceState(string context)
  {
    OpcUaClientEventSource eventLog = CoreClientUtils.EventLog;
    string context1 = context;
    int id = (int) this.m_id;
    DateTime notificationTime = this.m_lastNotificationTime;
    ISession session = this.m_session;
    int publishRequestCount = session != null ? session.GoodPublishRequestCount : 0;
    double publishingInterval = this.m_currentPublishingInterval;
    int currentKeepAliveCount = (int) this.m_currentKeepAliveCount;
    int num = this.m_currentPublishingEnabled ? 1 : 0;
    int monitoredItemCount = (int) this.MonitoredItemCount;
    eventLog.SubscriptionState(context1, (uint) id, notificationTime, publishRequestCount, publishingInterval, (uint) currentKeepAliveCount, num != 0, (uint) monitoredItemCount);
  }

  private void ModifySubscription(
    double revisedPublishingInterval,
    uint revisedKeepAliveCount,
    uint revisedLifetimeCounter)
  {
    this.CreateOrModifySubscription(false, 0U, revisedPublishingInterval, revisedKeepAliveCount, revisedLifetimeCounter);
  }

  private void CreateSubscription(
    uint subscriptionId,
    double revisedPublishingInterval,
    uint revisedKeepAliveCount,
    uint revisedLifetimeCounter)
  {
    this.CreateOrModifySubscription(true, subscriptionId, revisedPublishingInterval, revisedKeepAliveCount, revisedLifetimeCounter);
  }

  private void CreateOrModifySubscription(
    bool created,
    uint subscriptionId,
    double revisedPublishingInterval,
    uint revisedKeepAliveCount,
    uint revisedLifetimeCounter)
  {
    this.m_currentPublishingInterval = revisedPublishingInterval;
    this.m_currentKeepAliveCount = revisedKeepAliveCount;
    this.m_currentLifetimeCount = revisedLifetimeCounter;
    this.m_currentPriority = this.m_priority;
    if (!created)
    {
      this.m_changeMask |= SubscriptionChangeMask.Modified;
    }
    else
    {
      this.m_currentPublishingEnabled = this.m_publishingEnabled;
      this.m_transferId = this.m_id = subscriptionId;
      this.StartKeepAliveTimer();
      this.m_changeMask |= SubscriptionChangeMask.Created;
    }
    if ((int) this.m_keepAliveCount != (int) revisedKeepAliveCount)
      Opc.Ua.Utils.LogInfo("For subscription {0}, Keep alive count was revised from {1} to {2}", (object) this.Id, (object) this.m_keepAliveCount, (object) revisedKeepAliveCount);
    if ((int) this.m_lifetimeCount != (int) revisedLifetimeCounter)
      Opc.Ua.Utils.LogInfo("For subscription {0}, Lifetime count was revised from {1} to {2}", (object) this.Id, (object) this.m_lifetimeCount, (object) revisedLifetimeCounter);
    if ((double) this.m_publishingInterval != revisedPublishingInterval)
      Opc.Ua.Utils.LogInfo("For subscription {0}, Publishing interval was revised from {1} to {2}", (object) this.Id, (object) this.m_publishingInterval, (object) revisedPublishingInterval);
    if (revisedLifetimeCounter < revisedKeepAliveCount * 3U)
      Opc.Ua.Utils.LogInfo("For subscription {0}, Revised lifetime counter (value={1}) is less than three times the keep alive count (value={2})", (object) this.Id, (object) revisedLifetimeCounter, (object) revisedKeepAliveCount);
    if (this.m_currentPriority != (byte) 0)
      return;
    Opc.Ua.Utils.LogInfo("For subscription {0}, the priority was set to 0.", (object) this.Id);
  }

  private void DeleteSubscription()
  {
    this.m_id = 0U;
    this.m_transferId = 0U;
    this.m_currentPublishingInterval = 0.0;
    this.m_currentKeepAliveCount = 0U;
    this.m_currentPublishingEnabled = false;
    this.m_currentPriority = (byte) 0;
    lock (this.m_cache)
    {
      foreach (MonitoredItem monitoredItem in this.m_monitoredItems.Values)
        monitoredItem.SetDeleteResult((StatusCode) 0U, -1, (DiagnosticInfoCollection) null, (ResponseHeader) null);
    }
    this.m_deletedItems.Clear();
    this.m_changeMask |= SubscriptionChangeMask.Deleted;
  }

  private void AdjustCounts(ref uint keepAliveCount, ref uint lifetimeCount)
  {
    if (keepAliveCount == 0U)
    {
      Opc.Ua.Utils.LogInfo("Adjusted KeepAliveCount from value={0}, to value={1}, for subscription {2}.", (object) keepAliveCount, (object) 10U, (object) this.Id);
      keepAliveCount = 10U;
    }
    if (this.m_publishingInterval > 0)
    {
      if (this.m_minLifetimeInterval > 0U && (double) this.m_minLifetimeInterval < this.m_session.SessionTimeout)
        Opc.Ua.Utils.LogWarning("A smaller minLifetimeInterval {0}ms than session timeout {1}ms configured for subscription {2}.", (object) this.m_minLifetimeInterval, (object) this.m_session.SessionTimeout, (object) this.Id);
      uint num = (uint) ((ulong) this.m_minLifetimeInterval / (ulong) this.m_publishingInterval);
      if (lifetimeCount < num)
      {
        lifetimeCount = num;
        if ((long) this.m_minLifetimeInterval % (long) this.m_publishingInterval != 0L)
          ++lifetimeCount;
        Opc.Ua.Utils.LogInfo("Adjusted LifetimeCount to value={0}, for subscription {1}. ", (object) lifetimeCount, (object) this.Id);
      }
      if ((double) ((long) lifetimeCount * (long) this.m_publishingInterval) < this.m_session.SessionTimeout)
        Opc.Ua.Utils.LogWarning("Lifetime {0}ms configured for subscription {1} is less than session timeout {2}ms.", (object) ((long) lifetimeCount * (long) this.m_publishingInterval), (object) this.Id, (object) this.m_session.SessionTimeout);
    }
    else if (lifetimeCount == 0U)
    {
      Opc.Ua.Utils.LogInfo("Adjusted LifetimeCount from value={0}, to value={1}, for subscription {2}. ", (object) lifetimeCount, (object) 1000U, (object) this.Id);
      lifetimeCount = 1000U;
    }
    uint num1 = 3U * keepAliveCount;
    if (lifetimeCount >= num1)
      return;
    Opc.Ua.Utils.LogInfo("Adjusted LifetimeCount from value={0}, to value={1}, for subscription {2}. ", (object) lifetimeCount, (object) num1, (object) this.Id);
    lifetimeCount = num1;
  }

  private async Task OnMessageReceivedAsync(CancellationToken ct)
  {
    Subscription subscription = this;
    try
    {
      Interlocked.Increment(ref subscription.m_outstandingMessageWorkers);
      ISession session = (ISession) null;
      uint subscriptionId = 0;
      PublishStateChangedEventHandler changedEventHandler = (PublishStateChangedEventHandler) null;
      List<NotificationMessage> notificationMessageList = (List<NotificationMessage>) null;
      List<Subscription.IncomingMessage> incomingMessageList = (List<Subscription.IncomingMessage>) null;
      List<Subscription.IncomingMessage> messagesToRepublish = (List<Subscription.IncomingMessage>) null;
      PublishStateChangedMask changeMask = PublishStateChangedMask.None;
      lock (subscription.m_cache)
      {
        for (LinkedListNode<Subscription.IncomingMessage> linkedListNode = subscription.m_incomingMessages.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
        {
          if (linkedListNode.Value.Message != null && !linkedListNode.Value.Processed && (!subscription.m_sequentialPublishing || subscription.ValidSequentialPublishMessage(linkedListNode.Value)))
          {
            if (notificationMessageList == null)
              notificationMessageList = new List<NotificationMessage>();
            notificationMessageList.Add(linkedListNode.Value.Message);
            while (subscription.m_messageCache.Count > subscription.m_maxMessageCount)
              subscription.m_messageCache.RemoveFirst();
            subscription.m_messageCache.AddLast(linkedListNode.Value.Message);
            linkedListNode.Value.Processed = true;
            if (linkedListNode.Value.SequenceNumber > subscription.m_lastSequenceNumberProcessed || linkedListNode.Value.SequenceNumber == 1U && subscription.m_lastSequenceNumberProcessed == uint.MaxValue)
            {
              subscription.m_lastSequenceNumberProcessed = linkedListNode.Value.SequenceNumber;
              if (subscription.m_resyncLastSequenceNumberProcessed)
              {
                Opc.Ua.Utils.LogInfo("SubscriptionId {0}: Resynced last sequence number processed to {1}.", (object) subscription.Id, (object) subscription.m_lastSequenceNumberProcessed);
                subscription.m_resyncLastSequenceNumberProcessed = false;
              }
            }
          }
          else if (linkedListNode.Next == null && linkedListNode.Value.Message == null && !linkedListNode.Value.Processed)
          {
            if (incomingMessageList == null)
              incomingMessageList = new List<Subscription.IncomingMessage>();
            incomingMessageList.Add(linkedListNode.Value);
            changeMask |= PublishStateChangedMask.KeepAlive;
          }
          else if (linkedListNode.Next != null && linkedListNode.Value.Message == null && !linkedListNode.Value.Processed && !linkedListNode.Value.Republished && linkedListNode.Value.Timestamp.AddSeconds(2.0) < DateTime.UtcNow)
          {
            if (messagesToRepublish == null)
              messagesToRepublish = new List<Subscription.IncomingMessage>();
            messagesToRepublish.Add(linkedListNode.Value);
            linkedListNode.Value.Republished = true;
            changeMask |= PublishStateChangedMask.Republish;
          }
        }
        session = subscription.m_session;
        subscriptionId = subscription.m_id;
        changedEventHandler = subscription.m_publishStatusChanged;
      }
      FastKeepAliveNotificationEventHandler keepAliveCallback = subscription.m_fastKeepAliveCallback;
      if (incomingMessageList != null && keepAliveCallback != null)
      {
        foreach (Subscription.IncomingMessage incomingMessage in incomingMessageList)
        {
          NotificationData notification = new NotificationData()
          {
            PublishTime = incomingMessage.Timestamp,
            SequenceNumber = incomingMessage.SequenceNumber
          };
          keepAliveCallback(subscription, notification);
        }
      }
      if (notificationMessageList != null)
      {
        FastDataChangeNotificationEventHandler dataChangeCallback = subscription.m_fastDataChangeCallback;
        FastEventNotificationEventHandler fastEventCallback = subscription.m_fastEventCallback;
        foreach (NotificationMessage message in notificationMessageList)
        {
          int num = 0;
          try
          {
            foreach (ExtensionObject extensionObject in (List<ExtensionObject>) message.NotificationData)
            {
              if (extensionObject.Body is DataChangeNotification body1)
              {
                body1.PublishTime = message.PublishTime;
                body1.SequenceNumber = message.SequenceNumber;
                num += body1.MonitoredItems.Count;
                if (!subscription.m_disableMonitoredItemCache)
                  subscription.SaveDataChange(message, body1, (IList<string>) message.StringTable);
                if (dataChangeCallback != null)
                  dataChangeCallback(subscription, body1, (IList<string>) message.StringTable);
              }
              if (extensionObject.Body is EventNotificationList body2)
              {
                body2.PublishTime = message.PublishTime;
                body2.SequenceNumber = message.SequenceNumber;
                num += body2.Events.Count;
                if (!subscription.m_disableMonitoredItemCache)
                  subscription.SaveEvents(message, body2, (IList<string>) message.StringTable);
                if (fastEventCallback != null)
                  fastEventCallback(subscription, body2, (IList<string>) message.StringTable);
              }
              if (extensionObject.Body is StatusChangeNotification body3)
              {
                body3.PublishTime = message.PublishTime;
                body3.SequenceNumber = message.SequenceNumber;
                Opc.Ua.Utils.LogWarning("StatusChangeNotification received with Status = {0} for SubscriptionId={1}.", (object) body3.Status.ToString(), (object) subscription.Id);
                if (body3.Status == 2949120U /*0x2D0000*/)
                {
                  changeMask |= PublishStateChangedMask.Transferred;
                  subscription.ResetPublishTimerAndWorkerState();
                }
                else if (body3.Status == 2148139008U /*0x800A0000*/)
                  changeMask |= PublishStateChangedMask.Timeout;
              }
            }
          }
          catch (Exception ex)
          {
            object[] objArray = new object[1]
            {
              (object) message.SequenceNumber
            };
            Opc.Ua.Utils.LogError(ex, "Error while processing incoming message #{0}.", objArray);
          }
          if (subscription.MaxNotificationsPerPublish != 0U && (long) num > (long) subscription.MaxNotificationsPerPublish)
            Opc.Ua.Utils.LogWarning("For subscription {0}, more notifications were received={1} than the max notifications per publish value={2}", (object) subscription.Id, (object) num, (object) subscription.MaxNotificationsPerPublish);
        }
        if (changedEventHandler != null)
        {
          if (changeMask != PublishStateChangedMask.None)
          {
            try
            {
              changedEventHandler(subscription, new PublishStateChangedEventArgs(changeMask));
            }
            catch (Exception ex)
            {
              object[] objArray = Array.Empty<object>();
              Opc.Ua.Utils.LogError(ex, "Error while raising PublishStateChanged event.", objArray);
            }
          }
        }
      }
      if (messagesToRepublish != null && session != null && subscriptionId != 0U)
      {
        for (int ii = 0; ii < messagesToRepublish.Count; ++ii)
        {
          if (await session.RepublishAsync(subscriptionId, messagesToRepublish[ii].SequenceNumber, ct).ConfigureAwait(false))
            continue;
          messagesToRepublish[ii].Republished = false;
        }
      }
      session = (ISession) null;
      messagesToRepublish = (List<Subscription.IncomingMessage>) null;
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      Opc.Ua.Utils.LogError(ex, "Error while processing incoming messages.", objArray);
    }
    finally
    {
      Interlocked.Decrement(ref subscription.m_outstandingMessageWorkers);
    }
  }

  private void VerifySubscriptionState(bool created)
  {
    if (created && this.m_id == 0U)
      throw new ServiceResultException(2158952448U /*0x80AF0000*/, "Subscription has not been created.");
    if (!created && this.m_id != 0U)
      throw new ServiceResultException(2158952448U /*0x80AF0000*/, "Subscription has alredy been created.");
  }

  private bool ValidSequentialPublishMessage(Subscription.IncomingMessage message)
  {
    if (message.SequenceNumber <= this.m_lastSequenceNumberProcessed + 1U || this.m_resyncLastSequenceNumberProcessed)
      return true;
    return message.SequenceNumber == 1U && this.m_lastSequenceNumberProcessed == uint.MaxValue;
  }

  private bool UpdateMonitoringMode(
    IList<MonitoredItem> monitoredItems,
    IList<ServiceResult> errors,
    StatusCodeCollection results,
    DiagnosticInfoCollection diagnosticInfos,
    ResponseHeader responseHeader,
    MonitoringMode monitoringMode)
  {
    bool flag = true;
    for (int index = 0; index < results.Count; ++index)
    {
      ServiceResult serviceResult = (ServiceResult) null;
      if (StatusCode.IsBad(results[index]))
      {
        serviceResult = ClientBase.GetResult(results[index], index, diagnosticInfos, responseHeader);
        flag = false;
      }
      else
      {
        monitoredItems[index].MonitoringMode = monitoringMode;
        monitoredItems[index].Status.SetMonitoringMode(monitoringMode);
      }
      errors.Add(serviceResult);
    }
    return flag;
  }

  private MonitoredItemCreateRequestCollection PrepareItemsToCreate(
    out List<MonitoredItem> itemsToCreate)
  {
    this.VerifySubscriptionState(true);
    this.ResolveItemNodeIds();
    MonitoredItemCreateRequestCollection create = new MonitoredItemCreateRequestCollection();
    itemsToCreate = new List<MonitoredItem>();
    lock (this.m_cache)
    {
      foreach (MonitoredItem monitoredItem in this.m_monitoredItems.Values)
      {
        if (!monitoredItem.Status.Created)
        {
          MonitoredItemCreateRequest itemCreateRequest = new MonitoredItemCreateRequest();
          itemCreateRequest.ItemToMonitor.NodeId = monitoredItem.ResolvedNodeId;
          itemCreateRequest.ItemToMonitor.AttributeId = monitoredItem.AttributeId;
          itemCreateRequest.ItemToMonitor.IndexRange = monitoredItem.IndexRange;
          itemCreateRequest.ItemToMonitor.DataEncoding = monitoredItem.Encoding;
          itemCreateRequest.MonitoringMode = monitoredItem.MonitoringMode;
          itemCreateRequest.RequestedParameters.ClientHandle = monitoredItem.ClientHandle;
          itemCreateRequest.RequestedParameters.SamplingInterval = (double) monitoredItem.SamplingInterval;
          itemCreateRequest.RequestedParameters.QueueSize = monitoredItem.QueueSize;
          itemCreateRequest.RequestedParameters.DiscardOldest = monitoredItem.DiscardOldest;
          if (monitoredItem.Filter != null)
            itemCreateRequest.RequestedParameters.Filter = new ExtensionObject((object) monitoredItem.Filter);
          create.Add(itemCreateRequest);
          itemsToCreate.Add(monitoredItem);
        }
      }
    }
    return create;
  }

  private void PrepareItemsToModify(
    MonitoredItemModifyRequestCollection requestItems,
    IList<MonitoredItem> itemsToModify)
  {
    lock (this.m_cache)
    {
      foreach (MonitoredItem monitoredItem in this.m_monitoredItems.Values)
      {
        if (monitoredItem.Status.Created && monitoredItem.AttributesModified)
        {
          MonitoredItemModifyRequest itemModifyRequest = new MonitoredItemModifyRequest();
          itemModifyRequest.MonitoredItemId = monitoredItem.Status.Id;
          itemModifyRequest.RequestedParameters.ClientHandle = monitoredItem.ClientHandle;
          itemModifyRequest.RequestedParameters.SamplingInterval = (double) monitoredItem.SamplingInterval;
          itemModifyRequest.RequestedParameters.QueueSize = monitoredItem.QueueSize;
          itemModifyRequest.RequestedParameters.DiscardOldest = monitoredItem.DiscardOldest;
          if (monitoredItem.Filter != null)
            itemModifyRequest.RequestedParameters.Filter = new ExtensionObject((object) monitoredItem.Filter);
          requestItems.Add(itemModifyRequest);
          itemsToModify.Add(monitoredItem);
        }
      }
    }
  }

  private void TransferItems(
    UInt32Collection serverHandles,
    UInt32Collection clientHandles,
    out IList<MonitoredItem> itemsToModify)
  {
    lock (this.m_cache)
    {
      itemsToModify = (IList<MonitoredItem>) new List<MonitoredItem>();
      SortedDictionary<uint, MonitoredItem> sortedDictionary = new SortedDictionary<uint, MonitoredItem>();
      foreach (MonitoredItem monitoredItem1 in this.m_monitoredItems.Values)
      {
        MonitoredItem monitoredItem = monitoredItem1;
        int index = serverHandles.FindIndex((Predicate<uint>) (handle => (int) handle == (int) monitoredItem.Status.Id));
        if (index >= 0 && index < clientHandles.Count)
        {
          uint clientHandle = clientHandles[index];
          sortedDictionary[clientHandle] = monitoredItem;
          monitoredItem.SetTransferResult(clientHandle);
        }
        else
        {
          sortedDictionary[monitoredItem.ClientHandle] = monitoredItem;
          itemsToModify.Add(monitoredItem);
        }
      }
      this.m_monitoredItems = sortedDictionary;
    }
  }

  private void PrepareResolveItemNodeIds(
    BrowsePathCollection browsePaths,
    IList<MonitoredItem> itemsToBrowse)
  {
    lock (this.m_cache)
    {
      foreach (MonitoredItem monitoredItem in this.m_monitoredItems.Values)
      {
        if (!string.IsNullOrEmpty(monitoredItem.RelativePath) && NodeId.IsNull(monitoredItem.ResolvedNodeId))
        {
          if (monitoredItem.Created)
            throw new ServiceResultException(2158952448U /*0x80AF0000*/, "Cannot modify item path after it is created.");
          BrowsePath browsePath = new BrowsePath();
          browsePath.StartingNode = monitoredItem.StartNodeId;
          try
          {
            browsePath.RelativePath = RelativePath.Parse(monitoredItem.RelativePath, this.m_session.TypeTree);
          }
          catch (Exception ex)
          {
            monitoredItem.SetError(new ServiceResult(ex));
            continue;
          }
          browsePaths.Add(browsePath);
          itemsToBrowse.Add(monitoredItem);
        }
      }
    }
  }

  private void SaveDataChange(
    NotificationMessage message,
    DataChangeNotification notifications,
    IList<string> stringTable)
  {
    if (notifications.MonitoredItems != null && notifications.MonitoredItems.Count != 0)
    {
      for (int index = 0; index < notifications.MonitoredItems.Count; ++index)
      {
        MonitoredItemNotification monitoredItem1 = notifications.MonitoredItems[index];
        MonitoredItem monitoredItem2 = (MonitoredItem) null;
        lock (this.m_cache)
        {
          if (!this.m_monitoredItems.TryGetValue(monitoredItem1.ClientHandle, out monitoredItem2))
          {
            Opc.Ua.Utils.LogWarning("Publish response contains invalid MonitoredItem. SubscriptionId = {0}, ClientHandle = {1}", (object) this.m_id, (object) monitoredItem1.ClientHandle);
            continue;
          }
        }
        monitoredItem1.Message = message;
        if (notifications.DiagnosticInfos.Count > index)
          monitoredItem1.DiagnosticInfo = notifications.DiagnosticInfos[index];
        monitoredItem2.SaveValueInCache((IEncodeable) monitoredItem1);
      }
    }
    else
      Opc.Ua.Utils.LogInfo("Publish response contains empty MonitoredItems list for SubscriptionId = {0}.", (object) this.m_id);
  }

  private void SaveEvents(
    NotificationMessage message,
    EventNotificationList notifications,
    IList<string> stringTable)
  {
    for (int index = 0; index < notifications.Events.Count; ++index)
    {
      EventFieldList newValue = notifications.Events[index];
      MonitoredItem monitoredItem = (MonitoredItem) null;
      lock (this.m_cache)
      {
        if (!this.m_monitoredItems.TryGetValue(newValue.ClientHandle, out monitoredItem))
        {
          Opc.Ua.Utils.LogWarning("Publish response contains invalid MonitoredItem.SubscriptionId = {0}, ClientHandle = {1}", (object) this.m_id, (object) newValue.ClientHandle);
          continue;
        }
      }
      newValue.Message = message;
      monitoredItem.SaveValueInCache((IEncodeable) newValue);
    }
  }

  private Subscription.IncomingMessage FindOrCreateEntry(DateTime utcNow, uint sequenceNumber)
  {
    Subscription.IncomingMessage orCreateEntry = (Subscription.IncomingMessage) null;
    LinkedListNode<Subscription.IncomingMessage> node = this.m_incomingMessages.Last;
    while (node != null)
    {
      orCreateEntry = node.Value;
      LinkedListNode<Subscription.IncomingMessage> previous = node.Previous;
      if ((int) orCreateEntry.SequenceNumber != (int) sequenceNumber)
      {
        if (orCreateEntry.SequenceNumber >= sequenceNumber)
        {
          node = previous;
          orCreateEntry = (Subscription.IncomingMessage) null;
        }
        else
        {
          orCreateEntry = new Subscription.IncomingMessage();
          orCreateEntry.SequenceNumber = sequenceNumber;
          orCreateEntry.Timestamp = utcNow;
          this.m_incomingMessages.AddAfter(node, orCreateEntry);
          break;
        }
      }
      else
      {
        orCreateEntry.Timestamp = utcNow;
        break;
      }
    }
    if (orCreateEntry == null)
    {
      orCreateEntry = new Subscription.IncomingMessage();
      orCreateEntry.SequenceNumber = sequenceNumber;
      orCreateEntry.Timestamp = utcNow;
      this.m_incomingMessages.AddLast(orCreateEntry);
    }
    return orCreateEntry;
  }

  private event SubscriptionStateChangedEventHandler m_StateChanged;

  private event PublishStateChangedEventHandler m_publishStatusChanged;

  public async Task CreateAsync(CancellationToken ct = default (CancellationToken))
  {
    this.VerifySubscriptionState(false);
    uint keepAliveCount = this.m_keepAliveCount;
    uint lifetimeCount = this.m_lifetimeCount;
    this.AdjustCounts(ref keepAliveCount, ref lifetimeCount);
    CreateSubscriptionResponse subscriptionResponse = await this.m_session.CreateSubscriptionAsync((RequestHeader) null, (double) this.m_publishingInterval, lifetimeCount, keepAliveCount, this.m_maxNotificationsPerPublish, this.m_publishingEnabled, this.m_priority, ct).ConfigureAwait(false);
    this.CreateSubscription(subscriptionResponse.SubscriptionId, subscriptionResponse.RevisedPublishingInterval, subscriptionResponse.RevisedMaxKeepAliveCount, subscriptionResponse.RevisedLifetimeCount);
    IList<MonitoredItem> monitoredItemList = await this.CreateItemsAsync(ct).ConfigureAwait(false);
    this.ChangesCompleted();
  }

  public async Task DeleteAsync(bool silent, CancellationToken ct = default (CancellationToken))
  {
    if (!silent)
      this.VerifySubscriptionState(true);
    if (!this.Created)
      return;
    try
    {
      lock (this.m_cache)
      {
        Opc.Ua.Utils.SilentDispose((IDisposable) this.m_publishTimer);
        this.m_publishTimer = (Timer) null;
        this.m_messageWorkerEvent.Set();
        this.m_messageWorkerTask = (Task) null;
      }
      UInt32Collection subscriptionIds = (UInt32Collection) new uint[1]
      {
        this.m_id
      };
      DeleteSubscriptionsResponse subscriptionsResponse = await this.m_session.DeleteSubscriptionsAsync((RequestHeader) null, subscriptionIds, ct).ConfigureAwait(false);
      ClientBase.ValidateResponse((IList) subscriptionsResponse.Results, (IList) subscriptionIds);
      ClientBase.ValidateDiagnosticInfos(subscriptionsResponse.DiagnosticInfos, (IList) subscriptionIds);
      if (StatusCode.IsBad(subscriptionsResponse.Results[0]))
        throw new ServiceResultException(ClientBase.GetResult(subscriptionsResponse.Results[0], 0, subscriptionsResponse.DiagnosticInfos, subscriptionsResponse.ResponseHeader));
      subscriptionIds = (UInt32Collection) null;
    }
    catch (Exception ex)
    {
      if (!silent)
        throw new ServiceResultException(ex, 2147549184U /*0x80010000*/);
    }
    finally
    {
      this.DeleteSubscription();
    }
    this.ChangesCompleted();
  }

  public async Task ModifyAsync(CancellationToken ct = default (CancellationToken))
  {
    this.VerifySubscriptionState(true);
    uint keepAliveCount = this.m_keepAliveCount;
    uint lifetimeCount = this.m_lifetimeCount;
    this.AdjustCounts(ref keepAliveCount, ref lifetimeCount);
    ModifySubscriptionResponse subscriptionResponse = await this.m_session.ModifySubscriptionAsync((RequestHeader) null, this.m_id, (double) this.m_publishingInterval, lifetimeCount, keepAliveCount, this.m_maxNotificationsPerPublish, this.m_priority, ct).ConfigureAwait(false);
    this.ModifySubscription(subscriptionResponse.RevisedPublishingInterval, subscriptionResponse.RevisedMaxKeepAliveCount, subscriptionResponse.RevisedLifetimeCount);
    this.ChangesCompleted();
  }

  public async Task SetPublishingModeAsync(bool enabled, CancellationToken ct = default (CancellationToken))
  {
    this.VerifySubscriptionState(true);
    UInt32Collection subscriptionIds = (UInt32Collection) new uint[1]
    {
      this.m_id
    };
    SetPublishingModeResponse publishingModeResponse = await this.m_session.SetPublishingModeAsync((RequestHeader) null, (enabled ? 1 : 0) != 0, (UInt32Collection) new uint[1]
    {
      this.m_id
    }, ct).ConfigureAwait(false);
    ClientBase.ValidateResponse((IList) publishingModeResponse.Results, (IList) subscriptionIds);
    ClientBase.ValidateDiagnosticInfos(publishingModeResponse.DiagnosticInfos, (IList) subscriptionIds);
    if (StatusCode.IsBad(publishingModeResponse.Results[0]))
      throw new ServiceResultException(ClientBase.GetResult(publishingModeResponse.Results[0], 0, publishingModeResponse.DiagnosticInfos, publishingModeResponse.ResponseHeader));
    this.m_currentPublishingEnabled = this.m_publishingEnabled = enabled;
    this.m_changeMask |= SubscriptionChangeMask.Modified;
    this.ChangesCompleted();
    subscriptionIds = (UInt32Collection) null;
  }

  public async Task<NotificationMessage> RepublishAsync(uint sequenceNumber, CancellationToken ct = default (CancellationToken))
  {
    this.VerifySubscriptionState(true);
    return (await this.m_session.RepublishAsync((RequestHeader) null, this.m_id, sequenceNumber, ct).ConfigureAwait(false)).NotificationMessage;
  }

  public async Task ApplyChangesAsync(CancellationToken ct = default (CancellationToken))
  {
    ConfiguredTaskAwaitable<IList<MonitoredItem>> configuredTaskAwaitable = this.DeleteItemsAsync(ct).ConfigureAwait(false);
    IList<MonitoredItem> monitoredItemList1 = await configuredTaskAwaitable;
    configuredTaskAwaitable = this.ModifyItemsAsync(ct).ConfigureAwait(false);
    IList<MonitoredItem> monitoredItemList2 = await configuredTaskAwaitable;
    configuredTaskAwaitable = this.CreateItemsAsync(ct).ConfigureAwait(false);
    IList<MonitoredItem> monitoredItemList3 = await configuredTaskAwaitable;
  }

  public async Task ResolveItemNodeIdsAsync(CancellationToken ct)
  {
    this.VerifySubscriptionState(true);
    BrowsePathCollection browsePaths = new BrowsePathCollection();
    List<MonitoredItem> itemsToBrowse = new List<MonitoredItem>();
    this.PrepareResolveItemNodeIds(browsePaths, (IList<MonitoredItem>) itemsToBrowse);
    if (browsePaths.Count == 0)
    {
      browsePaths = (BrowsePathCollection) null;
      itemsToBrowse = (List<MonitoredItem>) null;
    }
    else
    {
      TranslateBrowsePathsToNodeIdsResponse toNodeIdsResponse = await this.m_session.TranslateBrowsePathsToNodeIdsAsync((RequestHeader) null, browsePaths, ct).ConfigureAwait(false);
      BrowsePathResultCollection results = toNodeIdsResponse.Results;
      ClientBase.ValidateResponse((IList) results, (IList) browsePaths);
      ClientBase.ValidateDiagnosticInfos(toNodeIdsResponse.DiagnosticInfos, (IList) browsePaths);
      for (int index = 0; index < results.Count; ++index)
        itemsToBrowse[index].SetResolvePathResult(results[index], index, toNodeIdsResponse.DiagnosticInfos, toNodeIdsResponse.ResponseHeader);
      this.m_changeMask |= SubscriptionChangeMask.ItemsModified;
      browsePaths = (BrowsePathCollection) null;
      itemsToBrowse = (List<MonitoredItem>) null;
    }
  }

  public async Task<IList<MonitoredItem>> CreateItemsAsync(CancellationToken ct = default (CancellationToken))
  {
    List<MonitoredItem> itemsToCreate;
    MonitoredItemCreateRequestCollection requestItems = this.PrepareItemsToCreate(out itemsToCreate);
    if (requestItems.Count == 0)
      return (IList<MonitoredItem>) itemsToCreate;
    CreateMonitoredItemsResponse monitoredItemsResponse = await this.m_session.CreateMonitoredItemsAsync((RequestHeader) null, this.m_id, this.m_timestampsToReturn, requestItems, ct).ConfigureAwait(false);
    MonitoredItemCreateResultCollection results = monitoredItemsResponse.Results;
    ClientBase.ValidateResponse((IList) results, (IList) itemsToCreate);
    ClientBase.ValidateDiagnosticInfos(monitoredItemsResponse.DiagnosticInfos, (IList) itemsToCreate);
    for (int index = 0; index < results.Count; ++index)
      itemsToCreate[index].SetCreateResult(requestItems[index], results[index], index, monitoredItemsResponse.DiagnosticInfos, monitoredItemsResponse.ResponseHeader);
    this.m_changeMask |= SubscriptionChangeMask.ItemsCreated;
    this.ChangesCompleted();
    return (IList<MonitoredItem>) itemsToCreate;
  }

  public async Task<IList<MonitoredItem>> ModifyItemsAsync(CancellationToken ct = default (CancellationToken))
  {
    this.VerifySubscriptionState(true);
    MonitoredItemModifyRequestCollection requestItems = new MonitoredItemModifyRequestCollection();
    List<MonitoredItem> itemsToModify = new List<MonitoredItem>();
    this.PrepareItemsToModify(requestItems, (IList<MonitoredItem>) itemsToModify);
    if (requestItems.Count == 0)
      return (IList<MonitoredItem>) itemsToModify;
    ModifyMonitoredItemsResponse monitoredItemsResponse = await this.m_session.ModifyMonitoredItemsAsync((RequestHeader) null, this.m_id, this.m_timestampsToReturn, requestItems, ct).ConfigureAwait(false);
    MonitoredItemModifyResultCollection results = monitoredItemsResponse.Results;
    ClientBase.ValidateResponse((IList) results, (IList) itemsToModify);
    ClientBase.ValidateDiagnosticInfos(monitoredItemsResponse.DiagnosticInfos, (IList) itemsToModify);
    for (int index = 0; index < results.Count; ++index)
      itemsToModify[index].SetModifyResult(requestItems[index], results[index], index, monitoredItemsResponse.DiagnosticInfos, monitoredItemsResponse.ResponseHeader);
    this.m_changeMask |= SubscriptionChangeMask.ItemsModified;
    this.ChangesCompleted();
    return (IList<MonitoredItem>) itemsToModify;
  }

  public async Task<IList<MonitoredItem>> DeleteItemsAsync(CancellationToken ct)
  {
    this.VerifySubscriptionState(true);
    if (this.m_deletedItems.Count == 0)
      return (IList<MonitoredItem>) new List<MonitoredItem>();
    List<MonitoredItem> itemsToDelete = this.m_deletedItems;
    this.m_deletedItems = new List<MonitoredItem>();
    UInt32Collection monitoredItemIds = new UInt32Collection();
    foreach (MonitoredItem monitoredItem in itemsToDelete)
      monitoredItemIds.Add(monitoredItem.Status.Id);
    DeleteMonitoredItemsResponse monitoredItemsResponse = await this.m_session.DeleteMonitoredItemsAsync((RequestHeader) null, this.m_id, monitoredItemIds, ct).ConfigureAwait(false);
    StatusCodeCollection results = monitoredItemsResponse.Results;
    ClientBase.ValidateResponse((IList) results, (IList) monitoredItemIds);
    ClientBase.ValidateDiagnosticInfos(monitoredItemsResponse.DiagnosticInfos, (IList) monitoredItemIds);
    for (int index = 0; index < results.Count; ++index)
      itemsToDelete[index].SetDeleteResult(results[index], index, monitoredItemsResponse.DiagnosticInfos, monitoredItemsResponse.ResponseHeader);
    this.m_changeMask |= SubscriptionChangeMask.ItemsDeleted;
    this.ChangesCompleted();
    return (IList<MonitoredItem>) itemsToDelete;
  }

  public async Task<List<ServiceResult>> SetMonitoringModeAsync(
    MonitoringMode monitoringMode,
    IList<MonitoredItem> monitoredItems,
    CancellationToken ct = default (CancellationToken))
  {
    if (monitoredItems == null)
      throw new ArgumentNullException(nameof (monitoredItems));
    this.VerifySubscriptionState(true);
    if (monitoredItems.Count == 0)
      return (List<ServiceResult>) null;
    UInt32Collection monitoredItemIds = new UInt32Collection();
    foreach (MonitoredItem monitoredItem in (IEnumerable<MonitoredItem>) monitoredItems)
      monitoredItemIds.Add(monitoredItem.Status.Id);
    SetMonitoringModeResponse monitoringModeResponse = await this.m_session.SetMonitoringModeAsync((RequestHeader) null, this.m_id, monitoringMode, monitoredItemIds, ct).ConfigureAwait(false);
    StatusCodeCollection results = monitoringModeResponse.Results;
    ClientBase.ValidateResponse((IList) results, (IList) monitoredItemIds);
    ClientBase.ValidateDiagnosticInfos(monitoringModeResponse.DiagnosticInfos, (IList) monitoredItemIds);
    List<ServiceResult> errors = new List<ServiceResult>();
    int num = this.UpdateMonitoringMode(monitoredItems, (IList<ServiceResult>) errors, results, monitoringModeResponse.DiagnosticInfos, monitoringModeResponse.ResponseHeader, monitoringMode) ? 1 : 0;
    this.m_changeMask |= SubscriptionChangeMask.ItemsModified;
    this.ChangesCompleted();
    return num == 0 ? errors : (List<ServiceResult>) null;
  }

  public async Task ConditionRefreshAsync(CancellationToken ct = default (CancellationToken))
  {
    this.VerifySubscriptionState(true);
    CallMethodRequestCollection methodsToCall = new CallMethodRequestCollection();
    CallMethodRequestCollection requestCollection = methodsToCall;
    CallMethodRequest callMethodRequest = new CallMethodRequest();
    callMethodRequest.MethodId = MethodIds.ConditionType_ConditionRefresh;
    VariantCollection variantCollection = new VariantCollection();
    variantCollection.Add(new Opc.Ua.Variant(this.m_id));
    callMethodRequest.InputArguments = variantCollection;
    requestCollection.Add(callMethodRequest);
    CallResponse callResponse = await this.m_session.CallAsync((RequestHeader) null, methodsToCall, ct).ConfigureAwait(false);
  }

  private class IncomingMessage
  {
    public uint SequenceNumber;
    public DateTime Timestamp;
    public NotificationMessage Message;
    public bool Processed;
    public bool Republished;
  }
}
