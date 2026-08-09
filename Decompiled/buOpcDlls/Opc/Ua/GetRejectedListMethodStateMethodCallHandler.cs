using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult GetRejectedListMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, ref byte[][] certificates);
