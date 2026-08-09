using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Opc.Ua.Configuration;

[ComVisible(true)]
public class ApplicationInstance
{
	private class CertValidationSuppressibleStatusCodes
	{
		public StatusCode[] ApprovedCodes { get; }

		public CertValidationSuppressibleStatusCodes(StatusCode[] approvedCodes)
		{
			ApprovedCodes = approvedCodes;
		}

		public void OnCertificateValidation(object sender, CertificateValidationEventArgs e)
		{
			if (ApprovedCodes.Contains(e.Error.StatusCode))
			{
				Utils.LogWarning("Application Certificate Validation suppressed {0}", e.Error.StatusCode);
				e.Accept = true;
			}
		}
	}

	private string m_applicationName;

	private ApplicationType m_applicationType;

	private string m_configSectionName;

	private Type m_configurationType;

	private ServerBase m_server;

	private ApplicationConfiguration m_applicationConfiguration;

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

	public string ConfigSectionName
	{
		get
		{
			return m_configSectionName;
		}
		set
		{
			m_configSectionName = value;
		}
	}

	public Type ConfigurationType
	{
		get
		{
			return m_configurationType;
		}
		set
		{
			m_configurationType = value;
		}
	}

	public ServerBase Server => m_server;

	public ApplicationConfiguration ApplicationConfiguration
	{
		get
		{
			return m_applicationConfiguration;
		}
		set
		{
			m_applicationConfiguration = value;
		}
	}

	public static IApplicationMessageDlg MessageDlg { get; set; }

	public ICertificatePasswordProvider CertificatePasswordProvider { get; set; }

	public bool DisableCertificateAutoCreation { get; set; }

	public ApplicationInstance()
	{
		DisableCertificateAutoCreation = false;
	}

	public ApplicationInstance(ApplicationConfiguration applicationConfiguration)
		: this()
	{
		m_applicationConfiguration = applicationConfiguration;
	}

	public bool ProcessCommandLine()
	{
		return false;
	}

	public void StartAsService(ServerBase server)
	{
		throw new NotImplementedException(".NetStandard Opc.Ua libraries do not support to start as a windows service");
	}

	public async Task Start(ServerBase server)
	{
		m_server = server;
		if (m_applicationConfiguration == null)
		{
			await LoadApplicationConfiguration(silent: false).ConfigureAwait(continueOnCapturedContext: false);
		}
		server.Start(m_applicationConfiguration);
	}

	public void Stop()
	{
		m_server.Stop();
	}

