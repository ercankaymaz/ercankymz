// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.RateSumAggregator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Diagnostics.Metrics;

internal sealed class RateSumAggregator : Aggregator
{
  private double _sum;

  public override void Update(double value)
  {
    lock (this)
      this._sum += value;
  }

  public override IAggregationStatistics Collect()
  {
    lock (this)
    {
      RateStatistics rateStatistics = new RateStatistics(new double?(this._sum));
      this._sum = 0.0;
      return (IAggregationStatistics) rateStatistics;
    }
  }
}
