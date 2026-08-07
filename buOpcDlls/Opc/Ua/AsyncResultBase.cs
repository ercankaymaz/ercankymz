// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AsyncResultBase
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.InteropServices;
using System.Threading;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class AsyncResultBase : IAsyncResult, IDisposable
{
  private AsyncCallback m_callback;
  private ManualResetEvent m_waitHandle;
  private DateTime m_deadline;
  private Timer m_timer;
  private CancellationTokenSource m_cts;

  public AsyncResultBase(AsyncCallback callback, object callbackData, int timeout)
    : this(callback, callbackData, timeout, (CancellationTokenSource) null)
  {
  }

  public AsyncResultBase(
    AsyncCallback callback,
    object callbackData,
    int timeout,
    CancellationTokenSource cts)
  {
    this.m_callback = callback;
    this.AsyncState = callbackData;
    this.m_deadline = DateTime.MinValue;
    this.m_cts = cts;
    if (timeout <= 0)
      return;
    this.m_deadline = DateTime.UtcNow.AddMilliseconds((double) timeout);
    if (this.m_callback == null)
      return;
    this.m_timer = new Timer(new TimerCallback(this.OnTimeout), (object) null, timeout, -1);
  }

  public void Dispose() => this.Dispose(true);

  protected virtual void Dispose(bool disposing)
  {
    if (!disposing)
      return;
    this.DisposeTimer();
    this.DisposeWaitHandle(true);
    if (this.m_cts == null)
      return;
    Utils.SilentDispose((IDisposable) this.m_cts);
    this.m_cts = (CancellationTokenSource) null;
  }

  public object Lock { get; } = new object();

  public IAsyncResult InnerResult { get; set; }

  public Exception Exception { get; set; }

  public CancellationToken CancellationToken
  {
    get => this.m_cts != null ? this.m_cts.Token : CancellationToken.None;
  }

  public static void WaitForComplete(IAsyncResult ar)
  {
    if (!(ar is AsyncResultBase asyncResultBase))
      throw new ArgumentException("IAsyncResult passed to call is not an instance of AsyncResultBase.");
    if (!asyncResultBase.WaitForComplete())
      throw new TimeoutException();
  }

  public bool WaitForComplete()
  {
    try
    {
      WaitHandle waitHandle = (WaitHandle) null;
      int millisecondsTimeout = -1;
      lock (this.Lock)
      {
        if (this.Exception != null)
          throw new ServiceResultException(this.Exception, 2147811328U /*0x80050000*/);
        if (this.m_deadline != DateTime.MinValue)
        {
          millisecondsTimeout = (int) (this.m_deadline - DateTime.UtcNow).TotalMilliseconds;
          if (millisecondsTimeout <= 0)
            return false;
        }
        if (this.IsCompleted)
          return true;
        if (this.m_waitHandle == null)
          this.m_waitHandle = new ManualResetEvent(false);
        waitHandle = (WaitHandle) this.m_waitHandle;
      }
      if (waitHandle != null)
      {
        try
        {
          if (!waitHandle.WaitOne(millisecondsTimeout))
            return false;
          lock (this.Lock)
          {
            if (this.Exception != null)
              throw new ServiceResultException(this.Exception, 2147811328U /*0x80050000*/);
          }
        }
        catch (ObjectDisposedException ex)
        {
          return false;
        }
      }
    }
    finally
    {
      this.DisposeTimer();
      this.DisposeWaitHandle(false);
    }
    return true;
  }

  public void Reset()
  {
    lock (this.Lock)
    {
      this.IsCompleted = false;
      this.m_waitHandle?.Reset();
    }
  }

  public void OperationCompleted()
  {
    lock (this.Lock)
    {
      this.IsCompleted = true;
      try
      {
        this.m_waitHandle?.Set();
      }
      catch (ObjectDisposedException ex)
      {
        object[] objArray = Array.Empty<object>();
        Utils.LogTrace((Exception) ex, "Unexpected error handling OperationCompleted for AsyncResult operation.", objArray);
      }
    }
    AsyncCallback callback = this.m_callback;
    if (callback == null)
      return;
    callback((IAsyncResult) this);
  }

  private void DisposeTimer()
  {
    lock (this.Lock)
    {
      try
      {
        this.m_timer?.Dispose();
      }
      catch (Exception ex)
      {
        object[] objArray = Array.Empty<object>();
        Utils.LogTrace(ex, "Unexpected error handling dispose of timer for AsyncResult operation.", objArray);
      }
      finally
      {
        this.m_timer = (Timer) null;
      }
    }
  }

  private void DisposeWaitHandle(bool set)
  {
    ManualResetEvent manualResetEvent = Interlocked.Exchange<ManualResetEvent>(ref this.m_waitHandle, (ManualResetEvent) null);
    if (manualResetEvent == null)
      return;
    try
    {
      if (set)
        manualResetEvent.Set();
      manualResetEvent.Dispose();
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      Utils.LogTrace(ex, "Unexpected error handling dispose of wait handle for AsyncResult operation.", objArray);
    }
  }

  private void OnTimeout(object state)
  {
    try
    {
      this.Exception = (Exception) new TimeoutException();
      this.m_cts?.Cancel();
      this.OperationCompleted();
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      Utils.LogTrace(ex, "Unexpected error handling timeout for ChannelAsyncResult operation.", objArray);
    }
  }

  public object AsyncState { get; private set; }

  public WaitHandle AsyncWaitHandle
  {
    get
    {
      lock (this.Lock)
      {
        if (this.m_waitHandle == null)
          this.m_waitHandle = new ManualResetEvent(false);
        return (WaitHandle) this.m_waitHandle;
      }
    }
  }

  public bool CompletedSynchronously => false;

  public bool IsCompleted { get; private set; }
}
