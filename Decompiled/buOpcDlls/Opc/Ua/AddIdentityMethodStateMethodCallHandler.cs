using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult AddIdentityMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, IdentityMappingRuleType rule);
