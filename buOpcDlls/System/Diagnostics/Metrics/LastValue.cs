// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.LastValue
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Diagnostics.Metrics;

internal sealed class LastValue : Aggregator
{
  private double? _lastValue;

  public override void Update(double value) => this._lastValue = new double?(value);

  public override IAggregationStatistics Collect()
  {
    lock (this)
    {
      LastValueStatistics lastValueStatistics = new LastValueStatistics(this._lastValue);
      this._lastValue = new double?();
      return (IAggregationStatistics) lastValueStatistics;
    }
  }
}
