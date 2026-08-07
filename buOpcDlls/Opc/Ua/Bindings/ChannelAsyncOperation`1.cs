// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.ChannelAsyncOperation`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class ChannelAsyncOperation<T> : IAsyncResult, IDisposable
{
  private readonly object m_lock = new object();
  private AsyncCallback m_callback;
  private object m_asyncState;
  private bool m_synchronous;
  private bool m_completed;
  private ManualResetEvent m_event;
  private TaskCompletionSource<bool> m_tcs;
  private T m_response;
  private ServiceResult m_error;
  private Timer m_timer;
  private Dictionary<string, object> m_properties;

  public ChannelAsyncOperation(int timeout, AsyncCallback callback, object asyncState)
  {
    this.m_callback = callback;
    this.m_asyncState = asyncState;
    this.m_synchronous = false;
    this.m_completed = false;
    if (timeout <= 0 || timeout == int.MaxValue)
      return;
    this.m_timer = new Timer(new TimerCallback(this.OnTimeout), (object) null, timeout, -1);
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!disposing)
      return;
    lock (this.m_lock)
    {
      Utils.SilentDispose((IDisposable) this.m_timer);
      this.m_timer = (Timer) null;
      if (this.m_event != null)
      {
        this.m_event.Set();
        this.m_event.Dispose();
        this.m_event = (ManualResetEvent) null;
      }
      if (this.m_tcs == null)
        return;
      if (!this.m_tcs.Task.IsCompleted)
        this.m_tcs.TrySetCanceled();
      this.m_tcs = (TaskCompletionSource<bool>) null;
    }
  }

  public bool Complete(T response) => this.InternalComplete(true, (object) response);

  public bool Complete(bool doNotBlock, T response)
  {
    return this.InternalComplete(doNotBlock, (object) response);
  }

  public bool Fault(ServiceResult error) => this.InternalComplete(true, (object) error);

  public bool Fault(bool doNotBlock, ServiceResult error)
  {
    return this.InternalComplete(doNotBlock, (object) error);
  }

  public bool Fault(uint code, string format, params object[] args)
  {
    return this.InternalComplete(true, (object) ServiceResult.Create(code, format, args));
  }

  public bool Fault(bool doNotBlock, uint code, string format, params object[] args)
  {
    return this.InternalComplete(doNotBlock, (object) ServiceResult.Create(code, format, args));
  }

  public bool Fault(Exception e, uint defaultCode, string format, params object[] args)
  {
    return this.InternalComplete(true, (object) ServiceResult.Create(e, defaultCode, format, args));
  }

  public bool Fault(
    bool doNotBlock,
    Exception e,
    uint defaultCode,
    string format,
    params object[] args)
  {
    return this.InternalComplete(doNotBlock, (object) ServiceResult.Create(e, defaultCode, format, args));
  }

  public T End(int timeout, bool throwOnError = true)
  {
    bool flag = false;
    lock (this.m_lock)
    {
      if (flag = !this.m_completed)
        this.m_event = new ManualResetEvent(false);
    }
    if (flag)
    {
      try
      {
        if (!this.m_event.WaitOne(timeout) & throwOnError)
          throw new ServiceResultException(2156134400U /*0x80840000*/);
      }
      finally
      {
        lock (this.m_lock)
        {
          if (this.m_event != null)
          {
            this.m_event.Dispose();
            this.m_event = (ManualResetEvent) null;
          }
        }
      }
    }
    lock (this.m_lock)
    {
      if (this.m_error != null & throwOnError)
        throw new ServiceResultException(this.m_error);
      return this.m_response;
    }
  }

  public async Task<T> EndAsync(int timeout, bool throwOnError = true, CancellationToken ct = default (CancellationToken))
  {
    bool flag = false;
    lock (this.m_lock)
    {
      if (flag = !this.m_completed)
        this.m_tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
    }
    if (flag)
    {
      bool badRequestInterrupted = false;
      try
      {
        Task<bool> task = this.m_tcs.Task;
        if (timeout != int.MaxValue || ct != new CancellationToken())
        {
          if (this.m_tcs.Task == await Task.WhenAny((Task) this.m_tcs.Task, Task.Delay(timeout, ct)).ConfigureAwait(false))
          {
            if (!this.m_tcs.Task.Result)
              badRequestInterrupted = true;
          }
          else
          {
            this.m_tcs.TrySetCanceled(ct);
            badRequestInterrupted = true;
          }
        }
        else if (!await task.ConfigureAwait(false))
          badRequestInterrupted = true;
      }
      catch (TimeoutException ex)
      {
        badRequestInterrupted = true;
      }
      catch (TaskCanceledException ex)
      {
        badRequestInterrupted = true;
      }
      finally
      {
        lock (this.m_lock)
          this.m_tcs = (TaskCompletionSource<bool>) null;
      }
      if (badRequestInterrupted & throwOnError)
        throw new ServiceResultException(2156134400U /*0x80840000*/);
    }
    T response;
    lock (this.m_lock)
    {
      if (this.m_error != null & throwOnError)
        throw new ServiceResultException(this.m_error);
      response = this.m_response;
    }
    return response;
  }

  public IDictionary<string, object> Properties
  {
    get
    {
      lock (this.m_lock)
      {
        if (this.m_properties == null)
          this.m_properties = new Dictionary<string, object>();
        return (IDictionary<string, object>) this.m_properties;
      }
    }
  }

  public object AsyncState
  {
    get
    {
      lock (this.m_lock)
        return this.m_asyncState;
    }
  }

  public WaitHandle AsyncWaitHandle
  {
    get
    {
      lock (this.m_lock)
      {
        if (this.m_event == null)
          this.m_event = new ManualResetEvent(this.m_completed);
        return (WaitHandle) this.m_event;
      }
    }
  }

  public bool CompletedSynchronously
  {
    get
    {
      lock (this.m_lock)
        return this.m_synchronous;
    }
  }

  public bool IsCompleted
  {
    get
    {
      lock (this.m_lock)
        return this.m_completed;
    }
  }

  private void OnTimeout(object state)
  {
    if (this.m_timer == null)
      return;
    this.InternalComplete(false, (object) new ServiceResult(2156199936U /*0x80850000*/));
  }

  protected virtual bool InternalComplete(bool doNotBlock, object result)
  {
    lock (this.m_lock)
    {
      if (this.m_completed)
        return false;
      if (result is T obj)
        this.m_response = obj;
      else
        this.m_error = result as ServiceResult;
      this.m_completed = true;
      if (this.m_timer != null)
      {
        this.m_timer.Dispose();
        this.m_timer = (Timer) null;
      }
      if (this.m_event != null)
        this.m_event.Set();
      if (this.m_tcs != null)
        this.m_tcs.TrySetResult(true);
    }
    if (this.m_callback != null)
    {
      if (doNotBlock)
      {
        Task.Run((Action) (() => this.m_callback((IAsyncResult) this)));
      }
      else
      {
        try
        {
          this.m_callback((IAsyncResult) this);
        }
        catch (Exception ex)
        {
          object[] objArray = Array.Empty<object>();
          Utils.LogError(ex, "ClientChannel: Unexpected error invoking AsyncCallback.", objArray);
        }
      }
    }
    return true;
  }
}
