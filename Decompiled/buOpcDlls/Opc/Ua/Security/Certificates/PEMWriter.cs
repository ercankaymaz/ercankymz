using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Opc.Ua.Security.Certificates.BouncyCastle;
using Org.BouncyCastle.Pkcs;

namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public static class PEMWriter
{
	public static byte[] ExportPrivateKeyAsPEM(X509Certificate2 certificate, string password = null)
	{
		if (!string.IsNullOrEmpty(password))
		{
			throw new ArgumentException("Export with password not supported on this platform.", "password");
		}
		return EncodeAsPEM(PrivateKeyInfoFactory.CreatePrivateKeyInfo(Opc.Ua.Security.Certificates.BouncyCastle.X509Utils.GetPrivateKeyParameter(certificate)).ToAsn1Object().GetDerEncoded(), "PRIVATE KEY");
	}

	public static byte[] ExportCRLAsPEM(byte[] crl)
	{
		return EncodeAsPEM(crl, "X509 CRL");
	}

	public static byte[] ExportCSRAsPEM(byte[] csr)
	{
		return EncodeAsPEM(csr, "CERTIFICATE REQUEST");
	}

	public static byte[] ExportCertificateAsPEM(X509Certificate2 certificate)
	{
		return EncodeAsPEM(certificate.RawData, "CERTIFICATE");
	}

	private static byte[] EncodeAsPEM(byte[] content, string contentType)
	{
		if (content == null)
		{
			throw new ArgumentNullException("content");
		}
		if (string.IsNullOrEmpty(contentType))
		{
			throw new ArgumentNullException("contentType");
		}
		string text = Convert.ToBase64String(content);
		using TextWriter textWriter = new StringWriter();
		textWriter.WriteLine("-----BEGIN {0}-----", contentType);
		while (text.Length > 64)
		{
			textWriter.WriteLine(text.Substring(0, 64));
			text = text.Substring(64);
		}
		textWriter.WriteLine(text);
		textWriter.WriteLine("-----END {0}-----", contentType);
		return Encoding.ASCII.GetBytes(textWriter.ToString());
	}
}
