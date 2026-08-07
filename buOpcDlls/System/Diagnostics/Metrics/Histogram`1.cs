// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.Histogram`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource;
using System.Runtime.InteropServices;
using System.Security;

#nullable disable
namespace System.Diagnostics.Metrics;

[SecuritySafeCritical]
[ComVisible(true)]
public sealed class Histogram<T> : Instrument<T> where T : struct
{
  internal Histogram(Meter meter, string name, string unit, string description)
    : base(meter, name, unit, description)
  {
    this.Publish();
  }

  public void Record(T value) => this.RecordMeasurement(value);

  public void Record(T value, [Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, object> tag)
  {
    this.RecordMeasurement(value, tag);
  }

  public void Record(T value, [Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, object> tag1, [Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, object> tag2)
  {
    this.RecordMeasurement(value, tag1, tag2);
  }

  public void Record(
    T value,
    [Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, object> tag1,
    [Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, object> tag2,
    [Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, object> tag3)
  {
    this.RecordMeasurement(value, tag1, tag2, tag3);
  }

  public void Record(T value, [Nullable(new byte[] {0, 0, 1, 2})] ReadOnlySpan<KeyValuePair<string, object>> tags)
  {
    this.RecordMeasurement(value, tags);
  }

  public void Record(T value, [Nullable(new byte[] {1, 0, 1, 2})] params KeyValuePair<string, object>[] tags)
  {
    this.RecordMeasurement(value, (ReadOnlySpan<KeyValuePair<string, object>>) tags.AsSpan<KeyValuePair<string, object>>());
  }

  public void Record(T value, [IsReadOnly, In] ref TagList tagList)
  {
    this.RecordMeasurement(value, ref tagList);
  }
}
