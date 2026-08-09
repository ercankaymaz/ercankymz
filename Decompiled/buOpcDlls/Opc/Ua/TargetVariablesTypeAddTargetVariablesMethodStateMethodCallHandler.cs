using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult TargetVariablesTypeAddTargetVariablesMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, ConfigurationVersionDataType configurationVersion, FieldTargetDataType[] targetVariablesToAdd, ref StatusCode[] addResults);
