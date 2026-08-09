using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate void NodeStateReportEventHandler(ISystemContext context, NodeState node, IFilterTarget e);
