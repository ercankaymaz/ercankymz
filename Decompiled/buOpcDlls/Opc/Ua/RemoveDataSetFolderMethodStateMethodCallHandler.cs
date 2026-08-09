using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult RemoveDataSetFolderMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, NodeId dataSetFolderNodeId);
