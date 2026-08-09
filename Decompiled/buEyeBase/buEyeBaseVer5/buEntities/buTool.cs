using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

public class buTool(string blockName) : BlockReference(0.0, 0.0, 0.0, blockName, 1.0, 1.0, 1.0, 0.0)
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

	public Point3D centerPointOfA = null;

	public Point3D centerPointOfB = null;

	public Point3D centerPointOfC = null;

	public bool ARotation = false;

	public bool BRotation = false;

	public bool CRotation = false;

	public bool AnglesInRadian = false;

	public string Tag;

	public int No = -1;

	public int HeadNumber = 1;

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
			double angleInRadians = Utility.DegToRad(cPos);
			if (AnglesInRadian)
			{
				angleInRadians = cPos;
			}
			if (!(centerPointOfC == null))
			{
				transformation_0 = Transformation.CreateRotation(angleInRadians, new Vector3D(0.0, 0.0, 1.0), centerPointOfC);
			}
			else
			{
				transformation_0 = Transformation.CreateRotation(angleInRadians, new Vector3D(0.0, 0.0, 1.0), new Point3D(xRot, yRot, zRot));
			}
			data.RenderContext.MultMatrixModelView(transformation_0);
			Point3D point3D = new Point3D(x, y, z);
			point3D.TransformBy(Transformation.CreateRotation(Utility.DegToRad(0.0 - cPos), new Vector3D(0.0, 0.0, 1.0), new Point3D(0.0, 0.0, 0.0)));
			x = point3D.X;
			y = point3D.Y;
			z = point3D.Z;
		}
		if (BRotation)
		{
			double angleInRadians2 = Utility.DegToRad(bPos);
			if (AnglesInRadian)
			{
				angleInRadians2 = bPos;
			}
			if (!(centerPointOfB == null))
			{
				transformation_0 = Transformation.CreateRotation(angleInRadians2, new Vector3D(0.0, 1.0, 0.0), centerPointOfB);
			}
			else
			{
				transformation_0 = Transformation.CreateRotation(angleInRadians2, new Vector3D(0.0, 1.0, 0.0), new Point3D(xRot, yRot, zRot));
			}
			data.RenderContext.MultMatrixModelView(transformation_0);
			Point3D point3D2 = new Point3D(x, y, z);
			point3D2.TransformBy(Transformation.CreateRotation(Utility.DegToRad(0.0 - bPos), new Vector3D(0.0, 1.0, 0.0), new Point3D(0.0, 0.0, 0.0)));
			x = point3D2.X;
			y = point3D2.Y;
			z = point3D2.Z;
		}
		if (ARotation)
		{
			double angleInRadians3 = Utility.DegToRad(aPos);
			if (AnglesInRadian)
			{
				angleInRadians3 = aPos;
			}
			if (!(centerPointOfA == null))
			{
				transformation_0 = Transformation.CreateRotation(angleInRadians3, new Vector3D(1.0, 0.0, 0.0), centerPointOfA);
			}
			else
			{
				transformation_0 = Transformation.CreateRotation(angleInRadians3, new Vector3D(1.0, 0.0, 0.0), new Point3D(xRot, yRot, zRot));
			}
			data.RenderContext.MultMatrixModelView(transformation_0);
			Point3D point3D3 = new Point3D(x, y, z);
			point3D3.TransformBy(Transformation.CreateRotation(Utility.DegToRad(0.0 - aPos), new Vector3D(1.0, 0.0, 0.0), new Point3D(0.0, 0.0, 0.0)));
			x = point3D3.X;
			y = point3D3.Y;
			z = point3D3.Z;
		}
		transformation_0 = Transformation.CreateTranslation(x, y, z);
		data.RenderContext.MultMatrixModelView(transformation_0);
	}

	public override bool IsInFrustum(FrustumParams data, Point3D center, double radius)
	{
		return true;
	}
}
