using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult GenericMethodCalledEventHandler2(ISystemContext context, MethodState method, NodeId objectId, IList<object> inputArguments, IList<object> outputArguments);
