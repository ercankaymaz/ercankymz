// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Activity
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;

#nullable disable
namespace System.Diagnostics;

[NullableContext(1)]
[Nullable(0)]
[ComVisible(true)]
public class Activity : IDisposable
{
  private static readonly IEnumerable<KeyValuePair<string, string>> s_emptyBaggageTags = (IEnumerable<KeyValuePair<string, string>>) new KeyValuePair<string, string>[0];
  private static readonly IEnumerable<KeyValuePair<string, object>> s_emptyTagObjects = (IEnumerable<KeyValuePair<string, object>>) new KeyValuePair<string, object>[0];
  private static readonly IEnumerable<ActivityLink> s_emptyLinks = (IEnumerable<ActivityLink>) new ActivityLink[0];
  private static readonly IEnumerable<ActivityEvent> s_emptyEvents = (IEnumerable<ActivityEvent>) new ActivityEvent[0];
  private static readonly ActivitySource s_defaultSource = new ActivitySource(string.Empty);
  private const byte ActivityTraceFlagsIsSet = 128 /*0x80*/;
  private const int RequestIdMaxLength = 1024 /*0x0400*/;
  private static readonly string s_uniqSuffix = $"-{Activity.GetRandomNumber().ToString("x")}.";
  private static long s_currentRootId = (long) (uint) Activity.GetRandomNumber();
  private static ActivityIdFormat s_defaultIdFormat;
  private string _traceState;
  private Activity.State _state;
  private int _currentChildId;
  private string _id;
  private string _rootId;
  private string _parentId;
  private string _parentSpanId;
  private string _traceId;
  private string _spanId;
  private byte _w3CIdFlags;
  private byte _parentTraceFlags;
  private Activity.TagsLinkedList _tags;
  private Activity.BaggageLinkedList _baggage;
  private DiagLinkedList<ActivityLink> _links;
  private DiagLinkedList<ActivityEvent> _events;
  private Dictionary<string, object> _customProperties;
  private string _displayName;
  private ActivityStatusCode _statusCode;
  private string _statusDescription;
  private Activity _previousActiveActivity;
  private static readonly AsyncLocal<Activity> s_current = new AsyncLocal<Activity>();
  private static Activity.TimeSync timeSync = new Activity.TimeSync();
  private static readonly Timer syncTimeUpdater = Activity.InitalizeSyncTimer();

  public static bool ForceDefaultIdFormat { get; set; }

  public ActivityStatusCode Status => this._statusCode;

  [Nullable(2)]
  public string StatusDescription
  {
    [NullableContext(2)] get => this._statusDescription;
  }

  public Activity SetStatus(ActivityStatusCode code, [Nullable(2)] string description = null)
  {
    this._statusCode = code;
    this._statusDescription = code == ActivityStatusCode.Error ? description : (string) null;
    return this;
  }

  public ActivityKind Kind { get; private set; }

  public string OperationName { get; }

  public string DisplayName
  {
    get => this._displayName ?? this.OperationName;
    set => this._displayName = value ?? throw new ArgumentNullException(nameof (value));
  }

  public ActivitySource Source { get; private set; }

  [Nullable(2)]
  public Activity Parent { [NullableContext(2)] get; private set; }

  public TimeSpan Duration { get; private set; }

  public DateTime StartTimeUtc { get; private set; }

  [Nullable(2)]
  public string Id
  {
    [NullableContext(2), SecuritySafeCritical] get
    {
      if (this._id == null && this._spanId != null)
      {
        Span<char> buffer = stackalloc char[2];
        HexConverter.ToCharsBuffer((byte) (4294967167U & (uint) this._w3CIdFlags), buffer, casing: HexConverter.Casing.Lower);
        Interlocked.CompareExchange<string>(ref this._id, $"00-{this._traceId}-{this._spanId}-{buffer.ToString()}", (string) null);
      }
      return this._id;
    }
  }

  [Nullable(2)]
  public string ParentId
  {
    [NullableContext(2), SecuritySafeCritical] get
    {
      if (this._parentId == null)
      {
        if (this._parentSpanId != null)
        {
          Span<char> buffer = stackalloc char[2];
          HexConverter.ToCharsBuffer((byte) (4294967167U & (uint) this._parentTraceFlags), buffer, casing: HexConverter.Casing.Lower);
          Interlocked.CompareExchange<string>(ref this._parentId, $"00-{this._traceId}-{this._parentSpanId}-{buffer.ToString()}", (string) null);
        }
        else if (this.Parent != null)
          Interlocked.CompareExchange<string>(ref this._parentId, this.Parent.Id, (string) null);
      }
      return this._parentId;
    }
  }

