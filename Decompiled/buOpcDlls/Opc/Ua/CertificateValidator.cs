using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Opc.Ua.Security.Certificates;

namespace Opc.Ua;

[ComVisible(true)]
public class CertificateValidator : ICertificateValidator
{
	[Flags]
	private enum ProtectFlags
	{
		AutoAcceptUntrustedCertificates = 1,
		RejectSHA1SignedCertificates = 2,
		RejectUnknownRevocationStatus = 4,
		MinimumCertificateKeySize = 8,
		UseValidatedCertificates = 0x10
	}

	private static readonly ReadOnlyList<StatusCode> m_suppressibleStatusCodes = new ReadOnlyList<StatusCode>(new List<StatusCode> { 2148925440u, 2149318656u, 2165112832u, 2148859904u, 2149122048u, 2149253120u, 2148794368u, 2165571584u, 2149056512u, 2149187584u });

	private readonly SemaphoreSlim m_semaphore = new SemaphoreSlim(1, 1);

	private readonly object m_callbackLock = new object();

	private readonly Dictionary<string, X509Certificate2> m_validatedCertificates;

	private CertificateStoreIdentifier m_trustedCertificateStore;

	private CertificateIdentifierCollection m_trustedCertificateList;

	private CertificateStoreIdentifier m_issuerCertificateStore;

	private CertificateIdentifierCollection m_issuerCertificateList;

	private CertificateStoreIdentifier m_rejectedCertificateStore;

	private X509Certificate2 m_applicationCertificate;

	private ProtectFlags m_protectFlags;

	private bool m_autoAcceptUntrustedCertificates;

	private bool m_rejectSHA1SignedCertificates;

	private bool m_rejectUnknownRevocationStatus;

	private ushort m_minimumCertificateKeySize;

	private bool m_useValidatedCertificates;

	public bool AutoAcceptUntrustedCertificates
	{
		get
		{
			return m_autoAcceptUntrustedCertificates;
		}
		set
		{
			try
			{
				m_semaphore.Wait();
				m_protectFlags |= ProtectFlags.AutoAcceptUntrustedCertificates;
				if (m_autoAcceptUntrustedCertificates != value)
				{
					m_autoAcceptUntrustedCertificates = value;
					InternalResetValidatedCertificates();
				}
			}
			finally
			{
				m_semaphore.Release();
			}
		}
	}

	public bool RejectSHA1SignedCertificates
	{
		get
		{
			return m_rejectSHA1SignedCertificates;
		}
		set
		{
			try
			{
				m_semaphore.Wait();
				m_protectFlags |= ProtectFlags.RejectSHA1SignedCertificates;
				if (m_rejectSHA1SignedCertificates != value)
				{
					m_rejectSHA1SignedCertificates = value;
					InternalResetValidatedCertificates();
				}
			}
			finally
			{
				m_semaphore.Release();
			}
		}
	}

	public bool RejectUnknownRevocationStatus
	{
		get
		{
			return m_rejectUnknownRevocationStatus;
		}
		set
		{
			try
			{
				m_semaphore.Wait();
				m_protectFlags |= ProtectFlags.RejectUnknownRevocationStatus;
				if (m_rejectUnknownRevocationStatus != value)
				{
					m_rejectUnknownRevocationStatus = value;
					InternalResetValidatedCertificates();
				}
			}
			finally
			{
				m_semaphore.Release();
			}
		}
	}

	public ushort MinimumCertificateKeySize
	{
		get
		{
			return m_minimumCertificateKeySize;
		}
		set
		{
			try
			{
				m_semaphore.Wait();
				m_protectFlags |= ProtectFlags.MinimumCertificateKeySize;
				if (m_minimumCertificateKeySize != value)
				{
					m_minimumCertificateKeySize = value;
					ResetValidatedCertificates();
				}
			}
			finally
			{
				m_semaphore.Release();
			}
		}
	}

	public bool UseValidatedCertificates
	{
		get
		{
			return m_useValidatedCertificates;
		}
		set
		{
			try
			{
				m_semaphore.Wait();
				m_protectFlags |= ProtectFlags.UseValidatedCertificates;
				if (m_useValidatedCertificates != value)
				{
					m_useValidatedCertificates = value;
					ResetValidatedCertificates();
				}
			}
			finally
			{
				m_semaphore.Release();
			}
		}
	}

	public event CertificateValidationEventHandler CertificateValidation
	{
		add
		{
			lock (m_callbackLock)
			{
				m_CertificateValidation += value;
			}
		}
		remove
		{
			lock (m_callbackLock)
			{
				m_CertificateValidation -= value;
			}
		}
	}

	public event CertificateUpdateEventHandler CertificateUpdate
	{
		add
		{
			lock (m_callbackLock)
			{
				m_CertificateUpdate += value;
			}
		}
		remove
		{
			lock (m_callbackLock)
			{
				m_CertificateUpdate -= value;
			}
		}
	}

	private event CertificateValidationEventHandler m_CertificateValidation;

	private event CertificateUpdateEventHandler m_CertificateUpdate;

	public CertificateValidator()
	{
		m_validatedCertificates = new Dictionary<string, X509Certificate2>();
		m_protectFlags = (ProtectFlags)0;
		m_autoAcceptUntrustedCertificates = false;
		m_rejectSHA1SignedCertificates = CertificateFactory.DefaultHashSize >= 256;
		m_rejectUnknownRevocationStatus = false;
		m_minimumCertificateKeySize = CertificateFactory.DefaultKeySize;
		m_useValidatedCertificates = false;
	}

