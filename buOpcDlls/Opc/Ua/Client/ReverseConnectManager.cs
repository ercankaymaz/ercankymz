// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.ReverseConnectManager
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua.Client;

[ComVisible(true)]
public class ReverseConnectManager : IDisposable
{
  public const int DefaultWaitTimeout = 20000;
  private readonly object m_lock = new object();
  private ConfigurationWatcher m_configurationWatcher;
  private ApplicationType m_applicationType;
  private Type m_configType;
  private ReverseConnectClientConfiguration m_configuration;
  private Dictionary<Uri, ReverseConnectManager.ReverseConnectInfo> m_endpointUrls;
  private ReverseConnectManager.ReverseConnectManagerState m_state;
  private List<ReverseConnectManager.Registration> m_registrations;
  private readonly object m_registrationsLock = new object();
  private CancellationTokenSource m_cts;

  public ReverseConnectManager()
  {
    this.m_state = ReverseConnectManager.ReverseConnectManagerState.New;
    this.m_registrations = new List<ReverseConnectManager.Registration>();
    this.m_endpointUrls = new Dictionary<Uri, ReverseConnectManager.ReverseConnectInfo>();
    this.m_cts = new CancellationTokenSource();
  }

  public void Dispose() => this.Dispose(true);

  public virtual void Dispose(bool disposing)
  {
    if (this.m_configurationWatcher != null)
    {
      Utils.SilentDispose((IDisposable) this.m_configurationWatcher);
      this.m_configurationWatcher = (ConfigurationWatcher) null;
    }
    if (this.m_cts != null)
    {
      Utils.SilentDispose((IDisposable) this.m_cts);
      this.m_cts = (CancellationTokenSource) null;
    }
    this.DisposeHosts();
  }

  protected virtual async void OnConfigurationChanged(
    object sender,
    ConfigurationWatcherEventArgs args)
  {
    try
    {
      this.OnUpdateConfiguration(await ApplicationConfiguration.Load(new FileInfo(args.FilePath), this.m_applicationType, this.m_configType).ConfigureAwait(false));
    }
    catch (Exception ex)
    {
      object[] objArray = new object[1]{ (object) args };
      Utils.LogError(ex, "Could not load updated configuration file from: {0}", objArray);
    }
  }

  protected virtual void OnUpdateConfiguration(ApplicationConfiguration configuration)
  {
    this.m_applicationType = configuration.ApplicationType;
    this.m_configType = configuration.GetType();
    this.OnUpdateConfiguration(configuration.ClientConfiguration.ReverseConnect);
  }

  protected virtual void OnUpdateConfiguration(ReverseConnectClientConfiguration configuration)
  {
    bool flag = false;
    lock (this.m_lock)
    {
      if (this.m_configuration != null)
      {
        this.StopService();
        this.m_configuration = (ReverseConnectClientConfiguration) null;
        flag = true;
      }
      this.m_configuration = configuration ?? new ReverseConnectClientConfiguration();
      this.ClearEndpoints(true);
      if (configuration?.ClientEndpoints != null)
      {
        foreach (ReverseConnectClientEndpoint clientEndpoint in (List<ReverseConnectClientEndpoint>) configuration.ClientEndpoints)
        {
          Uri uri = Utils.ParseUri(clientEndpoint.EndpointUrl);
          if (uri != (Uri) null)
            this.AddEndpointInternal(uri, true);
        }
      }
      if (!flag)
        return;
      this.StartService();
    }
  }

  private void OpenHosts()
  {
    lock (this.m_lock)
    {
      foreach (KeyValuePair<Uri, ReverseConnectManager.ReverseConnectInfo> endpointUrl in this.m_endpointUrls)
      {
        ReverseConnectManager.ReverseConnectInfo reverseConnectInfo = endpointUrl.Value;
        try
        {
          if (endpointUrl.Value.State < ReverseConnectManager.ReverseConnectHostState.Open)
          {
            reverseConnectInfo.ReverseConnectHost.Open();
            reverseConnectInfo.State = ReverseConnectManager.ReverseConnectHostState.Open;
          }
        }
        catch (Exception ex)
        {
          object[] objArray = new object[1]
          {
            (object) endpointUrl.Key
          };
          Utils.LogError(ex, "Failed to Open {0}.", objArray);
          reverseConnectInfo.State = ReverseConnectManager.ReverseConnectHostState.Errored;
        }
      }
    }
  }

