using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult TargetVariablesTypeRemoveTargetVariablesMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, ConfigurationVersionDataType configurationVersion, uint[] targetsToRemove, ref StatusCode[] removeResults);
