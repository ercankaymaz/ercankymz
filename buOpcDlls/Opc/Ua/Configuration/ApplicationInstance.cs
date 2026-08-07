// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Configuration.ApplicationInstance
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua.Configuration;

[ComVisible(true)]
public class ApplicationInstance
{
  private string m_applicationName;
  private ApplicationType m_applicationType;
  private string m_configSectionName;
  private Type m_configurationType;
  private ServerBase m_server;
  private ApplicationConfiguration m_applicationConfiguration;

  public ApplicationInstance() => this.DisableCertificateAutoCreation = false;

  public ApplicationInstance(ApplicationConfiguration applicationConfiguration)
    : this()
  {
    this.m_applicationConfiguration = applicationConfiguration;
  }

  public string ApplicationName
  {
    get => this.m_applicationName;
    set => this.m_applicationName = value;
  }

  public ApplicationType ApplicationType
  {
    get => this.m_applicationType;
    set => this.m_applicationType = value;
  }

  public string ConfigSectionName
  {
    get => this.m_configSectionName;
    set => this.m_configSectionName = value;
  }

  public Type ConfigurationType
  {
    get => this.m_configurationType;
    set => this.m_configurationType = value;
  }

  public ServerBase Server => this.m_server;

  public ApplicationConfiguration ApplicationConfiguration
  {
    get => this.m_applicationConfiguration;
    set => this.m_applicationConfiguration = value;
  }

  public static IApplicationMessageDlg MessageDlg { get; set; }

  public ICertificatePasswordProvider CertificatePasswordProvider { get; set; }

  public bool DisableCertificateAutoCreation { get; set; }

  public bool ProcessCommandLine() => false;

  public void StartAsService(ServerBase server)
  {
    throw new NotImplementedException(".NetStandard Opc.Ua libraries do not support to start as a windows service");
  }

  public async Task Start(ServerBase server)
  {
    this.m_server = server;
    if (this.m_applicationConfiguration == null)
    {
      ApplicationConfiguration applicationConfiguration = await this.LoadApplicationConfiguration(false).ConfigureAwait(false);
    }
    server.Start(this.m_applicationConfiguration);
  }

  public void Stop() => this.m_server.Stop();

  public async Task<ApplicationConfiguration> LoadAppConfig(
    bool silent,
    string filePath,
    ApplicationType applicationType,
    Type configurationType,
    bool applyTraceSettings,
    ICertificatePasswordProvider certificatePasswordProvider = null)
  {
    Utils.LogInfo("Loading application configuration file. {0}", (object) filePath);
    object obj;
    int num1;
    try
    {
      return await ApplicationConfiguration.Load(new FileInfo(filePath), applicationType, configurationType, applyTraceSettings, certificatePasswordProvider).ConfigureAwait(false) ?? (ApplicationConfiguration) null;
    }
    catch (Exception ex)
    {
      obj = (object) ex;
      num1 = 1;
    }
    if (num1 == 1)
    {
      Exception exception = (Exception) obj;
      Utils.LogError(exception, "Could not load configuration file. {0}", (object) filePath);
      if (!silent)
      {
        if (ApplicationInstance.MessageDlg != null)
        {
          ApplicationInstance.MessageDlg.Message("Load Application Configuration: " + exception.Message);
          int num2 = await ApplicationInstance.MessageDlg.ShowAsync().ConfigureAwait(false) ? 1 : 0;
        }
        if (!(obj is Exception source))
          throw obj;
        ExceptionDispatchInfo.Capture(source).Throw();
      }
      return (ApplicationConfiguration) null;
    }
    obj = (object) null;
    ApplicationConfiguration applicationConfiguration;
    return applicationConfiguration;
  }

