// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.ActivityCreationOptions`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

#nullable disable
namespace System.Diagnostics;

[System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.NullableContext(1)]
[System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(0)]
[System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.IsReadOnly]
[ComVisible(true)]
public struct ActivityCreationOptions<[System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(2)] T>
{
  private readonly ActivityTagsCollection _samplerTags;
  private readonly ActivityContext _context;

  internal ActivityCreationOptions(
    ActivitySource source,
    string name,
    T parent,
    ActivityKind kind,
    IEnumerable<KeyValuePair<string, object>> tags,
    IEnumerable<ActivityLink> links,
    ActivityIdFormat idFormat)
  {
    this.Source = source;
    this.Name = name;
    this.Kind = kind;
    this.Parent = parent;
    this.Tags = tags;
    this.Links = links;
    this.IdFormat = idFormat;
    if (this.IdFormat == ActivityIdFormat.Unknown && Activity.ForceDefaultIdFormat)
      this.IdFormat = Activity.DefaultIdFormat;
    this._samplerTags = (ActivityTagsCollection) null;
    switch (parent)
    {
      case ActivityContext activityContext when activityContext != new ActivityContext():
        this._context = activityContext;
        if (this.IdFormat != ActivityIdFormat.Unknown)
          break;
        this.IdFormat = ActivityIdFormat.W3C;
        break;
      case string traceParent when traceParent != null:
        if (this.IdFormat != ActivityIdFormat.Hierarchical)
        {
          if (ActivityContext.TryParse(traceParent, (string) null, out this._context))
            this.IdFormat = ActivityIdFormat.W3C;
          if (this.IdFormat != ActivityIdFormat.Unknown)
            break;
          this.IdFormat = ActivityIdFormat.Hierarchical;
          break;
        }
        this._context = new ActivityContext();
        break;
      default:
        this._context = new ActivityContext();
        if (this.IdFormat != ActivityIdFormat.Unknown)
          break;
        this.IdFormat = Activity.Current != null ? Activity.Current.IdFormat : Activity.DefaultIdFormat;
        break;
    }
  }

  public ActivitySource Source { get; }

  public string Name { get; }

  public ActivityKind Kind { get; }

  public T Parent { get; }

  [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(new byte[] {2, 0, 1, 2})]
  public IEnumerable<KeyValuePair<string, object>> Tags { [return: System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(new byte[] {2, 0, 1, 2})] get; }

  [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(2)]
  public IEnumerable<ActivityLink> Links { [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.NullableContext(2)] get; }

  public ActivityTagsCollection SamplingTags
  {
    [SecuritySafeCritical] get
    {
      if (this._samplerTags == null)
        Unsafe.AsRef<ActivityTagsCollection>(ref this._samplerTags) = new ActivityTagsCollection();
      return this._samplerTags;
    }
  }

  public ActivityTraceId TraceId
  {
    [SecuritySafeCritical] get
    {
      if ((object) this.Parent is ActivityContext && this.IdFormat == ActivityIdFormat.W3C && this._context == new ActivityContext())
      {
        Func<ActivityTraceId> traceIdGenerator = Activity.TraceIdGenerator;
        ActivityTraceId traceId = traceIdGenerator == null ? ActivityTraceId.CreateRandom() : traceIdGenerator();
        Unsafe.AsRef<ActivityContext>(ref this._context) = new ActivityContext(traceId, new ActivitySpanId(), ActivityTraceFlags.None);
      }
      return this._context.TraceId;
    }
  }

  internal ActivityIdFormat IdFormat { get; }

  internal ActivityTagsCollection GetSamplingTags() => this._samplerTags;

  internal ActivityContext GetContext() => this._context;
}
