using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult AlarmConditionUnshelveTimeValueEventHandler(ISystemContext context, AlarmConditionState alarm);