  public async Task<ApplicationConfiguration> LoadAppConfig(
    bool silent,
    Stream stream,
    ApplicationType applicationType,
    Type configurationType,
    bool applyTraceSettings,
    ICertificatePasswordProvider certificatePasswordProvider = null)
  {
    Utils.LogInfo("Loading application from stream.");
    object obj;
    int num1;
    try
    {
      return await ApplicationConfiguration.Load(stream, applicationType, configurationType, applyTraceSettings, certificatePasswordProvider).ConfigureAwait(false) ?? (ApplicationConfiguration) null;
    }
    catch (Exception ex)
    {
      obj = (object) ex;
      num1 = 1;
    }
    if (num1 == 1)
    {
      Exception exception = (Exception) obj;
      Utils.LogError(exception, "Could not load configuration from stream.");
      if (!silent)
      {
        if (ApplicationInstance.MessageDlg != null)
        {
          ApplicationInstance.MessageDlg.Message("Load Application Configuration: " + exception.Message);
          int num2 = await ApplicationInstance.MessageDlg.ShowAsync().ConfigureAwait(false) ? 1 : 0;
        }
        if (!(obj is Exception source))
          throw obj;
        ExceptionDispatchInfo.Capture(source).Throw();
      }
      return (ApplicationConfiguration) null;
    }
    obj = (object) null;
    ApplicationConfiguration applicationConfiguration;
    return applicationConfiguration;
  }

  public async Task<ApplicationConfiguration> LoadApplicationConfiguration(
    Stream stream,
    bool silent)
  {
    ApplicationConfiguration configuration = (ApplicationConfiguration) null;
    try
    {
      configuration = await this.LoadAppConfig(silent, stream, this.ApplicationType, this.ConfigurationType, true, this.CertificatePasswordProvider).ConfigureAwait(false);
    }
    catch (Exception ex) when (silent)
    {
    }
    this.m_applicationConfiguration = configuration != null ? ApplicationInstance.FixupAppConfig(configuration) : throw ServiceResultException.Create(2156462080U /*0x80890000*/, "Could not load configuration.");
    ApplicationConfiguration applicationConfiguration = configuration;
    configuration = (ApplicationConfiguration) null;
    return applicationConfiguration;
  }

  public async Task<ApplicationConfiguration> LoadApplicationConfiguration(
    string filePath,
    bool silent)
  {
    ApplicationConfiguration configuration = (ApplicationConfiguration) null;
    try
    {
      configuration = await this.LoadAppConfig(silent, filePath, this.ApplicationType, this.ConfigurationType, true, this.CertificatePasswordProvider).ConfigureAwait(false);
    }
    catch (Exception ex) when (silent)
    {
    }
    this.m_applicationConfiguration = configuration != null ? ApplicationInstance.FixupAppConfig(configuration) : throw ServiceResultException.Create(2156462080U /*0x80890000*/, "Could not load configuration file.");
    ApplicationConfiguration applicationConfiguration = configuration;
    configuration = (ApplicationConfiguration) null;
    return applicationConfiguration;
  }

  public async Task<ApplicationConfiguration> LoadApplicationConfiguration(bool silent)
  {
    return await this.LoadApplicationConfiguration(ApplicationConfiguration.GetFilePathFromAppConfig(this.ConfigSectionName), silent).ConfigureAwait(false);
  }

  public static ApplicationConfiguration FixupAppConfig(ApplicationConfiguration configuration)
  {
    configuration.ApplicationUri = Utils.ReplaceLocalhost(configuration.ApplicationUri);
    if (configuration.ServerConfiguration != null)
    {
      for (int index = 0; index < configuration.ServerConfiguration.BaseAddresses.Count; ++index)
        configuration.ServerConfiguration.BaseAddresses[index] = Utils.ReplaceLocalhost(configuration.ServerConfiguration.BaseAddresses[index]);
    }
    return configuration;
  }

  public IApplicationConfigurationBuilderTypes Build(string applicationUri, string productUri)
  {
    this.ApplicationConfiguration = new ApplicationConfiguration()
    {
      ApplicationName = this.ApplicationName,
      ApplicationType = this.ApplicationType,
      ApplicationUri = applicationUri,
      ProductUri = productUri,
      TraceConfiguration = new TraceConfiguration()
      {
        TraceMasks = 0
      },
      TransportQuotas = new TransportQuotas()
    };
    this.ApplicationConfiguration.TraceConfiguration.ApplySettings();
    return (IApplicationConfigurationBuilderTypes) new ApplicationConfigurationBuilder(this);
  }

  public Task<bool> CheckApplicationInstanceCertificate(bool silent, ushort minimumKeySize)
  {
    return this.CheckApplicationInstanceCertificate(silent, minimumKeySize, CertificateFactory.DefaultLifeTime);
  }

