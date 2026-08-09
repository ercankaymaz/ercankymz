using System.IdentityModel.Selectors;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace System.ServiceModel.Security;

public sealed class X509ServiceCertificateAuthentication
{
	internal const X509CertificateValidationMode DefaultCertificateValidationMode = X509CertificateValidationMode.ChainTrust;

	internal const X509RevocationMode DefaultRevocationMode = X509RevocationMode.Online;

	internal const StoreLocation DefaultTrustedStoreLocation = StoreLocation.CurrentUser;

	private static X509CertificateValidator s_defaultCertificateValidator;

	private static readonly Oid s_serverAuthOid = new Oid("1.3.6.1.5.5.7.3.1", "1.3.6.1.5.5.7.3.1");

	private X509CertificateValidationMode _certificateValidationMode = X509CertificateValidationMode.ChainTrust;

	private X509RevocationMode _revocationMode = X509RevocationMode.Online;

	private StoreLocation _trustedStoreLocation = StoreLocation.CurrentUser;

	private X509CertificateValidator _customCertificateValidator;

	private bool _isReadOnly;

	internal static X509CertificateValidator DefaultCertificateValidator
	{
		get
		{
			if (s_defaultCertificateValidator == null)
			{
				bool useMachineContext = false;
				X509ChainPolicy x509ChainPolicy = new X509ChainPolicy();
				x509ChainPolicy.ApplicationPolicy.Add(s_serverAuthOid);
				x509ChainPolicy.RevocationMode = X509RevocationMode.Online;
				s_defaultCertificateValidator = X509CertificateValidator.CreateChainTrustValidator(useMachineContext, x509ChainPolicy);
			}
			return s_defaultCertificateValidator;
		}
	}

	public X509CertificateValidationMode CertificateValidationMode
	{
		get
		{
			return _certificateValidationMode;
		}
		set
		{
			X509CertificateValidationModeHelper.Validate(value);
			if ((value == X509CertificateValidationMode.PeerTrust || value == X509CertificateValidationMode.PeerOrChainTrust) && RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
			{
				throw ExceptionHelper.PlatformNotSupported(System.SR.PeerTrustNotSupportedOnOSX);
			}
			ThrowIfImmutable();
			_certificateValidationMode = value;
		}
	}

	public X509RevocationMode RevocationMode
	{
		get
		{
			return _revocationMode;
		}
		set
		{
			ThrowIfImmutable();
			_revocationMode = value;
		}
	}

	public StoreLocation TrustedStoreLocation
	{
		get
		{
			return _trustedStoreLocation;
		}
		set
		{
			ThrowIfImmutable();
			_trustedStoreLocation = value;
		}
	}

	public X509CertificateValidator CustomCertificateValidator
	{
		get
		{
			return _customCertificateValidator;
		}
		set
		{
			ThrowIfImmutable();
			_customCertificateValidator = value;
		}
	}

	public X509ServiceCertificateAuthentication()
	{
	}

	internal X509ServiceCertificateAuthentication(X509ServiceCertificateAuthentication other)
	{
		_certificateValidationMode = other._certificateValidationMode;
		_customCertificateValidator = other._customCertificateValidator;
		_revocationMode = other._revocationMode;
		_trustedStoreLocation = other._trustedStoreLocation;
		_isReadOnly = other._isReadOnly;
	}

	internal bool TryGetCertificateValidator(out X509CertificateValidator validator)
	{
		validator = null;
		if (_certificateValidationMode == X509CertificateValidationMode.None)
		{
			validator = X509CertificateValidator.None;
		}
		else if (_certificateValidationMode == X509CertificateValidationMode.PeerTrust)
		{
			validator = X509CertificateValidator.PeerTrust;
		}
		else if (_certificateValidationMode == X509CertificateValidationMode.Custom)
		{
			validator = _customCertificateValidator;
		}
		else
		{
			bool useMachineContext = _trustedStoreLocation == StoreLocation.LocalMachine;
			X509ChainPolicy x509ChainPolicy = new X509ChainPolicy();
			x509ChainPolicy.ApplicationPolicy.Add(s_serverAuthOid);
			x509ChainPolicy.RevocationMode = _revocationMode;
			if (_certificateValidationMode == X509CertificateValidationMode.ChainTrust)
			{
				validator = X509CertificateValidator.CreateChainTrustValidator(useMachineContext, x509ChainPolicy);
			}
			else
			{
				validator = X509CertificateValidator.CreatePeerOrChainTrustValidator(useMachineContext, x509ChainPolicy);
			}
		}
		return validator != null;
	}

	internal X509CertificateValidator GetCertificateValidator()
	{
		if (!TryGetCertificateValidator(out var validator))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.MissingCustomCertificateValidator)));
		}
		return validator;
	}

	internal void MakeReadOnly()
	{
		_isReadOnly = true;
	}

	private void ThrowIfImmutable()
	{
		if (_isReadOnly)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.ObjectIsReadOnly)));
		}
	}
}
