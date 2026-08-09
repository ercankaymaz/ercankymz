using System.Globalization;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Security;

namespace System.IdentityModel.Tokens;

public class X509IssuerSerialKeyIdentifierClause : SecurityKeyIdentifierClause
{
	private readonly string _issuerSerialNumber;

	public string IssuerName { get; }

	public string IssuerSerialNumber => _issuerSerialNumber;

	public X509IssuerSerialKeyIdentifierClause(string issuerName, string issuerSerialNumber)
		: base(null)
	{
		if (string.IsNullOrEmpty(issuerName))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("issuerName");
		}
		if (string.IsNullOrEmpty(issuerSerialNumber))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("issuerSerialNumber");
		}
		IssuerName = issuerName;
		_issuerSerialNumber = issuerSerialNumber;
	}

	public X509IssuerSerialKeyIdentifierClause(X509Certificate2 certificate)
		: base(null)
	{
		if (certificate == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("certificate");
		}
		IssuerName = certificate.Issuer;
		_issuerSerialNumber = certificate.GetSerialNumberString();
	}

	public override bool Matches(SecurityKeyIdentifierClause keyIdentifierClause)
	{
		X509IssuerSerialKeyIdentifierClause x509IssuerSerialKeyIdentifierClause = keyIdentifierClause as X509IssuerSerialKeyIdentifierClause;
		if (this != x509IssuerSerialKeyIdentifierClause)
		{
			return x509IssuerSerialKeyIdentifierClause?.Matches(IssuerName, _issuerSerialNumber) ?? false;
		}
		return true;
	}

	public bool Matches(X509Certificate2 certificate)
	{
		if (certificate == null)
		{
			return false;
		}
		return Matches(certificate.Issuer, certificate.GetSerialNumberString());
	}

	public bool Matches(string issuerName, string issuerSerialNumber)
	{
		if (issuerName == null)
		{
			return false;
		}
		if (_issuerSerialNumber != issuerSerialNumber)
		{
			return false;
		}
		if (IssuerName == issuerName)
		{
			return true;
		}
		bool result = false;
		try
		{
			if (System.ServiceModel.Security.SecurityUtils.IsEqual(new X500DistinguishedName(IssuerName).RawData, new X500DistinguishedName(issuerName).RawData))
			{
				result = true;
			}
		}
		catch (CryptographicException)
		{
		}
		return result;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "X509IssuerSerialKeyIdentifierClause(Issuer = '{0}', Serial = '{1}')", IssuerName, IssuerSerialNumber);
	}
}
