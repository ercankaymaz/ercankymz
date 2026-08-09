using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

	public object PropertiesLock => m_properties;

	public IDictionary<string, object> Properties => m_properties;

	public IList<object> ExtensionObjects => m_extensionObjects;

	[DataMember(IsRequired = true, EmitDefaultValue = false, Order = 0)]
	public string ApplicationName
	{
		get
		{
			return m_applicationName;
		}
		set
		{
			m_applicationName = value;
		}
	}

	[DataMember(IsRequired = true, EmitDefaultValue = false, Order = 1)]
	public string ApplicationUri
	{
		get
		{
			return m_applicationUri;
		}
		set
		{
			m_applicationUri = value;
		}
	}

	[DataMember(IsRequired = false, Order = 2)]
	public string ProductUri
	{
		get
		{
			return m_productUri;
		}
		set
		{
			m_productUri = value;
		}
	}

	[DataMember(IsRequired = true, Order = 3)]
	public ApplicationType ApplicationType
	{
		get
		{
			return m_applicationType;
		}
		set
		{
			m_applicationType = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = true, Order = 4)]
	public SecurityConfiguration SecurityConfiguration
	{
		get
		{
			return m_securityConfiguration;
		}
		set
		{
			m_securityConfiguration = value ?? new SecurityConfiguration();
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = true, Order = 5)]
	public TransportConfigurationCollection TransportConfigurations
	{
		get
		{
			return m_transportConfigurations;
		}
		set
		{
			m_transportConfigurations = value ?? new TransportConfigurationCollection();
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = true, Order = 6)]
	public TransportQuotas TransportQuotas
	{
		get
		{
			return m_transportQuotas;
		}
		set
		{
			m_transportQuotas = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 7)]
	public ServerConfiguration ServerConfiguration
	{
		get
		{
			return m_serverConfiguration;
		}
		set
		{
			m_serverConfiguration = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 8)]
	public ClientConfiguration ClientConfiguration
	{
		get
		{
			return m_clientConfiguration;
		}
		set
		{
			m_clientConfiguration = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 9)]
	public DiscoveryServerConfiguration DiscoveryServerConfiguration
	{
		get
		{
			return m_discoveryServerConfiguration;
		}
		set
		{
			m_discoveryServerConfiguration = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 10)]
	public XmlElementCollection Extensions
	{
		get
		{
			return m_extensions;
		}
		set
		{
			m_extensions = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 11)]
	public TraceConfiguration TraceConfiguration
	{
		get
		{
			return m_traceConfiguration;
		}
		set
		{
			m_traceConfiguration = value;
		}
	}

	[DataMember(IsRequired = false, EmitDefaultValue = false, Order = 12)]
	public bool DisableHiResClock
	{
		get
		{
			return m_disableHiResClock;
		}
		set
		{
			m_disableHiResClock = value;
		}
	}

	public string SourceFilePath => m_sourceFilePath;

	public CertificateValidator CertificateValidator
	{
		get
		{
			return m_certificateValidator;
		}
		set
		{
			m_certificateValidator = value;
		}
	}

	[Obsolete("Warning: Behavior changed return a copy instead of a reference. Should call CreateMessageContext() instead.")]
	public IServiceMessageContext MessageContext
	{
		get
		{
			if (m_messageContext == null)
			{
				m_messageContext = CreateMessageContext();
			}
			return m_messageContext;
		}
	}

	public ApplicationConfiguration()
	{
		Initialize();
	}

	public ApplicationConfiguration(ApplicationConfiguration template)
	{
		Initialize();
		m_applicationName = template.m_applicationName;
		m_applicationType = template.m_applicationType;
		m_applicationUri = template.m_applicationUri;
		m_discoveryServerConfiguration = template.m_discoveryServerConfiguration;
		m_securityConfiguration = template.m_securityConfiguration;
		m_transportConfigurations = template.m_transportConfigurations;
		m_serverConfiguration = template.m_serverConfiguration;
		m_clientConfiguration = template.m_clientConfiguration;
		m_disableHiResClock = template.m_disableHiResClock;
		m_certificateValidator = template.m_certificateValidator;
		m_transportQuotas = template.m_transportQuotas;
		m_traceConfiguration = template.m_traceConfiguration;
		m_extensions = template.m_extensions;
		m_extensionObjects = template.m_extensionObjects;
		m_sourceFilePath = template.m_sourceFilePath;
		m_messageContext = template.m_messageContext;
		m_properties = template.m_properties;
	}

	private void Initialize()
	{
		m_sourceFilePath = null;
		m_securityConfiguration = new SecurityConfiguration();
		m_transportConfigurations = new TransportConfigurationCollection();
		m_disableHiResClock = false;
		m_properties = new Dictionary<string, object>();
		m_certificateValidator = new CertificateValidator();
		m_extensionObjects = new List<object>();
	}

	[OnDeserializing]
	public void Initialize(StreamingContext context)
	{
		Initialize();
	}

	public IList<string> GetServerDomainNames()
	{
		StringCollection stringCollection = new StringCollection();
		if (ServerConfiguration != null)
		{
			if (ServerConfiguration.BaseAddresses != null)
			{
				stringCollection.AddRange(ServerConfiguration.BaseAddresses);
			}
			if (ServerConfiguration.AlternateBaseAddresses != null)
			{
				stringCollection.AddRange(ServerConfiguration.AlternateBaseAddresses);
			}
		}
		if (DiscoveryServerConfiguration != null)
		{
			if (DiscoveryServerConfiguration.BaseAddresses != null)
			{
				stringCollection.AddRange(DiscoveryServerConfiguration.BaseAddresses);
			}
			if (DiscoveryServerConfiguration.AlternateBaseAddresses != null)
			{
				stringCollection.AddRange(DiscoveryServerConfiguration.AlternateBaseAddresses);
			}
		}
		List<string> list = new List<string>();
		for (int i = 0; i < stringCollection.Count; i++)
		{
			Uri uri = Utils.ParseUri(stringCollection[i]);
			if (!(uri == null))
			{
				string dnsSafeHost = uri.DnsSafeHost;
				dnsSafeHost = ((uri.HostNameType != UriHostNameType.Dns) ? Utils.NormalizedIPAddress(dnsSafeHost) : Utils.ReplaceLocalhost(dnsSafeHost));
				if (!Utils.FindStringIgnoreCase(list, dnsSafeHost))
				{
					list.Add(dnsSafeHost);
				}
			}
		}
		return list;
	}

	public ServiceMessageContext CreateMessageContext(bool clonedFactory = false)
	{
		ServiceMessageContext serviceMessageContext = new ServiceMessageContext();
		if (m_transportQuotas != null)
		{
			serviceMessageContext.MaxArrayLength = m_transportQuotas.MaxArrayLength;
			serviceMessageContext.MaxByteStringLength = m_transportQuotas.MaxByteStringLength;
			serviceMessageContext.MaxStringLength = m_transportQuotas.MaxStringLength;
			serviceMessageContext.MaxMessageSize = m_transportQuotas.MaxMessageSize;
		}
		serviceMessageContext.NamespaceUris = new NamespaceTable();
		serviceMessageContext.ServerUris = new StringTable();
		if (clonedFactory)
		{
			serviceMessageContext.Factory = new EncodeableFactory(EncodeableFactory.GlobalFactory);
		}
		return serviceMessageContext;
	}

	public static Task<ApplicationConfiguration> Load(string sectionName, ApplicationType applicationType)
	{
		return Load(sectionName, applicationType, typeof(ApplicationConfiguration));
	}

	public static Task<ApplicationConfiguration> Load(string sectionName, ApplicationType applicationType, Type systemType)
	{
		string filePathFromAppConfig = GetFilePathFromAppConfig(sectionName);
		FileInfo fileInfo = new FileInfo(filePathFromAppConfig);
		if (!fileInfo.Exists)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("Configuration file does not exist: {0}", filePathFromAppConfig);
			stringBuilder.AppendLine();
			stringBuilder.AppendFormat("Current directory is: {0}", Directory.GetCurrentDirectory());
			throw ServiceResultException.Create(2156462080u, stringBuilder.ToString());
		}
		return Load(fileInfo, applicationType, systemType);
	}

	public static ApplicationConfiguration LoadWithNoValidation(FileInfo file, Type systemType)
	{
		using FileStream stream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read);
		try
		{
			ApplicationConfiguration applicationConfiguration = new DataContractSerializer(systemType).ReadObject(stream) as ApplicationConfiguration;
			if (applicationConfiguration != null)
			{
				applicationConfiguration.m_sourceFilePath = file.FullName;
			}
			return applicationConfiguration;
		}
		catch (Exception ex)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("Configuration file could not be loaded: {0}", file.FullName);
			stringBuilder.AppendLine();
			stringBuilder.AppendFormat("Error is: {0}", ex.Message);
			throw ServiceResultException.Create(2156462080u, ex, stringBuilder.ToString());
		}
	}

	public static Task<ApplicationConfiguration> Load(FileInfo file, ApplicationType applicationType, Type systemType)
	{
		return Load(file, applicationType, systemType, applyTraceSettings: true);
	}

	public static async Task<ApplicationConfiguration> Load(FileInfo file, ApplicationType applicationType, Type systemType, bool applyTraceSettings, ICertificatePasswordProvider certificatePasswordProvider = null)
	{
		ApplicationConfiguration applicationConfiguration = null;
		try
		{
			using FileStream stream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read);
			applicationConfiguration = await Load(stream, applicationType, systemType, applyTraceSettings, certificatePasswordProvider).ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (Exception ex)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("Configuration file could not be loaded: {0}", file.FullName);
			stringBuilder.AppendLine();
			stringBuilder.Append(ex.Message);
			throw ServiceResultException.Create(2156462080u, ex, stringBuilder.ToString());
		}
		if (applicationConfiguration != null)
		{
			applicationConfiguration.m_sourceFilePath = file.FullName;
		}
		return applicationConfiguration;
	}

	public static async Task<ApplicationConfiguration> Load(Stream stream, ApplicationType applicationType, Type systemType, bool applyTraceSettings, ICertificatePasswordProvider certificatePasswordProvider = null)
	{
		systemType = systemType ?? typeof(ApplicationConfiguration);
		ApplicationConfiguration configuration;
		try
		{
			DataContractSerializer dataContractSerializer = new DataContractSerializer(systemType);
			configuration = (ApplicationConfiguration)dataContractSerializer.ReadObject(stream);
		}
		catch (Exception ex)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("Configuration could not be loaded.");
			stringBuilder.AppendLine();
			stringBuilder.AppendFormat("Error is: {0}", ex.Message);
			throw ServiceResultException.Create(2156462080u, ex, stringBuilder.ToString());
		}
		if (configuration != null)
		{
			if (applyTraceSettings && configuration.TraceConfiguration != null)
			{
				configuration.TraceConfiguration.ApplySettings();
			}
			configuration.SecurityConfiguration.CertificatePasswordProvider = certificatePasswordProvider;
			await configuration.Validate(applicationType).ConfigureAwait(continueOnCapturedContext: false);
		}
		return configuration;
	}

	public static string GetFilePathFromAppConfig(string sectionName)
	{
		string absoluteFilePath = Utils.GetAbsoluteFilePath(sectionName + ".Config.xml", checkCurrentDirectory: true, throwOnError: false, createAlways: false);
		if (absoluteFilePath == null)
		{
			return sectionName + ".Config.xml";
		}
		return absoluteFilePath;
	}

	public void SaveToFile(string filePath)
	{
		XmlWriterSettings xmlWriterSettings = Utils.DefaultXmlWriterSettings();
		xmlWriterSettings.CloseOutput = true;
		using Stream output = File.Open(filePath, FileMode.Create, FileAccess.ReadWrite);
		using XmlWriter writer = XmlWriter.Create(output, xmlWriterSettings);
		new DataContractSerializer(GetType()).WriteObject(writer, this);
	}

	public virtual async Task Validate(ApplicationType applicationType)
	{
		if (string.IsNullOrEmpty(ApplicationName))
		{
			throw ServiceResultException.Create(2156462080u, "ApplicationName must be specified.");
		}
		if (SecurityConfiguration == null)
		{
			throw ServiceResultException.Create(2156462080u, "SecurityConfiguration must be specified.");
		}
		SecurityConfiguration.Validate();
		await SecurityConfiguration.ApplicationCertificate.LoadPrivateKeyEx(SecurityConfiguration.CertificatePasswordProvider).ConfigureAwait(continueOnCapturedContext: false);
		Func<string> func = delegate
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("urn:");
			stringBuilder.Append(Utils.GetHostName());
			stringBuilder.Append(':');
			stringBuilder.Append(ApplicationName);
			return stringBuilder.ToString();
		};
		if (string.IsNullOrEmpty(ApplicationUri))
		{
			m_applicationUri = func();
		}
		if (applicationType == ApplicationType.Client || applicationType == ApplicationType.ClientAndServer)
		{
			if (ClientConfiguration == null)
			{
				throw ServiceResultException.Create(2156462080u, "ClientConfiguration must be specified.");
			}
			ClientConfiguration.Validate();
		}
		if (applicationType == ApplicationType.Server || applicationType == ApplicationType.ClientAndServer)
		{
			if (ServerConfiguration == null)
			{
				throw ServiceResultException.Create(2156462080u, "ServerConfiguration must be specified.");
			}
			ServerConfiguration.Validate();
		}
		if (applicationType == ApplicationType.DiscoveryServer)
		{
			if (DiscoveryServerConfiguration == null)
			{
				throw ServiceResultException.Create(2156462080u, "DiscoveryServerConfiguration must be specified.");
			}
			DiscoveryServerConfiguration.Validate();
		}
		HiResClock.Disabled = m_disableHiResClock;
		if (HiResClock.Disabled && m_serverConfiguration != null && m_serverConfiguration.PublishingResolution < 50)
		{
			m_serverConfiguration.PublishingResolution = 50;
		}
		await m_certificateValidator.Update(SecurityConfiguration).ConfigureAwait(continueOnCapturedContext: false);
	}

	public ConfiguredEndpointCollection LoadCachedEndpoints(bool createAlways)
	{
		return LoadCachedEndpoints(createAlways, overrideConfiguration: false);
	}

	public ConfiguredEndpointCollection LoadCachedEndpoints(bool createAlways, bool overrideConfiguration)
	{
		if (m_clientConfiguration == null)
		{
			throw new InvalidOperationException("Only valid for client configurations.");
		}
		string text = Utils.GetAbsoluteFilePath(m_clientConfiguration.EndpointCacheFilePath, checkCurrentDirectory: true, throwOnError: false, createAlways: false);
		if (text == null)
		{
			text = m_clientConfiguration.EndpointCacheFilePath;
			if (!Utils.IsPathRooted(text))
			{
				FileInfo fileInfo = new FileInfo(SourceFilePath);
				text = Utils.Format("{0}{1}{2}", fileInfo.DirectoryName, Path.DirectorySeparatorChar, text);
			}
		}
		if (!createAlways)
		{
			return ConfiguredEndpointCollection.Load(this, text, overrideConfiguration);
		}
		ConfiguredEndpointCollection configuredEndpointCollection = new ConfiguredEndpointCollection(this);
		try
		{
			configuredEndpointCollection = ConfiguredEndpointCollection.Load(this, text, overrideConfiguration);
		}
		catch (Exception e)
		{
			Utils.Trace(e, "Could not load configuration from file: {0}", text);
		}
		finally
		{
			string absoluteFilePath = Utils.GetAbsoluteFilePath(m_clientConfiguration.EndpointCacheFilePath, checkCurrentDirectory: true, throwOnError: false, createAlways: true, writable: true);
			if (absoluteFilePath != text)
			{
				configuredEndpointCollection.Save(absoluteFilePath);
			}
		}
		return configuredEndpointCollection;
	}

	public T ParseExtension<T>()
	{
		return ParseExtension<T>(null);
	}

	public T ParseExtension<T>(XmlQualifiedName elementName)
	{
		return Utils.ParseExtension<T>(m_extensions, elementName);
	}

	public void UpdateExtension<T>(XmlQualifiedName elementName, object value)
	{
		Utils.UpdateExtension<T>(ref m_extensions, elementName, value);
	}
}