	public virtual async Task Update(ApplicationConfiguration configuration)
	{
		if (configuration == null)
		{
			throw new ArgumentNullException("configuration");
		}
		await Update(configuration.SecurityConfiguration).ConfigureAwait(continueOnCapturedContext: false);
	}

	public virtual void Update(CertificateTrustList issuerStore, CertificateTrustList trustedStore, CertificateStoreIdentifier rejectedCertificateStore)
	{
		try
		{
			m_semaphore.Wait();
			InternalUpdate(issuerStore, trustedStore, rejectedCertificateStore);
		}
		finally
		{
			m_semaphore.Release();
		}
	}

	private void InternalUpdate(CertificateTrustList issuerStore, CertificateTrustList trustedStore, CertificateStoreIdentifier rejectedCertificateStore)
	{
		InternalResetValidatedCertificates();
		m_trustedCertificateStore = null;
		m_trustedCertificateList = null;
		if (trustedStore != null)
		{
			m_trustedCertificateStore = new CertificateStoreIdentifier();
			m_trustedCertificateStore.StoreType = trustedStore.StoreType;
			m_trustedCertificateStore.StorePath = trustedStore.StorePath;
			m_trustedCertificateStore.ValidationOptions = trustedStore.ValidationOptions;
			if (trustedStore.TrustedCertificates != null)
			{
				m_trustedCertificateList = new CertificateIdentifierCollection();
				m_trustedCertificateList.AddRange(trustedStore.TrustedCertificates);
			}
		}
		m_issuerCertificateStore = null;
		m_issuerCertificateList = null;
		if (issuerStore != null)
		{
			m_issuerCertificateStore = new CertificateStoreIdentifier();
			m_issuerCertificateStore.StoreType = issuerStore.StoreType;
			m_issuerCertificateStore.StorePath = issuerStore.StorePath;
			m_issuerCertificateStore.ValidationOptions = issuerStore.ValidationOptions;
			if (issuerStore.TrustedCertificates != null)
			{
				m_issuerCertificateList = new CertificateIdentifierCollection();
				m_issuerCertificateList.AddRange(issuerStore.TrustedCertificates);
			}
		}
		m_rejectedCertificateStore = null;
		if (rejectedCertificateStore != null)
		{
			m_rejectedCertificateStore = (CertificateStoreIdentifier)rejectedCertificateStore.MemberwiseClone();
		}
	}

	public virtual async Task Update(SecurityConfiguration configuration)
	{
		if (configuration == null)
		{
			throw new ArgumentNullException("configuration");
		}
		try
		{
			await m_semaphore.WaitAsync().ConfigureAwait(continueOnCapturedContext: false);
			InternalUpdate(configuration.TrustedIssuerCertificates, configuration.TrustedPeerCertificates, configuration.RejectedCertificateStore);
			if ((m_protectFlags & ProtectFlags.AutoAcceptUntrustedCertificates) == 0)
			{
				m_autoAcceptUntrustedCertificates = configuration.AutoAcceptUntrustedCertificates;
			}
			if ((m_protectFlags & ProtectFlags.RejectSHA1SignedCertificates) == 0)
			{
				m_rejectSHA1SignedCertificates = configuration.RejectSHA1SignedCertificates;
			}
			if ((m_protectFlags & ProtectFlags.RejectUnknownRevocationStatus) == 0)
			{
				m_rejectUnknownRevocationStatus = configuration.RejectUnknownRevocationStatus;
			}
			if ((m_protectFlags & ProtectFlags.MinimumCertificateKeySize) == 0)
			{
				m_minimumCertificateKeySize = configuration.MinimumCertificateKeySize;
			}
			if ((m_protectFlags & ProtectFlags.UseValidatedCertificates) == 0)
			{
				m_useValidatedCertificates = configuration.UseValidatedCertificates;
			}
		}
		finally
		{
			m_semaphore.Release();
		}
		if (configuration.ApplicationCertificate != null)
		{
			m_applicationCertificate = await configuration.ApplicationCertificate.Find(needPrivateKey: true).ConfigureAwait(continueOnCapturedContext: false);
		}
	}

	public virtual async Task UpdateCertificate(SecurityConfiguration securityConfiguration)
	{
		try
		{
			await m_semaphore.WaitAsync().ConfigureAwait(continueOnCapturedContext: false);
			securityConfiguration.ApplicationCertificate.Certificate = null;
			await securityConfiguration.ApplicationCertificate.LoadPrivateKeyEx(securityConfiguration.CertificatePasswordProvider).ConfigureAwait(continueOnCapturedContext: false);
		}
		finally
		{
			m_semaphore.Release();
		}
		await Update(securityConfiguration).ConfigureAwait(continueOnCapturedContext: false);
		lock (m_callbackLock)
		{
			if (this.m_CertificateUpdate != null)
			{
				CertificateUpdateEventArgs e = new CertificateUpdateEventArgs(securityConfiguration, GetChannelValidator());
				this.m_CertificateUpdate(this, e);
			}
		}
	}

	public void ResetValidatedCertificates()
	{
		try
		{
			m_semaphore.Wait();
			InternalResetValidatedCertificates();
		}
		finally
		{
			m_semaphore.Release();
		}
	}

	private void InternalResetValidatedCertificates()
	{
		foreach (X509Certificate2 value in m_validatedCertificates.Values)
		{
			Utils.SilentDispose(value);
		}
		m_validatedCertificates.Clear();
	}

	public void Validate(X509Certificate2 certificate)
	{
		Validate(new X509Certificate2Collection { certificate });
	}

	public virtual void Validate(X509Certificate2Collection certificateChain)
	{
		Validate(certificateChain, null);
	}

