using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult KeyCredentialUpdateMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, string credentialId, byte[] credentialSecret, string certificateThumbprint, string securityPolicyUri);
