using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult DialogResponseEventHandler(ISystemContext context, DialogConditionState dialog, int selectedResponse);
