using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult CreateSigningRequestMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, NodeId certificateGroupId, NodeId certificateTypeId, string subjectName, bool regeneratePrivateKey, byte[] nonce, ref byte[] certificateRequest);
