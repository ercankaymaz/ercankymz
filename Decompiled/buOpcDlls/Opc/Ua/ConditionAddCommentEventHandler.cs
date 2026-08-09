using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult ConditionAddCommentEventHandler(ISystemContext context, ConditionState condition, byte[] eventId, LocalizedText comment);
