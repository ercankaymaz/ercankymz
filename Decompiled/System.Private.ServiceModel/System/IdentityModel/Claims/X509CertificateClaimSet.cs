using System.Collections.Generic;
using System.IdentityModel.Policy;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.ServiceModel;

namespace System.IdentityModel.Claims;

public class X509CertificateClaimSet : ClaimSet, IIdentityInfo, IDisposable
{
	private class X500DistinguishedNameClaimSet : DefaultClaimSet, IIdentityInfo
	{
		public IIdentity Identity { get; }

		public X500DistinguishedNameClaimSet(X500DistinguishedName x500DistinguishedName)
		{
			if (x500DistinguishedName == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("x500DistinguishedName");
			}
			Identity = new X509Identity(x500DistinguishedName);
			List<Claim> claims = new List<Claim>(2)
			{
				new Claim(ClaimTypes.X500DistinguishedName, x500DistinguishedName, Rights.Identity),
				Claim.CreateX500DistinguishedNameClaim(x500DistinguishedName)
			};
			Initialize(ClaimSet.Anonymous, claims);
		}
	}

	private static class X509SubjectAlternativeNameConstants
	{
		public const string Oid = "2.5.29.17";

		private static readonly string s_identifier;

		private static readonly char s_delimiter;

		private static readonly string s_separator;

		private static bool s_successfullyInitialized;

		private static Exception s_initializationException;

		public static string Identifier
		{
			get
			{
				EnsureInitialized();
				return s_identifier;
			}
		}

		public static char Delimiter
		{
			get
			{
				EnsureInitialized();
				return s_delimiter;
			}
		}

		public static string Separator
		{
			get
			{
				EnsureInitialized();
				return s_separator;
			}
		}

		private static void EnsureInitialized()
		{
			if (!s_successfullyInitialized)
			{
				throw new FormatException($"There was an error detecting the identifier, delimiter, and separator for X509CertificateClaims on this platform.{Environment.NewLine}Detected values were: Identifier: '{s_identifier}'; Delimiter:'{s_delimiter}'; Separator:'{s_separator}'", s_initializationException);
			}
		}

		static X509SubjectAlternativeNameConstants()
		{
			byte[] rawData = new byte[38]
			{
				48, 36, 130, 21, 110, 111, 116, 45, 114, 101,
				97, 108, 45, 115, 117, 98, 106, 101, 99, 116,
				45, 110, 97, 109, 101, 130, 11, 101, 120, 97,
				109, 112, 108, 101, 46, 99, 111, 109
			};
			try
			{
				X509Extension x509Extension = new X509Extension("2.5.29.17", rawData, critical: true);
				string text = x509Extension.Format(multiLine: false);
				int num = text.IndexOf("not-real-subject-name") - 1;
				s_delimiter = text[num];
				s_identifier = text.Substring(0, num);
				int num2 = num + "not-real-subject-name".Length + 1;
				int num3 = 1;
				for (int i = num2 + 1; i < text.Length && text[i] != s_identifier[0]; i++)
				{
					num3++;
				}
				s_separator = text.Substring(num2, num3);
				s_successfullyInitialized = true;
			}
			catch (Exception ex)
			{
				s_successfullyInitialized = false;
				s_initializationException = ex;
			}
		}
	}

	private X509Certificate2 _certificate;

	private DateTime _expirationTime = SecurityUtils.MinUtcDateTime;

	private ClaimSet _issuer;

	private X509Identity _identity;

	private X509ChainElementCollection _elements;

	private IList<Claim> _claims;

	private int _index;

	private bool _disposed;

	public override Claim this[int index]
	{
		get
		{
			ThrowIfDisposed();
			EnsureClaims();
			return _claims[index];
		}
	}

	public override int Count
	{
		get
		{
			ThrowIfDisposed();
			EnsureClaims();
			return _claims.Count;
		}
	}

	IIdentity IIdentityInfo.Identity
	{
		get
		{
			ThrowIfDisposed();
			if (_identity == null)
			{
				_identity = new X509Identity(_certificate, clone: false, disposable: false);
			}
			return _identity;
		}
	}

