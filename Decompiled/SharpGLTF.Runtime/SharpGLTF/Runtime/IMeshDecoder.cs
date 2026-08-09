using System.Collections.Generic;

namespace SharpGLTF.Runtime;

public interface IMeshDecoder<TMaterial> where TMaterial : class
{
	string Name { get; }

	object Extras { get; }

	int LogicalIndex { get; }

	IReadOnlyList<IMeshPrimitiveDecoder<TMaterial>> Primitives { get; }
}
