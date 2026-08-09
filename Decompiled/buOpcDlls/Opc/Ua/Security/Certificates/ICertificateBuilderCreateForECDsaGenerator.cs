using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public interface ICertificateBuilderCreateForECDsaGenerator
{
	X509Certificate2 CreateForECDsa(X509SignatureGenerator generator);
}
