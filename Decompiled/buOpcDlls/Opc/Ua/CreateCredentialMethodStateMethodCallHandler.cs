using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult CreateCredentialMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, string resourceUri, string profileUri, string[] endpointUrls, ref NodeId credentialNodeId);
