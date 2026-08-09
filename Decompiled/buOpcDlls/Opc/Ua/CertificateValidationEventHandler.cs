using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate void CertificateValidationEventHandler(CertificateValidator sender, CertificateValidationEventArgs e);
