using SharpGLTF.Transforms;

namespace SharpGLTF.Diagnostics;

internal sealed class _Matrix4x4DoubleProxy
{
	private Matrix4x4Double _Value;

	public (double X, double Y, double Z, double W) Row1 => (X: _Value.M11, Y: _Value.M12, Z: _Value.M13, W: _Value.M14);

	public (double X, double Y, double Z, double W) Row2 => (X: _Value.M21, Y: _Value.M22, Z: _Value.M23, W: _Value.M24);

	public (double X, double Y, double Z, double W) Row3 => (X: _Value.M31, Y: _Value.M32, Z: _Value.M33, W: _Value.M34);

	public (double X, double Y, double Z, double W) Row4 => (X: _Value.M41, Y: _Value.M42, Z: _Value.M43, W: _Value.M44);

	public _Matrix4x4DoubleProxy(Matrix4x4Double value)
	{
		_Value = value;
	}
}
