using System.Numerics;

namespace SharpGLTF.Schema2;

public interface ICamera
{
	bool IsOrthographic { get; }

	bool IsPerspective { get; }

	Matrix4x4 Matrix { get; }
}
