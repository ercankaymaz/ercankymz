using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua;

[ComVisible(true)]
public interface ITransportListener : IDisposable
{
	string UriScheme { get; }

	event ConnectionWaitingHandlerAsync ConnectionWaiting;

	event EventHandler<ConnectionStatusEventArgs> ConnectionStatusChanged;

	void Open(Uri baseAddress, TransportListenerSettings settings, ITransportListenerCallback callback);

	void Close();

	void CertificateUpdate(ICertificateValidator validator, X509Certificate2 serverCertificate, X509Certificate2Collection serverCertificateChain);

	void CreateReverseConnection(Uri url, int timeout);
}