  private void CloseHosts()
  {
    lock (this.m_lock)
    {
      foreach (KeyValuePair<Uri, ReverseConnectManager.ReverseConnectInfo> endpointUrl in this.m_endpointUrls)
      {
        ReverseConnectManager.ReverseConnectInfo reverseConnectInfo = endpointUrl.Value;
        try
        {
          if (reverseConnectInfo.State == ReverseConnectManager.ReverseConnectHostState.Open)
          {
            reverseConnectInfo.ReverseConnectHost.Close();
            reverseConnectInfo.State = ReverseConnectManager.ReverseConnectHostState.Closed;
          }
        }
        catch (Exception ex)
        {
          object[] objArray = new object[1]
          {
            (object) endpointUrl.Key
          };
          Utils.LogError(ex, "Failed to Close {0}.", objArray);
          reverseConnectInfo.State = ReverseConnectManager.ReverseConnectHostState.Errored;
        }
      }
    }
  }

  private void DisposeHosts()
  {
    lock (this.m_lock)
    {
      this.CloseHosts();
      this.m_endpointUrls = (Dictionary<Uri, ReverseConnectManager.ReverseConnectInfo>) null;
    }
  }

  public void AddEndpoint(Uri endpointUrl)
  {
    if (endpointUrl == (Uri) null)
      throw new ArgumentNullException(nameof (endpointUrl));
    lock (this.m_lock)
    {
      if (this.m_state == ReverseConnectManager.ReverseConnectManagerState.Started)
        throw new ServiceResultException(2158952448U /*0x80AF0000*/);
      this.AddEndpointInternal(endpointUrl, false);
    }
  }

  public void StartService(ApplicationConfiguration configuration)
  {
    if (configuration == null)
      throw new ArgumentNullException(nameof (configuration));
    lock (this.m_lock)
    {
      if (this.m_state == ReverseConnectManager.ReverseConnectManagerState.Started)
        throw new ServiceResultException(2158952448U /*0x80AF0000*/);
      try
      {
        this.OnUpdateConfiguration(configuration);
        this.StartService();
        if (string.IsNullOrEmpty(configuration.SourceFilePath))
          return;
        this.m_configurationWatcher = new ConfigurationWatcher(configuration);
        this.m_configurationWatcher.Changed += new EventHandler<ConfigurationWatcherEventArgs>(this.OnConfigurationChanged);
      }
      catch (Exception ex)
      {
        object[] objArray1 = Array.Empty<object>();
        Utils.LogError(ex, "Unexpected error starting reverse connect manager.", objArray1);
        this.m_state = ReverseConnectManager.ReverseConnectManagerState.Errored;
        object[] objArray2 = Array.Empty<object>();
        throw new ServiceResultException(ServiceResult.Create(ex, 2147614720U /*0x80020000*/, "Unexpected error starting application", objArray2));
      }
    }
  }

  public void StartService(ReverseConnectClientConfiguration configuration)
  {
    if (configuration == null)
      throw new ArgumentNullException(nameof (configuration));
    lock (this.m_lock)
    {
      if (this.m_state == ReverseConnectManager.ReverseConnectManagerState.Started)
        throw new ServiceResultException(2158952448U /*0x80AF0000*/);
      try
      {
        this.m_configurationWatcher = (ConfigurationWatcher) null;
        this.OnUpdateConfiguration(configuration);
        this.OpenHosts();
        this.m_state = ReverseConnectManager.ReverseConnectManagerState.Started;
      }
      catch (Exception ex)
      {
        object[] objArray1 = Array.Empty<object>();
        Utils.LogError(ex, "Unexpected error starting reverse connect manager.", objArray1);
        this.m_state = ReverseConnectManager.ReverseConnectManagerState.Errored;
        object[] objArray2 = Array.Empty<object>();
        throw new ServiceResultException(ServiceResult.Create(ex, 2147614720U /*0x80020000*/, "Unexpected error starting reverse connect manager", objArray2));
      }
    }
  }

