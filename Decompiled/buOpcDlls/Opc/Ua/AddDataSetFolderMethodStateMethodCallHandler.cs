using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult AddDataSetFolderMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, string name, ref NodeId dataSetFolderNodeId);
