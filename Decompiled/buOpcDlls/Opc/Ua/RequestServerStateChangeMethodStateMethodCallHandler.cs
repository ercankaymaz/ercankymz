using System;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult RequestServerStateChangeMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, ServerState state, DateTime estimatedReturnTime, uint secondsTillShutdown, LocalizedText reason, bool restart);
