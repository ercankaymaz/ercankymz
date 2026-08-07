// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.Instrument`1
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
public abstract class Instrument<T> : Instrument where T : struct
{
  [ThreadStatic]
  private KeyValuePair<string, object>[] ts_tags;
  private const int MaxTagsCount = 8;

  [NullableContext(1)]
  protected Instrument(Meter meter, string name, [Nullable(2)] string unit, [Nullable(2)] string description)
    : base(meter, name, unit, description)
  {
    Instrument.ValidateTypeParameter<T>();
  }

  protected void RecordMeasurement(T measurement)
  {
    this.RecordMeasurement(measurement, (ReadOnlySpan<KeyValuePair<string, object>>) Instrument.EmptyTags.AsSpan<KeyValuePair<string, object>>());
  }

  protected void RecordMeasurement(T measurement, [Nullable(new byte[] {0, 0, 1, 2})] ReadOnlySpan<KeyValuePair<string, object>> tags)
  {
    for (DiagNode<ListenerSubscription> diagNode = this._subscriptions.First; diagNode != null; diagNode = diagNode.Next)
      diagNode.Value.Listener.NotifyMeasurement<T>((Instrument) this, measurement, tags, diagNode.Value.State);
  }

  protected void RecordMeasurement(T measurement, [Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, object> tag)
  {
    KeyValuePair<string, object>[] array = this.ts_tags ?? new KeyValuePair<string, object>[8];
    this.ts_tags = (KeyValuePair<string, object>[]) null;
    array[0] = tag;
    this.RecordMeasurement(measurement, (ReadOnlySpan<KeyValuePair<string, object>>) array.AsSpan<KeyValuePair<string, object>>().Slice(0, 1));
    this.ts_tags = array;
  }

  protected void RecordMeasurement(
    T measurement,
    [Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, object> tag1,
    [Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, object> tag2)
  {
    KeyValuePair<string, object>[] array = this.ts_tags ?? new KeyValuePair<string, object>[8];
    this.ts_tags = (KeyValuePair<string, object>[]) null;
    array[0] = tag1;
    array[1] = tag2;
    this.RecordMeasurement(measurement, (ReadOnlySpan<KeyValuePair<string, object>>) array.AsSpan<KeyValuePair<string, object>>().Slice(0, 2));
    this.ts_tags = array;
  }

  protected void RecordMeasurement(
    T measurement,
    [Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, object> tag1,
    [Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, object> tag2,
    [Nullable(new byte[] {0, 1, 2})] KeyValuePair<string, object> tag3)
  {
    KeyValuePair<string, object>[] array = this.ts_tags ?? new KeyValuePair<string, object>[8];
    this.ts_tags = (KeyValuePair<string, object>[]) null;
    array[0] = tag1;
    array[1] = tag2;
    array[2] = tag3;
    this.RecordMeasurement(measurement, (ReadOnlySpan<KeyValuePair<string, object>>) array.AsSpan<KeyValuePair<string, object>>().Slice(0, 3));
    this.ts_tags = array;
  }

  protected void RecordMeasurement(T measurement, [IsReadOnly, In] ref TagList tagList)
  {
    KeyValuePair<string, object>[] tags = tagList.Tags;
    if (tags != null)
    {
      this.RecordMeasurement(measurement, (ReadOnlySpan<KeyValuePair<string, object>>) tags.AsSpan<KeyValuePair<string, object>>().Slice(0, tagList.Count));
    }
    else
    {
      KeyValuePair<string, object>[] array = this.ts_tags ?? new KeyValuePair<string, object>[8];
      switch (tagList.Count)
      {
        case 1:
          array[0] = tagList.Tag1;
          this.ts_tags = (KeyValuePair<string, object>[]) null;
          this.RecordMeasurement(measurement, (ReadOnlySpan<KeyValuePair<string, object>>) array.AsSpan<KeyValuePair<string, object>>().Slice(0, tagList.Count));
          this.ts_tags = array;
          break;
        case 2:
          array[1] = tagList.Tag2;
          goto case 1;
        case 3:
          array[2] = tagList.Tag3;
          goto case 2;
        case 4:
          array[3] = tagList.Tag4;
          goto case 3;
        case 5:
          array[4] = tagList.Tag5;
          goto case 4;
        case 6:
          array[5] = tagList.Tag6;
          goto case 5;
        case 7:
          array[6] = tagList.Tag7;
          goto case 6;
        case 8:
          array[7] = tagList.Tag8;
          goto case 7;
      }
    }
  }
}
