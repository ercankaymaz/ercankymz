using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public interface ICertificateBuilderECCParameter
{
	ICertificateBuilderCreateForECDsaAny SetECCurve(ECCurve curve);
}
