using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public class RevokedCertificate
{
	public string SerialNumber => UserCertificate.ToHexString(invertEndian: true);

	public byte[] UserCertificate { get; }

	public DateTime RevocationDate { get; set; }

	public X509ExtensionCollection CrlEntryExtensions { get; }

	public RevokedCertificate(string serialNumber, CRLReason crlReason)
		: this(serialNumber)
	{
		CrlEntryExtensions.Add(X509Extensions.BuildX509CRLReason(crlReason));
	}

	public RevokedCertificate(byte[] serialNumber, CRLReason crlReason)
		: this(serialNumber)
	{
		if (crlReason != CRLReason.Unspecified)
		{
			CrlEntryExtensions.Add(X509Extensions.BuildX509CRLReason(crlReason));
		}
	}

	public RevokedCertificate(string serialNumber)
		: this()
	{
		UserCertificate = Enumerable.Reverse(serialNumber.FromHexString()).ToArray();
	}

	public RevokedCertificate(byte[] serialNumber)
		: this()
	{
		UserCertificate = serialNumber;
	}

	private RevokedCertificate()
	{
		RevocationDate = DateTime.UtcNow;
		CrlEntryExtensions = new X509ExtensionCollection();
	}
}
