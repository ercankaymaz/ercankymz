// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ApplicationConfiguration
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/SDK/Configuration.xsd")]
[ComVisible(true)]
public class ApplicationConfiguration
{
  private string m_applicationName;
  private string m_applicationUri;
  private string m_productUri;
  private ApplicationType m_applicationType;
  private SecurityConfiguration m_securityConfiguration;
  private TransportConfigurationCollection m_transportConfigurations;
  private TransportQuotas m_transportQuotas;
  private ServerConfiguration m_serverConfiguration;
  private ClientConfiguration m_clientConfiguration;
  private DiscoveryServerConfiguration m_discoveryServerConfiguration;
  private TraceConfiguration m_traceConfiguration;
  private bool m_disableHiResClock;
  private XmlElementCollection m_extensions;
  private List<object> m_extensionObjects;
  private string m_sourceFilePath;
  private IServiceMessageContext m_messageContext;
  private CertificateValidator m_certificateValidator;
  private Dictionary<string, object> m_properties;

  public ApplicationConfiguration() => this.Initialize();

  public ApplicationConfiguration(ApplicationConfiguration template)
  {
    this.Initialize();
    this.m_applicationName = template.m_applicationName;
    this.m_applicationType = template.m_applicationType;
    this.m_applicationUri = template.m_applicationUri;
    this.m_discoveryServerConfiguration = template.m_discoveryServerConfiguration;
    this.m_securityConfiguration = template.m_securityConfiguration;
    this.m_transportConfigurations = template.m_transportConfigurations;
    this.m_serverConfiguration = template.m_serverConfiguration;
    this.m_clientConfiguration = template.m_clientConfiguration;
    this.m_disableHiResClock = template.m_disableHiResClock;
    this.m_certificateValidator = template.m_certificateValidator;
    this.m_transportQuotas = template.m_transportQuotas;
    this.m_traceConfiguration = template.m_traceConfiguration;
    this.m_extensions = template.m_extensions;
    this.m_extensionObjects = template.m_extensionObjects;
    this.m_sourceFilePath = template.m_sourceFilePath;
    this.m_messageContext = template.m_messageContext;
    this.m_properties = template.m_properties;
  }

  private void Initialize()
  {
    this.m_sourceFilePath = (string) null;
    this.m_securityConfiguration = new SecurityConfiguration();
    this.m_transportConfigurations = new TransportConfigurationCollection();
    this.m_disableHiResClock = false;
    this.m_properties = new Dictionary<string, object>();
    this.m_certificateValidator = new CertificateValidator();
    this.m_extensionObjects = new List<object>();
  }

  [OnDeserializing]
  public void Initialize(StreamingContext context) => this.Initialize();

  public object PropertiesLock => (object) this.m_properties;

  public IDictionary<string, object> Properties => (IDictionary<string, object>) this.m_properties;

  public IList<object> ExtensionObjects => (IList<object>) this.m_extensionObjects;

