// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.Counter`1
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
public sealed class Counter<T> : Instrument<T> where T : struct
{
  internal Counter(Meter meter, string name, string unit, string description)
    : base(meter, name, unit, description)
  {
    this.Publish();
  }

  public void Add(T delta) => this.RecordMeasurement(delta);

  public void Add(T delta, [Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, object> tag)
  {
    this.RecordMeasurement(delta, tag);
  }

  public void Add(T delta, [Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, object> tag1, [Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, object> tag2)
  {
    this.RecordMeasurement(delta, tag1, tag2);
  }

  public void Add(
    T delta,
    [Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, object> tag1,
    [Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, object> tag2,
    [Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, object> tag3)
  {
    this.RecordMeasurement(delta, tag1, tag2, tag3);
  }

  public void Add(T delta, [Nullable(new byte[] {0, 0, 1, 2})] ReadOnlySpan<KeyValuePair<string, object>> tags)
  {
    this.RecordMeasurement(delta, tags);
  }

  public void Add(T delta, [Nullable(new byte[] {1, 0, 1, 2})] params KeyValuePair<string, object>[] tags)
  {
    this.RecordMeasurement(delta, (ReadOnlySpan<KeyValuePair<string, object>>) tags.AsSpan<KeyValuePair<string, object>>());
  }

  public void Add(T delta, [IsReadOnly, In] ref TagList tagList)
  {
    this.RecordMeasurement(delta, ref tagList);
  }
}
