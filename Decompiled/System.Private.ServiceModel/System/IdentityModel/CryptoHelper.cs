using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography;
using System.ServiceModel;

namespace System.IdentityModel;

internal static class CryptoHelper
{
	private static RandomNumberGenerator s_random;

	private const string SHAString = "SHA";

	private const string SHA1String = "SHA1";

	private const string SHA256String = "SHA256";

	private const string SystemSecurityCryptographySha1String = "System.Security.Cryptography.SHA1";

	private static Dictionary<string, Func<object>> s_algorithmDelegateDictionary = new Dictionary<string, Func<object>>();

	private static object s_algorithmDictionaryLock = new object();

	internal static RandomNumberGenerator RandomNumberGenerator
	{
		get
		{
			if (s_random == null)
			{
				s_random = RandomNumberGenerator.Create();
			}
			return s_random;
		}
	}

	internal static bool IsSymmetricAlgorithm(string algorithm)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	internal static byte[] UnwrapKey(byte[] wrappingKey, byte[] wrappedKey, string algorithm)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	internal static byte[] WrapKey(byte[] wrappingKey, byte[] keyToBeWrapped, string algorithm)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	internal static byte[] GenerateDerivedKey(byte[] key, string algorithm, byte[] label, byte[] nonce, int derivedKeySize, int position)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	internal static int GetIVSize(string algorithm)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	internal static ICryptoTransform CreateDecryptor(byte[] key, byte[] iv, string algorithm)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	internal static ICryptoTransform CreateEncryptor(byte[] key, byte[] iv, string algorithm)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	internal static KeyedHashAlgorithm CreateKeyedHashAlgorithm(byte[] key, string algorithm)
	{
		object algorithmFromConfig = GetAlgorithmFromConfig(algorithm);
		if (algorithmFromConfig != null)
		{
			if (algorithmFromConfig is KeyedHashAlgorithm keyedHashAlgorithm)
			{
				keyedHashAlgorithm.Key = key;
				return keyedHashAlgorithm;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new InvalidOperationException(System.SR.Format(System.SR.CustomCryptoAlgorithmIsNotValidKeyedHashAlgorithm, algorithm)));
		}
		if (!(algorithm == "http://www.w3.org/2000/09/xmldsig#hmac-sha1"))
		{
			if (algorithm == "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256")
			{
				return new HMACSHA256(key);
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new InvalidOperationException(System.SR.Format(System.SR.UnsupportedCryptoAlgorithm, algorithm)));
		}
		return new HMACSHA1(key);
	}

	internal static SymmetricAlgorithm GetSymmetricAlgorithm(byte[] key, string algorithm)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	internal static bool IsAsymmetricAlgorithm(string algorithm)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	internal static bool IsSymmetricSupportedAlgorithm(string algorithm, int keySize)
	{
		bool flag = false;
		object obj = null;
		try
		{
			obj = GetAlgorithmFromConfig(algorithm);
		}
		catch (InvalidOperationException)
		{
		}
		if (obj != null)
		{
			SymmetricAlgorithm symmetricAlgorithm = obj as SymmetricAlgorithm;
			KeyedHashAlgorithm keyedHashAlgorithm = obj as KeyedHashAlgorithm;
			if (symmetricAlgorithm != null || keyedHashAlgorithm != null)
			{
				flag = true;
			}
		}
		switch (algorithm)
		{
		case "http://www.w3.org/2000/09/xmldsig#dsa-sha1":
		case "http://www.w3.org/2000/09/xmldsig#rsa-sha1":
		case "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256":
		case "http://www.w3.org/2001/04/xmlenc#rsa-oaep-mgf1p":
		case "http://www.w3.org/2001/04/xmlenc#rsa-1_5":
			return false;
		case "http://www.w3.org/2000/09/xmldsig#hmac-sha1":
		case "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256":
		case "http://schemas.xmlsoap.org/ws/2005/02/sc/dk/p_sha1":
		case "http://docs.oasis-open.org/ws-sx/ws-secureconversation/200512/dk/p_sha1":
			return true;
		case "http://www.w3.org/2001/04/xmlenc#aes128-cbc":
		case "http://www.w3.org/2001/04/xmlenc#kw-aes128":
			if (keySize >= 128)
			{
				return keySize <= 256;
			}
			return false;
		case "http://www.w3.org/2001/04/xmlenc#aes192-cbc":
		case "http://www.w3.org/2001/04/xmlenc#kw-aes192":
			if (keySize >= 192)
			{
				return keySize <= 256;
			}
			return false;
		case "http://www.w3.org/2001/04/xmlenc#aes256-cbc":
		case "http://www.w3.org/2001/04/xmlenc#kw-aes256":
			return keySize == 256;
		case "http://www.w3.org/2001/04/xmlenc#tripledes-cbc":
		case "http://www.w3.org/2001/04/xmlenc#kw-tripledes":
			if (keySize != 128)
			{
				return keySize == 192;
			}
			return true;
		default:
			if (flag)
			{
				return true;
			}
			return false;
		}
	}

	internal static void FillRandomBytes(byte[] buffer)
	{
		RandomNumberGenerator.GetBytes(buffer);
	}

