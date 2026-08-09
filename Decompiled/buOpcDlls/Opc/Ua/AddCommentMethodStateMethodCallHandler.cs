using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult AddCommentMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, byte[] eventId, LocalizedText comment);
