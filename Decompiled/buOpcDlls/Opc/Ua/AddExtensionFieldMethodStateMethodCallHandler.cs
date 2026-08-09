using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult AddExtensionFieldMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, QualifiedName fieldName, object fieldValue, ref NodeId fieldId);
