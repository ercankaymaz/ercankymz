using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate bool NodeStateValidateHandler(ISystemContext context, NodeState node);
