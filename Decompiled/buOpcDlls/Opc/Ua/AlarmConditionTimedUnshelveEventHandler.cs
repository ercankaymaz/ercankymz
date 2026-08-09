using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult AlarmConditionTimedUnshelveEventHandler(ISystemContext context, AlarmConditionState alarm);
