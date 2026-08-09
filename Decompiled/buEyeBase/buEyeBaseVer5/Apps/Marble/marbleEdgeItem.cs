using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class marbleEdgeItem : buSerilization5
{
	public string Name = "";

	public bool Enable = true;

	public bool Inside = false;

	public bool Reverse = false;

	public double Depth = 0.0;

	public double Step = 0.0;

	public double Length = 0.0;

	public double Angle = 0.0;

	public double DirectionAngle = 0.0;

	public int IndexEntity = -1;

	public int IndexInside = -1;

	public int IndexEntitySub = -1;

	public int CamID = -1;

	public int ItemID = -1;

	public int EdgeID = -1;

	public int Index = -1;

	public int Sequence = -1;

	public Point3D pntAngleText = new Point3D();

	public ClockDirectionType Clock = ClockDirectionType.CCW;

	public OutsideInsideType OutsideInside = OutsideInsideType.Outside;

	public buEntity refEntity = null;

	public buEntity drawEntity = null;

	public marbleSlatPars Slat = null;

	public marbleChamferBothSidePars Chamfer = null;

	public marbleCountertopPocketPars Pocket = null;

	public Entity entityAngleSolid = null;

	public Entity entityAnglePlane = null;

	public Entity entityChamferTopPlane = null;

	public Entity entityChamferBottomPlane = null;

	public Entity entityChamferTopSolid = null;

	public Entity entityChamferBottomSolid = null;

	public Entity entityAngleText = null;

	public Entity entityDirection = null;

	public Entity entityEdge = null;

	public static List<string> Captions = new List<string>();

	public marbleEdgeItem()
	{
		Slat = new marbleSlatPars();
		Chamfer = new marbleChamferBothSidePars();
		Pocket = new marbleCountertopPocketPars();
	}

	public marbleEdgeItem(double angle)
	{
		Angle = angle;
		Slat = new marbleSlatPars();
		Chamfer = new marbleChamferBothSidePars();
		Pocket = new marbleCountertopPocketPars();
	}

	public marbleEdgeItem(string name, double angle)
	{
		Name = name;
		Angle = angle;
		Slat = new marbleSlatPars();
		Chamfer = new marbleChamferBothSidePars();
		Pocket = new marbleCountertopPocketPars();
	}

	public marbleEdgeItem(string name, double angle, ClockDirectionType clock, double depth, bool inside, double SlatSocketWidth, double SlatSocketHeight)
	{
		Name = name;
		Angle = angle;
		Depth = depth;
		Clock = clock;
		Inside = inside;
		Slat = new marbleSlatPars();
		Slat.Socket1.DataInside.InsideWidth = SlatSocketWidth;
		Slat.Socket1.DataInside.InsideHeight = SlatSocketHeight;
		Slat.Socket2.DataInside.InsideWidth = SlatSocketWidth;
		Slat.Socket2.DataInside.InsideHeight = SlatSocketHeight;
		Chamfer = new marbleChamferBothSidePars();
		Pocket = new marbleCountertopPocketPars();
	}

	public marbleEdgeItem(marbleEdgeItem data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
		if (GetType() == CopiedClass.GetType())
		{
			FieldInfo[] fields = GetType().GetFields();
			if (fields != null)
			{
				for (int i = 0; i <= fields.Length - 1; i++)
				{
					_ = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		if (data.Slat != null)
		{
			Slat = new marbleSlatPars(data.Slat);
		}
		if (data.Pocket != null)
		{
			Pocket = new marbleCountertopPocketPars(data.Pocket);
		}
		if (data.Chamfer != null)
		{
			Chamfer = new marbleChamferBothSidePars(data.Chamfer);
		}
		if (refEntity != null)
		{
			buEntity.Copy(data.refEntity, ref refEntity);
		}
		if (drawEntity != null)
		{
			buEntity.Copy(data.drawEntity, ref drawEntity);
		}
	}

	public static void Copy(List<marbleEdgeItem> refList, ref List<marbleEdgeItem> copyList)
	{
		if (copyList == null)
		{
			copyList = new List<marbleEdgeItem>();
		}
		if (refList != null && refList.Count > 0)
		{
			for (int i = 0; i <= refList.Count - 1; i++)
			{
				copyList.Add(new marbleEdgeItem(refList[i]));
			}
		}
	}

	public static ArrayList ToDef(marbleEdgeItem Edge)
	{
		ArrayList arrayList = new ArrayList();
		string text = "";
		text = buSerilization5.ClassToString(Edge);
		arrayList.Add(text);
		text = buSerilization5.ClassToString(Edge.Slat);
		arrayList.Add(text);
		text = buSerilization5.ClassToString(Edge.Chamfer);
		arrayList.Add(text);
		return arrayList;
	}

	public override string ToString()
	{
		string text = Name + " - Enable : " + Enable + " , Angle : " + Angle + " , Depth : " + Depth + " , " + OutsideInside;
		if (CamID >= 0)
		{
			text = text + " - CamID: " + CamID;
		}
		if (ItemID >= 0)
		{
			text = text + " - ItemID: " + ItemID;
		}
		if (EdgeID >= 0)
		{
			text = text + " - EdgeID: " + EdgeID;
		}
		return text;
	}
}
