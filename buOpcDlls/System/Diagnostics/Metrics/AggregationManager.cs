// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.AggregationManager
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.Versioning;
using System.Security;
using System.Threading;

#nullable disable
namespace System.Diagnostics.Metrics;

[UnsupportedOSPlatform("browser")]
[SecuritySafeCritical]
internal sealed class AggregationManager
{
  public const double MinCollectionTimeSecs = 0.1;
  private static readonly QuantileAggregation s_defaultHistogramConfig = new QuantileAggregation(new double[3]
  {
    0.5,
    0.95,
    0.99
  });
  private readonly List<Predicate<Instrument>> _instrumentConfigFuncs = new List<Predicate<Instrument>>();
  private TimeSpan _collectionPeriod;
  private readonly ConcurrentDictionary<Instrument, InstrumentState> _instrumentStates = new ConcurrentDictionary<Instrument, InstrumentState>();
  private readonly CancellationTokenSource _cts = new CancellationTokenSource();
  private Thread _collectThread;
  private readonly MeterListener _listener;
  private int _currentTimeSeries;
  private int _currentHistograms;
  private readonly int _maxTimeSeries;
  private readonly int _maxHistograms;
  private readonly Action<Instrument, LabeledAggregationStatistics> _collectMeasurement;
  private readonly Action<DateTime, DateTime> _beginCollection;
  private readonly Action<DateTime, DateTime> _endCollection;
  private readonly Action<Instrument> _beginInstrumentMeasurements;
  private readonly Action<Instrument> _endInstrumentMeasurements;
  private readonly Action<Instrument> _instrumentPublished;
  private readonly Action _initialInstrumentEnumerationComplete;
  private readonly Action<Exception> _collectionError;
  private readonly Action _timeSeriesLimitReached;
  private readonly Action _histogramLimitReached;
  private readonly Action<Exception> _observableInstrumentCallbackError;

  public AggregationManager(
    int maxTimeSeries,
    int maxHistograms,
    Action<Instrument, LabeledAggregationStatistics> collectMeasurement,
    Action<DateTime, DateTime> beginCollection,
    Action<DateTime, DateTime> endCollection,
    Action<Instrument> beginInstrumentMeasurements,
    Action<Instrument> endInstrumentMeasurements,
    Action<Instrument> instrumentPublished,
    Action initialInstrumentEnumerationComplete,
    Action<Exception> collectionError,
    Action timeSeriesLimitReached,
    Action histogramLimitReached,
    Action<Exception> observableInstrumentCallbackError)
  {
    this._maxTimeSeries = maxTimeSeries;
    this._maxHistograms = maxHistograms;
    this._collectMeasurement = collectMeasurement;
    this._beginCollection = beginCollection;
    this._endCollection = endCollection;
    this._beginInstrumentMeasurements = beginInstrumentMeasurements;
    this._endInstrumentMeasurements = endInstrumentMeasurements;
    this._instrumentPublished = instrumentPublished;
    this._initialInstrumentEnumerationComplete = initialInstrumentEnumerationComplete;
    this._collectionError = collectionError;
    this._timeSeriesLimitReached = timeSeriesLimitReached;
    this._histogramLimitReached = histogramLimitReached;
    this._observableInstrumentCallbackError = observableInstrumentCallbackError;
    this._listener = new MeterListener()
    {
      InstrumentPublished = (Action<Instrument, MeterListener>) ((instrument, listener) =>
      {
        this._instrumentPublished(instrument);
        InstrumentState instrumentState = this.GetInstrumentState(instrument);
        if (instrumentState == null)
          return;
        this._beginInstrumentMeasurements(instrument);
        listener.EnableMeasurementEvents(instrument, (object) instrumentState);
      }),
      MeasurementsCompleted = (Action<Instrument, object>) ((instrument, cookie) =>
      {
        this._endInstrumentMeasurements(instrument);
        this.RemoveInstrumentState(instrument, (InstrumentState) cookie);
      })
    };
    this._listener.SetMeasurementEventCallback<double>((MeasurementCallback<double>) ((i, m, l, c) => ((InstrumentState) c).Update(m, l)));
    this._listener.SetMeasurementEventCallback<float>((MeasurementCallback<float>) ((i, m, l, c) => ((InstrumentState) c).Update((double) m, l)));
    this._listener.SetMeasurementEventCallback<long>((MeasurementCallback<long>) ((i, m, l, c) => ((InstrumentState) c).Update((double) m, l)));
    this._listener.SetMeasurementEventCallback<int>((MeasurementCallback<int>) ((i, m, l, c) => ((InstrumentState) c).Update((double) m, l)));
    this._listener.SetMeasurementEventCallback<short>((MeasurementCallback<short>) ((i, m, l, c) => ((InstrumentState) c).Update((double) m, l)));
    this._listener.SetMeasurementEventCallback<byte>((MeasurementCallback<byte>) ((i, m, l, c) => ((InstrumentState) c).Update((double) m, l)));
    this._listener.SetMeasurementEventCallback<Decimal>((MeasurementCallback<Decimal>) ((i, m, l, c) => ((InstrumentState) c).Update((double) m, l)));
  }

  public void Include(string meterName)
  {
    this.Include((Predicate<Instrument>) (i => i.Meter.Name == meterName));
  }

  public void Include(string meterName, string instrumentName)
  {
    this.Include((Predicate<Instrument>) (i => i.Meter.Name == meterName && i.Name == instrumentName));
  }

  private void Include(Predicate<Instrument> instrumentFilter)
  {
    lock (this)
      this._instrumentConfigFuncs.Add(instrumentFilter);
  }

  public AggregationManager SetCollectionPeriod(TimeSpan collectionPeriod)
  {
    lock (this)
      this._collectionPeriod = collectionPeriod;
    return this;
  }

