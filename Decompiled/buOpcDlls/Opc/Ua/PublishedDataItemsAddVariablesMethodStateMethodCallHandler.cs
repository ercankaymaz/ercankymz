using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult PublishedDataItemsAddVariablesMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, ConfigurationVersionDataType configurationVersion, string[] fieldNameAliases, bool[] promotedFields, PublishedVariableDataType[] variablesToAdd, ref ConfigurationVersionDataType newConfigurationVersion, ref StatusCode[] addResults);