  public async Task DeleteApplicationInstanceCertificate(CancellationToken ct = default (CancellationToken))
  {
    if (this.m_applicationConfiguration == null)
      throw new ArgumentException("Missing configuration.");
    await ApplicationInstance.DeleteApplicationInstanceCertificateAsync(this.m_applicationConfiguration, ct).ConfigureAwait(false);
  }

  public async Task<bool> CheckApplicationInstanceCertificate(
    bool silent,
    ushort minimumKeySize,
    ushort lifeTimeInMonths,
    CancellationToken ct = default (CancellationToken))
  {
    Utils.LogInfo("Checking application instance certificate.");
    if (this.m_applicationConfiguration == null)
    {
      ApplicationConfiguration applicationConfiguration = await this.LoadApplicationConfiguration(silent).ConfigureAwait(false);
    }
    ApplicationConfiguration configuration = this.m_applicationConfiguration;
    CertificateIdentifier id = configuration.SecurityConfiguration.ApplicationCertificate;
    if (id == null)
      throw ServiceResultException.Create(2156462080U /*0x80890000*/, "Configuration file does not specify a certificate.");
    ConfiguredTaskAwaitable<X509Certificate2> configuredTaskAwaitable = configuration.SecurityConfiguration.ApplicationCertificate.LoadPrivateKeyEx(configuration.SecurityConfiguration.CertificatePasswordProvider).ConfigureAwait(false);
    X509Certificate2 x509Certificate2 = await configuredTaskAwaitable;
    configuredTaskAwaitable = id.Find(true).ConfigureAwait(false);
    X509Certificate2 certificate = await configuredTaskAwaitable;
    if (certificate != null)
    {
      Utils.LogCertificate("Check certificate:", certificate);
      if (!await this.CheckApplicationInstanceCertificateAsync(configuration, certificate, silent, minimumKeySize, ct).ConfigureAwait(false))
      {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("The certificate with subject {0} in the configuration is invalid.");
        stringBuilder.AppendLine(" Please update or delete the certificate from this location:");
        stringBuilder.AppendLine(" {1}");
        throw ServiceResultException.Create(2156462080U /*0x80890000*/, stringBuilder.ToString(), (object) id.SubjectName, (object) Utils.ReplaceSpecialFolderNames(id.StorePath));
      }
    }
    else
    {
      configuredTaskAwaitable = id.Find(false).ConfigureAwait(false);
      certificate = await configuredTaskAwaitable;
      if (certificate != null)
        throw ServiceResultException.Create(2156462080U /*0x80890000*/, "Cannot access certificate private key. Subject={0}", (object) certificate.Subject);
      if (!string.IsNullOrEmpty(id.Thumbprint))
      {
        if (!string.IsNullOrEmpty(id.SubjectName))
        {
          configuredTaskAwaitable = new CertificateIdentifier()
          {
            StoreType = id.StoreType,
            StorePath = id.StorePath,
            SubjectName = id.SubjectName
          }.Find(true).ConfigureAwait(false);
          certificate = await configuredTaskAwaitable;
        }
        if (certificate != null)
        {
          StringBuilder message = new StringBuilder();
          message.AppendLine("Thumbprint was explicitly specified in the configuration.");
          message.AppendLine("Another certificate with the same subject name was found.");
          message.AppendLine("Use it instead?");
          message.AppendLine("Requested: {0}");
          message.AppendLine("Found: {1}");
          if (!await ApplicationInstance.ApproveMessageAsync(string.Format(message.ToString(), (object) id.SubjectName, (object) certificate.Subject), silent).ConfigureAwait(false))
            throw ServiceResultException.Create(2156462080U /*0x80890000*/, message.ToString(), (object) id.SubjectName, (object) certificate.Subject);
          message = (StringBuilder) null;
        }
        else
        {
          StringBuilder stringBuilder = new StringBuilder();
          stringBuilder.AppendLine("Thumbprint was explicitly specified in the configuration.");
          stringBuilder.AppendLine("Cannot generate a new certificate.");
          throw ServiceResultException.Create(2156462080U /*0x80890000*/, stringBuilder.ToString());
        }
      }
    }
    if (certificate == null)
    {
      if (!this.DisableCertificateAutoCreation)
      {
        configuredTaskAwaitable = ApplicationInstance.CreateApplicationInstanceCertificateAsync(configuration, minimumKeySize, lifeTimeInMonths, ct).ConfigureAwait(false);
        certificate = await configuredTaskAwaitable;
      }
      else
        Utils.LogWarning("Application Instance certificate auto creation is disabled.");
      if (certificate == null)
      {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("There is no cert with subject {0} in the configuration.");
        stringBuilder.AppendLine(" Please generate a cert for your application,");
        stringBuilder.AppendLine(" then copy the new cert to this location:");
        stringBuilder.AppendLine(" {1}");
        throw ServiceResultException.Create(2156462080U /*0x80890000*/, stringBuilder.ToString(), (object) id.SubjectName, (object) id.StorePath);
      }
    }
    else if (configuration.SecurityConfiguration.AddAppCertToTrustedStore)
      await ApplicationInstance.AddToTrustedStoreAsync(configuration, certificate, ct).ConfigureAwait(false);
    bool flag = true;
    configuration = (ApplicationConfiguration) null;
    id = (CertificateIdentifier) null;
    certificate = (X509Certificate2) null;
    return flag;
  }

