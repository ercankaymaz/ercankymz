// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.MeterListener
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
public sealed class MeterListener : IDisposable
{
  private static List<MeterListener> s_allStartedListeners = new List<MeterListener>();
  private DiagLinkedList<Instrument> _enabledMeasurementInstruments = new DiagLinkedList<Instrument>();
  private bool _disposed;
  private MeasurementCallback<byte> _byteMeasurementCallback = (MeasurementCallback<byte>) ((instrument, measurement, tags, state) => { });
  private MeasurementCallback<short> _shortMeasurementCallback = (MeasurementCallback<short>) ((instrument, measurement, tags, state) => { });
  private MeasurementCallback<int> _intMeasurementCallback = (MeasurementCallback<int>) ((instrument, measurement, tags, state) => { });
  private MeasurementCallback<long> _longMeasurementCallback = (MeasurementCallback<long>) ((instrument, measurement, tags, state) => { });
  private MeasurementCallback<float> _floatMeasurementCallback = (MeasurementCallback<float>) ((instrument, measurement, tags, state) => { });
  private MeasurementCallback<double> _doubleMeasurementCallback = (MeasurementCallback<double>) ((instrument, measurement, tags, state) => { });
  private MeasurementCallback<Decimal> _decimalMeasurementCallback = (MeasurementCallback<Decimal>) ((instrument, measurement, tags, state) => { });

  [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(new byte[] {2, 1, 1})]
  public Action<Instrument, MeterListener> InstrumentPublished { [return: System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(new byte[] {2, 1, 1})] get; [param: System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(new byte[] {2, 1, 1})] set; }

  [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(new byte[] {2, 1, 2})]
  public Action<Instrument, object> MeasurementsCompleted { [return: System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(new byte[] {2, 1, 2})] get; [param: System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(new byte[] {2, 1, 2})] set; }

  [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.NullableContext(1)]
  public void EnableMeasurementEvents(Instrument instrument, [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(2)] object state = null)
  {
    bool oldStateStored = false;
    bool flag = false;
    object obj = (object) null;
    lock (Instrument.SyncObject)
    {
      if (instrument != null)
      {
        if (!this._disposed)
        {
          if (!instrument.Meter.Disposed)
          {
            this._enabledMeasurementInstruments.AddIfNotExist(instrument, (Func<Instrument, Instrument, bool>) ((instrument1, instrument2) => instrument1 == instrument2));
            obj = instrument.EnableMeasurement(new ListenerSubscription(this, state), out oldStateStored);
            flag = true;
          }
        }
      }
    }
    if (flag)
    {
      if (!oldStateStored || this.MeasurementsCompleted == null)
        return;
      Action<Instrument, object> measurementsCompleted = this.MeasurementsCompleted;
      if (measurementsCompleted == null)
        return;
      measurementsCompleted(instrument, obj);
    }
    else
    {
      Action<Instrument, object> measurementsCompleted = this.MeasurementsCompleted;
      if (measurementsCompleted == null)
        return;
      measurementsCompleted(instrument, state);
    }
  }

  [System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.NullableContext(1)]
  [return: System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(2)]
  public object DisableMeasurementEvents(Instrument instrument)
  {
    object obj = (object) null;
    lock (Instrument.SyncObject)
    {
      if (instrument == null || this._enabledMeasurementInstruments.Remove(instrument, (Func<Instrument, Instrument, bool>) ((instrument1, instrument2) => instrument1 == instrument2)) == null)
        return (object) null;
      obj = instrument.DisableMeasurements(this);
    }
    Action<Instrument, object> measurementsCompleted = this.MeasurementsCompleted;
    if (measurementsCompleted != null)
      measurementsCompleted(instrument, obj);
    return obj;
  }

  public void SetMeasurementEventCallback<T>([System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource.Nullable(new byte[] {2, 0})] MeasurementCallback<T> measurementCallback) where T : struct
  {
    switch (measurementCallback)
    {
      case MeasurementCallback<byte> measurementCallback1:
        this._byteMeasurementCallback = measurementCallback == null ? (MeasurementCallback<byte>) ((instrument, measurement, tags, state) => { }) : measurementCallback1;
        break;
      case MeasurementCallback<int> measurementCallback2:
        this._intMeasurementCallback = measurementCallback == null ? (MeasurementCallback<int>) ((instrument, measurement, tags, state) => { }) : measurementCallback2;
        break;
      case MeasurementCallback<float> measurementCallback3:
        this._floatMeasurementCallback = measurementCallback == null ? (MeasurementCallback<float>) ((instrument, measurement, tags, state) => { }) : measurementCallback3;
        break;
      case MeasurementCallback<double> measurementCallback4:
        this._doubleMeasurementCallback = measurementCallback == null ? (MeasurementCallback<double>) ((instrument, measurement, tags, state) => { }) : measurementCallback4;
        break;
      case MeasurementCallback<Decimal> measurementCallback5:
        this._decimalMeasurementCallback = measurementCallback == null ? (MeasurementCallback<Decimal>) ((instrument, measurement, tags, state) => { }) : measurementCallback5;
        break;
      case MeasurementCallback<short> measurementCallback6:
        this._shortMeasurementCallback = measurementCallback == null ? (MeasurementCallback<short>) ((instrument, measurement, tags, state) => { }) : measurementCallback6;
        break;
      case MeasurementCallback<long> measurementCallback7:
        this._longMeasurementCallback = measurementCallback == null ? (MeasurementCallback<long>) ((instrument, measurement, tags, state) => { }) : measurementCallback7;
        break;
      default:
        throw new InvalidOperationException(System.System.Diagnostics.DiagnosticSource3462135.SR.Format(System.System.Diagnostics.DiagnosticSource3462135.SR.UnsupportedType, (object) typeof (T)));
    }
  }

