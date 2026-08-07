// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.ActivitySource
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

#nullable disable
namespace System.Diagnostics;

[System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.NullableContext(1)]
[System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(0)]
[ComVisible(true)]
public sealed class ActivitySource : IDisposable
{
  private static readonly SynchronizedList<ActivitySource> s_activeSources = new SynchronizedList<ActivitySource>();
  private static readonly SynchronizedList<ActivityListener> s_allListeners = new SynchronizedList<ActivityListener>();
  private SynchronizedList<ActivityListener> _listeners;

  public ActivitySource(string name, [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(2)] string version = "")
  {
    this.Name = name != null ? name : throw new ArgumentNullException(nameof (name));
    this.Version = version;
    ActivitySource.s_activeSources.Add(this);
    if (ActivitySource.s_allListeners.Count > 0)
      ActivitySource.s_allListeners.EnumWithAction((Action<ActivityListener, object>) ((listener, source) =>
      {
        Func<ActivitySource, bool> shouldListenTo = listener.ShouldListenTo;
        if (shouldListenTo == null)
          return;
        ActivitySource activitySource = (ActivitySource) source;
        if (!shouldListenTo(activitySource))
          return;
        activitySource.AddListener(listener);
      }), (object) this);
    GC.KeepAlive((object) DiagnosticSourceEventSource.Log);
  }

  public string Name { get; }

  [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(2)]
  public string Version { [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.NullableContext(2)] get; }

  public bool HasListeners()
  {
    SynchronizedList<ActivityListener> listeners = this._listeners;
    return listeners != null && listeners.Count > 0;
  }

  [return: System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(2)]
  public Activity CreateActivity(string name, ActivityKind kind)
  {
    return this.CreateActivity(name, kind, new ActivityContext(), (string) null, (IEnumerable<KeyValuePair<string, object>>) null, (IEnumerable<ActivityLink>) null, new DateTimeOffset(), false);
  }

  [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.NullableContext(2)]
  public Activity CreateActivity(
    [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(1)] string name,
    ActivityKind kind,
    ActivityContext parentContext,
    [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(new byte[] {2, 0, 1, 2})] IEnumerable<KeyValuePair<string, object>> tags = null,
    IEnumerable<ActivityLink> links = null,
    ActivityIdFormat idFormat = ActivityIdFormat.Unknown)
  {
    return this.CreateActivity(name, kind, parentContext, (string) null, tags, links, new DateTimeOffset(), false, idFormat);
  }

  [return: System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(2)]
  public Activity CreateActivity(
    string name,
    ActivityKind kind,
    string parentId,
    [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(new byte[] {2, 0, 1, 2})] IEnumerable<KeyValuePair<string, object>> tags = null,
    [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(2)] IEnumerable<ActivityLink> links = null,
    ActivityIdFormat idFormat = ActivityIdFormat.Unknown)
  {
    return this.CreateActivity(name, kind, new ActivityContext(), parentId, tags, links, new DateTimeOffset(), false, idFormat);
  }

  [return: System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(2)]
  public Activity StartActivity([CallerMemberName] string name = "", ActivityKind kind = ActivityKind.Internal)
  {
    return this.CreateActivity(name, kind, new ActivityContext(), (string) null, (IEnumerable<KeyValuePair<string, object>>) null, (IEnumerable<ActivityLink>) null, new DateTimeOffset());
  }

  [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.NullableContext(2)]
  public Activity StartActivity(
    [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(1)] string name,
    ActivityKind kind,
    ActivityContext parentContext,
    [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(new byte[] {2, 0, 1, 2})] IEnumerable<KeyValuePair<string, object>> tags = null,
    IEnumerable<ActivityLink> links = null,
    DateTimeOffset startTime = default (DateTimeOffset))
  {
    return this.CreateActivity(name, kind, parentContext, (string) null, tags, links, startTime);
  }

