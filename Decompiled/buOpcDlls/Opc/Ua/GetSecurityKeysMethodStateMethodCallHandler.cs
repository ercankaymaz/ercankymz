using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult GetSecurityKeysMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, string securityGroupId, uint startingTokenId, uint requestedKeyCount, ref string securityPolicyUri, ref uint firstTokenId, ref byte[][] keys, ref double timeToNextKey, ref double keyLifetime);
