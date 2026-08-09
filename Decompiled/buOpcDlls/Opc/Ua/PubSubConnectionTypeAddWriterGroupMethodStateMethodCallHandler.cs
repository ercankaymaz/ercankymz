using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult PubSubConnectionTypeAddWriterGroupMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, WriterGroupDataType configuration, ref NodeId groupId);
