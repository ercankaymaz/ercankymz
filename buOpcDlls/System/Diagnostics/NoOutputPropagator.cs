// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.NoOutputPropagator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;

#nullable disable
namespace System.Diagnostics;

internal sealed class NoOutputPropagator : DistributedContextPropagator
{
  internal static DistributedContextPropagator Instance { get; } = (DistributedContextPropagator) new NoOutputPropagator();

  public override IReadOnlyCollection<string> Fields { get; } = LegacyPropagator.Instance.Fields;

  public override void Inject(
    Activity activity,
    object carrier,
    DistributedContextPropagator.PropagatorSetterCallback setter)
  {
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
}