  public void Start()
  {
    this._collectThread = new Thread((ThreadStart) (() => this.CollectWorker(this._cts.Token)));
    this._collectThread.IsBackground = true;
    this._collectThread.Name = "MetricsEventSource CollectWorker";
    this._collectThread.Start();
    this._listener.Start();
    this._initialInstrumentEnumerationComplete();
  }

  private void CollectWorker(CancellationToken cancelToken)
  {
    try
    {
      double num1 = -1.0;
      lock (this)
        num1 = this._collectionPeriod.TotalSeconds;
      DateTime utcNow1 = DateTime.UtcNow;
      DateTime dateTime1 = utcNow1;
      while (!cancelToken.IsCancellationRequested)
      {
        DateTime utcNow2 = DateTime.UtcNow;
        double num2 = Math.Ceiling((utcNow2 - utcNow1).TotalSeconds / num1) * num1;
        DateTime dateTime2 = utcNow1.AddSeconds(num2);
        DateTime dateTime3 = dateTime1.AddSeconds(num1);
        if (dateTime2 <= dateTime3)
          dateTime2 = dateTime3;
        TimeSpan timeout = dateTime2 - utcNow2;
        if (cancelToken.WaitHandle.WaitOne(timeout))
          break;
        this._beginCollection(dateTime1, dateTime2);
        this.Collect();
        this._endCollection(dateTime1, dateTime2);
        dateTime1 = dateTime2;
      }
    }
    catch (Exception ex)
    {
      this._collectionError(ex);
    }
  }

  public void Dispose()
  {
    this._cts.Cancel();
    if (this._collectThread != null)
    {
      this._collectThread.Join();
      this._collectThread = (Thread) null;
    }
    this._listener.Dispose();
  }

  private void RemoveInstrumentState(Instrument instrument, InstrumentState state)
  {
    this._instrumentStates.TryRemove(instrument, out InstrumentState _);
  }

  private InstrumentState GetInstrumentState(Instrument instrument)
  {
    InstrumentState instrumentState;
    if (!this._instrumentStates.TryGetValue(instrument, out instrumentState))
    {
      lock (this)
      {
        foreach (Predicate<Instrument> instrumentConfigFunc in this._instrumentConfigFuncs)
        {
          if (instrumentConfigFunc(instrument))
          {
            instrumentState = this.BuildInstrumentState(instrument);
            if (instrumentState != null)
            {
              this._instrumentStates.TryAdd(instrument, instrumentState);
              this._instrumentStates.TryGetValue(instrument, out instrumentState);
              break;
            }
            break;
          }
        }
      }
    }
    return instrumentState;
  }

  internal InstrumentState BuildInstrumentState(Instrument instrument)
  {
    Func<Aggregator> aggregatorFactory = this.GetAggregatorFactory(instrument);
    if (aggregatorFactory == null)
      return (InstrumentState) null;
    return (InstrumentState) Activator.CreateInstance(typeof (InstrumentState<>).MakeGenericType(aggregatorFactory.GetType().GenericTypeArguments[0]), (object) aggregatorFactory);
  }

  private Func<Aggregator> GetAggregatorFactory(Instrument instrument)
  {
    Type type = instrument.GetType();
    Type genericTypeDefinition = type.IsGenericType ? type.GetGenericTypeDefinition() : (Type) null;
    if (genericTypeDefinition == typeof (Counter<>))
      return (Func<Aggregator>) (() =>
      {
        lock (this)
          return this.CheckTimeSeriesAllowed() ? (Aggregator) new RateSumAggregator() : (Aggregator) null;
      });
    if (genericTypeDefinition == typeof (ObservableCounter<>))
      return (Func<Aggregator>) (() =>
      {
        lock (this)
          return this.CheckTimeSeriesAllowed() ? (Aggregator) new RateAggregator() : (Aggregator) null;
      });
    if (genericTypeDefinition == typeof (ObservableGauge<>))
      return (Func<Aggregator>) (() =>
      {
        lock (this)
          return this.CheckTimeSeriesAllowed() ? (Aggregator) new LastValue() : (Aggregator) null;
      });
    return genericTypeDefinition == typeof (Histogram<>) ? (Func<Aggregator>) (() =>
    {
      lock (this)
        return !this.CheckTimeSeriesAllowed() || !this.CheckHistogramAllowed() ? (Aggregator) null : (Aggregator) new ExponentialHistogramAggregator(AggregationManager.s_defaultHistogramConfig);
    }) : (Func<Aggregator>) null;
  }

  private bool CheckTimeSeriesAllowed()
  {
    if (this._currentTimeSeries < this._maxTimeSeries)
    {
      ++this._currentTimeSeries;
      return true;
    }
    if (this._currentTimeSeries != this._maxTimeSeries)
      return false;
    ++this._currentTimeSeries;
    this._timeSeriesLimitReached();
    return false;
  }

  private bool CheckHistogramAllowed()
  {
    if (this._currentHistograms < this._maxHistograms)
    {
      ++this._currentHistograms;
      return true;
    }
    if (this._currentHistograms != this._maxHistograms)
      return false;
    ++this._currentHistograms;
    this._histogramLimitReached();
    return false;
  }

  internal void Collect()
  {
    try
    {
      this._listener.RecordObservableInstruments();
    }
    catch (Exception ex)
    {
      this._observableInstrumentCallbackError(ex);
    }
    foreach (KeyValuePair<Instrument, InstrumentState> instrumentState in this._instrumentStates)
    {
      KeyValuePair<Instrument, InstrumentState> kv = instrumentState;
      kv.Value.Collect(kv.Key, (Action<LabeledAggregationStatistics>) (labeledAggStats => this._collectMeasurement(kv.Key, labeledAggStats)));
    }
  }
}
