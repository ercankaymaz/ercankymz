using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface ICertificateStoreType
{
	bool SupportsStorePath(string storePath);

	ICertificateStore CreateStore();
}
