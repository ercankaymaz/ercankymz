using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult PubSubGroupTypeRemoveReaderMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, NodeId dataSetReaderNodeId);
