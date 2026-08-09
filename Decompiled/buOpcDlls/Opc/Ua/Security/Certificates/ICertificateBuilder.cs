using System.Runtime.InteropServices;

namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public interface ICertificateBuilder : ICertificateBuilderConfig, ICertificateBuilderPublicKey, ICertificateBuilderRSAPublicKey, ICertificateBuilderECDsaPublicKey, ICertificateBuilderSetIssuer, ICertificateBuilderParameter, ICertificateBuilderRSAParameter, ICertificateBuilderECCParameter, ICertificateBuilderCreateForRSA, IX509Certificate
{
}
