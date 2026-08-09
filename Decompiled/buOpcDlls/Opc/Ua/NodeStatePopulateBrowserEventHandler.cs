using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate void NodeStatePopulateBrowserEventHandler(ISystemContext context, NodeState node, NodeBrowser browser);