	public Task ValidateAsync(X509Certificate2 certificate, CancellationToken ct)
	{
		return ValidateAsync(new X509Certificate2Collection { certificate }, ct);
	}

	public virtual Task ValidateAsync(X509Certificate2Collection chain, CancellationToken ct)
	{
		return ValidateAsync(chain, null, ct);
	}

	public virtual async Task ValidateAsync(X509Certificate2Collection chain, ConfiguredEndpoint endpoint, CancellationToken ct)
	{
		X509Certificate2 certificate = chain[0];
		try
		{
			await m_semaphore.WaitAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
			try
			{
				await InternalValidateAsync(chain, endpoint, ct).ConfigureAwait(continueOnCapturedContext: false);
				m_validatedCertificates[certificate.Thumbprint] = new X509Certificate2(certificate.RawData);
				return;
			}
			finally
			{
				m_semaphore.Release();
			}
		}
		catch (ServiceResultException se)
		{
			HandleCertificateValidationException(se, certificate, chain);
		}
		await m_semaphore.WaitAsync(ct).ConfigureAwait(continueOnCapturedContext: false);
		try
		{
			Utils.LogCertificate(LogLevel.Warning, "Validation errors suppressed: ", certificate);
			m_validatedCertificates[certificate.Thumbprint] = new X509Certificate2(certificate.RawData);
		}
		finally
		{
			m_semaphore.Release();
		}
	}

	public virtual void Validate(X509Certificate2Collection chain, ConfiguredEndpoint endpoint)
	{
		X509Certificate2 x509Certificate = chain[0];
		try
		{
			try
			{
				m_semaphore.Wait();
				InternalValidateAsync(chain, endpoint).GetAwaiter().GetResult();
				m_validatedCertificates[x509Certificate.Thumbprint] = new X509Certificate2(x509Certificate.RawData);
				return;
			}
			finally
			{
				m_semaphore.Release();
			}
		}
		catch (ServiceResultException se)
		{
			HandleCertificateValidationException(se, x509Certificate, chain);
		}
		try
		{
			m_semaphore.Wait();
			Utils.LogCertificate(LogLevel.Warning, "Validation errors suppressed: ", x509Certificate);
			m_validatedCertificates[x509Certificate.Thumbprint] = new X509Certificate2(x509Certificate.RawData);
		}
		finally
		{
			m_semaphore.Release();
		}
	}

	private void HandleCertificateValidationException(ServiceResultException se, X509Certificate2 certificate, X509Certificate2Collection chain)
	{
		if (ContainsUnsuppressibleSC(se.Result))
		{
			Utils.LogCertificate(LogLevel.Error, "Certificate rejected. Reason={0}.", certificate, se.Result.StatusCode);
			SaveCertificates(chain);
			LogInnerServiceResults(LogLevel.Error, se.Result.InnerResult);
			throw new ServiceResultException(se, 2148663296u);
		}
		Utils.LogCertificate(LogLevel.Warning, "Certificate Validation failed. Reason={0}.", certificate, se.Result.StatusCode);
		LogInnerServiceResults(LogLevel.Warning, se.Result.InnerResult);
		bool flag = false;
		string text = string.Empty;
		ServiceResult serviceResult = se.Result;
		lock (m_callbackLock)
		{
			do
			{
				flag = false;
				if (this.m_CertificateValidation != null)
				{
					CertificateValidationEventArgs e = new CertificateValidationEventArgs(serviceResult, certificate);
					this.m_CertificateValidation(this, e);
					if (e.AcceptAll)
					{
						flag = true;
						serviceResult = null;
						break;
					}
					text = e.ApplicationErrorMsg;
					flag = e.Accept;
				}
				else if (m_autoAcceptUntrustedCertificates && serviceResult.StatusCode == 2149187584u)
				{
					flag = true;
					Utils.LogCertificate("Auto accepted certificate: ", certificate);
				}
				if (!flag)
				{
					se = ((!string.IsNullOrEmpty(text)) ? new ServiceResultException(text) : new ServiceResultException(serviceResult));
				}
				else
				{
					serviceResult = serviceResult.InnerResult;
				}
			}
			while (flag && serviceResult != null);
		}
		if (!flag)
		{
			Utils.LogCertificate(LogLevel.Error, "Certificate rejected. Reason={0}.", certificate, (serviceResult != null) ? serviceResult.StatusCode.ToString() : "Unknown Error");
			SaveCertificates(chain);
			throw new ServiceResultException(se, 2148663296u);
		}
	}

	private static bool ContainsUnsuppressibleSC(ServiceResult sr)
	{
		while (sr != null)
		{
			if (!m_suppressibleStatusCodes.Contains(sr.StatusCode))
			{
				return true;
			}
			sr = sr.InnerResult;
		}
		return false;
	}

	private static void LogInnerServiceResults(LogLevel logLevel, ServiceResult result)
	{
		while (result != null)
		{
			Utils.Log(logLevel, 512, " -- {0}", result.ToString());
			result = result.InnerResult;
		}
	}

	private void SaveCertificate(X509Certificate2 certificate)
	{
		SaveCertificates(new X509Certificate2Collection { certificate });
	}

