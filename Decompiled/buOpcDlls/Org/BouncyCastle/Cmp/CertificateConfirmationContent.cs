using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Cms;

namespace Org.BouncyCastle.Cmp;

public class CertificateConfirmationContent
{
	private readonly DefaultDigestAlgorithmIdentifierFinder m_digestAlgFinder;

	private readonly CertConfirmContent m_content;

	public CertificateConfirmationContent(CertConfirmContent content)
	{
		m_content = content;
	}

	public CertificateConfirmationContent(CertConfirmContent content, DefaultDigestAlgorithmIdentifierFinder digestAlgFinder)
	{
		m_content = content;
		m_digestAlgFinder = digestAlgFinder;
	}

	public CertConfirmContent ToAsn1Structure()
	{
		return m_content;
	}

	public CertificateStatus[] GetStatusMessages()
	{
		CertStatus[] array = m_content.ToCertStatusArray();
		CertificateStatus[] array2 = new CertificateStatus[array.Length];
		for (int i = 0; i != array2.Length; i++)
		{
			array2[i] = new CertificateStatus(m_digestAlgFinder, array[i]);
		}
		return array2;
	}
}