  [Nullable(2)]
  public string RootId
  {
    [NullableContext(2)] get
    {
      if (this._rootId == null)
      {
        string str = (string) null;
        if (this.Id != null)
          str = this.GetRootId(this.Id);
        else if (this.ParentId != null)
          str = this.GetRootId(this.ParentId);
        if (str != null)
          Interlocked.CompareExchange<string>(ref this._rootId, str, (string) null);
      }
      return this._rootId;
    }
  }

  [Nullable(new byte[] {1, 0, 1, 2})]
  public IEnumerable<KeyValuePair<string, string>> Tags
  {
    [return: Nullable(new byte[] {1, 0, 1, 2})] get
    {
      Activity.TagsLinkedList tags1 = this._tags;
      IEnumerable<KeyValuePair<string, string>> tags2;
      if (tags1 == null)
      {
        tags2 = (IEnumerable<KeyValuePair<string, string>>) null;
      }
      else
      {
        tags2 = tags1.EnumerateStringValues();
        if (tags2 != null)
          return tags2;
      }
      return Activity.s_emptyBaggageTags;
    }
  }

  [Nullable(new byte[] {1, 0, 1, 2})]
  public IEnumerable<KeyValuePair<string, object>> TagObjects
  {
    [return: Nullable(new byte[] {1, 0, 1, 2})] get
    {
      return (IEnumerable<KeyValuePair<string, object>>) this._tags ?? Activity.s_emptyTagObjects;
    }
  }

  public IEnumerable<ActivityEvent> Events
  {
    get => (IEnumerable<ActivityEvent>) this._events ?? Activity.s_emptyEvents;
  }

  public IEnumerable<ActivityLink> Links
  {
    get => (IEnumerable<ActivityLink>) this._links ?? Activity.s_emptyLinks;
  }

  [Nullable(new byte[] {1, 0, 1, 2})]
  public IEnumerable<KeyValuePair<string, string>> Baggage
  {
    [return: Nullable(new byte[] {1, 0, 1, 2})] get
    {
      for (Activity activity = this; activity != null; activity = activity.Parent)
      {
        if (activity._baggage != null)
          return Iterate(activity);
      }
      return Activity.s_emptyBaggageTags;

      static IEnumerable<KeyValuePair<string, string>> Iterate(Activity activity)
      {
        do
        {
          if (activity._baggage != null)
            goto label_3;
label_2:
          activity = activity.Parent;
          continue;
label_3:
          DiagNode<KeyValuePair<string, string>> current;
          for (current = activity._baggage.First; current != null; current = current.Next)
            yield return current.Value;
          current = (DiagNode<KeyValuePair<string, string>>) null;
          goto label_2;
        }
        while (activity != null);
      }
    }
  }

  [return: Nullable(2)]
  public string GetBaggageItem(string key)
  {
    foreach (KeyValuePair<string, string> keyValuePair in this.Baggage)
    {
      if (key == keyValuePair.Key)
        return keyValuePair.Value;
    }
    return (string) null;
  }

  [return: Nullable(2)]
  public object GetTagItem(string key)
  {
    Activity.TagsLinkedList tags = this._tags;
    object tagItem;
    if (tags == null)
    {
      tagItem = (object) null;
    }
    else
    {
      tagItem = tags.Get(key);
      if (tagItem != null)
        return tagItem;
    }
    return (object) null;
  }

  public Activity(string operationName)
  {
    this.Source = Activity.s_defaultSource;
    this.IsAllDataRequested = true;
    if (string.IsNullOrEmpty(operationName))
      Activity.NotifyError((Exception) new ArgumentException(System.System.Diagnostics.DiagnosticSource3462135.SR.OperationNameInvalid));
    this.OperationName = operationName;
  }

  public Activity AddTag(string key, [Nullable(2)] string value)
  {
    return this.AddTag(key, (object) value);
  }

  public Activity AddTag(string key, [Nullable(2)] object value)
  {
    KeyValuePair<string, object> firstValue = new KeyValuePair<string, object>(key, value);
    if (this._tags != null || Interlocked.CompareExchange<Activity.TagsLinkedList>(ref this._tags, new Activity.TagsLinkedList(firstValue), (Activity.TagsLinkedList) null) != null)
      this._tags.Add(firstValue);
    return this;
  }

  public Activity SetTag(string key, [Nullable(2)] object value)
  {
    KeyValuePair<string, object> firstValue = new KeyValuePair<string, object>(key, value);
    if (this._tags != null || Interlocked.CompareExchange<Activity.TagsLinkedList>(ref this._tags, new Activity.TagsLinkedList(firstValue, true), (Activity.TagsLinkedList) null) != null)
      this._tags.Set(firstValue);
    return this;
  }

