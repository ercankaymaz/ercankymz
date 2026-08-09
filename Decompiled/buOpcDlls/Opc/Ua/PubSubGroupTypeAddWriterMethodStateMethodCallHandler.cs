using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult PubSubGroupTypeAddWriterMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, DataSetWriterDataType configuration, ref NodeId dataSetWriterNodeId);
