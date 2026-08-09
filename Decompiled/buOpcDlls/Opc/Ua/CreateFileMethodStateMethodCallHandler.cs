using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult CreateFileMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, string fileName, bool requestFileOpen, ref NodeId fileNodeId, ref uint fileHandle);
