// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.Meter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource;
using System.Runtime.InteropServices;
using System.Security;

#nullable disable
namespace System.Diagnostics.Metrics;

[NullableContext(2)]
[Nullable(0)]
[SecuritySafeCritical]
[ComVisible(true)]
public class Meter : IDisposable
{
  private static readonly List<Meter> s_allMeters = new List<Meter>();
  private List<Instrument> _instruments = new List<Instrument>();

  internal bool Disposed { get; private set; }

  [NullableContext(1)]
  public Meter(string name)
    : this(name, (string) null)
  {
  }

  [NullableContext(1)]
  public Meter(string name, [Nullable(2)] string version)
  {
    this.Name = name != null ? name : throw new ArgumentNullException(nameof (name));
    this.Version = version;
    lock (Instrument.SyncObject)
      Meter.s_allMeters.Add(this);
    GC.KeepAlive((object) MetricsEventSource.Log);
  }

  [Nullable(1)]
  public string Name { [NullableContext(1)] get; }

  public string Version { get; }

  [return: Nullable(new byte[] {1, 0})]
  public Counter<T> CreateCounter<[Nullable(0)] T>([Nullable(1)] string name, string unit = null, string description = null) where T : struct
  {
    return new Counter<T>(this, name, unit, description);
  }

  [return: Nullable(new byte[] {1, 0})]
  public Histogram<T> CreateHistogram<[Nullable(0)] T>(
    [Nullable(1)] string name,
    string unit = null,
    string description = null)
    where T : struct
  {
    return new Histogram<T>(this, name, unit, description);
  }

  [return: Nullable(new byte[] {1, 0})]
  public ObservableCounter<T> CreateObservableCounter<[Nullable(0)] T>(
    [Nullable(1)] string name,
    [Nullable(new byte[] {1, 0})] Func<T> observeValue,
    string unit = null,
    string description = null)
    where T : struct
  {
    return new ObservableCounter<T>(this, name, observeValue, unit, description);
  }

  [return: Nullable(new byte[] {1, 0})]
  public ObservableCounter<T> CreateObservableCounter<[Nullable(0)] T>(
    [Nullable(1)] string name,
    [Nullable(new byte[] {1, 0, 0})] Func<Measurement<T>> observeValue,
    string unit = null,
    string description = null)
    where T : struct
  {
    return new ObservableCounter<T>(this, name, observeValue, unit, description);
  }

  [return: Nullable(new byte[] {1, 0})]
  public ObservableCounter<T> CreateObservableCounter<[Nullable(0)] T>(
    [Nullable(1)] string name,
    [Nullable(new byte[] {1, 1, 0, 0})] Func<IEnumerable<Measurement<T>>> observeValues,
    string unit = null,
    string description = null)
    where T : struct
  {
    return new ObservableCounter<T>(this, name, observeValues, unit, description);
  }

  [return: Nullable(new byte[] {1, 0})]
  public ObservableGauge<T> CreateObservableGauge<[Nullable(0)] T>(
    [Nullable(1)] string name,
    [Nullable(new byte[] {1, 0})] Func<T> observeValue,
    string unit = null,
    string description = null)
    where T : struct
  {
    return new ObservableGauge<T>(this, name, observeValue, unit, description);
  }

  [return: Nullable(new byte[] {1, 0})]
  public ObservableGauge<T> CreateObservableGauge<[Nullable(0)] T>(
    [Nullable(1)] string name,
    [Nullable(new byte[] {1, 0, 0})] Func<Measurement<T>> observeValue,
    string unit = null,
    string description = null)
    where T : struct
  {
    return new ObservableGauge<T>(this, name, observeValue, unit, description);
  }

  [return: Nullable(new byte[] {1, 0})]
  public ObservableGauge<T> CreateObservableGauge<[Nullable(0)] T>(
    [Nullable(1)] string name,
    [Nullable(new byte[] {1, 1, 0, 0})] Func<IEnumerable<Measurement<T>>> observeValues,
    string unit = null,
    string description = null)
    where T : struct
  {
    return new ObservableGauge<T>(this, name, observeValues, unit, description);
  }

  public void Dispose()
  {
    List<Instrument> instrumentList = (List<Instrument>) null;
    lock (Instrument.SyncObject)
    {
      if (this.Disposed)
        return;
      this.Disposed = true;
      Meter.s_allMeters.Remove(this);
      instrumentList = this._instruments;
      this._instruments = new List<Instrument>();
    }
    if (instrumentList == null)
      return;
    foreach (Instrument instrument in instrumentList)
      instrument.NotifyForUnpublishedInstrument();
  }

  internal bool AddInstrument(Instrument instrument)
  {
    if (this._instruments.Contains(instrument))
      return false;
    this._instruments.Add(instrument);
    return true;
  }

  internal static List<Instrument> GetPublishedInstruments()
  {
    List<Instrument> publishedInstruments = (List<Instrument>) null;
    if (Meter.s_allMeters.Count > 0)
    {
      publishedInstruments = new List<Instrument>();
      foreach (Meter allMeter in Meter.s_allMeters)
      {
        foreach (Instrument instrument in allMeter._instruments)
          publishedInstruments.Add(instrument);
      }
    }
    return publishedInstruments;
  }
}
