using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult SetSubscriptionDurableMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, uint subscriptionId, uint lifetimeInHours, ref uint revisedLifetimeInHours);
