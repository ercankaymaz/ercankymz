using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult AddConnectionMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, PubSubConnectionDataType configuration, ref NodeId connectionId);
