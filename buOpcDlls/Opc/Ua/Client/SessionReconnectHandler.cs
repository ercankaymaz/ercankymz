// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.SessionReconnectHandler
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua.Client;

[ComVisible(true)]
public class SessionReconnectHandler : IDisposable
{
  public const int MinReconnectPeriod = 500;
  public const int MaxReconnectPeriod = 30000;
  public const int DefaultReconnectPeriod = 1000;
  public const int MinReconnectOperationTimeout = 5000;
  private readonly object m_lock = new object();
  private ISession m_session;
  private SessionReconnectHandler.ReconnectState m_state;
  private Random m_random;
  private bool m_reconnectFailed;
  private bool m_reconnectAbort;
  private bool m_cancelReconnect;
  private bool m_updateFromServer;
  private int m_reconnectPeriod;
  private int m_baseReconnectPeriod;
  private int m_maxReconnectPeriod;
  private Timer m_reconnectTimer;
  private EventHandler m_callback;
  private ReverseConnectManager m_reverseConnectManager;

  public SessionReconnectHandler(bool reconnectAbort = false, int maxReconnectPeriod = -1)
  {
    this.m_reconnectAbort = reconnectAbort;
    this.m_reconnectTimer = new Timer(new TimerCallback(this.OnReconnectAsync), (object) this, -1, -1);
    this.m_state = SessionReconnectHandler.ReconnectState.Ready;
    this.m_cancelReconnect = false;
    this.m_updateFromServer = false;
    this.m_baseReconnectPeriod = 1000;
    this.m_maxReconnectPeriod = maxReconnectPeriod < 0 ? -1 : Math.Max(500, Math.Min(maxReconnectPeriod, 30000));
    this.m_random = new Random();
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
      if (this.m_reconnectTimer != null)
      {
        this.m_reconnectTimer.Dispose();
        this.m_reconnectTimer = (Timer) null;
      }
      this.m_state = SessionReconnectHandler.ReconnectState.Disposed;
    }
  }

  public ISession Session => this.m_session;

  public SessionReconnectHandler.ReconnectState State
  {
    get
    {
      lock (this.m_lock)
        return this.m_reconnectTimer == null ? SessionReconnectHandler.ReconnectState.Disposed : this.m_state;
    }
  }

  public void CancelReconnect()
  {
    lock (this.m_lock)
    {
      if (this.m_reconnectTimer == null)
        return;
      if (this.m_state == SessionReconnectHandler.ReconnectState.Triggered)
      {
        this.m_session = (ISession) null;
        this.EnterReadyState();
      }
      else
        this.m_cancelReconnect = true;
    }
  }

  public SessionReconnectHandler.ReconnectState BeginReconnect(
    ISession session,
    int reconnectPeriod,
    EventHandler callback)
  {
    return this.BeginReconnect(session, (ReverseConnectManager) null, reconnectPeriod, callback);
  }

  public SessionReconnectHandler.ReconnectState BeginReconnect(
    ISession session,
    ReverseConnectManager reverseConnectManager,
    int reconnectPeriod,
    EventHandler callback)
  {
    lock (this.m_lock)
    {
      if (this.m_reconnectTimer == null)
        throw new ServiceResultException(2158952448U /*0x80AF0000*/);
      if (session == null)
      {
        if (this.m_state == SessionReconnectHandler.ReconnectState.Triggered)
        {
          this.m_session = (ISession) null;
          this.EnterReadyState();
          return this.m_state;
        }
        this.m_cancelReconnect = true;
        return this.m_state;
      }
      reconnectPeriod = this.CheckedReconnectPeriod(reconnectPeriod);
      if (this.m_state == SessionReconnectHandler.ReconnectState.Ready)
      {
        this.m_session = session;
        this.m_baseReconnectPeriod = reconnectPeriod;
        this.m_reconnectFailed = false;
        this.m_cancelReconnect = false;
        this.m_callback = callback;
        this.m_reverseConnectManager = reverseConnectManager;
        this.m_reconnectTimer.Change(this.JitteredReconnectPeriod(reconnectPeriod), -1);
        this.m_reconnectPeriod = this.CheckedReconnectPeriod(reconnectPeriod, true);
        this.m_state = SessionReconnectHandler.ReconnectState.Triggered;
        return this.m_state;
      }
      if (this.m_state == SessionReconnectHandler.ReconnectState.Triggered && reconnectPeriod < this.m_baseReconnectPeriod)
      {
        this.m_baseReconnectPeriod = reconnectPeriod;
        this.m_reconnectTimer.Change(this.JitteredReconnectPeriod(reconnectPeriod), -1);
        this.m_reconnectPeriod = this.CheckedReconnectPeriod(reconnectPeriod, true);
      }
      return this.m_state;
    }
  }

  public virtual int JitteredReconnectPeriod(int reconnectPeriod)
  {
    int num = reconnectPeriod * this.m_random.Next(-1000, 1000) / 10000;
    return reconnectPeriod + num;
  }

  public virtual int CheckedReconnectPeriod(int reconnectPeriod, bool exponentialBackoff = false)
  {
    if (this.m_maxReconnectPeriod <= 500)
      return Math.Max(reconnectPeriod, 500);
    if (exponentialBackoff)
      reconnectPeriod *= 2;
    return Math.Min(Math.Max(reconnectPeriod, 500), this.m_maxReconnectPeriod);
  }

  private async void OnReconnectAsync(object state)
  {
    SessionReconnectHandler sender = this;
    DateTime reconnectStart = DateTime.UtcNow;
    try
    {
      lock (sender.m_lock)
      {
        if (sender.m_reconnectTimer == null || sender.m_session == null || sender.m_state != SessionReconnectHandler.ReconnectState.Triggered)
          return;
        sender.m_state = SessionReconnectHandler.ReconnectState.Reconnecting;
      }
      bool flag1 = false;
      if (sender.m_session != null && sender.m_reconnectAbort && sender.m_session.Connected && !sender.m_session.KeepAliveStopped)
      {
        flag1 = true;
        sender.m_session = (ISession) null;
        Utils.LogInfo("Reconnect aborted, KeepAlive recovered.");
      }
      bool flag2;
      if (!(flag2 = flag1))
        flag2 = await sender.DoReconnectAsync().ConfigureAwait(false);
      if (flag2)
      {
        lock (sender.m_lock)
          sender.EnterReadyState();
        sender.m_callback((object) sender, (EventArgs) null);
        return;
      }
    }
    catch (Exception ex)
    {
      object[] objArray = Array.Empty<object>();
      Utils.LogError(ex, "Unexpected error during reconnect.", objArray);
    }
    lock (sender.m_lock)
    {
      if (sender.m_state == SessionReconnectHandler.ReconnectState.Disposed)
        return;
      if (sender.m_cancelReconnect)
      {
        sender.EnterReadyState();
      }
      else
      {
        int totalMilliseconds = (int) DateTime.UtcNow.Subtract(reconnectStart).TotalMilliseconds;
        Utils.LogInfo("Reconnect period is {0} ms, {1} ms elapsed in reconnect.", (object) sender.m_reconnectPeriod, (object) totalMilliseconds);
        int reconnectPeriod = sender.CheckedReconnectPeriod(sender.m_reconnectPeriod - totalMilliseconds);
        int dueTime = sender.JitteredReconnectPeriod(reconnectPeriod);
        sender.m_reconnectTimer.Change(dueTime, -1);
        Utils.LogInfo("Next adjusted reconnect scheduled in {0} ms.", (object) dueTime);
        sender.m_reconnectPeriod = sender.CheckedReconnectPeriod(sender.m_reconnectPeriod, true);
        sender.m_state = SessionReconnectHandler.ReconnectState.Triggered;
      }
    }
  }

  private async Task<bool> DoReconnectAsync()
  {
    int operationTimeout = this.m_session.OperationTimeout;
    int reconnectOperationTimeout = Math.Max(this.m_reconnectPeriod, 5000);
    if (!this.m_reconnectFailed)
    {
      try
      {
        this.m_session.OperationTimeout = reconnectOperationTimeout;
        if (this.m_reverseConnectManager != null)
          await this.m_session.ReconnectAsync(await this.m_reverseConnectManager.WaitForConnection(new Uri(this.m_session.Endpoint.EndpointUrl), this.m_session.Endpoint.Server.ApplicationUri).ConfigureAwait(false)).ConfigureAwait(false);
        else
          await this.m_session.ReconnectAsync().ConfigureAwait(false);
        return true;
      }
      catch (Exception ex)
      {
        if (ex is ServiceResultException serviceResultException)
        {
          Utils.LogWarning("Reconnect failed. Reason={0}.", (object) serviceResultException.Result);
          if (serviceResultException.StatusCode == 2156003328U /*0x80820000*/ || serviceResultException.StatusCode == 2147811328U /*0x80050000*/ || serviceResultException.StatusCode == 2156527616U /*0x808A0000*/ || serviceResultException.StatusCode == 2156199936U /*0x80850000*/ || serviceResultException.StatusCode == 2148139008U /*0x800A0000*/)
          {
            TimeSpan timeSpan = this.m_session.LastKeepAliveTime.AddMilliseconds(this.m_session.SessionTimeout) - DateTime.UtcNow;
            if (timeSpan.TotalMilliseconds > 0.0)
            {
              Utils.LogInfo("Retry to reactivate, est. session timeout in {0} ms.", (object) timeSpan.TotalMilliseconds);
              return false;
            }
          }
          if (serviceResultException.StatusCode != 2148728832U /*0x80130000*/ && serviceResultException.StatusCode != 2148663296U /*0x80120000*/)
          {
            if (serviceResultException.StatusCode != 2149908480U /*0x80250000*/)
            {
              this.m_reconnectFailed = true;
              return false;
            }
          }
          else
          {
            this.m_updateFromServer = true;
            Utils.LogInfo("Reconnect failed due to security check. Request endpoint update from server. {0}", (object) serviceResultException.Message);
          }
        }
        else
          Utils.LogError(ex, "Reconnect failed.");
        this.m_reconnectFailed = true;
      }
      finally
      {
        this.m_session.OperationTimeout = operationTimeout;
      }
    }
    try
    {
      this.m_session.OperationTimeout = reconnectOperationTimeout;
      ISession session;
      if (this.m_reverseConnectManager == null)
      {
        if (this.m_updateFromServer)
        {
          ConfiguredEndpoint configuredEndpoint = this.m_session.ConfiguredEndpoint;
          await configuredEndpoint.UpdateFromServerAsync(configuredEndpoint.EndpointUrl, configuredEndpoint.Description.SecurityMode, configuredEndpoint.Description.SecurityPolicyUri).ConfigureAwait(false);
          this.m_updateFromServer = false;
        }
        session = await this.m_session.SessionFactory.RecreateAsync(this.m_session).ConfigureAwait(false);
      }
      else
      {
        ConfiguredTaskAwaitable<ITransportWaitingConnection>.ConfiguredTaskAwaiter awaiter1;
        ConfiguredTaskAwaitable.ConfiguredTaskAwaiter awaiter2;
        ITransportWaitingConnection connection;
        do
        {
          awaiter1 = this.m_reverseConnectManager.WaitForConnection(new Uri(this.m_session.Endpoint.EndpointUrl), this.m_session.Endpoint.Server.ApplicationUri).ConfigureAwait(false).GetAwaiter();
          if (awaiter1.IsCompleted)
          {
            connection = awaiter1.GetResult();
            if (this.m_updateFromServer)
              goto label_24;
label_23:
            continue;
label_24:
            ConfiguredEndpoint configuredEndpoint = this.m_session.ConfiguredEndpoint;
            awaiter2 = configuredEndpoint.UpdateFromServerAsync(configuredEndpoint.EndpointUrl, connection, configuredEndpoint.Description.SecurityMode, configuredEndpoint.Description.SecurityPolicyUri).ConfigureAwait(false).GetAwaiter();
            if (awaiter2.IsCompleted)
            {
              awaiter2.GetResult();
              this.m_updateFromServer = false;
              connection = (ITransportWaitingConnection) null;
              goto label_23;
            }
            goto label_27;
          }
          goto label_26;
        }
        while (connection == null);
        goto label_28;
label_26:
        int num = 3;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003E1__state = 3;
        ConfiguredTaskAwaitable<ITransportWaitingConnection>.ConfiguredTaskAwaiter configuredTaskAwaiter1 = awaiter1;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<ITransportWaitingConnection>.ConfiguredTaskAwaiter, SessionReconnectHandler.\u003CDoReconnectAsync\u003Ed__18>(ref awaiter1, this);
        return;
label_27:
        num = 4;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003E1__state = 4;
        ConfiguredTaskAwaitable.ConfiguredTaskAwaiter configuredTaskAwaiter2 = awaiter2;
        // ISSUE: explicit reference operation
        // ISSUE: reference to a compiler-generated field
        (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable.ConfiguredTaskAwaiter, SessionReconnectHandler.\u003CDoReconnectAsync\u003Ed__18>(ref awaiter2, this);
        return;
label_28:
        session = await this.m_session.SessionFactory.RecreateAsync(this.m_session, connection).ConfigureAwait(false);
      }
      this.m_session = session;
      return true;
    }
    catch (ServiceResultException ex)
    {
      StatusCode? statusCode1 = ex.InnerResult?.StatusCode;
      StatusCode statusCode2 = (StatusCode) 2148728832U /*0x80130000*/;
      if ((statusCode1.HasValue ? (statusCode1.HasValue ? (statusCode1.GetValueOrDefault() == statusCode2 ? 1 : 0) : 1) : 0) == 0)
      {
        StatusCode? statusCode3 = ex.InnerResult?.StatusCode;
        StatusCode statusCode4 = (StatusCode) 2148663296U /*0x80120000*/;
        if ((statusCode3.HasValue ? (statusCode3.HasValue ? (statusCode3.GetValueOrDefault() == statusCode4 ? 1 : 0) : 1) : 0) == 0)
        {
          Utils.LogError("Could not reconnect the Session. {0}", (object) ex.Message);
          goto label_39;
        }
      }
      this.m_updateFromServer = true;
      if (this.m_maxReconnectPeriod > 500 && this.m_reconnectPeriod >= this.m_maxReconnectPeriod)
        this.m_reconnectPeriod = this.m_baseReconnectPeriod;
      Utils.LogError("Could not reconnect due to failed security check. Request endpoint update from server. {0}", (object) ex.Message);
label_39:
      return false;
    }
    catch (Exception ex)
    {
      Utils.LogError("Could not reconnect the Session. {0}", (object) ex.Message);
      return false;
    }
    finally
    {
      this.m_session.OperationTimeout = operationTimeout;
    }
  }

  private void EnterReadyState()
  {
    this.m_reconnectTimer.Change(-1, -1);
    this.m_state = SessionReconnectHandler.ReconnectState.Ready;
    this.m_cancelReconnect = false;
    this.m_updateFromServer = false;
  }

  public enum ReconnectState
  {
    Ready = 0,
    Triggered = 1,
    Reconnecting = 2,
    Disposed = 4,
  }
}
