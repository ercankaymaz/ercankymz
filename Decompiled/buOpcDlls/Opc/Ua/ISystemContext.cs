using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface ISystemContext
{
	object SystemHandle { get; }

	NodeId SessionId { get; }

	IUserIdentity UserIdentity { get; }

	IList<string> PreferredLocales { get; }

	string AuditEntryId { get; }

	NamespaceTable NamespaceUris { get; }

	StringTable ServerUris { get; }

	ITypeTable TypeTable { get; }

	IEncodeableFactory EncodeableFactory { get; }

	INodeIdFactory NodeIdFactory { get; }

	NodeStateFactory NodeStateFactory { get; }
}
