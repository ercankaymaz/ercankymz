using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface ICertificatePasswordProvider
{
	string GetPassword(CertificateIdentifier certificateIdentifier);
}
