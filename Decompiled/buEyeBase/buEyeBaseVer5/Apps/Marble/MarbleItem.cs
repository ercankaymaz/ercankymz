using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleItem : buSerilization5
{
	public string ItemName = "";

	public string FileName = "";

	public string FileNameFull = "";

	public bool IsSorted = false;

	public bool isSimulationDone = false;

	public bool isError = false;

	public bool isVerticalItem = false;

	public bool isTextVertical = false;

	public bool isVacuumCut = false;

	public bool MoveAble = true;

	public bool Enable = true;

	public bool Visible = true;

	public bool Selected = false;

	public bool MoveAfterDone = false;

	public bool DontCheckPartLimits = false;

	public string TextureName = "";

	public double MaterialThickness = 0.0;

	public double BaseHeight = 0.0;

	public double SawExtensionDistance = 0.0;

	public double OffsetX = 0.0;

	public double OffsetY = 0.0;

	public int Transparency = 120;

	public int ID = -1;

	public int MovedID = -1;

	public int indexItem = -1;

	public MarbleItemType ItemType = MarbleItemType.HorizontalCut;

	public MarbleShapeTypes ShapeType = MarbleShapeTypes.Rectangle;

	public MarbleToolType ToolType = MarbleToolType.Saw;

	public ClockDirectionType ClockDir = ClockDirectionType.CW;

	public List<MarbleItemCommands> ItemCommands = new List<MarbleItemCommands>();

	public Color colorItem = Color.DarkGray;

	public ObjectSize3D SizeItem = new ObjectSize3D();

	public Point3D MovePoint = new Point3D();

	public Point3D BasePoint = new Point3D();

	public Point3D CalcMovePoint = null;

	public Pnt6D CamPoint = new Pnt6D();

	public Point3D SortRefPoint = new Point3D();

	public MaterialSkin Skin = new MaterialSkin();

	public buEntitiesGroup EntGroup = null;

	public buEntitiesGroup EntGroupBottom = null;

	public MarbleItemEntities ItemEntities = new MarbleItemEntities();

	public List<marbleEdgeItem> Edges = new List<marbleEdgeItem>();

	public List<marbleCollapseItem> Collapses = new List<marbleCollapseItem>();

	public List<MarbleItemCam> CamList = new List<MarbleItemCam>();

	public MarbleItemSettings Settings = new MarbleItemSettings();

	public List<OsnapPoint> OsnapPoints = new List<OsnapPoint>();

	public List<MarbleItemExtend> Extends = new List<MarbleItemExtend>();

	public marbleCounterTopBase Countertop = null;

	public List<string> ErrorMessages = new List<string>();

	public List<string> WarningMessages = new List<string>();

	public MarbleItem()
	{
	}

	public MarbleItem(MarbleItem data)
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
		Skin = new MaterialSkin(data.Skin);
		BasePoint = new Point3D(data.BasePoint.X, data.BasePoint.Y, data.BasePoint.Z);
		MovePoint = new Point3D(data.MovePoint.X, data.MovePoint.Y, data.MovePoint.Z);
		Settings = new MarbleItemSettings(data.Settings);
		if (data.CalcMovePoint != null)
		{
			CalcMovePoint = new Point3D(data.CalcMovePoint.X, data.CalcMovePoint.Y, data.CalcMovePoint.Z);
		}
		ItemCommands.Clear();
		for (int j = 0; j <= data.ItemCommands.Count - 1; j++)
		{
			ItemCommands.Add(data.ItemCommands[j]);
		}
		if (data.CamList != null && data.CamList.Count > 0)
		{
			for (int k = 0; k <= data.CamList.Count - 1; k++)
			{
				CamList.Add(new MarbleItemCam(data.CamList[k]));
			}
		}
		if (data.CamList != null && data.Extends.Count > 0)
		{
			for (int l = 0; l <= data.Extends.Count - 1; l++)
			{
				Extends.Add(new MarbleItemExtend(data.Extends[l]));
			}
		}
		if (data.Edges != null && data.Edges.Count > 0)
		{
			for (int m = 0; m <= data.Edges.Count - 1; m++)
			{
				Edges.Add(new marbleEdgeItem(data.Edges[m]));
			}
		}
		if (data.Collapses != null && data.Collapses.Count > 0)
		{
			for (int n = 0; n <= data.Collapses.Count - 1; n++)
			{
				Collapses.Add(new marbleCollapseItem(data.Collapses[n]));
			}
		}
		if (data.EntGroup != null)
		{
			EntGroup = new buEntitiesGroup(data.EntGroup);
		}
		if (data.EntGroupBottom != null)
		{
			EntGroupBottom = new buEntitiesGroup(data.EntGroupBottom);
		}
		if (data.ItemEntities != null)
		{
			ItemEntities = new MarbleItemEntities(data.ItemEntities);
		}
	}

	public static void Copy(List<MarbleItem> Items, ref List<MarbleItem> CopyItems)
	{
		CopyItems = new List<MarbleItem>();
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			CopyItems.Add(new MarbleItem(Items[i]));
		}
	}

	public static ArrayList ToDef(MarbleItem refItem, int Space)
	{
		string text = "";
		ArrayList arrayList = new ArrayList();
		buSerilization5.ExceptionalVariables.Clear();
		buSerilization5.ExceptionalVariables.Add("ErrorMessages");
		buSerilization5.ExceptionalVariables.Add("WarningMessages");
		buSerilization5.ExceptionalVariables.Add("ItemEntities");
		buSerilization5.ExceptionalVariables.Add("OsnapPoints");
		buSerilization5.ExceptionalVariables.Add("CamList");
		buSerilization5.ExceptionalVariables.Add("EntGroup");
		buSerilization5.ExceptionalVariables.Add("ItemEntities");
		buSerilization5.ExceptionalVariables.Add("Edges");
		buSerilization5.ExceptionalVariables.Add("Collapses");
		buSerilization5.ExceptionalVariables.Add("Settings");
		buSerilization5.ClassToString(refItem);
		arrayList.AddRange(refItem.ToDefAll("", Space, SerilizationMode5.MultiLine));
		if (arrayList.Count > 0)
		{
			text = arrayList[arrayList.Count - 1].ToString();
			arrayList.RemoveAt(arrayList.Count - 1);
			arrayList.Add(buString5.SpaceChar(Space + 2) + "<ItemSettings>");
			arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItem.Settings.MaterialParameter));
			arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItem.Settings.ReadSurfaceParameter));
			arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItem.Settings.SawFeedAnalysisParameter));
			arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItem.Settings.settingAirDry));
			arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItem.Settings.settingChamferCut));
			arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItem.Settings.settingColoumnsCut));
			arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItem.Settings.settingDrillCut));
			arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItem.Settings.settingLatheCut));
			arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItem.Settings.settingLatheVerticalCut));
			arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItem.Settings.settingMarbleCam));
			arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItem.Settings.settingMaterialClean));
			arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItem.Settings.settingProfileCurveCut));
			arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItem.Settings.settingProfileCut));
			arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItem.Settings.settingSliceCut));
			arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItem.Settings.settingSweepCut));
			arrayList.Add(buString5.SpaceChar(Space + 2) + "</ItemSettings>");
			if (refItem.Edges != null && refItem.Edges.Count > 0)
			{
				arrayList.Add(buString5.SpaceChar(Space + 2) + "<ItemEdges>");
				for (int i = 0; i <= refItem.Edges.Count - 1; i++)
				{
					arrayList.Add(buString5.SpaceChar(Space + 4) + "<ItemEdge>");
					arrayList.AddRange(refItem.Edges[i].ToDefAll("", Space + 6, SerilizationMode5.MultiLine));
					if (refItem.Edges[i].refEntity != null)
					{
						arrayList.Add(buString5.SpaceChar(Space + 6) + "<ItemEdgeRefEntity>");
						arrayList.AddRange(buEntity.ToDefEntity(refItem.Edges[i].refEntity, Space + 8));
						arrayList.Add(buString5.SpaceChar(Space + 6) + "</ItemEdgeRefEntity>");
						arrayList.Add(buString5.SpaceChar(Space + 6) + "<ItemEdgeDrawEntity>");
						arrayList.AddRange(buEntity.ToDefEntity(refItem.Edges[i].drawEntity, Space + 8));
						arrayList.Add(buString5.SpaceChar(Space + 6) + "</ItemEdgeDrawEntity>");
					}
					arrayList.Add(buString5.SpaceChar(Space + 4) + "</ItemEdge>");
				}
				arrayList.Add(buString5.SpaceChar(Space + 2) + "</ItemEdges>");
			}
			if (refItem.Collapses != null && refItem.Collapses.Count > 0)
			{
				arrayList.Add(buString5.SpaceChar(Space + 2) + "<ItemCollapses>");
				for (int j = 0; j <= refItem.Collapses.Count - 1; j++)
				{
					arrayList.AddRange(refItem.Collapses[j].ToDefAll("", Space + 4, SerilizationMode5.MultiLine));
				}
				arrayList.Add(buString5.SpaceChar(Space + 2) + "</ItemCollapses>");
			}
			if (refItem.EntGroup != null)
			{
				arrayList.Add(buString5.SpaceChar(Space + 2) + "<ItemEntGroup>");
				arrayList.AddRange(buEntitiesGroup.ToDefGroup(refItem.EntGroup, Space + 4));
				arrayList.Add(buString5.SpaceChar(Space + 2) + "</ItemEntGroup>");
			}
			if (refItem.EntGroupBottom != null)
			{
				arrayList.Add(buString5.SpaceChar(Space + 2) + "<ItemEntGroupBottom>");
				arrayList.AddRange(buEntitiesGroup.ToDefGroup(refItem.EntGroupBottom, Space + 4));
				arrayList.Add(buString5.SpaceChar(Space + 2) + "</ItemEntGroupBottom>");
			}
			arrayList.Add(buString5.SpaceChar(Space + 2) + "<ItemEntities>");
			if (refItem.ItemEntities.DrawWireEntities != null && refItem.ItemEntities.DrawWireEntities.Count > 0)
			{
				arrayList.Add(buString5.SpaceChar(Space + 4) + "<DrawWireEntities>");
				arrayList.AddRange(buEntity.ToDefEntity(refItem.ItemEntities.DrawWireEntities, Space + 6));
				arrayList.Add(buString5.SpaceChar(Space + 4) + "</DrawWireEntities>");
			}
			if (refItem.ItemEntities.ConcaveEntities != null && refItem.ItemEntities.ConcaveEntities.Count > 0)
			{
				arrayList.Add(buString5.SpaceChar(Space + 4) + "<ConcaveEntities>");
				arrayList.AddRange(buEntity.ToDefEntity(refItem.ItemEntities.ConcaveEntities, Space + 6));
				arrayList.Add(buString5.SpaceChar(Space + 4) + "</ConcaveEntities>");
			}
			if (refItem.ItemEntities.ConvexEntities != null && refItem.ItemEntities.ConvexEntities.Count > 0)
			{
				arrayList.Add(buString5.SpaceChar(Space + 4) + "<ConvexEntities>");
				arrayList.AddRange(buEntity.ToDefEntity(refItem.ItemEntities.ConvexEntities, Space + 6));
				arrayList.Add(buString5.SpaceChar(Space + 4) + "</ConvexEntities>");
			}
			if (refItem.ItemEntities.DrillEntities != null && refItem.ItemEntities.ConcaveEntities.Count > 0)
			{
				arrayList.Add(buString5.SpaceChar(Space + 4) + "<DrillEntities>");
				arrayList.AddRange(buEntity.ToDefEntity(refItem.ItemEntities.DrillEntities, Space + 6));
				arrayList.Add(buString5.SpaceChar(Space + 4) + "</DrillEntities>");
			}
			if (refItem.ItemEntities.EdgeEntities != null && refItem.ItemEntities.EdgeEntities.Count > 0)
			{
				arrayList.Add(buString5.SpaceChar(Space + 4) + "<EdgeEntities>");
				arrayList.AddRange(buEntity.ToDefEntity(refItem.ItemEntities.EdgeEntities, Space + 6));
				arrayList.Add(buString5.SpaceChar(Space + 4) + "</EdgeEntities>");
			}
			if (refItem.ItemEntities.ExtensionEntities != null && refItem.ItemEntities.ExtensionEntities.Count > 0)
			{
				arrayList.Add(buString5.SpaceChar(Space + 4) + "<ExtensionEntities>");
				arrayList.AddRange(buEntity.ToDefEntity(refItem.ItemEntities.ExtensionEntities, Space + 6));
				arrayList.Add(buString5.SpaceChar(Space + 4) + "</ExtensionEntities>");
			}
			if (refItem.ItemEntities.WireEntities != null && refItem.ItemEntities.WireEntities.Count > 0)
			{
				arrayList.Add(buString5.SpaceChar(Space + 4) + "<WireEntities>");
				arrayList.AddRange(buEntity.ToDefEntity(refItem.ItemEntities.WireEntities, Space + 6));
				arrayList.Add(buString5.SpaceChar(Space + 4) + "</WireEntities>");
			}
			if (refItem.ItemEntities.BaseEntities != null && refItem.ItemEntities.BaseEntities.Count > 0)
			{
				arrayList.Add(buString5.SpaceChar(Space + 4) + "<BaseEntities>");
				arrayList.AddRange(buEntity.ToDefEntity(refItem.ItemEntities.BaseEntities, Space + 6));
				arrayList.Add(buString5.SpaceChar(Space + 4) + "</BaseEntities>");
			}
			if (refItem.ItemEntities.CamEntities != null && refItem.ItemEntities.CamEntities.Count > 0)
			{
				arrayList.Add(buString5.SpaceChar(Space + 4) + "<CamEntities>");
				arrayList.AddRange(buEntity.ToDefEntity(refItem.ItemEntities.CamEntities, Space + 6));
				arrayList.Add(buString5.SpaceChar(Space + 4) + "</CamEntities>");
			}
			if (refItem.ItemEntities.BorderEntities != null && refItem.ItemEntities.BorderEntities.Count > 0)
			{
				arrayList.Add(buString5.SpaceChar(Space + 4) + "<BorderEntities>");
				arrayList.AddRange(buEntity.ToDefEntity(refItem.ItemEntities.BorderEntities, Space + 6));
				arrayList.Add(buString5.SpaceChar(Space + 4) + "</BorderEntities>");
			}
			if (refItem.ItemEntities.EngravingEntities != null && refItem.ItemEntities.EngravingEntities.Count > 0)
			{
				arrayList.Add(buString5.SpaceChar(Space + 4) + "<EngravingEntities>");
				arrayList.AddRange(buEntity.ToDefEntity(refItem.ItemEntities.EngravingEntities, Space + 6));
				arrayList.Add(buString5.SpaceChar(Space + 4) + "</EngravingEntities>");
			}
			if (refItem.ItemEntities.SawEntities != null && refItem.ItemEntities.TextEntities.Count > 0)
			{
				arrayList.Add(buString5.SpaceChar(Space + 4) + "<TextEntities>");
				arrayList.AddRange(buEntity.ToDefEntity(refItem.ItemEntities.TextEntities, Space + 6));
				arrayList.Add(buString5.SpaceChar(Space + 4) + "</TextEntities>");
			}
			arrayList.Add(buString5.SpaceChar(Space + 2) + "</ItemEntities>");
			if (refItem.CamList == null || refItem.CamList.Count <= 0)
			{
			}
			arrayList.Add(text);
		}
		return arrayList;
	}

	public static void Decode(List<string> SL, ref MarbleItem refItem)
	{
		try
		{
			refItem = new MarbleItem();
			buSerilization5.Decode(SL, "", SerilizationMode5.MultiLine, refItem);
			List<List<string>> list = new List<List<string>>();
			List<string> CalcList = new List<string>();
			buStatics.ListToSpecificList("<ItemEntGroup>", "</ItemEntGroup>", AddStartEndKey: false, SL, ref CalcList);
			if (CalcList.Count > 0)
			{
				refItem.EntGroup = new buEntitiesGroup();
				buEntitiesGroup.Decode(CalcList, ref refItem.EntGroup);
			}
			CalcList.Clear();
			buStatics.ListToSpecificList("<ItemEntGroupBottom>", "</ItemEntGroupBottom>", AddStartEndKey: false, SL, ref CalcList);
			if (CalcList.Count > 0)
			{
				refItem.EntGroupBottom = new buEntitiesGroup();
				buEntitiesGroup.Decode(CalcList, ref refItem.EntGroupBottom);
			}
			CalcList.Clear();
			buStatics.ListToSpecificList("<ItemSettings>", "</ItemSettings>", AddStartEndKey: false, SL, ref CalcList);
			if (CalcList.Count > 0)
			{
				if (CalcList.Count >= 1)
				{
					object ObjPar = refItem.Settings.MaterialParameter;
					buSerilization5.StringToClass(ref ObjPar, CalcList[0]);
				}
				if (CalcList.Count >= 2)
				{
					object ObjPar2 = refItem.Settings.ReadSurfaceParameter;
					buSerilization5.StringToClass(ref ObjPar2, CalcList[1]);
				}
				if (CalcList.Count >= 3)
				{
					object ObjPar3 = refItem.Settings.SawFeedAnalysisParameter;
					buSerilization5.StringToClass(ref ObjPar3, CalcList[2]);
				}
				if (CalcList.Count >= 4)
				{
					object ObjPar4 = refItem.Settings.settingAirDry;
					buSerilization5.StringToClass(ref ObjPar4, CalcList[3]);
				}
				if (CalcList.Count >= 5)
				{
					object ObjPar5 = refItem.Settings.settingChamferCut;
					buSerilization5.StringToClass(ref ObjPar5, CalcList[4]);
				}
				if (CalcList.Count >= 6)
				{
					object ObjPar6 = refItem.Settings.settingColoumnsCut;
					buSerilization5.StringToClass(ref ObjPar6, CalcList[5]);
				}
				if (CalcList.Count >= 7)
				{
					object ObjPar7 = refItem.Settings.settingDrillCut;
					buSerilization5.StringToClass(ref ObjPar7, CalcList[6]);
				}
				if (CalcList.Count >= 8)
				{
					object ObjPar8 = refItem.Settings.settingLatheCut;
					buSerilization5.StringToClass(ref ObjPar8, CalcList[7]);
				}
				if (CalcList.Count >= 9)
				{
					object ObjPar9 = refItem.Settings.settingLatheVerticalCut;
					buSerilization5.StringToClass(ref ObjPar9, CalcList[8]);
				}
				if (CalcList.Count >= 10)
				{
					object ObjPar10 = refItem.Settings.settingMarbleCam;
					buSerilization5.StringToClass(ref ObjPar10, CalcList[9]);
				}
				if (CalcList.Count >= 11)
				{
					object ObjPar11 = refItem.Settings.settingMaterialClean;
					buSerilization5.StringToClass(ref ObjPar11, CalcList[10]);
				}
				if (CalcList.Count >= 12)
				{
					object ObjPar12 = refItem.Settings.settingProfileCurveCut;
					buSerilization5.StringToClass(ref ObjPar12, CalcList[11]);
				}
				if (CalcList.Count >= 13)
				{
					object ObjPar13 = refItem.Settings.settingProfileCut;
					buSerilization5.StringToClass(ref ObjPar13, CalcList[12]);
				}
				if (CalcList.Count >= 14)
				{
					object ObjPar14 = refItem.Settings.settingSliceCut;
					buSerilization5.StringToClass(ref ObjPar14, CalcList[13]);
				}
				if (CalcList.Count >= 15)
				{
					object ObjPar15 = refItem.Settings.settingSweepCut;
					buSerilization5.StringToClass(ref ObjPar15, CalcList[14]);
				}
				CalcList.Clear();
			}
			CalcList.Clear();
			buStatics.ListToSpecificList("<ItemCollapses>", "</ItemCollapses>", AddStartEndKey: false, SL, ref CalcList);
			if (CalcList.Count > 0)
			{
				list = new List<List<string>>();
				buStatics.ListToSpecificList("<marbleCollapseItem>", "</marbleCollapseItem>", AddStartEndKey: true, CalcList, ref list);
				if (list.Count > 0)
				{
					for (int i = 0; i <= list.Count - 1; i++)
					{
						marbleCollapseItem marbleCollapseItem2 = new marbleCollapseItem();
						buSerilization5.Decode(list[i], "", SerilizationMode5.MultiLine, marbleCollapseItem2);
						refItem.Collapses.Add(marbleCollapseItem2);
					}
				}
			}
			CalcList.Clear();
			if (CalcList.Count > 0)
			{
				list = new List<List<string>>();
				buStatics.ListToSpecificList("<ItemEdge>", "</ItemEdge>", AddStartEndKey: false, CalcList, ref list);
				if (list.Count > 0)
				{
					for (int j = 0; j <= list.Count - 1; j++)
					{
						marbleEdgeItem marbleEdgeItem2 = null;
						List<string> CalcList2 = new List<string>();
						buStatics.ListToSpecificList("<marbleEdgeItem>", "</marbleEdgeItem>", AddStartEndKey: true, list[j], ref CalcList2);
						if (CalcList2.Count >= 0)
						{
							marbleEdgeItem2 = new marbleEdgeItem();
							buSerilization5.Decode(list[j], "", SerilizationMode5.MultiLine, marbleEdgeItem2);
						}
						if (marbleEdgeItem2 == null)
						{
							continue;
						}
						CalcList2 = new List<string>();
						buStatics.ListToSpecificList("<ItemEdgeRefEntity>", "</ItemEdgeRefEntity>", AddStartEndKey: false, list[j], ref CalcList2);
						if (CalcList2.Count > 0)
						{
							if (CalcList2[0].IndexOf("<buEntity>") >= 0)
							{
								CalcList2.RemoveAt(0);
							}
							buEntity.Decode(CalcList2, ref marbleEdgeItem2.refEntity);
						}
						CalcList2 = new List<string>();
						buStatics.ListToSpecificList("<ItemEdgeDrawEntity>", "</ItemEdgeDrawEntity>", AddStartEndKey: false, list[j], ref CalcList2);
						if (CalcList2.Count > 0)
						{
							if (CalcList2[0].IndexOf("<buEntity>") >= 0)
							{
								CalcList2.RemoveAt(0);
							}
							buEntity.Decode(CalcList2, ref marbleEdgeItem2.drawEntity);
						}
						refItem.Edges.Add(marbleEdgeItem2);
					}
				}
			}
			CalcList.Clear();
			buStatics.ListToSpecificList("<ItemEntities>", "</ItemEntities>", AddStartEndKey: false, SL, ref CalcList);
			if (CalcList.Count > 0)
			{
				List<string> CalcList3 = new List<string>();
				buStatics.ListToSpecificList("<DrawWireEntities>", "</DrawWireEntities>", AddStartEndKey: true, CalcList, ref CalcList3);
				if (CalcList3.Count >= 0)
				{
					refItem.ItemEntities.DrawWireEntities = new List<buEntity>();
					buEntity.Decode(CalcList3, ref refItem.ItemEntities.DrawWireEntities);
					CalcList3.Clear();
				}
				buStatics.ListToSpecificList("<BaseEntities>", "</BaseEntities>", AddStartEndKey: true, CalcList, ref CalcList3);
				if (CalcList3.Count >= 0)
				{
					refItem.ItemEntities.BaseEntities = new List<buEntity>();
					buEntity.Decode(CalcList3, ref refItem.ItemEntities.BaseEntities);
					CalcList3.Clear();
				}
				buStatics.ListToSpecificList("<CamEntities>", "</CamEntities>", AddStartEndKey: true, CalcList, ref CalcList3);
				if (CalcList3.Count >= 0)
				{
					refItem.ItemEntities.CamEntities = new List<List<buEntity>>();
					buEntity.Decode(CalcList3, ref refItem.ItemEntities.CamEntities);
					CalcList3.Clear();
				}
				buStatics.ListToSpecificList("<BorderEntities>", "</BorderEntities>", AddStartEndKey: true, CalcList, ref CalcList3);
				if (CalcList3.Count >= 0)
				{
					refItem.ItemEntities.BorderEntities = new List<buEntity>();
					buEntity.Decode(CalcList3, ref refItem.ItemEntities.BorderEntities);
					CalcList3.Clear();
				}
				buStatics.ListToSpecificList("<ConcaveEntities>", "</ConcaveEntities>", AddStartEndKey: true, CalcList, ref CalcList3);
				if (CalcList3.Count >= 0)
				{
					refItem.ItemEntities.ConcaveEntities = new List<List<buEntity>>();
					buEntity.Decode(CalcList3, ref refItem.ItemEntities.ConcaveEntities);
					CalcList3.Clear();
				}
				buStatics.ListToSpecificList("<ConvexEntities>", "</ConvexEntities>", AddStartEndKey: true, CalcList, ref CalcList3);
				if (CalcList3.Count >= 0)
				{
					refItem.ItemEntities.ConvexEntities = new List<List<buEntity>>();
					buEntity.Decode(CalcList3, ref refItem.ItemEntities.ConvexEntities);
					CalcList3.Clear();
				}
				buStatics.ListToSpecificList("<DrillEntities>", "</DrillEntities>", AddStartEndKey: true, CalcList, ref CalcList3);
				if (CalcList3.Count >= 0)
				{
					refItem.ItemEntities.DrillEntities = new List<buEntity>();
					buEntity.Decode(CalcList3, ref refItem.ItemEntities.DrillEntities);
					CalcList3.Clear();
				}
				buStatics.ListToSpecificList("<EdgeEntities>", "</EdgeEntities>", AddStartEndKey: true, CalcList, ref CalcList3);
				if (CalcList3.Count >= 0)
				{
					refItem.ItemEntities.EdgeEntities = new List<buEntity>();
					buEntity.Decode(CalcList3, ref refItem.ItemEntities.EdgeEntities);
					CalcList3.Clear();
				}
				buStatics.ListToSpecificList("<EngravingEntities>", "</EngravingEntities>", AddStartEndKey: true, CalcList, ref CalcList3);
				if (CalcList3.Count >= 0)
				{
					refItem.ItemEntities.EngravingEntities = new List<buEntity>();
					buEntity.Decode(CalcList3, ref refItem.ItemEntities.EngravingEntities);
					CalcList3.Clear();
				}
				buStatics.ListToSpecificList("<ExtensionEntities>", "</ExtensionEntities>", AddStartEndKey: true, CalcList, ref CalcList3);
				if (CalcList3.Count >= 0)
				{
					refItem.ItemEntities.ExtensionEntities = new List<buEntity>();
					buEntity.Decode(CalcList3, ref refItem.ItemEntities.ExtensionEntities);
					CalcList3.Clear();
				}
				buStatics.ListToSpecificList("<SourceEntities>", "</SourceEntities>", AddStartEndKey: true, CalcList, ref CalcList3);
				if (CalcList3.Count >= 0)
				{
					refItem.ItemEntities.SourceEntities = new List<buEntity>();
					buEntity.Decode(CalcList3, ref refItem.ItemEntities.SourceEntities);
					CalcList3.Clear();
				}
				buStatics.ListToSpecificList("<TextEntities>", "</TextEntities>", AddStartEndKey: true, CalcList, ref CalcList3);
				if (CalcList3.Count >= 0)
				{
					refItem.ItemEntities.TextEntities = new List<buEntity>();
					buEntity.Decode(CalcList3, ref refItem.ItemEntities.TextEntities);
					CalcList3.Clear();
				}
				buStatics.ListToSpecificList("<WireEntities>", "</WireEntities>", AddStartEndKey: true, CalcList, ref CalcList3);
				if (CalcList3.Count >= 0)
				{
					refItem.ItemEntities.WireEntities = new List<List<buEntity>>();
					buEntity.Decode(CalcList3, ref refItem.ItemEntities.WireEntities);
					CalcList3.Clear();
				}
			}
			CalcList.Clear();
			buStatics.ListToSpecificList("<ItemCamList>", "</ItemCamList>", AddStartEndKey: false, SL, ref CalcList);
			if (CalcList.Count > 0)
			{
				refItem.CamList = new List<MarbleItemCam>();
				MarbleItemCam.Decode(CalcList, ref refItem.CamList);
				CalcList.Clear();
			}
		}
		catch (Exception)
		{
		}
	}

	public static void Decode(List<string> SL, ref List<MarbleItem> refItes)
	{
		try
		{
			refItes = new List<MarbleItem>();
			if (SL.Count <= 0)
			{
				return;
			}
			List<List<string>> CalcList = new List<List<string>>();
			buStatics.ListToSpecificList("<MarbleItem>", "</MarbleItem>", AddStartEndKey: true, SL, ref CalcList);
			if (CalcList.Count > 0)
			{
				for (int i = 0; i <= CalcList.Count - 1; i++)
				{
					MarbleItem refItem = new MarbleItem();
					Decode(CalcList[i], ref refItem);
					refItes.Add(refItem);
					CalcList[i].Clear();
				}
				CalcList.Clear();
			}
		}
		catch (Exception)
		{
		}
	}

	public override string ToString()
	{
		string text = "Type:" + ItemType.ToString() + " , ID:" + ID;
		if (MovedID >= 0)
		{
			text = text + " - " + MovedID;
		}
		return text;
	}
}
