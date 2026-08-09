using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult UpdateCertificateMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, NodeId certificateGroupId, NodeId certificateTypeId, byte[] certificate, byte[][] issuerCertificates, string privateKeyFormat, byte[] privateKey, ref bool applyChangesRequired);
