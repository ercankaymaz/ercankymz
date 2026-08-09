using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.buEntities;

public class buMachinePart(string blockName) : BlockReference(0.0, 0.0, 0.0, blockName, 1.0, 1.0, 1.0, 0.0)
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

	public double aPos2 = 0.0;

	public double bPos2 = 0.0;

	public double cPos2 = 0.0;

	public Point3D centerPointOfA = null;

	public Point3D centerPointOfB = null;

	public Point3D centerPointOfC = null;

	public Point3D centerPointOfA2 = null;

	public Point3D centerPointOfB2 = null;

	public Point3D centerPointOfC2 = null;

	public Vector3D vectorARotation = null;

	public Vector3D vectorBRotation = null;

	public Vector3D vectorCRotation = null;

	public Vector3D vectorARotation2 = null;

	public Vector3D vectorBRotation2 = null;

	public Vector3D vectorCRotation2 = null;

	public bool XMove = false;

	public bool YMove = false;

	public bool ZMove = false;

	public bool ARotation = false;

	public bool BRotation = false;

	public bool CRotation = false;

	public bool ARotation2 = false;

	public bool BRotation2 = false;

	public bool CRotation2 = false;

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
		double num = xPos;
		double num2 = yPos;
		double num3 = zPos;
		_ = base.BlockName;
		if (CRotation)
		{
			Vector3D vector3D = new Vector3D(0.0, 0.0, 1.0);
			if (vectorCRotation != null)
			{
				vector3D.X = vectorCRotation.X;
				vector3D.Y = vectorCRotation.Y;
				vector3D.Z = vectorCRotation.Z;
			}
			if (!(centerPointOfC == null))
			{
				transformation_0 = Transformation.CreateRotation(Utility.DegToRad(cPos), vector3D, centerPointOfC);
			}
			else
			{
				transformation_0 = Transformation.CreateRotation(Utility.DegToRad(cPos), vector3D, new Point3D(xRot, yRot, zRot));
			}
			data.RenderContext.MultMatrixModelView(transformation_0);
			if (!XMove)
			{
				num = 0.0;
			}
			if (!YMove)
			{
				num2 = 0.0;
			}
			if (!ZMove)
			{
				num3 = 0.0;
			}
			Point3D point3D = new Point3D(num, num2, num3);
			point3D.TransformBy(Transformation.CreateRotation(Utility.DegToRad(0.0 - cPos), vector3D, new Point3D(0.0, 0.0, 0.0)));
			num = point3D.X;
			num2 = point3D.Y;
			num3 = point3D.Z;
		}
		if (CRotation2)
		{
			Vector3D vector3D2 = new Vector3D(0.0, 0.0, 1.0);
			if (vectorCRotation2 != null)
			{
				vector3D2.X = vectorCRotation2.X;
				vector3D2.Y = vectorCRotation2.Y;
				vector3D2.Z = vectorCRotation2.Z;
			}
			new Point3D((base.BoxMin.X + base.BoxMax.X) / 2.0, (base.BoxMin.Y + base.BoxMax.Y) / 2.0);
			if (!(centerPointOfC2 == null))
			{
				transformation_0 = Transformation.CreateRotation(Utility.DegToRad(cPos2), vector3D2, centerPointOfC2);
			}
			else
			{
				transformation_0 = Transformation.CreateRotation(Utility.DegToRad(cPos2), vector3D2, new Point3D(xRot, yRot, zRot));
			}
			data.RenderContext.MultMatrixModelView(transformation_0);
			if (!XMove)
			{
				num = 0.0;
			}
			if (!YMove)
			{
				num2 = 0.0;
			}
			if (!ZMove)
			{
				num3 = 0.0;
			}
			Point3D point3D2 = new Point3D(num, num2, num3);
			point3D2.TransformBy(Transformation.CreateRotation(Utility.DegToRad(0.0 - cPos2), vector3D2, new Point3D(0.0, 0.0, 0.0)));
		}
		if (BRotation)
		{
			if (!(centerPointOfB == null))
			{
				transformation_0 = Transformation.CreateRotation(Utility.DegToRad(bPos), new Vector3D(0.0, 1.0, 0.0), centerPointOfB);
			}
			else
			{
				transformation_0 = Transformation.CreateRotation(Utility.DegToRad(bPos), new Vector3D(0.0, 1.0, 0.0), new Point3D(xRot, yRot, zRot));
			}
			data.RenderContext.MultMatrixModelView(transformation_0);
			if (!XMove)
			{
				num = 0.0;
			}
			if (!YMove)
			{
				num2 = 0.0;
			}
			if (!ZMove)
			{
				num3 = 0.0;
			}
			Point3D point3D3 = new Point3D(num, num2, num3);
			point3D3.TransformBy(Transformation.CreateRotation(Utility.DegToRad(0.0 - bPos), new Vector3D(0.0, 1.0, 0.0), new Point3D(0.0, 0.0, 0.0)));
			num = point3D3.X;
			num2 = point3D3.Y;
			num3 = point3D3.Z;
		}
		if (ARotation)
		{
			if (!(centerPointOfA == null))
			{
				transformation_0 = Transformation.CreateRotation(Utility.DegToRad(aPos), new Vector3D(1.0, 0.0, 0.0), centerPointOfA);
			}
			else
			{
				transformation_0 = Transformation.CreateRotation(Utility.DegToRad(aPos), new Vector3D(1.0, 0.0, 0.0), new Point3D(xRot, yRot, zRot));
			}
			data.RenderContext.MultMatrixModelView(transformation_0);
			if (!XMove)
			{
				num = 0.0;
			}
			if (!YMove)
			{
				num2 = 0.0;
			}
			if (!ZMove)
			{
				num3 = 0.0;
			}
			Point3D point3D4 = new Point3D(num, num2, num3);
			point3D4.TransformBy(Transformation.CreateRotation(Utility.DegToRad(0.0 - aPos), new Vector3D(1.0, 0.0, 0.0), new Point3D(0.0, 0.0, 0.0)));
			num = point3D4.X;
			num2 = point3D4.Y;
			num3 = point3D4.Z;
		}
		ToString();
		if (!XMove)
		{
			num = 0.0;
		}
		if (!YMove)
		{
			num2 = 0.0;
		}
		if (!ZMove)
		{
			num3 = 0.0;
		}
		transformation_0 = Transformation.CreateTranslation(num, num2, num3);
		data.RenderContext.MultMatrixModelView(transformation_0);
	}

	public override bool IsInFrustum(FrustumParams data, Point3D center, double radius)
	{
		return true;
	}
}
