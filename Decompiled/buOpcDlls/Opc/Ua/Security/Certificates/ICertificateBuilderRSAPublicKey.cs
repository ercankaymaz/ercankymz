using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public interface ICertificateBuilderRSAPublicKey
{
	ICertificateBuilderCreateForRSAAny SetRSAPublicKey(byte[] publicKey);

	ICertificateBuilderCreateForRSAAny SetRSAPublicKey(RSA publicKey);
}
