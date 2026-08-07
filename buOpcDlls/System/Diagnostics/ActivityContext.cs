// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.ActivityContext
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Diagnostics.CodeAnalysis.System.Diagnostics.DiagnosticSource3462135;
using System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource;
using System.Runtime.InteropServices;

#nullable disable
namespace System.Diagnostics;

[NullableContext(2)]
[Nullable(0)]
[IsReadOnly]
[ComVisible(true)]
public struct ActivityContext(
  ActivityTraceId traceId,
  ActivitySpanId spanId,
  ActivityTraceFlags traceFlags,
  string traceState = null,
  bool isRemote = false) : IEquatable<ActivityContext>
{
  public ActivityTraceId TraceId { get; } = traceId;

  public ActivitySpanId SpanId { get; } = spanId;

  public ActivityTraceFlags TraceFlags { get; } = traceFlags;

  public string TraceState { get; } = traceState;

  public bool IsRemote { get; } = isRemote;

  public static bool TryParse(string traceParent, string traceState, out ActivityContext context)
  {
    if (traceParent != null)
      return Activity.TryConvertIdToContext(traceParent, traceState, out context);
    context = new ActivityContext();
    return false;
  }

  [NullableContext(1)]
  public static ActivityContext Parse(string traceParent, [Nullable(2)] string traceState)
  {
    if (traceParent == null)
      throw new ArgumentNullException(nameof (traceParent));
    ActivityContext context;
    if (!Activity.TryConvertIdToContext(traceParent, traceState, out context))
      throw new ArgumentException(System.System.Diagnostics.DiagnosticSource3462135.SR.InvalidTraceParent);
    return context;
  }

  public bool Equals(ActivityContext value)
  {
    return this.SpanId.Equals(value.SpanId) && this.TraceId.Equals(value.TraceId) && this.TraceFlags == value.TraceFlags && this.TraceState == value.TraceState && this.IsRemote == value.IsRemote;
  }

  public override bool Equals([NotNullWhen(true)] object obj)
  {
    return obj is ActivityContext activityContext && this.Equals(activityContext);
  }

  public static bool operator ==(ActivityContext left, ActivityContext right) => left.Equals(right);

  public static bool operator !=(ActivityContext left, ActivityContext right) => !(left == right);

  public override int GetHashCode()
  {
    if (this == new ActivityContext())
      return 0;
    int num1 = 177573 + this.TraceId.GetHashCode();
    int num2 = (num1 << 5) + num1 + this.SpanId.GetHashCode();
    int num3 = (int) ((num2 << 5) + num2 + this.TraceFlags);
    return (num3 << 5) + num3 + (this.TraceState == null ? 0 : this.TraceState.GetHashCode());
  }
}
