using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IEncodeableFactory : ICloneable
{
	int InstanceId { get; }

	IReadOnlyDictionary<ExpandedNodeId, Type> EncodeableTypes { get; }

	void AddEncodeableType(Type systemType);

	void AddEncodeableType(ExpandedNodeId encodingId, Type systemType);

	void AddEncodeableTypes(Assembly assembly);

	void AddEncodeableTypes(IEnumerable<Type> systemTypes);

	Type GetSystemType(ExpandedNodeId typeId);
}
