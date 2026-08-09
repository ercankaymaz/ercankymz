using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua;

[ComVisible(true)]
public interface IAuditEventCallback
{
	void ReportAuditOpenSecureChannelEvent(string globalChannelId, EndpointDescription endpointDescription, OpenSecureChannelRequest request, X509Certificate2 clientCertificate, Exception exception);

	void ReportAuditCloseSecureChannelEvent(string globalChannelId, Exception exception);

	void ReportAuditCertificateEvent(X509Certificate2 clientCertificate, Exception exception);
}