  public void ClearWaitingConnections()
  {
    lock (this.m_registrationsLock)
    {
      this.m_registrations.Clear();
      this.CancelAndRenewTokenSource();
    }
  }

  public async Task<ITransportWaitingConnection> WaitForConnection(
    Uri endpointUrl,
    string serverUri,
    CancellationToken ct = default (CancellationToken))
  {
    TaskCompletionSource<ITransportWaitingConnection> tcs = new TaskCompletionSource<ITransportWaitingConnection>();
    int hashCode = this.RegisterWaitingConnection(endpointUrl, serverUri, (EventHandler<ConnectionWaitingEventArgs>) ((sender, e) => tcs.TrySetResult((ITransportWaitingConnection) e)), ReverseConnectManager.ReverseConnectStrategy.Once);
    Func<Task> func = (Func<Task>) (async () =>
    {
      if (!(ct == new CancellationToken()))
        await Task.Delay(-1, ct).ContinueWith((Action<Task>) (tsk => { })).ConfigureAwait(false);
      else
        await Task.Delay(this.m_configuration.WaitTimeout > 0 ? this.m_configuration.WaitTimeout : 20000).ConfigureAwait(false);
      tcs.TrySetCanceled();
    });
    Task task = await Task.WhenAny((Task) tcs.Task, func()).ConfigureAwait(false);
    if (!tcs.Task.IsCompleted || tcs.Task.IsCanceled)
    {
      this.UnregisterWaitingConnection(hashCode);
      throw new ServiceResultException(2148139008U /*0x800A0000*/, "Waiting for the reverse connection timed out.");
    }
    return await tcs.Task.ConfigureAwait(false);
  }

  public int RegisterWaitingConnection(
    Uri endpointUrl,
    string serverUri,
    EventHandler<ConnectionWaitingEventArgs> onConnectionWaiting,
    ReverseConnectManager.ReverseConnectStrategy reverseConnectStrategy)
  {
    if (endpointUrl == (Uri) null)
      throw new ArgumentNullException(nameof (endpointUrl));
    ReverseConnectManager.Registration registration = new ReverseConnectManager.Registration(serverUri, endpointUrl, onConnectionWaiting)
    {
      ReverseConnectStrategy = reverseConnectStrategy
    };
    lock (this.m_registrationsLock)
    {
      this.m_registrations.Add(registration);
      this.CancelAndRenewTokenSource();
    }
    return registration.GetHashCode();
  }

  public void UnregisterWaitingConnection(int hashCode)
  {
    lock (this.m_registrationsLock)
    {
      ReverseConnectManager.Registration registration1 = (ReverseConnectManager.Registration) null;
      foreach (ReverseConnectManager.Registration registration2 in this.m_registrations)
      {
        if (registration2.GetHashCode() == hashCode)
        {
          registration1 = registration2;
          break;
        }
      }
      if (registration1 == null)
        return;
      this.m_registrations.Remove(registration1);
      this.CancelAndRenewTokenSource();
    }
  }

  private void StopService()
  {
    this.ClearWaitingConnections();
    lock (this.m_lock)
    {
      this.CloseHosts();
      this.m_state = ReverseConnectManager.ReverseConnectManagerState.Stopped;
    }
  }

  private void StartService()
  {
    lock (this.m_lock)
    {
      this.OpenHosts();
      this.m_state = ReverseConnectManager.ReverseConnectManagerState.Started;
    }
  }

  private void ClearEndpoints(bool configEntry)
  {
    Dictionary<Uri, ReverseConnectManager.ReverseConnectInfo> dictionary = new Dictionary<Uri, ReverseConnectManager.ReverseConnectInfo>();
    foreach (KeyValuePair<Uri, ReverseConnectManager.ReverseConnectInfo> endpointUrl in this.m_endpointUrls)
    {
      if (endpointUrl.Value.ConfigEntry != configEntry)
        dictionary[endpointUrl.Key] = endpointUrl.Value;
    }
    this.m_endpointUrls = dictionary;
  }