	private void SaveCertificates(X509Certificate2Collection certificateChain)
	{
		try
		{
			m_semaphore.Wait();
			if (m_rejectedCertificateStore == null)
			{
				return;
			}
			Utils.LogTrace("Writing rejected certificate chain to: {0}", m_rejectedCertificateStore);
			try
			{
				ICertificateStore certificateStore = m_rejectedCertificateStore.OpenStore();
				try
				{
					bool flag = true;
					X509Certificate2Enumerator enumerator = certificateChain.GetEnumerator();
					while (enumerator.MoveNext())
					{
						X509Certificate2 current = enumerator.Current;
						try
						{
							certificateStore.Add(current).GetAwaiter().GetResult();
							if (!flag)
							{
								Utils.LogCertificate("Saved issuer certificate: ", current);
							}
							flag = false;
						}
						catch (ArgumentException ex)
						{
							Utils.LogCertificate(ex.Message, current);
						}
					}
				}
				finally
				{
					certificateStore.Close();
				}
			}
			catch (Exception exception)
			{
				Utils.LogError(exception, "Could not write certificate to directory: {0}", m_rejectedCertificateStore);
			}
		}
		finally
		{
			m_semaphore.Release();
		}
	}

	private async Task<CertificateIdentifier> GetTrustedCertificateAsync(X509Certificate2 certificate)
	{
		if (m_trustedCertificateList != null)
		{
			for (int ii = 0; ii < m_trustedCertificateList.Count; ii++)
			{
				X509Certificate2 x509Certificate = await m_trustedCertificateList[ii].Find(needPrivateKey: false).ConfigureAwait(continueOnCapturedContext: false);
				if (x509Certificate != null && x509Certificate.Thumbprint == certificate.Thumbprint && Utils.IsEqual(x509Certificate.RawData, certificate.RawData))
				{
					return m_trustedCertificateList[ii];
				}
			}
		}
		if (m_trustedCertificateStore != null)
		{
			ICertificateStore store = m_trustedCertificateStore.OpenStore();
			try
			{
				X509Certificate2Collection x509Certificate2Collection = await store.FindByThumbprint(certificate.Thumbprint).ConfigureAwait(continueOnCapturedContext: false);
				for (int i = 0; i < x509Certificate2Collection.Count; i++)
				{
					if (Utils.IsEqual(x509Certificate2Collection[i].RawData, certificate.RawData))
					{
						return new CertificateIdentifier(x509Certificate2Collection[i], m_trustedCertificateStore.ValidationOptions);
					}
				}
			}
			finally
			{
				store.Close();
			}
		}
		return null;
	}

	private bool Match(X509Certificate2 certificate, X500DistinguishedName subjectName, string serialNumber, string authorityKeyId)
	{
		bool result = false;
		if (certificate == null)
		{
			return false;
		}
		if (!X509Utils.CompareDistinguishedName(certificate.SubjectName, subjectName))
		{
			return false;
		}
		if (!string.IsNullOrEmpty(serialNumber))
		{
			if (certificate.SerialNumber != serialNumber)
			{
				return false;
			}
			result = true;
		}
		if (!string.IsNullOrEmpty(authorityKeyId))
		{
			X509SubjectKeyIdentifierExtension x509SubjectKeyIdentifierExtension = certificate.FindExtension<X509SubjectKeyIdentifierExtension>();
			if (x509SubjectKeyIdentifierExtension != null)
			{
				if (x509SubjectKeyIdentifierExtension.SubjectKeyIdentifier != authorityKeyId)
				{
					return false;
				}
				result = true;
			}
		}
		return result;
	}

	public async Task<bool> GetIssuersNoExceptionsOnGetIssuer(X509Certificate2Collection certificates, List<CertificateIdentifier> issuers, Dictionary<X509Certificate2, ServiceResultException> validationErrors)
	{
		bool isTrusted = false;
		CertificateIdentifier issuer = null;
		ServiceResultException revocationStatus = null;
		X509Certificate2 certificate = certificates[0];
		CertificateIdentifierCollection untrustedCollection = new CertificateIdentifierCollection();
		for (int i = 1; i < certificates.Count; i++)
		{
			untrustedCollection.Add(new CertificateIdentifier(certificates[i]));
		}
		while (!X509Utils.IsSelfSigned(certificate))
		{
			if (validationErrors != null)
			{
				(issuer, revocationStatus) = await GetIssuerNoExceptionAsync(certificate, m_trustedCertificateList, m_trustedCertificateStore, checkRecovationStatus: true).ConfigureAwait(continueOnCapturedContext: false);
			}
			else
			{
				issuer = await GetIssuer(certificate, m_trustedCertificateList, m_trustedCertificateStore, checkRecovationStatus: true).ConfigureAwait(continueOnCapturedContext: false);
			}
			if (issuer == null)
			{
				if (validationErrors != null)
				{
					(issuer, revocationStatus) = await GetIssuerNoExceptionAsync(certificate, m_issuerCertificateList, m_issuerCertificateStore, checkRecovationStatus: true).ConfigureAwait(continueOnCapturedContext: false);
				}
				else
				{
					issuer = await GetIssuer(certificate, m_issuerCertificateList, m_issuerCertificateStore, checkRecovationStatus: true).ConfigureAwait(continueOnCapturedContext: false);
				}
				if (issuer == null)
				{
					if (validationErrors != null)
					{
						(issuer, revocationStatus) = await GetIssuerNoExceptionAsync(certificate, untrustedCollection, null, checkRecovationStatus: true).ConfigureAwait(continueOnCapturedContext: false);
					}
					else
					{
						issuer = await GetIssuer(certificate, untrustedCollection, null, checkRecovationStatus: true).ConfigureAwait(continueOnCapturedContext: false);
					}
				}
			}
			else
			{
				isTrusted = true;
			}
			if (issuer != null)
			{
				if (validationErrors != null)
				{
					validationErrors[certificate] = revocationStatus;
				}
				if (issuers.Find((CertificateIdentifier iss) => string.Equals(iss.Thumbprint, issuer.Thumbprint, StringComparison.OrdinalIgnoreCase)) != null)
				{
					break;
				}
				issuers.Add(issuer);
				certificate = await issuer.Find(needPrivateKey: false).ConfigureAwait(continueOnCapturedContext: false);
			}
			if (issuer == null)
			{
				break;
			}
		}
		return isTrusted;
	}

