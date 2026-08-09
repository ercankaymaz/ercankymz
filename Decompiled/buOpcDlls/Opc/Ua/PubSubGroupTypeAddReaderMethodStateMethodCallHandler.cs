using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult PubSubGroupTypeAddReaderMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, DataSetReaderDataType configuration, ref NodeId dataSetReaderNodeId);
