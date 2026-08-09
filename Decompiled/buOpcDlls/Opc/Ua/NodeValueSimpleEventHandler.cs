using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult NodeValueSimpleEventHandler(ISystemContext context, NodeState node, ref object value);
