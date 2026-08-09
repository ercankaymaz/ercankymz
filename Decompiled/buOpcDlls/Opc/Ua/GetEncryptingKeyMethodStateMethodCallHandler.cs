using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult GetEncryptingKeyMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, string credentialId, string requestedSecurityPolicyUri, ref byte[] publicKey, ref NodeId revisedSecurityPolicyUri);
