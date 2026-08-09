using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public interface IX509CRL
{
	X500DistinguishedName IssuerName { get; }

	string Issuer { get; }

	DateTime ThisUpdate { get; }

	DateTime NextUpdate { get; }

	HashAlgorithmName HashAlgorithmName { get; }

	IList<RevokedCertificate> RevokedCertificates { get; }

	X509ExtensionCollection CrlExtensions { get; }

	byte[] RawData { get; }
}
