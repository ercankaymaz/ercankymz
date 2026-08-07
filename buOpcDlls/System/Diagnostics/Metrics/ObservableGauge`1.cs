// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.ObservableGauge`1
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
public sealed class ObservableGauge<T> : ObservableInstrument<T> where T : struct
{
  private object _callback;

  internal ObservableGauge(
    Meter meter,
    string name,
    Func<T> observeValue,
    string unit,
    string description)
    : base(meter, name, unit, description)
  {
    this._callback = observeValue != null ? (object) observeValue : throw new ArgumentNullException(nameof (observeValue));
    this.Publish();
  }

  internal ObservableGauge(
    Meter meter,
    string name,
    Func<Measurement<T>> observeValue,
    string unit,
    string description)
    : base(meter, name, unit, description)
  {
    this._callback = observeValue != null ? (object) observeValue : throw new ArgumentNullException(nameof (observeValue));
    this.Publish();
  }

  internal ObservableGauge(
    Meter meter,
    string name,
    Func<IEnumerable<Measurement<T>>> observeValues,
    string unit,
    string description)
    : base(meter, name, unit, description)
  {
    this._callback = observeValues != null ? (object) observeValues : throw new ArgumentNullException(nameof (observeValues));
    this.Publish();
  }

  [return: Nullable(new byte[] {1, 0, 0})]
  protected override IEnumerable<Measurement<T>> Observe() => this.Observe(this._callback);
}
