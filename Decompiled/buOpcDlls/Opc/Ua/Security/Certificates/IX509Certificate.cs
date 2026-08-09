using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public interface IX509Certificate
{
	X500DistinguishedName SubjectName { get; }

	X500DistinguishedName IssuerName { get; }

	DateTime NotBefore { get; }

	DateTime NotAfter { get; }

	string SerialNumber { get; }

	HashAlgorithmName HashAlgorithmName { get; }

	X509ExtensionCollection Extensions { get; }

	byte[] GetSerialNumber();
}
