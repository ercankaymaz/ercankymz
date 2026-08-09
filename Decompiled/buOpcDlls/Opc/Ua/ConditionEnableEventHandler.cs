using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult ConditionEnableEventHandler(ISystemContext context, ConditionState condition, bool enabling);
