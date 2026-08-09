using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult RemoveApplicationMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, string applicationUri);
