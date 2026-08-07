// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.PassThroughPropagator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;

#nullable disable
namespace System.Diagnostics;

internal sealed class PassThroughPropagator : DistributedContextPropagator
{
  internal static DistributedContextPropagator Instance { get; } = (DistributedContextPropagator) new PassThroughPropagator();

  public override IReadOnlyCollection<string> Fields { get; } = LegacyPropagator.Instance.Fields;

  public override void Inject(
    Activity activity,
    object carrier,
    DistributedContextPropagator.PropagatorSetterCallback setter)
  {
    if (setter == null)
      return;
    string parentId;
    string traceState;
    bool isW3c;
    IEnumerable<KeyValuePair<string, string>> baggage;
    PassThroughPropagator.GetRootId(out parentId, out traceState, out isW3c, out baggage);
    if (parentId == null)
      return;
    setter(carrier, isW3c ? "traceparent" : "Request-Id", parentId);
    if (!string.IsNullOrEmpty(traceState))
      setter(carrier, "tracestate", traceState);
    if (baggage == null)
      return;
    DistributedContextPropagator.InjectBaggage(carrier, baggage, setter);
  }

  public override void ExtractTraceIdAndState(
    object carrier,
    DistributedContextPropagator.PropagatorGetterCallback getter,
    out string traceId,
    out string traceState)
  {
    LegacyPropagator.Instance.ExtractTraceIdAndState(carrier, getter, out traceId, out traceState);
  }

  public override IEnumerable<KeyValuePair<string, string>> ExtractBaggage(
    object carrier,
    DistributedContextPropagator.PropagatorGetterCallback getter)
  {
    return LegacyPropagator.Instance.ExtractBaggage(carrier, getter);
  }

  private static void GetRootId(
    out string parentId,
    out string traceState,
    out bool isW3c,
    out IEnumerable<KeyValuePair<string, string>> baggage)
  {
    Activity activity = Activity.Current;
    while (true)
    {
      Activity parent = activity?.Parent;
      if (parent != null)
        activity = parent;
      else
        break;
    }
    traceState = activity?.TraceStateString;
    ref string local = ref parentId;
    string str;
    if (activity == null)
    {
      str = (string) null;
    }
    else
    {
      str = activity.ParentId;
      if (str != null)
        goto label_7;
    }
    str = activity?.Id;
label_7:
    local = str;
    isW3c = parentId != null && Activity.TryConvertIdToContext(parentId, traceState, out ActivityContext _);
    baggage = activity?.Baggage;
  }
}
