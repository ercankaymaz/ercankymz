using System.Collections.Generic;

namespace ACadSharp.IO.Templates;

internal interface ICadOwnerTemplate : ICadObjectTemplate, ICadTemplate
{
	HashSet<ulong> OwnedObjectsHandlers { get; }
}
