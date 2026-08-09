using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult RemoveSecurityGroupMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, NodeId securityGroupNodeId);
