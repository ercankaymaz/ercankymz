using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult MoveOrCopyMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, NodeId objectToMoveOrCopy, NodeId targetDirectory, bool createCopy, string newName, ref NodeId newNodeId);
