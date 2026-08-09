using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Opc.Ua;

[ComVisible(true)]
public interface ICertificateValidator
{
	void Validate(X509Certificate2 certificate);

	void Validate(X509Certificate2Collection certificateChain);

	Task ValidateAsync(X509Certificate2 certificate, CancellationToken ct);

	Task ValidateAsync(X509Certificate2Collection certificateChain, CancellationToken ct);
}
