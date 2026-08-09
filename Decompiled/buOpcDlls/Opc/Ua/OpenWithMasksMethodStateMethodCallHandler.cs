using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult OpenWithMasksMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, uint masks, ref uint fileHandle);
