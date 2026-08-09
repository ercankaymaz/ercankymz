using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult RemoveExtensionFieldMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, NodeId fieldId);
