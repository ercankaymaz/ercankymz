using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult PubSubConnectionAddReaderGroupGroupMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, ReaderGroupDataType configuration, ref NodeId groupId);
