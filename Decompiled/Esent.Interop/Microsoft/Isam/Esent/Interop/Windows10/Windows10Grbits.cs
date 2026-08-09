using Microsoft.Isam.Esent.Interop.Windows8;

namespace Microsoft.Isam.Esent.Interop.Windows10;

public static class Windows10Grbits
{
	public const CreateTableColumnIndexGrbit TableCreateImmutableStructure = (CreateTableColumnIndexGrbit)8;

	public const CreateIndexGrbit IndexCreateImmutableStructure = (CreateIndexGrbit)524288;

	public const DurableCommitCallbackGrbit LogUnavailable = (DurableCommitCallbackGrbit)1;
}
