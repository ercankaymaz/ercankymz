using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult DataSetReaderTypeCreateDataSetMirrorMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, string parentNodeName, RolePermissionType[] rolePermissions, ref NodeId parentNodeId);
