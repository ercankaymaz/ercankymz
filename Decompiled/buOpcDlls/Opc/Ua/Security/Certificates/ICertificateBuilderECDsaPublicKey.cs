using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public interface ICertificateBuilderECDsaPublicKey
{
	ICertificateBuilderCreateForECDsaAny SetECDsaPublicKey(byte[] publicKey);

	ICertificateBuilderCreateForECDsaAny SetECDsaPublicKey(ECDsa publicKey);
}