	public DateTime ExpirationTime
	{
		get
		{
			ThrowIfDisposed();
			if (_expirationTime == SecurityUtils.MinUtcDateTime)
			{
				_expirationTime = _certificate.NotAfter.ToUniversalTime();
			}
			return _expirationTime;
		}
	}

	public override ClaimSet Issuer
	{
		get
		{
			ThrowIfDisposed();
			if (_issuer == null)
			{
				if (_elements == null)
				{
					X509Chain x509Chain = new X509Chain();
					x509Chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
					x509Chain.Build(_certificate);
					_index = 0;
					_elements = x509Chain.ChainElements;
				}
				if (_index + 1 < _elements.Count)
				{
					_issuer = new X509CertificateClaimSet(_elements, _index + 1);
					_elements = null;
				}
				else if (StringComparer.OrdinalIgnoreCase.Equals(_certificate.SubjectName.Name, _certificate.IssuerName.Name))
				{
					_issuer = this;
				}
				else
				{
					_issuer = new X500DistinguishedNameClaimSet(_certificate.IssuerName);
				}
			}
			return _issuer;
		}
	}

	public X509Certificate2 X509Certificate
	{
		get
		{
			ThrowIfDisposed();
			return _certificate;
		}
	}

	public X509CertificateClaimSet(X509Certificate2 certificate)
		: this(certificate, clone: true)
	{
	}

	internal X509CertificateClaimSet(X509Certificate2 certificate, bool clone)
	{
		if (certificate == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("certificate");
		}
		_certificate = (clone ? new X509Certificate2(certificate) : certificate);
	}

	private X509CertificateClaimSet(X509CertificateClaimSet from)
		: this(from.X509Certificate, clone: true)
	{
	}

	private X509CertificateClaimSet(X509ChainElementCollection elements, int index)
	{
		_elements = elements;
		_index = index;
		_certificate = elements[index].Certificate;
	}

	internal X509CertificateClaimSet Clone()
	{
		ThrowIfDisposed();
		return new X509CertificateClaimSet(this);
	}

	public void Dispose()
	{
		if (_disposed)
		{
			return;
		}
		_disposed = true;
		SecurityUtils.DisposeIfNecessary(_identity);
		if (_issuer != null && _issuer != this)
		{
			SecurityUtils.DisposeIfNecessary(_issuer as IDisposable);
		}
		if (_elements != null)
		{
			for (int i = _index + 1; i < _elements.Count; i++)
			{
				SecurityUtils.ResetCertificate(_elements[i].Certificate);
			}
		}
		SecurityUtils.ResetCertificate(_certificate);
	}

	private IList<Claim> InitializeClaimsCore()
	{
		List<Claim> list = new List<Claim>();
		byte[] certHash = _certificate.GetCertHash();
		list.Add(new Claim(ClaimTypes.Thumbprint, certHash, Rights.Identity));
		list.Add(new Claim(ClaimTypes.Thumbprint, certHash, Rights.PossessProperty));
		string name = _certificate.SubjectName.Name;
		if (!string.IsNullOrEmpty(name))
		{
			list.Add(Claim.CreateX500DistinguishedNameClaim(_certificate.SubjectName));
		}
		string[] dnsFromExtensions = GetDnsFromExtensions(_certificate);
		if (dnsFromExtensions.Length != 0)
		{
			for (int i = 0; i < dnsFromExtensions.Length; i++)
			{
				list.Add(Claim.CreateDnsClaim(dnsFromExtensions[i]));
			}
		}
		else
		{
			name = _certificate.GetNameInfo(X509NameType.DnsName, forIssuer: false);
			if (!string.IsNullOrEmpty(name))
			{
				list.Add(Claim.CreateDnsClaim(name));
			}
		}
		name = _certificate.GetNameInfo(X509NameType.SimpleName, forIssuer: false);
		if (!string.IsNullOrEmpty(name))
		{
			list.Add(Claim.CreateNameClaim(name));
		}
		name = _certificate.GetNameInfo(X509NameType.UpnName, forIssuer: false);
		if (!string.IsNullOrEmpty(name))
		{
			list.Add(Claim.CreateUpnClaim(name));
		}
		name = _certificate.GetNameInfo(X509NameType.UrlName, forIssuer: false);
		if (!string.IsNullOrEmpty(name))
		{
			list.Add(Claim.CreateUriClaim(new Uri(name)));
		}
		return list;
	}