  [return: System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(2)]
  public Activity StartActivity(
    string name,
    ActivityKind kind,
    string parentId,
    [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(new byte[] {2, 0, 1, 2})] IEnumerable<KeyValuePair<string, object>> tags = null,
    [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(2)] IEnumerable<ActivityLink> links = null,
    DateTimeOffset startTime = default (DateTimeOffset))
  {
    return this.CreateActivity(name, kind, new ActivityContext(), parentId, tags, links, startTime);
  }

  [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.NullableContext(2)]
  public Activity StartActivity(
    ActivityKind kind,
    ActivityContext parentContext = default (ActivityContext),
    [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(new byte[] {2, 0, 1, 2})] IEnumerable<KeyValuePair<string, object>> tags = null,
    IEnumerable<ActivityLink> links = null,
    DateTimeOffset startTime = default (DateTimeOffset),
    [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(1), CallerMemberName] string name = "")
  {
    return this.CreateActivity(name, kind, parentContext, (string) null, tags, links, startTime);
  }

  private Activity CreateActivity(
    string name,
    ActivityKind kind,
    ActivityContext context,
    string parentId,
    IEnumerable<KeyValuePair<string, object>> tags,
    IEnumerable<ActivityLink> links,
    DateTimeOffset startTime,
    bool startIt = true,
    ActivityIdFormat idFormat = ActivityIdFormat.Unknown)
  {
    SynchronizedList<ActivityListener> listeners = this._listeners;
    if (listeners == null || listeners.Count == 0)
      return (Activity) null;
    Activity activity = (Activity) null;
    ActivitySamplingResult samplingResult = ActivitySamplingResult.None;
    ActivityTagsCollection samplerTags;
    if (parentId != null)
    {
      ActivityCreationOptions<string> data1 = new ActivityCreationOptions<string>();
      ActivityCreationOptions<ActivityContext> dataWithContext1 = new ActivityCreationOptions<ActivityContext>();
      data1 = new ActivityCreationOptions<string>(this, name, parentId, kind, tags, links, idFormat);
      if (data1.IdFormat == ActivityIdFormat.W3C)
        dataWithContext1 = new ActivityCreationOptions<ActivityContext>(this, name, data1.GetContext(), kind, tags, links, ActivityIdFormat.W3C);
      listeners.EnumWithFunc<string>((ActivitySource.Function<ActivityListener, string>) ((ActivityListener listener, ref ActivityCreationOptions<string> data, ref ActivitySamplingResult result, ref ActivityCreationOptions<ActivityContext> dataWithContext) =>
      {
        SampleActivity<string> sampleUsingParentId = listener.SampleUsingParentId;
        if (sampleUsingParentId != null)
        {
          ActivitySamplingResult activitySamplingResult = sampleUsingParentId(ref data);
          if (activitySamplingResult <= result)
            return;
          result = activitySamplingResult;
        }
        else
        {
          if (data.IdFormat != ActivityIdFormat.W3C)
            return;
          SampleActivity<ActivityContext> sample = listener.Sample;
          if (sample == null)
            return;
          ActivitySamplingResult activitySamplingResult = sample(ref dataWithContext);
          if (activitySamplingResult <= result)
            return;
          result = activitySamplingResult;
        }
      }), ref data1, ref samplingResult, ref dataWithContext1);
      if (context == new ActivityContext())
      {
        if (data1.GetContext() != new ActivityContext())
        {
          context = data1.GetContext();
          parentId = (string) null;
        }
        else if (dataWithContext1.GetContext() != new ActivityContext())
        {
          context = dataWithContext1.GetContext();
          parentId = (string) null;
        }
      }
      samplerTags = data1.GetSamplingTags();
      ActivityTagsCollection samplingTags = dataWithContext1.GetSamplingTags();
      if (samplingTags != null)
      {
        if (samplerTags == null)
        {
          samplerTags = samplingTags;
        }
        else
        {
          foreach (KeyValuePair<string, object> keyValuePair in samplingTags)
            samplerTags.Add(keyValuePair);
        }
      }
      idFormat = data1.IdFormat;
    }
    else
    {
      bool flag = context == new ActivityContext() && Activity.Current != null;
      ActivityCreationOptions<ActivityContext> activityCreationOptions = new ActivityCreationOptions<ActivityContext>(this, name, flag ? Activity.Current.Context : context, kind, tags, links, idFormat);
      listeners.EnumWithFunc<ActivityContext>((ActivitySource.Function<ActivityListener, ActivityContext>) ((ActivityListener listener, ref ActivityCreationOptions<ActivityContext> data, ref ActivitySamplingResult result, ref ActivityCreationOptions<ActivityContext> unused) =>
      {
        SampleActivity<ActivityContext> sample = listener.Sample;
        if (sample == null)
          return;
        ActivitySamplingResult activitySamplingResult = sample(ref data);
        if (activitySamplingResult <= result)
          return;
        result = activitySamplingResult;
      }), ref activityCreationOptions, ref samplingResult, ref activityCreationOptions);
      if (!flag)
        context = activityCreationOptions.GetContext();
      samplerTags = activityCreationOptions.GetSamplingTags();
      idFormat = activityCreationOptions.IdFormat;
    }
    if (samplingResult != ActivitySamplingResult.None)
      activity = Activity.Create(this, name, kind, parentId, context, tags, links, startTime, samplerTags, samplingResult, startIt, idFormat);
    return activity;
  }

