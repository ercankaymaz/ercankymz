using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult TimedShelveMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, double shelvingTime);
