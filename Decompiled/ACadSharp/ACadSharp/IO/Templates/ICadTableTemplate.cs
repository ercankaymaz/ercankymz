using System.Collections.Generic;

namespace ACadSharp.IO.Templates;

internal interface ICadTableTemplate : ICadObjectTemplate, ICadTemplate
{
	HashSet<ulong> EntryHandles { get; }
}
