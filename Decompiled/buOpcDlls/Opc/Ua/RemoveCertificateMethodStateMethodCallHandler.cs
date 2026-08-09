using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult RemoveCertificateMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, string thumbprint, bool isTrustedCertificate);
