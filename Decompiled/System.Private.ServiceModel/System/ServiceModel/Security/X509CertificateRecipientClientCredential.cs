using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace System.ServiceModel.Security;

public sealed class X509CertificateRecipientClientCredential
{
	private X509ServiceCertificateAuthentication _sslCertificateAuthentication;

	internal const StoreLocation DefaultStoreLocation = StoreLocation.CurrentUser;

	internal const StoreName DefaultStoreName = StoreName.My;

	internal const X509FindType DefaultFindType = X509FindType.FindBySubjectDistinguishedName;

	private X509Certificate2 _defaultCertificate;

	private bool _isReadOnly;

	public X509Certificate2 DefaultCertificate
	{
		get
		{
			return _defaultCertificate;
		}
		set
		{
			ThrowIfImmutable();
			_defaultCertificate = value;
		}
	}

	public Dictionary<Uri, X509Certificate2> ScopedCertificates { get; }

	public X509ServiceCertificateAuthentication Authentication { get; }

	public X509ServiceCertificateAuthentication SslCertificateAuthentication
	{
		get
		{
			return _sslCertificateAuthentication;
		}
		set
		{
			ThrowIfImmutable();
			_sslCertificateAuthentication = value;
		}
	}

	internal X509CertificateRecipientClientCredential()
	{
		Authentication = new X509ServiceCertificateAuthentication();
		ScopedCertificates = new Dictionary<Uri, X509Certificate2>();
	}

	internal X509CertificateRecipientClientCredential(X509CertificateRecipientClientCredential other)
	{
		Authentication = new X509ServiceCertificateAuthentication(other.Authentication);
		if (other._sslCertificateAuthentication != null)
		{
			_sslCertificateAuthentication = new X509ServiceCertificateAuthentication(other._sslCertificateAuthentication);
		}
		_defaultCertificate = other._defaultCertificate;
		ScopedCertificates = new Dictionary<Uri, X509Certificate2>();
		foreach (Uri key in other.ScopedCertificates.Keys)
		{
			ScopedCertificates.Add(key, other.ScopedCertificates[key]);
		}
		_isReadOnly = other._isReadOnly;
	}

	public void SetDefaultCertificate(string subjectName, StoreLocation storeLocation, StoreName storeName)
	{
		if (subjectName == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("subjectName");
		}
		SetDefaultCertificate(storeLocation, storeName, X509FindType.FindBySubjectDistinguishedName, subjectName);
	}

	public void SetDefaultCertificate(StoreLocation storeLocation, StoreName storeName, X509FindType findType, object findValue)
	{
		if (findValue == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("findValue");
		}
		ThrowIfImmutable();
		_defaultCertificate = SecurityUtils.GetCertificateFromStore(storeName, storeLocation, findType, findValue, null);
	}

	public void SetScopedCertificate(string subjectName, StoreLocation storeLocation, StoreName storeName, Uri targetService)
	{
		if (subjectName == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("subjectName");
		}
		SetScopedCertificate(StoreLocation.CurrentUser, StoreName.My, X509FindType.FindBySubjectDistinguishedName, subjectName, targetService);
	}

	public void SetScopedCertificate(StoreLocation storeLocation, StoreName storeName, X509FindType findType, object findValue, Uri targetService)
	{
		if (findValue == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("findValue");
		}
		if (targetService == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("targetService");
		}
		ThrowIfImmutable();
		X509Certificate2 certificateFromStore = SecurityUtils.GetCertificateFromStore(storeName, storeLocation, findType, findValue, null);
		ScopedCertificates[targetService] = certificateFromStore;
	}

	internal void MakeReadOnly()
	{
		_isReadOnly = true;
		Authentication.MakeReadOnly();
		if (_sslCertificateAuthentication != null)
		{
			_sslCertificateAuthentication.MakeReadOnly();
		}
	}

	private void ThrowIfImmutable()
	{
		if (_isReadOnly)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.ObjectIsReadOnly)));
		}
	}
}
