// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.RateAggregator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Diagnostics.Metrics;

internal sealed class RateAggregator : Aggregator
{
  private double? _prevValue;
  private double _value;

  public override void Update(double value)
  {
    lock (this)
      this._value = value;
  }

  public override IAggregationStatistics Collect()
  {
    lock (this)
    {
      double? delta = new double?();
      if (this._prevValue.HasValue)
        delta = new double?(this._value - this._prevValue.Value);
      RateStatistics rateStatistics = new RateStatistics(delta);
      this._prevValue = new double?(this._value);
      return (IAggregationStatistics) rateStatistics;
    }
  }
}
