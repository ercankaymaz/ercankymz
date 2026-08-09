using System.Runtime.InteropServices;

namespace Opc.Ua.Security.Certificates;

[ComVisible(true)]
public interface ICertificateBuilderRSAParameter
{
	ICertificateBuilderCreateForRSAAny SetRSAKeySize(ushort keySize);
}
