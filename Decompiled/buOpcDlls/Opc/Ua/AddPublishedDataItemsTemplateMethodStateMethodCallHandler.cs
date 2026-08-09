using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult AddPublishedDataItemsTemplateMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, string name, DataSetMetaDataType dataSetMetaData, PublishedVariableDataType[] variablesToAdd, ref NodeId dataSetNodeId, ref StatusCode[] addResults);
