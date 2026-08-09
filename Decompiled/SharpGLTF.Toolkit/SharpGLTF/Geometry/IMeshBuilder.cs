using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace SharpGLTF.Geometry;

public interface IMeshBuilder<TMaterial>
{
	string Name { get; set; }

	JsonNode Extras { get; set; }

	bool IsEmpty { get; }

	IEnumerable<TMaterial> Materials { get; }

	IReadOnlyCollection<IPrimitiveReader<TMaterial>> Primitives { get; }

	IPrimitiveBuilder UsePrimitive(TMaterial material, int primitiveVertexCount = 3);

	IMorphTargetBuilder UseMorphTarget(int index);

	IMeshBuilder<TMaterial> Clone(Func<TMaterial, TMaterial> materialCloneCallback = null);

	void Validate();
}
