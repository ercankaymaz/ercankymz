using System.Collections.Generic;
using ACadSharp.Blocks;

namespace ACadSharp.IO.Templates;

internal class CadBlockEntityTemplate : CadEntityTemplate, ICadOwnerTemplate, ICadObjectTemplate, ICadTemplate
{
	public HashSet<ulong> OwnedObjectsHandlers { get; } = new HashSet<ulong>();

	public CadBlockEntityTemplate(Block entity)
		: base(entity)
	{
	}
}
