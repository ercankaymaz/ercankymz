using System.Collections.Generic;
using System.Numerics;

namespace SharpGLTF.Transforms;

public interface IMaterialTransform
{
	Vector2 MorphTexCoord(Vector2 texCoord, IReadOnlyList<Vector2> morphTargets);

	Vector4 MorphColors(Vector4 color, IReadOnlyList<Vector4> morphTargets);
}
