// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.ObservableInstrument`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

#nullable disable
namespace System.Diagnostics.Metrics;

[SecuritySafeCritical]
[ComVisible(true)]
public abstract class ObservableInstrument<T> : Instrument where T : struct
{
  [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.NullableContext(1)]
  protected ObservableInstrument(Meter meter, string name, [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(2)] string unit, [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(2)] string description)
    : base(meter, name, unit, description)
  {
    Instrument.ValidateTypeParameter<T>();
  }

  [return: System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(new byte[] {1, 0, 0})]
  protected abstract IEnumerable<Measurement<T>> Observe();

  public override bool IsObservable => true;

  [SecuritySafeCritical]
  internal override void Observe(MeterListener listener)
  {
    object subscriptionState = this.GetSubscriptionState(listener);
    IEnumerable<Measurement<T>> measurements = this.Observe();
    if (measurements == null)
      return;
    foreach (Measurement<T> measurement in measurements)
      listener.NotifyMeasurement<T>((Instrument) this, measurement.Value, measurement.Tags, subscriptionState);
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal IEnumerable<Measurement<T>> Observe(object callback)
  {
    switch (callback)
    {
      case Func<T> func1:
        return (IEnumerable<Measurement<T>>) new Measurement<T>[1]
        {
          new Measurement<T>(func1())
        };
      case Func<Measurement<T>> func2:
        return (IEnumerable<Measurement<T>>) new Measurement<T>[1]
        {
          func2()
        };
      case Func<IEnumerable<Measurement<T>>> func3:
        return func3();
      default:
        return (IEnumerable<Measurement<T>>) null;
    }
  }
}