  public async Task AddOwnCertificateToTrustedStoreAsync(
    X509Certificate2 certificate,
    CancellationToken ct)
  {
    await ApplicationInstance.AddToTrustedStoreAsync(this.m_applicationConfiguration, certificate, ct).ConfigureAwait(false);
  }

  private async Task<bool> CheckApplicationInstanceCertificateAsync(
    ApplicationConfiguration configuration,
    X509Certificate2 certificate,
    bool silent,
    ushort minimumKeySize,
    CancellationToken ct)
  {
    if (certificate == null)
      return false;
    ApplicationInstance.CertValidationSuppressibleStatusCodes certValidator = new ApplicationInstance.CertValidationSuppressibleStatusCodes(new StatusCode[6]
    {
      (StatusCode) 2149187584U /*0x801A0000*/,
      (StatusCode) 2148794368U /*0x80140000*/,
      (StatusCode) 2148859904U /*0x80150000*/,
      (StatusCode) 2148925440U /*0x80160000*/,
      (StatusCode) 2149253120U /*0x801B0000*/,
      (StatusCode) 2149318656U /*0x801C0000*/
    });
    Utils.LogCertificate("Check application instance certificate.", certificate);
    try
    {
      configuration.CertificateValidator.CertificateValidation += new CertificateValidationEventHandler(certValidator.OnCertificateValidation);
      await configuration.CertificateValidator.ValidateAsync(certificate.HasPrivateKey ? new X509Certificate2(certificate.RawData) : certificate, ct).ConfigureAwait(false);
    }
    catch (Exception ex)
    {
      if (!await ApplicationInstance.ApproveMessageAsync(Utils.Format("Error validating certificate. Exception: {0}. Use certificate anyway?", (object) ex.Message), silent).ConfigureAwait(false))
        return false;
    }
    finally
    {
      configuration.CertificateValidator.CertificateValidation -= new CertificateValidationEventHandler(certValidator.OnCertificateValidation);
    }
    int rsaPublicKeySize = Opc.Ua.X509Utils.GetRSAPublicKeySize(certificate);
    if ((int) minimumKeySize > rsaPublicKeySize)
    {
      if (!await ApplicationInstance.ApproveMessageAsync(Utils.Format("The key size ({0}) in the certificate is less than the minimum allowed ({1}). Use certificate anyway?", (object) rsaPublicKeySize, (object) minimumKeySize), silent).ConfigureAwait(false))
        return false;
    }
    ConfiguredTaskAwaitable<bool> configuredTaskAwaitable;
    if (configuration.ApplicationType != ApplicationType.Client)
    {
      configuredTaskAwaitable = ApplicationInstance.CheckDomainsInCertificateAsync(configuration, certificate, silent, ct).ConfigureAwait(false);
      if (!await configuredTaskAwaitable)
        return false;
    }
    string applicationUri = Opc.Ua.X509Utils.GetApplicationUriFromCertificate(certificate);
    if (string.IsNullOrEmpty(applicationUri))
    {
      configuredTaskAwaitable = ApplicationInstance.ApproveMessageAsync("The Application URI could not be read from the certificate. Use certificate anyway?", silent).ConfigureAwait(false);
      if (!await configuredTaskAwaitable)
        return false;
    }
    else if (!configuration.ApplicationUri.Equals(applicationUri, StringComparison.Ordinal))
    {
      Utils.LogInfo("Updated the ApplicationUri: {0} --> {1}", (object) configuration.ApplicationUri, (object) applicationUri);
      configuration.ApplicationUri = applicationUri;
    }
    Utils.LogInfo("Using the ApplicationUri: {0}", (object) applicationUri);
    configuration.SecurityConfiguration.ApplicationCertificate.Certificate = certificate;
    return true;
  }

