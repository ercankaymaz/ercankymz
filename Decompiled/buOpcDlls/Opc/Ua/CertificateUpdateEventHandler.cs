using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate void CertificateUpdateEventHandler(CertificateValidator sender, CertificateUpdateEventArgs e);
