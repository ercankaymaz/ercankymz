// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.Metrics.Instrument
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource;
using System.Runtime.InteropServices;
using System.Security;

#nullable disable
namespace System.Diagnostics.Metrics;

[NullableContext(1)]
[Nullable(0)]
[SecuritySafeCritical]
[ComVisible(true)]
public abstract class Instrument
{
  internal readonly DiagLinkedList<ListenerSubscription> _subscriptions = new DiagLinkedList<ListenerSubscription>();

  [Nullable(new byte[] {1, 0, 1, 2})]
  internal static KeyValuePair<string, object>[] EmptyTags
  {
    get => Array.Empty<KeyValuePair<string, object>>();
  }

  internal static object SyncObject { get; } = new object();

  protected Instrument(Meter meter, string name, [Nullable(2)] string unit, [Nullable(2)] string description)
  {
    if (meter == null)
      throw new ArgumentNullException(nameof (meter));
    if (name == null)
      throw new ArgumentNullException(nameof (name));
    this.Meter = meter;
    this.Name = name;
    this.Description = description;
    this.Unit = unit;
  }

  protected void Publish()
  {
    List<MeterListener> meterListenerList = (List<MeterListener>) null;
    lock (Instrument.SyncObject)
    {
      if (this.Meter.Disposed || !this.Meter.AddInstrument(this))
        return;
      meterListenerList = MeterListener.GetAllListeners();
    }
    if (meterListenerList == null)
      return;
    foreach (MeterListener meterListener in meterListenerList)
    {
      Action<Instrument, MeterListener> instrumentPublished = meterListener.InstrumentPublished;
      if (instrumentPublished != null)
        instrumentPublished(this, meterListener);
    }
  }

  public Meter Meter { get; }

  public string Name { get; }

  [Nullable(2)]
  public string Description { [NullableContext(2)] get; }

  [Nullable(2)]
  public string Unit { [NullableContext(2)] get; }

  public bool Enabled => this._subscriptions.First != null;

  public virtual bool IsObservable => false;

  internal void NotifyForUnpublishedInstrument()
  {
    for (DiagNode<ListenerSubscription> diagNode = this._subscriptions.First; diagNode != null; diagNode = diagNode.Next)
      diagNode.Value.Listener.DisableMeasurementEvents(this);
    this._subscriptions.Clear();
  }

  internal static void ValidateTypeParameter<T>()
  {
    Type p1 = typeof (T);
    if (p1 != typeof (byte) && p1 != typeof (short) && p1 != typeof (int) && p1 != typeof (long) && p1 != typeof (double) && p1 != typeof (float) && p1 != typeof (Decimal))
      throw new InvalidOperationException(System.System.Diagnostics.DiagnosticSource3462135.SR.Format(System.System.Diagnostics.DiagnosticSource3462135.SR.UnsupportedType, (object) p1));
  }

  internal object EnableMeasurement(ListenerSubscription subscription, out bool oldStateStored)
  {
    oldStateStored = false;
    if (this._subscriptions.AddIfNotExist(subscription, (Func<ListenerSubscription, ListenerSubscription, bool>) ((s1, s2) => s1.Listener == s2.Listener)))
      return (object) false;
    ListenerSubscription listenerSubscription = this._subscriptions.Remove(subscription, (Func<ListenerSubscription, ListenerSubscription, bool>) ((s1, s2) => s1.Listener == s2.Listener));
    this._subscriptions.AddIfNotExist(subscription, (Func<ListenerSubscription, ListenerSubscription, bool>) ((s1, s2) => s1.Listener == s2.Listener));
    oldStateStored = listenerSubscription.Listener == subscription.Listener;
    return listenerSubscription.State;
  }

  internal object DisableMeasurements(MeterListener listener)
  {
    return this._subscriptions.Remove(new ListenerSubscription(listener), (Func<ListenerSubscription, ListenerSubscription, bool>) ((s1, s2) => s1.Listener == s2.Listener)).State;
  }

  internal virtual void Observe(MeterListener listener) => throw new InvalidOperationException();

  internal object GetSubscriptionState(MeterListener listener)
  {
    for (DiagNode<ListenerSubscription> diagNode = this._subscriptions.First; diagNode != null; diagNode = diagNode.Next)
    {
      if (listener == diagNode.Value.Listener)
        return diagNode.Value.State;
    }
    return (object) null;
  }
}
