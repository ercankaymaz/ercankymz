using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua;

[ComVisible(true)]
public class SoftwareCertificate
{
	private X509Certificate2 m_signedCertificate;

	public X509Certificate2 SignedCertificate
	{
		get
		{
			return m_signedCertificate;
		}
		set
		{
			m_signedCertificate = value;
		}
	}

	public static ServiceResult Validate(CertificateValidator validator, byte[] signedCertificate, out SoftwareCertificate softwareCertificate)
	{
		softwareCertificate = null;
		X509Certificate2 x509Certificate = null;
		try
		{
			x509Certificate = CertificateFactory.Create(signedCertificate, useCache: true);
			validator.Validate(x509Certificate);
		}
		catch (Exception e)
		{
			return ServiceResult.Create(e, 2147942400u, "Could not decode software certificate body.");
		}
		byte[] array = null;
		if (array == null)
		{
			return ServiceResult.Create(2148663296u, "Could not find extension containing the software certficate.");
		}
		try
		{
			MemoryStream stream = new MemoryStream(array, writable: false);
			DataContractSerializer dataContractSerializer = new DataContractSerializer(typeof(SoftwareCertificate));
			softwareCertificate = (SoftwareCertificate)dataContractSerializer.ReadObject(stream);
			softwareCertificate.SignedCertificate = x509Certificate;
		}
		catch (Exception e2)
		{
			return ServiceResult.Create(e2, 2148663296u, "Certificate does not contain a valid SoftwareCertificate body.");
		}
		return ServiceResult.Good;
	}
}
