using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult CreateDirectoryMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, string directoryName, ref NodeId directoryNodeId);
