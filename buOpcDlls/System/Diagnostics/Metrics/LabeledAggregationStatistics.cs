// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.LabeledAggregationStatistics
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;

#nullable disable
namespace System.Diagnostics.Metrics;

internal sealed class LabeledAggregationStatistics
{
  public LabeledAggregationStatistics(
    IAggregationStatistics stats,
    params KeyValuePair<string, string>[] labels)
  {
    this.AggregationStatistics = stats;
    this.Labels = labels;
  }

  public KeyValuePair<string, string>[] Labels { get; }

  public IAggregationStatistics AggregationStatistics { get; }
}
