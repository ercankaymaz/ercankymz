using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public delegate void ReportAuditCertificateEventHandler(X509Certificate2 clientCertificate, Exception exception);
