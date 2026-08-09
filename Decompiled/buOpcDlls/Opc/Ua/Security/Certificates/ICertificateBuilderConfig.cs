using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public interface ICertificateBuilderConfig
{
	ICertificateBuilder SetSerialNumberLength(int length);

	ICertificateBuilder SetSerialNumber(byte[] serialNumber);

	ICertificateBuilder CreateSerialNumber();

	ICertificateBuilder SetNotBefore(DateTime notBefore);

	ICertificateBuilder SetNotAfter(DateTime notAfter);

	ICertificateBuilder SetLifeTime(TimeSpan lifeTime);

	ICertificateBuilder SetLifeTime(ushort months);

	ICertificateBuilder SetHashAlgorithm(HashAlgorithmName hashAlgorithmName);

	ICertificateBuilder SetCAConstraint(int pathLengthConstraint = -1);

	ICertificateBuilder AddExtension(X509Extension extension);
}
