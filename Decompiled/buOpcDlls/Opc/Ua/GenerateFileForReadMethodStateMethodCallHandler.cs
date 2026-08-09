using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult GenerateFileForReadMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, object generateOptions, ref NodeId fileNodeId, ref uint fileHandle, ref NodeId completionStateMachine);
