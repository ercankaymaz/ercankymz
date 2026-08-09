using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult RemovePublishedDataSetMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, NodeId dataSetNodeId);