  public Activity AddEvent(ActivityEvent e)
  {
    if (this._events != null || Interlocked.CompareExchange<DiagLinkedList<ActivityEvent>>(ref this._events, new DiagLinkedList<ActivityEvent>(e), (DiagLinkedList<ActivityEvent>) null) != null)
      this._events.Add(e);
    return this;
  }

  public Activity AddBaggage(string key, [Nullable(2)] string value)
  {
    KeyValuePair<string, string> firstValue = new KeyValuePair<string, string>(key, value);
    if (this._baggage != null || Interlocked.CompareExchange<Activity.BaggageLinkedList>(ref this._baggage, new Activity.BaggageLinkedList(firstValue), (Activity.BaggageLinkedList) null) != null)
      this._baggage.Add(firstValue);
    return this;
  }

  public Activity SetBaggage(string key, [Nullable(2)] string value)
  {
    KeyValuePair<string, string> firstValue = new KeyValuePair<string, string>(key, value);
    if (this._baggage != null || Interlocked.CompareExchange<Activity.BaggageLinkedList>(ref this._baggage, new Activity.BaggageLinkedList(firstValue, true), (Activity.BaggageLinkedList) null) != null)
      this._baggage.Set(firstValue);
    return this;
  }

  public Activity SetParentId(string parentId)
  {
    if (this.Parent != null)
      Activity.NotifyError((Exception) new InvalidOperationException(System.System.Diagnostics.DiagnosticSource3462135.SR.SetParentIdOnActivityWithParent));
    else if (this.ParentId == null && this._parentSpanId == null)
    {
      if (string.IsNullOrEmpty(parentId))
        Activity.NotifyError((Exception) new ArgumentException(System.System.Diagnostics.DiagnosticSource3462135.SR.ParentIdInvalid));
      else
        this._parentId = parentId;
    }
    else
      Activity.NotifyError((Exception) new InvalidOperationException(System.System.Diagnostics.DiagnosticSource3462135.SR.ParentIdAlreadySet));
    return this;
  }

  public Activity SetParentId(
    ActivityTraceId traceId,
    ActivitySpanId spanId,
    ActivityTraceFlags activityTraceFlags = ActivityTraceFlags.None)
  {
    if (this.Parent != null)
      Activity.NotifyError((Exception) new InvalidOperationException(System.System.Diagnostics.DiagnosticSource3462135.SR.SetParentIdOnActivityWithParent));
    else if (this.ParentId == null && this._parentSpanId == null)
    {
      this._traceId = traceId.ToHexString();
      this._parentSpanId = spanId.ToHexString();
      this.ActivityTraceFlags = activityTraceFlags;
      this._parentTraceFlags = (byte) activityTraceFlags;
    }
    else
      Activity.NotifyError((Exception) new InvalidOperationException(System.System.Diagnostics.DiagnosticSource3462135.SR.ParentIdAlreadySet));
    return this;
  }

  public Activity SetStartTime(DateTime startTimeUtc)
  {
    if (startTimeUtc.Kind != DateTimeKind.Utc)
      Activity.NotifyError((Exception) new InvalidOperationException(System.System.Diagnostics.DiagnosticSource3462135.SR.StartTimeNotUtc));
    else
      this.StartTimeUtc = startTimeUtc;
    return this;
  }

  public Activity SetEndTime(DateTime endTimeUtc)
  {
    if (endTimeUtc.Kind != DateTimeKind.Utc)
    {
      Activity.NotifyError((Exception) new InvalidOperationException(System.System.Diagnostics.DiagnosticSource3462135.SR.EndTimeNotUtc));
    }
    else
    {
      this.Duration = endTimeUtc - this.StartTimeUtc;
      if (this.Duration.Ticks <= 0L)
        this.Duration = new TimeSpan(1L);
    }
    return this;
  }

  public ActivityContext Context
  {
    get
    {
      return new ActivityContext(this.TraceId, this.SpanId, this.ActivityTraceFlags, this.TraceStateString);
    }
  }

  public Activity Start()
  {
    if (this._id == null && this._spanId == null)
    {
      this._previousActiveActivity = Activity.Current;
      if (this._parentId == null && this._parentSpanId == null && this._previousActiveActivity != null)
        this.Parent = this._previousActiveActivity;
      if (this.StartTimeUtc == new DateTime())
        this.StartTimeUtc = Activity.GetUtcNow();
      if (this.IdFormat == ActivityIdFormat.Unknown)
        this.IdFormat = Activity.ForceDefaultIdFormat ? Activity.DefaultIdFormat : (this.Parent != null ? this.Parent.IdFormat : (this._parentSpanId != null ? ActivityIdFormat.W3C : (this._parentId == null ? Activity.DefaultIdFormat : (Activity.IsW3CId(this._parentId) ? ActivityIdFormat.W3C : ActivityIdFormat.Hierarchical))));
      if (this.IdFormat == ActivityIdFormat.W3C)
        this.GenerateW3CId();
      else
        this._id = this.GenerateHierarchicalId();
      Activity.SetCurrent(this);
      this.Source.NotifyActivityStart(this);
    }
    else
      Activity.NotifyError((Exception) new InvalidOperationException(System.System.Diagnostics.DiagnosticSource3462135.SR.ActivityStartAlreadyStarted));
    return this;
  }

