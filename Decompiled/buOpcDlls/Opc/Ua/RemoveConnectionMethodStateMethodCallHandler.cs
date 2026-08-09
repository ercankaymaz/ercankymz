using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult RemoveConnectionMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, NodeId connectionId);