  private void AddEndpointInternal(Uri endpointUrl, bool configEntry)
  {
    ReverseConnectHost reverseConnectHost = new ReverseConnectHost();
    ReverseConnectManager.ReverseConnectInfo reverseConnectInfo = new ReverseConnectManager.ReverseConnectInfo(reverseConnectHost, configEntry);
    try
    {
      this.m_endpointUrls[endpointUrl] = reverseConnectInfo;
      reverseConnectHost.CreateListener(endpointUrl, new ConnectionWaitingHandlerAsync(this.OnConnectionWaiting), new EventHandler<ConnectionStatusEventArgs>(this.OnConnectionStatusChanged));
    }
    catch (ArgumentException ex)
    {
      object[] objArray = new object[1]
      {
        (object) endpointUrl
      };
      Utils.LogError((Exception) ex, "No listener was found for endpoint {0}.", objArray);
      reverseConnectInfo.State = ReverseConnectManager.ReverseConnectHostState.Errored;
    }
  }

  private async Task OnConnectionWaiting(object sender, ConnectionWaitingEventArgs e)
  {
    DateTime startTime = DateTime.UtcNow;
    DateTime dateTime = startTime + TimeSpan.FromMilliseconds((double) this.m_configuration.HoldTime);
    bool matched = this.MatchRegistration(sender, e);
    if (!matched)
    {
      Utils.LogInfo("Holding reverse connection: {0} {1}", (object) e.ServerUri, (object) e.EndpointUrl);
      CancellationToken token;
      lock (this.m_registrationsLock)
        token = this.m_cts.Token;
      TimeSpan delay = dateTime - DateTime.UtcNow;
      if (delay.TotalMilliseconds > 0.0)
        await Task.Delay(delay, token).ContinueWith((Action<Task>) (tsk =>
        {
          if (!tsk.IsCanceled)
            return;
          matched = this.MatchRegistration(sender, e);
          if (!matched)
            return;
          Utils.LogInfo("Matched reverse connection {0} {1} after {2}ms", (object) e.ServerUri, (object) e.EndpointUrl, (object) (int) (DateTime.UtcNow - startTime).TotalMilliseconds);
        })).ConfigureAwait(false);
    }
    Utils.LogInfo("{0} reverse connection: {1} {2} after {3}ms", e.Accepted ? (object) "Accepted" : (object) "Rejected", (object) e.ServerUri, (object) e.EndpointUrl, (object) (int) DateTime.UtcNow.Subtract(startTime).TotalMilliseconds);
  }

  private bool MatchRegistration(object sender, ConnectionWaitingEventArgs e)
  {
    ReverseConnectManager.Registration registration1 = (ReverseConnectManager.Registration) null;
    bool flag = false;
    lock (this.m_registrationsLock)
    {
      foreach (ReverseConnectManager.Registration registration2 in this.m_registrations.Where<ReverseConnectManager.Registration>((Func<ReverseConnectManager.Registration, bool>) (r => (r.ReverseConnectStrategy & ReverseConnectManager.ReverseConnectStrategy.Any) == ReverseConnectManager.ReverseConnectStrategy.Undefined)))
      {
        if (registration2.EndpointUrl.Scheme.Equals(e.EndpointUrl.Scheme, StringComparison.InvariantCulture) && (registration2.ServerUri == e.ServerUri || registration2.EndpointUrl.Authority.Equals(e.EndpointUrl.Authority, StringComparison.InvariantCulture)))
        {
          registration1 = registration2;
          e.Accepted = true;
          flag = true;
          Utils.LogInfo("Accepted reverse connection: {0} {1}", (object) e.ServerUri, (object) e.EndpointUrl);
          break;
        }
      }
      if (registration1 == null)
      {
        foreach (ReverseConnectManager.Registration registration3 in this.m_registrations.Where<ReverseConnectManager.Registration>((Func<ReverseConnectManager.Registration, bool>) (r => (r.ReverseConnectStrategy & ReverseConnectManager.ReverseConnectStrategy.Any) != 0)))
        {
          if (registration3.EndpointUrl.Scheme.Equals(e.EndpointUrl.Scheme, StringComparison.InvariantCulture))
          {
            registration1 = registration3;
            e.Accepted = true;
            flag = true;
            Utils.LogInfo("Accept any reverse connection for approval: {0} {1}", (object) e.ServerUri, (object) e.EndpointUrl);
            break;
          }
        }
      }
      if (registration1 != null)
      {
        if ((registration1.ReverseConnectStrategy & ReverseConnectManager.ReverseConnectStrategy.Once) != ReverseConnectManager.ReverseConnectStrategy.Undefined)
          this.m_registrations.Remove(registration1);
      }
    }
    if (registration1 != null)
    {
      EventHandler<ConnectionWaitingEventArgs> connectionWaiting = registration1.OnConnectionWaiting;
      if (connectionWaiting != null)
        connectionWaiting(sender, e);
    }
    return flag;
  }

