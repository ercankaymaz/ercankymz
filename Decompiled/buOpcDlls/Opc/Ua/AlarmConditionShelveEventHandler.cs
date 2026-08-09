using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult AlarmConditionShelveEventHandler(ISystemContext context, AlarmConditionState alarm, bool shelving, bool oneShot, double shelvingTime);
