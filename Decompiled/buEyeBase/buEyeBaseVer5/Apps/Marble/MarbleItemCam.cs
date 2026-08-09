using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleItemCam : buSerilization5
{
	public string CamName = "";

	public bool isCamCalculated = false;

	public bool isConcave = false;

	public bool isConvex = false;

	public bool isTempCam = false;

	public bool isDrill = false;

	public bool isRough = false;

	public bool isFinish = false;

	public bool Visible = true;

	public Color colorItem = Color.DarkGray;

	public int Transparency = 120;

	public int CamID = -1;

	public int ItemID = -1;

	public int ID = -1;

	public int indexInside = -1;

	public int indexOpen = -1;

	public int indexCollapse = -1;

	public int indexItem = -1;

	public int indexCam = -1;

	public int AxesNumber = 3;

	public MarbleToolType ToolType = MarbleToolType.Saw;

	public MarbleCamType CamMarbleType = MarbleCamType.None;

	public MarbleCamMode CamMode = MarbleCamMode.Finish;

	public CamWireFrameType WireType = CamWireFrameType.Contour;

	public CamTriangularMeshType MeshType = CamTriangularMeshType.Rough;

	public CamType CamType = CamType.None;

	public ClockDirectionType BaseClockDir = ClockDirectionType.CCW;

	public InOutCenterType Direction = InOutCenterType.Outside;

	public planeNames CamPlane = planeNames.Top;

	public ObjectSize3D SizeCamItem = new ObjectSize3D();

	public ToolBase5 ToolSelected = null;

	public camTp CamBase = null;

	public camParameters5 setCam = new camParameters5();

	public buEntityList EntityList = null;

	public List<buEntity> CamEntities = null;

	public List<List<buEntity>> WireAuxEntities = null;

	public List<List<buEntity>> WireEntities = null;

	public List<List<buEntity>> ConcaveEntities = null;

	public List<List<buEntity>> ConvexEntities = null;

	public List<buEntity> DrillEntities = null;

	public List<Entity> SolidEntities = null;

	public List<buEntity> DrawEntities = null;

	public MarbleItemCam()
	{
	}

	public MarbleItemCam(MarbleItemCam data)
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
		SizeCamItem = new ObjectSize3D(data.SizeCamItem);
		setCam = new camParameters5(data.setCam);
		if (data.CamEntities != null)
		{
			CamEntities = new List<buEntity>();
			buEntity.Copy(data.CamEntities, ref CamEntities);
		}
		if (data.EntityList != null)
		{
			EntityList = new buEntityList(data.EntityList);
		}
		if (data.ConcaveEntities != null)
		{
			ConcaveEntities = new List<List<buEntity>>();
			buEntity.Copy(data.ConcaveEntities, ref ConcaveEntities);
		}
		if (data.DrawEntities != null)
		{
			DrawEntities = new List<buEntity>();
			buEntity.Copy(data.DrawEntities, ref DrawEntities);
		}
		if (data.DrillEntities != null)
		{
			DrillEntities = new List<buEntity>();
			buEntity.Copy(data.DrillEntities, ref DrillEntities);
		}
		if (data.ConvexEntities != null)
		{
			ConvexEntities = new List<List<buEntity>>();
			buEntity.Copy(data.ConvexEntities, ref ConvexEntities);
		}
		if (data.WireEntities != null)
		{
			WireEntities = new List<List<buEntity>>();
			buEntity.Copy(data.WireEntities, ref WireEntities);
		}
		if (data.WireAuxEntities != null)
		{
			WireAuxEntities = new List<List<buEntity>>();
			buEntity.Copy(data.WireAuxEntities, ref WireAuxEntities);
		}
		if (data.SolidEntities != null)
		{
			SolidEntities = new List<Entity>();
			buEntity.Copy(data.SolidEntities, ref SolidEntities);
		}
		if (data.CamBase != null)
		{
			CamBase = new camTp();
			camTp.CopyCam(data.CamBase, ref CamBase);
		}
		if (data.ToolSelected != null)
		{
			ToolSelected = new ToolBase5(data.ToolSelected);
		}
	}

	public static void Copy(MarbleItemCam refCam, ref MarbleItemCam copiedCam)
	{
		if (refCam != null)
		{
			copiedCam = new MarbleItemCam(refCam);
		}
	}

	public static void Copy(List<MarbleItemCam> refCam, ref List<MarbleItemCam> copiedCam)
	{
		if (refCam != null)
		{
			copiedCam = new List<MarbleItemCam>();
			for (int i = 0; i <= copiedCam.Count - 1; i++)
			{
				copiedCam.Add(new MarbleItemCam(refCam[i]));
			}
		}
	}

	public static ArrayList ToDef(MarbleItemCam refItemCam, int Space)
	{
		string text = "";
		ArrayList arrayList = new ArrayList();
		buSerilization5.ExceptionalVariables.Clear();
		buSerilization5.ExceptionalVariables.Add("EntityList");
		buSerilization5.ExceptionalVariables.Add("ToolSelected");
		buSerilization5.ExceptionalVariables.Add("setCam");
		arrayList.AddRange(refItemCam.ToDefAll("", Space, SerilizationMode5.MultiLine));
		if (arrayList.Count > 0)
		{
			text = arrayList[arrayList.Count - 1].ToString();
			arrayList.RemoveAt(arrayList.Count - 1);
			if (refItemCam.EntityList == null)
			{
			}
			if (refItemCam.ToolSelected != null)
			{
				arrayList.Add(buString5.SpaceChar(Space + 2) + "<ToolSelected>");
				arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItemCam.ToolSelected));
				arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItemCam.ToolSelected.Data));
				arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItemCam.ToolSelected.Geometry));
				arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItemCam.ToolSelected.CamData));
				arrayList.Add(buString5.SpaceChar(Space + 2) + "</ToolSelected>");
			}
			if (refItemCam.setCam != null)
			{
				arrayList.Add(buString5.SpaceChar(Space + 2) + "<CamSettings>");
				arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItemCam.setCam.Offsets));
				arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItemCam.setCam.Distances));
				arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItemCam.setCam.Drill));
				arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItemCam.setCam.Operations));
				arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItemCam.setCam.Options));
				arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItemCam.setCam.Pockets));
				arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItemCam.setCam.Speeds));
				arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItemCam.setCam.Steps));
				arrayList.Add(buString5.SpaceChar(Space + 4) + buSerilization5.ClassToString(refItemCam.setCam.Strategy));
				arrayList.Add(buString5.SpaceChar(Space + 2) + "</CamSettings>");
			}
			if (refItemCam.WireAuxEntities != null && refItemCam.WireAuxEntities.Count > 0)
			{
				arrayList.Add(buString5.SpaceChar(Space + 2) + "<WireAuxEntities>");
				arrayList.AddRange(buEntity.ToDefEntity(refItemCam.WireAuxEntities, Space + 4));
				arrayList.Add(buString5.SpaceChar(Space + 2) + "</WireAuxEntities>");
			}
			if (refItemCam.WireEntities != null && refItemCam.WireEntities.Count > 0)
			{
				arrayList.Add(buString5.SpaceChar(Space + 2) + "<WireEntities>");
				arrayList.AddRange(buEntity.ToDefEntity(refItemCam.WireEntities, Space + 4));
				arrayList.Add(buString5.SpaceChar(Space + 2) + "</WireEntities>");
			}
			if (refItemCam.ConcaveEntities != null && refItemCam.ConcaveEntities.Count > 0)
			{
				arrayList.Add(buString5.SpaceChar(Space + 2) + "<ConcaveEntities>");
				arrayList.AddRange(buEntity.ToDefEntity(refItemCam.ConcaveEntities, Space + 4));
				arrayList.Add(buString5.SpaceChar(Space + 2) + "</ConcaveEntities>");
			}
			if (refItemCam.ConvexEntities != null && refItemCam.ConvexEntities.Count > 0)
			{
				arrayList.Add(buString5.SpaceChar(Space + 2) + "<ConvexEntities>");
				arrayList.AddRange(buEntity.ToDefEntity(refItemCam.ConvexEntities, Space + 4));
				arrayList.Add(buString5.SpaceChar(Space + 2) + "</ConvexEntities>");
			}
			if (refItemCam.DrillEntities != null && refItemCam.DrillEntities.Count > 0)
			{
				arrayList.Add(buString5.SpaceChar(Space + 2) + "<DrillEntities>");
				arrayList.AddRange(buEntity.ToDefEntity(refItemCam.DrillEntities, Space + 4));
				arrayList.Add(buString5.SpaceChar(Space + 2) + "</DrillEntities>");
			}
			arrayList.Add(text);
		}
		return arrayList;
	}

	public static void Decode(List<string> SL, ref MarbleItemCam refItemCam)
	{
		try
		{
			refItemCam = new MarbleItemCam();
			buSerilization5.Decode(SL, "", SerilizationMode5.MultiLine, refItemCam);
			new List<List<string>>();
			List<string> CalcList = new List<string>();
			buStatics.ListToSpecificList("<ToolSelected>", "</ToolSelected>", AddStartEndKey: false, SL, ref CalcList);
			if (CalcList.Count > 0)
			{
				if (CalcList.Count >= 1)
				{
					refItemCam.ToolSelected = new ToolBase5();
					object ObjPar = refItemCam.ToolSelected;
					buSerilization5.StringToClass(ref ObjPar, CalcList[0]);
				}
				if (CalcList.Count >= 2)
				{
					object ObjPar2 = refItemCam.ToolSelected.Data;
					buSerilization5.StringToClass(ref ObjPar2, CalcList[1]);
				}
				if (CalcList.Count >= 3)
				{
					object ObjPar3 = refItemCam.ToolSelected.Geometry;
					buSerilization5.StringToClass(ref ObjPar3, CalcList[2]);
				}
				if (CalcList.Count >= 4)
				{
					object ObjPar4 = refItemCam.ToolSelected.CamData;
					buSerilization5.StringToClass(ref ObjPar4, CalcList[3]);
				}
				CalcList.Clear();
			}
			buStatics.ListToSpecificList("<CamSettings>", "</CamSettings>", AddStartEndKey: false, SL, ref CalcList);
			if (CalcList.Count > 0)
			{
				if (CalcList.Count >= 1)
				{
					object ObjPar5 = refItemCam.setCam.Offsets;
					buSerilization5.StringToClass(ref ObjPar5, CalcList[0]);
				}
				if (CalcList.Count >= 2)
				{
					object ObjPar6 = refItemCam.setCam.Distances;
					buSerilization5.StringToClass(ref ObjPar6, CalcList[1]);
				}
				if (CalcList.Count >= 3)
				{
					object ObjPar7 = refItemCam.setCam.Drill;
					buSerilization5.StringToClass(ref ObjPar7, CalcList[2]);
				}
				if (CalcList.Count >= 4)
				{
					object ObjPar8 = refItemCam.setCam.Operations;
					buSerilization5.StringToClass(ref ObjPar8, CalcList[3]);
				}
				if (CalcList.Count >= 5)
				{
					object ObjPar9 = refItemCam.setCam.Options;
					buSerilization5.StringToClass(ref ObjPar9, CalcList[4]);
				}
				if (CalcList.Count >= 6)
				{
					object ObjPar10 = refItemCam.setCam.Pockets;
					buSerilization5.StringToClass(ref ObjPar10, CalcList[5]);
				}
				if (CalcList.Count >= 7)
				{
					object ObjPar11 = refItemCam.setCam.Speeds;
					buSerilization5.StringToClass(ref ObjPar11, CalcList[6]);
				}
				if (CalcList.Count >= 8)
				{
					object ObjPar12 = refItemCam.setCam.Steps;
					buSerilization5.StringToClass(ref ObjPar12, CalcList[7]);
				}
				if (CalcList.Count >= 9)
				{
					object ObjPar13 = refItemCam.setCam.Strategy;
					buSerilization5.StringToClass(ref ObjPar13, CalcList[8]);
				}
				CalcList.Clear();
			}
			buStatics.ListToSpecificList("<WireEntities>", "</WireEntities>", AddStartEndKey: false, SL, ref CalcList);
			if (CalcList.Count > 0)
			{
				refItemCam.WireEntities = new List<List<buEntity>>();
				buEntity.Decode(CalcList, ref refItemCam.WireEntities);
				CalcList.Clear();
			}
			buStatics.ListToSpecificList("<WireAuxEntities>", "</WireAuxEntities>", AddStartEndKey: false, SL, ref CalcList);
			if (CalcList.Count > 0)
			{
				refItemCam.WireAuxEntities = new List<List<buEntity>>();
				buEntity.Decode(CalcList, ref refItemCam.WireAuxEntities);
				CalcList.Clear();
			}
			buStatics.ListToSpecificList("<ConcaveEntities>", "</ConcaveEntities>", AddStartEndKey: false, SL, ref CalcList);
			if (CalcList.Count > 0)
			{
				refItemCam.ConcaveEntities = new List<List<buEntity>>();
				buEntity.Decode(CalcList, ref refItemCam.ConcaveEntities);
				CalcList.Clear();
			}
			buStatics.ListToSpecificList("<ConvexEntities>", "</ConvexEntities>", AddStartEndKey: false, SL, ref CalcList);
			if (CalcList.Count > 0)
			{
				refItemCam.ConvexEntities = new List<List<buEntity>>();
				buEntity.Decode(CalcList, ref refItemCam.ConvexEntities);
				CalcList.Clear();
			}
			buStatics.ListToSpecificList("<DrillEntities>", "</ConcaveEntDrillEntitiesities>", AddStartEndKey: false, SL, ref CalcList);
			if (CalcList.Count > 0)
			{
				refItemCam.DrillEntities = new List<buEntity>();
				buEntity.Decode(CalcList, ref refItemCam.DrillEntities);
				CalcList.Clear();
			}
		}
		catch (Exception)
		{
		}
	}

	public static void Decode(List<string> SL, ref List<MarbleItemCam> refItemCams)
	{
		try
		{
			refItemCams = new List<MarbleItemCam>();
			if (SL.Count <= 0)
			{
				return;
			}
			List<List<string>> CalcList = new List<List<string>>();
			buStatics.ListToSpecificList("<MarbleItemCam>", "</MarbleItemCam>", AddStartEndKey: true, SL, ref CalcList);
			if (CalcList.Count > 0)
			{
				for (int i = 0; i <= CalcList.Count - 1; i++)
				{
					MarbleItemCam refItemCam = new MarbleItemCam();
					Decode(CalcList[i], ref refItemCam);
					refItemCams.Add(refItemCam);
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
		string text = "Tool: " + ToolType.ToString() + " - Cam: " + CamMarbleType;
		if (CamBase != null)
		{
			text = text + " - " + CamBase.TypeCam;
		}
		if (ToolType == MarbleToolType.Saw)
		{
			text = text + " - " + Direction;
		}
		if (isCamCalculated)
		{
			text += " - CamCalc";
		}
		if (isConcave)
		{
			text += " - Concave";
		}
		if (isConvex)
		{
			text += " - Convex";
		}
		if (isDrill)
		{
			text += " - Drill";
		}
		if (CamID >= 0)
		{
			text = text + " - CamID: " + CamID;
		}
		if (ItemID >= 0)
		{
			text = text + " - ItemID: " + ItemID;
		}
		return text;
	}
}
