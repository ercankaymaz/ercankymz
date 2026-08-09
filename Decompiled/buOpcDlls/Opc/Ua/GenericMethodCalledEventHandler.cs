using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult GenericMethodCalledEventHandler(ISystemContext context, MethodState method, IList<object> inputArguments, IList<object> outputArguments);
