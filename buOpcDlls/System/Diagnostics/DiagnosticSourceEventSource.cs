// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.DiagnosticSourceEventSource
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

#nullable disable
namespace System.Diagnostics;

[EventSource(Name = "Microsoft-Diagnostics-DiagnosticSource")]
[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2113:ReflectionToRequiresUnreferencedCode", Justification = "In EventSource, EnsureDescriptorsInitialized's use of GetType preserves methods on Delegate and MulticastDelegate because the nested type OverrideEventProvider's base type EventProvider defines a delegate. This includes Delegate and MulticastDelegate methods which require unreferenced code, but EnsureDescriptorsInitialized does not access these members and is safe to call.")]
[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2115:ReflectionToDynamicallyAccessedMembers", Justification = "In EventSource, EnsureDescriptorsInitialized's use of GetType preserves methods on Delegate and MulticastDelegate because the nested type OverrideEventProvider's base type EventProvider defines a delegate. This includes Delegate and MulticastDelegate methods which have dynamically accessed members requirements, but EnsureDescriptorsInitialized does not access these members and is safe to call.")]
internal sealed class DiagnosticSourceEventSource : EventSource
{
  public static DiagnosticSourceEventSource Log = new DiagnosticSourceEventSource();
  private readonly string AspNetCoreHostingKeywordValue = "Microsoft.AspNetCore/Microsoft.AspNetCore.Hosting.BeginRequest@Activity1Start:-httpContext.Request.Method;httpContext.Request.Host;httpContext.Request.Path;httpContext.Request.QueryString\nMicrosoft.AspNetCore/Microsoft.AspNetCore.Hosting.EndRequest@Activity1Stop:-httpContext.TraceIdentifier;httpContext.Response.StatusCode";
  private readonly string EntityFrameworkCoreCommandsKeywordValue = "Microsoft.EntityFrameworkCore/Microsoft.EntityFrameworkCore.BeforeExecuteCommand@Activity2Start:-Command.Connection.DataSource;Command.Connection.Database;Command.CommandText\nMicrosoft.EntityFrameworkCore/Microsoft.EntityFrameworkCore.AfterExecuteCommand@Activity2Stop:-";
  private volatile bool _false;
  private DiagnosticSourceEventSource.FilterAndTransform _specs;
  private DiagnosticSourceEventSource.FilterAndTransform _activitySourceSpecs;
  private ActivityListener _activityListener;

  [System.Diagnostics.Tracing.Event(1, Keywords = (EventKeywords) 1)]
  public void Message(string Message) => this.WriteEvent(1, Message);

  [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Arguments parameter is trimmer safe")]
  [System.Diagnostics.Tracing.Event(2, Keywords = (EventKeywords) 2)]
  private void Event(
    string SourceName,
    string EventName,
    IEnumerable<KeyValuePair<string, string>> Arguments)
  {
    this.WriteEvent(2, (object) SourceName, (object) EventName, (object) Arguments);
  }

  [System.Diagnostics.Tracing.Event(3, Keywords = (EventKeywords) 2)]
  private void EventJson(string SourceName, string EventName, string ArgmentsJson)
  {
    this.WriteEvent(3, SourceName, EventName, ArgmentsJson);
  }

  [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Arguments parameter is trimmer safe")]
  [System.Diagnostics.Tracing.Event(4, Keywords = (EventKeywords) 2)]
  private void Activity1Start(
    string SourceName,
    string EventName,
    IEnumerable<KeyValuePair<string, string>> Arguments)
  {
    this.WriteEvent(4, (object) SourceName, (object) EventName, (object) Arguments);
  }

  [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Arguments parameter is trimmer safe")]
  [System.Diagnostics.Tracing.Event(5, Keywords = (EventKeywords) 2)]
  private void Activity1Stop(
    string SourceName,
    string EventName,
    IEnumerable<KeyValuePair<string, string>> Arguments)
  {
    this.WriteEvent(5, (object) SourceName, (object) EventName, (object) Arguments);
  }

  [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Arguments parameter is trimmer safe")]
  [System.Diagnostics.Tracing.Event(6, Keywords = (EventKeywords) 2)]
  private void Activity2Start(
    string SourceName,
    string EventName,
    IEnumerable<KeyValuePair<string, string>> Arguments)
  {
    this.WriteEvent(6, (object) SourceName, (object) EventName, (object) Arguments);
  }

  [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Arguments parameter is trimmer safe")]
  [System.Diagnostics.Tracing.Event(7, Keywords = (EventKeywords) 2)]
  private void Activity2Stop(
    string SourceName,
    string EventName,
    IEnumerable<KeyValuePair<string, string>> Arguments)
  {
    this.WriteEvent(7, (object) SourceName, (object) EventName, (object) Arguments);
  }

  [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Arguments parameter is trimmer safe")]
  [System.Diagnostics.Tracing.Event(8, Keywords = (EventKeywords) 2, ActivityOptions = EventActivityOptions.Recursive)]
  private void RecursiveActivity1Start(
    string SourceName,
    string EventName,
    IEnumerable<KeyValuePair<string, string>> Arguments)
  {
    this.WriteEvent(8, (object) SourceName, (object) EventName, (object) Arguments);
  }

  [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Arguments parameter is trimmer safe")]
  [System.Diagnostics.Tracing.Event(9, Keywords = (EventKeywords) 2, ActivityOptions = EventActivityOptions.Recursive)]
  private void RecursiveActivity1Stop(
    string SourceName,
    string EventName,
    IEnumerable<KeyValuePair<string, string>> Arguments)
  {
    this.WriteEvent(9, (object) SourceName, (object) EventName, (object) Arguments);
  }

  [System.Diagnostics.Tracing.Event(10, Keywords = (EventKeywords) 2)]
  private void NewDiagnosticListener(string SourceName) => this.WriteEvent(10, SourceName);

  [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Arguments parameter is trimmer safe")]
  [System.Diagnostics.Tracing.Event(11, Keywords = (EventKeywords) 2, ActivityOptions = EventActivityOptions.Recursive)]
  private void ActivityStart(
    string SourceName,
    string ActivityName,
    IEnumerable<KeyValuePair<string, string>> Arguments)
  {
    this.WriteEvent(11, (object) SourceName, (object) ActivityName, (object) Arguments);
  }

  [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Arguments parameter is trimmer safe")]
  [System.Diagnostics.Tracing.Event(12, Keywords = (EventKeywords) 2, ActivityOptions = EventActivityOptions.Recursive)]
  private void ActivityStop(
    string SourceName,
    string ActivityName,
    IEnumerable<KeyValuePair<string, string>> Arguments)
  {
    this.WriteEvent(12, (object) SourceName, (object) ActivityName, (object) Arguments);
  }

  private DiagnosticSourceEventSource()
    : base(EventSourceSettings.EtwSelfDescribingEventFormat)
  {
  }

  [NonEvent]
  protected override void OnEventCommand(EventCommandEventArgs command)
  {
    this.BreakPointWithDebuggerFuncEval();
    lock (this)
    {
      if ((command.Command == EventCommand.Update || command.Command == EventCommand.Enable) && this.IsEnabled(EventLevel.Informational, (EventKeywords) 2))
      {
        string str = (string) null;
        command.Arguments.TryGetValue("FilterAndPayloadSpecs", out str);
        if (!this.IsEnabled(EventLevel.Informational, (EventKeywords) 2048 /*0x0800*/))
        {
          if (this.IsEnabled(EventLevel.Informational, (EventKeywords) 4096 /*0x1000*/))
            str = DiagnosticSourceEventSource.NewLineSeparate(str, this.AspNetCoreHostingKeywordValue);
          if (this.IsEnabled(EventLevel.Informational, (EventKeywords) 8192 /*0x2000*/))
            str = DiagnosticSourceEventSource.NewLineSeparate(str, this.EntityFrameworkCoreCommandsKeywordValue);
        }
        DiagnosticSourceEventSource.FilterAndTransform.CreateFilterAndTransformList(ref this._specs, str, this);
      }
      else
      {
        if (command.Command != EventCommand.Update && command.Command != EventCommand.Disable)
          return;
        DiagnosticSourceEventSource.FilterAndTransform.DestroyFilterAndTransformList(ref this._specs, this);
      }
    }
  }

  private static string NewLineSeparate(string str1, string str2)
  {
    return string.IsNullOrEmpty(str1) ? str2 : $"{str1}\n{str2}";
  }

  [NonEvent]
  [MethodImpl(MethodImplOptions.NoOptimization)]
  private void BreakPointWithDebuggerFuncEval()
  {
    object obj = new object();
    while (this._false)
      this._false = false;
  }

  public static class Keywords
  {
    public const EventKeywords Messages = (EventKeywords) 1;
    public const EventKeywords Events = (EventKeywords) 2;
    public const EventKeywords IgnoreShortCutKeywords = (EventKeywords) 2048 /*0x0800*/;
    public const EventKeywords AspNetCoreHosting = (EventKeywords) 4096 /*0x1000*/;
    public const EventKeywords EntityFrameworkCoreCommands = (EventKeywords) 8192 /*0x2000*/;
  }

  [Flags]
  internal enum ActivityEvents
  {
    None = 0,
    ActivityStart = 1,
    ActivityStop = 2,
    All = ActivityStop | ActivityStart, // 0x00000003
  }

  internal sealed class FilterAndTransform
  {
    public DiagnosticSourceEventSource.FilterAndTransform Next;
    internal const string c_ActivitySourcePrefix = "[AS]";
    private IDisposable _diagnosticsListenersSubscription;
    private DiagnosticSourceEventSource.Subscriptions _liveSubscriptions;
    private readonly bool _noImplicitTransforms;
    private DiagnosticSourceEventSource.ImplicitTransformEntry _firstImplicitTransformsEntry;
    private ConcurrentDictionary<Type, DiagnosticSourceEventSource.TransformSpec> _implicitTransformsTable;
    private readonly DiagnosticSourceEventSource.TransformSpec _explicitTransforms;
    private readonly DiagnosticSourceEventSource _eventSource;

    public static void CreateFilterAndTransformList(
      ref DiagnosticSourceEventSource.FilterAndTransform specList,
      string filterAndPayloadSpecs,
      DiagnosticSourceEventSource eventSource)
    {
      DiagnosticSourceEventSource.FilterAndTransform.DestroyFilterAndTransformList(ref specList, eventSource);
      if (filterAndPayloadSpecs == null)
        filterAndPayloadSpecs = "";
      int num1 = filterAndPayloadSpecs.Length;
      while (true)
      {
        while (0 >= num1 || !char.IsWhiteSpace(filterAndPayloadSpecs[num1 - 1]))
        {
          int num2 = filterAndPayloadSpecs.LastIndexOf('\n', num1 - 1, num1);
          int num3 = 0;
          if (0 <= num2)
            num3 = num2 + 1;
          while (num3 < num1 && char.IsWhiteSpace(filterAndPayloadSpecs[num3]))
            ++num3;
          if (DiagnosticSourceEventSource.FilterAndTransform.IsActivitySourceEntry(filterAndPayloadSpecs, num3, num1))
            DiagnosticSourceEventSource.FilterAndTransform.AddNewActivitySourceTransform(filterAndPayloadSpecs, num3, num1, eventSource);
          else
            specList = new DiagnosticSourceEventSource.FilterAndTransform(filterAndPayloadSpecs, num3, num1, eventSource, specList);
          num1 = num2;
          if (num1 < 0)
          {
            if (eventSource._activitySourceSpecs == null)
              return;
            DiagnosticSourceEventSource.FilterAndTransform.NormalizeActivitySourceSpecsList(eventSource);
            DiagnosticSourceEventSource.FilterAndTransform.CreateActivityListener(eventSource);
            return;
          }
        }
        --num1;
      }
    }

    public static void DestroyFilterAndTransformList(
      ref DiagnosticSourceEventSource.FilterAndTransform specList,
      DiagnosticSourceEventSource eventSource)
    {
      eventSource._activityListener?.Dispose();
      eventSource._activityListener = (ActivityListener) null;
      eventSource._activitySourceSpecs = (DiagnosticSourceEventSource.FilterAndTransform) null;
      DiagnosticSourceEventSource.FilterAndTransform filterAndTransform = specList;
      specList = (DiagnosticSourceEventSource.FilterAndTransform) null;
      for (; filterAndTransform != null; filterAndTransform = filterAndTransform.Next)
        filterAndTransform.Dispose();
    }

    public FilterAndTransform(
      string filterAndPayloadSpec,
      int startIdx,
      int endIdx,
      DiagnosticSourceEventSource eventSource,
      DiagnosticSourceEventSource.FilterAndTransform next)
    {
      DiagnosticSourceEventSource.FilterAndTransform filterAndTransform = this;
      this.Next = next;
      this._eventSource = eventSource;
      string listenerNameFilter = (string) null;
      string eventNameFilter = (string) null;
      string str = (string) null;
      int index = startIdx;
      int num1 = endIdx;
      int num2 = filterAndPayloadSpec.IndexOf(':', startIdx, endIdx - startIdx);
      if (0 <= num2)
      {
        num1 = num2;
        index = num2 + 1;
      }
      int num3 = filterAndPayloadSpec.IndexOf('/', startIdx, num1 - startIdx);
      if (0 <= num3)
      {
        listenerNameFilter = filterAndPayloadSpec.Substring(startIdx, num3 - startIdx);
        int num4 = filterAndPayloadSpec.IndexOf('@', num3 + 1, num1 - num3 - 1);
        if (0 <= num4)
        {
          str = filterAndPayloadSpec.Substring(num4 + 1, num1 - num4 - 1);
          eventNameFilter = filterAndPayloadSpec.Substring(num3 + 1, num4 - num3 - 1);
        }
        else
          eventNameFilter = filterAndPayloadSpec.Substring(num3 + 1, num1 - num3 - 1);
      }
      else if (startIdx < num1)
        listenerNameFilter = filterAndPayloadSpec.Substring(startIdx, num1 - startIdx);
      this._eventSource.Message($"DiagnosticSource: Enabling '{listenerNameFilter ?? "*"}/{eventNameFilter ?? "*"}'");
      if (index < endIdx && filterAndPayloadSpec[index] == '-')
      {
        this._eventSource.Message("DiagnosticSource: suppressing implicit transforms.");
        this._noImplicitTransforms = true;
        ++index;
      }
      if (index < endIdx)
      {
        while (true)
        {
          int num5 = index;
          int num6 = filterAndPayloadSpec.LastIndexOf(';', endIdx - 1, endIdx - index);
          if (0 <= num6)
            goto label_17;
label_11:
          if (num5 < endIdx)
          {
            if (this._eventSource.IsEnabled(EventLevel.Informational, (EventKeywords) 1))
              this._eventSource.Message($"DiagnosticSource: Parsing Explicit Transform '{filterAndPayloadSpec.Substring(num5, endIdx - num5)}'");
            this._explicitTransforms = new DiagnosticSourceEventSource.TransformSpec(filterAndPayloadSpec, num5, endIdx, this._explicitTransforms);
          }
          if (index != num5)
          {
            endIdx = num6;
            continue;
          }
          break;
label_17:
          num5 = num6 + 1;
          goto label_11;
        }
      }
      Action<string, string, IEnumerable<KeyValuePair<string, string>>> writeEvent = (Action<string, string, IEnumerable<KeyValuePair<string, string>>>) null;
      if (str != null && str.Contains("Activity"))
      {
        Action<string, string, IEnumerable<KeyValuePair<string, string>>> action;
        switch (str)
        {
          case "Activity1Start":
            action = new Action<string, string, IEnumerable<KeyValuePair<string, string>>>(this._eventSource.Activity1Start);
            break;
          case "Activity1Stop":
            action = new Action<string, string, IEnumerable<KeyValuePair<string, string>>>(this._eventSource.Activity1Stop);
            break;
          case "Activity2Start":
            action = new Action<string, string, IEnumerable<KeyValuePair<string, string>>>(this._eventSource.Activity2Start);
            break;
          case "Activity2Stop":
            action = new Action<string, string, IEnumerable<KeyValuePair<string, string>>>(this._eventSource.Activity2Stop);
            break;
          case "RecursiveActivity1Start":
            action = new Action<string, string, IEnumerable<KeyValuePair<string, string>>>(this._eventSource.RecursiveActivity1Start);
            break;
          case "RecursiveActivity1Stop":
            action = new Action<string, string, IEnumerable<KeyValuePair<string, string>>>(this._eventSource.RecursiveActivity1Stop);
            break;
          default:
            action = (Action<string, string, IEnumerable<KeyValuePair<string, string>>>) null;
            break;
        }
        writeEvent = action;
        if (writeEvent == null)
          this._eventSource.Message("DiagnosticSource: Could not find Event to log Activity " + str);
      }
      if (writeEvent == null)
        writeEvent = new Action<string, string, IEnumerable<KeyValuePair<string, string>>>(this._eventSource.Event);
      this._diagnosticsListenersSubscription = DiagnosticListener.AllListeners.Subscribe((IObserver<DiagnosticListener>) new DiagnosticSourceEventSource.CallbackObserver<DiagnosticListener>((Action<DiagnosticListener>) (newListener =>
      {
        if (listenerNameFilter != null && !(listenerNameFilter == newListener.Name))
          return;
        filterAndTransform._eventSource.NewDiagnosticListener(newListener.Name);
        Predicate<string> isEnabled = (Predicate<string>) null;
        if (eventNameFilter != null)
          isEnabled = (Predicate<string>) (eventName => eventNameFilter == eventName);
        filterAndTransform._liveSubscriptions = new DiagnosticSourceEventSource.Subscriptions(newListener.Subscribe((IObserver<KeyValuePair<string, object>>) new DiagnosticSourceEventSource.CallbackObserver<KeyValuePair<string, object>>(new Action<KeyValuePair<string, object>>(OnEventWritten)), isEnabled), filterAndTransform._liveSubscriptions);

        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "DiagnosticSource.Write is marked with RequiresUnreferencedCode.")]
        void OnEventWritten(KeyValuePair<string, object> evnt)
        {
          if (eventNameFilter != null && eventNameFilter != evnt.Key)
            return;
          List<KeyValuePair<string, string>> keyValuePairList = filterAndTransform.Morph(evnt.Value);
          writeEvent(newListener.Name, evnt.Key, (IEnumerable<KeyValuePair<string, string>>) keyValuePairList);
        }
      })));
    }

    internal FilterAndTransform(
      string filterAndPayloadSpec,
      int endIdx,
      int colonIdx,
      string activitySourceName,
      string activityName,
      DiagnosticSourceEventSource.ActivityEvents events,
      ActivitySamplingResult samplingResult,
      DiagnosticSourceEventSource eventSource)
    {
      this._eventSource = eventSource;
      this.Next = this._eventSource._activitySourceSpecs;
      this._eventSource._activitySourceSpecs = this;
      this.SourceName = activitySourceName;
      this.ActivityName = activityName;
      this.Events = events;
      this.SamplingResult = samplingResult;
      if (colonIdx < 0)
        return;
      int index = colonIdx + 1;
      if (index < endIdx && filterAndPayloadSpec[index] == '-')
      {
        this._eventSource.Message("DiagnosticSource: suppressing implicit transforms.");
        this._noImplicitTransforms = true;
        ++index;
      }
      if (index >= endIdx)
        return;
      while (true)
      {
        int num1 = index;
        int num2 = filterAndPayloadSpec.LastIndexOf(';', endIdx - 1, endIdx - index);
        if (0 <= num2)
          goto label_11;
label_5:
        if (num1 < endIdx)
        {
          if (this._eventSource.IsEnabled(EventLevel.Informational, (EventKeywords) 1))
            this._eventSource.Message($"DiagnosticSource: Parsing Explicit Transform '{filterAndPayloadSpec.Substring(num1, endIdx - num1)}'");
          this._explicitTransforms = new DiagnosticSourceEventSource.TransformSpec(filterAndPayloadSpec, num1, endIdx, this._explicitTransforms);
        }
        if (index != num1)
        {
          endIdx = num2;
          continue;
        }
        break;
label_11:
        num1 = num2 + 1;
        goto label_5;
      }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static bool IsActivitySourceEntry(
      string filterAndPayloadSpec,
      int startIdx,
      int endIdx)
    {
      return filterAndPayloadSpec.AsSpan(startIdx, endIdx - startIdx).StartsWith("[AS]".AsSpan(), StringComparison.Ordinal);
    }

    internal static void AddNewActivitySourceTransform(
      string filterAndPayloadSpec,
      int startIdx,
      int endIdx,
      DiagnosticSourceEventSource eventSource)
    {
      DiagnosticSourceEventSource.ActivityEvents events = DiagnosticSourceEventSource.ActivityEvents.All;
      ActivitySamplingResult samplingResult = ActivitySamplingResult.AllDataAndRecorded;
      int colonIdx = filterAndPayloadSpec.IndexOf(':', startIdx + "[AS]".Length, endIdx - startIdx - "[AS]".Length);
      ReadOnlySpan<char> span1 = filterAndPayloadSpec.AsSpan(startIdx + "[AS]".Length, (colonIdx >= 0 ? colonIdx : endIdx) - startIdx - "[AS]".Length).Trim();
      int length1 = span1.IndexOf<char>('/');
      ReadOnlySpan<char> span2;
      if (length1 >= 0)
      {
        span2 = span1.Slice(0, length1).Trim();
        ReadOnlySpan<char> span3 = span1.Slice(length1 + 1, span1.Length - length1 - 1).Trim();
        int length2 = span3.IndexOf<char>('-');
        ReadOnlySpan<char> span4;
        if (length2 >= 0)
        {
          span4 = span3.Slice(0, length2).Trim();
          ReadOnlySpan<char> span5 = span3.Slice(length2 + 1, span3.Length - length2 - 1).Trim();
          if (span5.Length > 0)
          {
            if (MemoryExtensions.Equals(span5, "Propagate".AsSpan(), StringComparison.OrdinalIgnoreCase))
            {
              samplingResult = ActivitySamplingResult.PropagationData;
            }
            else
            {
              if (!MemoryExtensions.Equals(span5, "Record".AsSpan(), StringComparison.OrdinalIgnoreCase))
                return;
              samplingResult = ActivitySamplingResult.AllData;
            }
          }
        }
        else
          span4 = span3;
        if (span4.Length > 0)
        {
          if (MemoryExtensions.Equals(span4, "Start".AsSpan(), StringComparison.OrdinalIgnoreCase))
          {
            events = DiagnosticSourceEventSource.ActivityEvents.ActivityStart;
          }
          else
          {
            if (!MemoryExtensions.Equals(span4, "Stop".AsSpan(), StringComparison.OrdinalIgnoreCase))
              return;
            events = DiagnosticSourceEventSource.ActivityEvents.ActivityStop;
          }
        }
      }
      else
        span2 = span1;
      string activityName = (string) null;
      int length3 = span2.IndexOf<char>('+');
      if (length3 >= 0)
      {
        activityName = span2.Slice(length3 + 1).Trim().ToString();
        span2 = span2.Slice(0, length3).Trim();
      }
      DiagnosticSourceEventSource.FilterAndTransform filterAndTransform = new DiagnosticSourceEventSource.FilterAndTransform(filterAndPayloadSpec, endIdx, colonIdx, span2.ToString(), activityName, events, samplingResult, eventSource);
    }

    private static ActivitySamplingResult Sample(
      string activitySourceName,
      string activityName,
      DiagnosticSourceEventSource eventSource)
    {
      DiagnosticSourceEventSource.FilterAndTransform filterAndTransform = eventSource._activitySourceSpecs;
      ActivitySamplingResult activitySamplingResult1 = ActivitySamplingResult.None;
      ActivitySamplingResult activitySamplingResult2 = ActivitySamplingResult.None;
      for (; filterAndTransform != null; filterAndTransform = filterAndTransform.Next)
      {
        if (filterAndTransform.ActivityName == null || filterAndTransform.ActivityName == activityName)
        {
          if (activitySourceName == filterAndTransform.SourceName)
          {
            if (filterAndTransform.SamplingResult > activitySamplingResult1)
              activitySamplingResult1 = filterAndTransform.SamplingResult;
            if (activitySamplingResult1 >= ActivitySamplingResult.AllDataAndRecorded)
              return activitySamplingResult1;
          }
          else if (filterAndTransform.SourceName == "*")
          {
            if (activitySamplingResult1 != ActivitySamplingResult.None)
              return activitySamplingResult1;
            if (filterAndTransform.SamplingResult > activitySamplingResult2)
              activitySamplingResult2 = filterAndTransform.SamplingResult;
          }
        }
      }
      return activitySamplingResult1 == ActivitySamplingResult.None ? activitySamplingResult2 : activitySamplingResult1;
    }

    internal static void CreateActivityListener(DiagnosticSourceEventSource eventSource)
    {
      eventSource._activityListener = new ActivityListener();
      eventSource._activityListener.SampleUsingParentId = (SampleActivity<string>) ((ref ActivityCreationOptions<string> activityOptions) => DiagnosticSourceEventSource.FilterAndTransform.Sample(activityOptions.Source.Name, activityOptions.Name, eventSource));
      eventSource._activityListener.Sample = (SampleActivity<ActivityContext>) ((ref ActivityCreationOptions<ActivityContext> activityOptions) => DiagnosticSourceEventSource.FilterAndTransform.Sample(activityOptions.Source.Name, activityOptions.Name, eventSource));
      eventSource._activityListener.ShouldListenTo = (Func<ActivitySource, bool>) (activitySource =>
      {
        for (DiagnosticSourceEventSource.FilterAndTransform filterAndTransform = eventSource._activitySourceSpecs; filterAndTransform != null; filterAndTransform = filterAndTransform.Next)
        {
          if (activitySource.Name == filterAndTransform.SourceName || filterAndTransform.SourceName == "*")
            return true;
        }
        return false;
      });
      eventSource._activityListener.ActivityStarted = (Action<Activity>) (activity => DiagnosticSourceEventSource.FilterAndTransform.OnActivityStarted(eventSource, activity));
      eventSource._activityListener.ActivityStopped = (Action<Activity>) (activity => DiagnosticSourceEventSource.FilterAndTransform.OnActivityStopped(eventSource, activity));
      ActivitySource.AddActivityListener(eventSource._activityListener);
    }

    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicProperties, typeof (Activity))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicProperties, typeof (ActivityContext))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicProperties, typeof (ActivityEvent))]
    [DynamicDependency(DynamicallyAccessedMemberTypes.PublicProperties, typeof (ActivityLink))]
    [DynamicDependency("Ticks", typeof (DateTime))]
    [DynamicDependency("Ticks", typeof (TimeSpan))]
    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Activity's properties are being preserved with the DynamicDependencies on OnActivityStarted.")]
    private static void OnActivityStarted(
      DiagnosticSourceEventSource eventSource,
      Activity activity)
    {
      for (DiagnosticSourceEventSource.FilterAndTransform filterAndTransform = eventSource._activitySourceSpecs; filterAndTransform != null; filterAndTransform = filterAndTransform.Next)
      {
        if ((filterAndTransform.Events & DiagnosticSourceEventSource.ActivityEvents.ActivityStart) != DiagnosticSourceEventSource.ActivityEvents.None && (activity.Source.Name == filterAndTransform.SourceName || filterAndTransform.SourceName == "*") && (filterAndTransform.ActivityName == null || filterAndTransform.ActivityName == activity.OperationName))
        {
          eventSource.ActivityStart(activity.Source.Name, activity.OperationName, (IEnumerable<KeyValuePair<string, string>>) filterAndTransform.Morph((object) activity));
          break;
        }
      }
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "Activity's properties are being preserved with the DynamicDependencies on OnActivityStarted.")]
    private static void OnActivityStopped(
      DiagnosticSourceEventSource eventSource,
      Activity activity)
    {
      for (DiagnosticSourceEventSource.FilterAndTransform filterAndTransform = eventSource._activitySourceSpecs; filterAndTransform != null; filterAndTransform = filterAndTransform.Next)
      {
        if ((filterAndTransform.Events & DiagnosticSourceEventSource.ActivityEvents.ActivityStop) != DiagnosticSourceEventSource.ActivityEvents.None && (activity.Source.Name == filterAndTransform.SourceName || filterAndTransform.SourceName == "*") && (filterAndTransform.ActivityName == null || filterAndTransform.ActivityName == activity.OperationName))
        {
          eventSource.ActivityStop(activity.Source.Name, activity.OperationName, (IEnumerable<KeyValuePair<string, string>>) filterAndTransform.Morph((object) activity));
          break;
        }
      }
    }

    internal static void NormalizeActivitySourceSpecsList(DiagnosticSourceEventSource eventSource)
    {
      DiagnosticSourceEventSource.FilterAndTransform filterAndTransform1 = eventSource._activitySourceSpecs;
      DiagnosticSourceEventSource.FilterAndTransform filterAndTransform2 = (DiagnosticSourceEventSource.FilterAndTransform) null;
      DiagnosticSourceEventSource.FilterAndTransform filterAndTransform3 = (DiagnosticSourceEventSource.FilterAndTransform) null;
      DiagnosticSourceEventSource.FilterAndTransform filterAndTransform4 = (DiagnosticSourceEventSource.FilterAndTransform) null;
      DiagnosticSourceEventSource.FilterAndTransform filterAndTransform5 = (DiagnosticSourceEventSource.FilterAndTransform) null;
      for (; filterAndTransform1 != null; filterAndTransform1 = filterAndTransform1.Next)
      {
        if (filterAndTransform1.SourceName == "*")
        {
          if (filterAndTransform4 == null)
          {
            filterAndTransform4 = filterAndTransform5 = filterAndTransform1;
          }
          else
          {
            filterAndTransform5.Next = filterAndTransform1;
            filterAndTransform5 = filterAndTransform1;
          }
        }
        else if (filterAndTransform2 == null)
        {
          filterAndTransform2 = filterAndTransform3 = filterAndTransform1;
        }
        else
        {
          filterAndTransform3.Next = filterAndTransform1;
          filterAndTransform3 = filterAndTransform1;
        }
      }
      if (filterAndTransform2 == null || filterAndTransform4 == null)
        return;
      filterAndTransform3.Next = filterAndTransform4;
      filterAndTransform5.Next = (DiagnosticSourceEventSource.FilterAndTransform) null;
      eventSource._activitySourceSpecs = filterAndTransform2;
    }

    private void Dispose()
    {
      if (this._diagnosticsListenersSubscription != null)
      {
        this._diagnosticsListenersSubscription.Dispose();
        this._diagnosticsListenersSubscription = (IDisposable) null;
      }
      if (this._liveSubscriptions == null)
        return;
      DiagnosticSourceEventSource.Subscriptions subscriptions = this._liveSubscriptions;
      this._liveSubscriptions = (DiagnosticSourceEventSource.Subscriptions) null;
      for (; subscriptions != null; subscriptions = subscriptions.Next)
        subscriptions.Subscription.Dispose();
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2112:ReflectionToRequiresUnreferencedCode", Justification = "In EventSource, EnsureDescriptorsInitialized's use of GetType preserves this method which requires unreferenced code, but EnsureDescriptorsInitialized does not access this member and is safe to call.")]
    [RequiresUnreferencedCode("The type of object being written to DiagnosticSource cannot be discovered statically.")]
    public List<KeyValuePair<string, string>> Morph(object args)
    {
      List<KeyValuePair<string, string>> keyValuePairList = new List<KeyValuePair<string, string>>();
      if (args != null)
      {
        if (!this._noImplicitTransforms)
        {
          Type type1 = args.GetType();
          DiagnosticSourceEventSource.ImplicitTransformEntry implicitTransformsEntry = this._firstImplicitTransformsEntry;
          DiagnosticSourceEventSource.TransformSpec transformSpec1;
          if (implicitTransformsEntry != null && implicitTransformsEntry.Type == type1)
            transformSpec1 = implicitTransformsEntry.Transforms;
          else if (implicitTransformsEntry == null)
          {
            transformSpec1 = DiagnosticSourceEventSource.FilterAndTransform.MakeImplicitTransforms(type1);
            Interlocked.CompareExchange<DiagnosticSourceEventSource.ImplicitTransformEntry>(ref this._firstImplicitTransformsEntry, new DiagnosticSourceEventSource.ImplicitTransformEntry()
            {
              Type = type1,
              Transforms = transformSpec1
            }, (DiagnosticSourceEventSource.ImplicitTransformEntry) null);
          }
          else
          {
            if (this._implicitTransformsTable == null)
              Interlocked.CompareExchange<ConcurrentDictionary<Type, DiagnosticSourceEventSource.TransformSpec>>(ref this._implicitTransformsTable, new ConcurrentDictionary<Type, DiagnosticSourceEventSource.TransformSpec>(1, 8), (ConcurrentDictionary<Type, DiagnosticSourceEventSource.TransformSpec>) null);
            transformSpec1 = this._implicitTransformsTable.GetOrAdd(type1, (Func<Type, DiagnosticSourceEventSource.TransformSpec>) (type => MakeImplicitTransformsWrapper(type)));
          }
          if (transformSpec1 != null)
          {
            for (DiagnosticSourceEventSource.TransformSpec transformSpec2 = transformSpec1; transformSpec2 != null; transformSpec2 = transformSpec2.Next)
              keyValuePairList.Add(transformSpec2.Morph(args));
          }
        }
        if (this._explicitTransforms != null)
        {
          for (DiagnosticSourceEventSource.TransformSpec transformSpec = this._explicitTransforms; transformSpec != null; transformSpec = transformSpec.Next)
          {
            KeyValuePair<string, string> keyValuePair = transformSpec.Morph(args);
            if (keyValuePair.Value != null)
              keyValuePairList.Add(keyValuePair);
          }
        }
      }
      return keyValuePairList;

      [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "The Morph method has RequiresUnreferencedCode, but the trimmer can't see through lamdba calls.")]
      static DiagnosticSourceEventSource.TransformSpec MakeImplicitTransformsWrapper(
        Type transformType)
      {
        return DiagnosticSourceEventSource.FilterAndTransform.MakeImplicitTransforms(transformType);
      }
    }

    internal string SourceName { get; set; }

    internal string ActivityName { get; set; }

    internal DiagnosticSourceEventSource.ActivityEvents Events { get; set; }

    internal ActivitySamplingResult SamplingResult { get; set; }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2112:ReflectionToRequiresUnreferencedCode", Justification = "In EventSource, EnsureDescriptorsInitialized's use of GetType preserves this method which requires unreferenced code, but EnsureDescriptorsInitialized does not access this member and is safe to call.")]
    [RequiresUnreferencedCode("The type of object being written to DiagnosticSource cannot be discovered statically.")]
    private static DiagnosticSourceEventSource.TransformSpec MakeImplicitTransforms(Type type)
    {
      DiagnosticSourceEventSource.TransformSpec transformSpec = (DiagnosticSourceEventSource.TransformSpec) null;
      foreach (PropertyInfo property in type.GetTypeInfo().GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
      {
        if (!(property.GetMethod == (MethodInfo) null) && property.GetMethod.GetParameters().Length == 0)
          transformSpec = new DiagnosticSourceEventSource.TransformSpec(property.Name, 0, property.Name.Length, transformSpec);
      }
      return DiagnosticSourceEventSource.FilterAndTransform.Reverse(transformSpec);
    }

    private static DiagnosticSourceEventSource.TransformSpec Reverse(
      DiagnosticSourceEventSource.TransformSpec list)
    {
      DiagnosticSourceEventSource.TransformSpec transformSpec = (DiagnosticSourceEventSource.TransformSpec) null;
      DiagnosticSourceEventSource.TransformSpec next;
      for (; list != null; list = next)
      {
        next = list.Next;
        list.Next = transformSpec;
        transformSpec = list;
      }
      return transformSpec;
    }
  }

  internal sealed class ImplicitTransformEntry
  {
    public Type Type;
    public DiagnosticSourceEventSource.TransformSpec Transforms;
  }

  internal sealed class TransformSpec
  {
    public DiagnosticSourceEventSource.TransformSpec Next;
    private readonly string _outputName;
    private readonly DiagnosticSourceEventSource.TransformSpec.PropertySpec _fetches;

    public TransformSpec(
      string transformSpec,
      int startIdx,
      int endIdx,
      DiagnosticSourceEventSource.TransformSpec next = null)
    {
      this.Next = next;
      int num1 = transformSpec.IndexOf('=', startIdx, endIdx - startIdx);
      if (0 <= num1)
      {
        this._outputName = transformSpec.Substring(startIdx, num1 - startIdx);
        startIdx = num1 + 1;
      }
      int num2;
      for (; startIdx < endIdx; endIdx = num2)
      {
        num2 = transformSpec.LastIndexOf('.', endIdx - 1, endIdx - startIdx);
        int startIndex = startIdx;
        if (0 <= num2)
          startIndex = num2 + 1;
        string propertyName = transformSpec.Substring(startIndex, endIdx - startIndex);
        this._fetches = new DiagnosticSourceEventSource.TransformSpec.PropertySpec(propertyName, this._fetches);
        if (this._outputName == null)
          this._outputName = propertyName;
      }
    }

    [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2112:ReflectionToRequiresUnreferencedCode", Justification = "In EventSource, EnsureDescriptorsInitialized's use of GetType preserves this method which requires unreferenced code, but EnsureDescriptorsInitialized does not access this member and is safe to call.")]
    [RequiresUnreferencedCode("The type of object being written to DiagnosticSource cannot be discovered statically.")]
    public KeyValuePair<string, string> Morph(object obj)
    {
      for (DiagnosticSourceEventSource.TransformSpec.PropertySpec propertySpec = this._fetches; propertySpec != null; propertySpec = propertySpec.Next)
      {
        if (obj != null || propertySpec.IsStatic)
          obj = propertySpec.Fetch(obj);
      }
      return new KeyValuePair<string, string>(this._outputName, obj?.ToString());
    }

    internal sealed class PropertySpec
    {
      private const string CurrentActivityPropertyName = "*Activity";
      private const string EnumeratePropertyName = "*Enumerate";
      public DiagnosticSourceEventSource.TransformSpec.PropertySpec Next;
      private readonly string _propertyName;
      private volatile DiagnosticSourceEventSource.TransformSpec.PropertySpec.PropertyFetch _fetchForExpectedType;

      public PropertySpec(
        string propertyName,
        DiagnosticSourceEventSource.TransformSpec.PropertySpec next)
      {
        this.Next = next;
        this._propertyName = propertyName;
        if (!(this._propertyName == "*Activity"))
          return;
        this.IsStatic = true;
      }

      public bool IsStatic { get; private set; }

      [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2112:ReflectionToRequiresUnreferencedCode", Justification = "In EventSource, EnsureDescriptorsInitialized's use of GetType preserves this method which requires unreferenced code, but EnsureDescriptorsInitialized does not access this member and is safe to call.")]
      [RequiresUnreferencedCode("The type of object being written to DiagnosticSource cannot be discovered statically.")]
      public object Fetch(object obj)
      {
        DiagnosticSourceEventSource.TransformSpec.PropertySpec.PropertyFetch propertyFetch = this._fetchForExpectedType;
        Type type = obj?.GetType();
        if (propertyFetch == null || propertyFetch.Type != type)
          this._fetchForExpectedType = propertyFetch = DiagnosticSourceEventSource.TransformSpec.PropertySpec.PropertyFetch.FetcherForProperty(type, this._propertyName);
        object obj1 = (object) null;
        try
        {
          obj1 = propertyFetch.Fetch(obj);
        }
        catch (Exception ex)
        {
          DiagnosticSourceEventSource.Log.Message($"Property {type}.{this._propertyName} threw the exception {ex}");
        }
        return obj1;
      }

      private class PropertyFetch
      {
        public PropertyFetch(Type type) => this.Type = type;

        internal Type Type { get; }

        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2112:ReflectionToRequiresUnreferencedCode", Justification = "In EventSource, EnsureDescriptorsInitialized's use of GetType preserves this method which requires unreferenced code, but EnsureDescriptorsInitialized does not access this member and is safe to call.")]
        [RequiresUnreferencedCode("The type of object being written to DiagnosticSource cannot be discovered statically.")]
        public static DiagnosticSourceEventSource.TransformSpec.PropertySpec.PropertyFetch FetcherForProperty(
          Type type,
          string propertyName)
        {
          switch (propertyName)
          {
            case null:
              return new DiagnosticSourceEventSource.TransformSpec.PropertySpec.PropertyFetch(type);
            case "*Activity":
              return (DiagnosticSourceEventSource.TransformSpec.PropertySpec.PropertyFetch) new DiagnosticSourceEventSource.TransformSpec.PropertySpec.PropertyFetch.CurrentActivityPropertyFetch();
            default:
              TypeInfo typeInfo1 = type.GetTypeInfo();
              if (propertyName == "*Enumerate")
              {
                foreach (Type type1 in typeInfo1.GetInterfaces())
                {
                  TypeInfo typeInfo2 = type1.GetTypeInfo();
                  if (typeInfo2.IsGenericType && !(typeInfo2.GetGenericTypeDefinition() != typeof (IEnumerable<>)))
                  {
                    Type genericArgument = typeInfo2.GetGenericArguments()[0];
                    return (DiagnosticSourceEventSource.TransformSpec.PropertySpec.PropertyFetch) Activator.CreateInstance(typeof (DiagnosticSourceEventSource.TransformSpec.PropertySpec.PropertyFetch.EnumeratePropertyFetch<>).GetTypeInfo().MakeGenericType(genericArgument), (object) type);
                  }
                }
                DiagnosticSourceEventSource.Log.Message($"*Enumerate applied to non-enumerable type {type}");
                return new DiagnosticSourceEventSource.TransformSpec.PropertySpec.PropertyFetch(type);
              }
              PropertyInfo propertyInfo = typeInfo1.GetDeclaredProperty(propertyName);
              if (propertyInfo == (PropertyInfo) null)
              {
                foreach (PropertyInfo property in typeInfo1.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                {
                  if (property.Name == propertyName)
                  {
                    propertyInfo = property;
                    break;
                  }
                }
              }
              if (propertyInfo == (PropertyInfo) null)
              {
                DiagnosticSourceEventSource.Log.Message($"Property {propertyName} not found on {type}. Ensure the name is spelled correctly. If you published the application with PublishTrimmed=true, ensure the property was not trimmed away.");
                return new DiagnosticSourceEventSource.TransformSpec.PropertySpec.PropertyFetch(type);
              }
              MethodInfo getMethod = propertyInfo.GetMethod;
              // ISSUE: explicit non-virtual call
              if (((object) getMethod != null ? (__nonvirtual (getMethod.IsStatic) ? 1 : 0) : 0) == 0)
              {
                MethodInfo setMethod = propertyInfo.SetMethod;
                // ISSUE: explicit non-virtual call
                if (((object) setMethod != null ? (__nonvirtual (setMethod.IsStatic) ? 1 : 0) : 0) == 0)
                  return (DiagnosticSourceEventSource.TransformSpec.PropertySpec.PropertyFetch) Activator.CreateInstance((typeInfo1.IsValueType ? typeof (DiagnosticSourceEventSource.TransformSpec.PropertySpec.PropertyFetch.ValueTypedFetchProperty<,>) : typeof (DiagnosticSourceEventSource.TransformSpec.PropertySpec.PropertyFetch.RefTypedFetchProperty<,>)).GetTypeInfo().MakeGenericType(propertyInfo.DeclaringType, propertyInfo.PropertyType), (object) type, (object) propertyInfo);
              }
              DiagnosticSourceEventSource.Log.Message($"Property {propertyName} is static.");
              return new DiagnosticSourceEventSource.TransformSpec.PropertySpec.PropertyFetch(type);
          }
        }

        public virtual object Fetch(object obj) => (object) null;

        private sealed class RefTypedFetchProperty<TObject, TProperty> : 
          DiagnosticSourceEventSource.TransformSpec.PropertySpec.PropertyFetch
        {
          private readonly Func<TObject, TProperty> _propertyFetch;

          public RefTypedFetchProperty(Type type, PropertyInfo property)
            : base(type)
          {
            this._propertyFetch = (Func<TObject, TProperty>) property.GetMethod.CreateDelegate(typeof (Func<TObject, TProperty>));
          }

          public override object Fetch(object obj) => (object) this._propertyFetch((TObject) obj);
        }

        private delegate TProperty StructFunc<TStruct, TProperty>(ref TStruct thisArg);

        private sealed class ValueTypedFetchProperty<TStruct, TProperty> : 
          DiagnosticSourceEventSource.TransformSpec.PropertySpec.PropertyFetch
        {
          private readonly DiagnosticSourceEventSource.TransformSpec.PropertySpec.PropertyFetch.StructFunc<TStruct, TProperty> _propertyFetch;

          public ValueTypedFetchProperty(Type type, PropertyInfo property)
            : base(type)
          {
            this._propertyFetch = (DiagnosticSourceEventSource.TransformSpec.PropertySpec.PropertyFetch.StructFunc<TStruct, TProperty>) property.GetMethod.CreateDelegate(typeof (DiagnosticSourceEventSource.TransformSpec.PropertySpec.PropertyFetch.StructFunc<TStruct, TProperty>));
          }

          public override object Fetch(object obj)
          {
            TStruct thisArg = (TStruct) obj;
            return (object) this._propertyFetch(ref thisArg);
          }
        }

        private sealed class CurrentActivityPropertyFetch : 
          DiagnosticSourceEventSource.TransformSpec.PropertySpec.PropertyFetch
        {
          public CurrentActivityPropertyFetch()
            : base((Type) null)
          {
          }

          public override object Fetch(object obj) => (object) Activity.Current;
        }

        private sealed class EnumeratePropertyFetch<ElementType>(Type type) : 
          DiagnosticSourceEventSource.TransformSpec.PropertySpec.PropertyFetch(type)
        {
          public override object Fetch(object obj)
          {
            return (object) string.Join<ElementType>(",", (IEnumerable<ElementType>) obj);
          }
        }
      }
    }
  }

  internal sealed class CallbackObserver<T> : IObserver<T>
  {
    private readonly Action<T> _callback;

    public CallbackObserver(Action<T> callback) => this._callback = callback;

    public void OnCompleted()
    {
    }

    public void OnError(Exception error)
    {
    }

    public void OnNext(T value) => this._callback(value);
  }

  internal sealed class Subscriptions
  {
    public IDisposable Subscription;
    public DiagnosticSourceEventSource.Subscriptions Next;

    public Subscriptions(IDisposable subscription, DiagnosticSourceEventSource.Subscriptions next)
    {
      this.Subscription = subscription;
      this.Next = next;
    }
  }
}