  [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 0)]
  public string ApplicationName
  {
    get => this.m_applicationName;
    set => this.m_applicationName = value;
  }

  [DataMember(IsRequired = true, EmitDefaultValue = false, Order = 1)]
  public string ApplicationUri
  {
    get => this.m_applicationUri;
    set => this.m_applicationUri = value;
  }

  [DataMember(IsRequired = false, Order = 2)]
  public string ProductUri
  {
    get => this.m_productUri;
    set => this.m_productUri = value;
  }

  [DataMember(IsRequired = true, Order = 3)]
  public ApplicationType ApplicationType
  {
    get => this.m_applicationType;
    set => this.m_applicationType = value;
  }

  [DataMember(IsRequired = false, EmitDefaultValue = true, Order = 4)]
  public SecurityConfiguration SecurityConfiguration
  {
    get => this.m_securityConfiguration;
    set => this.m_securityConfiguration = value ?? new SecurityConfiguration();
  }

  [DataMember(IsRequired = false, EmitDefaultValue = true, Order = 5)]
  public TransportConfigurationCollection TransportConfigurations
  {
    get => this.m_transportConfigurations;
    set => this.m_transportConfigurations = value ?? new TransportConfigurationCollection();
  }

  [DataMember(IsRequired = false, EmitDefaultValue = true, Order = 6)]
  public TransportQuotas TransportQuotas
  {
    get => this.m_transportQuotas;
    set => this.m_transportQuotas = value;
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 7)]
  public ServerConfiguration ServerConfiguration
  {
    get => this.m_serverConfiguration;
    set => this.m_serverConfiguration = value;
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 8)]
  public ClientConfiguration ClientConfiguration
  {
    get => this.m_clientConfiguration;
    set => this.m_clientConfiguration = value;
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 9)]
  public DiscoveryServerConfiguration DiscoveryServerConfiguration
  {
    get => this.m_discoveryServerConfiguration;
    set => this.m_discoveryServerConfiguration = value;
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 10)]
  public XmlElementCollection Extensions
  {
    get => this.m_extensions;
    set => this.m_extensions = value;
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 11)]
  public TraceConfiguration TraceConfiguration
  {
    get => this.m_traceConfiguration;
    set => this.m_traceConfiguration = value;
  }

  [DataMember(IsRequired = false, EmitDefaultValue = false, Order = 12)]
  public bool DisableHiResClock
  {
    get => this.m_disableHiResClock;
    set => this.m_disableHiResClock = value;
  }

  public string SourceFilePath => this.m_sourceFilePath;

  public CertificateValidator CertificateValidator
  {
    get => this.m_certificateValidator;
    set => this.m_certificateValidator = value;
  }

  public IList<string> GetServerDomainNames()
  {
    StringCollection stringCollection = new StringCollection();
    if (this.ServerConfiguration != null)
    {
      if (this.ServerConfiguration.BaseAddresses != null)
        stringCollection.AddRange((IEnumerable<string>) this.ServerConfiguration.BaseAddresses);
      if (this.ServerConfiguration.AlternateBaseAddresses != null)
        stringCollection.AddRange((IEnumerable<string>) this.ServerConfiguration.AlternateBaseAddresses);
    }
    if (this.DiscoveryServerConfiguration != null)
    {
      if (this.DiscoveryServerConfiguration.BaseAddresses != null)
        stringCollection.AddRange((IEnumerable<string>) this.DiscoveryServerConfiguration.BaseAddresses);
      if (this.DiscoveryServerConfiguration.AlternateBaseAddresses != null)
        stringCollection.AddRange((IEnumerable<string>) this.DiscoveryServerConfiguration.AlternateBaseAddresses);
    }
    List<string> strings = new List<string>();
    for (int index = 0; index < stringCollection.Count; ++index)
    {
      Uri uri = Utils.ParseUri(stringCollection[index]);
      if (!(uri == (Uri) null))
      {
        string dnsSafeHost = uri.DnsSafeHost;
        string target = uri.HostNameType != UriHostNameType.Dns ? Utils.NormalizedIPAddress(dnsSafeHost) : Utils.ReplaceLocalhost(dnsSafeHost);
        if (!Utils.FindStringIgnoreCase((IList<string>) strings, target))
          strings.Add(target);
      }
    }
    return (IList<string>) strings;
  }

  public ServiceMessageContext CreateMessageContext(bool clonedFactory = false)
  {
    ServiceMessageContext messageContext = new ServiceMessageContext();
    if (this.m_transportQuotas != null)
    {
      messageContext.MaxArrayLength = this.m_transportQuotas.MaxArrayLength;
      messageContext.MaxByteStringLength = this.m_transportQuotas.MaxByteStringLength;
      messageContext.MaxStringLength = this.m_transportQuotas.MaxStringLength;
      messageContext.MaxMessageSize = this.m_transportQuotas.MaxMessageSize;
    }
    messageContext.NamespaceUris = new NamespaceTable();
    messageContext.ServerUris = new StringTable();
    if (clonedFactory)
      messageContext.Factory = (IEncodeableFactory) new EncodeableFactory((IEncodeableFactory) EncodeableFactory.GlobalFactory);
    return messageContext;
  }

  [Obsolete("Warning: Behavior changed return a copy instead of a reference. Should call CreateMessageContext() instead.")]
  public IServiceMessageContext MessageContext
  {
    get
    {
      if (this.m_messageContext == null)
        this.m_messageContext = (IServiceMessageContext) this.CreateMessageContext();
      return this.m_messageContext;
    }
  }

  public static Task<ApplicationConfiguration> Load(
    string sectionName,
    ApplicationType applicationType)
  {
    return ApplicationConfiguration.Load(sectionName, applicationType, typeof (ApplicationConfiguration));
  }

  public static Task<ApplicationConfiguration> Load(
    string sectionName,
    ApplicationType applicationType,
    Type systemType)
  {
    string pathFromAppConfig = ApplicationConfiguration.GetFilePathFromAppConfig(sectionName);
    FileInfo file = new FileInfo(pathFromAppConfig);
    if (!file.Exists)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.AppendFormat("Configuration file does not exist: {0}", (object) pathFromAppConfig);
      stringBuilder.AppendLine();
      stringBuilder.AppendFormat("Current directory is: {0}", (object) Directory.GetCurrentDirectory());
      throw ServiceResultException.Create(2156462080U /*0x80890000*/, stringBuilder.ToString());
    }
    return ApplicationConfiguration.Load(file, applicationType, systemType);
  }

  public static ApplicationConfiguration LoadWithNoValidation(FileInfo file, Type systemType)
  {
    using (FileStream fileStream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
    {
      try
      {
        if (new DataContractSerializer(systemType).ReadObject((Stream) fileStream) is ApplicationConfiguration applicationConfiguration)
          applicationConfiguration.m_sourceFilePath = file.FullName;
        return applicationConfiguration;
      }
      catch (Exception ex)
      {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendFormat("Configuration file could not be loaded: {0}", (object) file.FullName);
        stringBuilder.AppendLine();
        stringBuilder.AppendFormat("Error is: {0}", (object) ex.Message);
        throw ServiceResultException.Create(2156462080U /*0x80890000*/, ex, stringBuilder.ToString());
      }
    }
  }

  public static Task<ApplicationConfiguration> Load(
    FileInfo file,
    ApplicationType applicationType,
    Type systemType)
  {
    return ApplicationConfiguration.Load(file, applicationType, systemType, true);
  }

  public static async Task<ApplicationConfiguration> Load(
    FileInfo file,
    ApplicationType applicationType,
    Type systemType,
    bool applyTraceSettings,
    ICertificatePasswordProvider certificatePasswordProvider = null)
  {
    ApplicationConfiguration applicationConfiguration = (ApplicationConfiguration) null;
    try
    {
      using (FileStream stream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
        applicationConfiguration = await ApplicationConfiguration.Load((Stream) stream, applicationType, systemType, applyTraceSettings, certificatePasswordProvider).ConfigureAwait(false);
    }
    catch (Exception ex)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.AppendFormat("Configuration file could not be loaded: {0}", (object) file.FullName);
      stringBuilder.AppendLine();
      stringBuilder.Append(ex.Message);
      throw ServiceResultException.Create(2156462080U /*0x80890000*/, ex, stringBuilder.ToString());
    }
    if (applicationConfiguration != null)
      applicationConfiguration.m_sourceFilePath = file.FullName;
    return applicationConfiguration;
  }

  public static async Task<ApplicationConfiguration> Load(
    Stream stream,
    ApplicationType applicationType,
    Type systemType,
    bool applyTraceSettings,
    ICertificatePasswordProvider certificatePasswordProvider = null)
  {
    ApplicationConfiguration configuration = (ApplicationConfiguration) null;
    Type type = systemType;
    if ((object) type == null)
      type = typeof (ApplicationConfiguration);
    systemType = type;
    try
    {
      configuration = (ApplicationConfiguration) new DataContractSerializer(systemType).ReadObject(stream);
    }
    catch (Exception ex)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.AppendFormat("Configuration could not be loaded.");
      stringBuilder.AppendLine();
      stringBuilder.AppendFormat("Error is: {0}", (object) ex.Message);
      throw ServiceResultException.Create(2156462080U /*0x80890000*/, ex, stringBuilder.ToString());
    }
    if (configuration != null)
    {
      if (applyTraceSettings && configuration.TraceConfiguration != null)
        configuration.TraceConfiguration.ApplySettings();
      configuration.SecurityConfiguration.CertificatePasswordProvider = certificatePasswordProvider;
      await configuration.Validate(applicationType).ConfigureAwait(false);
    }
    ApplicationConfiguration applicationConfiguration = configuration;
    configuration = (ApplicationConfiguration) null;
    return applicationConfiguration;
  }

  public static string GetFilePathFromAppConfig(string sectionName)
  {
    return Utils.GetAbsoluteFilePath(sectionName + ".Config.xml", true, false, false) ?? sectionName + ".Config.xml";
  }

  public void SaveToFile(string filePath)
  {
    XmlWriterSettings settings = Utils.DefaultXmlWriterSettings();
    settings.CloseOutput = true;
    using (Stream output = (Stream) File.Open(filePath, FileMode.Create, FileAccess.ReadWrite))
    {
      using (XmlWriter writer = XmlWriter.Create(output, settings))
        new DataContractSerializer(this.GetType()).WriteObject(writer, (object) this);
    }
  }

  public virtual async Task Validate(ApplicationType applicationType)
  {
    ApplicationConfiguration applicationConfiguration = this;
    if (string.IsNullOrEmpty(applicationConfiguration.ApplicationName))
      throw ServiceResultException.Create(2156462080U /*0x80890000*/, "ApplicationName must be specified.");
    if (applicationConfiguration.SecurityConfiguration == null)
      throw ServiceResultException.Create(2156462080U /*0x80890000*/, "SecurityConfiguration must be specified.");
    applicationConfiguration.SecurityConfiguration.Validate();
    X509Certificate2 x509Certificate2 = await applicationConfiguration.SecurityConfiguration.ApplicationCertificate.LoadPrivateKeyEx(applicationConfiguration.SecurityConfiguration.CertificatePasswordProvider).ConfigureAwait(false);
    // ISSUE: reference to a compiler-generated method
    Func<string> func = new Func<string>(applicationConfiguration.\u003CValidate\u003Eb__84_0);
    if (string.IsNullOrEmpty(applicationConfiguration.ApplicationUri))
      applicationConfiguration.m_applicationUri = func();
    if (applicationType == ApplicationType.Client || applicationType == ApplicationType.ClientAndServer)
    {
      if (applicationConfiguration.ClientConfiguration == null)
        throw ServiceResultException.Create(2156462080U /*0x80890000*/, "ClientConfiguration must be specified.");
      applicationConfiguration.ClientConfiguration.Validate();
    }
    if (applicationType == ApplicationType.Server || applicationType == ApplicationType.ClientAndServer)
    {
      if (applicationConfiguration.ServerConfiguration == null)
        throw ServiceResultException.Create(2156462080U /*0x80890000*/, "ServerConfiguration must be specified.");
      applicationConfiguration.ServerConfiguration.Validate();
    }
    if (applicationType == ApplicationType.DiscoveryServer)
    {
      if (applicationConfiguration.DiscoveryServerConfiguration == null)
        throw ServiceResultException.Create(2156462080U /*0x80890000*/, "DiscoveryServerConfiguration must be specified.");
      applicationConfiguration.DiscoveryServerConfiguration.Validate();
    }
    HiResClock.Disabled = applicationConfiguration.m_disableHiResClock;
    if (HiResClock.Disabled && applicationConfiguration.m_serverConfiguration != null && applicationConfiguration.m_serverConfiguration.PublishingResolution < 50)
      applicationConfiguration.m_serverConfiguration.PublishingResolution = 50;
    await applicationConfiguration.m_certificateValidator.Update(applicationConfiguration.SecurityConfiguration).ConfigureAwait(false);
  }

  public ConfiguredEndpointCollection LoadCachedEndpoints(bool createAlways)
  {
    return this.LoadCachedEndpoints(createAlways, false);
  }

  public ConfiguredEndpointCollection LoadCachedEndpoints(
    bool createAlways,
    bool overrideConfiguration)
  {
    string str = this.m_clientConfiguration != null ? Utils.GetAbsoluteFilePath(this.m_clientConfiguration.EndpointCacheFilePath, true, false, false) : throw new InvalidOperationException("Only valid for client configurations.");
    if (str == null)
    {
      str = this.m_clientConfiguration.EndpointCacheFilePath;
      if (!Utils.IsPathRooted(str))
        str = Utils.Format("{0}{1}{2}", (object) new FileInfo(this.SourceFilePath).DirectoryName, (object) Path.DirectorySeparatorChar, (object) str);
    }
    if (!createAlways)
      return ConfiguredEndpointCollection.Load(this, str, overrideConfiguration);
    ConfiguredEndpointCollection endpointCollection = new ConfiguredEndpointCollection(this);
    try
    {
      endpointCollection = ConfiguredEndpointCollection.Load(this, str, overrideConfiguration);
    }
    catch (Exception ex)
    {
      object[] objArray = new object[1]{ (object) str };
      Utils.Trace(ex, "Could not load configuration from file: {0}", objArray);
    }
    finally
    {
      string absoluteFilePath = Utils.GetAbsoluteFilePath(this.m_clientConfiguration.EndpointCacheFilePath, true, false, true, true);
      if (absoluteFilePath != str)
        endpointCollection.Save(absoluteFilePath);
    }
    return endpointCollection;
  }

  public T ParseExtension<T>() => this.ParseExtension<T>((XmlQualifiedName) null);

  public T ParseExtension<T>(XmlQualifiedName elementName)
  {
    return Utils.ParseExtension<T>((IList<XmlElement>) this.m_extensions, elementName);
  }

  public void UpdateExtension<T>(XmlQualifiedName elementName, object value)
  {
    Utils.UpdateExtension<T>(ref this.m_extensions, elementName, value);
  }
}