	public Task<bool> GetIssuers(X509Certificate2Collection certificates, List<CertificateIdentifier> issuers)
	{
		return GetIssuersNoExceptionsOnGetIssuer(certificates, issuers, null);
	}

	public Task<bool> GetIssuers(X509Certificate2 certificate, List<CertificateIdentifier> issuers)
	{
		return GetIssuers(new X509Certificate2Collection { certificate }, issuers);
	}

	private async Task<(CertificateIdentifier, ServiceResultException)> GetIssuerNoExceptionAsync(X509Certificate2 certificate, CertificateIdentifierCollection explicitList, CertificateStoreIdentifier certificateStore, bool checkRecovationStatus)
	{
		ServiceResultException serviceResult = null;
		X500DistinguishedName subjectName = certificate.IssuerName;
		string keyId = null;
		string serialNumber = null;
		X509AuthorityKeyIdentifierExtension x509AuthorityKeyIdentifierExtension = certificate.FindExtension<X509AuthorityKeyIdentifierExtension>();
		if (x509AuthorityKeyIdentifierExtension != null)
		{
			keyId = x509AuthorityKeyIdentifierExtension.KeyIdentifier;
			serialNumber = x509AuthorityKeyIdentifierExtension.SerialNumber;
		}
		if (explicitList != null)
		{
			for (int ii = 0; ii < explicitList.Count; ii++)
			{
				X509Certificate2 x509Certificate = await explicitList[ii].Find(needPrivateKey: false).ConfigureAwait(continueOnCapturedContext: false);
				if (x509Certificate != null && X509Utils.IsIssuerAllowed(x509Certificate) && Match(x509Certificate, subjectName, serialNumber, keyId))
				{
					return (new CertificateIdentifier(x509Certificate, CertificateValidationOptions.SuppressRevocationStatusUnknown), null);
				}
			}
		}
		if (certificateStore != null)
		{
			ICertificateStore store = certificateStore.OpenStore();
			try
			{
				X509Certificate2Collection x509Certificate2Collection = await store.Enumerate().ConfigureAwait(continueOnCapturedContext: false);
				for (int i = 0; i < x509Certificate2Collection.Count; i++)
				{
					X509Certificate2 issuer = x509Certificate2Collection[i];
					if (issuer == null || !X509Utils.IsIssuerAllowed(issuer) || !Match(issuer, subjectName, serialNumber, keyId))
					{
						continue;
					}
					CertificateValidationOptions options = certificateStore.ValidationOptions;
					if (checkRecovationStatus)
					{
						StatusCode statusCode = await store.IsRevoked(issuer, certificate).ConfigureAwait(continueOnCapturedContext: false);
						if (StatusCode.IsBad(statusCode) && statusCode != 2151481344u)
						{
							if (statusCode == 2149253120u)
							{
								if (X509Utils.IsCertificateAuthority(certificate))
								{
									statusCode.Code = 2149318656u;
								}
								if (m_rejectUnknownRevocationStatus && (options & CertificateValidationOptions.SuppressRevocationStatusUnknown) == 0)
								{
									serviceResult = new ServiceResultException(statusCode);
								}
							}
							else
							{
								if (statusCode == 2149384192u && X509Utils.IsCertificateAuthority(certificate))
								{
									statusCode.Code = 2149449728u;
								}
								serviceResult = new ServiceResultException(statusCode);
							}
						}
					}
					options |= CertificateValidationOptions.SuppressRevocationStatusUnknown;
					return (new CertificateIdentifier(issuer, options), serviceResult);
				}
			}
			finally
			{
				store.Close();
			}
		}
		return (null, null);
	}

	private async Task<CertificateIdentifier> GetIssuer(X509Certificate2 certificate, CertificateIdentifierCollection explicitList, CertificateStoreIdentifier certificateStore, bool checkRecovationStatus)
	{
		if (X509Utils.IsSelfSigned(certificate))
		{
			return null;
		}
		var (result, ex) = await GetIssuerNoExceptionAsync(certificate, explicitList, certificateStore, checkRecovationStatus).ConfigureAwait(continueOnCapturedContext: false);
		if (ex != null)
		{
			throw ex;
		}
		return result;
	}

