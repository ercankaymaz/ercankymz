using Xbim.Common;

namespace Xbim.IO.Step21;

public struct DeferredReference(int paramIndex, IPersist hostEntity, int refId, int[] nestedIndex)
{
	public int ParameterIndex = paramIndex;

	public IPersist HostEntity = hostEntity;

	public int ReferenceId = refId;

	public int[] NestedIndex = nestedIndex;
}