  private void OnConnectionStatusChanged(object sender, ConnectionStatusEventArgs e)
  {
    Utils.LogInfo("Channel status: {0} {1} {2}", (object) e.EndpointUrl, (object) e.ChannelStatus, (object) e.Closed);
  }

  private void CancelAndRenewTokenSource()
  {
    CancellationTokenSource cts = this.m_cts;
    this.m_cts = new CancellationTokenSource();
    cts.Cancel();
    cts.Dispose();
  }

  private enum ReverseConnectManagerState
  {
    New,
    Stopped,
    Started,
    Errored,
  }

  private enum ReverseConnectHostState
  {
    New,
    Closed,
    Open,
    Errored,
  }

  [Flags]
  public enum ReverseConnectStrategy
  {
    Undefined = 0,
    Once = 1,
    Always = 2,
    Any = 128, // 0x00000080
    AnyOnce = Any | Once, // 0x00000081
    AnyAlways = Any | Always, // 0x00000082
  }

  private class ReverseConnectInfo
  {
    public ReverseConnectHost ReverseConnectHost;
    public ReverseConnectManager.ReverseConnectHostState State;
    public bool ConfigEntry;

    public ReverseConnectInfo(ReverseConnectHost reverseConnectHost, bool configEntry)
    {
      this.ReverseConnectHost = reverseConnectHost;
      this.State = ReverseConnectManager.ReverseConnectHostState.New;
      this.ConfigEntry = configEntry;
    }
  }

  private class Registration
  {
    public readonly string ServerUri;
    public readonly Uri EndpointUrl;
    public readonly EventHandler<ConnectionWaitingEventArgs> OnConnectionWaiting;
    public ReverseConnectManager.ReverseConnectStrategy ReverseConnectStrategy;

    public Registration(
      string serverUri,
      Uri endpointUrl,
      EventHandler<ConnectionWaitingEventArgs> onConnectionWaiting)
      : this(endpointUrl, onConnectionWaiting)
    {
      this.ServerUri = Utils.ReplaceLocalhost(serverUri);
    }

    public Registration(
      X509Certificate2 serverCertificate,
      Uri endpointUrl,
      EventHandler<ConnectionWaitingEventArgs> onConnectionWaiting)
      : this(endpointUrl, onConnectionWaiting)
    {
      this.ServerUri = Opc.Ua.X509Utils.GetApplicationUriFromCertificate(serverCertificate);
    }

    private Registration(
      Uri endpointUrl,
      EventHandler<ConnectionWaitingEventArgs> onConnectionWaiting)
    {
      this.EndpointUrl = new Uri(Utils.ReplaceLocalhost(endpointUrl.ToString()));
      this.OnConnectionWaiting = onConnectionWaiting;
      this.ReverseConnectStrategy = ReverseConnectManager.ReverseConnectStrategy.Once;
    }
  }
}
