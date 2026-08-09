using System.Runtime.InteropServices;

namespace System.Buffers;

[ComVisible(true)]
public enum OperationStatus
{
	Done,
	DestinationTooSmall,
	NeedMoreData,
	InvalidData
}