	protected virtual async Task InternalValidateAsync(X509Certificate2Collection certificates, ConfiguredEndpoint endpoint, CancellationToken ct = default(CancellationToken))
	{
		X509Certificate2 certificate = certificates[0];
		X509Certificate2 value = null;
		if (m_useValidatedCertificates && m_validatedCertificates.TryGetValue(certificate.Thumbprint, out value) && Utils.IsEqual(value.RawData, certificate.RawData))
		{
			return;
		}
		CertificateIdentifier trustedCertificate = await GetTrustedCertificateAsync(certificate).ConfigureAwait(continueOnCapturedContext: false);
		List<CertificateIdentifier> issuers = new List<CertificateIdentifier>();
		Dictionary<X509Certificate2, ServiceResultException> validationErrors = new Dictionary<X509Certificate2, ServiceResultException>();
		bool flag = await GetIssuersNoExceptionsOnGetIssuer(certificates, issuers, validationErrors).ConfigureAwait(continueOnCapturedContext: false);
		ServiceResult serviceResult = PopulateSresultWithValidationErrors(validationErrors);
		X509ChainPolicy x509ChainPolicy = new X509ChainPolicy
		{
			RevocationFlag = X509RevocationFlag.EntireChain,
			RevocationMode = X509RevocationMode.NoCheck,
			VerificationFlags = X509VerificationFlags.NoFlag,
			UrlRetrievalTimeout = TimeSpan.FromMilliseconds(1.0)
		};
		foreach (CertificateIdentifier item in issuers)
		{
			if ((item.ValidationOptions & CertificateValidationOptions.SuppressRevocationStatusUnknown) != CertificateValidationOptions.Default)
			{
				x509ChainPolicy.VerificationFlags |= X509VerificationFlags.IgnoreCertificateAuthorityRevocationUnknown;
				x509ChainPolicy.VerificationFlags |= X509VerificationFlags.IgnoreCtlSignerRevocationUnknown;
				x509ChainPolicy.VerificationFlags |= X509VerificationFlags.IgnoreEndRevocationUnknown;
				x509ChainPolicy.VerificationFlags |= X509VerificationFlags.IgnoreRootRevocationUnknown;
			}
			x509ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
			x509ChainPolicy.ExtraStore.Add(item.Certificate);
		}
		bool flag2 = false;
		using (X509Chain x509Chain = new X509Chain())
		{
			x509Chain.ChainPolicy = x509ChainPolicy;
			x509Chain.Build(certificate);
			CertificateIdentifier certificateIdentifier = trustedCertificate;
			if (certificateIdentifier == null)
			{
				certificateIdentifier = new CertificateIdentifier(certificate);
			}
			X509ChainStatus[] chainStatus = x509Chain.ChainStatus;
			for (int i = 0; i < chainStatus.Length; i++)
			{
				X509ChainStatus x509ChainStatus = chainStatus[i];
				switch (x509ChainStatus.Status)
				{
				case X509ChainStatusFlags.PartialChain:
					flag2 = true;
					flag = false;
					continue;
				case X509ChainStatusFlags.NotSignatureValid:
					break;
				default:
					Utils.LogError("Unexpected status {0} processing certificate chain.", x509ChainStatus.Status);
					break;
				case X509ChainStatusFlags.NoError:
				case X509ChainStatusFlags.NotTimeValid:
				case X509ChainStatusFlags.NotTimeNested:
				case X509ChainStatusFlags.Revoked:
				case X509ChainStatusFlags.NotValidForUsage:
				case X509ChainStatusFlags.UntrustedRoot:
				case X509ChainStatusFlags.RevocationStatusUnknown:
				case X509ChainStatusFlags.InvalidBasicConstraints:
				case X509ChainStatusFlags.OfflineRevocation:
					continue;
				}
				serviceResult = new ServiceResult(ServiceResult.Create(2148663296u, "Certificate validation failed. {0}: {1}", x509ChainStatus.Status, x509ChainStatus.StatusInformation), serviceResult);
			}
			if (issuers.Count + 1 != x509Chain.ChainElements.Count)
			{
				flag2 = true;
				flag = false;
			}
			for (int j = 0; j < x509Chain.ChainElements.Count; j++)
			{
				X509ChainElement x509ChainElement = x509Chain.ChainElements[j];
				CertificateIdentifier certificateIdentifier2 = null;
				if (j < issuers.Count)
				{
					certificateIdentifier2 = issuers[j];
				}
				if (j + 1 < x509Chain.ChainElements.Count)
				{
					X509Certificate2 certificate2 = x509Chain.ChainElements[j + 1].Certificate;
					if (certificateIdentifier2 == null || !Utils.IsEqual(certificate2.RawData, certificateIdentifier2.RawData))
					{
						Utils.LogCertificate(512, "An unexpected certificate was used in the certificate chain.", certificate2);
						flag2 = true;
						flag = false;
						break;
					}
				}
				if (x509ChainElement.ChainElementStatus.Length != 0)
				{
					chainStatus = x509ChainElement.ChainElementStatus;
					for (int i = 0; i < chainStatus.Length; i++)
					{
						ServiceResult serviceResult2 = CheckChainStatus(chainStatus[i], certificateIdentifier, certificateIdentifier2, j != 0);
						if (ServiceResult.IsBad(serviceResult2))
						{
							serviceResult = new ServiceResult(serviceResult2, serviceResult);
						}
					}
				}
				if (certificateIdentifier2 != null)
				{
					certificateIdentifier = certificateIdentifier2;
				}
			}
		}
		bool flag3 = !X509Utils.IsSelfSigned(certificate);
		if (issuers.Count > 0)
		{
			if (!X509Utils.IsSelfSigned(issuers[issuers.Count - 1].Certificate))
			{
				flag2 = true;
			}
		}
		else if (flag3)
		{
			flag2 = true;
		}
		if (flag3 && !flag && trustedCertificate == null)
		{
			string text = "Certificate Issuer is not trusted.";
			serviceResult = new ServiceResult(2149187584u, null, null, text, null, serviceResult);
		}
		if (trustedCertificate == null && !flag && (m_applicationCertificate == null || !Utils.IsEqual(m_applicationCertificate.RawData, certificate.RawData)))
		{
			string text2 = "Certificate is not trusted.";
			serviceResult = new ServiceResult(2149187584u, null, null, text2, null, serviceResult);
		}
		if (endpoint != null && !FindDomain(certificate, endpoint))
		{
			string text3 = Utils.Format("The domain '{0}' is not listed in the server certificate.", endpoint.EndpointUrl.DnsSafeHost);
			serviceResult = new ServiceResult(2148925440u, null, null, text3, null, serviceResult);
		}
		if ((X509Utils.GetKeyUsage(certificate) & X509KeyUsageFlags.DataEncipherment) == 0)
		{
			serviceResult = new ServiceResult(2149056512u, null, null, "Usage of certificate is not allowed.", null, serviceResult);
		}
		if (m_rejectSHA1SignedCertificates && IsSHA1SignatureAlgorithm(certificate.SignatureAlgorithm))
		{
			serviceResult = new ServiceResult(2165571584u, null, null, "SHA1 signed certificates are not trusted.", null, serviceResult);
		}
		int rSAPublicKeySize = X509Utils.GetRSAPublicKeySize(certificate);
		if (rSAPublicKeySize < m_minimumCertificateKeySize)
		{
			serviceResult = new ServiceResult(2165571584u, null, null, $"Certificate doesn't meet minimum key length requirement. ({rSAPublicKeySize}<{m_minimumCertificateKeySize})", null, serviceResult);
		}
		if (flag3 && flag2)
		{
			string text4 = "Certificate chain validation incomplete.";
			serviceResult = new ServiceResult(2165112832u, null, null, text4, null, serviceResult);
		}
		if (serviceResult != null)
		{
			throw new ServiceResultException(serviceResult);
		}
	}

