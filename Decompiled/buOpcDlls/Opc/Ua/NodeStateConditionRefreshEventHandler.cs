using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate void NodeStateConditionRefreshEventHandler(ISystemContext context, NodeState node, List<IFilterTarget> events);
