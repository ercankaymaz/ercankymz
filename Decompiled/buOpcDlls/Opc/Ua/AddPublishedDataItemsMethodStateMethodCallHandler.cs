using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult AddPublishedDataItemsMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, string name, string[] fieldNameAliases, ushort[] fieldFlags, PublishedVariableDataType[] variablesToAdd, ref NodeId dataSetNodeId, ref ConfigurationVersionDataType configurationVersion, ref StatusCode[] addResults);
