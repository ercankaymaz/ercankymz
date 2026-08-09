using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

public class buMaterialMoveable(string blockName) : BlockReference(0.0, 0.0, 0.0, blockName, 1.0, 1.0, 1.0, 0.0)
{
	public double xPos = 0.0;

	public double yPos = 0.0;

	public double zPos = 0.0;

	public double aPos = 0.0;

	public double bPos = 0.0;

	public double cPos = 0.0;

	public double xRot = 0.0;

	public double yRot = 0.0;

	public double zRot = 0.0;

	public bool XMove = false;

	public bool YMove = false;

	public bool ZMove = false;

	public bool ARotation = false;

	public bool BRotation = false;

	public bool CRotation = false;

	public string Tag;

	private Transformation transformation_0;

	protected override void Animate(int frameNumber)
	{
		base.Animate(frameNumber);
	}

	public override void Rotate(double angleInRadians, Vector3D axis, Point3D center)
	{
		base.Rotate(angleInRadians, axis, center);
	}

	public override void MoveTo(DrawParams data)
	{
		base.MoveTo(data);
		double x = xPos;
		double y = yPos;
		double z = zPos;
		if (CRotation)
		{
			transformation_0 = new Rotation(Utility.DegToRad(cPos), new Vector3D(0.0, 0.0, 1.0), new Point3D(xRot, yRot, zRot));
			data.RenderContext.MultMatrixModelView(transformation_0);
		}
		if (BRotation)
		{
			transformation_0 = new Rotation(Utility.DegToRad(bPos), new Vector3D(0.0, 1.0, 0.0), new Point3D(xRot, yRot, zRot));
			data.RenderContext.MultMatrixModelView(transformation_0);
		}
		if (ARotation)
		{
			transformation_0 = new Rotation(Utility.DegToRad(aPos), new Vector3D(1.0, 0.0, 0.0), new Point3D(xRot, yRot, zRot));
			data.RenderContext.MultMatrixModelView(transformation_0);
			Point3D point3D = new Point3D(x, y, z);
			point3D.TransformBy(new Rotation(Utility.DegToRad(0.0 - aPos), new Vector3D(1.0, 0.0, 0.0), new Point3D(0.0, 0.0, 0.0)));
			x = point3D.X;
			y = point3D.Y;
			z = point3D.Z;
		}
		ToString();
		if (!XMove)
		{
			x = 0.0;
		}
		if (!YMove)
		{
			y = 0.0;
		}
		if (!ZMove)
		{
			z = 0.0;
		}
		transformation_0 = new Translation(x, y, z);
		data.RenderContext.MultMatrixModelView(transformation_0);
	}

	public override bool IsInFrustum(FrustumParams data, Point3D center, double radius)
	{
		return true;
	}
}
