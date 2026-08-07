// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.Measurement`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource;
using System.Runtime.InteropServices;
using System.Security;

#nullable disable
namespace System.Diagnostics.Metrics;

[IsReadOnly]
[SecuritySafeCritical]
[ComVisible(true)]
public struct Measurement<T> where T : struct
{
  private readonly KeyValuePair<string, object>[] _tags;

  public Measurement(T value)
  {
    this._tags = Instrument.EmptyTags;
    this.Value = value;
  }

  public Measurement(T value, [Nullable(new byte[] {2, 0, 1, 2})] IEnumerable<KeyValuePair<string, object>> tags)
  {
    this._tags = Measurement<T>.ToArray(tags);
    this.Value = value;
  }

  public Measurement(T value, [Nullable(new byte[] {2, 0, 1, 2})] params KeyValuePair<string, object>[] tags)
  {
    if (tags != null)
    {
      this._tags = new KeyValuePair<string, object>[tags.Length];
      tags.CopyTo((Array) this._tags, 0);
    }
    else
      this._tags = Instrument.EmptyTags;
    this.Value = value;
  }

  public Measurement(T value, [Nullable(new byte[] {0, 0, 1, 2})] ReadOnlySpan<KeyValuePair<string, object>> tags)
  {
    this._tags = tags.ToArray();
    this.Value = value;
  }

  [Nullable(new byte[] {0, 0, 1, 2})]
  public ReadOnlySpan<KeyValuePair<string, object>> Tags
  {
    [return: Nullable(new byte[] {0, 0, 1, 2})] get
    {
      return (ReadOnlySpan<KeyValuePair<string, object>>) this._tags.AsSpan<KeyValuePair<string, object>>();
    }
  }

  public T Value { get; }

  private static KeyValuePair<string, object>[] ToArray(
    IEnumerable<KeyValuePair<string, object>> tags)
  {
    return tags != null ? new List<KeyValuePair<string, object>>(tags).ToArray() : Instrument.EmptyTags;
  }
}
