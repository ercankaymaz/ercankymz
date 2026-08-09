using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate void NodeStateChangedHandler(ISystemContext context, NodeState node, NodeStateChangeMasks changes);
