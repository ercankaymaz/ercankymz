using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult ResendDataMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, uint subscriptionId);
