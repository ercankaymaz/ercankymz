using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult AddCertificateMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, byte[] certificate, bool isTrustedCertificate);
