using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult GetMonitoredItemsMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, uint subscriptionId, ref uint[] serverHandles, ref uint[] clientHandles);
