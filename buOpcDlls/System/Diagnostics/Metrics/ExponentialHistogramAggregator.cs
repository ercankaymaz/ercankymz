// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.ExponentialHistogramAggregator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;

#nullable disable
namespace System.Diagnostics.Metrics;

internal sealed class ExponentialHistogramAggregator : Aggregator
{
  private const int ExponentArraySize = 4096 /*0x1000*/;
  private const int ExponentShift = 52;
  private const double MinRelativeError = 0.0001;
  private readonly QuantileAggregation _config;
  private int[][] _counters;
  private int _count;
  private readonly int _mantissaMax;
  private readonly int _mantissaMask;
  private readonly int _mantissaShift;

  public ExponentialHistogramAggregator(QuantileAggregation config)
  {
    this._config = config;
    this._counters = new int[4096 /*0x1000*/][];
    if (this._config.MaxRelativeError < 0.0001)
      throw new ArgumentException();
    int num = (int) Math.Ceiling(Math.Log(1.0 / this._config.MaxRelativeError, 2.0)) - 1;
    this._mantissaShift = 52 - num;
    this._mantissaMax = 1 << num;
    this._mantissaMask = this._mantissaMax - 1;
  }

  public override IAggregationStatistics Collect()
  {
    int[][] counters;
    int count1;
    lock (this)
    {
      counters = this._counters;
      count1 = this._count;
      this._counters = new int[4096 /*0x1000*/][];
      this._count = 0;
    }
    QuantileValue[] quantiles = new QuantileValue[this._config.Quantiles.Length];
    int index = 0;
    if (0 == this._config.Quantiles.Length)
      return (IAggregationStatistics) new HistogramStatistics(quantiles);
    int count2 = count1 - this.GetInvalidCount(counters);
    int rank = this.QuantileToRank(this._config.Quantiles[index], count2);
    int num = 0;
    foreach (ExponentialHistogramAggregator.Bucket iterateBucket in this.IterateBuckets(counters))
    {
      for (num += iterateBucket.Count; num > rank; rank = this.QuantileToRank(this._config.Quantiles[index], count2))
      {
        quantiles[index] = new QuantileValue(this._config.Quantiles[index], iterateBucket.Value);
        ++index;
        if (index == this._config.Quantiles.Length)
          return (IAggregationStatistics) new HistogramStatistics(quantiles);
      }
    }
    return (IAggregationStatistics) new HistogramStatistics(Array.Empty<QuantileValue>());
  }

  private int GetInvalidCount(int[][] counters)
  {
    int[] counter1 = counters[2047 /*0x07FF*/];
    int[] counter2 = counters[4095 /*0x0FFF*/];
    int invalidCount = 0;
    if (counter1 != null)
    {
      foreach (int num in counter1)
        invalidCount += num;
    }
    if (counter2 != null)
    {
      foreach (int num in counter2)
        invalidCount += num;
    }
    return invalidCount;
  }

  private IEnumerable<ExponentialHistogramAggregator.Bucket> IterateBuckets(int[][] counters)
  {
    int exponent;
    int[] mantissaCounts;
    int mantissa;
    for (exponent = 4094; exponent >= 2048 /*0x0800*/; --exponent)
    {
      mantissaCounts = counters[exponent];
      if (mantissaCounts == null)
        continue;
      for (mantissa = this._mantissaMax - 1; mantissa >= 0; --mantissa)
      {
        int count = mantissaCounts[mantissa];
        if (count <= 0)
          continue;
        yield return new ExponentialHistogramAggregator.Bucket(this.GetBucketCanonicalValue(exponent, mantissa), count);
      }
      mantissaCounts = (int[]) null;
    }
    for (exponent = 0; exponent < 2047 /*0x07FF*/; ++exponent)
    {
      mantissaCounts = counters[exponent];
      if (mantissaCounts == null)
        continue;
      for (mantissa = 0; mantissa < this._mantissaMax; ++mantissa)
      {
        int count = mantissaCounts[mantissa];
        if (count <= 0)
          continue;
        yield return new ExponentialHistogramAggregator.Bucket(this.GetBucketCanonicalValue(exponent, mantissa), count);
      }
      mantissaCounts = (int[]) null;
    }
  }

  public override void Update(double measurement)
  {
    lock (this)
    {
      ulong int64Bits = (ulong) BitConverter.DoubleToInt64Bits(measurement);
      int index1 = (int) (int64Bits >> 52);
      int index2 = (int) (int64Bits >> this._mantissaShift) & this._mantissaMask;
      ref int[] local = ref this._counters[index1];
      if (local == null)
        local = new int[this._mantissaMax];
      ++local[index2];
      ++this._count;
    }
  }

  private int QuantileToRank(double quantile, int count)
  {
    return Math.Min(Math.Max(0, (int) (quantile * (double) count)), count - 1);
  }

  private double GetBucketCanonicalValue(int exponent, int mantissa)
  {
    return BitConverter.Int64BitsToDouble((long) exponent << 52 | (long) mantissa << this._mantissaShift);
  }

  private struct Bucket(double value, int count)
  {
    public double Value = value;
    public int Count = count;
  }
}
