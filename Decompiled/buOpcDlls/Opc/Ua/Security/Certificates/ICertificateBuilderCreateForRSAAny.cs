using System.Runtime.InteropServices;

namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public interface ICertificateBuilderCreateForRSAAny : ICertificateBuilderCreateForRSA, ICertificateBuilderCreateForRSAGenerator
{
}
