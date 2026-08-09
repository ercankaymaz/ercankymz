using System;
using System.Collections.Generic;
using System.Drawing;
using buClass;
using buCore;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

public class buDoor
{
	public static List<string> LangDoorStatus = new List<string>();

	public static List<string> LangDoorMessage = new List<string>();

	public static List<string> LangDoorCaptions = new List<string>();

	public static List<string> LangDoorCommands = new List<string>();

	public static DoorTempVars varTemps = new DoorTempVars();

	public static DoorSettings varDoorSettings = new DoorSettings();

	public static DoorRuntimeSettings varDoorRunSettings = new DoorRuntimeSettings();

	public buDoor()
	{
		if (!buVector5.smethod_0("buDoor"))
		{
			throw new RegisterException("buDoor");
		}
	}

	public void CreateDoorEntityFromMaterial(MaterialBase5 Mat, ref Entity entDoor)
	{
		List<Point3D> list = new List<Point3D>();
		list.Add(new Point3D(0.0, 0.0, Mat.Size.Depth));
		list.Add(new Point3D(0.0, Mat.Size.Height, Mat.Size.Depth));
		Point3D item = new Point3D(0.0, Mat.Size.Height, 0.0);
		if (Mat.BackAngle != 0.0)
		{
			double num = Math.Tan(buConversion.DegreeToRadian(Mat.BackAngle)) * Mat.Size.Depth;
			item = new Point3D(0.0, Mat.Size.Height - num, 0.0);
		}
		list.Add(item);
		Point3D item2 = new Point3D(0.0, 0.0, 0.0);
		if (Mat.FrontAngle != 0.0)
		{
			double y = Math.Tan(buConversion.DegreeToRadian(Mat.FrontAngle)) * Mat.Size.Depth;
			item2 = new Point3D(0.0, y, 0.0);
		}
		list.Add(item2);
		list.Add(new Point3D(0.0, 0.0, Mat.Size.Depth));
		LinearPath item3 = new LinearPath(list);
		List<ICurve> list2 = new List<ICurve>();
		list2.Add(item3);
		CompositeCurve outer = new CompositeCurve(list2);
		devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(outer, Plane.YZ);
		entDoor = region.ExtrudeAsBrep(Mat.Size.Width);
		entDoor.Color = Mat.Display.SkinColor;
		entDoor.ColorMethod = colorMethodType.byEntity;
	}

	public void CreateCaseEntityFromMaterial(SizeObject Case1, SizeObject Case2, Color clr, double Space, ref Entity entCase1, ref Entity entCase2)
	{
		List<Point3D> list = new List<Point3D>();
		list.Add(new Point3D(0.0, 0.0, 0.0));
		list.Add(new Point3D(Case1.Width, 0.0, 0.0));
		list.Add(new Point3D(Case1.Width, Case1.Height, 0.0));
		list.Add(new Point3D(0.0, Case1.Height, 0.0));
		list.Add(new Point3D(0.0, 0.0, 0.0));
		LinearPath outer = new LinearPath(list);
		devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(outer, Plane.XY);
		entCase1 = region.ExtrudeAsBrep(Case1.Depth);
		entCase1.Color = clr;
		entCase1.ColorMethod = colorMethodType.byEntity;
		entCase1.Regen(0.1);
		list = new List<Point3D>();
		list.Add(new Point3D(0.0, 0.0, 0.0));
		list.Add(new Point3D(Case2.Width, 0.0, 0.0));
		list.Add(new Point3D(Case2.Width, Case2.Height, 0.0));
		list.Add(new Point3D(0.0, Case2.Height, 0.0));
		list.Add(new Point3D(0.0, 0.0, 0.0));
		outer = new LinearPath(list);
		region = new devDept.Eyeshot.Entities.Region(outer, Plane.XY);
		entCase2 = region.ExtrudeAsBrep(Case2.Depth);
		entCase2.Color = clr;
		entCase2.ColorMethod = colorMethodType.byEntity;
		entCase2.Translate(0.0, Case1.Height + Space);
		entCase2.Regen(0.1);
	}

	public int JobImageIndex(buShape Item)
	{
		if (!(Item.GetType() == typeof(buShapeCircle)))
		{
			if (!(Item.GetType() == typeof(buShapeRectangle)))
			{
				if (!(Item.GetType() == typeof(buShapeEllipse)))
				{
					if (!(Item.GetType() == typeof(buShapeKeyHole)))
					{
						if (!(Item.GetType() == typeof(buShapePolygon)))
						{
							if (!(Item.GetType() == typeof(buShapeSlot)))
							{
								if (!(Item.GetType() == typeof(buShapeFreeDraw)))
								{
									return -1;
								}
								return 2;
							}
							return 6;
						}
						return 4;
					}
					return 3;
				}
				return 1;
			}
			return 5;
		}
		return 0;
	}

	public void RotatePointAtFrontPlane(ref List<Point3D> PL, Point3D refPoint, Point3D calcPoint, double MaterialDepth, double Angle)
	{
		Point3D centerPoint = new Point3D(0.0, 0.0, MaterialDepth);
		Point3D Points = buVector5.ToPoint3D(calcPoint);
		buCall.buVector5_0.Rotate(centerPoint, Angle, Plane.YZ, ref Points);
		buCall.buVector5_0.Rotate(centerPoint, Angle, Plane.YZ, ref PL);
		double num = refPoint.Z - Points.Z;
		double num2 = num * Math.Tan(buConversion5.DegreeToRadian(Angle));
		buCall.buVector5_0.Move(0.0, 0.0 - num2, num, ref PL);
	}

	public void RotatePointAtBackPlane(ref List<Point3D> PL, Point3D refPoint, Point3D calcPoint, double MaterialDepth, double MaterialHeight, double Angle)
	{
		Point3D centerPoint = new Point3D(0.0, MaterialHeight, MaterialDepth);
		Point3D Points = buVector5.ToPoint3D(calcPoint);
		buCall.buVector5_0.Rotate(centerPoint, 0.0 - Angle, Plane.YZ, ref Points);
		buCall.buVector5_0.Rotate(centerPoint, 0.0 - Angle, Plane.YZ, ref PL);
		double num = refPoint.Z - Points.Z;
		double dY = num * Math.Tan(buConversion5.DegreeToRadian(Angle));
		buCall.buVector5_0.Move(0.0, dY, num, ref PL);
	}
}