  public void Stop()
  {
    if (this._id == null && this._spanId == null)
    {
      Activity.NotifyError((Exception) new InvalidOperationException(System.System.Diagnostics.DiagnosticSource3462135.SR.ActivityNotStarted));
    }
    else
    {
      if (this.IsFinished)
        return;
      this.IsFinished = true;
      if (this.Duration == TimeSpan.Zero)
        this.SetEndTime(Activity.GetUtcNow());
      this.Source.NotifyActivityStop(this);
      Activity.SetCurrent(this._previousActiveActivity);
    }
  }

  [Nullable(2)]
  public string TraceStateString
  {
    [NullableContext(2)] get
    {
      for (Activity activity = this; activity != null; activity = activity.Parent)
      {
        string traceState = activity._traceState;
        if (traceState != null)
          return traceState;
      }
      return (string) null;
    }
    [NullableContext(2)] set => this._traceState = value;
  }

  public ActivitySpanId SpanId
  {
    [SecuritySafeCritical] get
    {
      if (this._spanId == null && this._id != null && this.IdFormat == ActivityIdFormat.W3C)
        Interlocked.CompareExchange<string>(ref this._spanId, ActivitySpanId.CreateFromString(this._id.AsSpan(36, 16 /*0x10*/)).ToHexString(), (string) null);
      return new ActivitySpanId(this._spanId);
    }
  }

  public ActivityTraceId TraceId
  {
    get
    {
      if (this._traceId == null)
        this.TrySetTraceIdFromParent();
      return new ActivityTraceId(this._traceId);
    }
  }

  public bool Recorded => (this.ActivityTraceFlags & ActivityTraceFlags.Recorded) != 0;

  public bool IsAllDataRequested { get; set; }

  public ActivityTraceFlags ActivityTraceFlags
  {
    get
    {
      if (!this.W3CIdFlagsSet)
        this.TrySetTraceFlagsFromParent();
      return (ActivityTraceFlags) (-129 & (int) this._w3CIdFlags);
    }
    set => this._w3CIdFlags = (byte) (128U /*0x80*/ | (uint) (byte) value);
  }

  public ActivitySpanId ParentSpanId
  {
    [SecuritySafeCritical] get
    {
      if (this._parentSpanId == null)
      {
        string str = (string) null;
        if (this._parentId != null)
        {
          if (Activity.IsW3CId(this._parentId))
          {
            try
            {
              str = ActivitySpanId.CreateFromString(this._parentId.AsSpan(36, 16 /*0x10*/)).ToHexString();
              goto label_7;
            }
            catch
            {
              goto label_7;
            }
          }
        }
        if (this.Parent != null && this.Parent.IdFormat == ActivityIdFormat.W3C)
          str = this.Parent.SpanId.ToHexString();
label_7:
        if (str != null)
          Interlocked.CompareExchange<string>(ref this._parentSpanId, str, (string) null);
      }
      return new ActivitySpanId(this._parentSpanId);
    }
  }

  [Nullable(2)]
  public static Func<ActivityTraceId> TraceIdGenerator { [NullableContext(2)] get; [NullableContext(2)] set; }

  public static ActivityIdFormat DefaultIdFormat
  {
    get
    {
      if (Activity.s_defaultIdFormat == ActivityIdFormat.Unknown)
        Activity.s_defaultIdFormat = ActivityIdFormat.Hierarchical;
      return Activity.s_defaultIdFormat;
    }
    set
    {
      Activity.s_defaultIdFormat = ActivityIdFormat.Hierarchical <= value && value <= ActivityIdFormat.W3C ? value : throw new ArgumentException(System.System.Diagnostics.DiagnosticSource3462135.SR.ActivityIdFormatInvalid);
    }
  }

  public Activity SetIdFormat(ActivityIdFormat format)
  {
    if (this._id == null && this._spanId == null)
      this.IdFormat = format;
    else
      Activity.NotifyError((Exception) new InvalidOperationException(System.System.Diagnostics.DiagnosticSource3462135.SR.SetFormatOnStartedActivity));
    return this;
  }

  private static bool IsW3CId(string id)
  {
    if (id.Length != 55 || ('0' > id[0] || id[0] > '9') && ('a' > id[0] || id[0] > 'f') || ('0' > id[1] || id[1] > '9') && ('a' > id[1] || id[1] > 'f'))
      return false;
    return id[0] != 'f' || id[1] != 'f';
  }

