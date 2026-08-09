using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate ServiceResult FindAliasMethodStateMethodCallHandler(ISystemContext _context, MethodState _method, NodeId _objectId, string aliasNameSearchPattern, NodeId referenceTypeFilter, ref AliasNameDataType[] aliasNodeList);
