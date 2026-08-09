using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult CloseAndUpdateMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, uint fileHandle, ref bool applyChangesRequired);