	private void EnsureClaims()
	{
		if (_claims == null)
		{
			_claims = InitializeClaimsCore();
		}
	}

	private static bool SupportedClaimType(string claimType)
	{
		if (claimType != null && !ClaimTypes.Thumbprint.Equals(claimType) && !ClaimTypes.X500DistinguishedName.Equals(claimType) && !ClaimTypes.Dns.Equals(claimType) && !ClaimTypes.Name.Equals(claimType) && !ClaimTypes.Email.Equals(claimType) && !ClaimTypes.Upn.Equals(claimType) && !ClaimTypes.Uri.Equals(claimType))
		{
			return ClaimTypes.Rsa.Equals(claimType);
		}
		return true;
	}

	public override IEnumerable<Claim> FindClaims(string claimType, string right)
	{
		ThrowIfDisposed();
		if (!SupportedClaimType(claimType) || !ClaimSet.SupportedRight(right))
		{
			yield break;
		}
		if (_claims == null && ClaimTypes.Thumbprint.Equals(claimType))
		{
			if (right == null || Rights.Identity.Equals(right))
			{
				yield return new Claim(ClaimTypes.Thumbprint, _certificate.GetCertHash(), Rights.Identity);
			}
			if (right == null || Rights.PossessProperty.Equals(right))
			{
				yield return new Claim(ClaimTypes.Thumbprint, _certificate.GetCertHash(), Rights.PossessProperty);
			}
			yield break;
		}
		int i;
		if (_claims == null && ClaimTypes.Dns.Equals(claimType))
		{
			if (right != null && !Rights.PossessProperty.Equals(right))
			{
				yield break;
			}
			string[] dnsEntries = GetDnsFromExtensions(_certificate);
			if (dnsEntries.Length != 0)
			{
				i = 0;
				while (i < dnsEntries.Length)
				{
					yield return Claim.CreateDnsClaim(dnsEntries[i]);
					int num = i + 1;
					i = num;
				}
			}
			else
			{
				string nameInfo = _certificate.GetNameInfo(X509NameType.DnsName, forIssuer: false);
				if (!string.IsNullOrEmpty(nameInfo))
				{
					yield return Claim.CreateDnsClaim(nameInfo);
				}
			}
			yield break;
		}
		EnsureClaims();
		bool anyClaimType = claimType == null;
		bool anyRight = right == null;
		i = 0;
		while (i < _claims.Count)
		{
			Claim claim = _claims[i];
			if (claim != null && (anyClaimType || claimType.Equals(claim.ClaimType)) && (anyRight || right.Equals(claim.Right)))
			{
				yield return claim;
			}
			int num = i + 1;
			i = num;
		}
	}

	private static string[] GetDnsFromExtensions(X509Certificate2 cert)
	{
		X509ExtensionEnumerator enumerator = cert.Extensions.GetEnumerator();
		while (enumerator.MoveNext())
		{
			X509Extension current = enumerator.Current;
			if (!(current.Oid.Value == "2.5.29.17"))
			{
				continue;
			}
			string text = current.Format(multiLine: false);
			if (string.IsNullOrWhiteSpace(text))
			{
				return new string[0];
			}
			string[] array = text.Split(new string[1] { X509SubjectAlternativeNameConstants.Separator }, StringSplitOptions.RemoveEmptyEntries);
			List<string> list = new List<string>();
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(new char[1] { X509SubjectAlternativeNameConstants.Delimiter });
				if (string.Equals(array2[0], X509SubjectAlternativeNameConstants.Identifier))
				{
					list.Add(array2[1]);
				}
			}
			return list.ToArray();
		}
		return new string[0];
	}

	public override IEnumerator<Claim> GetEnumerator()
	{
		ThrowIfDisposed();
		EnsureClaims();
		return _claims.GetEnumerator();
	}

	public override string ToString()
	{
		if (!_disposed)
		{
			return SecurityUtils.ClaimSetToString(this);
		}
		return base.ToString();
	}

	private void ThrowIfDisposed()
	{
		if (_disposed)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ObjectDisposedException(GetType().FullName));
		}
	}
}
