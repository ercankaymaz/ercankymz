using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult OpenMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, byte mode, ref uint fileHandle);
