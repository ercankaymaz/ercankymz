using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult DeleteFileMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, NodeId objectToDelete);
