using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class DrillItem : buSerilization5
{
	public string ItemName = "";

	public bool isError = false;

	public bool isDrill = false;

	public bool isPocket = false;

	public bool isCenter = true;

	public bool isMillingAtClamperSide = false;

	public bool isRough = false;

	public bool isFinish = false;

	public int SubID = -1;

	public int Tool = 0;

	public int GroupIndex = -1;

	public int BaseIndex = -1;

	public int Index = -1;

	public DrillShapeData ShapeData = new DrillShapeData();

	public camParameters5 CamPars = new camParameters5();

	public double Sing = -1.0;

	public Vector3D CornerDirection = new Vector3D(0.0, 0.0, 1.0);

	public Point3D Center = new Point3D(0.0, 0.0, 0.0);

	public Point3D CornerPoint = new Point3D(0.0, 0.0, 0.0);

	public Point3D OffsetedPoint = new Point3D(0.0, 0.0, 0.0);

	public Point3D BoxMinOfDrawing = new Point3D(0.0, 0.0, 0.0);

	public Point3D BoxMaxOfDrawing = new Point3D(0.0, 0.0, 0.0);

	public Point3D BoxMinItem = new Point3D(0.0, 0.0, 0.0);

	public Point3D BoxMaxItem = new Point3D(0.0, 0.0, 0.0);

	public Color Color = Color.Lime;

	public int Transparency = 120;

	public List<List<buEntity>> shapeEntitites = new List<List<buEntity>>();

	public List<List<buEntity>> camEntities = new List<List<buEntity>>();

	public List<Entity> solidEntities = new List<Entity>();

	public Entity SolidEntity = null;

	public Plane planeOperation = new Plane();

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

	public double X1Move = 0.0;

	public double X2Move = 0.0;

	public bool X1First = true;

	public bool StepEnable = false;

	public double StepValue = 1.0;

	public double Offset = 0.0;

	public double FeedPlunge = 0.0;

	public double FeedCut = 0.0;

	public double SpindleSpeed = 0.0;

	public bool SmallContour = false;

	public int NumberNextHorizontalItem = 0;

	public int NumberNextVerticalItem = 0;

	public ClockDirectionType ClockDir = ClockDirectionType.CW;

	public ToolBase5 ToolMilling = null;

	public DrillItem()
	{
	}

	public DrillItem(Point3D center)
	{
		Center = new Point3D(center.X, center.Y, center.Z);
	}

	public DrillItem(DrillItem data)
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
		if (data.SolidEntity != null)
		{
			SolidEntity = buVector5.CopyEntities(data.SolidEntity);
		}
		if (data.ToolMilling != null)
		{
			ToolMilling = new ToolBase5(data.ToolMilling);
		}
		ShapeData = new DrillShapeData(data.ShapeData);
		CamPars = new camParameters5(data.CamPars);
		Center = buVector5.ToPoint3D(data.Center);
		OffsetedPoint = buVector5.ToPoint3D(data.OffsetedPoint);
		CornerDirection = (Vector3D)data.CornerDirection.Clone();
		BoxMinOfDrawing = buVector5.ToPoint3D(data.BoxMinOfDrawing);
		BoxMaxOfDrawing = buVector5.ToPoint3D(data.BoxMaxOfDrawing);
		BoxMinItem = buVector5.ToPoint3D(data.BoxMinItem);
		BoxMaxItem = buVector5.ToPoint3D(data.BoxMaxItem);
		if (data.solidEntities != null)
		{
			buVector5.CopyEntities(data.solidEntities, ref solidEntities);
		}
		if (data.shapeEntitites != null)
		{
			buEntity.Copy(data.shapeEntitites, ref shapeEntitites);
		}
		if (data.camEntities != null)
		{
			buEntity.Copy(data.camEntities, ref camEntities);
		}
		planeOperation = (Plane)data.planeOperation.Clone();
	}

	public DrillItem(buShapeCut Item)
	{
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
		if (Item.isMilling)
		{
			Type = DrillItemType.SlotByMilling;
		}
		else
		{
			Type = DrillItemType.Slot;
		}
		if (Item.CutType == CutTypes.CutHorizontal)
		{
			Command = drillCommands.CutHorizontal;
		}
		if (Item.CutType == CutTypes.CutHorizontalLine)
		{
			Command = drillCommands.CutHorizontalLine;
		}
		if (Item.CutType == CutTypes.CutVertical)
		{
			Command = drillCommands.CutVertical;
		}
		if (Item.CutType == CutTypes.CutVerticalLine)
		{
			Command = drillCommands.CutVerticalLine;
		}
		if (Item.CutType == CutTypes.CutFree)
		{
			Command = drillCommands.CutFree;
		}
		Center = new Point3D(0.0 - Item.CalculatedPoint.X, 0.0 - Item.CalculatedPoint.Y, 0.0 - Item.CalculatedPoint.Z);
		BoxMaxOfDrawing = new Point3D(Item.ItemSize.MaxBox.X, Item.ItemSize.MaxBox.Y, Item.ItemSize.MaxBox.Z);
		BoxMinOfDrawing = new Point3D(Item.ItemSize.MinBox.X, Item.ItemSize.MinBox.Y, Item.ItemSize.MinBox.Z);
		BoxMaxItem = new Point3D(0.0 - Item.ItemSize.MinBox.X, 0.0 - Item.ItemSize.MinBox.Y, 0.0 - Item.ItemSize.MinBox.Z);
		BoxMinItem = new Point3D(0.0 - Item.ItemSize.MaxBox.X, 0.0 - Item.ItemSize.MaxBox.Y, 0.0 - Item.ItemSize.MaxBox.Z);
		ShapeData.Depth = Item.Depth;
		FeedCut = Item.feedCutting;
		FeedPlunge = Item.feedPlunge;
		SpindleSpeed = Item.SpindleSpeed;
		CamPars = new camParameters5(Item.CamPar);
		List<buEntity> copiedEntities = new List<buEntity>();
		buEntity.Copy(Item.entitiesShape, ref copiedEntities);
		shapeEntitites.Add(copiedEntities);
		bool flag = false;
		if (Item.Tool != null)
		{
			ToolMilling = new ToolBase5(Item.Tool);
		}
		if ((Item.CutType == CutTypes.CutVertical) | (Item.CutType == CutTypes.CutVerticalLine) | (Item.CutType == CutTypes.CutFree))
		{
			flag = true;
		}
		if (!(Item.isMilling || flag))
		{
			return;
		}
		copiedEntities = new List<buEntity>();
		if ((Item.CutType == CutTypes.CutHorizontal) | (Item.CutType == CutTypes.CutHorizontalLine))
		{
			if ((Item.planeName == planeBoxNames.Top) | (Item.planeName == planeBoxNames.Bottom) | (Item.planeName == planeBoxNames.Front) | (Item.planeName == planeBoxNames.Back))
			{
				Point3D start = new Point3D(Item.CalculatedPoint.X, Item.CalculatedPoint.Y, Item.CalculatedPoint.Z);
				Point3D end = new Point3D(Item.CalculatedPoint.X + Item.Length * Item.CornerDirection.X, Item.CalculatedPoint.Y, Item.CalculatedPoint.Z);
				buLine item = new buLine(start, end);
				copiedEntities.Add(item);
			}
			if ((Item.planeName == planeBoxNames.Left) | (Item.planeName == planeBoxNames.Right))
			{
				Point3D start2 = new Point3D(Item.CalculatedPoint.X, Item.CalculatedPoint.Y, Item.CalculatedPoint.Z);
				Point3D end2 = new Point3D(Item.CalculatedPoint.X, Item.CalculatedPoint.Y + Item.Length * Item.CornerDirection.Y, Item.CalculatedPoint.Z);
				buLine item2 = new buLine(start2, end2);
				copiedEntities.Add(item2);
			}
		}
		if ((Item.CutType == CutTypes.CutVertical) | (Item.CutType == CutTypes.CutVerticalLine))
		{
			if ((Item.planeName == planeBoxNames.Top) | (Item.planeName == planeBoxNames.Bottom))
			{
				Point3D start3 = new Point3D(Item.CalculatedPoint.X, Item.CalculatedPoint.Y, Item.CalculatedPoint.Z);
				Point3D end3 = new Point3D(Item.CalculatedPoint.X, Item.CalculatedPoint.Y + Item.Length * Item.CornerDirection.Y, Item.CalculatedPoint.Z);
				buLine item3 = new buLine(start3, end3);
				copiedEntities.Add(item3);
			}
			if ((Item.planeName == planeBoxNames.Front) | (Item.planeName == planeBoxNames.Back) | (Item.planeName == planeBoxNames.Right) | (Item.planeName == planeBoxNames.Left))
			{
				Point3D start4 = new Point3D(Item.CalculatedPoint.X, Item.CalculatedPoint.Y, Item.CalculatedPoint.Z);
				Point3D end4 = new Point3D(Item.CalculatedPoint.X, Item.CalculatedPoint.Y, Item.CalculatedPoint.Z + Item.Length * Item.CornerDirection.Z);
				buLine item4 = new buLine(start4, end4);
				copiedEntities.Add(item4);
			}
		}
		if (Item.CutType == CutTypes.CutFree && ((Item.planeName == planeBoxNames.Top) | (Item.planeName == planeBoxNames.Bottom)))
		{
			Point3D start5 = new Point3D(Item.CalculatedPoint.X, Item.CalculatedPoint.Y, Item.CalculatedPoint.Z);
			Point3D EndPnt = new Point3D();
			buCall.buVector5_0.LineWithLengthAndAngle(Item.CalculatedPoint, Item.Length, Item.Angle, ref EndPnt);
			buLine item5 = new buLine(start5, EndPnt);
			copiedEntities.Add(item5);
		}
		camEntities.Add(copiedEntities);
	}

	public DrillItem(buShapeHole Item)
	{
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
		Type = DrillItemType.ShapeDrill;
		Command = drillCommands.SingleHole;
		if (Item.Tool != null)
		{
			ToolMilling = new ToolBase5(Item.Tool);
		}
		Center = new Point3D(0.0 - Item.CalculatedPoint.X, 0.0 - Item.CalculatedPoint.Y, 0.0 - Item.CalculatedPoint.Z);
		BoxMaxOfDrawing = new Point3D(Item.ItemSize.MaxBox.X, Item.ItemSize.MaxBox.Y, Item.ItemSize.MaxBox.Z);
		BoxMinOfDrawing = new Point3D(Item.ItemSize.MinBox.X, Item.ItemSize.MinBox.Y, Item.ItemSize.MinBox.Z);
		BoxMaxItem = new Point3D(0.0 - Item.ItemSize.MinBox.X, 0.0 - Item.ItemSize.MinBox.Y, 0.0 - Item.ItemSize.MinBox.Z);
		BoxMinItem = new Point3D(0.0 - Item.ItemSize.MaxBox.X, 0.0 - Item.ItemSize.MaxBox.Y, 0.0 - Item.ItemSize.MaxBox.Z);
		ShapeData.Diameter = Item.Diameter;
		ShapeData.Depth = Item.Depth;
		CamPars = new camParameters5(Item.CamPar);
		List<buEntity> copiedEntities = new List<buEntity>();
		buEntity.Copy(Item.entitiesShape, ref copiedEntities);
		shapeEntitites.Add(copiedEntities);
	}

	public DrillItem(buShapeProfiling Item)
	{
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
		Type = DrillItemType.Profiling;
		ProfilingType = Item.ProfilingType;
		if (Item.Tool != null)
		{
			ToolMilling = new ToolBase5(Item.Tool);
		}
		Center = new Point3D(0.0 - Item.CalculatedPoint.X, 0.0 - Item.CalculatedPoint.Y, 0.0 - Item.CalculatedPoint.Z);
		BoxMaxOfDrawing = new Point3D(Item.ItemSize.MaxBox.X, Item.ItemSize.MaxBox.Y, Item.ItemSize.MaxBox.Z);
		BoxMinOfDrawing = new Point3D(Item.ItemSize.MinBox.X, Item.ItemSize.MinBox.Y, Item.ItemSize.MinBox.Z);
		BoxMaxItem = new Point3D(0.0 - Item.ItemSize.MinBox.X, 0.0 - Item.ItemSize.MinBox.Y, 0.0 - Item.ItemSize.MinBox.Z);
		BoxMinItem = new Point3D(0.0 - Item.ItemSize.MaxBox.X, 0.0 - Item.ItemSize.MaxBox.Y, 0.0 - Item.ItemSize.MaxBox.Z);
		ShapeData.Depth = Item.Depth;
		isPocket = Item.isPocket;
		CamPars = new camParameters5(Item.CamPar);
		List<buEntity> copiedEntities = new List<buEntity>();
		buEntity.Copy(Item.entitiesShape, ref copiedEntities);
		shapeEntitites.Add(copiedEntities);
		copiedEntities = new List<buEntity>();
		buEntity.Copy(Item.entitiesCam, ref copiedEntities);
		camEntities.Add(copiedEntities);
	}

	public DrillItem(buShapeEngrave Item)
	{
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
		Type = DrillItemType.Engraving;
		Command = drillCommands.Engraving;
		isRough = !Item.isFinish;
		isFinish = Item.isFinish;
		if (Item.Tool != null)
		{
			ToolMilling = new ToolBase5(Item.Tool);
		}
		Center = new Point3D(0.0 - Item.CalculatedPoint.X, 0.0 - Item.CalculatedPoint.Y, 0.0 - Item.CalculatedPoint.Z);
		BoxMaxOfDrawing = new Point3D(Item.ItemSize.MaxBox.X, Item.ItemSize.MaxBox.Y, Item.ItemSize.MaxBox.Z);
		BoxMinOfDrawing = new Point3D(Item.ItemSize.MinBox.X, Item.ItemSize.MinBox.Y, Item.ItemSize.MinBox.Z);
		BoxMaxItem = new Point3D(0.0 - Item.ItemSize.MinBox.X, 0.0 - Item.ItemSize.MinBox.Y, 0.0 - Item.ItemSize.MinBox.Z);
		BoxMinItem = new Point3D(0.0 - Item.ItemSize.MaxBox.X, 0.0 - Item.ItemSize.MaxBox.Y, 0.0 - Item.ItemSize.MaxBox.Z);
		CamPars = new camParameters5(Item.CamPar);
		List<buEntity> copiedEntities = new List<buEntity>();
		buEntity.Copy(Item.entitiesShape, ref copiedEntities);
		shapeEntitites.Add(copiedEntities);
		copiedEntities = new List<buEntity>();
		buEntity.Copy(Item.entitiesCam, ref copiedEntities);
		camEntities.Add(copiedEntities);
		buEntity.Copy(Item.entitySolid, ref solidEntities);
	}

	public DrillItem(buShape Item, bool Contour = false)
	{
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
		Type = DrillItemType.Shape;
		ShapeType = Item.ShapeType;
		if (Contour)
		{
			Type = DrillItemType.Contour;
			Offset = Item.OffsetDistance;
		}
		if (Item.Tool != null)
		{
			ToolMilling = new ToolBase5(Item.Tool);
		}
		ShapeData.Depth = Item.Depth;
		Center = new Point3D(0.0 - Item.CalculatedPoint.X, 0.0 - Item.CalculatedPoint.Y, 0.0 - Item.CalculatedPoint.Z);
		BoxMaxOfDrawing = new Point3D(Item.ItemSize.MaxBox.X, Item.ItemSize.MaxBox.Y, Item.ItemSize.MaxBox.Z);
		BoxMinOfDrawing = new Point3D(Item.ItemSize.MinBox.X, Item.ItemSize.MinBox.Y, Item.ItemSize.MinBox.Z);
		BoxMaxItem = new Point3D(0.0 - Item.ItemSize.MinBox.X, 0.0 - Item.ItemSize.MinBox.Y, 0.0 - Item.ItemSize.MinBox.Z);
		BoxMinItem = new Point3D(0.0 - Item.ItemSize.MaxBox.X, 0.0 - Item.ItemSize.MaxBox.Y, 0.0 - Item.ItemSize.MaxBox.Z);
		ShapeData.Depth = Item.Depth;
		isPocket = Item.isPocket;
		FeedCut = Item.feedCutting;
		FeedPlunge = Item.feedPlunge;
		SpindleSpeed = Item.SpindleSpeed;
		CamPars = new camParameters5(Item.CamPar);
		List<buEntity> copiedEntities = new List<buEntity>();
		buEntity.Copy(Item.entitiesShape, ref copiedEntities);
		if (Item.ShapeType == ShapeTypes.FreeLines && Item.entityWireframe != null)
		{
			copiedEntities = new List<buEntity>();
			buEntity.Copy(Item.entityWireframe, ref copiedEntities);
			camEntities.Add(copiedEntities);
		}
		shapeEntitites.Add(copiedEntities);
	}

	public static void Copy(List<DrillItem> RefItem, ref List<DrillItem> CopiedItem)
	{
		CopiedItem.Clear();
		CopiedItem = new List<DrillItem>();
		for (int i = 0; i <= RefItem.Count - 1; i++)
		{
			DrillItem CopiedItem2 = new DrillItem();
			Copy(RefItem[i], ref CopiedItem2);
			CopiedItem.Add(CopiedItem2);
		}
	}

	public static void Copy(DrillItem RefItem, ref DrillItem CopiedItem)
	{
		CopiedItem = new DrillItem(RefItem);
	}

	public static ArrayList ToDefPars(DrillItem P, string Char, int Space)
	{
		string text = "DrillItemPars";
		if (Char.Trim().Length > 0)
		{
			text = Char;
		}
		ArrayList arrayList = new ArrayList();
		arrayList.Add(buString5.SpaceChar(Space) + "<" + text);
		arrayList.Add(buString5.SpaceChar(Space + 2) + ToDefPars(P));
		arrayList.Add(buString5.SpaceChar(Space) + "</" + text);
		return arrayList;
	}

	public static List<string> ToDefPars(DrillItem P, int Space)
	{
		List<string> list = new List<string>();
		list.Add(buString5.SpaceChar(Space) + "<DrillItemPars>");
		list.Add(buString5.SpaceChar(Space + 2) + ToDefPars(P));
		list.Add(buString5.SpaceChar(Space) + "</DrillItemPars>");
		return list;
	}

	public static string ToDefPars(DrillItem P)
	{
		return buSerilization5.ClassToString(P);
	}

	public static ArrayList ToDef(List<DrillItem> Items, int Space)
	{
		new string(' ', Space);
		ArrayList arrayList = new ArrayList();
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			ArrayList arrayList2 = new ArrayList();
			arrayList.AddRange(arrayList2.ToArray());
		}
		return arrayList;
	}

	public static ArrayList ToDef(DrillItem Item, string Char, int Space)
	{
		buSerilization5.ClassToString(Item);
		string text = new string(' ', Space);
		ArrayList arrayList = new ArrayList();
		arrayList.AddRange(Item.ToDefAll("", Space + 2, SerilizationMode5.MultiLine));
		arrayList.RemoveAt(arrayList.Count - 1);
		arrayList.Add(text + "</DrillItem>");
		return arrayList;
	}

	public static void Decode(ArrayList AL, ref List<DrillItem> Items)
	{
		Items.Clear();
		Items = new List<DrillItem>();
		new List<List<string>>();
		List<List<string>> CalcList = new List<List<string>>();
		buStatics.ListToSpecificList("<DrillItem>", "</DrillItem>", AddStartEndKey: true, AL, ref CalcList);
		for (int i = 0; i <= CalcList.Count - 1; i++)
		{
			ArrayList arrayList = new ArrayList();
			arrayList.AddRange(CalcList[i].ToArray());
			DrillItem Item = new DrillItem();
			Decode(arrayList, ref Item);
			Items.Add(Item);
		}
	}

	public static void Decode(ArrayList AL, ref DrillItem Item)
	{
		Item = new DrillItem();
		buSerilization5.Decode(AL, "", SerilizationMode5.MultiLine, Item);
		new List<List<string>>();
	}

	public override string ToString()
	{
		string text = planeName.ToString() + " Center : " + Center.ToString() + " - Dia: " + ShapeData.Diameter.ToString("f3") + " - Dpth: " + ShapeData.Depth.ToString("f3") + " - Calc: " + Calculated;
		if (Tool > 0)
		{
			text = text + " T:" + Tool;
		}
		return text;
	}
}
