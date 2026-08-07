// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.QuantileAggregation
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace System.Diagnostics.Metrics;

internal sealed class QuantileAggregation
{
  public QuantileAggregation(params double[] quantiles)
  {
    this.Quantiles = quantiles;
    Array.Sort<double>(this.Quantiles);
  }

  public double[] Quantiles { get; set; }

  public double MaxRelativeError { get; set; } = 0.001;
}
