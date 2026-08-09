using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult NodeAttributeEventHandler<T>(ISystemContext context, NodeState node, ref T value);
