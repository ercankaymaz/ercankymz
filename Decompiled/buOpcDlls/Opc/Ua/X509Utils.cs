using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Opc.Ua.Security.Certificates;

namespace Opc.Ua;

[ComVisible(true)]
public static class X509Utils
{
	public static IList<string> GetDomainsFromCertficate(X509Certificate2 certificate)
	{
		List<string> list = new List<string>();
		List<string> list2 = ParseDistinguishedName(certificate.Subject);
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < list2.Count; i++)
		{
			if (list2[i].StartsWith("DC="))
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append('.');
				}
				stringBuilder.Append(list2[i].Substring(3));
			}
		}
		if (stringBuilder.Length > 0)
		{
			list.Add(stringBuilder.ToString().ToUpperInvariant());
		}
		X509SubjectAltNameExtension x509SubjectAltNameExtension = certificate.FindExtension<X509SubjectAltNameExtension>();
		if (x509SubjectAltNameExtension != null)
		{
			for (int j = 0; j < x509SubjectAltNameExtension.DomainNames.Count; j++)
			{
				string text = x509SubjectAltNameExtension.DomainNames[j];
				bool flag = false;
				for (int k = 0; k < list.Count; k++)
				{
					if (string.Equals(list[k], text, StringComparison.OrdinalIgnoreCase))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					list.Add(text.ToUpperInvariant());
				}
			}
			for (int l = 0; l < x509SubjectAltNameExtension.IPAddresses.Count; l++)
			{
				string item = x509SubjectAltNameExtension.IPAddresses[l];
				if (!list.Contains(item))
				{
					list.Add(item);
				}
			}
		}
		return list;
	}

	public static int GetRSAPublicKeySize(X509Certificate2 certificate)
	{
		using RSA rSA = certificate.GetRSAPublicKey();
		return rSA?.KeySize ?? (-1);
	}

	public static string GetApplicationUriFromCertificate(X509Certificate2 certificate)
	{
		X509SubjectAltNameExtension x509SubjectAltNameExtension = certificate.FindExtension<X509SubjectAltNameExtension>();
		if (x509SubjectAltNameExtension != null && x509SubjectAltNameExtension.Uris.Count > 0)
		{
			return x509SubjectAltNameExtension.Uris[0];
		}
		return string.Empty;
	}

	public static bool HasApplicationURN(X509Certificate2 certificate)
	{
		X509SubjectAltNameExtension x509SubjectAltNameExtension = certificate.FindExtension<X509SubjectAltNameExtension>();
		if (x509SubjectAltNameExtension != null && x509SubjectAltNameExtension.Uris.Count > 0)
		{
			string text = "urn:";
			for (int i = 0; i < x509SubjectAltNameExtension.Uris.Count; i++)
			{
				if (string.Compare(x509SubjectAltNameExtension.Uris[i], 0, text, 0, text.Length, StringComparison.OrdinalIgnoreCase) == 0)
				{
					return true;
				}
			}
		}
		return false;
	}

	public static bool DoesUrlMatchCertificate(X509Certificate2 certificate, Uri endpointUrl)
	{
		if (endpointUrl == null || certificate == null)
		{
			return false;
		}
		IList<string> domainsFromCertficate = GetDomainsFromCertficate(certificate);
		for (int i = 0; i < domainsFromCertficate.Count; i++)
		{
			if (string.Equals(domainsFromCertficate[i], endpointUrl.DnsSafeHost, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}

	public static bool IsIssuerAllowed(X509Certificate2 certificate)
	{
		return certificate.FindExtension<X509BasicConstraintsExtension>()?.CertificateAuthority ?? false;
	}

	public static bool IsCertificateAuthority(X509Certificate2 certificate)
	{
		return certificate.FindExtension<X509BasicConstraintsExtension>()?.CertificateAuthority ?? false;
	}

	public static X509KeyUsageFlags GetKeyUsage(X509Certificate2 cert)
	{
		X509KeyUsageFlags x509KeyUsageFlags = X509KeyUsageFlags.None;
		foreach (X509KeyUsageExtension item in cert.Extensions.OfType<X509KeyUsageExtension>())
		{
			x509KeyUsageFlags |= item.KeyUsages;
		}
		return x509KeyUsageFlags;
	}

	public static bool IsSelfSigned(X509Certificate2 certificate)
	{
		return CompareDistinguishedName(certificate.SubjectName, certificate.IssuerName);
	}

	public static bool CompareDistinguishedName(X500DistinguishedName name1, X500DistinguishedName name2)
	{
		return Utils.IsEqual(name1.RawData, name2.RawData);
	}

	public static bool CompareDistinguishedName(string name1, string name2)
	{
		if (string.Equals(name1, name2, StringComparison.Ordinal))
		{
			return true;
		}
		List<string> list = ParseDistinguishedName(name1);
		List<string> list2 = ParseDistinguishedName(name2);
		if (list.Count != list2.Count)
		{
			return false;
		}
		return CompareDistinguishedNameFields(list, list2);
	}

	private static bool CompareDistinguishedNameFields(IList<string> fields1, IList<string> fields2)
	{
		for (int i = 0; i < fields1.Count; i++)
		{
			StringComparison comparisonType = StringComparison.Ordinal;
			if (fields1[i].StartsWith("DC=", StringComparison.OrdinalIgnoreCase))
			{
				comparisonType = StringComparison.OrdinalIgnoreCase;
			}
			if (!string.Equals(fields1[i], fields2[i], comparisonType))
			{
				return false;
			}
		}
		return true;
	}

	public static bool CompareDistinguishedName(X509Certificate2 certificate, List<string> parsedName)
	{
		if (parsedName.Count == 0)
		{
			return false;
		}
		List<string> list = ParseDistinguishedName(certificate.Subject);
		if (parsedName.Count != list.Count)
		{
			return false;
		}
		return CompareDistinguishedNameFields(parsedName, list);
	}

	public static List<string> ParseDistinguishedName(string name)
	{
		List<string> list = new List<string>();
		if (string.IsNullOrEmpty(name))
		{
			return list;
		}
		char c = ',';
		bool flag = false;
		bool flag2 = false;
		for (int num = name.Length - 1; num >= 0; num--)
		{
			char c2 = name[num];
			if (c2 == '"')
			{
				flag2 = !flag2;
			}
			else if (!flag2 && c2 == '=')
			{
				num--;
				while (num >= 0 && char.IsWhiteSpace(name[num]))
				{
					num--;
				}
				while (num >= 0 && (char.IsLetterOrDigit(name[num]) || name[num] == '.'))
				{
					num--;
				}
				while (num >= 0 && char.IsWhiteSpace(name[num]))
				{
					num--;
				}
				if (num >= 0)
				{
					c = name[num];
				}
				break;
			}
		}
		StringBuilder stringBuilder = new StringBuilder();
		string value = null;
		string text = null;
		flag = false;
		for (int i = 0; i < name.Length; i++)
		{
			for (; i < name.Length && char.IsWhiteSpace(name[i]); i++)
			{
			}
			if (i >= name.Length)
			{
				break;
			}
			char c3 = name[i];
			if (flag)
			{
				char c4 = c;
				if (i < name.Length && name[i] == '"')
				{
					i++;
					c4 = '"';
				}
				for (; i < name.Length; i++)
				{
					c3 = name[i];
					if (c3 == c4)
					{
						for (; i < name.Length && name[i] != c; i++)
						{
						}
						break;
					}
					stringBuilder.Append(c3);
				}
				text = stringBuilder.ToString().TrimEnd();
				flag = false;
				stringBuilder.Length = 0;
				stringBuilder.Append(value);
				stringBuilder.Append('=');
				if (text.IndexOfAny(new char[3] { '/', ',', '=' }) != -1)
				{
					if (text.Length > 0 && text[0] != '"')
					{
						stringBuilder.Append('"');
					}
					stringBuilder.Append(text);
					if (text.Length > 0 && text[text.Length - 1] != '"')
					{
						stringBuilder.Append('"');
					}
				}
				else
				{
					stringBuilder.Append(text);
				}
				list.Add(stringBuilder.ToString());
				stringBuilder.Length = 0;
				continue;
			}
			for (; i < name.Length; i++)
			{
				c3 = name[i];
				if (c3 == '=')
				{
					break;
				}
				stringBuilder.Append(c3);
			}
			value = stringBuilder.ToString().TrimEnd().ToUpperInvariant();
			stringBuilder.Length = 0;
			flag = true;
		}
		return list;
	}

	public static bool VerifyRSAKeyPair(X509Certificate2 certWithPublicKey, X509Certificate2 certWithPrivateKey, bool throwOnError = false)
	{
		return X509PfxUtils.VerifyRSAKeyPair(certWithPublicKey, certWithPrivateKey, throwOnError);
	}

	public static bool VerifySelfSigned(X509Certificate2 cert)
	{
		try
		{
			return new X509Signature(cert.RawData).Verify(cert);
		}
		catch
		{
			return false;
		}
	}

	public static X509Certificate2 CreateCertificateFromPKCS12(byte[] rawData, string password)
	{
		return X509PfxUtils.CreateCertificateFromPKCS12(rawData, password);
	}

	public static async Task<X509Certificate2> FindIssuerCABySerialNumberAsync(ICertificateStore store, X500DistinguishedName issuer, string serialnumber)
	{
		X509Certificate2Enumerator enumerator = (await store.Enumerate().ConfigureAwait(continueOnCapturedContext: false)).GetEnumerator();
		while (enumerator.MoveNext())
		{
			X509Certificate2 current = enumerator.Current;
			if (CompareDistinguishedName(current.SubjectName, issuer) && Utils.IsEqual(current.SerialNumber, serialnumber))
			{
				return current;
			}
		}
		return null;
	}

	public static X509Certificate2 AddToStore(this X509Certificate2 certificate, string storeType, string storePath, string password = null)
	{
		if (!string.IsNullOrEmpty(storePath) && !string.IsNullOrEmpty(storeType))
		{
			using ICertificateStore certificateStore = CertificateStoreIdentifier.CreateStore(storeType);
			if (certificateStore == null)
			{
				throw new ArgumentException("Invalid store type");
			}
			certificateStore.Open(storePath, noPrivateKeys: false);
			certificateStore.Add(certificate, password).Wait();
			certificateStore.Close();
		}
		return certificate;
	}

	public static async Task<X509Certificate2> AddToStoreAsync(this X509Certificate2 certificate, string storeType, string storePath, string password = null, CancellationToken ct = default(CancellationToken))
	{
		if (!string.IsNullOrEmpty(storePath) && !string.IsNullOrEmpty(storeType))
		{
			using ICertificateStore store = CertificateStoreIdentifier.CreateStore(storeType);
			if (store == null)
			{
				throw new ArgumentException("Invalid store type");
			}
			store.Open(storePath, noPrivateKeys: false);
			await store.Add(certificate, password).ConfigureAwait(continueOnCapturedContext: false);
			store.Close();
		}
		return certificate;
	}

	public static HashAlgorithmName GetRSAHashAlgorithmName(uint hashSizeInBits)
	{
		if (hashSizeInBits <= 160)
		{
			return HashAlgorithmName.SHA1;
		}
		if (hashSizeInBits <= 256)
		{
			return HashAlgorithmName.SHA256;
		}
		if (hashSizeInBits <= 384)
		{
			return HashAlgorithmName.SHA384;
		}
		return HashAlgorithmName.SHA512;
	}

	internal static string GeneratePasscode()
	{
		return Convert.ToBase64String(Utils.Nonce.CreateNonce(18u));
	}
}
