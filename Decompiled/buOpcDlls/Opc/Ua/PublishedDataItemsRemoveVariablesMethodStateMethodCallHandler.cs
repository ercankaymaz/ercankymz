using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult PublishedDataItemsRemoveVariablesMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, ConfigurationVersionDataType configurationVersion, uint[] variablesToRemove, ref ConfigurationVersionDataType newConfigurationVersion, ref StatusCode[] removeResults);
