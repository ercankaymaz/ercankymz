using devDept.Eyeshot;
using devDept.Geometry;

namespace devDept.Serialization;

public class CameraSurrogate : Surrogate<Camera>
{
	public Point3D Target;

	public double Distance;

	public Quaternion Rotation;

	public byte ProjectionMode;

	public double FocalLength;

	public double ZoomFactor;

	public CameraSurrogate(Camera camera)
		: base(camera)
	{
	}

	protected override Camera ConvertToObject()
	{
		Camera camera = new Camera(this);
		CopyDataToObject(camera);
		return camera;
	}

	protected override void CopyDataToObject(Camera camera)
	{
	}

	protected override void CopyDataFromObject(Camera camera)
	{
		Target = camera.Target;
		Distance = camera.Distance;
		Rotation = camera.Rotation;
		ProjectionMode = (byte)camera.ProjectionMode;
		FocalLength = (int)(byte)camera.FocalLength;
		ZoomFactor = camera.ZoomFactor;
	}

	public static implicit operator Camera(CameraSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator CameraSurrogate(Camera source)
	{
		return source?.ConvertToSurrogate();
	}
}
