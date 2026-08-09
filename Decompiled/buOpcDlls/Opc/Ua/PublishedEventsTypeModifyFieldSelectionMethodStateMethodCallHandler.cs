using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult PublishedEventsTypeModifyFieldSelectionMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, ConfigurationVersionDataType configurationVersion, string[] fieldNameAliases, bool[] promotedFields, SimpleAttributeOperand[] selectedFields, ref ConfigurationVersionDataType newConfigurationVersion);
