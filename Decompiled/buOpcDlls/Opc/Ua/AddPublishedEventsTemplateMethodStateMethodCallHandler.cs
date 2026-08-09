using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult AddPublishedEventsTemplateMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, string name, DataSetMetaDataType dataSetMetaData, NodeId eventNotifier, SimpleAttributeOperand[] selectedFields, ContentFilter filter, ref NodeId dataSetNodeId);
