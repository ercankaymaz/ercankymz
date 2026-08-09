using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult ReadMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, uint fileHandle, int length, ref byte[] data);
