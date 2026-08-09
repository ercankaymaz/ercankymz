using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult SetSecurityKeysMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, string securityGroupId, string securityPolicyUri, uint currentTokenId, byte[] currentKey, byte[][] futureKeys, double timeToNextKey, double keyLifetime);
