using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult GetSecurityGroupMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, string securityGroupId, ref NodeId securityGroupNodeId);