	private ServiceResult PopulateSresultWithValidationErrors(Dictionary<X509Certificate2, ServiceResultException> validationErrors)
	{
		Dictionary<X509Certificate2, ServiceResultException> dictionary = new Dictionary<X509Certificate2, ServiceResultException>();
		Dictionary<X509Certificate2, ServiceResultException> dictionary2 = new Dictionary<X509Certificate2, ServiceResultException>();
		Dictionary<X509Certificate2, ServiceResultException> dictionary3 = new Dictionary<X509Certificate2, ServiceResultException>();
		ServiceResult serviceResult = null;
		foreach (KeyValuePair<X509Certificate2, ServiceResultException> validationError in validationErrors)
		{
			if (validationError.Value != null)
			{
				if (validationError.Value.StatusCode == 2149384192u)
				{
					dictionary[validationError.Key] = validationError.Value;
				}
				else if (validationError.Value.StatusCode == 2149449728u)
				{
					dictionary2[validationError.Key] = validationError.Value;
				}
				else if (validationError.Value.StatusCode == 2149253120u)
				{
					dictionary3[validationError.Key] = validationError.Value;
				}
				else if (validationError.Value.StatusCode == 2149318656u)
				{
					string text = CertificateMessage("Certificate issuer revocation list not found.", validationError.Key);
					serviceResult = new ServiceResult(2149318656u, null, null, text, null, serviceResult);
				}
				else if (StatusCode.IsBad(validationError.Value.StatusCode))
				{
					string text2 = CertificateMessage("Unknown error while trying to determine the revocation status.", validationError.Key);
					serviceResult = new ServiceResult(validationError.Value.StatusCode, null, null, text2, null, serviceResult);
				}
			}
		}
		if (dictionary3.Count > 0)
		{
			foreach (KeyValuePair<X509Certificate2, ServiceResultException> item in dictionary3)
			{
				string text3 = CertificateMessage("Certificate revocation list not found.", item.Key);
				serviceResult = new ServiceResult(2149253120u, null, null, text3, null, serviceResult);
			}
		}
		if (dictionary2.Count > 0)
		{
			foreach (KeyValuePair<X509Certificate2, ServiceResultException> item2 in dictionary2)
			{
				string text4 = CertificateMessage("Certificate issuer is revoked.", item2.Key);
				serviceResult = new ServiceResult(2149449728u, null, null, text4, null, serviceResult);
			}
		}
		if (dictionary.Count > 0)
		{
			foreach (KeyValuePair<X509Certificate2, ServiceResultException> item3 in dictionary)
			{
				string text5 = CertificateMessage("Certificate is revoked.", item3.Key);
				serviceResult = new ServiceResult(2149384192u, null, null, text5, null, serviceResult);
			}
		}
		return serviceResult;
	}

	public ICertificateValidator GetChannelValidator()
	{
		return this;
	}

	public void ValidateDomains(X509Certificate2 serverCertificate, ConfiguredEndpoint endpoint, bool serverValidation = false)
	{
		if ((!serverValidation && m_useValidatedCertificates && m_validatedCertificates.TryGetValue(serverCertificate.Thumbprint, out var value) && Utils.IsEqual(value.RawData, serverCertificate.RawData)) || FindDomain(serverCertificate, endpoint))
		{
			return;
		}
		bool flag = false;
		ServiceResultException ex = ServiceResultException.Create(2148925440u, "The domain '{0}' is not listed in the server certificate.", endpoint.EndpointUrl.DnsSafeHost);
		if (this.m_CertificateValidation != null)
		{
			CertificateValidationEventArgs e = new CertificateValidationEventArgs(new ServiceResult(ex), serverCertificate);
			this.m_CertificateValidation(this, e);
			flag = e.Accept || e.AcceptAll;
		}
		if (!flag)
		{
			if (serverValidation)
			{
				Utils.LogError("The domain '{0}' is not listed in the server certificate.", endpoint.EndpointUrl.DnsSafeHost);
			}
			else
			{
				Utils.LogCertificate(LogLevel.Error, "Certificate rejected. Reason={0}.", serverCertificate, (ex != null) ? ex.ToString() : "Unknown Error");
				SaveCertificate(serverCertificate);
			}
			throw ex;
		}
	}