	internal static HashAlgorithm CreateHashAlgorithm(string algorithm)
	{
		object algorithmFromConfig = GetAlgorithmFromConfig(algorithm);
		if (algorithmFromConfig != null)
		{
			if (algorithmFromConfig is HashAlgorithm result)
			{
				return result;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new InvalidOperationException(System.SR.Format(System.SR.CustomCryptoAlgorithmIsNotValidHashAlgorithm, algorithm)));
		}
		switch (algorithm)
		{
		case "SHA":
		case "SHA1":
		case "System.Security.Cryptography.SHA1":
		case "http://www.w3.org/2000/09/xmldsig#sha1":
			return SHA1.Create();
		case "SHA256":
		case "http://www.w3.org/2001/04/xmlenc#sha256":
			return SHA256.Create();
		default:
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperWarning(new InvalidOperationException(System.SR.Format(System.SR.UnsupportedCryptoAlgorithm, algorithm)));
		}
	}

	private static object GetDefaultAlgorithm(string algorithm)
	{
		if (string.IsNullOrEmpty(algorithm))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("algorithm"));
		}
		switch (algorithm)
		{
		case "http://www.w3.org/2000/09/xmldsig#sha1":
			return SHA1.Create();
		case "http://www.w3.org/2001/10/xml-exc-c14n#":
			throw ExceptionHelper.PlatformNotSupported();
		case "SHA256":
		case "http://www.w3.org/2001/04/xmlenc#sha256":
			return SHA256.Create();
		case "http://www.w3.org/2001/04/xmlenc#sha512":
			return SHA512.Create();
		case "http://www.w3.org/2001/04/xmlenc#aes128-cbc":
		case "http://www.w3.org/2001/04/xmlenc#aes192-cbc":
		case "http://www.w3.org/2001/04/xmlenc#aes256-cbc":
		case "http://www.w3.org/2001/04/xmlenc#kw-aes128":
		case "http://www.w3.org/2001/04/xmlenc#kw-aes192":
		case "http://www.w3.org/2001/04/xmlenc#kw-aes256":
			return Aes.Create();
		case "http://www.w3.org/2001/04/xmlenc#tripledes-cbc":
		case "http://www.w3.org/2001/04/xmlenc#kw-tripledes":
			return TripleDES.Create();
		case "http://www.w3.org/2000/09/xmldsig#hmac-sha1":
			return new HMACSHA1();
		case "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256":
			return new HMACSHA256();
		case "http://www.w3.org/2001/10/xml-exc-c14n#WithComments":
			throw ExceptionHelper.PlatformNotSupported();
		case "http://www.w3.org/2001/04/xmlenc#ripemd160":
			return null;
		case "http://www.w3.org/2001/04/xmlenc#des-cbc":
			return DES.Create();
		default:
			return null;
		}
	}

	internal static object GetAlgorithmFromConfig(string algorithm)
	{
		if (string.IsNullOrEmpty(algorithm))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("algorithm"));
		}
		object obj = null;
		object obj2 = null;
		Func<object> value = null;
		if (!s_algorithmDelegateDictionary.TryGetValue(algorithm, out value))
		{
			lock (s_algorithmDictionaryLock)
			{
				if (!s_algorithmDelegateDictionary.ContainsKey(algorithm))
				{
					try
					{
						obj = CryptoConfig.CreateFromName(algorithm);
					}
					catch (TargetInvocationException)
					{
						s_algorithmDelegateDictionary[algorithm] = null;
					}
					if (obj == null)
					{
						s_algorithmDelegateDictionary[algorithm] = null;
					}
					else
					{
						obj2 = GetDefaultAlgorithm(algorithm);
						if (obj2 == null || !(obj2.GetType() == obj.GetType()))
						{
							Type type = obj.GetType();
							NewExpression body = Expression.New(type);
							LambdaExpression lambdaExpression = Expression.Lambda<Func<object>>(body, Array.Empty<ParameterExpression>());
							if (lambdaExpression.Compile() is Func<object> value2)
							{
								s_algorithmDelegateDictionary[algorithm] = value2;
							}
							return obj;
						}
						s_algorithmDelegateDictionary[algorithm] = null;
					}
				}
			}
		}
		else if (value != null)
		{
			return value();
		}
		switch (algorithm)
		{
		case "SHA256":
		case "http://www.w3.org/2001/04/xmlenc#sha256":
			return SHA256.Create();
		case "http://www.w3.org/2000/09/xmldsig#sha1":
			return SHA1.Create();
		case "http://www.w3.org/2000/09/xmldsig#hmac-sha1":
			return new HMACSHA1();
		default:
			return null;
		}
	}

	internal static HashAlgorithm NewSha1HashAlgorithm()
	{
		return CreateHashAlgorithm("http://www.w3.org/2000/09/xmldsig#sha1");
	}

	internal static HashAlgorithm NewSha256HashAlgorithm()
	{
		return CreateHashAlgorithm("http://www.w3.org/2001/04/xmlenc#sha256");
	}

	internal static KeyedHashAlgorithm NewHmacSha1KeyedHashAlgorithm(byte[] key)
	{
		return CreateKeyedHashAlgorithm(key, "http://www.w3.org/2000/09/xmldsig#hmac-sha1");
	}
}
