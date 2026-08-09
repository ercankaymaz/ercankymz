using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public interface ICertificateBuilderSetIssuer
{
	ICertificateBuilderIssuer SetIssuer(X509Certificate2 issuerCertificate);
}
