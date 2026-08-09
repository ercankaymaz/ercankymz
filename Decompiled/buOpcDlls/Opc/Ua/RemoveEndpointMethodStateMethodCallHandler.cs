using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult RemoveEndpointMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, EndpointType endpoint);