	private static ServiceResult CheckChainStatus(X509ChainStatus status, CertificateIdentifier id, CertificateIdentifier issuer, bool isIssuer)
	{
		switch (status.Status)
		{
		case X509ChainStatusFlags.NotValidForUsage:
			return ServiceResult.Create(isIssuer ? 2149056512u : 2149122048u, "Certificate may not be used as an application instance certificate. {0}: {1}", status.Status, status.StatusInformation);
		case X509ChainStatusFlags.UntrustedRoot:
		case X509ChainStatusFlags.PartialChain:
			if (issuer == null && id.Certificate != null && X509Utils.IsSelfSigned(id.Certificate))
			{
				if (IsSignatureValid(id.Certificate))
				{
					break;
				}
				goto default;
			}
			return ServiceResult.Create(2165112832u, "Certificate chain validation failed. {0}: {1}", status.Status, status.StatusInformation);
		case X509ChainStatusFlags.RevocationStatusUnknown:
			if (issuer != null && (issuer.ValidationOptions & CertificateValidationOptions.SuppressRevocationStatusUnknown) != CertificateValidationOptions.Default)
			{
				Utils.LogWarning(512, "Error suppressed: {0}: {1}", status.Status, status.StatusInformation);
			}
			else if (id.Certificate == null || !X509Utils.IsSelfSigned(id.Certificate))
			{
				return ServiceResult.Create(isIssuer ? 2149318656u : 2149253120u, "Certificate revocation status cannot be verified. {0}: {1}", status.Status, status.StatusInformation);
			}
			break;
		case X509ChainStatusFlags.Revoked:
			return ServiceResult.Create(isIssuer ? 2149449728u : 2149384192u, "Certificate has been revoked. {0}: {1}", status.Status, status.StatusInformation);
		case X509ChainStatusFlags.NotTimeNested:
			if (id != null && (id.ValidationOptions & CertificateValidationOptions.SuppressCertificateExpired) != CertificateValidationOptions.Default)
			{
				Utils.LogWarning(512, "Error suppressed: {0}: {1}", status.Status, status.StatusInformation);
				break;
			}
			return ServiceResult.Create(2148859904u, "Issuer Certificate has expired or is not yet valid. {0}: {1}", status.Status, status.StatusInformation);
		case X509ChainStatusFlags.NotTimeValid:
			if (id != null && (id.ValidationOptions & CertificateValidationOptions.SuppressCertificateExpired) != CertificateValidationOptions.Default)
			{
				Utils.LogWarning(512, "Error suppressed: {0}: {1}", status.Status, status.StatusInformation);
				break;
			}
			return ServiceResult.Create(isIssuer ? 2148859904u : 2148794368u, "Certificate has expired or is not yet valid. {0}: {1}", status.Status, status.StatusInformation);
		default:
			return ServiceResult.Create(2148663296u, "Certificate validation failed. {0}: {1}", status.Status, status.StatusInformation);
		case X509ChainStatusFlags.NoError:
		case X509ChainStatusFlags.InvalidBasicConstraints:
		case X509ChainStatusFlags.OfflineRevocation:
			break;
		}
		return null;
	}

	private static bool IsSHA1SignatureAlgorithm(Oid oid)
	{
		if (!(oid.Value == "1.3.14.3.2.29") && !(oid.Value == "1.2.840.10040.4.3") && !(oid.Value == "1.2.840.10045.4.1") && !(oid.Value == "1.2.840.113549.1.1.5") && !(oid.Value == "1.3.14.3.2.13"))
		{
			return oid.Value == "1.3.14.3.2.27";
		}
		return true;
	}

	private string CertificateMessage(string error, X509Certificate2 certificate)
	{
		StringBuilder stringBuilder = new StringBuilder().AppendLine(error).AppendFormat("Subject: {0}", certificate.Subject).AppendLine();
		if (!string.Equals(certificate.Subject, certificate.Issuer, StringComparison.Ordinal))
		{
			stringBuilder.AppendFormat("Issuer: {0}", certificate.Issuer).AppendLine();
		}
		return stringBuilder.ToString();
	}

	private static bool IsSignatureValid(X509Certificate2 cert)
	{
		return X509Utils.VerifySelfSigned(cert);
	}

	private bool FindDomain(X509Certificate2 serverCertificate, ConfiguredEndpoint endpoint)
	{
		bool result = false;
		IList<string> domainsFromCertficate = X509Utils.GetDomainsFromCertficate(serverCertificate);
		if (domainsFromCertficate != null && domainsFromCertficate.Count > 0)
		{
			string text2;
			string text = (text2 = endpoint.EndpointUrl.DnsSafeHost);
			bool flag = false;
			if (endpoint.EndpointUrl.HostNameType == UriHostNameType.Dns)
			{
				if (string.Equals(text, "localhost", StringComparison.OrdinalIgnoreCase))
				{
					flag = true;
				}
				else
				{
					text2 = text.Split('.')[0];
				}
			}
			else
			{
				text2 = Utils.NormalizedIPAddress(text);
				if (text2 == "127.0.0.1" || text2 == "::1")
				{
					flag = true;
				}
			}
			if (flag)
			{
				text = Utils.GetFullQualifiedDomainName();
				text2 = Utils.GetHostName();
			}
			for (int i = 0; i < domainsFromCertficate.Count; i++)
			{
				if (string.Equals(text2, domainsFromCertficate[i], StringComparison.OrdinalIgnoreCase) || string.Equals(text, domainsFromCertficate[i], StringComparison.OrdinalIgnoreCase))
				{
					result = true;
					break;
				}
			}
		}
		return result;
	}
}