  public void Start()
  {
    List<Instrument> instrumentList = (List<Instrument>) null;
    lock (Instrument.SyncObject)
    {
      if (this._disposed)
        return;
      if (!MeterListener.s_allStartedListeners.Contains(this))
      {
        MeterListener.s_allStartedListeners.Add(this);
        instrumentList = Meter.GetPublishedInstruments();
      }
    }
    if (instrumentList == null)
      return;
    foreach (Instrument instrument in instrumentList)
    {
      Action<Instrument, MeterListener> instrumentPublished = this.InstrumentPublished;
      if (instrumentPublished != null)
        instrumentPublished(instrument, this);
    }
  }

  public void RecordObservableInstruments()
  {
    List<Exception> innerExceptions = (List<Exception>) null;
    for (DiagNode<Instrument> diagNode = this._enabledMeasurementInstruments.First; diagNode != null; diagNode = diagNode.Next)
    {
      if (diagNode.Value.IsObservable)
      {
        try
        {
          diagNode.Value.Observe(this);
        }
        catch (Exception ex)
        {
          if (innerExceptions == null)
            innerExceptions = new List<Exception>();
          innerExceptions.Add(ex);
        }
      }
    }
    if (innerExceptions != null)
      throw new AggregateException((IEnumerable<Exception>) innerExceptions);
  }

  public void Dispose()
  {
    Dictionary<Instrument, object> dictionary = (Dictionary<Instrument, object>) null;
    Action<Instrument, object> measurementsCompleted = this.MeasurementsCompleted;
    lock (Instrument.SyncObject)
    {
      if (this._disposed)
        return;
      this._disposed = true;
      MeterListener.s_allStartedListeners.Remove(this);
      DiagNode<Instrument> diagNode = this._enabledMeasurementInstruments.First;
      if (diagNode != null)
      {
        if (measurementsCompleted != null)
        {
          dictionary = new Dictionary<Instrument, object>();
          do
          {
            object obj = diagNode.Value.DisableMeasurements(this);
            dictionary.Add(diagNode.Value, obj);
            diagNode = diagNode.Next;
          }
          while (diagNode != null);
          this._enabledMeasurementInstruments.Clear();
        }
      }
    }
    if (dictionary == null)
      return;
    foreach (KeyValuePair<Instrument, object> keyValuePair in dictionary)
    {
      if (measurementsCompleted != null)
        measurementsCompleted(keyValuePair.Key, keyValuePair.Value);
    }
  }

  internal static List<MeterListener> GetAllListeners()
  {
    return MeterListener.s_allStartedListeners.Count != 0 ? new List<MeterListener>((IEnumerable<MeterListener>) MeterListener.s_allStartedListeners) : (List<MeterListener>) null;
  }

  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  internal void NotifyMeasurement<T>(
    Instrument instrument,
    T measurement,
    ReadOnlySpan<KeyValuePair<string, object>> tags,
    object state)
    where T : struct
  {
    if (typeof (T) == typeof (byte))
      this._byteMeasurementCallback(instrument, (byte) (ValueType) measurement, tags, state);
    if (typeof (T) == typeof (short))
      this._shortMeasurementCallback(instrument, (short) (ValueType) measurement, tags, state);
    if (typeof (T) == typeof (int))
      this._intMeasurementCallback(instrument, (int) (ValueType) measurement, tags, state);
    if (typeof (T) == typeof (long))
      this._longMeasurementCallback(instrument, (long) (ValueType) measurement, tags, state);
    if (typeof (T) == typeof (float))
      this._floatMeasurementCallback(instrument, (float) (ValueType) measurement, tags, state);
    if (typeof (T) == typeof (double))
      this._doubleMeasurementCallback(instrument, (double) (ValueType) measurement, tags, state);
    if (!(typeof (T) == typeof (Decimal)))
      return;
    this._decimalMeasurementCallback(instrument, (Decimal) (ValueType) measurement, tags, state);
  }
}
