using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;

namespace System.IdentityModel.Tokens;

public class X509SubjectKeyIdentifierClause : BinaryKeyIdentifierClause
{
	private const string SubjectKeyIdentifierOid = "2.5.29.14";

	private const int SkiDataOffset = 2;

	public X509SubjectKeyIdentifierClause(byte[] ski)
		: this(ski, cloneBuffer: true)
	{
	}

	internal X509SubjectKeyIdentifierClause(byte[] ski, bool cloneBuffer)
		: base(null, ski, cloneBuffer)
	{
	}

	private static byte[] GetSkiRawData(X509Certificate2 certificate)
	{
		if (certificate == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("certificate");
		}
		if (certificate.Extensions["2.5.29.14"] is X509SubjectKeyIdentifierExtension x509SubjectKeyIdentifierExtension)
		{
			return x509SubjectKeyIdentifierExtension.RawData;
		}
		return null;
	}

	public byte[] GetX509SubjectKeyIdentifier()
	{
		return GetBuffer();
	}

	public bool Matches(X509Certificate2 certificate)
	{
		if (certificate == null)
		{
			return false;
		}
		byte[] skiRawData = GetSkiRawData(certificate);
		if (skiRawData != null)
		{
			return Matches(skiRawData, 2);
		}
		return false;
	}

	public static bool TryCreateFrom(X509Certificate2 certificate, out X509SubjectKeyIdentifierClause keyIdentifierClause)
	{
		byte[] skiRawData = GetSkiRawData(certificate);
		keyIdentifierClause = null;
		if (skiRawData != null)
		{
			byte[] ski = SecurityUtils.CloneBuffer(skiRawData, 2, skiRawData.Length - 2);
			keyIdentifierClause = new X509SubjectKeyIdentifierClause(ski, cloneBuffer: false);
		}
		return keyIdentifierClause != null;
	}

	public static bool CanCreateFrom(X509Certificate2 certificate)
	{
		return GetSkiRawData(certificate) != null;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "X509SubjectKeyIdentifierClause(SKI = 0x{0})", ToHexString());
	}
}
