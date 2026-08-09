using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;

namespace System.IdentityModel.Tokens;

public class X509AsymmetricSecurityKey : AsymmetricSecurityKey
{
	private X509Certificate2 _certificate;

	private AsymmetricAlgorithm _privateKey;

	private bool _privateKeyAvailabilityDetermined;

	private AsymmetricAlgorithm _publicKey;

	private bool _publicKeyAvailabilityDetermined;

	public override int KeySize => PublicKey.KeySize;

	private AsymmetricAlgorithm PrivateKey
	{
		get
		{
			if (!_privateKeyAvailabilityDetermined)
			{
				lock (ThisLock)
				{
					_privateKey = _certificate.GetRSAPrivateKey();
					if (_privateKey != null)
					{
						if (_privateKey is RSACryptoServiceProvider rSACryptoServiceProvider && rSACryptoServiceProvider.CspKeyContainerInfo.ProviderType == 1)
						{
							CspParameters cspParameters = new CspParameters();
							cspParameters.ProviderType = 24;
							cspParameters.KeyContainerName = rSACryptoServiceProvider.CspKeyContainerInfo.KeyContainerName;
							cspParameters.KeyNumber = (int)rSACryptoServiceProvider.CspKeyContainerInfo.KeyNumber;
							if (rSACryptoServiceProvider.CspKeyContainerInfo.MachineKeyStore)
							{
								cspParameters.Flags = CspProviderFlags.UseMachineKeyStore;
							}
							cspParameters.Flags |= CspProviderFlags.UseExistingKey;
							_privateKey = new RSACryptoServiceProvider(cspParameters);
						}
					}
					else
					{
						_privateKey = _certificate.GetECDsaPrivateKey();
					}
					if (_certificate.HasPrivateKey && _privateKey == null)
					{
						DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.PrivateKeyNotSupported));
					}
					_privateKeyAvailabilityDetermined = true;
				}
			}
			return _privateKey;
		}
	}

	private AsymmetricAlgorithm PublicKey
	{
		get
		{
			if (!_publicKeyAvailabilityDetermined)
			{
				lock (ThisLock)
				{
					if (!_publicKeyAvailabilityDetermined)
					{
						_publicKey = _certificate.GetRSAPublicKey();
						if (_publicKey == null)
						{
							DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.PublicKeyNotSupported));
						}
						_publicKeyAvailabilityDetermined = true;
					}
				}
			}
			return _publicKey;
		}
	}

	private object ThisLock { get; } = new object();

	public X509AsymmetricSecurityKey(X509Certificate2 certificate)
	{
		_certificate = certificate ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("certificate");
	}

	public override byte[] DecryptKey(string algorithm, byte[] keyData)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	public override byte[] EncryptKey(string algorithm, byte[] keyData)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	public override AsymmetricAlgorithm GetAsymmetricAlgorithm(string algorithm, bool privateKey)
	{
		if (privateKey)
		{
			if (PrivateKey == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.MissingPrivateKey));
			}
			if (string.IsNullOrEmpty(algorithm))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(algorithm, System.SR.Format(System.SR.EmptyOrNullArgumentString, "algorithm"));
			}
			switch (algorithm)
			{
			case "http://www.w3.org/2000/09/xmldsig#dsa-sha1":
				if (PrivateKey is DSA)
				{
					return PrivateKey as DSA;
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.AlgorithmAndPrivateKeyMisMatch));
			case "http://www.w3.org/2000/09/xmldsig#rsa-sha1":
			case "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256":
			case "http://www.w3.org/2001/04/xmlenc#rsa-1_5":
			case "http://www.w3.org/2001/04/xmlenc#rsa-oaep-mgf1p":
				if (PrivateKey is RSA)
				{
					return PrivateKey as RSA;
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.AlgorithmAndPrivateKeyMisMatch));
			default:
				if (IsSupportedAlgorithm(algorithm))
				{
					return PrivateKey;
				}
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.UnsupportedCryptoAlgorithm, algorithm)));
			}
		}
		switch (algorithm)
		{
		case "http://www.w3.org/2000/09/xmldsig#dsa-sha1":
			if (PublicKey is DSA result)
			{
				return result;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.AlgorithmAndPublicKeyMisMatch));
		case "http://www.w3.org/2000/09/xmldsig#rsa-sha1":
		case "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256":
		case "http://www.w3.org/2001/04/xmlenc#rsa-1_5":
		case "http://www.w3.org/2001/04/xmlenc#rsa-oaep-mgf1p":
			if (PublicKey is RSA)
			{
				return PublicKey as RSA;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.AlgorithmAndPublicKeyMisMatch));
		default:
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.UnsupportedCryptoAlgorithm, algorithm)));
		}
	}

	public override HashAlgorithm GetHashAlgorithmForSignature(string algorithm)
	{
		if (string.IsNullOrEmpty(algorithm))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(algorithm, System.SR.Format(System.SR.EmptyOrNullArgumentString, "algorithm"));
		}
		object algorithmFromConfig = CryptoHelper.GetAlgorithmFromConfig(algorithm);
		if (algorithmFromConfig != null)
		{
			if (algorithmFromConfig is SignatureDescription signatureDescription)
			{
				return signatureDescription.CreateDigest();
			}
			if (algorithmFromConfig is HashAlgorithm result)
			{
				return result;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CryptographicException(System.SR.Format(System.SR.UnsupportedAlgorithmForCryptoOperation, algorithm, "CreateDigest")));
		}
		switch (algorithm)
		{
		case "http://www.w3.org/2000/09/xmldsig#dsa-sha1":
		case "http://www.w3.org/2000/09/xmldsig#rsa-sha1":
			return CryptoHelper.NewSha1HashAlgorithm();
		case "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256":
			return CryptoHelper.NewSha256HashAlgorithm();
		default:
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.UnsupportedCryptoAlgorithm, algorithm)));
		}
	}

	public override AsymmetricSignatureDeformatter GetSignatureDeformatter(string algorithm)
	{
		if (string.IsNullOrEmpty(algorithm))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(algorithm, System.SR.Format(System.SR.EmptyOrNullArgumentString, "algorithm"));
		}
		object algorithmFromConfig = CryptoHelper.GetAlgorithmFromConfig(algorithm);
		if (algorithmFromConfig != null)
		{
			if (algorithmFromConfig is SignatureDescription signatureDescription)
			{
				return signatureDescription.CreateDeformatter(PublicKey);
			}
			try
			{
				if (algorithmFromConfig is AsymmetricSignatureDeformatter asymmetricSignatureDeformatter)
				{
					asymmetricSignatureDeformatter.SetKey(PublicKey);
					return asymmetricSignatureDeformatter;
				}
			}
			catch (InvalidCastException innerException)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.AlgorithmAndPublicKeyMisMatch, innerException));
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CryptographicException(System.SR.Format(System.SR.UnsupportedAlgorithmForCryptoOperation, algorithm, "GetSignatureDeformatter")));
		}
		switch (algorithm)
		{
		case "http://www.w3.org/2000/09/xmldsig#dsa-sha1":
			if (!(PublicKey is DSA key2))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.PublicKeyNotDSA));
			}
			return new DSASignatureDeformatter(key2);
		case "http://www.w3.org/2000/09/xmldsig#rsa-sha1":
		case "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256":
			if (!(PublicKey is RSA key))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.PublicKeyNotRSA));
			}
			return new RSAPKCS1SignatureDeformatter(key);
		default:
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.UnsupportedCryptoAlgorithm, algorithm)));
		}
	}

	public override AsymmetricSignatureFormatter GetSignatureFormatter(string algorithm)
	{
		if (PrivateKey == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.MissingPrivateKey));
		}
		if (string.IsNullOrEmpty(algorithm))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(algorithm, System.SR.Format(System.SR.EmptyOrNullArgumentString, "algorithm"));
		}
		AsymmetricAlgorithm privateKey = PrivateKey;
		object algorithmFromConfig = CryptoHelper.GetAlgorithmFromConfig(algorithm);
		if (algorithmFromConfig != null)
		{
			if (algorithmFromConfig is SignatureDescription signatureDescription)
			{
				return signatureDescription.CreateFormatter(privateKey);
			}
			try
			{
				if (algorithmFromConfig is AsymmetricSignatureFormatter asymmetricSignatureFormatter)
				{
					asymmetricSignatureFormatter.SetKey(privateKey);
					return asymmetricSignatureFormatter;
				}
			}
			catch (InvalidCastException innerException)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.AlgorithmAndPrivateKeyMisMatch, innerException));
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new CryptographicException(System.SR.Format(System.SR.UnsupportedAlgorithmForCryptoOperation, algorithm, "GetSignatureFormatter")));
		}
		switch (algorithm)
		{
		case "http://www.w3.org/2000/09/xmldsig#dsa-sha1":
			if (!(PrivateKey is DSA key3))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.PrivateKeyNotDSA));
			}
			return new DSASignatureFormatter(key3);
		case "http://www.w3.org/2000/09/xmldsig#rsa-sha1":
			if (!(PrivateKey is RSA key2))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.PrivateKeyNotRSA));
			}
			return new RSAPKCS1SignatureFormatter(key2);
		case "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256":
			if (!(privateKey is RSA key))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.PrivateKeyNotRSA));
			}
			return new RSAPKCS1SignatureFormatter(key);
		default:
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException(System.SR.Format(System.SR.UnsupportedCryptoAlgorithm, algorithm)));
		}
	}

	public override bool HasPrivateKey()
	{
		return PrivateKey != null;
	}

	public override bool IsAsymmetricAlgorithm(string algorithm)
	{
		if (string.IsNullOrEmpty(algorithm))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(algorithm, System.SR.Format(System.SR.EmptyOrNullArgumentString, "algorithm"));
		}
		return CryptoHelper.IsAsymmetricAlgorithm(algorithm);
	}

	public override bool IsSupportedAlgorithm(string algorithm)
	{
		if (string.IsNullOrEmpty(algorithm))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument(algorithm, System.SR.Format(System.SR.EmptyOrNullArgumentString, "algorithm"));
		}
		object obj = null;
		try
		{
			obj = CryptoHelper.GetAlgorithmFromConfig(algorithm);
		}
		catch (InvalidOperationException)
		{
			algorithm = null;
		}
		if (obj != null)
		{
			if (obj is SignatureDescription)
			{
				return true;
			}
			if (obj is AsymmetricAlgorithm)
			{
				return true;
			}
			return false;
		}
		switch (algorithm)
		{
		case "http://www.w3.org/2000/09/xmldsig#dsa-sha1":
			return PublicKey is DSA;
		case "http://www.w3.org/2000/09/xmldsig#rsa-sha1":
		case "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256":
		case "http://www.w3.org/2001/04/xmlenc#rsa-1_5":
		case "http://www.w3.org/2001/04/xmlenc#rsa-oaep-mgf1p":
			return PublicKey is RSA;
		default:
			return false;
		}
	}

	public override bool IsSymmetricAlgorithm(string algorithm)
	{
		return CryptoHelper.IsSymmetricAlgorithm(algorithm);
	}
}
