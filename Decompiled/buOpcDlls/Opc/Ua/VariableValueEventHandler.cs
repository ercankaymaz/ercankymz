using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate void VariableValueEventHandler(ISystemContext context, BaseVariableValue variable, NodeState component);
