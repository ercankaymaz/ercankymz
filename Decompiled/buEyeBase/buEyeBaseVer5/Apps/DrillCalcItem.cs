using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class DrillCalcItem : buSerilization5
{
	public string ItemName = "";

	public bool isError = false;

	public bool isDrill = false;

	public bool isPocket = false;

	public bool isCenter = true;

	public int ID = -1;

	public int Tool = 0;

	public int GroupIndex = -1;

	public int HeadNo = -1;

	public double Diameter = 10.0;

	public double Depth = 0.0;

	public double Length = 0.0;

	public double Width = 0.0;

	public double Height = 0.0;

	public double Angle = 0.0;

	public Vector3D Direction = new Vector3D(0.0, 0.0, 1.0);

	public Point3D Center = new Point3D(0.0, 0.0, 0.0);

	public Point3D OffsetedPoint = new Point3D(0.0, 0.0, 0.0);

	public Point3D BoxMin = new Point3D(0.0, 0.0, 0.0);

	public Point3D BoxMax = new Point3D(0.0, 0.0, 0.0);

	public int Transparency = 120;

	public planeBoxNames planeName = planeBoxNames.Top;

	public DrillItemType Type = DrillItemType.Drill;

	public drillCommands Command = drillCommands.SingleHole;

	public CornerLocation Corner = CornerLocation.RightTop;

	public ShapeTypes ShapeType = ShapeTypes.Rectangle;

	public ProfilingTypes ProfilingType = ProfilingTypes.ProfilingRectangle;

	public bool Calculated = false;

	public bool Enable = true;

	public bool UseMilling = false;

	public int HorizontalCount = 0;

	public int VerticalCount = 0;

	public double HorizontalDistance = 0.0;

	public double VerticalDistance = 0.0;

	public double StartDistance = 0.0;

	public double EndDistance = 0.0;

	public int NumberNextHorizontalItem = 0;

	public int NumberNextVerticalItem = 0;

	public DrillCalcItem()
	{
	}

	public DrillCalcItem(Point3D center)
	{
		Center = new Point3D(center.X, center.Y, center.Z);
	}

	public DrillCalcItem(DrillItem Item)
	{
		Angle = Item.ShapeData.Angle;
		BoxMax = buVector5.ToPoint3D(Item.BoxMaxOfDrawing);
		BoxMin = buVector5.ToPoint3D(Item.BoxMinOfDrawing);
		Calculated = Item.Calculated;
		Center = buVector5.ToPoint3D(Item.Center);
		Command = Item.Command;
		Corner = Item.Corner;
		Depth = Item.ShapeData.Depth;
		Diameter = Item.ShapeData.Diameter;
		Direction = new Vector3D(Item.CornerDirection.X, Item.CornerDirection.Y, Item.CornerDirection.Z);
		Enable = Item.Enable;
		EndDistance = Item.EndDistance;
		GroupIndex = Item.GroupIndex;
		Height = Item.ShapeData.Height;
		HorizontalCount = Item.HorizontalCount;
		HorizontalDistance = Item.HorizontalDistance;
		ID = Item.SubID;
		isCenter = Item.isCenter;
		isDrill = Item.isDrill;
		isError = Item.isError;
		isPocket = Item.isPocket;
		ItemName = Item.ItemName;
		Length = Item.ShapeData.Length;
		NumberNextHorizontalItem = Item.NumberNextHorizontalItem;
		NumberNextVerticalItem = Item.NumberNextVerticalItem;
		OffsetedPoint = buVector5.ToPoint3D(Item.OffsetedPoint);
		planeName = Item.planeName;
		ProfilingType = Item.ProfilingType;
		ShapeType = Item.ShapeType;
		StartDistance = Item.StartDistance;
		Tool = Item.Tool;
		Transparency = Item.Transparency;
		Type = Item.Type;
		UseMilling = Item.UseMilling;
		VerticalCount = Item.VerticalCount;
		VerticalDistance = Item.VerticalDistance;
		Width = Item.ShapeData.Width;
	}

	public DrillCalcItem(buShapeHole Item)
	{
		Diameter = Item.Diameter;
		if (Item.planeName != planeBoxNames.Front)
		{
			if (Item.planeName != planeBoxNames.Back)
			{
				if (Item.planeName != planeBoxNames.Top)
				{
					if (Item.planeName != planeBoxNames.Bottom)
					{
						if (Item.planeName != planeBoxNames.Right)
						{
							if (Item.planeName == planeBoxNames.Left)
							{
								planeName = planeBoxNames.Back;
							}
						}
						else
						{
							planeName = planeBoxNames.Front;
						}
					}
					else
					{
						planeName = planeBoxNames.Bottom;
					}
				}
				else
				{
					planeName = planeBoxNames.Top;
				}
			}
			else
			{
				planeName = planeBoxNames.Left;
			}
		}
		else
		{
			planeName = planeBoxNames.Right;
		}
		Depth = Item.Depth;
		ID = Item.ID;
		Center = new Point3D(0.0 - Item.CalculatedPoint.X, 0.0 - Item.CalculatedPoint.Y, Item.CalculatedPoint.Z);
	}

	public DrillCalcItem(buShapeCut Item)
	{
		Width = Item.Diameter;
		if (Item.planeName != planeBoxNames.Front)
		{
			if (Item.planeName != planeBoxNames.Back)
			{
				if (Item.planeName != planeBoxNames.Top)
				{
					if (Item.planeName != planeBoxNames.Bottom)
					{
						if (Item.planeName != planeBoxNames.Right)
						{
							if (Item.planeName == planeBoxNames.Left)
							{
								planeName = planeBoxNames.Back;
							}
						}
						else
						{
							planeName = planeBoxNames.Front;
						}
					}
					else
					{
						planeName = planeBoxNames.Bottom;
					}
				}
				else
				{
					planeName = planeBoxNames.Top;
				}
			}
			else
			{
				planeName = planeBoxNames.Left;
			}
		}
		else
		{
			planeName = planeBoxNames.Right;
		}
		Depth = Item.Depth;
		Length = Item.Length;
		ID = Item.ID;
		Center = new Point3D(0.0 - Item.CalculatedPoint.X, 0.0 - Item.CalculatedPoint.Y, Item.CalculatedPoint.Z);
		Type = DrillItemType.Slot;
		UseMilling = Item.isMilling;
		if (Item.Tool != null)
		{
			Tool = Item.Tool.Data.No;
		}
	}

	public DrillCalcItem(DrillCalcItem data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
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
		Center = buVector5.ToPoint3D(data.Center);
		OffsetedPoint = buVector5.ToPoint3D(data.OffsetedPoint);
		Direction = (Vector3D)data.Direction.Clone();
		BoxMin = buVector5.ToPoint3D(data.BoxMin);
		BoxMax = buVector5.ToPoint3D(data.BoxMax);
	}

	public static void Copy(List<DrillCalcItem> RefItem, ref List<DrillCalcItem> CopiedItem)
	{
		CopiedItem.Clear();
		CopiedItem = new List<DrillCalcItem>();
		for (int i = 0; i <= RefItem.Count - 1; i++)
		{
			DrillCalcItem CopiedItem2 = new DrillCalcItem();
			Copy(RefItem[i], ref CopiedItem2);
			CopiedItem.Add(CopiedItem2);
		}
	}

	public static void Copy(DrillCalcItem RefItem, ref DrillCalcItem CopiedItem)
	{
		CopiedItem = new DrillCalcItem(RefItem);
	}

	public override string ToString()
	{
		string text = planeName.ToString() + " Center : " + Center.ToString() + " - Dia: " + Diameter.ToString("f3") + " - Dpth: " + Depth.ToString("f3") + " - Calc: " + Calculated;
		if (Tool > 0)
		{
			text = text + " T:" + Tool;
		}
		if (HeadNo >= 1)
		{
			text = text + " Head: " + HeadNo;
		}
		return text;
	}
}