  public void Dispose()
  {
    this._listeners = (SynchronizedList<ActivityListener>) null;
    ActivitySource.s_activeSources.Remove(this);
  }

  public static void AddActivityListener(ActivityListener listener)
  {
    if (listener == null)
      throw new ArgumentNullException(nameof (listener));
    if (!ActivitySource.s_allListeners.AddIfNotExist(listener))
      return;
    ActivitySource.s_activeSources.EnumWithAction((Action<ActivitySource, object>) ((source, obj) =>
    {
      Func<ActivitySource, bool> shouldListenTo = ((ActivityListener) obj).ShouldListenTo;
      if (shouldListenTo == null || !shouldListenTo(source))
        return;
      source.AddListener((ActivityListener) obj);
    }), (object) listener);
  }

  internal void AddListener(ActivityListener listener)
  {
    if (this._listeners == null)
      Interlocked.CompareExchange<SynchronizedList<ActivityListener>>(ref this._listeners, new SynchronizedList<ActivityListener>(), (SynchronizedList<ActivityListener>) null);
    this._listeners.AddIfNotExist(listener);
  }

  internal static void DetachListener(ActivityListener listener)
  {
    ActivitySource.s_allListeners.Remove(listener);
    ActivitySource.s_activeSources.EnumWithAction((Action<ActivitySource, object>) ((source, obj) => source._listeners?.Remove((ActivityListener) obj)), (object) listener);
  }

  internal void NotifyActivityStart(Activity activity)
  {
    SynchronizedList<ActivityListener> listeners = this._listeners;
    if (listeners == null || listeners.Count <= 0)
      return;
    listeners.EnumWithAction((Action<ActivityListener, object>) ((listener, obj) =>
    {
      Action<Activity> activityStarted = listener.ActivityStarted;
      if (activityStarted == null)
        return;
      activityStarted((Activity) obj);
    }), (object) activity);
  }

  internal void NotifyActivityStop(Activity activity)
  {
    SynchronizedList<ActivityListener> listeners = this._listeners;
    if (listeners == null || listeners.Count <= 0)
      return;
    listeners.EnumWithAction((Action<ActivityListener, object>) ((listener, obj) =>
    {
      Action<Activity> activityStopped = listener.ActivityStopped;
      if (activityStopped == null)
        return;
      activityStopped((Activity) obj);
    }), (object) activity);
  }

  internal delegate void Function<T, TParent>(
    T item,
    ref ActivityCreationOptions<TParent> data,
    ref ActivitySamplingResult samplingResult,
    ref ActivityCreationOptions<ActivityContext> dataWithContext);
}
