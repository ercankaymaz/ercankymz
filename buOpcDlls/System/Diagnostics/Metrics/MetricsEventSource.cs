// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.MetricsEventSource
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Globalization;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;

#nullable disable
namespace System.Diagnostics.Metrics;

[EventSource(Name = "System.Diagnostics.Metrics")]
internal sealed class MetricsEventSource : EventSource
{
  public static readonly MetricsEventSource Log = new MetricsEventSource();
  private MetricsEventSource.CommandHandler _handler;

  private MetricsEventSource.CommandHandler Handler
  {
    get
    {
      if (this._handler == null)
        Interlocked.CompareExchange<MetricsEventSource.CommandHandler>(ref this._handler, new MetricsEventSource.CommandHandler(this), (MetricsEventSource.CommandHandler) null);
      return this._handler;
    }
  }

  private MetricsEventSource()
  {
  }

  [Event(1, Keywords = (EventKeywords) 1)]
  public void Message(string Message) => this.WriteEvent(1, Message);

  [Event(2, Keywords = (EventKeywords) 2)]
  [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This calls WriteEvent with all primitive arguments which is safe. Primitives are always serialized properly.")]
  public void CollectionStart(
    string sessionId,
    DateTime intervalStartTime,
    DateTime intervalEndTime)
  {
    this.WriteEvent(2, (object) sessionId, (object) intervalStartTime, (object) intervalEndTime);
  }

  [Event(3, Keywords = (EventKeywords) 2)]
  [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This calls WriteEvent with all primitive arguments which is safe. Primitives are always serialized properly.")]
  public void CollectionStop(
    string sessionId,
    DateTime intervalStartTime,
    DateTime intervalEndTime)
  {
    this.WriteEvent(3, (object) sessionId, (object) intervalStartTime, (object) intervalEndTime);
  }

  [Event(4, Keywords = (EventKeywords) 2)]
  [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This calls WriteEvent with all primitive arguments which is safe. Primitives are always serialized properly.")]
  public void CounterRateValuePublished(
    string sessionId,
    string meterName,
    string meterVersion,
    string instrumentName,
    string unit,
    string tags,
    string rate)
  {
    this.WriteEvent(4, (object) sessionId, (object) meterName, (object) (meterVersion ?? ""), (object) instrumentName, (object) (unit ?? ""), (object) tags, (object) rate);
  }

  [Event(5, Keywords = (EventKeywords) 2)]
  [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This calls WriteEvent with all primitive arguments which is safe. Primitives are always serialized properly.")]
  public void GaugeValuePublished(
    string sessionId,
    string meterName,
    string meterVersion,
    string instrumentName,
    string unit,
    string tags,
    string lastValue)
  {
    this.WriteEvent(5, (object) sessionId, (object) meterName, (object) (meterVersion ?? ""), (object) instrumentName, (object) (unit ?? ""), (object) tags, (object) lastValue);
  }

  [Event(6, Keywords = (EventKeywords) 2)]
  [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This calls WriteEvent with all primitive arguments which is safe. Primitives are always serialized properly.")]
  public void HistogramValuePublished(
    string sessionId,
    string meterName,
    string meterVersion,
    string instrumentName,
    string unit,
    string tags,
    string quantiles)
  {
    this.WriteEvent(6, (object) sessionId, (object) meterName, (object) (meterVersion ?? ""), (object) instrumentName, (object) (unit ?? ""), (object) tags, (object) quantiles);
  }

  [Event(7, Keywords = (EventKeywords) 2)]
  [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This calls WriteEvent with all primitive arguments which is safe. Primitives are always serialized properly.")]
  public void BeginInstrumentReporting(
    string sessionId,
    string meterName,
    string meterVersion,
    string instrumentName,
    string instrumentType,
    string unit,
    string description)
  {
    this.WriteEvent(7, (object) sessionId, (object) meterName, (object) (meterVersion ?? ""), (object) instrumentName, (object) instrumentType, (object) (unit ?? ""), (object) (description ?? ""));
  }

  [Event(8, Keywords = (EventKeywords) 2)]
  [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This calls WriteEvent with all primitive arguments which is safe. Primitives are always serialized properly.")]
  public void EndInstrumentReporting(
    string sessionId,
    string meterName,
    string meterVersion,
    string instrumentName,
    string instrumentType,
    string unit,
    string description)
  {
    this.WriteEvent(8, (object) sessionId, (object) meterName, (object) (meterVersion ?? ""), (object) instrumentName, (object) instrumentType, (object) (unit ?? ""), (object) (description ?? ""));
  }

  [Event(9, Keywords = (EventKeywords) 7)]
  public void Error(string sessionId, string errorMessage)
  {
    this.WriteEvent(9, sessionId, errorMessage);
  }

  [Event(10, Keywords = (EventKeywords) 6)]
  public void InitialInstrumentEnumerationComplete(string sessionId)
  {
    this.WriteEvent(10, sessionId);
  }

  [Event(11, Keywords = (EventKeywords) 4)]
  [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "This calls WriteEvent with all primitive arguments which is safe. Primitives are always serialized properly.")]
  public void InstrumentPublished(
    string sessionId,
    string meterName,
    string meterVersion,
    string instrumentName,
    string instrumentType,
    string unit,
    string description)
  {
    this.WriteEvent(11, (object) sessionId, (object) meterName, (object) (meterVersion ?? ""), (object) instrumentName, (object) instrumentType, (object) (unit ?? ""), (object) (description ?? ""));
  }

  [Event(12, Keywords = (EventKeywords) 2)]
  public void TimeSeriesLimitReached(string sessionId) => this.WriteEvent(12, sessionId);

  [Event(13, Keywords = (EventKeywords) 2)]
  public void HistogramLimitReached(string sessionId) => this.WriteEvent(13, sessionId);

  [Event(14, Keywords = (EventKeywords) 2)]
  public void ObservableInstrumentCallbackError(string sessionId, string errorMessage)
  {
    this.WriteEvent(14, sessionId, errorMessage);
  }

  [Event(15, Keywords = (EventKeywords) 7)]
  public void MultipleSessionsNotSupportedError(string runningSessionId)
  {
    this.WriteEvent(15, runningSessionId);
  }

  [NonEvent]
  protected override void OnEventCommand(EventCommandEventArgs command)
  {
    lock (this)
      this.Handler.OnEventCommand(command);
  }

  public static class Keywords
  {
    public const EventKeywords Messages = (EventKeywords) 1;
    public const EventKeywords TimeSeriesValues = (EventKeywords) 2;
    public const EventKeywords InstrumentPublishing = (EventKeywords) 4;
  }

  private sealed class CommandHandler
  {
    private AggregationManager _aggregationManager;
    private string _sessionId = "";
    private static readonly char[] s_instrumentSeperators = new char[4]
    {
      '\r',
      '\n',
      ',',
      ';'
    };

    public CommandHandler(MetricsEventSource parent) => this.Parent = parent;

    public MetricsEventSource Parent { get; private set; }

    public void OnEventCommand(EventCommandEventArgs command)
    {
      try
      {
        if (command.Command == EventCommand.Update || command.Command == EventCommand.Disable || command.Command == EventCommand.Enable)
        {
          if (this._aggregationManager != null)
          {
            if (command.Command != EventCommand.Enable && command.Command != EventCommand.Update)
            {
              this._aggregationManager.Dispose();
              this._aggregationManager = (AggregationManager) null;
              this.Parent.Message($"Previous session with id {this._sessionId} is stopped");
            }
            else
            {
              this.Parent.MultipleSessionsNotSupportedError(this._sessionId);
              return;
            }
          }
          this._sessionId = "";
        }
        if (command.Command != EventCommand.Update && command.Command != EventCommand.Enable || command.Arguments == null)
          return;
        string str;
        if (command.Arguments.TryGetValue("SessionId", out str))
        {
          this._sessionId = str;
          this.Parent.Message("SessionId argument received: " + this._sessionId);
        }
        else
        {
          this._sessionId = Guid.NewGuid().ToString();
          this.Parent.Message("New session started. SessionId auto-generated: " + this._sessionId);
        }
        double num1 = 1.0;
        double result1 = num1;
        string s1;
        if (command.Arguments.TryGetValue("RefreshInterval", out s1))
        {
          this.Parent.Message("RefreshInterval argument received: " + s1);
          if (!double.TryParse(s1, out result1))
          {
            this.Parent.Message($"Failed to parse RefreshInterval. Using default {num1}s.");
            result1 = num1;
          }
          else if (result1 < 0.1)
          {
            this.Parent.Message($"RefreshInterval too small. Using minimum interval {0.1} seconds.");
            result1 = 0.1;
          }
        }
        else
        {
          this.Parent.Message($"No RefreshInterval argument received. Using default {num1}s.");
          result1 = num1;
        }
        int num2 = 1000;
        string s2;
        int result2;
        if (command.Arguments.TryGetValue("MaxTimeSeries", out s2))
        {
          this.Parent.Message("MaxTimeSeries argument received: " + s2);
          if (!int.TryParse(s2, out result2))
          {
            this.Parent.Message($"Failed to parse MaxTimeSeries. Using default {num2}");
            result2 = num2;
          }
        }
        else
        {
          this.Parent.Message($"No MaxTimeSeries argument received. Using default {num2}");
          result2 = num2;
        }
        int num3 = 20;
        string s3;
        int result3;
        if (command.Arguments.TryGetValue("MaxHistograms", out s3))
        {
          this.Parent.Message("MaxHistograms argument received: " + s3);
          if (!int.TryParse(s3, out result3))
          {
            this.Parent.Message($"Failed to parse MaxHistograms. Using default {num3}");
            result3 = num3;
          }
        }
        else
        {
          this.Parent.Message($"No MaxHistogram argument received. Using default {num3}");
          result3 = num3;
        }
        string sessionId = this._sessionId;
        this._aggregationManager = new AggregationManager(result2, result3, (Action<Instrument, LabeledAggregationStatistics>) ((i, s) => this.TransmitMetricValue(i, s, sessionId)), (Action<DateTime, DateTime>) ((startIntervalTime, endIntervalTime) => this.Parent.CollectionStart(sessionId, startIntervalTime, endIntervalTime)), (Action<DateTime, DateTime>) ((startIntervalTime, endIntervalTime) => this.Parent.CollectionStop(sessionId, startIntervalTime, endIntervalTime)), (Action<Instrument>) (i => this.Parent.BeginInstrumentReporting(sessionId, i.Meter.Name, i.Meter.Version, i.Name, i.GetType().Name, i.Unit, i.Description)), (Action<Instrument>) (i => this.Parent.EndInstrumentReporting(sessionId, i.Meter.Name, i.Meter.Version, i.Name, i.GetType().Name, i.Unit, i.Description)), (Action<Instrument>) (i => this.Parent.InstrumentPublished(sessionId, i.Meter.Name, i.Meter.Version, i.Name, i.GetType().Name, i.Unit, i.Description)), (Action) (() => this.Parent.InitialInstrumentEnumerationComplete(sessionId)), (Action<Exception>) (e => this.Parent.Error(sessionId, e.ToString())), (Action) (() => this.Parent.TimeSeriesLimitReached(sessionId)), (Action) (() => this.Parent.HistogramLimitReached(sessionId)), (Action<Exception>) (e => this.Parent.ObservableInstrumentCallbackError(sessionId, e.ToString())));
        this._aggregationManager.SetCollectionPeriod(TimeSpan.FromSeconds(result1));
        string metricsSpecs;
        if (command.Arguments.TryGetValue("Metrics", out metricsSpecs))
        {
          this.Parent.Message("Metrics argument received: " + metricsSpecs);
          this.ParseSpecs(metricsSpecs);
        }
        else
          this.Parent.Message("No Metrics argument received");
        this._aggregationManager.Start();
      }
      catch (Exception ex) when (this.LogError(ex))
      {
      }
    }

    private bool LogError(Exception e)
    {
      this.Parent.Error(this._sessionId, e.ToString());
      return false;
    }

    [UnsupportedOSPlatform("browser")]
    private void ParseSpecs(string metricsSpecs)
    {
      if (metricsSpecs == null)
        return;
      foreach (string text in metricsSpecs.Split(MetricsEventSource.CommandHandler.s_instrumentSeperators, StringSplitOptions.RemoveEmptyEntries))
      {
        MetricsEventSource.MetricSpec spec;
        if (!MetricsEventSource.MetricSpec.TryParse(text, out spec))
        {
          this.Parent.Message("Failed to parse metric spec: " + text);
        }
        else
        {
          this.Parent.Message($"Parsed metric: {spec}");
          if (spec.InstrumentName != null)
            this._aggregationManager.Include(spec.MeterName, spec.InstrumentName);
          else
            this._aggregationManager.Include(spec.MeterName);
        }
      }
    }

    private void TransmitMetricValue(
      Instrument instrument,
      LabeledAggregationStatistics stats,
      string sessionId)
    {
      if (stats.AggregationStatistics is RateStatistics aggregationStatistics2)
        MetricsEventSource.Log.CounterRateValuePublished(sessionId, instrument.Meter.Name, instrument.Meter.Version, instrument.Name, instrument.Unit, this.FormatTags(stats.Labels), aggregationStatistics2.Delta.HasValue ? aggregationStatistics2.Delta.Value.ToString((IFormatProvider) CultureInfo.InvariantCulture) : "");
      else if (stats.AggregationStatistics is LastValueStatistics aggregationStatistics1)
      {
        MetricsEventSource.Log.GaugeValuePublished(sessionId, instrument.Meter.Name, instrument.Meter.Version, instrument.Name, instrument.Unit, this.FormatTags(stats.Labels), aggregationStatistics1.LastValue.HasValue ? aggregationStatistics1.LastValue.Value.ToString((IFormatProvider) CultureInfo.InvariantCulture) : "");
      }
      else
      {
        if (!(stats.AggregationStatistics is HistogramStatistics aggregationStatistics))
          return;
        MetricsEventSource.Log.HistogramValuePublished(sessionId, instrument.Meter.Name, instrument.Meter.Version, instrument.Name, instrument.Unit, this.FormatTags(stats.Labels), this.FormatQuantiles(aggregationStatistics.Quantiles));
      }
    }

    private string FormatTags(KeyValuePair<string, string>[] labels)
    {
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < labels.Length; ++index)
      {
        stringBuilder.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, "{0}={1}", (object) labels[index].Key, (object) labels[index].Value);
        if (index != labels.Length - 1)
          stringBuilder.Append(',');
      }
      return stringBuilder.ToString();
    }

    private string FormatQuantiles(QuantileValue[] quantiles)
    {
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < quantiles.Length; ++index)
      {
        stringBuilder.AppendFormat((IFormatProvider) CultureInfo.InvariantCulture, "{0}={1}", (object) quantiles[index].Quantile, (object) quantiles[index].Value);
        if (index != quantiles.Length - 1)
          stringBuilder.Append(';');
      }
      return stringBuilder.ToString();
    }
  }

  private class MetricSpec
  {
    private const char MeterInstrumentSeparator = '\\';

    public string MeterName { get; private set; }

    public string InstrumentName { get; private set; }

    public MetricSpec(string meterName, string instrumentName)
    {
      this.MeterName = meterName;
      this.InstrumentName = instrumentName;
    }

    public static bool TryParse(string text, out MetricsEventSource.MetricSpec spec)
    {
      int length = text.IndexOf('\\');
      if (length == -1)
      {
        spec = new MetricsEventSource.MetricSpec(text.Trim(), (string) null);
        return true;
      }
      string meterName = text.Substring(0, length).Trim();
      string instrumentName = text.Substring(length + 1).Trim();
      spec = new MetricsEventSource.MetricSpec(meterName, instrumentName);
      return true;
    }

    public override string ToString()
    {
      return this.InstrumentName == null ? this.MeterName : $"{this.MeterName}\\{this.InstrumentName}";
    }
  }
}
