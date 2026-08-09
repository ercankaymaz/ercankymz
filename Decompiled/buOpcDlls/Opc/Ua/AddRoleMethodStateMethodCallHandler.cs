using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult AddRoleMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, string roleName, string namespaceUri, ref NodeId roleNodeId);
