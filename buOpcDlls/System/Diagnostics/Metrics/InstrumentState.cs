// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.InstrumentState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Security;

#nullable disable
namespace System.Diagnostics.Metrics;

internal abstract class InstrumentState
{
  [SecuritySafeCritical]
  public abstract void Update(double measurement, ReadOnlySpan<KeyValuePair<string, object>> labels);

  public abstract void Collect(
    Instrument instrument,
    Action<LabeledAggregationStatistics> aggregationVisitFunc);
}