  [SecuritySafeCritical]
  internal static bool TryConvertIdToContext(
    string traceParent,
    string traceState,
    out ActivityContext context)
  {
    context = new ActivityContext();
    if (!Activity.IsW3CId(traceParent))
      return false;
    ReadOnlySpan<char> idData1 = traceParent.AsSpan(3, 32 /*0x20*/);
    ReadOnlySpan<char> idData2 = traceParent.AsSpan(36, 16 /*0x10*/);
    if (!ActivityTraceId.IsLowerCaseHexAndNotAllZeros(idData1) || !ActivityTraceId.IsLowerCaseHexAndNotAllZeros(idData2) || !HexConverter.IsHexLowerChar((int) traceParent[53]) || !HexConverter.IsHexLowerChar((int) traceParent[54]))
      return false;
    context = new ActivityContext(new ActivityTraceId(idData1.ToString()), new ActivitySpanId(idData2.ToString()), (ActivityTraceFlags) ActivityTraceId.HexByteFromChars(traceParent[53], traceParent[54]), traceState);
    return true;
  }

  public void Dispose()
  {
    if (!this.IsFinished)
      this.Stop();
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  protected virtual void Dispose(bool disposing)
  {
  }

  public void SetCustomProperty(string propertyName, [Nullable(2)] object propertyValue)
  {
    if (this._customProperties == null)
      Interlocked.CompareExchange<Dictionary<string, object>>(ref this._customProperties, new Dictionary<string, object>(), (Dictionary<string, object>) null);
    lock (this._customProperties)
    {
      if (propertyValue == null)
        this._customProperties.Remove(propertyName);
      else
        this._customProperties[propertyName] = propertyValue;
    }
  }

  [return: Nullable(2)]
  public object GetCustomProperty(string propertyName)
  {
    if (this._customProperties == null)
      return (object) null;
    lock (this._customProperties)
    {
      object obj;
      return this._customProperties.TryGetValue(propertyName, out obj) ? obj : (object) null;
    }
  }

  internal static Activity Create(
    ActivitySource source,
    string name,
    ActivityKind kind,
    string parentId,
    ActivityContext parentContext,
    IEnumerable<KeyValuePair<string, object>> tags,
    IEnumerable<ActivityLink> links,
    DateTimeOffset startTime,
    ActivityTagsCollection samplerTags,
    ActivitySamplingResult request,
    bool startIt,
    ActivityIdFormat idFormat)
  {
    Activity activity = new Activity(name);
    activity.Source = source;
    activity.Kind = kind;
    activity.IdFormat = idFormat;
    if (links != null)
    {
      using (IEnumerator<ActivityLink> enumerator = links.GetEnumerator())
      {
        if (enumerator.MoveNext())
          activity._links = new DiagLinkedList<ActivityLink>(enumerator);
      }
    }
    if (tags != null)
    {
      using (IEnumerator<KeyValuePair<string, object>> enumerator = tags.GetEnumerator())
      {
        if (enumerator.MoveNext())
          activity._tags = new Activity.TagsLinkedList(enumerator);
      }
    }
    if (samplerTags != null)
    {
      if (activity._tags == null)
        activity._tags = new Activity.TagsLinkedList((IEnumerable<KeyValuePair<string, object>>) samplerTags);
      else
        activity._tags.Add((IEnumerable<KeyValuePair<string, object>>) samplerTags);
    }
    if (parentId != null)
      activity._parentId = parentId;
    else if (parentContext != new ActivityContext())
    {
      activity._traceId = parentContext.TraceId.ToString();
      if (parentContext.SpanId != new ActivitySpanId())
        activity._parentSpanId = parentContext.SpanId.ToString();
      activity.ActivityTraceFlags = parentContext.TraceFlags;
      activity._parentTraceFlags = (byte) parentContext.TraceFlags;
      activity._traceState = parentContext.TraceState;
    }
    activity.IsAllDataRequested = request == ActivitySamplingResult.AllData || request == ActivitySamplingResult.AllDataAndRecorded;
    if (request == ActivitySamplingResult.AllDataAndRecorded)
      activity.ActivityTraceFlags |= ActivityTraceFlags.Recorded;
    if (startTime != new DateTimeOffset())
      activity.StartTimeUtc = startTime.UtcDateTime;
    if (startIt)
      activity.Start();
    return activity;
  }

  private void GenerateW3CId()
  {
    if (this._traceId == null && !this.TrySetTraceIdFromParent())
    {
      Func<ActivityTraceId> traceIdGenerator = Activity.TraceIdGenerator;
      this._traceId = (traceIdGenerator == null ? ActivityTraceId.CreateRandom() : traceIdGenerator()).ToHexString();
    }
    if (!this.W3CIdFlagsSet)
      this.TrySetTraceFlagsFromParent();
    this._spanId = ActivitySpanId.CreateRandom().ToHexString();
  }

  private static void NotifyError(Exception exception)
  {
    try
    {
      throw exception;
    }
    catch
    {
    }
  }

  private string GenerateHierarchicalId()
  {
    string hierarchicalId;
    if (this.Parent != null)
      hierarchicalId = this.AppendSuffix(this.Parent.Id, Interlocked.Increment(ref this.Parent._currentChildId).ToString(), '.');
    else if (this.ParentId != null)
    {
      string parentId = this.ParentId[0] == '|' ? this.ParentId : "|" + this.ParentId;
      switch (parentId[parentId.Length - 1])
      {
        case '.':
        case '_':
          hierarchicalId = this.AppendSuffix(parentId, Interlocked.Increment(ref Activity.s_currentRootId).ToString("x"), '_');
          break;
        default:
          parentId += ".";
          goto case '.';
      }
    }
    else
      hierarchicalId = Activity.GenerateRootId();
    return hierarchicalId;
  }

  private string GetRootId(string id)
  {
    if (this.IdFormat == ActivityIdFormat.W3C)
      return id.Substring(3, 32 /*0x20*/);
    int num = id.IndexOf('.');
    if (num < 0)
      num = id.Length;
    int startIndex = id[0] == '|' ? 1 : 0;
    return id.Substring(startIndex, num - startIndex);
  }

  private string AppendSuffix(string parentId, string suffix, char delimiter)
  {
    if (parentId.Length + suffix.Length < 1024 /*0x0400*/)
      return parentId + suffix + delimiter.ToString();
    int length = 1015;
    while (length > 1 && parentId[length - 1] != '.' && parentId[length - 1] != '_')
      --length;
    if (length == 1)
      return Activity.GenerateRootId();
    string str = ((int) Activity.GetRandomNumber()).ToString("x8");
    return $"{parentId.Substring(0, length)}{str}#";
  }

  [SecuritySafeCritical]
  private static unsafe long GetRandomNumber() => *(long*) &Guid.NewGuid();

  private static bool ValidateSetCurrent(Activity activity)
  {
    bool flag;
    if (!(flag = activity == null || activity.Id != null && !activity.IsFinished))
      Activity.NotifyError((Exception) new InvalidOperationException(System.System.Diagnostics.DiagnosticSource3462135.SR.ActivityNotRunning));
    return flag;
  }

  [SecuritySafeCritical]
  private bool TrySetTraceIdFromParent()
  {
    if (this.Parent != null && this.Parent.IdFormat == ActivityIdFormat.W3C)
      this._traceId = this.Parent.TraceId.ToHexString();
    else if (this._parentId != null)
    {
      if (Activity.IsW3CId(this._parentId))
      {
        try
        {
          this._traceId = ActivityTraceId.CreateFromString(this._parentId.AsSpan(3, 32 /*0x20*/)).ToHexString();
        }
        catch
        {
        }
      }
    }
    return this._traceId != null;
  }

  [SecuritySafeCritical]
  private void TrySetTraceFlagsFromParent()
  {
    if (this.W3CIdFlagsSet)
      return;
    if (this.Parent != null)
    {
      this.ActivityTraceFlags = this.Parent.ActivityTraceFlags;
    }
    else
    {
      if (this._parentId == null || !Activity.IsW3CId(this._parentId))
        return;
      if (HexConverter.IsHexLowerChar((int) this._parentId[53]) && HexConverter.IsHexLowerChar((int) this._parentId[54]))
        this._w3CIdFlags = (byte) ((uint) ActivityTraceId.HexByteFromChars(this._parentId[53], this._parentId[54]) | 128U /*0x80*/);
      else
        this._w3CIdFlags = (byte) 128 /*0x80*/;
    }
  }

  private bool W3CIdFlagsSet => ((uint) this._w3CIdFlags & 128U /*0x80*/) > 0U;

  private bool IsFinished
  {
    get => (this._state & Activity.State.IsFinished) != 0;
    set
    {
      if (value)
        this._state |= Activity.State.IsFinished;
      else
        this._state &= ~Activity.State.IsFinished;
    }
  }

  public ActivityIdFormat IdFormat
  {
    get => (ActivityIdFormat) (this._state & Activity.State.FormatFlags);
    private set
    {
      this._state = this._state & ~Activity.State.FormatFlags | (Activity.State) ((uint) (byte) value & 3U);
    }
  }

  [Nullable(2)]
  public static Activity Current
  {
    [NullableContext(2)] get => Activity.s_current.Value;
    [NullableContext(2)] set
    {
      if (!Activity.ValidateSetCurrent(value))
        return;
      Activity.SetCurrent(value);
    }
  }

  private static void SetCurrent(Activity activity) => Activity.s_current.Value = activity;

  private static string GenerateRootId()
  {
    return $"|{Interlocked.Increment(ref Activity.s_currentRootId).ToString("x")}{Activity.s_uniqSuffix}";
  }

  internal static DateTime GetUtcNow()
  {
    Activity.TimeSync timeSync = Activity.timeSync;
    long num = (long) ((double) ((Stopwatch.GetTimestamp() - timeSync.SyncStopwatchTicks) * 10000000L) / (double) Stopwatch.Frequency);
    return timeSync.SyncUtcNow.AddTicks(num);
  }

  private static void Sync()
  {
    Thread.Sleep(1);
    Activity.timeSync = new Activity.TimeSync();
  }

  [SecuritySafeCritical]
  private static Timer InitalizeSyncTimer()
  {
    bool flag = false;
    try
    {
      if (!ExecutionContext.IsFlowSuppressed())
      {
        ExecutionContext.SuppressFlow();
        flag = true;
      }
      return new Timer((TimerCallback) (s => Activity.Sync()), (object) null, 0, 7200000);
    }
    finally
    {
      if (flag)
        ExecutionContext.RestoreFlow();
    }
  }

  private sealed class BaggageLinkedList : IEnumerable<KeyValuePair<string, string>>, IEnumerable
  {
    private DiagNode<KeyValuePair<string, string>> _first;

    public BaggageLinkedList(KeyValuePair<string, string> firstValue, bool set = false)
    {
      this._first = !set || firstValue.Value != null ? new DiagNode<KeyValuePair<string, string>>(firstValue) : (DiagNode<KeyValuePair<string, string>>) null;
    }

    public DiagNode<KeyValuePair<string, string>> First => this._first;

    public void Add(KeyValuePair<string, string> value)
    {
      DiagNode<KeyValuePair<string, string>> diagNode = new DiagNode<KeyValuePair<string, string>>(value);
      lock (this)
      {
        diagNode.Next = this._first;
        this._first = diagNode;
      }
    }

    public void Set(KeyValuePair<string, string> value)
    {
      if (value.Value == null)
      {
        this.Remove(value.Key);
      }
      else
      {
        lock (this)
        {
          for (DiagNode<KeyValuePair<string, string>> diagNode = this._first; diagNode != null; diagNode = diagNode.Next)
          {
            if (diagNode.Value.Key == value.Key)
            {
              diagNode.Value = value;
              return;
            }
          }
          this._first = new DiagNode<KeyValuePair<string, string>>(value)
          {
            Next = this._first
          };
        }
      }
    }

    public void Remove(string key)
    {
      lock (this)
      {
        if (this._first == null)
          return;
        if (this._first.Value.Key == key)
        {
          this._first = this._first.Next;
        }
        else
        {
          for (DiagNode<KeyValuePair<string, string>> diagNode = this._first; diagNode.Next != null; diagNode = diagNode.Next)
          {
            if (diagNode.Next.Value.Key == key)
            {
              diagNode.Next = diagNode.Next.Next;
              break;
            }
          }
        }
      }
    }

    public Enumerator<KeyValuePair<string, string>> GetEnumerator()
    {
      return new Enumerator<KeyValuePair<string, string>>(this._first);
    }

    IEnumerator<KeyValuePair<string, string>> IEnumerable<KeyValuePair<string, string>>.GetEnumerator()
    {
      return (IEnumerator<KeyValuePair<string, string>>) this.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
  }

  private sealed class TagsLinkedList : IEnumerable<KeyValuePair<string, object>>, IEnumerable
  {
    private DiagNode<KeyValuePair<string, object>> _first;
    private DiagNode<KeyValuePair<string, object>> _last;
    private StringBuilder _stringBuilder;

    public TagsLinkedList(KeyValuePair<string, object> firstValue, bool set = false)
    {
      this._last = this._first = !set || firstValue.Value != null ? new DiagNode<KeyValuePair<string, object>>(firstValue) : (DiagNode<KeyValuePair<string, object>>) null;
    }

    public TagsLinkedList(IEnumerator<KeyValuePair<string, object>> e)
    {
      this._last = this._first = new DiagNode<KeyValuePair<string, object>>(e.Current);
      while (e.MoveNext())
      {
        this._last.Next = new DiagNode<KeyValuePair<string, object>>(e.Current);
        this._last = this._last.Next;
      }
    }

    public TagsLinkedList(IEnumerable<KeyValuePair<string, object>> list) => this.Add(list);

    public void Add(IEnumerable<KeyValuePair<string, object>> list)
    {
      IEnumerator<KeyValuePair<string, object>> enumerator = list.GetEnumerator();
      if (!enumerator.MoveNext())
        return;
      if (this._first == null)
      {
        this._last = this._first = new DiagNode<KeyValuePair<string, object>>(enumerator.Current);
      }
      else
      {
        this._last.Next = new DiagNode<KeyValuePair<string, object>>(enumerator.Current);
        this._last = this._last.Next;
      }
      while (enumerator.MoveNext())
      {
        this._last.Next = new DiagNode<KeyValuePair<string, object>>(enumerator.Current);
        this._last = this._last.Next;
      }
    }

    public void Add(KeyValuePair<string, object> value)
    {
      DiagNode<KeyValuePair<string, object>> diagNode = new DiagNode<KeyValuePair<string, object>>(value);
      lock (this)
      {
        if (this._first == null)
        {
          this._first = this._last = diagNode;
        }
        else
        {
          this._last.Next = diagNode;
          this._last = diagNode;
        }
      }
    }

    public object Get(string key)
    {
      for (DiagNode<KeyValuePair<string, object>> diagNode = this._first; diagNode != null; diagNode = diagNode.Next)
      {
        if (diagNode.Value.Key == key)
          return diagNode.Value.Value;
      }
      return (object) null;
    }

    public void Remove(string key)
    {
      lock (this)
      {
        if (this._first == null)
          return;
        if (this._first.Value.Key == key)
        {
          this._first = this._first.Next;
          if (this._first != null)
            return;
          this._last = (DiagNode<KeyValuePair<string, object>>) null;
        }
        else
        {
          for (DiagNode<KeyValuePair<string, object>> diagNode = this._first; diagNode.Next != null; diagNode = diagNode.Next)
          {
            if (diagNode.Next.Value.Key == key)
            {
              if (this._last == diagNode.Next)
                this._last = diagNode;
              diagNode.Next = diagNode.Next.Next;
              break;
            }
          }
        }
      }
    }

    public void Set(KeyValuePair<string, object> value)
    {
      if (value.Value == null)
      {
        this.Remove(value.Key);
      }
      else
      {
        lock (this)
        {
          for (DiagNode<KeyValuePair<string, object>> diagNode = this._first; diagNode != null; diagNode = diagNode.Next)
          {
            if (diagNode.Value.Key == value.Key)
            {
              diagNode.Value = value;
              return;
            }
          }
          DiagNode<KeyValuePair<string, object>> diagNode1 = new DiagNode<KeyValuePair<string, object>>(value);
          if (this._first == null)
          {
            this._first = this._last = diagNode1;
          }
          else
          {
            this._last.Next = diagNode1;
            this._last = diagNode1;
          }
        }
      }
    }

    public Enumerator<KeyValuePair<string, object>> GetEnumerator()
    {
      return new Enumerator<KeyValuePair<string, object>>(this._first);
    }

    IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
    {
      return (IEnumerator<KeyValuePair<string, object>>) this.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

    public IEnumerable<KeyValuePair<string, string>> EnumerateStringValues()
    {
      for (DiagNode<KeyValuePair<string, object>> current = this._first; current != null; current = current.Next)
      {
        if (!(current.Value.Value is string) && current.Value.Value != null)
          continue;
        yield return new KeyValuePair<string, string>(current.Value.Key, (string) current.Value.Value);
      }
    }

    public override string ToString()
    {
      lock (this)
      {
        if (this._first == null)
          return string.Empty;
        if (this._stringBuilder == null)
          this._stringBuilder = new StringBuilder();
        this._stringBuilder.Append(this._first.Value.Key);
        this._stringBuilder.Append(':');
        this._stringBuilder.Append(this._first.Value.Value);
        for (DiagNode<KeyValuePair<string, object>> next = this._first.Next; next != null; next = next.Next)
        {
          this._stringBuilder.Append(", ");
          this._stringBuilder.Append(next.Value.Key);
          this._stringBuilder.Append(':');
          this._stringBuilder.Append(next.Value.Value);
        }
        string str = this._stringBuilder.ToString();
        this._stringBuilder.Clear();
        return str;
      }
    }
  }

  [Flags]
  private enum State : byte
  {
    None = 0,
    FormatUnknown = 0,
    FormatHierarchical = 1,
    FormatW3C = 2,
    FormatFlags = FormatW3C | FormatHierarchical, // 0x03
    IsFinished = 128, // 0x80
  }

  private sealed class TimeSync
  {
    public readonly DateTime SyncUtcNow = DateTime.UtcNow;
    public readonly long SyncStopwatchTicks = Stopwatch.GetTimestamp();
  }
}
