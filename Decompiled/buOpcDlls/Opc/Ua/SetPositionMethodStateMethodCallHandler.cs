using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult SetPositionMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, uint fileHandle, ulong position);
