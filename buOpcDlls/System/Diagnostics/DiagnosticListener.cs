// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.DiagnosticListener
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices.System.Diagnostics.DiagnosticSource;
using System.Runtime.InteropServices;
using System.Threading;

#nullable disable
namespace System.Diagnostics;

[NullableContext(1)]
[Nullable(0)]
[ComVisible(true)]
public class DiagnosticListener : 
  System.Diagnostics.DiagnosticSource,
  IObservable<KeyValuePair<string, object>>,
  IDisposable
{
  private volatile DiagnosticListener.DiagnosticSubscription _subscriptions;
  private DiagnosticListener _next;
  private bool _disposed;
  private static DiagnosticListener s_allListeners;
  private static volatile DiagnosticListener.AllListenerObservable s_allListenerObservable;
  private static readonly object s_allListenersLock = new object();

  public static IObservable<DiagnosticListener> AllListeners
  {
    get
    {
      GC.KeepAlive((object) HttpHandlerDiagnosticListener.s_instance);
      return (IObservable<DiagnosticListener>) DiagnosticListener.s_allListenerObservable ?? (IObservable<DiagnosticListener>) Interlocked.CompareExchange<DiagnosticListener.AllListenerObservable>(ref DiagnosticListener.s_allListenerObservable, new DiagnosticListener.AllListenerObservable(), (DiagnosticListener.AllListenerObservable) null) ?? (IObservable<DiagnosticListener>) DiagnosticListener.s_allListenerObservable;
    }
  }

  public virtual IDisposable Subscribe(
    [Nullable(new byte[] {1, 0, 1, 2})] IObserver<KeyValuePair<string, object>> observer,
    [Nullable(new byte[] {2, 1})] Predicate<string> isEnabled)
  {
    IDisposable disposable;
    if (isEnabled == null)
    {
      disposable = this.SubscribeInternal(observer, (Predicate<string>) null, (Func<string, object, object, bool>) null, (Action<Activity, object>) null, (Action<Activity, object>) null);
    }
    else
    {
      Predicate<string> localIsEnabled = isEnabled;
      disposable = this.SubscribeInternal(observer, isEnabled, (Func<string, object, object, bool>) ((name, arg1, arg2) => localIsEnabled(name)), (Action<Activity, object>) null, (Action<Activity, object>) null);
    }
    return disposable;
  }

  public virtual IDisposable Subscribe(
    [Nullable(new byte[] {1, 0, 1, 2})] IObserver<KeyValuePair<string, object>> observer,
    [Nullable(new byte[] {2, 1, 2, 2})] Func<string, object, object, bool> isEnabled)
  {
    return isEnabled != null ? this.SubscribeInternal(observer, (Predicate<string>) (name => this.IsEnabled(name, (object) null, (object) null)), isEnabled, (Action<Activity, object>) null, (Action<Activity, object>) null) : this.SubscribeInternal(observer, (Predicate<string>) null, (Func<string, object, object, bool>) null, (Action<Activity, object>) null, (Action<Activity, object>) null);
  }

  public virtual IDisposable Subscribe([Nullable(new byte[] {1, 0, 1, 2})] IObserver<KeyValuePair<string, object>> observer)
  {
    return this.SubscribeInternal(observer, (Predicate<string>) null, (Func<string, object, object, bool>) null, (Action<Activity, object>) null, (Action<Activity, object>) null);
  }

  public DiagnosticListener(string name)
  {
    this.Name = name;
    lock (DiagnosticListener.s_allListenersLock)
    {
      DiagnosticListener.s_allListenerObservable?.OnNewDiagnosticListener(this);
      this._next = DiagnosticListener.s_allListeners;
      DiagnosticListener.s_allListeners = this;
    }
    GC.KeepAlive((object) DiagnosticSourceEventSource.Log);
  }

  public virtual void Dispose()
  {
    lock (DiagnosticListener.s_allListenersLock)
    {
      if (this._disposed)
        return;
      this._disposed = true;
      if (DiagnosticListener.s_allListeners == this)
      {
        DiagnosticListener.s_allListeners = DiagnosticListener.s_allListeners._next;
      }
      else
      {
        for (DiagnosticListener diagnosticListener = DiagnosticListener.s_allListeners; diagnosticListener != null; diagnosticListener = diagnosticListener._next)
        {
          if (diagnosticListener._next == this)
          {
            diagnosticListener._next = this._next;
            break;
          }
        }
      }
      this._next = (DiagnosticListener) null;
    }
    DiagnosticListener.DiagnosticSubscription location1 = (DiagnosticListener.DiagnosticSubscription) null;
    Interlocked.Exchange<DiagnosticListener.DiagnosticSubscription>(ref location1, this._subscriptions);
    for (; location1 != null; location1 = location1.Next)
      location1.Observer.OnCompleted();
  }

  public string Name { get; private set; }

  public override string ToString() => this.Name ?? string.Empty;

  public bool IsEnabled() => this._subscriptions != null;

  public override bool IsEnabled(string name)
  {
    for (DiagnosticListener.DiagnosticSubscription diagnosticSubscription = this._subscriptions; diagnosticSubscription != null; diagnosticSubscription = diagnosticSubscription.Next)
    {
      if (diagnosticSubscription.IsEnabled1Arg == null || diagnosticSubscription.IsEnabled1Arg(name))
        return true;
    }
    return false;
  }

  [NullableContext(2)]
  public override bool IsEnabled([Nullable(1)] string name, object arg1, object arg2 = null)
  {
    for (DiagnosticListener.DiagnosticSubscription diagnosticSubscription = this._subscriptions; diagnosticSubscription != null; diagnosticSubscription = diagnosticSubscription.Next)
    {
      if (diagnosticSubscription.IsEnabled3Arg == null || diagnosticSubscription.IsEnabled3Arg(name, arg1, arg2))
        return true;
    }
    return false;
  }

  [RequiresUnreferencedCode("The type of object being written to DiagnosticSource cannot be discovered statically.")]
  public override void Write(string name, [Nullable(2)] object value)
  {
    for (DiagnosticListener.DiagnosticSubscription diagnosticSubscription = this._subscriptions; diagnosticSubscription != null; diagnosticSubscription = diagnosticSubscription.Next)
      diagnosticSubscription.Observer.OnNext(new KeyValuePair<string, object>(name, value));
  }

  private IDisposable SubscribeInternal(
    IObserver<KeyValuePair<string, object>> observer,
    Predicate<string> isEnabled1Arg,
    Func<string, object, object, bool> isEnabled3Arg,
    Action<Activity, object> onActivityImport,
    Action<Activity, object> onActivityExport)
  {
    if (this._disposed)
      return (IDisposable) new DiagnosticListener.DiagnosticSubscription()
      {
        Owner = this
      };
    DiagnosticListener.DiagnosticSubscription diagnosticSubscription = new DiagnosticListener.DiagnosticSubscription()
    {
      Observer = observer,
      IsEnabled1Arg = isEnabled1Arg,
      IsEnabled3Arg = isEnabled3Arg,
      OnActivityImport = onActivityImport,
      OnActivityExport = onActivityExport,
      Owner = this,
      Next = this._subscriptions
    };
    while (Interlocked.CompareExchange<DiagnosticListener.DiagnosticSubscription>(ref this._subscriptions, diagnosticSubscription, diagnosticSubscription.Next) != diagnosticSubscription.Next)
      diagnosticSubscription.Next = this._subscriptions;
    return (IDisposable) diagnosticSubscription;
  }

  public override void OnActivityImport(Activity activity, [Nullable(2)] object payload)
  {
    for (DiagnosticListener.DiagnosticSubscription diagnosticSubscription = this._subscriptions; diagnosticSubscription != null; diagnosticSubscription = diagnosticSubscription.Next)
    {
      Action<Activity, object> onActivityImport = diagnosticSubscription.OnActivityImport;
      if (onActivityImport != null)
        onActivityImport(activity, payload);
    }
  }

  public override void OnActivityExport(Activity activity, [Nullable(2)] object payload)
  {
    for (DiagnosticListener.DiagnosticSubscription diagnosticSubscription = this._subscriptions; diagnosticSubscription != null; diagnosticSubscription = diagnosticSubscription.Next)
    {
      Action<Activity, object> onActivityExport = diagnosticSubscription.OnActivityExport;
      if (onActivityExport != null)
        onActivityExport(activity, payload);
    }
  }

  public virtual IDisposable Subscribe(
    [Nullable(new byte[] {1, 0, 1, 2})] IObserver<KeyValuePair<string, object>> observer,
    [Nullable(new byte[] {2, 1, 2, 2})] Func<string, object, object, bool> isEnabled,
    [Nullable(new byte[] {2, 1, 2})] Action<Activity, object> onActivityImport = null,
    [Nullable(new byte[] {2, 1, 2})] Action<Activity, object> onActivityExport = null)
  {
    return isEnabled != null ? this.SubscribeInternal(observer, (Predicate<string>) (name => this.IsEnabled(name, (object) null, (object) null)), isEnabled, onActivityImport, onActivityExport) : this.SubscribeInternal(observer, (Predicate<string>) null, (Func<string, object, object, bool>) null, onActivityImport, onActivityExport);
  }

  private sealed class DiagnosticSubscription : IDisposable
  {
    internal IObserver<KeyValuePair<string, object>> Observer;
    internal Predicate<string> IsEnabled1Arg;
    internal Func<string, object, object, bool> IsEnabled3Arg;
    internal Action<Activity, object> OnActivityImport;
    internal Action<Activity, object> OnActivityExport;
    internal DiagnosticListener Owner;
    internal DiagnosticListener.DiagnosticSubscription Next;

    public void Dispose()
    {
      DiagnosticListener.DiagnosticSubscription subscriptions;
      do
      {
        subscriptions = this.Owner._subscriptions;
      }
      while (Interlocked.CompareExchange<DiagnosticListener.DiagnosticSubscription>(ref this.Owner._subscriptions, DiagnosticListener.DiagnosticSubscription.Remove(subscriptions, this), subscriptions) != subscriptions);
    }

    private static DiagnosticListener.DiagnosticSubscription Remove(
      DiagnosticListener.DiagnosticSubscription subscriptions,
      DiagnosticListener.DiagnosticSubscription subscription)
    {
      if (subscriptions == null)
        return (DiagnosticListener.DiagnosticSubscription) null;
      if (subscriptions.Observer == subscription.Observer && subscriptions.IsEnabled1Arg == subscription.IsEnabled1Arg && subscriptions.IsEnabled3Arg == subscription.IsEnabled3Arg)
        return subscriptions.Next;
      return new DiagnosticListener.DiagnosticSubscription()
      {
        Observer = subscriptions.Observer,
        Owner = subscriptions.Owner,
        IsEnabled1Arg = subscriptions.IsEnabled1Arg,
        IsEnabled3Arg = subscriptions.IsEnabled3Arg,
        Next = DiagnosticListener.DiagnosticSubscription.Remove(subscriptions.Next, subscription)
      };
    }
  }

  private sealed class AllListenerObservable : IObservable<DiagnosticListener>
  {
    private DiagnosticListener.AllListenerObservable.AllListenerSubscription _subscriptions;

    public IDisposable Subscribe(IObserver<DiagnosticListener> observer)
    {
      lock (DiagnosticListener.s_allListenersLock)
      {
        for (DiagnosticListener diagnosticListener = DiagnosticListener.s_allListeners; diagnosticListener != null; diagnosticListener = diagnosticListener._next)
          observer.OnNext(diagnosticListener);
        this._subscriptions = new DiagnosticListener.AllListenerObservable.AllListenerSubscription(this, observer, this._subscriptions);
        return (IDisposable) this._subscriptions;
      }
    }

    internal void OnNewDiagnosticListener(DiagnosticListener diagnosticListener)
    {
      for (DiagnosticListener.AllListenerObservable.AllListenerSubscription listenerSubscription = this._subscriptions; listenerSubscription != null; listenerSubscription = listenerSubscription.Next)
        listenerSubscription.Subscriber.OnNext(diagnosticListener);
    }

    private bool Remove(
      DiagnosticListener.AllListenerObservable.AllListenerSubscription subscription)
    {
      lock (DiagnosticListener.s_allListenersLock)
      {
        if (this._subscriptions == subscription)
        {
          this._subscriptions = subscription.Next;
          return true;
        }
        if (this._subscriptions != null)
        {
          for (DiagnosticListener.AllListenerObservable.AllListenerSubscription listenerSubscription = this._subscriptions; listenerSubscription.Next != null; listenerSubscription = listenerSubscription.Next)
          {
            if (listenerSubscription.Next == subscription)
            {
              listenerSubscription.Next = listenerSubscription.Next.Next;
              return true;
            }
          }
        }
        return false;
      }
    }

    internal sealed class AllListenerSubscription : IDisposable
    {
      private readonly DiagnosticListener.AllListenerObservable _owner;
      internal readonly IObserver<DiagnosticListener> Subscriber;
      internal DiagnosticListener.AllListenerObservable.AllListenerSubscription Next;

      internal AllListenerSubscription(
        DiagnosticListener.AllListenerObservable owner,
        IObserver<DiagnosticListener> subscriber,
        DiagnosticListener.AllListenerObservable.AllListenerSubscription next)
      {
        this._owner = owner;
        this.Subscriber = subscriber;
        this.Next = next;
      }

      public void Dispose()
      {
        if (!this._owner.Remove(this))
          return;
        this.Subscriber.OnCompleted();
      }
    }
  }
}