	public async Task<ApplicationConfiguration> LoadAppConfig(bool silent, string filePath, ApplicationType applicationType, Type configurationType, bool applyTraceSettings, ICertificatePasswordProvider certificatePasswordProvider = null)
	{
		Utils.LogInfo("Loading application configuration file. {0}", filePath);
		try
		{
			ApplicationConfiguration applicationConfiguration = await ApplicationConfiguration.Load(new FileInfo(filePath), applicationType, configurationType, applyTraceSettings, certificatePasswordProvider).ConfigureAwait(continueOnCapturedContext: false);
			if (applicationConfiguration == null)
			{
				return null;
			}
			return applicationConfiguration;
		}
		catch (Exception ex)
		{
			Utils.LogError(ex, "Could not load configuration file. {0}", filePath);
			if (!silent)
			{
				if (MessageDlg != null)
				{
					MessageDlg.Message("Load Application Configuration: " + ex.Message);
					await MessageDlg.ShowAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
				throw;
			}
			return null;
		}
	}

	public async Task<ApplicationConfiguration> LoadAppConfig(bool silent, Stream stream, ApplicationType applicationType, Type configurationType, bool applyTraceSettings, ICertificatePasswordProvider certificatePasswordProvider = null)
	{
		Utils.LogInfo("Loading application from stream.");
		try
		{
			ApplicationConfiguration applicationConfiguration = await ApplicationConfiguration.Load(stream, applicationType, configurationType, applyTraceSettings, certificatePasswordProvider).ConfigureAwait(continueOnCapturedContext: false);
			if (applicationConfiguration == null)
			{
				return null;
			}
			return applicationConfiguration;
		}
		catch (Exception ex)
		{
			Utils.LogError(ex, "Could not load configuration from stream.");
			if (!silent)
			{
				if (MessageDlg != null)
				{
					MessageDlg.Message("Load Application Configuration: " + ex.Message);
					await MessageDlg.ShowAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
				throw;
			}
			return null;
		}
	}

	public async Task<ApplicationConfiguration> LoadApplicationConfiguration(Stream stream, bool silent)
	{
		ApplicationConfiguration configuration = null;
		try
		{
			configuration = await LoadAppConfig(silent, stream, ApplicationType, ConfigurationType, applyTraceSettings: true, CertificatePasswordProvider).ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (Exception) when (silent)
		{
		}
		if (configuration == null)
		{
			throw ServiceResultException.Create(2156462080u, "Could not load configuration.");
		}
		m_applicationConfiguration = FixupAppConfig(configuration);
		return configuration;
	}

	public async Task<ApplicationConfiguration> LoadApplicationConfiguration(string filePath, bool silent)
	{
		ApplicationConfiguration configuration = null;
		try
		{
			configuration = await LoadAppConfig(silent, filePath, ApplicationType, ConfigurationType, applyTraceSettings: true, CertificatePasswordProvider).ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (Exception) when (silent)
		{
		}
		if (configuration == null)
		{
			throw ServiceResultException.Create(2156462080u, "Could not load configuration file.");
		}
		m_applicationConfiguration = FixupAppConfig(configuration);
		return configuration;
	}

	public async Task<ApplicationConfiguration> LoadApplicationConfiguration(bool silent)
	{
		string filePathFromAppConfig = ApplicationConfiguration.GetFilePathFromAppConfig(ConfigSectionName);
		return await LoadApplicationConfiguration(filePathFromAppConfig, silent).ConfigureAwait(continueOnCapturedContext: false);
	}

	public static ApplicationConfiguration FixupAppConfig(ApplicationConfiguration configuration)
	{
		configuration.ApplicationUri = Utils.ReplaceLocalhost(configuration.ApplicationUri);
		if (configuration.ServerConfiguration != null)
		{
			for (int i = 0; i < configuration.ServerConfiguration.BaseAddresses.Count; i++)
			{
				configuration.ServerConfiguration.BaseAddresses[i] = Utils.ReplaceLocalhost(configuration.ServerConfiguration.BaseAddresses[i]);
			}
		}
		return configuration;
	}

	public IApplicationConfigurationBuilderTypes Build(string applicationUri, string productUri)
	{
		ApplicationConfiguration = new ApplicationConfiguration
		{
			ApplicationName = ApplicationName,
			ApplicationType = ApplicationType,
			ApplicationUri = applicationUri,
			ProductUri = productUri,
			TraceConfiguration = new TraceConfiguration
			{
				TraceMasks = 0
			},
			TransportQuotas = new TransportQuotas()
		};
		ApplicationConfiguration.TraceConfiguration.ApplySettings();
		return new ApplicationConfigurationBuilder(this);
	}

	public Task<bool> CheckApplicationInstanceCertificate(bool silent, ushort minimumKeySize)
	{
		return CheckApplicationInstanceCertificate(silent, minimumKeySize, CertificateFactory.DefaultLifeTime);
	}

	public async Task DeleteApplicationInstanceCertificate(CancellationToken ct = default(CancellationToken))
	{
		if (m_applicationConfiguration == null)
		{
			throw new ArgumentException("Missing configuration.");
		}
		await DeleteApplicationInstanceCertificateAsync(m_applicationConfiguration, ct).ConfigureAwait(continueOnCapturedContext: false);
	}

	public async Task<bool> CheckApplicationInstanceCertificate(bool silent, ushort minimumKeySize, ushort lifeTimeInMonths, CancellationToken ct = default(CancellationToken))
	{
		Utils.LogInfo("Checking application instance certificate.");
		if (m_applicationConfiguration == null)
		{
			await LoadApplicationConfiguration(silent).ConfigureAwait(continueOnCapturedContext: false);
		}
		ApplicationConfiguration configuration = m_applicationConfiguration;
		CertificateIdentifier id = configuration.SecurityConfiguration.ApplicationCertificate;
		if (id == null)
		{
			throw ServiceResultException.Create(2156462080u, "Configuration file does not specify a certificate.");
		}
		ICertificatePasswordProvider certificatePasswordProvider = configuration.SecurityConfiguration.CertificatePasswordProvider;
		await configuration.SecurityConfiguration.ApplicationCertificate.LoadPrivateKeyEx(certificatePasswordProvider).ConfigureAwait(continueOnCapturedContext: false);
		X509Certificate2 certificate = await id.Find(needPrivateKey: true).ConfigureAwait(continueOnCapturedContext: false);
		if (certificate != null)
		{
			Utils.LogCertificate("Check certificate:", certificate);
			if (!(await CheckApplicationInstanceCertificateAsync(configuration, certificate, silent, minimumKeySize, ct).ConfigureAwait(continueOnCapturedContext: false)))
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine("The certificate with subject {0} in the configuration is invalid.");
				stringBuilder.AppendLine(" Please update or delete the certificate from this location:");
				stringBuilder.AppendLine(" {1}");
				throw ServiceResultException.Create(2156462080u, stringBuilder.ToString(), id.SubjectName, Utils.ReplaceSpecialFolderNames(id.StorePath));
			}
		}
		else
		{
			certificate = await id.Find(needPrivateKey: false).ConfigureAwait(continueOnCapturedContext: false);
			if (certificate != null)
			{
				throw ServiceResultException.Create(2156462080u, "Cannot access certificate private key. Subject={0}", certificate.Subject);
			}
			if (!string.IsNullOrEmpty(id.Thumbprint))
			{
				if (!string.IsNullOrEmpty(id.SubjectName))
				{
					certificate = await new CertificateIdentifier
					{
						StoreType = id.StoreType,
						StorePath = id.StorePath,
						SubjectName = id.SubjectName
					}.Find(needPrivateKey: true).ConfigureAwait(continueOnCapturedContext: false);
				}
				if (certificate == null)
				{
					StringBuilder stringBuilder2 = new StringBuilder();
					stringBuilder2.AppendLine("Thumbprint was explicitly specified in the configuration.");
					stringBuilder2.AppendLine("Cannot generate a new certificate.");
					throw ServiceResultException.Create(2156462080u, stringBuilder2.ToString());
				}
				StringBuilder message = new StringBuilder();
				message.AppendLine("Thumbprint was explicitly specified in the configuration.");
				message.AppendLine("Another certificate with the same subject name was found.");
				message.AppendLine("Use it instead?");
				message.AppendLine("Requested: {0}");
				message.AppendLine("Found: {1}");
				if (!(await ApproveMessageAsync(string.Format(message.ToString(), id.SubjectName, certificate.Subject), silent).ConfigureAwait(continueOnCapturedContext: false)))
				{
					throw ServiceResultException.Create(2156462080u, message.ToString(), id.SubjectName, certificate.Subject);
				}
			}
		}
		if (certificate == null)
		{
			if (!DisableCertificateAutoCreation)
			{
				certificate = await CreateApplicationInstanceCertificateAsync(configuration, minimumKeySize, lifeTimeInMonths, ct).ConfigureAwait(continueOnCapturedContext: false);
			}
			else
			{
				Utils.LogWarning("Application Instance certificate auto creation is disabled.");
			}
			if (certificate == null)
			{
				StringBuilder stringBuilder3 = new StringBuilder();
				stringBuilder3.AppendLine("There is no cert with subject {0} in the configuration.");
				stringBuilder3.AppendLine(" Please generate a cert for your application,");
				stringBuilder3.AppendLine(" then copy the new cert to this location:");
				stringBuilder3.AppendLine(" {1}");
				throw ServiceResultException.Create(2156462080u, stringBuilder3.ToString(), id.SubjectName, id.StorePath);
			}
		}
		else if (configuration.SecurityConfiguration.AddAppCertToTrustedStore)
		{
			await AddToTrustedStoreAsync(configuration, certificate, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
		return true;
	}

	public async Task AddOwnCertificateToTrustedStoreAsync(X509Certificate2 certificate, CancellationToken ct)
	{
		await AddToTrustedStoreAsync(m_applicationConfiguration, certificate, ct).ConfigureAwait(continueOnCapturedContext: false);
	}

	private async Task<bool> CheckApplicationInstanceCertificateAsync(ApplicationConfiguration configuration, X509Certificate2 certificate, bool silent, ushort minimumKeySize, CancellationToken ct)
	{
		if (certificate == null)
		{
			return false;
		}
		CertValidationSuppressibleStatusCodes certValidator = new CertValidationSuppressibleStatusCodes(new StatusCode[6] { 2149187584u, 2148794368u, 2148859904u, 2148925440u, 2149253120u, 2149318656u });
		Utils.LogCertificate("Check application instance certificate.", certificate);
		try
		{
			configuration.CertificateValidator.CertificateValidation += certValidator.OnCertificateValidation;
			await configuration.CertificateValidator.ValidateAsync(certificate.HasPrivateKey ? new X509Certificate2(certificate.RawData) : certificate, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (Exception ex)
		{
			if (!(await ApproveMessageAsync(Utils.Format("Error validating certificate. Exception: {0}. Use certificate anyway?", ex.Message), silent).ConfigureAwait(continueOnCapturedContext: false)))
			{
				return false;
			}
		}
		finally
		{
			configuration.CertificateValidator.CertificateValidation -= certValidator.OnCertificateValidation;
		}
		int rSAPublicKeySize = X509Utils.GetRSAPublicKeySize(certificate);
		if (minimumKeySize > rSAPublicKeySize && !(await ApproveMessageAsync(Utils.Format("The key size ({0}) in the certificate is less than the minimum allowed ({1}). Use certificate anyway?", rSAPublicKeySize, minimumKeySize), silent).ConfigureAwait(continueOnCapturedContext: false)))
		{
			return false;
		}
		if (configuration.ApplicationType != ApplicationType.Client && !(await CheckDomainsInCertificateAsync(configuration, certificate, silent, ct).ConfigureAwait(continueOnCapturedContext: false)))
		{
			return false;
		}
		string applicationUri = X509Utils.GetApplicationUriFromCertificate(certificate);
		if (string.IsNullOrEmpty(applicationUri))
		{
			if (!(await ApproveMessageAsync("The Application URI could not be read from the certificate. Use certificate anyway?", silent).ConfigureAwait(continueOnCapturedContext: false)))
			{
				return false;
			}
		}
		else if (!configuration.ApplicationUri.Equals(applicationUri, StringComparison.Ordinal))
		{
			Utils.LogInfo("Updated the ApplicationUri: {0} --> {1}", configuration.ApplicationUri, applicationUri);
			configuration.ApplicationUri = applicationUri;
		}
		Utils.LogInfo("Using the ApplicationUri: {0}", applicationUri);
		configuration.SecurityConfiguration.ApplicationCertificate.Certificate = certificate;
		return true;
	}

	private static async Task<bool> CheckDomainsInCertificateAsync(ApplicationConfiguration configuration, X509Certificate2 certificate, bool silent, CancellationToken ct)
	{
		Utils.LogInfo("Check domains in certificate.");
		bool valid = true;
		IList<string> serverDomainNames = configuration.GetServerDomainNames();
		IList<string> certificateDomainNames = X509Utils.GetDomainsFromCertficate(certificate);
		Utils.LogInfo("Server Domain names:");
		foreach (string item in serverDomainNames)
		{
			Utils.LogInfo(" {0}", item);
		}
		Utils.LogInfo("Certificate Domain names:");
		foreach (string item2 in certificateDomainNames)
		{
			Utils.LogInfo(" {0}", item2);
		}
		string computerName = Utils.GetHostName();
		IPAddress[] addresses = null;
		for (int ii = 0; ii < serverDomainNames.Count; ii++)
		{
			if (Utils.FindStringIgnoreCase(certificateDomainNames, serverDomainNames[ii]))
			{
				continue;
			}
			if (string.Equals(serverDomainNames[ii], "localhost", StringComparison.OrdinalIgnoreCase))
			{
				if (Utils.FindStringIgnoreCase(certificateDomainNames, computerName))
				{
					continue;
				}
				bool found = false;
				if (addresses == null)
				{
					addresses = await Utils.GetHostAddressesAsync(computerName).ConfigureAwait(continueOnCapturedContext: false);
				}
				for (int i = 0; i < addresses.Length; i++)
				{
					if (Utils.FindStringIgnoreCase(certificateDomainNames, addresses[i].ToString()))
					{
						found = true;
						break;
					}
				}
				if (found)
				{
					continue;
				}
			}
			string message = Utils.Format("The server is configured to use domain '{0}' which does not appear in the certificate. Use certificate anyway?", serverDomainNames[ii]);
			valid = false;
			if (!(await ApproveMessageAsync(message, silent).ConfigureAwait(continueOnCapturedContext: false)))
			{
				break;
			}
			valid = true;
		}
		return valid;
	}

	private static async Task<X509Certificate2> CreateApplicationInstanceCertificateAsync(ApplicationConfiguration configuration, ushort keySize, ushort lifeTimeInMonths, CancellationToken ct)
	{
		await DeleteApplicationInstanceCertificateAsync(configuration, ct).ConfigureAwait(continueOnCapturedContext: false);
		Utils.LogInfo("Creating application instance certificate.");
		CertificateIdentifier id = configuration.SecurityConfiguration.ApplicationCertificate;
		IList<string> serverDomainNames = configuration.GetServerDomainNames();
		if (serverDomainNames.Count == 0)
		{
			serverDomainNames.Add(Utils.GetHostName());
		}
		if (id.StoreType == "Directory")
		{
			Utils.GetAbsoluteDirectoryPath(id.StorePath, checkCurrentDirectory: true, throwOnError: true, createAlways: true);
		}
		ICertificatePasswordProvider passwordProvider = configuration.SecurityConfiguration.CertificatePasswordProvider;
		X509Certificate2 certificate = (id.Certificate = CertificateFactory.CreateCertificate(configuration.ApplicationUri, configuration.ApplicationName, id.SubjectName, serverDomainNames).SetLifeTime(lifeTimeInMonths).SetRSAKeySize(keySize)
			.CreateForRSA());
		await certificate.AddToStoreAsync(id.StoreType, id.StorePath, passwordProvider?.GetPassword(id), ct).ConfigureAwait(continueOnCapturedContext: false);
		if (configuration.SecurityConfiguration.AddAppCertToTrustedStore)
		{
			await AddToTrustedStoreAsync(configuration, certificate, ct).ConfigureAwait(continueOnCapturedContext: false);
		}
		CertificateIdentifier certificateIdentifier = id;
		certificateIdentifier.Certificate = await configuration.SecurityConfiguration.ApplicationCertificate.LoadPrivateKeyEx(passwordProvider).ConfigureAwait(continueOnCapturedContext: false);
		await configuration.CertificateValidator.Update(configuration.SecurityConfiguration).ConfigureAwait(continueOnCapturedContext: false);
		Utils.LogCertificate("Certificate created for {0}.", certificate, configuration.ApplicationUri);
		return id.Certificate;
	}

	private static async Task DeleteApplicationInstanceCertificateAsync(ApplicationConfiguration configuration, CancellationToken ct)
	{
		CertificateIdentifier id = configuration.SecurityConfiguration.ApplicationCertificate;
		if (id == null)
		{
			return;
		}
		X509Certificate2 certificate = await id.Find().ConfigureAwait(continueOnCapturedContext: false);
		if (certificate != null)
		{
			Utils.LogCertificate(512, "Deleting application instance certificate and private key.", certificate);
		}
		if (configuration.SecurityConfiguration != null && configuration.SecurityConfiguration.TrustedPeerCertificates != null)
		{
			string thumbprint = id.Thumbprint;
			if (certificate != null)
			{
				thumbprint = certificate.Thumbprint;
			}
			if (!string.IsNullOrEmpty(thumbprint))
			{
				using ICertificateStore store = configuration.SecurityConfiguration.TrustedPeerCertificates.OpenStore();
				if (await store.Delete(thumbprint).ConfigureAwait(continueOnCapturedContext: false))
				{
					Utils.LogInfo(512, "Application Instance Certificate [{0}] deleted from trusted store.", thumbprint);
				}
			}
		}
		if (certificate != null)
		{
			using ICertificateStore store = id.OpenStore();
			if (await store.Delete(certificate.Thumbprint).ConfigureAwait(continueOnCapturedContext: false))
			{
				Utils.LogCertificate(512, "Application certificate and private key deleted.", certificate);
			}
		}
		id.Certificate = null;
	}

	private static async Task AddToTrustedStoreAsync(ApplicationConfiguration configuration, X509Certificate2 certificate, CancellationToken ct)
	{
		if (certificate == null)
		{
			throw new ArgumentNullException("certificate");
		}
		string value = null;
		if (configuration != null && configuration.SecurityConfiguration != null && configuration.SecurityConfiguration.TrustedPeerCertificates != null)
		{
			value = configuration.SecurityConfiguration.TrustedPeerCertificates.StorePath;
		}
		if (string.IsNullOrEmpty(value))
		{
			Utils.LogWarning("WARNING: Trusted peer store not specified.");
			return;
		}
		try
		{
			ICertificateStore store = configuration.SecurityConfiguration.TrustedPeerCertificates.OpenStore();
			if (store == null)
			{
				Utils.LogWarning("Could not open trusted peer store.");
				return;
			}
			try
			{
				if ((await store.FindByThumbprint(certificate.Thumbprint).ConfigureAwait(continueOnCapturedContext: false)).Count > 0)
				{
					return;
				}
				Utils.LogCertificate("Adding application certificate to trusted peer store.", certificate);
				List<string> subjectName = X509Utils.ParseDistinguishedName(certificate.Subject);
				X509Certificate2Collection x509Certificate2Collection = await store.Enumerate().ConfigureAwait(continueOnCapturedContext: false);
				for (int i = 0; i < x509Certificate2Collection.Count; i++)
				{
					if (X509Utils.CompareDistinguishedName(x509Certificate2Collection[i], subjectName))
					{
						if (x509Certificate2Collection[i].Thumbprint == certificate.Thumbprint)
						{
							return;
						}
						Utils.LogCertificate("Delete Certificate from trusted store.", certificate);
						await store.Delete(x509Certificate2Collection[i].Thumbprint).ConfigureAwait(continueOnCapturedContext: false);
						break;
					}
				}
				X509Certificate2 certificate2 = new X509Certificate2(certificate.RawData);
				await store.Add(certificate2).ConfigureAwait(continueOnCapturedContext: false);
				Utils.LogInfo("Added application certificate to trusted peer store.");
			}
			finally
			{
				store.Close();
			}
		}
		catch (Exception exception)
		{
			Utils.LogError(exception, "Could not add certificate to trusted peer store.");
		}
	}

	private static async Task<bool> ApproveMessageAsync(string message, bool silent)
	{
		if (!silent && MessageDlg != null)
		{
			MessageDlg.Message(message, ask: true);
			return await MessageDlg.ShowAsync().ConfigureAwait(continueOnCapturedContext: false);
		}
		Utils.LogError(message);
		return false;
	}
}
