using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult AddPublishedEventsMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, string name, NodeId eventNotifier, string[] fieldNameAliases, ushort[] fieldFlags, SimpleAttributeOperand[] selectedFields, ContentFilter filter, ref ConfigurationVersionDataType configurationVersion, ref NodeId dataSetNodeId);
