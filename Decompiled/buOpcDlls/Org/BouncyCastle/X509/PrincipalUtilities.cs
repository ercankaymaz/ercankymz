using Org.BouncyCastle.Asn1.X509;

namespace Org.BouncyCastle.X509;

public class PrincipalUtilities
{
	public static X509Name GetIssuerX509Principal(X509Certificate cert)
	{
		return cert.CertificateStructure.TbsCertificate.Issuer;
	}

	public static X509Name GetSubjectX509Principal(X509Certificate cert)
	{
		return cert.CertificateStructure.TbsCertificate.Subject;
	}

	public static X509Name GetIssuerX509Principal(X509Crl crl)
	{
		return crl.CertificateList.TbsCertList.Issuer;
	}
}
