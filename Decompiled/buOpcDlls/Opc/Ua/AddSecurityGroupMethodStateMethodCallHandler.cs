using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult AddSecurityGroupMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, string securityGroupName, double keyLifetime, string securityPolicyUri, uint maxFutureKeyCount, uint maxPastKeyCount, ref string securityGroupId, ref NodeId securityGroupNodeId);
