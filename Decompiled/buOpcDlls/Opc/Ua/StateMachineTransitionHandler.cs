using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult StateMachineTransitionHandler(ISystemContext context, StateMachineState machine, uint transitionId, uint causeId, IList<object> inputArguments, IList<object> outputArguments);