  private static async Task<bool> CheckDomainsInCertificateAsync(
    ApplicationConfiguration configuration,
    X509Certificate2 certificate,
    bool silent,
    CancellationToken ct)
  {
    Utils.LogInfo("Check domains in certificate.");
    bool valid = true;
    IList<string> serverDomainNames = configuration.GetServerDomainNames();
    IList<string> certificateDomainNames = Opc.Ua.X509Utils.GetDomainsFromCertficate(certificate);
    Utils.LogInfo("Server Domain names:");
    foreach (object obj in (IEnumerable<string>) serverDomainNames)
      Utils.LogInfo(" {0}", obj);
    Utils.LogInfo("Certificate Domain names:");
    foreach (object obj in (IEnumerable<string>) certificateDomainNames)
      Utils.LogInfo(" {0}", obj);
    string computerName = Utils.GetHostName();
    IPAddress[] addresses = (IPAddress[]) null;
    for (int ii = 0; ii < serverDomainNames.Count; ++ii)
    {
      if (!Utils.FindStringIgnoreCase(certificateDomainNames, serverDomainNames[ii]))
      {
        int num1;
        if (string.Equals(serverDomainNames[ii], "localhost", StringComparison.OrdinalIgnoreCase))
        {
          if (!Utils.FindStringIgnoreCase(certificateDomainNames, computerName))
          {
            bool found = false;
            if (addresses == null)
              goto label_30;
label_29:
            for (int index = 0; index < addresses.Length; ++index)
            {
              if (Utils.FindStringIgnoreCase(certificateDomainNames, addresses[index].ToString()))
              {
                found = true;
                break;
              }
            }
            if (found)
              continue;
            goto label_24;
label_30:
            ConfiguredTaskAwaitable<IPAddress[]>.ConfiguredTaskAwaiter awaiter = Utils.GetHostAddressesAsync(computerName).ConfigureAwait(false).GetAwaiter();
            if (awaiter.IsCompleted)
            {
              addresses = awaiter.GetResult();
              goto label_29;
            }
            num1 = 0;
            // ISSUE: explicit reference operation
            // ISSUE: reference to a compiler-generated field
            (^this).\u003C\u003E1__state = 0;
            ConfiguredTaskAwaitable<IPAddress[]>.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter;
            // ISSUE: explicit reference operation
            // ISSUE: reference to a compiler-generated field
            (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<IPAddress[]>.ConfiguredTaskAwaiter, ApplicationInstance.\u003CCheckDomainsInCertificateAsync\u003Ed__48>(ref awaiter, this);
            return;
          }
          continue;
        }
label_24:
        string message = Utils.Format("The server is configured to use domain '{0}' which does not appear in the certificate. Use certificate anyway?", (object) serverDomainNames[ii]);
        valid = false;
        int num2 = silent ? 1 : 0;
        ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter awaiter1 = ApplicationInstance.ApproveMessageAsync(message, num2 != 0).ConfigureAwait(false).GetAwaiter();
        if (awaiter1.IsCompleted)
        {
          if (awaiter1.GetResult())
            valid = true;
          else
            break;
        }
        else
        {
          num1 = 1;
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          (^this).\u003C\u003E1__state = 1;
          ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter configuredTaskAwaiter = awaiter1;
          // ISSUE: explicit reference operation
          // ISSUE: reference to a compiler-generated field
          (^this).\u003C\u003Et__builder.AwaitUnsafeOnCompleted<ConfiguredTaskAwaitable<bool>.ConfiguredTaskAwaiter, ApplicationInstance.\u003CCheckDomainsInCertificateAsync\u003Ed__48>(ref awaiter1, this);
          return;
        }
      }
    }
    bool flag = valid;
    serverDomainNames = (IList<string>) null;
    certificateDomainNames = (IList<string>) null;
    computerName = (string) null;
    addresses = (IPAddress[]) null;
    return flag;
  }

  private static async Task<X509Certificate2> CreateApplicationInstanceCertificateAsync(
    ApplicationConfiguration configuration,
    ushort keySize,
    ushort lifeTimeInMonths,
    CancellationToken ct)
  {
    await ApplicationInstance.DeleteApplicationInstanceCertificateAsync(configuration, ct).ConfigureAwait(false);
    Utils.LogInfo("Creating application instance certificate.");
    CertificateIdentifier id = configuration.SecurityConfiguration.ApplicationCertificate;
    IList<string> serverDomainNames = configuration.GetServerDomainNames();
    if (serverDomainNames.Count == 0)
      serverDomainNames.Add(Utils.GetHostName());
    if (id.StoreType == "Directory")
      Utils.GetAbsoluteDirectoryPath(id.StorePath, true, true, true);
    ICertificatePasswordProvider passwordProvider = configuration.SecurityConfiguration.CertificatePasswordProvider;
    X509Certificate2 certificate = CertificateFactory.CreateCertificate(configuration.ApplicationUri, configuration.ApplicationName, id.SubjectName, serverDomainNames).SetLifeTime(lifeTimeInMonths).SetRSAKeySize(keySize).CreateForRSA();
    id.Certificate = certificate;
    ConfiguredTaskAwaitable<X509Certificate2> configuredTaskAwaitable = certificate.AddToStoreAsync(id.StoreType, id.StorePath, passwordProvider?.GetPassword(id), ct).ConfigureAwait(false);
    X509Certificate2 x509Certificate2 = await configuredTaskAwaitable;
    if (configuration.SecurityConfiguration.AddAppCertToTrustedStore)
      await ApplicationInstance.AddToTrustedStoreAsync(configuration, certificate, ct).ConfigureAwait(false);
    CertificateIdentifier certificateIdentifier = id;
    configuredTaskAwaitable = configuration.SecurityConfiguration.ApplicationCertificate.LoadPrivateKeyEx(passwordProvider).ConfigureAwait(false);
    certificateIdentifier.Certificate = await configuredTaskAwaitable;
    certificateIdentifier = (CertificateIdentifier) null;
    await configuration.CertificateValidator.Update(configuration.SecurityConfiguration).ConfigureAwait(false);
    Utils.LogCertificate("Certificate created for {0}.", certificate, (object) configuration.ApplicationUri);
    X509Certificate2 certificate1 = id.Certificate;
    id = (CertificateIdentifier) null;
    passwordProvider = (ICertificatePasswordProvider) null;
    certificate = (X509Certificate2) null;
    return certificate1;
  }

  private static async Task DeleteApplicationInstanceCertificateAsync(
    ApplicationConfiguration configuration,
    CancellationToken ct)
  {
    CertificateIdentifier id = configuration.SecurityConfiguration.ApplicationCertificate;
    X509Certificate2 certificate;
    if (id == null)
    {
      id = (CertificateIdentifier) null;
      certificate = (X509Certificate2) null;
    }
    else
    {
      certificate = await id.Find().ConfigureAwait(false);
      if (certificate != null)
        Utils.LogCertificate((EventId) 512 /*0x0200*/, "Deleting application instance certificate and private key.", certificate);
      ICertificateStore store;
      if (configuration.SecurityConfiguration != null && configuration.SecurityConfiguration.TrustedPeerCertificates != null)
      {
        string thumbprint = id.Thumbprint;
        if (certificate != null)
          thumbprint = certificate.Thumbprint;
        if (!string.IsNullOrEmpty(thumbprint))
        {
          store = configuration.SecurityConfiguration.TrustedPeerCertificates.OpenStore();
          try
          {
            if (await store.Delete(thumbprint).ConfigureAwait(false))
              Utils.LogInfo((EventId) 512 /*0x0200*/, "Application Instance Certificate [{0}] deleted from trusted store.", (object) thumbprint);
          }
          finally
          {
            store?.Dispose();
          }
          store = (ICertificateStore) null;
        }
        thumbprint = (string) null;
      }
      if (certificate != null)
      {
        store = id.OpenStore();
        try
        {
          if (await store.Delete(certificate.Thumbprint).ConfigureAwait(false))
            Utils.LogCertificate((EventId) 512 /*0x0200*/, "Application certificate and private key deleted.", certificate);
        }
        finally
        {
          store?.Dispose();
        }
        store = (ICertificateStore) null;
      }
      id.Certificate = (X509Certificate2) null;
      id = (CertificateIdentifier) null;
      certificate = (X509Certificate2) null;
    }
  }

  private static async Task AddToTrustedStoreAsync(
    ApplicationConfiguration configuration,
    X509Certificate2 certificate,
    CancellationToken ct)
  {
    if (certificate == null)
      throw new ArgumentNullException(nameof (certificate));
    string str = (string) null;
    if (configuration != null && configuration.SecurityConfiguration != null && configuration.SecurityConfiguration.TrustedPeerCertificates != null)
      str = configuration.SecurityConfiguration.TrustedPeerCertificates.StorePath;
    if (string.IsNullOrEmpty(str))
    {
      Utils.LogWarning("WARNING: Trusted peer store not specified.");
    }
    else
    {
      try
      {
        ICertificateStore store = configuration.SecurityConfiguration.TrustedPeerCertificates.OpenStore();
        if (store == null)
        {
          Utils.LogWarning("Could not open trusted peer store.");
        }
        else
        {
          try
          {
            if ((await store.FindByThumbprint(certificate.Thumbprint).ConfigureAwait(false)).Count > 0)
              return;
            Utils.LogCertificate("Adding application certificate to trusted peer store.", certificate);
            List<string> subjectName = Opc.Ua.X509Utils.ParseDistinguishedName(certificate.Subject);
            X509Certificate2Collection certificate2Collection = await store.Enumerate().ConfigureAwait(false);
            for (int index = 0; index < certificate2Collection.Count; ++index)
            {
              if (Opc.Ua.X509Utils.CompareDistinguishedName(certificate2Collection[index], subjectName))
              {
                if (certificate2Collection[index].Thumbprint == certificate.Thumbprint)
                  return;
                Utils.LogCertificate("Delete Certificate from trusted store.", certificate);
                int num = await store.Delete(certificate2Collection[index].Thumbprint).ConfigureAwait(false) ? 1 : 0;
                break;
              }
            }
            await store.Add(new X509Certificate2(certificate.RawData)).ConfigureAwait(false);
            Utils.LogInfo("Added application certificate to trusted peer store.");
            subjectName = (List<string>) null;
          }
          finally
          {
            store.Close();
          }
          store = (ICertificateStore) null;
        }
      }
      catch (Exception ex)
      {
        object[] objArray = Array.Empty<object>();
        Utils.LogError(ex, "Could not add certificate to trusted peer store.", objArray);
      }
    }
  }

  private static async Task<bool> ApproveMessageAsync(string message, bool silent)
  {
    if (!silent && ApplicationInstance.MessageDlg != null)
    {
      ApplicationInstance.MessageDlg.Message(message, true);
      return await ApplicationInstance.MessageDlg.ShowAsync().ConfigureAwait(false);
    }
    Utils.LogError(message);
    return false;
  }

  private class CertValidationSuppressibleStatusCodes
  {
    public StatusCode[] ApprovedCodes { get; }

    public CertValidationSuppressibleStatusCodes(StatusCode[] approvedCodes)
    {
      this.ApprovedCodes = approvedCodes;
    }

    public void OnCertificateValidation(object sender, CertificateValidationEventArgs e)
    {
      if (!((IEnumerable<StatusCode>) this.ApprovedCodes).Contains<StatusCode>(e.Error.StatusCode))
        return;
      Utils.LogWarning("Application Certificate Validation suppressed {0}", (object) e.Error.StatusCode);
      e.Accept = true;
    }
  }
}
