using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IServiceMessageContext
{
	object SyncRoot { get; }

	int MaxStringLength { get; }

	int MaxArrayLength { get; }

	int MaxByteStringLength { get; }

	int MaxMessageSize { get; }

	uint MaxEncodingNestingLevels { get; }

	NamespaceTable NamespaceUris { get; }

	StringTable ServerUris { get; }

	IEncodeableFactory Factory { get; }
}
