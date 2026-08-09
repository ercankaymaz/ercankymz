using System.Collections.ObjectModel;
using System.IdentityModel.Tokens;
using System.Xml;

namespace System.ServiceModel.Security;

public abstract class SecurityAlgorithmSuite
{
	private static SecurityAlgorithmSuite s_basic256;

	private static SecurityAlgorithmSuite s_tripleDes;

	private static SecurityAlgorithmSuite s_basic256Sha256;

	public static SecurityAlgorithmSuite Default => Basic256;

	public static SecurityAlgorithmSuite Basic256
	{
		get
		{
			if (s_basic256 == null)
			{
				s_basic256 = new Basic256SecurityAlgorithmSuite();
			}
			return s_basic256;
		}
	}

	public static SecurityAlgorithmSuite TripleDes
	{
		get
		{
			if (s_tripleDes == null)
			{
				s_tripleDes = new TripleDesSecurityAlgorithmSuite();
			}
			return s_tripleDes;
		}
	}

	public static SecurityAlgorithmSuite Basic256Sha256
	{
		get
		{
			if (s_basic256Sha256 == null)
			{
				s_basic256Sha256 = new Basic256Sha256SecurityAlgorithmSuite();
			}
			return s_basic256Sha256;
		}
	}

	public abstract string DefaultCanonicalizationAlgorithm { get; }

	public abstract string DefaultDigestAlgorithm { get; }

	public abstract string DefaultEncryptionAlgorithm { get; }

	public abstract int DefaultEncryptionKeyDerivationLength { get; }

	public abstract string DefaultSymmetricKeyWrapAlgorithm { get; }

	public abstract string DefaultAsymmetricKeyWrapAlgorithm { get; }

	public abstract string DefaultSymmetricSignatureAlgorithm { get; }

	public abstract string DefaultAsymmetricSignatureAlgorithm { get; }

	public abstract int DefaultSignatureKeyDerivationLength { get; }

	public abstract int DefaultSymmetricKeyLength { get; }

	internal virtual XmlDictionaryString DefaultCanonicalizationAlgorithmDictionaryString => null;

	internal virtual XmlDictionaryString DefaultDigestAlgorithmDictionaryString => null;

	internal virtual XmlDictionaryString DefaultEncryptionAlgorithmDictionaryString => null;

	internal virtual XmlDictionaryString DefaultSymmetricKeyWrapAlgorithmDictionaryString => null;

	internal virtual XmlDictionaryString DefaultAsymmetricKeyWrapAlgorithmDictionaryString => null;

	internal virtual XmlDictionaryString DefaultSymmetricSignatureAlgorithmDictionaryString => null;

	internal virtual XmlDictionaryString DefaultAsymmetricSignatureAlgorithmDictionaryString => null;

	public virtual bool IsCanonicalizationAlgorithmSupported(string algorithm)
	{
		return algorithm == DefaultCanonicalizationAlgorithm;
	}

	public virtual bool IsDigestAlgorithmSupported(string algorithm)
	{
		return algorithm == DefaultDigestAlgorithm;
	}

	public virtual bool IsEncryptionAlgorithmSupported(string algorithm)
	{
		return algorithm == DefaultEncryptionAlgorithm;
	}

	public virtual bool IsEncryptionKeyDerivationAlgorithmSupported(string algorithm)
	{
		if (!(algorithm == "http://schemas.xmlsoap.org/ws/2005/02/sc/dk/p_sha1"))
		{
			return algorithm == "http://docs.oasis-open.org/ws-sx/ws-secureconversation/200512/dk/p_sha1";
		}
		return true;
	}

	public virtual bool IsSymmetricKeyWrapAlgorithmSupported(string algorithm)
	{
		return algorithm == DefaultSymmetricKeyWrapAlgorithm;
	}

	public virtual bool IsAsymmetricKeyWrapAlgorithmSupported(string algorithm)
	{
		return algorithm == DefaultAsymmetricKeyWrapAlgorithm;
	}

	public virtual bool IsSymmetricSignatureAlgorithmSupported(string algorithm)
	{
		return algorithm == DefaultSymmetricSignatureAlgorithm;
	}

	public virtual bool IsAsymmetricSignatureAlgorithmSupported(string algorithm)
	{
		return algorithm == DefaultAsymmetricSignatureAlgorithm;
	}

	public virtual bool IsSignatureKeyDerivationAlgorithmSupported(string algorithm)
	{
		if (!(algorithm == "http://schemas.xmlsoap.org/ws/2005/02/sc/dk/p_sha1"))
		{
			return algorithm == "http://docs.oasis-open.org/ws-sx/ws-secureconversation/200512/dk/p_sha1";
		}
		return true;
	}

	public abstract bool IsSymmetricKeyLengthSupported(int length);

	public abstract bool IsAsymmetricKeyLengthSupported(int length);

	internal void GetSignatureAlgorithmAndKey(SecurityToken token, out string signatureAlgorithm, out SecurityKey key, out XmlDictionaryString signatureAlgorithmDictionaryString)
	{
		ReadOnlyCollection<SecurityKey> securityKeys = token.SecurityKeys;
		if (securityKeys == null || securityKeys.Count == 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SigningTokenHasNoKeys, token)));
		}
		for (int i = 0; i < securityKeys.Count; i++)
		{
			if (securityKeys[i].IsSupportedAlgorithm(DefaultSymmetricSignatureAlgorithm))
			{
				signatureAlgorithm = DefaultSymmetricSignatureAlgorithm;
				signatureAlgorithmDictionaryString = DefaultSymmetricSignatureAlgorithmDictionaryString;
				key = securityKeys[i];
				return;
			}
			if (securityKeys[i].IsSupportedAlgorithm(DefaultAsymmetricSignatureAlgorithm))
			{
				signatureAlgorithm = DefaultAsymmetricSignatureAlgorithm;
				signatureAlgorithmDictionaryString = DefaultAsymmetricSignatureAlgorithmDictionaryString;
				key = securityKeys[i];
				return;
			}
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SigningTokenHasNoKeysSupportingTheAlgorithmSuite, token, this)));
	}
}
