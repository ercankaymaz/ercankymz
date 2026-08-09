using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult RemoveIdentityMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, IdentityMappingRuleType rule);
